﻿using System;
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
						pbFinalImage.Image = pr.ProgressReportImage;
					}

					lblBatchTime.Text = pr.BatchInfo;
				});
			}
		}

		private void btnGenerateRGBUniform_Click(object sender, EventArgs e)
			=> btnGenerate_Handler(ColourGenerator.GenerateColours_RGB_Uniform);

		private void btnGenerateHSBRandom_Click(object sender, EventArgs e)
			=> btnGenerate_Handler(ColourGenerator.GenerateColours_HSB_Random);

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

		private void saveCurrentImage_Click(object sender, EventArgs e)
			=> gen.Save();

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
