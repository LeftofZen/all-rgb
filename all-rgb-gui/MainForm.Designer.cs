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
			btnSortColours = new System.Windows.Forms.Button();
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
			btnPause = new System.Windows.Forms.Button();
			btnOpenDir = new System.Windows.Forms.Button();
			btnLoadTemplate = new System.Windows.Forms.Button();
			btnReverse = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)pbFinalImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbPalette).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbPaletteShuffled).BeginInit();
			SuspendLayout();
			// 
			// pbFinalImage
			// 
			pbFinalImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pbFinalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			pbFinalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbFinalImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			pbFinalImage.Location = new System.Drawing.Point(12, 129);
			pbFinalImage.Name = "pbFinalImage";
			pbFinalImage.Size = new System.Drawing.Size(300, 300);
			pbFinalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pbFinalImage.TabIndex = 0;
			pbFinalImage.TabStop = false;
			// 
			// pbPalette
			// 
			pbPalette.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			pbPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbPalette.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			pbPalette.Location = new System.Drawing.Point(318, 11);
			pbPalette.Name = "pbPalette";
			pbPalette.Size = new System.Drawing.Size(100, 418);
			pbPalette.TabIndex = 7;
			pbPalette.TabStop = false;
			// 
			// btnGenerateColours
			// 
			btnGenerateColours.Location = new System.Drawing.Point(12, 14);
			btnGenerateColours.Name = "btnGenerateColours";
			btnGenerateColours.Size = new System.Drawing.Size(156, 23);
			btnGenerateColours.TabIndex = 1;
			btnGenerateColours.Text = "Generate Colours";
			btnGenerateColours.UseVisualStyleBackColor = true;
			btnGenerateColours.Click += btnGenerateColours_Click;
			// 
			// btnSortColours
			// 
			btnSortColours.Location = new System.Drawing.Point(12, 42);
			btnSortColours.Name = "btnSortColours";
			btnSortColours.Size = new System.Drawing.Size(75, 23);
			btnSortColours.TabIndex = 2;
			btnSortColours.Text = "Sort Colours";
			btnSortColours.UseVisualStyleBackColor = true;
			btnSortColours.Click += btnShuffleColours_Click;
			// 
			// btnPaint
			// 
			btnPaint.Location = new System.Drawing.Point(12, 71);
			btnPaint.Name = "btnPaint";
			btnPaint.Size = new System.Drawing.Size(75, 23);
			btnPaint.TabIndex = 3;
			btnPaint.Text = "Paint";
			btnPaint.UseVisualStyleBackColor = true;
			btnPaint.Click += btnPaint_Click;
			// 
			// btnSave
			// 
			btnSave.Location = new System.Drawing.Point(138, 99);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(75, 23);
			btnSave.TabIndex = 4;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// tbWidth
			// 
			tbWidth.Location = new System.Drawing.Point(236, 11);
			tbWidth.Name = "tbWidth";
			tbWidth.Size = new System.Drawing.Size(76, 23);
			tbWidth.TabIndex = 5;
			tbWidth.Text = "128";
			// 
			// tbHeight
			// 
			tbHeight.Location = new System.Drawing.Point(236, 40);
			tbHeight.Name = "tbHeight";
			tbHeight.Size = new System.Drawing.Size(76, 23);
			tbHeight.TabIndex = 6;
			tbHeight.Text = "128";
			// 
			// pbPaletteShuffled
			// 
			pbPaletteShuffled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			pbPaletteShuffled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbPaletteShuffled.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			pbPaletteShuffled.Location = new System.Drawing.Point(424, 11);
			pbPaletteShuffled.Name = "pbPaletteShuffled";
			pbPaletteShuffled.Size = new System.Drawing.Size(100, 418);
			pbPaletteShuffled.TabIndex = 9;
			pbPaletteShuffled.TabStop = false;
			// 
			// lblWidth
			// 
			lblWidth.AutoSize = true;
			lblWidth.Location = new System.Drawing.Point(191, 14);
			lblWidth.Name = "lblWidth";
			lblWidth.Size = new System.Drawing.Size(39, 15);
			lblWidth.TabIndex = 10;
			lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			lblHeight.AutoSize = true;
			lblHeight.Location = new System.Drawing.Point(187, 43);
			lblHeight.Name = "lblHeight";
			lblHeight.Size = new System.Drawing.Size(43, 15);
			lblHeight.TabIndex = 11;
			lblHeight.Text = "Height";
			// 
			// chkAverageMode
			// 
			chkAverageMode.AutoSize = true;
			chkAverageMode.Location = new System.Drawing.Point(225, 74);
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
			pgPaint.Location = new System.Drawing.Point(12, 446);
			pgPaint.Name = "pgPaint";
			pgPaint.Size = new System.Drawing.Size(512, 23);
			pgPaint.TabIndex = 13;
			// 
			// lblETA
			// 
			lblETA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lblETA.AutoSize = true;
			lblETA.Location = new System.Drawing.Point(12, 472);
			lblETA.Name = "lblETA";
			lblETA.Size = new System.Drawing.Size(26, 15);
			lblETA.TabIndex = 14;
			lblETA.Text = "ETA";
			// 
			// btnPause
			// 
			btnPause.Location = new System.Drawing.Point(94, 70);
			btnPause.Name = "btnPause";
			btnPause.Size = new System.Drawing.Size(75, 23);
			btnPause.TabIndex = 15;
			btnPause.Text = "Pause";
			btnPause.UseVisualStyleBackColor = true;
			btnPause.Click += btnPause_Click;
			// 
			// btnOpenDir
			// 
			btnOpenDir.Location = new System.Drawing.Point(12, 99);
			btnOpenDir.Name = "btnOpenDir";
			btnOpenDir.Size = new System.Drawing.Size(120, 23);
			btnOpenDir.TabIndex = 16;
			btnOpenDir.Text = "Open Saved Images";
			btnOpenDir.UseVisualStyleBackColor = true;
			btnOpenDir.Click += btnOpenDir_Click;
			// 
			// btnLoadTemplate
			// 
			btnLoadTemplate.Location = new System.Drawing.Point(219, 100);
			btnLoadTemplate.Name = "btnLoadTemplate";
			btnLoadTemplate.Size = new System.Drawing.Size(93, 23);
			btnLoadTemplate.TabIndex = 17;
			btnLoadTemplate.Text = "Load Template";
			btnLoadTemplate.UseVisualStyleBackColor = true;
			btnLoadTemplate.Click += btnLoadTemplate_Click;
			// 
			// btnReverse
			// 
			btnReverse.Location = new System.Drawing.Point(94, 42);
			btnReverse.Name = "btnReverse";
			btnReverse.Size = new System.Drawing.Size(74, 23);
			btnReverse.TabIndex = 18;
			btnReverse.Text = "Reverse Colours";
			btnReverse.UseVisualStyleBackColor = true;
			btnReverse.Click += btnReverseColours_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(537, 496);
			Controls.Add(btnReverse);
			Controls.Add(btnLoadTemplate);
			Controls.Add(btnOpenDir);
			Controls.Add(btnPause);
			Controls.Add(lblETA);
			Controls.Add(pgPaint);
			Controls.Add(chkAverageMode);
			Controls.Add(lblHeight);
			Controls.Add(lblWidth);
			Controls.Add(pbPaletteShuffled);
			Controls.Add(pbPalette);
			Controls.Add(tbHeight);
			Controls.Add(tbWidth);
			Controls.Add(btnSave);
			Controls.Add(btnPaint);
			Controls.Add(btnSortColours);
			Controls.Add(btnGenerateColours);
			Controls.Add(pbFinalImage);
			Name = "MainForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "All-RGB Image Generator";
			((System.ComponentModel.ISupportInitialize)pbFinalImage).EndInit();
			((System.ComponentModel.ISupportInitialize)pbPalette).EndInit();
			((System.ComponentModel.ISupportInitialize)pbPaletteShuffled).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBoxWithInterpolationMode pbFinalImage;
		private PictureBoxWithInterpolationMode pbPalette;
		private System.Windows.Forms.Button btnGenerateColours;
		private System.Windows.Forms.Button btnSortColours;
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
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Button btnOpenDir;
		private System.Windows.Forms.Button btnLoadTemplate;
		private System.Windows.Forms.Button btnReverse;
	}
}

