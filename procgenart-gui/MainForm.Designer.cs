﻿namespace all_rgb_gui
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pbFinalImage = new PictureBoxWithInterpolationMode();
			pbPalette = new PictureBoxWithInterpolationMode();
			btnGenerateRGBUniform = new System.Windows.Forms.Button();
			btnPaint = new System.Windows.Forms.Button();
			tbWidth = new System.Windows.Forms.TextBox();
			tbHeight = new System.Windows.Forms.TextBox();
			lblWidth = new System.Windows.Forms.Label();
			lblHeight = new System.Windows.Forms.Label();
			pgPaint = new System.Windows.Forms.ProgressBar();
			lblETA = new System.Windows.Forms.Label();
			btnPausePaint = new System.Windows.Forms.Button();
			grpPalette = new System.Windows.Forms.GroupBox();
			tcAllRGB = new System.Windows.Forms.TabControl();
			tpGeneration = new System.Windows.Forms.TabPage();
			btnGenerateRGBPastel = new System.Windows.Forms.Button();
			btnGenerateHSBRandom = new System.Windows.Forms.Button();
			tpPaletteSorting = new System.Windows.Forms.TabPage();
			chkSortHue = new System.Windows.Forms.CheckBox();
			btnSortNN = new System.Windows.Forms.Button();
			btnSortRGB = new System.Windows.Forms.Button();
			chkSortBlue = new System.Windows.Forms.CheckBox();
			chkSortSat = new System.Windows.Forms.CheckBox();
			chkSortGreen = new System.Windows.Forms.CheckBox();
			chkSortRed = new System.Windows.Forms.CheckBox();
			chkSortBri = new System.Windows.Forms.CheckBox();
			btnSortHSB = new System.Windows.Forms.Button();
			tpPaletteShuffing = new System.Windows.Forms.TabPage();
			btnShuffle = new System.Windows.Forms.Button();
			tbShuffleSkip = new System.Windows.Forms.TextBox();
			lblShuffleSkip = new System.Windows.Forms.Label();
			trbShufflePercentage = new BetterTrackBar();
			tpPaletteMisc = new System.Windows.Forms.TabPage();
			btnReverse = new System.Windows.Forms.Button();
			btnEqualise = new System.Windows.Forms.Button();
			grpPaint = new System.Windows.Forms.GroupBox();
			btnClearCanvas = new System.Windows.Forms.Button();
			btnAbortPaint = new System.Windows.Forms.Button();
			grpPaintParams = new System.Windows.Forms.GroupBox();
			rbPixelSelectorSum = new System.Windows.Forms.RadioButton();
			rbPixelSelectorAvg = new System.Windows.Forms.RadioButton();
			rbPixelSelectorMax = new System.Windows.Forms.RadioButton();
			rbPixelSelectorMin = new System.Windows.Forms.RadioButton();
			trbNeighbourCountThreshold = new BetterTrackBar();
			trbNeighbourCountWeight = new BetterTrackBar();
			trbDistanceWeight = new BetterTrackBar();
			trbHSBWeight = new BetterTrackBar();
			trbRGBWeight = new BetterTrackBar();
			btnDenoiseRGB = new System.Windows.Forms.Button();
			grpImageProperties = new System.Windows.Forms.GroupBox();
			cmbPresetSizes = new System.Windows.Forms.ComboBox();
			lblBatchTime = new System.Windows.Forms.Label();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			loadPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			paletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openSavedImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			currentImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			paletteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			grpDenoiserParams = new System.Windows.Forms.GroupBox();
			btnDenoiseHSB = new System.Windows.Forms.Button();
			trbPixelNoiseThreshold = new BetterTrackBar();
			tcProcGenTypes = new System.Windows.Forms.TabControl();
			tpAllRGB = new System.Windows.Forms.TabPage();
			tpPoissonCircles = new System.Windows.Forms.TabPage();
			lbRunningTasks = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)pbFinalImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbPalette).BeginInit();
			grpPalette.SuspendLayout();
			tcAllRGB.SuspendLayout();
			tpGeneration.SuspendLayout();
			tpPaletteSorting.SuspendLayout();
			tpPaletteShuffing.SuspendLayout();
			tpPaletteMisc.SuspendLayout();
			grpPaint.SuspendLayout();
			grpPaintParams.SuspendLayout();
			grpImageProperties.SuspendLayout();
			menuStrip1.SuspendLayout();
			grpDenoiserParams.SuspendLayout();
			tcProcGenTypes.SuspendLayout();
			tpAllRGB.SuspendLayout();
			SuspendLayout();
			// 
			// pbFinalImage
			// 
			pbFinalImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pbFinalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			pbFinalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbFinalImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			pbFinalImage.Location = new System.Drawing.Point(681, 27);
			pbFinalImage.Name = "pbFinalImage";
			pbFinalImage.Size = new System.Drawing.Size(1210, 957);
			pbFinalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pbFinalImage.TabIndex = 0;
			pbFinalImage.TabStop = false;
			// 
			// pbPalette
			// 
			pbPalette.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pbPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbPalette.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			pbPalette.Location = new System.Drawing.Point(3, 207);
			pbPalette.Name = "pbPalette";
			pbPalette.Size = new System.Drawing.Size(293, 663);
			pbPalette.TabIndex = 7;
			pbPalette.TabStop = false;
			// 
			// btnGenerateRGBUniform
			// 
			btnGenerateRGBUniform.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnGenerateRGBUniform.BackColor = System.Drawing.SystemColors.ControlLight;
			btnGenerateRGBUniform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnGenerateRGBUniform.Location = new System.Drawing.Point(3, 6);
			btnGenerateRGBUniform.Name = "btnGenerateRGBUniform";
			btnGenerateRGBUniform.Size = new System.Drawing.Size(276, 23);
			btnGenerateRGBUniform.TabIndex = 1;
			btnGenerateRGBUniform.Text = "Generate RGB Uniform";
			btnGenerateRGBUniform.UseVisualStyleBackColor = false;
			btnGenerateRGBUniform.Click += btnGenerateRGBUniform_Click;
			// 
			// btnPaint
			// 
			btnPaint.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
			btnPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnPaint.Location = new System.Drawing.Point(6, 17);
			btnPaint.Name = "btnPaint";
			btnPaint.Size = new System.Drawing.Size(75, 23);
			btnPaint.TabIndex = 3;
			btnPaint.Text = "Paint";
			btnPaint.UseVisualStyleBackColor = false;
			btnPaint.Click += btnPaint_Click;
			// 
			// tbWidth
			// 
			tbWidth.Location = new System.Drawing.Point(51, 16);
			tbWidth.Name = "tbWidth";
			tbWidth.Size = new System.Drawing.Size(39, 23);
			tbWidth.TabIndex = 5;
			tbWidth.Text = "128";
			// 
			// tbHeight
			// 
			tbHeight.Location = new System.Drawing.Point(145, 16);
			tbHeight.Name = "tbHeight";
			tbHeight.Size = new System.Drawing.Size(39, 23);
			tbHeight.TabIndex = 6;
			tbHeight.Text = "128";
			// 
			// lblWidth
			// 
			lblWidth.AutoSize = true;
			lblWidth.Location = new System.Drawing.Point(6, 19);
			lblWidth.Name = "lblWidth";
			lblWidth.Size = new System.Drawing.Size(39, 15);
			lblWidth.TabIndex = 10;
			lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			lblHeight.AutoSize = true;
			lblHeight.Location = new System.Drawing.Point(96, 19);
			lblHeight.Name = "lblHeight";
			lblHeight.Size = new System.Drawing.Size(43, 15);
			lblHeight.TabIndex = 11;
			lblHeight.Text = "Height";
			// 
			// pgPaint
			// 
			pgPaint.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pgPaint.Location = new System.Drawing.Point(12, 991);
			pgPaint.Name = "pgPaint";
			pgPaint.Size = new System.Drawing.Size(1879, 23);
			pgPaint.TabIndex = 13;
			// 
			// lblETA
			// 
			lblETA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lblETA.AutoSize = true;
			lblETA.Location = new System.Drawing.Point(12, 1017);
			lblETA.Name = "lblETA";
			lblETA.Size = new System.Drawing.Size(26, 15);
			lblETA.TabIndex = 14;
			lblETA.Text = "ETA";
			// 
			// btnPausePaint
			// 
			btnPausePaint.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			btnPausePaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnPausePaint.Location = new System.Drawing.Point(87, 17);
			btnPausePaint.Name = "btnPausePaint";
			btnPausePaint.Size = new System.Drawing.Size(75, 23);
			btnPausePaint.TabIndex = 15;
			btnPausePaint.Text = "Pause";
			btnPausePaint.UseVisualStyleBackColor = false;
			btnPausePaint.Click += btnPause_Click;
			// 
			// grpPalette
			// 
			grpPalette.Controls.Add(tcAllRGB);
			grpPalette.Controls.Add(pbPalette);
			grpPalette.Location = new System.Drawing.Point(8, 3);
			grpPalette.Name = "grpPalette";
			grpPalette.Size = new System.Drawing.Size(299, 904);
			grpPalette.TabIndex = 18;
			grpPalette.TabStop = false;
			grpPalette.Text = "Palette";
			// 
			// tcAllRGB
			// 
			tcAllRGB.Controls.Add(tpGeneration);
			tcAllRGB.Controls.Add(tpPaletteSorting);
			tcAllRGB.Controls.Add(tpPaletteShuffing);
			tcAllRGB.Controls.Add(tpPaletteMisc);
			tcAllRGB.Dock = System.Windows.Forms.DockStyle.Top;
			tcAllRGB.Location = new System.Drawing.Point(3, 19);
			tcAllRGB.Name = "tcAllRGB";
			tcAllRGB.SelectedIndex = 0;
			tcAllRGB.Size = new System.Drawing.Size(293, 182);
			tcAllRGB.TabIndex = 23;
			// 
			// tpGeneration
			// 
			tpGeneration.Controls.Add(btnGenerateRGBPastel);
			tpGeneration.Controls.Add(btnGenerateRGBUniform);
			tpGeneration.Controls.Add(btnGenerateHSBRandom);
			tpGeneration.Location = new System.Drawing.Point(4, 24);
			tpGeneration.Name = "tpGeneration";
			tpGeneration.Padding = new System.Windows.Forms.Padding(3);
			tpGeneration.Size = new System.Drawing.Size(285, 154);
			tpGeneration.TabIndex = 0;
			tpGeneration.Text = "Generation";
			tpGeneration.UseVisualStyleBackColor = true;
			// 
			// btnGenerateRGBPastel
			// 
			btnGenerateRGBPastel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnGenerateRGBPastel.BackColor = System.Drawing.SystemColors.ControlLight;
			btnGenerateRGBPastel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnGenerateRGBPastel.Location = new System.Drawing.Point(4, 66);
			btnGenerateRGBPastel.Name = "btnGenerateRGBPastel";
			btnGenerateRGBPastel.Size = new System.Drawing.Size(276, 23);
			btnGenerateRGBPastel.TabIndex = 27;
			btnGenerateRGBPastel.Text = "Generate RGB Pastel";
			btnGenerateRGBPastel.UseVisualStyleBackColor = false;
			btnGenerateRGBPastel.Click += btnGenerateRGBPastel_Click;
			// 
			// btnGenerateHSBRandom
			// 
			btnGenerateHSBRandom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnGenerateHSBRandom.BackColor = System.Drawing.SystemColors.ControlLight;
			btnGenerateHSBRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnGenerateHSBRandom.Location = new System.Drawing.Point(3, 35);
			btnGenerateHSBRandom.Name = "btnGenerateHSBRandom";
			btnGenerateHSBRandom.Size = new System.Drawing.Size(276, 23);
			btnGenerateHSBRandom.TabIndex = 26;
			btnGenerateHSBRandom.Text = "Generate HSB Random";
			btnGenerateHSBRandom.UseVisualStyleBackColor = false;
			btnGenerateHSBRandom.Click += btnGenerateHSBRandom_Click;
			// 
			// tpPaletteSorting
			// 
			tpPaletteSorting.Controls.Add(chkSortHue);
			tpPaletteSorting.Controls.Add(btnSortNN);
			tpPaletteSorting.Controls.Add(btnSortRGB);
			tpPaletteSorting.Controls.Add(chkSortBlue);
			tpPaletteSorting.Controls.Add(chkSortSat);
			tpPaletteSorting.Controls.Add(chkSortGreen);
			tpPaletteSorting.Controls.Add(chkSortRed);
			tpPaletteSorting.Controls.Add(chkSortBri);
			tpPaletteSorting.Controls.Add(btnSortHSB);
			tpPaletteSorting.Location = new System.Drawing.Point(4, 24);
			tpPaletteSorting.Name = "tpPaletteSorting";
			tpPaletteSorting.Padding = new System.Windows.Forms.Padding(3);
			tpPaletteSorting.Size = new System.Drawing.Size(285, 154);
			tpPaletteSorting.TabIndex = 1;
			tpPaletteSorting.Text = "Sorting";
			tpPaletteSorting.UseVisualStyleBackColor = true;
			// 
			// chkSortHue
			// 
			chkSortHue.AutoSize = true;
			chkSortHue.Location = new System.Drawing.Point(6, 6);
			chkSortHue.Name = "chkSortHue";
			chkSortHue.Size = new System.Drawing.Size(48, 19);
			chkSortHue.TabIndex = 15;
			chkSortHue.Text = "Hue";
			chkSortHue.UseVisualStyleBackColor = true;
			// 
			// btnSortNN
			// 
			btnSortNN.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnSortNN.BackColor = System.Drawing.SystemColors.ControlLight;
			btnSortNN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSortNN.Location = new System.Drawing.Point(3, 114);
			btnSortNN.Name = "btnSortNN";
			btnSortNN.Size = new System.Drawing.Size(169, 23);
			btnSortNN.TabIndex = 14;
			btnSortNN.Text = "Sort NN (slow)";
			btnSortNN.UseVisualStyleBackColor = false;
			btnSortNN.Click += btnSortNN_Click;
			// 
			// btnSortRGB
			// 
			btnSortRGB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnSortRGB.BackColor = System.Drawing.SystemColors.ControlLight;
			btnSortRGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSortRGB.Location = new System.Drawing.Point(3, 85);
			btnSortRGB.Name = "btnSortRGB";
			btnSortRGB.Size = new System.Drawing.Size(169, 23);
			btnSortRGB.TabIndex = 12;
			btnSortRGB.Text = "Sort RGB";
			btnSortRGB.UseVisualStyleBackColor = false;
			btnSortRGB.Click += btnSortRGB_Click;
			// 
			// chkSortBlue
			// 
			chkSortBlue.AutoSize = true;
			chkSortBlue.Location = new System.Drawing.Point(123, 60);
			chkSortBlue.Name = "chkSortBlue";
			chkSortBlue.Size = new System.Drawing.Size(49, 19);
			chkSortBlue.TabIndex = 20;
			chkSortBlue.Text = "Blue";
			chkSortBlue.UseVisualStyleBackColor = true;
			// 
			// chkSortSat
			// 
			chkSortSat.AutoSize = true;
			chkSortSat.Location = new System.Drawing.Point(60, 6);
			chkSortSat.Name = "chkSortSat";
			chkSortSat.Size = new System.Drawing.Size(42, 19);
			chkSortSat.TabIndex = 16;
			chkSortSat.Text = "Sat";
			chkSortSat.UseVisualStyleBackColor = true;
			// 
			// chkSortGreen
			// 
			chkSortGreen.AutoSize = true;
			chkSortGreen.Location = new System.Drawing.Point(60, 60);
			chkSortGreen.Name = "chkSortGreen";
			chkSortGreen.Size = new System.Drawing.Size(57, 19);
			chkSortGreen.TabIndex = 19;
			chkSortGreen.Text = "Green";
			chkSortGreen.UseVisualStyleBackColor = true;
			// 
			// chkSortRed
			// 
			chkSortRed.AutoSize = true;
			chkSortRed.Location = new System.Drawing.Point(6, 60);
			chkSortRed.Name = "chkSortRed";
			chkSortRed.Size = new System.Drawing.Size(46, 19);
			chkSortRed.TabIndex = 18;
			chkSortRed.Text = "Red";
			chkSortRed.UseVisualStyleBackColor = true;
			// 
			// chkSortBri
			// 
			chkSortBri.AutoSize = true;
			chkSortBri.Location = new System.Drawing.Point(108, 6);
			chkSortBri.Name = "chkSortBri";
			chkSortBri.Size = new System.Drawing.Size(40, 19);
			chkSortBri.TabIndex = 17;
			chkSortBri.Text = "Bri";
			chkSortBri.UseVisualStyleBackColor = true;
			// 
			// btnSortHSB
			// 
			btnSortHSB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnSortHSB.BackColor = System.Drawing.SystemColors.ControlLight;
			btnSortHSB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSortHSB.Location = new System.Drawing.Point(3, 31);
			btnSortHSB.Name = "btnSortHSB";
			btnSortHSB.Size = new System.Drawing.Size(169, 23);
			btnSortHSB.TabIndex = 13;
			btnSortHSB.Text = "Sort HSB";
			btnSortHSB.UseVisualStyleBackColor = false;
			btnSortHSB.Click += btnSortHSB_Click;
			// 
			// tpPaletteShuffing
			// 
			tpPaletteShuffing.Controls.Add(btnShuffle);
			tpPaletteShuffing.Controls.Add(tbShuffleSkip);
			tpPaletteShuffing.Controls.Add(lblShuffleSkip);
			tpPaletteShuffing.Controls.Add(trbShufflePercentage);
			tpPaletteShuffing.Location = new System.Drawing.Point(4, 24);
			tpPaletteShuffing.Name = "tpPaletteShuffing";
			tpPaletteShuffing.Size = new System.Drawing.Size(285, 154);
			tpPaletteShuffing.TabIndex = 2;
			tpPaletteShuffing.Text = "Shuffling";
			tpPaletteShuffing.UseVisualStyleBackColor = true;
			// 
			// btnShuffle
			// 
			btnShuffle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnShuffle.BackColor = System.Drawing.SystemColors.ControlLight;
			btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnShuffle.Location = new System.Drawing.Point(0, 65);
			btnShuffle.Name = "btnShuffle";
			btnShuffle.Size = new System.Drawing.Size(282, 23);
			btnShuffle.TabIndex = 10;
			btnShuffle.Text = "Shuffle";
			btnShuffle.UseVisualStyleBackColor = false;
			btnShuffle.Click += btnShuffle_Click;
			// 
			// tbShuffleSkip
			// 
			tbShuffleSkip.Location = new System.Drawing.Point(126, 36);
			tbShuffleSkip.Name = "tbShuffleSkip";
			tbShuffleSkip.Size = new System.Drawing.Size(39, 23);
			tbShuffleSkip.TabIndex = 27;
			tbShuffleSkip.Text = "1";
			// 
			// lblShuffleSkip
			// 
			lblShuffleSkip.AutoSize = true;
			lblShuffleSkip.Location = new System.Drawing.Point(3, 39);
			lblShuffleSkip.Name = "lblShuffleSkip";
			lblShuffleSkip.Size = new System.Drawing.Size(117, 15);
			lblShuffleSkip.TabIndex = 12;
			lblShuffleSkip.Text = "Shuffle Every X Items";
			// 
			// trbShufflePercentage
			// 
			trbShufflePercentage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			trbShufflePercentage.BackColor = System.Drawing.SystemColors.ControlLight;
			trbShufflePercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			trbShufflePercentage.Caption = "%";
			trbShufflePercentage.Location = new System.Drawing.Point(3, 4);
			trbShufflePercentage.Maximum = 100;
			trbShufflePercentage.Minimum = 0;
			trbShufflePercentage.Name = "trbShufflePercentage";
			trbShufflePercentage.Size = new System.Drawing.Size(279, 26);
			trbShufflePercentage.TabIndex = 25;
			trbShufflePercentage.Value = "100";
			// 
			// tpPaletteMisc
			// 
			tpPaletteMisc.Controls.Add(btnReverse);
			tpPaletteMisc.Controls.Add(btnEqualise);
			tpPaletteMisc.Location = new System.Drawing.Point(4, 24);
			tpPaletteMisc.Name = "tpPaletteMisc";
			tpPaletteMisc.Size = new System.Drawing.Size(285, 154);
			tpPaletteMisc.TabIndex = 3;
			tpPaletteMisc.Text = "Misc";
			tpPaletteMisc.UseVisualStyleBackColor = true;
			// 
			// btnReverse
			// 
			btnReverse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnReverse.BackColor = System.Drawing.SystemColors.ControlLight;
			btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnReverse.Location = new System.Drawing.Point(3, 3);
			btnReverse.Name = "btnReverse";
			btnReverse.Size = new System.Drawing.Size(138, 23);
			btnReverse.TabIndex = 11;
			btnReverse.Text = "Reverse";
			btnReverse.UseVisualStyleBackColor = false;
			btnReverse.Click += btnReverse_Click;
			// 
			// btnEqualise
			// 
			btnEqualise.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnEqualise.BackColor = System.Drawing.SystemColors.ControlLight;
			btnEqualise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnEqualise.Location = new System.Drawing.Point(3, 32);
			btnEqualise.Name = "btnEqualise";
			btnEqualise.Size = new System.Drawing.Size(138, 23);
			btnEqualise.TabIndex = 8;
			btnEqualise.Text = "Equalise";
			btnEqualise.UseVisualStyleBackColor = false;
			btnEqualise.Click += btnEqualise_Click;
			// 
			// grpPaint
			// 
			grpPaint.Controls.Add(btnClearCanvas);
			grpPaint.Controls.Add(btnAbortPaint);
			grpPaint.Controls.Add(btnPaint);
			grpPaint.Controls.Add(btnPausePaint);
			grpPaint.Location = new System.Drawing.Point(317, 27);
			grpPaint.Name = "grpPaint";
			grpPaint.Size = new System.Drawing.Size(358, 47);
			grpPaint.TabIndex = 10;
			grpPaint.TabStop = false;
			grpPaint.Text = "Paint";
			// 
			// btnClearCanvas
			// 
			btnClearCanvas.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			btnClearCanvas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnClearCanvas.Location = new System.Drawing.Point(249, 17);
			btnClearCanvas.Name = "btnClearCanvas";
			btnClearCanvas.Size = new System.Drawing.Size(75, 23);
			btnClearCanvas.TabIndex = 20;
			btnClearCanvas.Text = "Clear";
			btnClearCanvas.UseVisualStyleBackColor = false;
			btnClearCanvas.Click += btnClearCanvas_Click;
			// 
			// btnAbortPaint
			// 
			btnAbortPaint.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
			btnAbortPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAbortPaint.Location = new System.Drawing.Point(168, 17);
			btnAbortPaint.Name = "btnAbortPaint";
			btnAbortPaint.Size = new System.Drawing.Size(75, 23);
			btnAbortPaint.TabIndex = 18;
			btnAbortPaint.Text = "Abort";
			btnAbortPaint.UseVisualStyleBackColor = false;
			btnAbortPaint.Click += btnAbortPaint_Click;
			// 
			// grpPaintParams
			// 
			grpPaintParams.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			grpPaintParams.Controls.Add(rbPixelSelectorSum);
			grpPaintParams.Controls.Add(rbPixelSelectorAvg);
			grpPaintParams.Controls.Add(rbPixelSelectorMax);
			grpPaintParams.Controls.Add(rbPixelSelectorMin);
			grpPaintParams.Controls.Add(trbNeighbourCountThreshold);
			grpPaintParams.Controls.Add(trbNeighbourCountWeight);
			grpPaintParams.Controls.Add(trbDistanceWeight);
			grpPaintParams.Controls.Add(trbHSBWeight);
			grpPaintParams.Controls.Add(trbRGBWeight);
			grpPaintParams.Location = new System.Drawing.Point(313, 3);
			grpPaintParams.Name = "grpPaintParams";
			grpPaintParams.Size = new System.Drawing.Size(339, 224);
			grpPaintParams.TabIndex = 19;
			grpPaintParams.TabStop = false;
			grpPaintParams.Text = "Paint Params";
			// 
			// rbPixelSelectorSum
			// 
			rbPixelSelectorSum.AutoSize = true;
			rbPixelSelectorSum.Location = new System.Drawing.Point(112, 22);
			rbPixelSelectorSum.Name = "rbPixelSelectorSum";
			rbPixelSelectorSum.Size = new System.Drawing.Size(49, 19);
			rbPixelSelectorSum.TabIndex = 25;
			rbPixelSelectorSum.Text = "Sum";
			rbPixelSelectorSum.UseVisualStyleBackColor = true;
			// 
			// rbPixelSelectorAvg
			// 
			rbPixelSelectorAvg.AutoSize = true;
			rbPixelSelectorAvg.Location = new System.Drawing.Point(167, 22);
			rbPixelSelectorAvg.Name = "rbPixelSelectorAvg";
			rbPixelSelectorAvg.Size = new System.Drawing.Size(68, 19);
			rbPixelSelectorAvg.TabIndex = 25;
			rbPixelSelectorAvg.Text = "Average";
			rbPixelSelectorAvg.UseVisualStyleBackColor = true;
			// 
			// rbPixelSelectorMax
			// 
			rbPixelSelectorMax.AutoSize = true;
			rbPixelSelectorMax.Checked = true;
			rbPixelSelectorMax.Location = new System.Drawing.Point(58, 22);
			rbPixelSelectorMax.Name = "rbPixelSelectorMax";
			rbPixelSelectorMax.Size = new System.Drawing.Size(48, 19);
			rbPixelSelectorMax.TabIndex = 25;
			rbPixelSelectorMax.TabStop = true;
			rbPixelSelectorMax.Text = "Max";
			rbPixelSelectorMax.UseVisualStyleBackColor = true;
			// 
			// rbPixelSelectorMin
			// 
			rbPixelSelectorMin.AutoSize = true;
			rbPixelSelectorMin.Location = new System.Drawing.Point(6, 22);
			rbPixelSelectorMin.Name = "rbPixelSelectorMin";
			rbPixelSelectorMin.Size = new System.Drawing.Size(46, 19);
			rbPixelSelectorMin.TabIndex = 25;
			rbPixelSelectorMin.Text = "Min";
			rbPixelSelectorMin.UseVisualStyleBackColor = true;
			// 
			// trbNeighbourCountThreshold
			// 
			trbNeighbourCountThreshold.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			trbNeighbourCountThreshold.BackColor = System.Drawing.SystemColors.ControlLight;
			trbNeighbourCountThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			trbNeighbourCountThreshold.Caption = "Neighbour # Thresh";
			trbNeighbourCountThreshold.Location = new System.Drawing.Point(6, 175);
			trbNeighbourCountThreshold.Maximum = 8;
			trbNeighbourCountThreshold.Minimum = 0;
			trbNeighbourCountThreshold.Name = "trbNeighbourCountThreshold";
			trbNeighbourCountThreshold.Size = new System.Drawing.Size(327, 26);
			trbNeighbourCountThreshold.TabIndex = 24;
			trbNeighbourCountThreshold.Value = "0";
			// 
			// trbNeighbourCountWeight
			// 
			trbNeighbourCountWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			trbNeighbourCountWeight.BackColor = System.Drawing.SystemColors.ControlLight;
			trbNeighbourCountWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			trbNeighbourCountWeight.Caption = "Neighbour # Weight";
			trbNeighbourCountWeight.Location = new System.Drawing.Point(6, 143);
			trbNeighbourCountWeight.Maximum = 100;
			trbNeighbourCountWeight.Minimum = 0;
			trbNeighbourCountWeight.Name = "trbNeighbourCountWeight";
			trbNeighbourCountWeight.Size = new System.Drawing.Size(327, 26);
			trbNeighbourCountWeight.TabIndex = 23;
			trbNeighbourCountWeight.Value = "0";
			// 
			// trbDistanceWeight
			// 
			trbDistanceWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			trbDistanceWeight.BackColor = System.Drawing.SystemColors.ControlLight;
			trbDistanceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			trbDistanceWeight.Caption = "Distance Weight";
			trbDistanceWeight.Location = new System.Drawing.Point(6, 111);
			trbDistanceWeight.Maximum = 100;
			trbDistanceWeight.Minimum = 0;
			trbDistanceWeight.Name = "trbDistanceWeight";
			trbDistanceWeight.Size = new System.Drawing.Size(327, 26);
			trbDistanceWeight.TabIndex = 22;
			trbDistanceWeight.Value = "0";
			// 
			// trbHSBWeight
			// 
			trbHSBWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			trbHSBWeight.BackColor = System.Drawing.SystemColors.ControlLight;
			trbHSBWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			trbHSBWeight.Caption = "HSB Weight";
			trbHSBWeight.Location = new System.Drawing.Point(6, 79);
			trbHSBWeight.Maximum = 100;
			trbHSBWeight.Minimum = 0;
			trbHSBWeight.Name = "trbHSBWeight";
			trbHSBWeight.Size = new System.Drawing.Size(327, 26);
			trbHSBWeight.TabIndex = 21;
			trbHSBWeight.Value = "0";
			// 
			// trbRGBWeight
			// 
			trbRGBWeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			trbRGBWeight.BackColor = System.Drawing.SystemColors.ControlLight;
			trbRGBWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			trbRGBWeight.Caption = "RGB Weight";
			trbRGBWeight.Location = new System.Drawing.Point(6, 47);
			trbRGBWeight.Maximum = 100;
			trbRGBWeight.Minimum = 0;
			trbRGBWeight.Name = "trbRGBWeight";
			trbRGBWeight.Size = new System.Drawing.Size(327, 26);
			trbRGBWeight.TabIndex = 20;
			trbRGBWeight.Value = "100";
			// 
			// btnDenoiseRGB
			// 
			btnDenoiseRGB.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			btnDenoiseRGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnDenoiseRGB.Location = new System.Drawing.Point(6, 54);
			btnDenoiseRGB.Name = "btnDenoiseRGB";
			btnDenoiseRGB.Size = new System.Drawing.Size(100, 23);
			btnDenoiseRGB.TabIndex = 18;
			btnDenoiseRGB.Text = "DenoiseRGB";
			btnDenoiseRGB.UseVisualStyleBackColor = false;
			btnDenoiseRGB.Click += btnDenoiseRGB_Click;
			// 
			// grpImageProperties
			// 
			grpImageProperties.Controls.Add(cmbPresetSizes);
			grpImageProperties.Controls.Add(tbWidth);
			grpImageProperties.Controls.Add(tbHeight);
			grpImageProperties.Controls.Add(lblWidth);
			grpImageProperties.Controls.Add(lblHeight);
			grpImageProperties.Location = new System.Drawing.Point(12, 27);
			grpImageProperties.Name = "grpImageProperties";
			grpImageProperties.Size = new System.Drawing.Size(299, 47);
			grpImageProperties.TabIndex = 19;
			grpImageProperties.TabStop = false;
			grpImageProperties.Text = "Image";
			// 
			// cmbPresetSizes
			// 
			cmbPresetSizes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			cmbPresetSizes.FormattingEnabled = true;
			cmbPresetSizes.Items.AddRange(new object[] { "64x64", "128x128", "256x256", "512x512", "1024x1024", "1920x1080", "2560x1440", "2048x2048", "3840x2160", "4096x4096" });
			cmbPresetSizes.Location = new System.Drawing.Point(190, 16);
			cmbPresetSizes.Name = "cmbPresetSizes";
			cmbPresetSizes.Size = new System.Drawing.Size(103, 23);
			cmbPresetSizes.TabIndex = 22;
			cmbPresetSizes.SelectedIndexChanged += cmbPresetSizes_SelectedIndexChanged;
			// 
			// lblBatchTime
			// 
			lblBatchTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lblBatchTime.AutoSize = true;
			lblBatchTime.Location = new System.Drawing.Point(430, 1017);
			lblBatchTime.Name = "lblBatchTime";
			lblBatchTime.Size = new System.Drawing.Size(63, 15);
			lblBatchTime.TabIndex = 20;
			lblBatchTime.Text = "BatchTime";
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(1904, 24);
			menuStrip1.TabIndex = 21;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { loadPaletteToolStripMenuItem, openSavedImagesToolStripMenuItem, saveToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// loadPaletteToolStripMenuItem
			// 
			loadPaletteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { paletteToolStripMenuItem, templateToolStripMenuItem, imageToolStripMenuItem });
			loadPaletteToolStripMenuItem.Name = "loadPaletteToolStripMenuItem";
			loadPaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			loadPaletteToolStripMenuItem.Text = "Load";
			// 
			// paletteToolStripMenuItem
			// 
			paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
			paletteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			paletteToolStripMenuItem.Text = "Palette";
			paletteToolStripMenuItem.Click += loadPalette_Click;
			// 
			// templateToolStripMenuItem
			// 
			templateToolStripMenuItem.Name = "templateToolStripMenuItem";
			templateToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			templateToolStripMenuItem.Text = "Template";
			templateToolStripMenuItem.Click += loadTemplate_Click;
			// 
			// imageToolStripMenuItem
			// 
			imageToolStripMenuItem.Name = "imageToolStripMenuItem";
			imageToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			imageToolStripMenuItem.Text = "Image";
			imageToolStripMenuItem.Click += loadImage_Click;
			// 
			// openSavedImagesToolStripMenuItem
			// 
			openSavedImagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { currentImageToolStripMenuItem, paletteToolStripMenuItem1 });
			openSavedImagesToolStripMenuItem.Name = "openSavedImagesToolStripMenuItem";
			openSavedImagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			openSavedImagesToolStripMenuItem.Text = "Save";
			// 
			// currentImageToolStripMenuItem
			// 
			currentImageToolStripMenuItem.Name = "currentImageToolStripMenuItem";
			currentImageToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			currentImageToolStripMenuItem.Text = "Current Image";
			currentImageToolStripMenuItem.Click += saveCurrentImage_Click;
			// 
			// paletteToolStripMenuItem1
			// 
			paletteToolStripMenuItem1.Name = "paletteToolStripMenuItem1";
			paletteToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
			paletteToolStripMenuItem1.Text = "Palette";
			paletteToolStripMenuItem1.Click += saveCurrentPalette_Click;
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			saveToolStripMenuItem.Text = "Open Images Folder";
			saveToolStripMenuItem.Click += openImagesFolder_Click;
			// 
			// grpDenoiserParams
			// 
			grpDenoiserParams.Controls.Add(btnDenoiseHSB);
			grpDenoiserParams.Controls.Add(trbPixelNoiseThreshold);
			grpDenoiserParams.Controls.Add(btnDenoiseRGB);
			grpDenoiserParams.Location = new System.Drawing.Point(313, 233);
			grpDenoiserParams.Name = "grpDenoiserParams";
			grpDenoiserParams.Size = new System.Drawing.Size(339, 93);
			grpDenoiserParams.TabIndex = 22;
			grpDenoiserParams.TabStop = false;
			grpDenoiserParams.Text = "Denoiser";
			// 
			// btnDenoiseHSB
			// 
			btnDenoiseHSB.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			btnDenoiseHSB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnDenoiseHSB.Location = new System.Drawing.Point(112, 54);
			btnDenoiseHSB.Name = "btnDenoiseHSB";
			btnDenoiseHSB.Size = new System.Drawing.Size(100, 23);
			btnDenoiseHSB.TabIndex = 26;
			btnDenoiseHSB.Text = "DenoiseHSB";
			btnDenoiseHSB.UseVisualStyleBackColor = false;
			btnDenoiseHSB.Click += btnDenoiseHSB_Click;
			// 
			// trbPixelNoiseThreshold
			// 
			trbPixelNoiseThreshold.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			trbPixelNoiseThreshold.BackColor = System.Drawing.SystemColors.ControlLight;
			trbPixelNoiseThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			trbPixelNoiseThreshold.Caption = "Pixel Noise Threshold";
			trbPixelNoiseThreshold.Location = new System.Drawing.Point(6, 22);
			trbPixelNoiseThreshold.Maximum = 100;
			trbPixelNoiseThreshold.Minimum = 0;
			trbPixelNoiseThreshold.Name = "trbPixelNoiseThreshold";
			trbPixelNoiseThreshold.Size = new System.Drawing.Size(327, 26);
			trbPixelNoiseThreshold.TabIndex = 25;
			trbPixelNoiseThreshold.Value = "100";
			// 
			// tcProcGenTypes
			// 
			tcProcGenTypes.Controls.Add(tpAllRGB);
			tcProcGenTypes.Controls.Add(tpPoissonCircles);
			tcProcGenTypes.Location = new System.Drawing.Point(12, 80);
			tcProcGenTypes.Name = "tcProcGenTypes";
			tcProcGenTypes.SelectedIndex = 0;
			tcProcGenTypes.Size = new System.Drawing.Size(663, 904);
			tcProcGenTypes.TabIndex = 23;
			// 
			// tpAllRGB
			// 
			tpAllRGB.Controls.Add(lbRunningTasks);
			tpAllRGB.Controls.Add(grpPalette);
			tpAllRGB.Controls.Add(grpDenoiserParams);
			tpAllRGB.Controls.Add(grpPaintParams);
			tpAllRGB.Location = new System.Drawing.Point(4, 24);
			tpAllRGB.Name = "tpAllRGB";
			tpAllRGB.Size = new System.Drawing.Size(655, 876);
			tpAllRGB.TabIndex = 0;
			tpAllRGB.Text = "AllRGB";
			tpAllRGB.UseVisualStyleBackColor = true;
			// 
			// tpPoissonCircles
			// 
			tpPoissonCircles.Location = new System.Drawing.Point(4, 24);
			tpPoissonCircles.Name = "tpPoissonCircles";
			tpPoissonCircles.Size = new System.Drawing.Size(655, 876);
			tpPoissonCircles.TabIndex = 1;
			tpPoissonCircles.Text = "PoissonCircles";
			tpPoissonCircles.UseVisualStyleBackColor = true;
			// 
			// lbRunningTasks
			// 
			lbRunningTasks.FormattingEnabled = true;
			lbRunningTasks.ItemHeight = 15;
			lbRunningTasks.Location = new System.Drawing.Point(313, 332);
			lbRunningTasks.Name = "lbRunningTasks";
			lbRunningTasks.Size = new System.Drawing.Size(339, 259);
			lbRunningTasks.TabIndex = 24;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1904, 1041);
			Controls.Add(tcProcGenTypes);
			Controls.Add(lblBatchTime);
			Controls.Add(grpImageProperties);
			Controls.Add(grpPaint);
			Controls.Add(pbFinalImage);
			Controls.Add(lblETA);
			Controls.Add(pgPaint);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "MainForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "All-RGB Image Generator";
			((System.ComponentModel.ISupportInitialize)pbFinalImage).EndInit();
			((System.ComponentModel.ISupportInitialize)pbPalette).EndInit();
			grpPalette.ResumeLayout(false);
			tcAllRGB.ResumeLayout(false);
			tpGeneration.ResumeLayout(false);
			tpPaletteSorting.ResumeLayout(false);
			tpPaletteSorting.PerformLayout();
			tpPaletteShuffing.ResumeLayout(false);
			tpPaletteShuffing.PerformLayout();
			tpPaletteMisc.ResumeLayout(false);
			grpPaint.ResumeLayout(false);
			grpPaintParams.ResumeLayout(false);
			grpPaintParams.PerformLayout();
			grpImageProperties.ResumeLayout(false);
			grpImageProperties.PerformLayout();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			grpDenoiserParams.ResumeLayout(false);
			tcProcGenTypes.ResumeLayout(false);
			tpAllRGB.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBoxWithInterpolationMode pbFinalImage;
		private PictureBoxWithInterpolationMode pbPalette;
		private System.Windows.Forms.Button btnGenerateRGBUniform;
		private System.Windows.Forms.Button btnPaint;
		private System.Windows.Forms.TextBox tbWidth;
		private System.Windows.Forms.TextBox tbHeight;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.ProgressBar pgPaint;
		private System.Windows.Forms.Label lblETA;
		private System.Windows.Forms.Button btnPausePaint;
		private System.Windows.Forms.GroupBox grpPalette;
		private System.Windows.Forms.GroupBox grpPaint;
		private System.Windows.Forms.GroupBox grpImageProperties;
		private System.Windows.Forms.Button btnAbortPaint;
		private System.Windows.Forms.Button btnEqualise;
		private System.Windows.Forms.Button btnReverse;
		private System.Windows.Forms.Button btnShuffle;
		private System.Windows.Forms.Label lblBatchTime;
		private System.Windows.Forms.Button btnSortNN;
		private System.Windows.Forms.Button btnSortHSB;
		private System.Windows.Forms.Button btnSortRGB;
		private System.Windows.Forms.CheckBox chkSortBri;
		private System.Windows.Forms.CheckBox chkSortSat;
		private System.Windows.Forms.CheckBox chkSortHue;
		private System.Windows.Forms.GroupBox grpPaintParams;
		private BetterTrackBar trbRGBWeight;
		private BetterTrackBar trbDistanceWeight;
		private BetterTrackBar trbHSBWeight;
		private BetterTrackBar trbNeighbourCountWeight;
		private BetterTrackBar trbNeighbourCountThreshold;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadPaletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openSavedImagesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem currentImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private BetterTrackBar trbShufflePercentage;
		private System.Windows.Forms.CheckBox chkSortBlue;
		private System.Windows.Forms.CheckBox chkSortGreen;
		private System.Windows.Forms.CheckBox chkSortRed;
		private System.Windows.Forms.Button btnGenerateHSBRandom;
		private System.Windows.Forms.Label lblShuffleSkip;
		private System.Windows.Forms.TextBox tbShuffleSkip;
		private System.Windows.Forms.ComboBox cmbPresetSizes;
		private System.Windows.Forms.Button btnDenoiseRGB;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.GroupBox grpDenoiserParams;
		private BetterTrackBar trbPixelNoiseThreshold;
		private System.Windows.Forms.TabControl tcAllRGB;
		private System.Windows.Forms.TabPage tpGeneration;
		private System.Windows.Forms.TabPage tpPaletteSorting;
		private System.Windows.Forms.TabPage tpPaletteShuffing;
		private System.Windows.Forms.TabPage tpPaletteMisc;
		private System.Windows.Forms.Button btnGenerateRGBPastel;
		private System.Windows.Forms.RadioButton rbPixelSelectorSum;
		private System.Windows.Forms.RadioButton rbPixelSelectorAvg;
		private System.Windows.Forms.RadioButton rbPixelSelectorMax;
		private System.Windows.Forms.RadioButton rbPixelSelectorMin;
		private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem1;
		private System.Windows.Forms.Button btnClearCanvas;
		private System.Windows.Forms.TabControl tcProcGenTypes;
		private System.Windows.Forms.TabPage tpAllRGB;
		private System.Windows.Forms.TabPage tpPoissonCircles;
		private System.Windows.Forms.Button btnDenoiseHSB;
		private System.Windows.Forms.ListBox lbRunningTasks;
	}
}

