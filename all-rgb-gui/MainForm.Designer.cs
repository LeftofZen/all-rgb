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
			this.btnGenerateColours = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnPaint = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.tbWidth = new System.Windows.Forms.TextBox();
			this.tbHeight = new System.Windows.Forms.TextBox();
			this.pbPaletteShuffled = new all_rgb_gui.PictureBoxWithInterpolationMode();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.chkAverageMode = new System.Windows.Forms.CheckBox();
			this.pgPaint = new System.Windows.Forms.ProgressBar();
			this.lblETA = new System.Windows.Forms.Label();
			this.btnPausePaint = new System.Windows.Forms.Button();
			this.btnOpenDir = new System.Windows.Forms.Button();
			this.btnLoadTemplate = new System.Windows.Forms.Button();
			this.grpGeneration = new System.Windows.Forms.GroupBox();
			this.btnEqualise = new System.Windows.Forms.Button();
			this.grpColourRefinement = new System.Windows.Forms.GroupBox();
			this.btnReverse = new System.Windows.Forms.Button();
			this.btnShuffle = new System.Windows.Forms.Button();
			this.grpPaint = new System.Windows.Forms.GroupBox();
			this.btnAbortPaint = new System.Windows.Forms.Button();
			this.grpImageProperties = new System.Windows.Forms.GroupBox();
			this.btnLoadPalette = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPaletteShuffled)).BeginInit();
			this.grpGeneration.SuspendLayout();
			this.grpColourRefinement.SuspendLayout();
			this.grpPaint.SuspendLayout();
			this.grpImageProperties.SuspendLayout();
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
			this.pbFinalImage.Location = new System.Drawing.Point(6, 51);
			this.pbFinalImage.Name = "pbFinalImage";
			this.pbFinalImage.Size = new System.Drawing.Size(714, 774);
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
			this.pbPalette.Location = new System.Drawing.Point(6, 79);
			this.pbPalette.Name = "pbPalette";
			this.pbPalette.Size = new System.Drawing.Size(188, 658);
			this.pbPalette.TabIndex = 7;
			this.pbPalette.TabStop = false;
			// 
			// btnGenerateColours
			// 
			this.btnGenerateColours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerateColours.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnGenerateColours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGenerateColours.Location = new System.Drawing.Point(6, 21);
			this.btnGenerateColours.Name = "btnGenerateColours";
			this.btnGenerateColours.Size = new System.Drawing.Size(188, 23);
			this.btnGenerateColours.TabIndex = 1;
			this.btnGenerateColours.Text = "Generate Colours";
			this.btnGenerateColours.UseVisualStyleBackColor = false;
			this.btnGenerateColours.Click += new System.EventHandler(this.btnGenerateColours_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopy.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCopy.Location = new System.Drawing.Point(6, 21);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(188, 23);
			this.btnCopy.TabIndex = 2;
			this.btnCopy.Text = "Copy From Generated";
			this.btnCopy.UseVisualStyleBackColor = false;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnPaint
			// 
			this.btnPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPaint.Location = new System.Drawing.Point(228, 22);
			this.btnPaint.Name = "btnPaint";
			this.btnPaint.Size = new System.Drawing.Size(75, 23);
			this.btnPaint.TabIndex = 3;
			this.btnPaint.Text = "Paint";
			this.btnPaint.UseVisualStyleBackColor = false;
			this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(471, 22);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// tbWidth
			// 
			this.tbWidth.Location = new System.Drawing.Point(63, 22);
			this.tbWidth.Name = "tbWidth";
			this.tbWidth.Size = new System.Drawing.Size(76, 23);
			this.tbWidth.TabIndex = 5;
			this.tbWidth.Text = "64";
			// 
			// tbHeight
			// 
			this.tbHeight.Location = new System.Drawing.Point(63, 51);
			this.tbHeight.Name = "tbHeight";
			this.tbHeight.Size = new System.Drawing.Size(76, 23);
			this.tbHeight.TabIndex = 6;
			this.tbHeight.Text = "64";
			// 
			// pbPaletteShuffled
			// 
			this.pbPaletteShuffled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbPaletteShuffled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbPaletteShuffled.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.pbPaletteShuffled.Location = new System.Drawing.Point(6, 108);
			this.pbPaletteShuffled.Name = "pbPaletteShuffled";
			this.pbPaletteShuffled.Size = new System.Drawing.Size(188, 629);
			this.pbPaletteShuffled.TabIndex = 9;
			this.pbPaletteShuffled.TabStop = false;
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(18, 25);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(39, 15);
			this.lblWidth.TabIndex = 10;
			this.lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(14, 54);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(43, 15);
			this.lblHeight.TabIndex = 11;
			this.lblHeight.Text = "Height";
			// 
			// chkAverageMode
			// 
			this.chkAverageMode.AutoSize = true;
			this.chkAverageMode.Location = new System.Drawing.Point(135, 25);
			this.chkAverageMode.Name = "chkAverageMode";
			this.chkAverageMode.Size = new System.Drawing.Size(87, 19);
			this.chkAverageMode.TabIndex = 12;
			this.chkAverageMode.Text = "Min Or Avg";
			this.chkAverageMode.UseVisualStyleBackColor = true;
			this.chkAverageMode.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// pgPaint
			// 
			this.pgPaint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pgPaint.Location = new System.Drawing.Point(12, 853);
			this.pgPaint.Name = "pgPaint";
			this.pgPaint.Size = new System.Drawing.Size(1136, 23);
			this.pgPaint.TabIndex = 13;
			// 
			// lblETA
			// 
			this.lblETA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblETA.AutoSize = true;
			this.lblETA.Location = new System.Drawing.Point(12, 879);
			this.lblETA.Name = "lblETA";
			this.lblETA.Size = new System.Drawing.Size(26, 15);
			this.lblETA.TabIndex = 14;
			this.lblETA.Text = "ETA";
			// 
			// btnPausePaint
			// 
			this.btnPausePaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnPausePaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPausePaint.Location = new System.Drawing.Point(309, 22);
			this.btnPausePaint.Name = "btnPausePaint";
			this.btnPausePaint.Size = new System.Drawing.Size(75, 23);
			this.btnPausePaint.TabIndex = 15;
			this.btnPausePaint.Text = "Pause";
			this.btnPausePaint.UseVisualStyleBackColor = false;
			this.btnPausePaint.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// btnOpenDir
			// 
			this.btnOpenDir.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnOpenDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOpenDir.Location = new System.Drawing.Point(144, 22);
			this.btnOpenDir.Name = "btnOpenDir";
			this.btnOpenDir.Size = new System.Drawing.Size(256, 52);
			this.btnOpenDir.TabIndex = 16;
			this.btnOpenDir.Text = "Open Saved Images Folder";
			this.btnOpenDir.UseVisualStyleBackColor = false;
			this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
			// 
			// btnLoadTemplate
			// 
			this.btnLoadTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnLoadTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadTemplate.Location = new System.Drawing.Point(6, 22);
			this.btnLoadTemplate.Name = "btnLoadTemplate";
			this.btnLoadTemplate.Size = new System.Drawing.Size(123, 23);
			this.btnLoadTemplate.TabIndex = 17;
			this.btnLoadTemplate.Text = "Load Template";
			this.btnLoadTemplate.UseVisualStyleBackColor = false;
			this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
			// 
			// grpGeneration
			// 
			this.grpGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grpGeneration.Controls.Add(this.btnLoadPalette);
			this.grpGeneration.Controls.Add(this.pbPalette);
			this.grpGeneration.Controls.Add(this.btnGenerateColours);
			this.grpGeneration.Location = new System.Drawing.Point(12, 100);
			this.grpGeneration.Name = "grpGeneration";
			this.grpGeneration.Size = new System.Drawing.Size(200, 743);
			this.grpGeneration.TabIndex = 18;
			this.grpGeneration.TabStop = false;
			this.grpGeneration.Text = "Colour Generation";
			// 
			// btnEqualise
			// 
			this.btnEqualise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEqualise.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnEqualise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEqualise.Location = new System.Drawing.Point(6, 79);
			this.btnEqualise.Name = "btnEqualise";
			this.btnEqualise.Size = new System.Drawing.Size(91, 23);
			this.btnEqualise.TabIndex = 8;
			this.btnEqualise.Text = "Equalise";
			this.btnEqualise.UseVisualStyleBackColor = false;
			this.btnEqualise.Click += new System.EventHandler(this.btnEqualise_Click);
			// 
			// grpColourRefinement
			// 
			this.grpColourRefinement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grpColourRefinement.Controls.Add(this.btnEqualise);
			this.grpColourRefinement.Controls.Add(this.btnReverse);
			this.grpColourRefinement.Controls.Add(this.btnShuffle);
			this.grpColourRefinement.Controls.Add(this.btnCopy);
			this.grpColourRefinement.Controls.Add(this.pbPaletteShuffled);
			this.grpColourRefinement.Location = new System.Drawing.Point(218, 100);
			this.grpColourRefinement.Name = "grpColourRefinement";
			this.grpColourRefinement.Size = new System.Drawing.Size(200, 743);
			this.grpColourRefinement.TabIndex = 8;
			this.grpColourRefinement.TabStop = false;
			this.grpColourRefinement.Text = "Refinement";
			// 
			// btnReverse
			// 
			this.btnReverse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReverse.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReverse.Location = new System.Drawing.Point(103, 50);
			this.btnReverse.Name = "btnReverse";
			this.btnReverse.Size = new System.Drawing.Size(91, 23);
			this.btnReverse.TabIndex = 11;
			this.btnReverse.Text = "Reverse";
			this.btnReverse.UseVisualStyleBackColor = false;
			this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
			// 
			// btnShuffle
			// 
			this.btnShuffle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnShuffle.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnShuffle.Location = new System.Drawing.Point(6, 50);
			this.btnShuffle.Name = "btnShuffle";
			this.btnShuffle.Size = new System.Drawing.Size(91, 23);
			this.btnShuffle.TabIndex = 10;
			this.btnShuffle.Text = "Shuffle";
			this.btnShuffle.UseVisualStyleBackColor = false;
			this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
			// 
			// grpPaint
			// 
			this.grpPaint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpPaint.Controls.Add(this.btnAbortPaint);
			this.grpPaint.Controls.Add(this.btnPaint);
			this.grpPaint.Controls.Add(this.btnPausePaint);
			this.grpPaint.Controls.Add(this.pbFinalImage);
			this.grpPaint.Controls.Add(this.btnLoadTemplate);
			this.grpPaint.Controls.Add(this.chkAverageMode);
			this.grpPaint.Controls.Add(this.btnSave);
			this.grpPaint.Location = new System.Drawing.Point(424, 12);
			this.grpPaint.Name = "grpPaint";
			this.grpPaint.Size = new System.Drawing.Size(726, 831);
			this.grpPaint.TabIndex = 10;
			this.grpPaint.TabStop = false;
			this.grpPaint.Text = "Paint";
			// 
			// btnAbortPaint
			// 
			this.btnAbortPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnAbortPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAbortPaint.Location = new System.Drawing.Point(390, 22);
			this.btnAbortPaint.Name = "btnAbortPaint";
			this.btnAbortPaint.Size = new System.Drawing.Size(75, 23);
			this.btnAbortPaint.TabIndex = 18;
			this.btnAbortPaint.Text = "Abort";
			this.btnAbortPaint.UseVisualStyleBackColor = false;
			this.btnAbortPaint.Click += new System.EventHandler(this.btnAbortPaint_Click);
			// 
			// grpImageProperties
			// 
			this.grpImageProperties.Controls.Add(this.tbWidth);
			this.grpImageProperties.Controls.Add(this.tbHeight);
			this.grpImageProperties.Controls.Add(this.lblWidth);
			this.grpImageProperties.Controls.Add(this.lblHeight);
			this.grpImageProperties.Controls.Add(this.btnOpenDir);
			this.grpImageProperties.Location = new System.Drawing.Point(12, 12);
			this.grpImageProperties.Name = "grpImageProperties";
			this.grpImageProperties.Size = new System.Drawing.Size(406, 82);
			this.grpImageProperties.TabIndex = 19;
			this.grpImageProperties.TabStop = false;
			this.grpImageProperties.Text = "Image";
			// 
			// btnLoadPalette
			// 
			this.btnLoadPalette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadPalette.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnLoadPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadPalette.Location = new System.Drawing.Point(6, 50);
			this.btnLoadPalette.Name = "btnLoadPalette";
			this.btnLoadPalette.Size = new System.Drawing.Size(188, 23);
			this.btnLoadPalette.TabIndex = 8;
			this.btnLoadPalette.Text = "Load Palette";
			this.btnLoadPalette.UseVisualStyleBackColor = false;
			this.btnLoadPalette.Click += new System.EventHandler(this.btnLoadPalette_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1161, 903);
			this.Controls.Add(this.grpImageProperties);
			this.Controls.Add(this.grpPaint);
			this.Controls.Add(this.grpColourRefinement);
			this.Controls.Add(this.grpGeneration);
			this.Controls.Add(this.lblETA);
			this.Controls.Add(this.pgPaint);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "All-RGB Image Generator";
			((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPaletteShuffled)).EndInit();
			this.grpGeneration.ResumeLayout(false);
			this.grpColourRefinement.ResumeLayout(false);
			this.grpPaint.ResumeLayout(false);
			this.grpPaint.PerformLayout();
			this.grpImageProperties.ResumeLayout(false);
			this.grpImageProperties.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PictureBoxWithInterpolationMode pbFinalImage;
		private PictureBoxWithInterpolationMode pbPalette;
		private System.Windows.Forms.Button btnGenerateColours;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnPaint;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox tbWidth;
		private System.Windows.Forms.TextBox tbHeight;
		private PictureBoxWithInterpolationMode pbPaletteShuffled;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.CheckBox chkAverageMode;
		private System.Windows.Forms.ProgressBar pgPaint;
		private System.Windows.Forms.Label lblETA;
		private System.Windows.Forms.Button btnPausePaint;
		private System.Windows.Forms.Button btnOpenDir;
		private System.Windows.Forms.Button btnLoadTemplate;
		private System.Windows.Forms.GroupBox grpGeneration;
		private System.Windows.Forms.GroupBox grpColourRefinement;
		private System.Windows.Forms.GroupBox grpPaint;
		private System.Windows.Forms.GroupBox grpImageProperties;
		private System.Windows.Forms.Button btnAbortPaint;
		private System.Windows.Forms.Button btnEqualise;
		private System.Windows.Forms.Button btnReverse;
		private System.Windows.Forms.Button btnShuffle;
		private System.Windows.Forms.Button btnLoadPalette;
	}
}

