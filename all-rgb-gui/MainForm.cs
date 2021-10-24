using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using all_rgb;

namespace all_rgb_gui
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			gen = new AllRGBGenerator();
			gen.ProgressCallback = OnGeneratorProgressReport;
		}

		AllRGBGenerator gen;

		void OnGeneratorProgressReport(ProgressReport pr)
		{
			if (IsHandleCreated)
			{
				pgPaint.Invoke((MethodInvoker)delegate
				{
					pgPaint.Value = (int)(pr.percent * 100);
					lblETA.Text = pr.etaText;
					if (pr.prgi != null)
					{
						pbFinalImage.Image = pr.prgi;
					}

					lblBatchTime.Text = pr.batchInfo;
				});
			}
		}

		private void btnGenerateRGBUniform_Click(object sender, EventArgs e)
		{
			btnGenerate_Handler(ColourGenerator.GenerateColours_RGB_Uniform);
		}

		private void btnGenerateHSBRandom_Click(object sender, EventArgs e)
		{
			btnGenerate_Handler(ColourGenerator.GenerateColours_HSB_Random);
		}

		private void btnGenerate_Handler(Func<int, HashSet<Colour>> genFunc)
		{
			gen.CreateBuffer(int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
			gen.Colours = genFunc(gen.CurrentBuffer.Width * gen.CurrentBuffer.Height).ToList();
			pbPalette.Image = AllRGBGenerator.GetImageFromColours(
				gen.Colours,
				pbPalette.Width,
				pbPalette.Height);
		}

		private void btnPaint_Click(object sender, EventArgs e)
		{
			var nearestColourParam = new NearestColourParam
			{
				UseMin = !chkAverageMode.Checked,
				RgbWeight = trbRGBWeight.ValueAsNormalisedFloat,
				HsbWeight = trbHSBWeight.ValueAsNormalisedFloat,
				NeighbourCountWeight = trbNeighbourCountWeight.ValueAsNormalisedFloat,
				NeighbourCountThreshold = trbNeighbourCountThreshold.ValueAsInt,
				DistanceWeight = trbDistanceWeight.ValueAsNormalisedFloat,
			};

			_ = gen.Paint(nearestColourParam);
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			gen.Pause = !gen.Pause;
			btnPausePaint.Text = gen.Pause ? "Resume" : "Pause";
		}

		private void btnAbortPaint_Click(object sender, EventArgs e)
		{
			gen.AbortPaint();
		}

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

			if (chkSortRed.Checked)
				rgbComponents |= RGBComparerComponents.Red;
			if (chkSortGreen.Checked)
				rgbComponents |= RGBComparerComponents.Green;
			if (chkSortBlue.Checked)
				rgbComponents |= RGBComparerComponents.Blue;

			gen.Colours = AllRGBGenerator.SortColours(gen.Colours, AllRGBGenerator.SortType.RGB, rgbComponents, null);

			pbPalette.Image = AllRGBGenerator.GetImageFromColours(gen.Colours, pbPalette.Width, pbPalette.Height);
		}

		private void btnSortHSB_Click(object sender, EventArgs e)
		{
			var hsbComponents = HSBComparerComponents.Empty;

			if (chkSortHue.Checked)
				hsbComponents |= HSBComparerComponents.Hue;
			if (chkSortSat.Checked)
				hsbComponents |= HSBComparerComponents.Saturation;
			if (chkSortBri.Checked)
				hsbComponents |= HSBComparerComponents.Brightness;

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

		private void saveCurrentImage_Click(object sender, EventArgs e)
		{
			gen.Save();
		}

		private void openImagesFolder_Click(object sender, EventArgs e)
		{
			_ = Process.Start("explorer.exe", ImageBuffer.BaseFileName);
		}


	}
}
