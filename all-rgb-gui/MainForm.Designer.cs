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
			pbFinalImage = new PictureBoxWithInterpolationMode();
			pbPalette = new PictureBoxWithInterpolationMode();
			btnGenerateColours = new System.Windows.Forms.Button();
			btnCopy = new System.Windows.Forms.Button();
			btnPaint = new System.Windows.Forms.Button();
			btnSave = new System.Windows.Forms.Button();
			tbWidth = new System.Windows.Forms.TextBox();
			tbHeight = new System.Windows.Forms.TextBox();
			pbPaletteShuffled = new PictureBoxWithInterpolationMode();
			lblWidth = new System.Windows.Forms.Label();
			lblHeight = new System.Windows.Forms.Label();
			chkAverageMode = new System.Windows.Forms.CheckBox();
			pgPaint = new System.Windows.Forms.ProgressBar();
			lblETA = new System.Windows.Forms.Label();
			btnPausePaint = new System.Windows.Forms.Button();
			btnOpenDir = new System.Windows.Forms.Button();
			btnLoadTemplate = new System.Windows.Forms.Button();
			grpGeneration = new System.Windows.Forms.GroupBox();
			btnLoadPalette = new System.Windows.Forms.Button();
			btnEqualise = new System.Windows.Forms.Button();
			grpColourRefinement = new System.Windows.Forms.GroupBox();
			btnSortNN = new System.Windows.Forms.Button();
			btnSortHSB = new System.Windows.Forms.Button();
			btnSortRGB = new System.Windows.Forms.Button();
			btnReverse = new System.Windows.Forms.Button();
			btnShuffle = new System.Windows.Forms.Button();
			grpPaint = new System.Windows.Forms.GroupBox();
			btnAbortPaint = new System.Windows.Forms.Button();
			grpImageProperties = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)pbFinalImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbPalette).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbPaletteShuffled).BeginInit();
			grpGeneration.SuspendLayout();
			grpColourRefinement.SuspendLayout();
			grpPaint.SuspendLayout();
			grpImageProperties.SuspendLayout();
			SuspendLayout();
			// 
			// pbFinalImage
			// 
			pbFinalImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pbFinalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			pbFinalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbFinalImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			pbFinalImage.Location = new System.Drawing.Point(6, 51);
			pbFinalImage.Name = "pbFinalImage";
			pbFinalImage.Size = new System.Drawing.Size(714, 774);
			pbFinalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pbFinalImage.TabIndex = 0;
			pbFinalImage.TabStop = false;
			// 
			// pbPalette
			// 
			pbPalette.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pbPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbPalette.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			pbPalette.Location = new System.Drawing.Point(6, 79);
			pbPalette.Name = "pbPalette";
			pbPalette.Size = new System.Drawing.Size(188, 658);
			pbPalette.TabIndex = 7;
			pbPalette.TabStop = false;
			// 
			// btnGenerateColours
			// 
			btnGenerateColours.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnGenerateColours.BackColor = System.Drawing.SystemColors.ControlLight;
			btnGenerateColours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnGenerateColours.Location = new System.Drawing.Point(6, 21);
			btnGenerateColours.Name = "btnGenerateColours";
			btnGenerateColours.Size = new System.Drawing.Size(188, 23);
			btnGenerateColours.TabIndex = 1;
			btnGenerateColours.Text = "Generate Colours";
			btnGenerateColours.UseVisualStyleBackColor = false;
			btnGenerateColours.Click += btnGenerateColours_Click;
			// 
			// btnCopy
			// 
			btnCopy.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnCopy.BackColor = System.Drawing.SystemColors.ControlLight;
			btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCopy.Location = new System.Drawing.Point(6, 21);
			btnCopy.Name = "btnCopy";
			btnCopy.Size = new System.Drawing.Size(188, 23);
			btnCopy.TabIndex = 2;
			btnCopy.Text = "Copy From Generated";
			btnCopy.UseVisualStyleBackColor = false;
			btnCopy.Click += btnCopy_Click;
			// 
			// btnPaint
			// 
			btnPaint.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
			btnPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnPaint.Location = new System.Drawing.Point(228, 22);
			btnPaint.Name = "btnPaint";
			btnPaint.Size = new System.Drawing.Size(75, 23);
			btnPaint.TabIndex = 3;
			btnPaint.Text = "Paint";
			btnPaint.UseVisualStyleBackColor = false;
			btnPaint.Click += btnPaint_Click;
			// 
			// btnSave
			// 
			btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Location = new System.Drawing.Point(471, 22);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(75, 23);
			btnSave.TabIndex = 4;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += btnSave_Click;
			// 
			// tbWidth
			// 
			tbWidth.Location = new System.Drawing.Point(63, 22);
			tbWidth.Name = "tbWidth";
			tbWidth.Size = new System.Drawing.Size(76, 23);
			tbWidth.TabIndex = 5;
			tbWidth.Text = "128";
			// 
			// tbHeight
			// 
			tbHeight.Location = new System.Drawing.Point(63, 51);
			tbHeight.Name = "tbHeight";
			tbHeight.Size = new System.Drawing.Size(76, 23);
			tbHeight.TabIndex = 6;
			tbHeight.Text = "128";
			// 
			// pbPaletteShuffled
			// 
			pbPaletteShuffled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pbPaletteShuffled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbPaletteShuffled.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			pbPaletteShuffled.Location = new System.Drawing.Point(6, 137);
			pbPaletteShuffled.Name = "pbPaletteShuffled";
			pbPaletteShuffled.Size = new System.Drawing.Size(188, 600);
			pbPaletteShuffled.TabIndex = 9;
			pbPaletteShuffled.TabStop = false;
			// 
			// lblWidth
			// 
			lblWidth.AutoSize = true;
			lblWidth.Location = new System.Drawing.Point(18, 25);
			lblWidth.Name = "lblWidth";
			lblWidth.Size = new System.Drawing.Size(39, 15);
			lblWidth.TabIndex = 10;
			lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			lblHeight.AutoSize = true;
			lblHeight.Location = new System.Drawing.Point(14, 54);
			lblHeight.Name = "lblHeight";
			lblHeight.Size = new System.Drawing.Size(43, 15);
			lblHeight.TabIndex = 11;
			lblHeight.Text = "Height";
			// 
			// chkAverageMode
			// 
			chkAverageMode.AutoSize = true;
			chkAverageMode.Location = new System.Drawing.Point(135, 25);
			chkAverageMode.Name = "chkAverageMode";
			chkAverageMode.Size = new System.Drawing.Size(87, 19);
			chkAverageMode.TabIndex = 12;
			chkAverageMode.Text = "Min Or Avg";
			chkAverageMode.UseVisualStyleBackColor = true;
			chkAverageMode.CheckedChanged += checkBox1_CheckedChanged;
			// 
			// pgPaint
			// 
			pgPaint.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pgPaint.Location = new System.Drawing.Point(12, 853);
			pgPaint.Name = "pgPaint";
			pgPaint.Size = new System.Drawing.Size(1136, 23);
			pgPaint.TabIndex = 13;
			// 
			// lblETA
			// 
			lblETA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lblETA.AutoSize = true;
			lblETA.Location = new System.Drawing.Point(12, 879);
			lblETA.Name = "lblETA";
			lblETA.Size = new System.Drawing.Size(26, 15);
			lblETA.TabIndex = 14;
			lblETA.Text = "ETA";
			// 
			// btnPausePaint
			// 
			btnPausePaint.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
			btnPausePaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnPausePaint.Location = new System.Drawing.Point(309, 22);
			btnPausePaint.Name = "btnPausePaint";
			btnPausePaint.Size = new System.Drawing.Size(75, 23);
			btnPausePaint.TabIndex = 15;
			btnPausePaint.Text = "Pause";
			btnPausePaint.UseVisualStyleBackColor = false;
			btnPausePaint.Click += btnPause_Click;
			// 
			// btnOpenDir
			// 
			btnOpenDir.BackColor = System.Drawing.SystemColors.ControlLight;
			btnOpenDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnOpenDir.Location = new System.Drawing.Point(144, 22);
			btnOpenDir.Name = "btnOpenDir";
			btnOpenDir.Size = new System.Drawing.Size(256, 52);
			btnOpenDir.TabIndex = 16;
			btnOpenDir.Text = "Open Saved Images Folder";
			btnOpenDir.UseVisualStyleBackColor = false;
			btnOpenDir.Click += btnOpenDir_Click;
			// 
			// btnLoadTemplate
			// 
			btnLoadTemplate.BackColor = System.Drawing.SystemColors.ControlLight;
			btnLoadTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnLoadTemplate.Location = new System.Drawing.Point(6, 22);
			btnLoadTemplate.Name = "btnLoadTemplate";
			btnLoadTemplate.Size = new System.Drawing.Size(123, 23);
			btnLoadTemplate.TabIndex = 17;
			btnLoadTemplate.Text = "Load Template";
			btnLoadTemplate.UseVisualStyleBackColor = false;
			btnLoadTemplate.Click += btnLoadTemplate_Click;
			// 
			// grpGeneration
			// 
			grpGeneration.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			grpGeneration.Controls.Add(btnLoadPalette);
			grpGeneration.Controls.Add(pbPalette);
			grpGeneration.Controls.Add(btnGenerateColours);
			grpGeneration.Location = new System.Drawing.Point(12, 100);
			grpGeneration.Name = "grpGeneration";
			grpGeneration.Size = new System.Drawing.Size(200, 743);
			grpGeneration.TabIndex = 18;
			grpGeneration.TabStop = false;
			grpGeneration.Text = "Colour Generation";
			// 
			// btnLoadPalette
			// 
			btnLoadPalette.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnLoadPalette.BackColor = System.Drawing.SystemColors.ControlLight;
			btnLoadPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnLoadPalette.Location = new System.Drawing.Point(6, 50);
			btnLoadPalette.Name = "btnLoadPalette";
			btnLoadPalette.Size = new System.Drawing.Size(188, 23);
			btnLoadPalette.TabIndex = 8;
			btnLoadPalette.Text = "Load Palette";
			btnLoadPalette.UseVisualStyleBackColor = false;
			btnLoadPalette.Click += btnLoadPalette_Click;
			// 
			// btnEqualise
			// 
			btnEqualise.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnEqualise.BackColor = System.Drawing.SystemColors.ControlLight;
			btnEqualise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnEqualise.Location = new System.Drawing.Point(6, 79);
			btnEqualise.Name = "btnEqualise";
			btnEqualise.Size = new System.Drawing.Size(91, 23);
			btnEqualise.TabIndex = 8;
			btnEqualise.Text = "Equalise";
			btnEqualise.UseVisualStyleBackColor = false;
			btnEqualise.Click += btnEqualise_Click;
			// 
			// grpColourRefinement
			// 
			grpColourRefinement.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			grpColourRefinement.Controls.Add(btnSortNN);
			grpColourRefinement.Controls.Add(btnSortHSB);
			grpColourRefinement.Controls.Add(btnSortRGB);
			grpColourRefinement.Controls.Add(btnEqualise);
			grpColourRefinement.Controls.Add(btnReverse);
			grpColourRefinement.Controls.Add(btnShuffle);
			grpColourRefinement.Controls.Add(btnCopy);
			grpColourRefinement.Controls.Add(pbPaletteShuffled);
			grpColourRefinement.Location = new System.Drawing.Point(218, 100);
			grpColourRefinement.Name = "grpColourRefinement";
			grpColourRefinement.Size = new System.Drawing.Size(200, 743);
			grpColourRefinement.TabIndex = 8;
			grpColourRefinement.TabStop = false;
			grpColourRefinement.Text = "Refinement";
			// 
			// btnSortNN
			// 
			btnSortNN.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnSortNN.BackColor = System.Drawing.SystemColors.ControlLight;
			btnSortNN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSortNN.Location = new System.Drawing.Point(103, 79);
			btnSortNN.Name = "btnSortNN";
			btnSortNN.Size = new System.Drawing.Size(91, 23);
			btnSortNN.TabIndex = 14;
			btnSortNN.Text = "Sort NN";
			btnSortNN.UseVisualStyleBackColor = false;
			btnSortNN.Click += btnSortNN_Click;
			// 
			// btnSortHSB
			// 
			btnSortHSB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnSortHSB.BackColor = System.Drawing.SystemColors.ControlLight;
			btnSortHSB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSortHSB.Location = new System.Drawing.Point(103, 108);
			btnSortHSB.Name = "btnSortHSB";
			btnSortHSB.Size = new System.Drawing.Size(91, 23);
			btnSortHSB.TabIndex = 13;
			btnSortHSB.Text = "Sort HSB";
			btnSortHSB.UseVisualStyleBackColor = false;
			btnSortHSB.Click += btnSortHSB_Click;
			// 
			// btnSortRGB
			// 
			btnSortRGB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnSortRGB.BackColor = System.Drawing.SystemColors.ControlLight;
			btnSortRGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSortRGB.Location = new System.Drawing.Point(6, 108);
			btnSortRGB.Name = "btnSortRGB";
			btnSortRGB.Size = new System.Drawing.Size(91, 23);
			btnSortRGB.TabIndex = 12;
			btnSortRGB.Text = "Sort RGB";
			btnSortRGB.UseVisualStyleBackColor = false;
			btnSortRGB.Click += btnSortRGB_Click;
			// 
			// btnReverse
			// 
			btnReverse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnReverse.BackColor = System.Drawing.SystemColors.ControlLight;
			btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnReverse.Location = new System.Drawing.Point(103, 50);
			btnReverse.Name = "btnReverse";
			btnReverse.Size = new System.Drawing.Size(91, 23);
			btnReverse.TabIndex = 11;
			btnReverse.Text = "Reverse";
			btnReverse.UseVisualStyleBackColor = false;
			btnReverse.Click += btnReverse_Click;
			// 
			// btnShuffle
			// 
			btnShuffle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			btnShuffle.BackColor = System.Drawing.SystemColors.ControlLight;
			btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnShuffle.Location = new System.Drawing.Point(6, 50);
			btnShuffle.Name = "btnShuffle";
			btnShuffle.Size = new System.Drawing.Size(91, 23);
			btnShuffle.TabIndex = 10;
			btnShuffle.Text = "Shuffle";
			btnShuffle.UseVisualStyleBackColor = false;
			btnShuffle.Click += btnShuffle_Click;
			// 
			// grpPaint
			// 
			grpPaint.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			grpPaint.Controls.Add(btnAbortPaint);
			grpPaint.Controls.Add(btnPaint);
			grpPaint.Controls.Add(btnPausePaint);
			grpPaint.Controls.Add(pbFinalImage);
			grpPaint.Controls.Add(btnLoadTemplate);
			grpPaint.Controls.Add(chkAverageMode);
			grpPaint.Controls.Add(btnSave);
			grpPaint.Location = new System.Drawing.Point(424, 12);
			grpPaint.Name = "grpPaint";
			grpPaint.Size = new System.Drawing.Size(726, 831);
			grpPaint.TabIndex = 10;
			grpPaint.TabStop = false;
			grpPaint.Text = "Paint";
			// 
			// btnAbortPaint
			// 
			btnAbortPaint.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
			btnAbortPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAbortPaint.Location = new System.Drawing.Point(390, 22);
			btnAbortPaint.Name = "btnAbortPaint";
			btnAbortPaint.Size = new System.Drawing.Size(75, 23);
			btnAbortPaint.TabIndex = 18;
			btnAbortPaint.Text = "Abort";
			btnAbortPaint.UseVisualStyleBackColor = false;
			btnAbortPaint.Click += btnAbortPaint_Click;
			// 
			// grpImageProperties
			// 
			grpImageProperties.Controls.Add(tbWidth);
			grpImageProperties.Controls.Add(tbHeight);
			grpImageProperties.Controls.Add(lblWidth);
			grpImageProperties.Controls.Add(lblHeight);
			grpImageProperties.Controls.Add(btnOpenDir);
			grpImageProperties.Location = new System.Drawing.Point(12, 12);
			grpImageProperties.Name = "grpImageProperties";
			grpImageProperties.Size = new System.Drawing.Size(406, 82);
			grpImageProperties.TabIndex = 19;
			grpImageProperties.TabStop = false;
			grpImageProperties.Text = "Image";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1161, 903);
			Controls.Add(grpImageProperties);
			Controls.Add(grpPaint);
			Controls.Add(grpColourRefinement);
			Controls.Add(grpGeneration);
			Controls.Add(lblETA);
			Controls.Add(pgPaint);
			Name = "MainForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "All-RGB Image Generator";
			((System.ComponentModel.ISupportInitialize)pbFinalImage).EndInit();
			((System.ComponentModel.ISupportInitialize)pbPalette).EndInit();
			((System.ComponentModel.ISupportInitialize)pbPaletteShuffled).EndInit();
			grpGeneration.ResumeLayout(false);
			grpColourRefinement.ResumeLayout(false);
			grpPaint.ResumeLayout(false);
			grpPaint.PerformLayout();
			grpImageProperties.ResumeLayout(false);
			grpImageProperties.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
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
		private System.Windows.Forms.Button btnSortHSB;
		private System.Windows.Forms.Button btnSortRGB;
		private System.Windows.Forms.Button btnSortNN;
	}
}

