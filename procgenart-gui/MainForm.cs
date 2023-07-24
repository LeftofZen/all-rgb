using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using all_rgb;
using poisson_disk_sampling;
using Zenith.Colour;
using Zenith.Drawing;
using Zenith.System.Drawing;

namespace all_rgb_gui
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			gen = new AllRGBGenerator
			{
				ProgressCallback = OnGeneratorProgressReport
			};
		}

		readonly AllRGBGenerator gen;

		void OnGeneratorProgressReport(ProgressReport pr)
		{
			if (IsHandleCreated)
			{
				_ = pgPaint.Invoke((MethodInvoker)delegate
				{
					pgPaint.Value = (int)(pr.Percent * 100);
					lblETA.Text = pr.ETAText;
					if (pr.ProgressReportImageBuffer != null)
					{
						var imageBuffer = pr.ProgressReportImageBuffer;
						var image = imageBuffer.GetImage();
						var g = Graphics.FromImage(image);
						var circleCentre = new Point(imageBuffer.Width / 2, imageBuffer.Height / 2);
						var rect = new Rectangle(
							circleCentre.X - (int)pr.CurrentAverageRadius,
							circleCentre.Y - (int)pr.CurrentAverageRadius,
							(int)pr.CurrentAverageRadius * 2,
							(int)pr.CurrentAverageRadius * 2);
						g.DrawEllipse(Pens.Red, rect);
						pbFinalImage.Image = image;

						if (pr.Percent == 1f && !gen.Abort)
						{
							Save(GenSaveOptions.Image); // autosave a completed image							
						}
					}

					lblBatchTime.Text = pr.BatchInfo;
				});
			}
		}

		private void btnGenerateRGBUniform_Click(object sender, EventArgs e)
			=> btnGeneratePalette_Handler(ColourGenerator.GenerateColours_RGB_Uniform);

		private void btnGenerateHSBUniform_Click(object sender, EventArgs e)
			=> btnGeneratePalette_Handler(ColourGenerator.GenerateColours_HSB_Uniform_RGB);

		private void btnGenerateHSBPastel_Click(object sender, EventArgs e)
			=> btnGeneratePalette_Handler(ColourGenerator.GenerateColours_HSB_Pastel_RGB);

		private void btnGenerateRGBPastel_Click(object sender, EventArgs e)
			=> btnGeneratePalette_Handler(ColourGenerator.GenerateColours_RGB_Pastel);

		private void btnGeneratePalette_Handler(Func<int, HashSet<ColourRGB>> genFunc)
		{
			gen.CreateBuffer(int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
			var totalColoursNeeded = gen.CurrentBuffer.Width * gen.CurrentBuffer.Height;
			gen.Colours = genFunc(totalColoursNeeded);
			if (gen.Colours == null || gen.Colours.Count != totalColoursNeeded)
			{
				_ = MessageBox.Show("Unable to generate enough colours for input image size.");
				return;
			}

			var buf = AllRGBGenerator.GetImageFromColours(
				gen.Colours,
				pbPalette.Width,
				pbPalette.Height);
			pbPalette.Image = buf.GetImage();
		}

		private async void btnPaint_Click(object sender, EventArgs e)
		{
			gen.AbortPaint();
			if (gen.PaintTask != null)
			{
				_ = await gen.PaintTask;
			}

			// contextual gen based on open tab
			if (tcProcGenTypes.SelectedTab == tpAllRGB)
			{
				var paintParams = new PaintParams
				{
					NearestColourSelector = GetNearestColourSelector(),
					RgbWeight = trbRGBWeight.ValueAsNormalisedFloat,
					HsbWeight = trbHSBWeight.ValueAsNormalisedFloat,
					NeighbourCountWeight = trbNeighbourCountWeight.ValueAsNormalisedFloat,
					NeighbourCountThreshold = trbNeighbourCountThreshold.ValueAsInt,
					DistanceWeight = trbDistanceWeight.ValueAsNormalisedFloat,
					SeedType = GetSeedType(),
					SeedCount = trbSeedCount.ValueAsInt,
				};

				_ = gen.Paint(paintParams);
			}
			else if (tcProcGenTypes.SelectedTab == tpPoissonCircles)
			{
				var width = int.Parse(tbWidth.Text);
				var height = int.Parse(tbHeight.Text);
				const int minimumDistanceBetweenSamples = 50;

				var points = Algorithm.Sample2D(width, height, minimumDistanceBetweenSamples);
				var image = new Bitmap(width, height);

				using (var graphics = Graphics.FromImage(image))
				{
					graphics.FillRectangle(Brushes.Black, 0f, 0f, width, height);
					//var pen = new Pen(Color.DarkRed, 2f);
					foreach (var p in points)
					{
						graphics.FillRectangle(Brushes.Yellow, p.X, p.Y, 1, 1);
						//graphics.FillEllipse(Brushes.Yellow, p.X - dot_r, p.Y - dot_r, 2f * dot_r, 2f * dot_r);
						//graphics.DrawEllipse(pen, p.X - minimumDistanceBetweenSamples / 2f, p.Y - minimumDistanceBetweenSamples / 2f, minimumDistanceBetweenSamples, minimumDistanceBetweenSamples);
					}
				}

				pbFinalImage.Image = image;
			}
		}

		private void btnClearCanvas_Click(object sender, EventArgs e)
			=> pbFinalImage.Image = new Bitmap(int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));

		NearestColourSelector GetNearestColourSelector()
		{
			if (rbPixelSelectorMin.Checked)
			{
				return NearestColourSelector.Min;
			}

			if (rbPixelSelectorMax.Checked)
			{
				return NearestColourSelector.Max;
			}

			if (rbPixelSelectorSum.Checked)
			{
				return NearestColourSelector.Sum;
			}

			if (rbPixelSelectorAvg.Checked)
			{
				return NearestColourSelector.Average;
			}

			// default
			return NearestColourSelector.Min;
		}

		SeedType GetSeedType()
		{
			if (rbCentre.Checked)
			{
				return SeedType.Centre;
			}
			else if (rbRandom.Checked)
			{
				return SeedType.Random;
			}

			// default
			return SeedType.Centre;
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			gen.Pause = !gen.Pause;
			btnPausePaint.Text = gen.Pause ? "Resume" : "Pause";
		}

		private void btnDenoisePaint_Click(object sender, EventArgs e)
		{
			var denoiserParams = new DenoiserParam
			{
				DenoisePixelThreshold = trbPixelNoiseThreshold.ValueAsNormalisedFloat
			};

			Denoiser.Denoise(gen.CurrentBuffer, denoiserParams);
			pbFinalImage.Image = gen.CurrentBuffer.GetImage();
		}

		private void btnAbortPaint_Click(object sender, EventArgs e)
			=> gen.AbortPaint();

		private void btnEqualise_Click(object sender, EventArgs e)
		{
			gen.Colours = ColourEqualiser.Equalise(gen.Colours).ToHashSet();
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnReverse_Click(object sender, EventArgs e)
		{
			gen.Colours = AllRGBGenerator.ReverseColours(gen.Colours.ToList()).ToHashSet();
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnShuffle_Click(object sender, EventArgs e)
		{
			gen.Colours = AllRGBGenerator.ShuffleColours(gen.Colours.ToList(), trbShufflePercentage.ValueAsNormalisedFloat, int.TryParse(tbShuffleSkip.Text, out var result) ? result : 1).ToHashSet();
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnSortRGB_Click(object sender, EventArgs e)
		{
			var rgbComponents = RGBComparerComponents.Empty;

			rgbComponents |= chkSortRed.Checked ? RGBComparerComponents.Red : RGBComparerComponents.Empty;
			rgbComponents |= chkSortGreen.Checked ? RGBComparerComponents.Green : RGBComparerComponents.Empty;
			rgbComponents |= chkSortBlue.Checked ? RGBComparerComponents.Blue : RGBComparerComponents.Empty;

			try
			{
				gen.Colours = AllRGBGenerator.SortColours(gen.Colours, AllRGBGenerator.SortType.RGB, rgbComponents, null);
			}
			catch (ArgumentException)
			{
				_ = MessageBox.Show("sorting failed");
			}

			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnSortHSB_Click(object sender, EventArgs e)
		{
			var hsbComponents = HSBComparerComponents.Empty;

			hsbComponents |= chkSortHue.Checked ? HSBComparerComponents.Hue : HSBComparerComponents.Empty;
			hsbComponents |= chkSortSat.Checked ? HSBComparerComponents.Saturation : HSBComparerComponents.Empty;
			hsbComponents |= chkSortBri.Checked ? HSBComparerComponents.Brightness : HSBComparerComponents.Empty;

			gen.Colours = AllRGBGenerator.SortColours(gen.Colours, AllRGBGenerator.SortType.HSB, null, hsbComponents);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnSortNN_Click(object sender, EventArgs e)
		{
			gen.Colours = AllRGBGenerator.SortColours(gen.Colours, AllRGBGenerator.SortType.NN);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void loadPalette_Click(object sender, EventArgs e)
		{
			using var ofd = new OpenFileDialog();
			ofd.InitialDirectory = BasePath;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var bmp = new Bitmap(ofd.FileName);
				var imageBuffer = ImageBufferHelpers.FromBitmap(bmp);
				gen.SetPalette(imageBuffer);

				pbPalette.Image = AllRGBGenerator.GetImageFromColours(
					gen.Colours,
					pbPalette.Width,
					pbPalette.Height).GetImage();
			}
		}

		private void loadTemplate_Click(object sender, EventArgs e)
		{
			using var ofd = new OpenFileDialog();
			ofd.InitialDirectory = BasePath;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var bmp = new Bitmap(ofd.FileName);
				var imageBuffer = ImageBufferHelpers.FromBitmap(bmp);
				tbWidth.Text = bmp.Width.ToString();
				tbHeight.Text = bmp.Height.ToString();
				gen.SetTemplate(imageBuffer);
				pbFinalImage.Image = bmp;
			}
		}

		private void loadImage_Click(object sender, EventArgs e)
		{
			using var ofd = new OpenFileDialog();
			ofd.InitialDirectory = BasePath;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var bmp = new Bitmap(ofd.FileName);
				tbWidth.Text = bmp.Width.ToString();
				tbHeight.Text = bmp.Height.ToString();
				gen.Clear();
				gen.CurrentBuffer = ImageBufferHelpers.FromBitmap(bmp);
				pbFinalImage.Image = gen.CurrentBuffer.GetImage();
			}
		}

		private void saveCurrentImage_Click(object sender, EventArgs e)
			=> Save(GenSaveOptions.Image);

		private void saveCurrentPalette_Click(object sender, EventArgs e)
			=> Save(GenSaveOptions.Palette);

		private void openImagesFolder_Click(object sender, EventArgs e)
			=> _ = Process.Start("explorer.exe", BasePath);

		private void cmbPresetSizes_SelectedIndexChanged(object sender, EventArgs e)
		{
			var txt = cmbPresetSizes.SelectedItem.ToString().Split('x');
			tbWidth.Text = txt[0];
			tbHeight.Text = txt[1];
		}

		public enum GenSaveOptions
		{
			Palette, Image
		}

		public void Save(GenSaveOptions options)
		{
			switch (options)
			{
				case GenSaveOptions.Palette:
					SavePalette();
					break;
				case GenSaveOptions.Image:
					gen.CurrentBuffer.Save(BasePath);
					break;
			}
		}

		public const string BasePath = @"C:\Users\bigba\source\repos\all-rgb\all-rgb\content";

		void SavePalette()
		{
			var paletteBuffer = new ImageBuffer(gen.CurrentBuffer.Width, gen.CurrentBuffer.Height);
			var count = 0;
			foreach (var c in gen.Colours)
			{
				paletteBuffer.SetPixel(count % gen.CurrentBuffer.Width, count / gen.CurrentBuffer.Width, c);
				count++;
			}

			paletteBuffer.Save(BasePath);
		}
	}
}
