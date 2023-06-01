using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using all_rgb;
using poisson_disk_sampling;
using procgenart_core;

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
					if (pr.ProgressReportImage != null)
					{
						var img = pr.ProgressReportImage;
						var g = Graphics.FromImage(img);
						var circleCentre = new Point(img.Width / 2, img.Height / 2);
						var rect = new Rectangle(
							circleCentre.X - (int)pr.CurrentAverageRadius,
							circleCentre.Y - (int)pr.CurrentAverageRadius,
							(int)pr.CurrentAverageRadius * 2,
							(int)pr.CurrentAverageRadius * 2);
						g.DrawEllipse(Pens.Red, rect);
						pbFinalImage.Image = img;
					}

					lblBatchTime.Text = pr.BatchInfo;
				});
			}
		}

		private void btnGenerateRGBUniform_Click(object sender, EventArgs e)
			=> btnGenerate_Handler(ColourGenerator.GenerateColours_RGB_Uniform);

		private void btnGenerateHSBRandom_Click(object sender, EventArgs e)
			=> btnGenerate_Handler(ColourGenerator.GenerateColours_HSB_Random);

		private void btnGenerateRGBPastel_Click(object sender, EventArgs e)
		=> btnGenerate_Handler(ColourGenerator.GenerateColours_RGB_Pastel);

		private void btnGenerate_Handler(Func<int, HashSet<Colour>> genFunc)
		{
			gen.CreateBuffer(int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
			var totalColoursNeeded = gen.CurrentBuffer.Width * gen.CurrentBuffer.Height;
			gen.Colours = genFunc(totalColoursNeeded).ToList();
			if (gen.Colours == null || gen.Colours.Count != totalColoursNeeded)
			{
				MessageBox.Show("Unable to generate enough colours for input image size.");
				return;
			}

			pbPalette.Image = AllRGBGenerator.GetImageFromColours(
				gen.Colours,
				pbPalette.Width,
				pbPalette.Height);
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
				var nearestColourParam = new NearestColourParam
				{
					NearestColourSelector = GetNearestColourSelector(),
					RgbWeight = trbRGBWeight.ValueAsNormalisedFloat,
					HsbWeight = trbHSBWeight.ValueAsNormalisedFloat,
					NeighbourCountWeight = trbNeighbourCountWeight.ValueAsNormalisedFloat,
					NeighbourCountThreshold = trbNeighbourCountThreshold.ValueAsInt,
					DistanceWeight = trbDistanceWeight.ValueAsNormalisedFloat,
				};

				_ = gen.Paint(nearestColourParam);
			}
			else if (tcProcGenTypes.SelectedTab == tpPoissonCircles)
			{
				var width = int.Parse(tbWidth.Text);
				var height = int.Parse(tbHeight.Text);
				var minimumDistanceBetweenSamples = 50;

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
		{
			var buf = new ImageBuffer(int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
			pbFinalImage.Image = buf.GetImage();
		}

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
			pbFinalImage.Image = gen.GetCurrentImage();
		}

		private void btnAbortPaint_Click(object sender, EventArgs e)
			=> gen.AbortPaint();

		private void btnEqualise_Click(object sender, EventArgs e)
		{
			gen.Colours = ColourEqualiser.Equalise(gen.Colours);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height);
		}

		private void btnReverse_Click(object sender, EventArgs e)
		{
			gen.Colours = AllRGBGenerator.ReverseColours(gen.Colours);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height);
		}

		private void btnShuffle_Click(object sender, EventArgs e)
		{
			gen.Colours = AllRGBGenerator.ShuffleColours(gen.Colours, trbShufflePercentage.ValueAsNormalisedFloat, int.TryParse(tbShuffleSkip.Text, out var result) ? result : 1);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height);
		}

		private void btnSortRGB_Click(object sender, EventArgs e)
		{
			var rgbComponents = RGBComparerComponents.Empty;

			rgbComponents |= chkSortRed.Checked ? RGBComparerComponents.Red : RGBComparerComponents.Empty;
			rgbComponents |= chkSortGreen.Checked ? RGBComparerComponents.Green : RGBComparerComponents.Empty;
			rgbComponents |= chkSortBlue.Checked ? RGBComparerComponents.Blue : RGBComparerComponents.Empty;

			gen.Colours = AllRGBGenerator.SortColours(gen.Colours, AllRGBGenerator.SortType.RGB, rgbComponents, null);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height);
		}

		private void btnSortHSB_Click(object sender, EventArgs e)
		{
			var hsbComponents = HSBComparerComponents.Empty;

			hsbComponents |= chkSortHue.Checked ? HSBComparerComponents.Hue : HSBComparerComponents.Empty;
			hsbComponents |= chkSortSat.Checked ? HSBComparerComponents.Saturation : HSBComparerComponents.Empty;
			hsbComponents |= chkSortBri.Checked ? HSBComparerComponents.Brightness : HSBComparerComponents.Empty;

			gen.Colours = AllRGBGenerator.SortColours(gen.Colours, AllRGBGenerator.SortType.HSB, null, hsbComponents);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height);
		}

		private void btnSortNN_Click(object sender, EventArgs e)
		{
			gen.Colours = AllRGBGenerator.SortColours(gen.Colours, AllRGBGenerator.SortType.NN);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height);
		}

		private void loadPalette_Click(object sender, EventArgs e)
		{
			using var ofd = new OpenFileDialog();
			ofd.InitialDirectory = ImageBuffer.BaseFileName;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var bmp = new Bitmap(ofd.FileName);
				gen.CreatePalette(bmp);

				pbPalette.Image = AllRGBGenerator.GetImageFromColours(
					gen.Colours,
					pbPalette.Width,
					pbPalette.Height);
			}
		}

		private void loadTemplate_Click(object sender, EventArgs e)
		{
			using var ofd = new OpenFileDialog();
			ofd.InitialDirectory = ImageBuffer.BaseFileName;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var bmp = new Bitmap(ofd.FileName);
				tbWidth.Text = bmp.Width.ToString();
				tbHeight.Text = bmp.Height.ToString();
				gen.CreateTemplate(bmp);
				pbFinalImage.Image = bmp;
			}
		}

		private void loadImage_Click(object sender, EventArgs e)
		{
			using var ofd = new OpenFileDialog();
			ofd.InitialDirectory = ImageBuffer.BaseFileName;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var bmp = new Bitmap(ofd.FileName);
				tbWidth.Text = bmp.Width.ToString();
				tbHeight.Text = bmp.Height.ToString();
				gen.BufferFromImage(bmp);
				pbFinalImage.Image = gen.GetCurrentImage();
			}
		}

		private void saveCurrentImage_Click(object sender, EventArgs e)
			=> gen.Save(AllRGBGenerator.GenSaveOptions.Image);


		private void saveCurrentPalette_Click(object sender, EventArgs e)
			=> gen.Save(AllRGBGenerator.GenSaveOptions.Palette);

		private void openImagesFolder_Click(object sender, EventArgs e)
			=> _ = Process.Start("explorer.exe", ImageBuffer.BaseFileName);

		private void cmbPresetSizes_SelectedIndexChanged(object sender, EventArgs e)
		{
			var txt = cmbPresetSizes.SelectedItem.ToString().Split('x');
			tbWidth.Text = txt[0];
			tbHeight.Text = txt[1];
		}
	}
}
