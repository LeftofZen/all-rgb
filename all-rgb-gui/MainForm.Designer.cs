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
			this.btnShuffleColours = new System.Windows.Forms.Button();
			this.btnPaint = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.tbWidth = new System.Windows.Forms.TextBox();
			this.tbHeight = new System.Windows.Forms.TextBox();
			this.pbPaletteShuffled = new all_rgb_gui.PictureBoxWithInterpolationMode();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.chkAverageMode = new System.Windows.Forms.CheckBox();
			this.pgPaint = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPaletteShuffled)).BeginInit();
			this.SuspendLayout();
			// 
			// pbFinalImage
			// 
			this.pbFinalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pbFinalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbFinalImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.pbFinalImage.Location = new System.Drawing.Point(12, 129);
			this.pbFinalImage.Name = "pbFinalImage";
			this.pbFinalImage.Size = new System.Drawing.Size(300, 300);
			this.pbFinalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbFinalImage.TabIndex = 0;
			this.pbFinalImage.TabStop = false;
			// 
			// pbPalette
			// 
			this.pbPalette.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.pbPalette.Location = new System.Drawing.Point(318, 11);
			this.pbPalette.Name = "pbPalette";
			this.pbPalette.Size = new System.Drawing.Size(100, 417);
			this.pbPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbPalette.TabIndex = 7;
			this.pbPalette.TabStop = false;
			// 
			// btnGenerateColours
			// 
			this.btnGenerateColours.Location = new System.Drawing.Point(13, 13);
			this.btnGenerateColours.Name = "btnGenerateColours";
			this.btnGenerateColours.Size = new System.Drawing.Size(125, 23);
			this.btnGenerateColours.TabIndex = 1;
			this.btnGenerateColours.Text = "Generate Colours";
			this.btnGenerateColours.UseVisualStyleBackColor = true;
			this.btnGenerateColours.Click += new System.EventHandler(this.btnGenerateColours_Click);
			// 
			// btnShuffleColours
			// 
			this.btnShuffleColours.Location = new System.Drawing.Point(13, 42);
			this.btnShuffleColours.Name = "btnShuffleColours";
			this.btnShuffleColours.Size = new System.Drawing.Size(125, 23);
			this.btnShuffleColours.TabIndex = 2;
			this.btnShuffleColours.Text = "Shuffle Colours";
			this.btnShuffleColours.UseVisualStyleBackColor = true;
			this.btnShuffleColours.Click += new System.EventHandler(this.btnShuffleColours_Click);
			// 
			// btnPaint
			// 
			this.btnPaint.Location = new System.Drawing.Point(13, 71);
			this.btnPaint.Name = "btnPaint";
			this.btnPaint.Size = new System.Drawing.Size(125, 23);
			this.btnPaint.TabIndex = 3;
			this.btnPaint.Text = "Paint";
			this.btnPaint.UseVisualStyleBackColor = true;
			this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(13, 100);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(125, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// tbWidth
			// 
			this.tbWidth.Location = new System.Drawing.Point(236, 11);
			this.tbWidth.Name = "tbWidth";
			this.tbWidth.Size = new System.Drawing.Size(76, 23);
			this.tbWidth.TabIndex = 5;
			this.tbWidth.Text = "64";
			// 
			// tbHeight
			// 
			this.tbHeight.Location = new System.Drawing.Point(236, 40);
			this.tbHeight.Name = "tbHeight";
			this.tbHeight.Size = new System.Drawing.Size(76, 23);
			this.tbHeight.TabIndex = 6;
			this.tbHeight.Text = "64";
			// 
			// pbPaletteShuffled
			// 
			this.pbPaletteShuffled.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.pbPaletteShuffled.Location = new System.Drawing.Point(424, 11);
			this.pbPaletteShuffled.Name = "pbPaletteShuffled";
			this.pbPaletteShuffled.Size = new System.Drawing.Size(100, 418);
			this.pbPaletteShuffled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbPaletteShuffled.TabIndex = 9;
			this.pbPaletteShuffled.TabStop = false;
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(191, 14);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(39, 15);
			this.lblWidth.TabIndex = 10;
			this.lblWidth.Text = "Width";
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(187, 43);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(43, 15);
			this.lblHeight.TabIndex = 11;
			this.lblHeight.Text = "Height";
			// 
			// chkAverageMode
			// 
			this.chkAverageMode.AutoSize = true;
			this.chkAverageMode.Location = new System.Drawing.Point(225, 74);
			this.chkAverageMode.Name = "chkAverageMode";
			this.chkAverageMode.Size = new System.Drawing.Size(87, 19);
			this.chkAverageMode.TabIndex = 12;
			this.chkAverageMode.Text = "Min Or Avg";
			this.chkAverageMode.UseVisualStyleBackColor = true;
			this.chkAverageMode.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// pgPaint
			// 
			this.pgPaint.Location = new System.Drawing.Point(12, 435);
			this.pgPaint.Name = "pgPaint";
			this.pgPaint.Size = new System.Drawing.Size(512, 23);
			this.pgPaint.TabIndex = 13;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 470);
			this.Controls.Add(this.pgPaint);
			this.Controls.Add(this.chkAverageMode);
			this.Controls.Add(this.lblHeight);
			this.Controls.Add(this.lblWidth);
			this.Controls.Add(this.pbPaletteShuffled);
			this.Controls.Add(this.pbPalette);
			this.Controls.Add(this.tbHeight);
			this.Controls.Add(this.tbWidth);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnPaint);
			this.Controls.Add(this.btnShuffleColours);
			this.Controls.Add(this.btnGenerateColours);
			this.Controls.Add(this.pbFinalImage);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "All-RGB Image Generator";
			((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPaletteShuffled)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PictureBoxWithInterpolationMode pbFinalImage;
		private PictureBoxWithInterpolationMode pbPalette;
		private System.Windows.Forms.Button btnGenerateColours;
		private System.Windows.Forms.Button btnShuffleColours;
		private System.Windows.Forms.Button btnPaint;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox tbWidth;
		private System.Windows.Forms.TextBox tbHeight;
		private PictureBoxWithInterpolationMode pbPaletteShuffled;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.CheckBox chkAverageMode;
		private System.Windows.Forms.ProgressBar pgPaint;
	}
}

