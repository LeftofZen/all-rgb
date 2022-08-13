namespace all_rgb_gui
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
			this.pbFinalImage = new all_rgb_gui.PictureBoxWithInterpolationMode();
			this.pbPalette = new all_rgb_gui.PictureBoxWithInterpolationMode();
			this.btnGenerateRGBUniform = new System.Windows.Forms.Button();
			this.btnPaint = new System.Windows.Forms.Button();
			this.tbWidth = new System.Windows.Forms.TextBox();
			this.tbHeight = new System.Windows.Forms.TextBox();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.pgPaint = new System.Windows.Forms.ProgressBar();
			this.lblETA = new System.Windows.Forms.Label();
			this.btnPausePaint = new System.Windows.Forms.Button();
			this.grpPalette = new System.Windows.Forms.GroupBox();
			this.tcAllRGB = new System.Windows.Forms.TabControl();
			this.tpGeneration = new System.Windows.Forms.TabPage();
			this.btnGenerateRGBPastel = new System.Windows.Forms.Button();
			this.btnGenerateHSBRandom = new System.Windows.Forms.Button();
			this.tpPaletteSorting = new System.Windows.Forms.TabPage();
			this.chkSortHue = new System.Windows.Forms.CheckBox();
			this.btnSortNN = new System.Windows.Forms.Button();
			this.btnSortRGB = new System.Windows.Forms.Button();
			this.chkSortBlue = new System.Windows.Forms.CheckBox();
			this.chkSortSat = new System.Windows.Forms.CheckBox();
			this.chkSortGreen = new System.Windows.Forms.CheckBox();
			this.chkSortRed = new System.Windows.Forms.CheckBox();
			this.chkSortBri = new System.Windows.Forms.CheckBox();
			this.btnSortHSB = new System.Windows.Forms.Button();
			this.tpPaletteShuffing = new System.Windows.Forms.TabPage();
			this.btnShuffle = new System.Windows.Forms.Button();
			this.tbShuffleSkip = new System.Windows.Forms.TextBox();
			this.lblShuffleSkip = new System.Windows.Forms.Label();
			this.trbShufflePercentage = new all_rgb_gui.BetterTrackBar();
			this.tpPaletteMisc = new System.Windows.Forms.TabPage();
			this.btnReverse = new System.Windows.Forms.Button();
			this.btnEqualise = new System.Windows.Forms.Button();
			this.grpPaint = new System.Windows.Forms.GroupBox();
			this.btnClearCanvas = new System.Windows.Forms.Button();
			this.btnAbortPaint = new System.Windows.Forms.Button();
			this.grpPaintParams = new System.Windows.Forms.GroupBox();
			this.rbPixelSelectorSum = new System.Windows.Forms.RadioButton();
			this.rbPixelSelectorAvg = new System.Windows.Forms.RadioButton();
			this.rbPixelSelectorMax = new System.Windows.Forms.RadioButton();
			this.rbPixelSelectorMin = new System.Windows.Forms.RadioButton();
			this.trbNeighbourCountThreshold = new all_rgb_gui.BetterTrackBar();
			this.trbNeighbourCountWeight = new all_rgb_gui.BetterTrackBar();
			this.trbDistanceWeight = new all_rgb_gui.BetterTrackBar();
			this.trbHSBWeight = new all_rgb_gui.BetterTrackBar();
			this.trbRGBWeight = new all_rgb_gui.BetterTrackBar();
			this.btnDenoise = new System.Windows.Forms.Button();
			this.grpImageProperties = new System.Windows.Forms.GroupBox();
			this.cmbPresetSizes = new System.Windows.Forms.ComboBox();
			this.lblBatchTime = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSavedImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.currentImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paletteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.grpDenoiserParams = new System.Windows.Forms.GroupBox();
			this.trbPixelNoiseThreshold = new all_rgb_gui.BetterTrackBar();
			this.tcProcGenTypes = new System.Windows.Forms.TabControl();
			this.tpAllRGB = new System.Windows.Forms.TabPage();
			this.tpPoissonCircles = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
			this.grpPalette.SuspendLayout();
			this.tcAllRGB.SuspendLayout();
			this.tpGeneration.SuspendLayout();
			this.tpPaletteSorting.SuspendLayout();
			this.tpPaletteShuffing.SuspendLayout();
			this.tpPaletteMisc.SuspendLayout();
			this.grpPaint.SuspendLayout();
			this.grpPaintParams.SuspendLayout();
			this.grpImageProperties.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.grpDenoiserParams.SuspendLayout();
			this.tcProcGenTypes.SuspendLayout();
			this.tpAllRGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbFinalImage
			// 
			this.pbFinalImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbFinalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pbFinalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbFinalImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.pbFinalImage.Location = new System.Drawing.Point(681, 27);
			this.pbFinalImage.Name = "pbFinalImage";
			this.pbFinalImage.Size = new System.Drawing.Size(1210, 957);
			this.pbFinalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbFinalImage.TabIndex = 0;
			this.pbFinalImage.TabStop = false;
			// 
			// pbPalette
			// 
			this.pbPalette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbPalette.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.pbPalette.Location = new System.Drawing.Point(3, 207);
			this.pbPalette.Name = "pbPalette";
			this.pbPalette.Size = new System.Drawing.Size(293, 663);
			this.pbPalette.TabIndex = 7;
			this.pbPalette.TabStop = false;
			// 
			// btnGenerateRGBUniform
			// 
			this.btnGenerateRGBUniform.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerateRGBUniform.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnGenerateRGBUniform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGenerateRGBUniform.Location = new System.Drawing.Point(3, 6);
			this.btnGenerateRGBUniform.Name = "btnGenerateRGBUniform";
			this.btnGenerateRGBUniform.Size = new System.Drawing.Size(276, 23);
			this.btnGenerateRGBUniform.TabIndex = 1;
			this.btnGenerateRGBUniform.Text = "Generate RGB Uniform";
			this.btnGenerateRGBUniform.UseVisualStyleBackColor = false;
			this.btnGenerateRGBUniform.Click += new System.EventHandler(this.btnGenerateRGBUniform_Click);
			// 
			// btnPaint
			// 
			this.btnPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPaint.Location = new System.Drawing.Point(6, 17);
			this.btnPaint.Name = "btnPaint";
			this.btnPaint.Size = new System.Drawing.Size(75, 23);
			this.btnPaint.TabIndex = 3;
			this.btnPaint.Text = "Paint";
			this.btnPaint.UseVisualStyleBackColor = false;
			this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
			// 
			// tbWidth
			// 
			this.tbWidth.Location = new System.Drawing.Point(51, 16);
			this.tbWidth.Name = "tbWidth";
			this.tbWidth.Size = new System.Drawing.Size(39, 23);
			this.tbWidth.TabIndex = 5;
			this.tbWidth.Text = "128";
			// 
			// tbHeight
			// 
			this.tbHeight.Location = new System.Drawing.Point(145, 16);
			this.tbHeight.Name = "tbHeight";
			this.tbHeight.Size = new System.Drawing.Size(39, 23);
			this.tbHeight.TabIndex = 6;
			this.tbHeight.Text = "128";
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(6, 19);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(39, 15);
			this.lblWidth.TabIndex = 10;
			this.lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(96, 19);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(43, 15);
			this.lblHeight.TabIndex = 11;
			this.lblHeight.Text = "Height";
			// 
			// pgPaint
			// 
			this.pgPaint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pgPaint.Location = new System.Drawing.Point(12, 991);
			this.pgPaint.Name = "pgPaint";
			this.pgPaint.Size = new System.Drawing.Size(1879, 23);
			this.pgPaint.TabIndex = 13;
			// 
			// lblETA
			// 
			this.lblETA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblETA.AutoSize = true;
			this.lblETA.Location = new System.Drawing.Point(12, 1017);
			this.lblETA.Name = "lblETA";
			this.lblETA.Size = new System.Drawing.Size(26, 15);
			this.lblETA.TabIndex = 14;
			this.lblETA.Text = "ETA";
			// 
			// btnPausePaint
			// 
			this.btnPausePaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnPausePaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPausePaint.Location = new System.Drawing.Point(87, 17);
			this.btnPausePaint.Name = "btnPausePaint";
			this.btnPausePaint.Size = new System.Drawing.Size(75, 23);
			this.btnPausePaint.TabIndex = 15;
			this.btnPausePaint.Text = "Pause";
			this.btnPausePaint.UseVisualStyleBackColor = false;
			this.btnPausePaint.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// grpPalette
			// 
			this.grpPalette.Controls.Add(this.tcAllRGB);
			this.grpPalette.Controls.Add(this.pbPalette);
			this.grpPalette.Location = new System.Drawing.Point(8, 3);
			this.grpPalette.Name = "grpPalette";
			this.grpPalette.Size = new System.Drawing.Size(299, 904);
			this.grpPalette.TabIndex = 18;
			this.grpPalette.TabStop = false;
			this.grpPalette.Text = "Palette";
			// 
			// tcAllRGB
			// 
			this.tcAllRGB.Controls.Add(this.tpGeneration);
			this.tcAllRGB.Controls.Add(this.tpPaletteSorting);
			this.tcAllRGB.Controls.Add(this.tpPaletteShuffing);
			this.tcAllRGB.Controls.Add(this.tpPaletteMisc);
			this.tcAllRGB.Dock = System.Windows.Forms.DockStyle.Top;
			this.tcAllRGB.Location = new System.Drawing.Point(3, 19);
			this.tcAllRGB.Name = "tcAllRGB";
			this.tcAllRGB.SelectedIndex = 0;
			this.tcAllRGB.Size = new System.Drawing.Size(293, 182);
			this.tcAllRGB.TabIndex = 23;
			// 
			// tpGeneration
			// 
			this.tpGeneration.Controls.Add(this.btnGenerateRGBPastel);
			this.tpGeneration.Controls.Add(this.btnGenerateRGBUniform);
			this.tpGeneration.Controls.Add(this.btnGenerateHSBRandom);
			this.tpGeneration.Location = new System.Drawing.Point(4, 24);
			this.tpGeneration.Name = "tpGeneration";
			this.tpGeneration.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneration.Size = new System.Drawing.Size(285, 154);
			this.tpGeneration.TabIndex = 0;
			this.tpGeneration.Text = "Generation";
			this.tpGeneration.UseVisualStyleBackColor = true;
			// 
			// btnGenerateRGBPastel
			// 
			this.btnGenerateRGBPastel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerateRGBPastel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnGenerateRGBPastel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGenerateRGBPastel.Location = new System.Drawing.Point(4, 66);
			this.btnGenerateRGBPastel.Name = "btnGenerateRGBPastel";
			this.btnGenerateRGBPastel.Size = new System.Drawing.Size(276, 23);
			this.btnGenerateRGBPastel.TabIndex = 27;
			this.btnGenerateRGBPastel.Text = "Generate RGB Pastel";
			this.btnGenerateRGBPastel.UseVisualStyleBackColor = false;
			this.btnGenerateRGBPastel.Click += new System.EventHandler(this.btnGenerateRGBPastel_Click);
			// 
			// btnGenerateHSBRandom
			// 
			this.btnGenerateHSBRandom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerateHSBRandom.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnGenerateHSBRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGenerateHSBRandom.Location = new System.Drawing.Point(3, 35);
			this.btnGenerateHSBRandom.Name = "btnGenerateHSBRandom";
			this.btnGenerateHSBRandom.Size = new System.Drawing.Size(276, 23);
			this.btnGenerateHSBRandom.TabIndex = 26;
			this.btnGenerateHSBRandom.Text = "Generate HSB Random";
			this.btnGenerateHSBRandom.UseVisualStyleBackColor = false;
			this.btnGenerateHSBRandom.Click += new System.EventHandler(this.btnGenerateHSBRandom_Click);
			// 
			// tpPaletteSorting
			// 
			this.tpPaletteSorting.Controls.Add(this.chkSortHue);
			this.tpPaletteSorting.Controls.Add(this.btnSortNN);
			this.tpPaletteSorting.Controls.Add(this.btnSortRGB);
			this.tpPaletteSorting.Controls.Add(this.chkSortBlue);
			this.tpPaletteSorting.Controls.Add(this.chkSortSat);
			this.tpPaletteSorting.Controls.Add(this.chkSortGreen);
			this.tpPaletteSorting.Controls.Add(this.chkSortRed);
			this.tpPaletteSorting.Controls.Add(this.chkSortBri);
			this.tpPaletteSorting.Controls.Add(this.btnSortHSB);
			this.tpPaletteSorting.Location = new System.Drawing.Point(4, 24);
			this.tpPaletteSorting.Name = "tpPaletteSorting";
			this.tpPaletteSorting.Padding = new System.Windows.Forms.Padding(3);
			this.tpPaletteSorting.Size = new System.Drawing.Size(285, 154);
			this.tpPaletteSorting.TabIndex = 1;
			this.tpPaletteSorting.Text = "Sorting";
			this.tpPaletteSorting.UseVisualStyleBackColor = true;
			// 
			// chkSortHue
			// 
			this.chkSortHue.AutoSize = true;
			this.chkSortHue.Location = new System.Drawing.Point(6, 6);
			this.chkSortHue.Name = "chkSortHue";
			this.chkSortHue.Size = new System.Drawing.Size(48, 19);
			this.chkSortHue.TabIndex = 15;
			this.chkSortHue.Text = "Hue";
			this.chkSortHue.UseVisualStyleBackColor = true;
			// 
			// btnSortNN
			// 
			this.btnSortNN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSortNN.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnSortNN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSortNN.Location = new System.Drawing.Point(3, 114);
			this.btnSortNN.Name = "btnSortNN";
			this.btnSortNN.Size = new System.Drawing.Size(169, 23);
			this.btnSortNN.TabIndex = 14;
			this.btnSortNN.Text = "Sort NN (slow)";
			this.btnSortNN.UseVisualStyleBackColor = false;
			this.btnSortNN.Click += new System.EventHandler(this.btnSortNN_Click);
			// 
			// btnSortRGB
			// 
			this.btnSortRGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSortRGB.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnSortRGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSortRGB.Location = new System.Drawing.Point(3, 85);
			this.btnSortRGB.Name = "btnSortRGB";
			this.btnSortRGB.Size = new System.Drawing.Size(169, 23);
			this.btnSortRGB.TabIndex = 12;
			this.btnSortRGB.Text = "Sort RGB";
			this.btnSortRGB.UseVisualStyleBackColor = false;
			this.btnSortRGB.Click += new System.EventHandler(this.btnSortRGB_Click);
			// 
			// chkSortBlue
			// 
			this.chkSortBlue.AutoSize = true;
			this.chkSortBlue.Location = new System.Drawing.Point(123, 60);
			this.chkSortBlue.Name = "chkSortBlue";
			this.chkSortBlue.Size = new System.Drawing.Size(49, 19);
			this.chkSortBlue.TabIndex = 20;
			this.chkSortBlue.Text = "Blue";
			this.chkSortBlue.UseVisualStyleBackColor = true;
			// 
			// chkSortSat
			// 
			this.chkSortSat.AutoSize = true;
			this.chkSortSat.Location = new System.Drawing.Point(60, 6);
			this.chkSortSat.Name = "chkSortSat";
			this.chkSortSat.Size = new System.Drawing.Size(42, 19);
			this.chkSortSat.TabIndex = 16;
			this.chkSortSat.Text = "Sat";
			this.chkSortSat.UseVisualStyleBackColor = true;
			// 
			// chkSortGreen
			// 
			this.chkSortGreen.AutoSize = true;
			this.chkSortGreen.Location = new System.Drawing.Point(60, 60);
			this.chkSortGreen.Name = "chkSortGreen";
			this.chkSortGreen.Size = new System.Drawing.Size(57, 19);
			this.chkSortGreen.TabIndex = 19;
			this.chkSortGreen.Text = "Green";
			this.chkSortGreen.UseVisualStyleBackColor = true;
			// 
			// chkSortRed
			// 
			this.chkSortRed.AutoSize = true;
			this.chkSortRed.Location = new System.Drawing.Point(6, 60);
			this.chkSortRed.Name = "chkSortRed";
			this.chkSortRed.Size = new System.Drawing.Size(46, 19);
			this.chkSortRed.TabIndex = 18;
			this.chkSortRed.Text = "Red";
			this.chkSortRed.UseVisualStyleBackColor = true;
			// 
			// chkSortBri
			// 
			this.chkSortBri.AutoSize = true;
			this.chkSortBri.Location = new System.Drawing.Point(108, 6);
			this.chkSortBri.Name = "chkSortBri";
			this.chkSortBri.Size = new System.Drawing.Size(40, 19);
			this.chkSortBri.TabIndex = 17;
			this.chkSortBri.Text = "Bri";
			this.chkSortBri.UseVisualStyleBackColor = true;
			// 
			// btnSortHSB
			// 
			this.btnSortHSB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSortHSB.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnSortHSB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSortHSB.Location = new System.Drawing.Point(3, 31);
			this.btnSortHSB.Name = "btnSortHSB";
			this.btnSortHSB.Size = new System.Drawing.Size(169, 23);
			this.btnSortHSB.TabIndex = 13;
			this.btnSortHSB.Text = "Sort HSB";
			this.btnSortHSB.UseVisualStyleBackColor = false;
			this.btnSortHSB.Click += new System.EventHandler(this.btnSortHSB_Click);
			// 
			// tpPaletteShuffing
			// 
			this.tpPaletteShuffing.Controls.Add(this.btnShuffle);
			this.tpPaletteShuffing.Controls.Add(this.tbShuffleSkip);
			this.tpPaletteShuffing.Controls.Add(this.lblShuffleSkip);
			this.tpPaletteShuffing.Controls.Add(this.trbShufflePercentage);
			this.tpPaletteShuffing.Location = new System.Drawing.Point(4, 24);
			this.tpPaletteShuffing.Name = "tpPaletteShuffing";
			this.tpPaletteShuffing.Size = new System.Drawing.Size(285, 154);
			this.tpPaletteShuffing.TabIndex = 2;
			this.tpPaletteShuffing.Text = "Shuffling";
			this.tpPaletteShuffing.UseVisualStyleBackColor = true;
			// 
			// btnShuffle
			// 
			this.btnShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnShuffle.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnShuffle.Location = new System.Drawing.Point(0, 65);
			this.btnShuffle.Name = "btnShuffle";
			this.btnShuffle.Size = new System.Drawing.Size(282, 23);
			this.btnShuffle.TabIndex = 10;
			this.btnShuffle.Text = "Shuffle";
			this.btnShuffle.UseVisualStyleBackColor = false;
			this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
			// 
			// tbShuffleSkip
			// 
			this.tbShuffleSkip.Location = new System.Drawing.Point(126, 36);
			this.tbShuffleSkip.Name = "tbShuffleSkip";
			this.tbShuffleSkip.Size = new System.Drawing.Size(39, 23);
			this.tbShuffleSkip.TabIndex = 27;
			this.tbShuffleSkip.Text = "1";
			// 
			// lblShuffleSkip
			// 
			this.lblShuffleSkip.AutoSize = true;
			this.lblShuffleSkip.Location = new System.Drawing.Point(3, 39);
			this.lblShuffleSkip.Name = "lblShuffleSkip";
			this.lblShuffleSkip.Size = new System.Drawing.Size(117, 15);
			this.lblShuffleSkip.TabIndex = 12;
			this.lblShuffleSkip.Text = "Shuffle Every X Items";
			// 
			// trbShufflePercentage
			// 
			this.trbShufflePercentage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trbShufflePercentage.BackColor = System.Drawing.SystemColors.ControlLight;
			this.trbShufflePercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trbShufflePercentage.Caption = "%";
			this.trbShufflePercentage.Location = new System.Drawing.Point(3, 4);
			this.trbShufflePercentage.Maximum = 100;
			this.trbShufflePercentage.Minimum = 0;
			this.trbShufflePercentage.Name = "trbShufflePercentage";
			this.trbShufflePercentage.Size = new System.Drawing.Size(279, 26);
			this.trbShufflePercentage.TabIndex = 25;
			this.trbShufflePercentage.Value = "100";
			// 
			// tpPaletteMisc
			// 
			this.tpPaletteMisc.Controls.Add(this.btnReverse);
			this.tpPaletteMisc.Controls.Add(this.btnEqualise);
			this.tpPaletteMisc.Location = new System.Drawing.Point(4, 24);
			this.tpPaletteMisc.Name = "tpPaletteMisc";
			this.tpPaletteMisc.Size = new System.Drawing.Size(285, 154);
			this.tpPaletteMisc.TabIndex = 3;
			this.tpPaletteMisc.Text = "Misc";
			this.tpPaletteMisc.UseVisualStyleBackColor = true;
			// 
			// btnReverse
			// 
			this.btnReverse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReverse.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReverse.Location = new System.Drawing.Point(3, 3);
			this.btnReverse.Name = "btnReverse";
			this.btnReverse.Size = new System.Drawing.Size(138, 23);
			this.btnReverse.TabIndex = 11;
			this.btnReverse.Text = "Reverse";
			this.btnReverse.UseVisualStyleBackColor = false;
			this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
			// 
			// btnEqualise
			// 
			this.btnEqualise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEqualise.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnEqualise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEqualise.Location = new System.Drawing.Point(3, 32);
			this.btnEqualise.Name = "btnEqualise";
			this.btnEqualise.Size = new System.Drawing.Size(138, 23);
			this.btnEqualise.TabIndex = 8;
			this.btnEqualise.Text = "Equalise";
			this.btnEqualise.UseVisualStyleBackColor = false;
			this.btnEqualise.Click += new System.EventHandler(this.btnEqualise_Click);
			// 
			// grpPaint
			// 
			this.grpPaint.Controls.Add(this.btnClearCanvas);
			this.grpPaint.Controls.Add(this.btnAbortPaint);
			this.grpPaint.Controls.Add(this.btnPaint);
			this.grpPaint.Controls.Add(this.btnPausePaint);
			this.grpPaint.Location = new System.Drawing.Point(317, 27);
			this.grpPaint.Name = "grpPaint";
			this.grpPaint.Size = new System.Drawing.Size(358, 47);
			this.grpPaint.TabIndex = 10;
			this.grpPaint.TabStop = false;
			this.grpPaint.Text = "Paint";
			// 
			// btnClearCanvas
			// 
			this.btnClearCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.btnClearCanvas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClearCanvas.Location = new System.Drawing.Point(249, 17);
			this.btnClearCanvas.Name = "btnClearCanvas";
			this.btnClearCanvas.Size = new System.Drawing.Size(75, 23);
			this.btnClearCanvas.TabIndex = 20;
			this.btnClearCanvas.Text = "Clear";
			this.btnClearCanvas.UseVisualStyleBackColor = false;
			this.btnClearCanvas.Click += new System.EventHandler(this.btnClearCanvas_Click);
			// 
			// btnAbortPaint
			// 
			this.btnAbortPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnAbortPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAbortPaint.Location = new System.Drawing.Point(168, 17);
			this.btnAbortPaint.Name = "btnAbortPaint";
			this.btnAbortPaint.Size = new System.Drawing.Size(75, 23);
			this.btnAbortPaint.TabIndex = 18;
			this.btnAbortPaint.Text = "Abort";
			this.btnAbortPaint.UseVisualStyleBackColor = false;
			this.btnAbortPaint.Click += new System.EventHandler(this.btnAbortPaint_Click);
			// 
			// grpPaintParams
			// 
			this.grpPaintParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpPaintParams.Controls.Add(this.rbPixelSelectorSum);
			this.grpPaintParams.Controls.Add(this.rbPixelSelectorAvg);
			this.grpPaintParams.Controls.Add(this.rbPixelSelectorMax);
			this.grpPaintParams.Controls.Add(this.rbPixelSelectorMin);
			this.grpPaintParams.Controls.Add(this.trbNeighbourCountThreshold);
			this.grpPaintParams.Controls.Add(this.trbNeighbourCountWeight);
			this.grpPaintParams.Controls.Add(this.trbDistanceWeight);
			this.grpPaintParams.Controls.Add(this.trbHSBWeight);
			this.grpPaintParams.Controls.Add(this.trbRGBWeight);
			this.grpPaintParams.Location = new System.Drawing.Point(313, 3);
			this.grpPaintParams.Name = "grpPaintParams";
			this.grpPaintParams.Size = new System.Drawing.Size(339, 224);
			this.grpPaintParams.TabIndex = 19;
			this.grpPaintParams.TabStop = false;
			this.grpPaintParams.Text = "Paint Params";
			// 
			// rbPixelSelectorSum
			// 
			this.rbPixelSelectorSum.AutoSize = true;
			this.rbPixelSelectorSum.Location = new System.Drawing.Point(112, 22);
			this.rbPixelSelectorSum.Name = "rbPixelSelectorSum";
			this.rbPixelSelectorSum.Size = new System.Drawing.Size(49, 19);
			this.rbPixelSelectorSum.TabIndex = 25;
			this.rbPixelSelectorSum.Text = "Sum";
			this.rbPixelSelectorSum.UseVisualStyleBackColor = true;
			// 
			// rbPixelSelectorAvg
			// 
			this.rbPixelSelectorAvg.AutoSize = true;
			this.rbPixelSelectorAvg.Location = new System.Drawing.Point(167, 22);
			this.rbPixelSelectorAvg.Name = "rbPixelSelectorAvg";
			this.rbPixelSelectorAvg.Size = new System.Drawing.Size(68, 19);
			this.rbPixelSelectorAvg.TabIndex = 25;
			this.rbPixelSelectorAvg.Text = "Average";
			this.rbPixelSelectorAvg.UseVisualStyleBackColor = true;
			// 
			// rbPixelSelectorMax
			// 
			this.rbPixelSelectorMax.AutoSize = true;
			this.rbPixelSelectorMax.Checked = true;
			this.rbPixelSelectorMax.Location = new System.Drawing.Point(58, 22);
			this.rbPixelSelectorMax.Name = "rbPixelSelectorMax";
			this.rbPixelSelectorMax.Size = new System.Drawing.Size(48, 19);
			this.rbPixelSelectorMax.TabIndex = 25;
			this.rbPixelSelectorMax.TabStop = true;
			this.rbPixelSelectorMax.Text = "Max";
			this.rbPixelSelectorMax.UseVisualStyleBackColor = true;
			// 
			// rbPixelSelectorMin
			// 
			this.rbPixelSelectorMin.AutoSize = true;
			this.rbPixelSelectorMin.Location = new System.Drawing.Point(6, 22);
			this.rbPixelSelectorMin.Name = "rbPixelSelectorMin";
			this.rbPixelSelectorMin.Size = new System.Drawing.Size(46, 19);
			this.rbPixelSelectorMin.TabIndex = 25;
			this.rbPixelSelectorMin.Text = "Min";
			this.rbPixelSelectorMin.UseVisualStyleBackColor = true;
			// 
			// trbNeighbourCountThreshold
			// 
			this.trbNeighbourCountThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trbNeighbourCountThreshold.BackColor = System.Drawing.SystemColors.ControlLight;
			this.trbNeighbourCountThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trbNeighbourCountThreshold.Caption = "Neighbour # Thresh";
			this.trbNeighbourCountThreshold.Location = new System.Drawing.Point(6, 175);
			this.trbNeighbourCountThreshold.Maximum = 8;
			this.trbNeighbourCountThreshold.Minimum = 0;
			this.trbNeighbourCountThreshold.Name = "trbNeighbourCountThreshold";
			this.trbNeighbourCountThreshold.Size = new System.Drawing.Size(327, 26);
			this.trbNeighbourCountThreshold.TabIndex = 24;
			this.trbNeighbourCountThreshold.Value = "0";
			// 
			// trbNeighbourCountWeight
			// 
			this.trbNeighbourCountWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trbNeighbourCountWeight.BackColor = System.Drawing.SystemColors.ControlLight;
			this.trbNeighbourCountWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trbNeighbourCountWeight.Caption = "Neighbour # Weight";
			this.trbNeighbourCountWeight.Location = new System.Drawing.Point(6, 143);
			this.trbNeighbourCountWeight.Maximum = 100;
			this.trbNeighbourCountWeight.Minimum = 0;
			this.trbNeighbourCountWeight.Name = "trbNeighbourCountWeight";
			this.trbNeighbourCountWeight.Size = new System.Drawing.Size(327, 26);
			this.trbNeighbourCountWeight.TabIndex = 23;
			this.trbNeighbourCountWeight.Value = "0";
			// 
			// trbDistanceWeight
			// 
			this.trbDistanceWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trbDistanceWeight.BackColor = System.Drawing.SystemColors.ControlLight;
			this.trbDistanceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trbDistanceWeight.Caption = "Distance Weight";
			this.trbDistanceWeight.Location = new System.Drawing.Point(6, 111);
			this.trbDistanceWeight.Maximum = 100;
			this.trbDistanceWeight.Minimum = 0;
			this.trbDistanceWeight.Name = "trbDistanceWeight";
			this.trbDistanceWeight.Size = new System.Drawing.Size(327, 26);
			this.trbDistanceWeight.TabIndex = 22;
			this.trbDistanceWeight.Value = "0";
			// 
			// trbHSBWeight
			// 
			this.trbHSBWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trbHSBWeight.BackColor = System.Drawing.SystemColors.ControlLight;
			this.trbHSBWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trbHSBWeight.Caption = "HSB Weight";
			this.trbHSBWeight.Location = new System.Drawing.Point(6, 79);
			this.trbHSBWeight.Maximum = 100;
			this.trbHSBWeight.Minimum = 0;
			this.trbHSBWeight.Name = "trbHSBWeight";
			this.trbHSBWeight.Size = new System.Drawing.Size(327, 26);
			this.trbHSBWeight.TabIndex = 21;
			this.trbHSBWeight.Value = "0";
			// 
			// trbRGBWeight
			// 
			this.trbRGBWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trbRGBWeight.BackColor = System.Drawing.SystemColors.ControlLight;
			this.trbRGBWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trbRGBWeight.Caption = "RGB Weight";
			this.trbRGBWeight.Location = new System.Drawing.Point(6, 47);
			this.trbRGBWeight.Maximum = 100;
			this.trbRGBWeight.Minimum = 0;
			this.trbRGBWeight.Name = "trbRGBWeight";
			this.trbRGBWeight.Size = new System.Drawing.Size(327, 26);
			this.trbRGBWeight.TabIndex = 20;
			this.trbRGBWeight.Value = "100";
			// 
			// btnDenoise
			// 
			this.btnDenoise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.btnDenoise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDenoise.Location = new System.Drawing.Point(6, 54);
			this.btnDenoise.Name = "btnDenoise";
			this.btnDenoise.Size = new System.Drawing.Size(75, 23);
			this.btnDenoise.TabIndex = 18;
			this.btnDenoise.Text = "Denoise";
			this.btnDenoise.UseVisualStyleBackColor = false;
			this.btnDenoise.Click += new System.EventHandler(this.btnDenoisePaint_Click);
			// 
			// grpImageProperties
			// 
			this.grpImageProperties.Controls.Add(this.cmbPresetSizes);
			this.grpImageProperties.Controls.Add(this.tbWidth);
			this.grpImageProperties.Controls.Add(this.tbHeight);
			this.grpImageProperties.Controls.Add(this.lblWidth);
			this.grpImageProperties.Controls.Add(this.lblHeight);
			this.grpImageProperties.Location = new System.Drawing.Point(12, 27);
			this.grpImageProperties.Name = "grpImageProperties";
			this.grpImageProperties.Size = new System.Drawing.Size(299, 47);
			this.grpImageProperties.TabIndex = 19;
			this.grpImageProperties.TabStop = false;
			this.grpImageProperties.Text = "Image";
			// 
			// cmbPresetSizes
			// 
			this.cmbPresetSizes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPresetSizes.FormattingEnabled = true;
			this.cmbPresetSizes.Items.AddRange(new object[] {
            "64x64",
            "128x128",
            "256x256",
            "512x512",
            "1024x1024",
            "1920x1080",
            "2560x1440",
            "2048x2048",
            "3840x2160",
            "4096x4096"});
			this.cmbPresetSizes.Location = new System.Drawing.Point(190, 16);
			this.cmbPresetSizes.Name = "cmbPresetSizes";
			this.cmbPresetSizes.Size = new System.Drawing.Size(103, 23);
			this.cmbPresetSizes.TabIndex = 22;
			this.cmbPresetSizes.SelectedIndexChanged += new System.EventHandler(this.cmbPresetSizes_SelectedIndexChanged);
			// 
			// lblBatchTime
			// 
			this.lblBatchTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblBatchTime.AutoSize = true;
			this.lblBatchTime.Location = new System.Drawing.Point(430, 1017);
			this.lblBatchTime.Name = "lblBatchTime";
			this.lblBatchTime.Size = new System.Drawing.Size(63, 15);
			this.lblBatchTime.TabIndex = 20;
			this.lblBatchTime.Text = "BatchTime";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
			this.menuStrip1.TabIndex = 21;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPaletteToolStripMenuItem,
            this.openSavedImagesToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadPaletteToolStripMenuItem
			// 
			this.loadPaletteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paletteToolStripMenuItem,
            this.templateToolStripMenuItem,
            this.imageToolStripMenuItem});
			this.loadPaletteToolStripMenuItem.Name = "loadPaletteToolStripMenuItem";
			this.loadPaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.loadPaletteToolStripMenuItem.Text = "Load";
			// 
			// paletteToolStripMenuItem
			// 
			this.paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
			this.paletteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.paletteToolStripMenuItem.Text = "Palette";
			this.paletteToolStripMenuItem.Click += new System.EventHandler(this.loadPalette_Click);
			// 
			// templateToolStripMenuItem
			// 
			this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
			this.templateToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.templateToolStripMenuItem.Text = "Template";
			this.templateToolStripMenuItem.Click += new System.EventHandler(this.loadTemplate_Click);
			// 
			// imageToolStripMenuItem
			// 
			this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
			this.imageToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.imageToolStripMenuItem.Text = "Image";
			this.imageToolStripMenuItem.Click += new System.EventHandler(this.loadImage_Click);
			// 
			// openSavedImagesToolStripMenuItem
			// 
			this.openSavedImagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentImageToolStripMenuItem,
            this.paletteToolStripMenuItem1});
			this.openSavedImagesToolStripMenuItem.Name = "openSavedImagesToolStripMenuItem";
			this.openSavedImagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openSavedImagesToolStripMenuItem.Text = "Save";
			// 
			// currentImageToolStripMenuItem
			// 
			this.currentImageToolStripMenuItem.Name = "currentImageToolStripMenuItem";
			this.currentImageToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.currentImageToolStripMenuItem.Text = "Current Image";
			this.currentImageToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentImage_Click);
			// 
			// paletteToolStripMenuItem1
			// 
			this.paletteToolStripMenuItem1.Name = "paletteToolStripMenuItem1";
			this.paletteToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
			this.paletteToolStripMenuItem1.Text = "Palette";
			this.paletteToolStripMenuItem1.Click += new System.EventHandler(this.saveCurrentPalette_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "Open Images Folder";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.openImagesFolder_Click);
			// 
			// grpDenoiserParams
			// 
			this.grpDenoiserParams.Controls.Add(this.trbPixelNoiseThreshold);
			this.grpDenoiserParams.Controls.Add(this.btnDenoise);
			this.grpDenoiserParams.Location = new System.Drawing.Point(313, 233);
			this.grpDenoiserParams.Name = "grpDenoiserParams";
			this.grpDenoiserParams.Size = new System.Drawing.Size(339, 93);
			this.grpDenoiserParams.TabIndex = 22;
			this.grpDenoiserParams.TabStop = false;
			this.grpDenoiserParams.Text = "Denoiser";
			// 
			// trbPixelNoiseThreshold
			// 
			this.trbPixelNoiseThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trbPixelNoiseThreshold.BackColor = System.Drawing.SystemColors.ControlLight;
			this.trbPixelNoiseThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trbPixelNoiseThreshold.Caption = "Pixel Noise Threshold";
			this.trbPixelNoiseThreshold.Location = new System.Drawing.Point(6, 22);
			this.trbPixelNoiseThreshold.Maximum = 100;
			this.trbPixelNoiseThreshold.Minimum = 0;
			this.trbPixelNoiseThreshold.Name = "trbPixelNoiseThreshold";
			this.trbPixelNoiseThreshold.Size = new System.Drawing.Size(327, 26);
			this.trbPixelNoiseThreshold.TabIndex = 25;
			this.trbPixelNoiseThreshold.Value = "100";
			// 
			// tcProcGenTypes
			// 
			this.tcProcGenTypes.Controls.Add(this.tpAllRGB);
			this.tcProcGenTypes.Controls.Add(this.tpPoissonCircles);
			this.tcProcGenTypes.Location = new System.Drawing.Point(12, 80);
			this.tcProcGenTypes.Name = "tcProcGenTypes";
			this.tcProcGenTypes.SelectedIndex = 0;
			this.tcProcGenTypes.Size = new System.Drawing.Size(663, 904);
			this.tcProcGenTypes.TabIndex = 23;
			// 
			// tpAllRGB
			// 
			this.tpAllRGB.Controls.Add(this.grpPalette);
			this.tpAllRGB.Controls.Add(this.grpDenoiserParams);
			this.tpAllRGB.Controls.Add(this.grpPaintParams);
			this.tpAllRGB.Location = new System.Drawing.Point(4, 24);
			this.tpAllRGB.Name = "tpAllRGB";
			this.tpAllRGB.Size = new System.Drawing.Size(655, 876);
			this.tpAllRGB.TabIndex = 0;
			this.tpAllRGB.Text = "AllRGB";
			this.tpAllRGB.UseVisualStyleBackColor = true;
			// 
			// tpPoissonCircles
			// 
			this.tpPoissonCircles.Location = new System.Drawing.Point(4, 24);
			this.tpPoissonCircles.Name = "tpPoissonCircles";
			this.tpPoissonCircles.Size = new System.Drawing.Size(655, 876);
			this.tpPoissonCircles.TabIndex = 1;
			this.tpPoissonCircles.Text = "PoissonCircles";
			this.tpPoissonCircles.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1904, 1041);
			this.Controls.Add(this.tcProcGenTypes);
			this.Controls.Add(this.lblBatchTime);
			this.Controls.Add(this.grpImageProperties);
			this.Controls.Add(this.grpPaint);
			this.Controls.Add(this.pbFinalImage);
			this.Controls.Add(this.lblETA);
			this.Controls.Add(this.pgPaint);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "All-RGB Image Generator";
			((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
			this.grpPalette.ResumeLayout(false);
			this.tcAllRGB.ResumeLayout(false);
			this.tpGeneration.ResumeLayout(false);
			this.tpPaletteSorting.ResumeLayout(false);
			this.tpPaletteSorting.PerformLayout();
			this.tpPaletteShuffing.ResumeLayout(false);
			this.tpPaletteShuffing.PerformLayout();
			this.tpPaletteMisc.ResumeLayout(false);
			this.grpPaint.ResumeLayout(false);
			this.grpPaintParams.ResumeLayout(false);
			this.grpPaintParams.PerformLayout();
			this.grpImageProperties.ResumeLayout(false);
			this.grpImageProperties.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.grpDenoiserParams.ResumeLayout(false);
			this.tcProcGenTypes.ResumeLayout(false);
			this.tpAllRGB.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.Button btnDenoise;
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
	}
}

