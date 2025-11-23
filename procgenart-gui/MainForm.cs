using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using all_rgb;
using poisson_disk_sampling;
using Zenith.Algorithms;
using Zenith.Colour;
using Zenith.Drawing;
using Zenith.ProceduralGeneration;
using Zenith.System.Drawing;

namespace all_rgb_gui
{
	public partial class MainForm : Form
	{
		private readonly AllRGBGenerator allrgbGen;
		private readonly SimplexNoiseParams snp;
		private readonly DiamondSquareParams dsp;
		private readonly RidgeNoiseParams rnp;

		private ImageBuffer CurrentBuffer
		{
			get => currentBuffer;

			set
			{
				currentBuffer = value;
				pbFinalImage.Image = currentBuffer.GetImage();
			}
		}
		private ImageBuffer currentBuffer;

		public MainForm()
		{
			InitializeComponent();
			allrgbGen = new AllRGBGenerator
			{
				ProgressCallback = OnGeneratorProgressReport
			};

			snp = new SimplexNoiseParams(128, 128, 0, 0, 0, 8, 3, 0.5, 1, 0.005, 1, false, 0, true);
			dsp = new DiamondSquareParams(128, 128, 0, 1.0, null);
			rnp = new RidgeNoiseParams(128, 128, 0, 1);
			pgSimplexNoise.SelectedObject = snp;
			pgDiamondSquare.SelectedObject = dsp;
			pgRidgeNoise.SelectedObject = rnp;
		}

		private void OnGeneratorProgressReport(ProgressReport pr)
		{
			if (IsHandleCreated)
			{
				_ = pgPaint.Invoke((MethodInvoker)delegate
				{
					pgPaint.Value = (int)(pr.Percent * 100);
					lblETA.Text = pr.ETAText;
					if (pr.ProgressReportImageBuffer != null)
					{
						CurrentBuffer = pr.ProgressReportImageBuffer;
						//var image = CurrentBuffer.GetImage();
						//var g = Graphics.FromImage(image);
						//var circleCentre = new Point(CurrentBuffer.Width / 2, CurrentBuffer.Height / 2);
						//var rect = new Rectangle(
						//	circleCentre.X - (int)pr.CurrentAverageRadius,
						//	circleCentre.Y - (int)pr.CurrentAverageRadius,
						//	(int)pr.CurrentAverageRadius * 2,
						//	(int)pr.CurrentAverageRadius * 2);
						//g.DrawEllipse(Pens.Red, rect);
						//pbFinalImage.Image = image;

						if (pr.Percent == 1f && !allrgbGen.Abort)
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
			allrgbGen.CreateBuffer(int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
			var totalColoursNeeded = allrgbGen.CurrentBuffer.Width * allrgbGen.CurrentBuffer.Height;
			allrgbGen.Colours = genFunc(totalColoursNeeded);
			if (allrgbGen.Colours == null || allrgbGen.Colours.Count != totalColoursNeeded)
			{
				_ = MessageBox.Show("Unable to generate enough colours for input image size.");
				return;
			}

			var buf = AllRGBGenerator.GetImageFromColours(
				allrgbGen.Colours,
				pbPalette.Width,
				pbPalette.Height);
			pbPalette.Image = buf.GetImage();
		}

		private async void btnPaint_Click(object sender, EventArgs e)
		{
			allrgbGen.AbortPaint();
			if (allrgbGen.PaintTask != null)
			{
				_ = await allrgbGen.PaintTask;
			}

			var width = int.Parse(tbWidth.Text);
			var height = int.Parse(tbHeight.Text);

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

				_ = allrgbGen.Paint(paintParams);
			}
			else if (tcProcGenTypes.SelectedTab == tpPoissonCircles)
			{
				var r = int.Parse(tbPoissonR.Text);
				var k = int.Parse(tbPoissonK.Text);

				var args = new PoissonDiskSamplerParams(width, height, r, k);
				var image = PoissonDiskSampler.Generate(args);
				CurrentBuffer = image;
				Save(GenSaveOptions.Image);
			}
			else if (tcProcGenTypes.SelectedTab == tpNoise)
			{
				double[,] output;
				Vector3[,] normals = null;
				if (tcNoiseGenerators.SelectedTab.Text == "Simplex Noise")
				{
					// not possible to hide width and height from the propertygrid from here, can only do it in the library containing the params structs, and it wouldn't make sense to do it there
					snp.Width = width;
					snp.Height = height;
					(output, normals) = SimplexNoiseGenerator.Generate(snp);
					//_SimplexNoiseGenerator.Erode(output);
				}
				else if (tcNoiseGenerators.SelectedTab.Text == "Diamond Square")
				{
					dsp.Width = width;
					dsp.Height = height;
					output = DiamondSquareGenerator.Generate(dsp);
				}
				else if (tcNoiseGenerators.SelectedTab.Text == "Ridge Noise")
				{
					rnp.Width = width;
					rnp.Height = height;
					output = RidgeNoiseGenerate(rnp);
				}
				else
				{
					return;
				}

				// turn double[,] into imagebuffer
				CurrentBuffer = ToImageBuffer(output);
				CurrentBuffer = CurrentBuffer.Convolve(Kernels.Blur, EdgeHandling.Extend);
				var extra = CurrentBuffer; // ToImageBuffer(output);

				var flowmap = SimplexNoiseGenerator.FlowMap(output);
				for (var y = 0; y < CurrentBuffer.Height; ++y)
				{
					for (var x = 0; x < CurrentBuffer.Width; ++x)
					{
						var flow = flowmap[x, y];
						var polar = (float)((Math.Atan2(flow.Y, flow.X) + Math.PI) / (Math.PI * 2));
						extra[x, y] = new ColourHSB(polar, 1, 1).AsRGB();
					}
				}

				CurrentBuffer = extra;
				//CurrentBuffer = CurrentBuffer.Convolve(Kernels.Blur, EdgeHandling.Extend);

				//CurrentBuffer = CurrentBuffer.Convolve(Kernels.EdgeDetection, EdgeHandling.Extend);

				if (normals != null)
				{
					//	CurrentBuffer = ToImageBuffer(normals);
				}

				Save(GenSaveOptions.Image);
			}
			else if (tcProcGenTypes.SelectedTab == tpFractal)
			{
				if (tcFractal.SelectedTab == tpSpaceFilling)
				{
					var args = new FractalGeneratorParams(width);
					var image = FractalGenerator.Generate(args, CurrentBuffer);
					CurrentBuffer = image;
					Save(GenSaveOptions.Image);
				}
			}
		}

		private static double[,] RidgeNoiseGenerate(RidgeNoiseParams rnp)
		{
			var data = new double[rnp.Width, rnp.Height];
			var noise = new OpenSimplexNoise(rnp.Seed);
			var frequency = 0.01;

			double ridgenoise(int x, int y) => 2 * (0.5 - Math.Abs(0.5 - noise.Evaluate(x * frequency, y * frequency)));

			for (var y = 0; y < data.GetLength(1); y++)
			{
				for (var x = 0; x < data.GetLength(0); x++)
				{
					var e0 = 1 * ridgenoise(1 * x, 1 * y);
					var e1 = 0.5 * ridgenoise(2 * x, 2 * y) * e0;
					var e2 = 0.25 * ridgenoise(4 * x, 4 * y) * (e0 + e1);
					var e = (e0 + e1 + e2) / (1 + 0.5 + 0.25);
					var r = Math.Pow(e, rnp.Exponent);
					if (double.IsNaN(r))
					{
						//Debugger.Break();
					}
					else
					{
						data[x, y] = r;
					}
				}
			}

			return data;
		}

		private static ImageBuffer ToImageBuffer(double[,] data)
		{
			var imageBuffer = new ImageBuffer(data.GetLength(0), data.GetLength(1));
			for (var y = 0; y < data.GetLength(1); ++y)
			{
				for (var x = 0; x < data.GetLength(0); ++x)
				{
					if (data[x, y] is < 0 or > 1)
					{
						imageBuffer.SetPixel(x, y, ColourRGB.Red);
					}
					else
					{
						var grey = (float)data[x, y];
						imageBuffer.SetPixel(x, y, new ColourRGB(grey, grey, grey));
					}
				}
			}

			return imageBuffer;
		}

		private static ImageBuffer ToImageBuffer(Vector3[,] data)
		{
			var imageBuffer = new ImageBuffer(data.GetLength(0), data.GetLength(1));
			for (var y = 0; y < data.GetLength(1); ++y)
			{
				for (var x = 0; x < data.GetLength(0); ++x)
				{
					imageBuffer.SetPixel(x, y, new ColourRGB((data[x, y].X + 1f) / 2f, (data[x, y].Y + 1f) / 2f, (data[x, y].Z + 1f) / 2f));
				}
			}

			return imageBuffer;
		}

		private void btnClearCanvas_Click(object sender, EventArgs e)
			=> pbFinalImage.Image = new Bitmap(int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));

		private NearestColourSelector GetNearestColourSelector()
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

		private SeedType GetSeedType()
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
			allrgbGen.Pause = !allrgbGen.Pause;
			btnPausePaint.Text = allrgbGen.Pause ? "Resume" : "Pause";
		}

		private void btnDenoisePaint_Click(object sender, EventArgs e)
		{
			var denoiserParams = new DenoiserParam
			{
				DenoisePixelThreshold = trbPixelNoiseThreshold.ValueAsNormalisedFloat
			};

			Denoiser.Denoise(allrgbGen.CurrentBuffer, denoiserParams);
			pbFinalImage.Image = allrgbGen.CurrentBuffer.GetImage();
		}

		private void btnAbortPaint_Click(object sender, EventArgs e)
			=> allrgbGen.AbortPaint();

		private void btnEqualise_Click(object sender, EventArgs e)
		{
			allrgbGen.Colours = ColourEqualiser.Equalise(allrgbGen.Colours).ToHashSet();
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(allrgbGen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnReverse_Click(object sender, EventArgs e)
		{
			allrgbGen.Colours = AllRGBGenerator.ReverseColours(allrgbGen.Colours.ToList()).ToHashSet();
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(allrgbGen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnShuffle_Click(object sender, EventArgs e)
		{
			allrgbGen.Colours = AllRGBGenerator.ShuffleColours(allrgbGen.Colours.ToList(), trbShufflePercentage.ValueAsNormalisedFloat, int.TryParse(tbShuffleSkip.Text, out var result) ? result : 1).ToHashSet();
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(allrgbGen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnSortRGB_Click(object sender, EventArgs e)
		{
			var rgbComponents = RGBComparerComponents.Empty;

			rgbComponents |= chkSortRed.Checked ? RGBComparerComponents.Red : RGBComparerComponents.Empty;
			rgbComponents |= chkSortGreen.Checked ? RGBComparerComponents.Green : RGBComparerComponents.Empty;
			rgbComponents |= chkSortBlue.Checked ? RGBComparerComponents.Blue : RGBComparerComponents.Empty;

			try
			{
				allrgbGen.Colours = AllRGBGenerator.SortColours(allrgbGen.Colours, AllRGBGenerator.SortType.RGB, rgbComponents, null);
			}
			catch (ArgumentException)
			{
				_ = MessageBox.Show("sorting failed");
			}

			pbPalette.Image = AllRGBGenerator.GetImageFromColours(allrgbGen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnSortHSB_Click(object sender, EventArgs e)
		{
			var hsbComponents = HSBComparerComponents.Empty;

			hsbComponents |= chkSortHue.Checked ? HSBComparerComponents.Hue : HSBComparerComponents.Empty;
			hsbComponents |= chkSortSat.Checked ? HSBComparerComponents.Saturation : HSBComparerComponents.Empty;
			hsbComponents |= chkSortBri.Checked ? HSBComparerComponents.Brightness : HSBComparerComponents.Empty;

			allrgbGen.Colours = AllRGBGenerator.SortColours(allrgbGen.Colours, AllRGBGenerator.SortType.HSB, null, hsbComponents);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(allrgbGen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void btnSortNN_Click(object sender, EventArgs e)
		{
			allrgbGen.Colours = AllRGBGenerator.SortColours(allrgbGen.Colours, AllRGBGenerator.SortType.NN);
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(allrgbGen.Colours, pbPalette.Width, pbPalette.Height).GetImage();
		}

		private void loadPalette_Click(object sender, EventArgs e)
		{
			using var ofd = new OpenFileDialog();
			ofd.InitialDirectory = BasePath;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var bmp = new Bitmap(ofd.FileName);
				var imageBuffer = ImageBufferHelpers.FromBitmap(bmp);
				allrgbGen.SetPalette(imageBuffer);

				pbPalette.Image = AllRGBGenerator.GetImageFromColours(
					allrgbGen.Colours,
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
				allrgbGen.SetTemplate(imageBuffer);
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
				allrgbGen.Clear();
				CurrentBuffer = ImageBufferHelpers.FromBitmap(bmp);
				allrgbGen.CurrentBuffer = CurrentBuffer;
				pbFinalImage.Image = allrgbGen.CurrentBuffer.GetImage();
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

		public void Save(GenSaveOptions options)
		{
			switch (options)
			{
				case GenSaveOptions.Palette:
					SavePalette();
					break;
				case GenSaveOptions.Image:
					if (!Directory.Exists(BasePath))
					{
						CurrentBuffer.Save(BasePath);
					}

					break;
			}
		}

		public const string BasePath = @"C:\Users\bigba\source\repos\all-rgb\Content";

		private void SavePalette()
		{
			var paletteBuffer = new ImageBuffer(allrgbGen.CurrentBuffer.Width, allrgbGen.CurrentBuffer.Height);
			var count = 0;
			foreach (var c in allrgbGen.Colours)
			{
				paletteBuffer.SetPixel(count % allrgbGen.CurrentBuffer.Width, count / allrgbGen.CurrentBuffer.Width, c);
				count++;
			}

			_ = paletteBuffer.Save(BasePath);
		}
	}
}
