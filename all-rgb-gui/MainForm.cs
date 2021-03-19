using System;
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
			gen.ProgressCallback = (value) => pgPaint.Value = value;
		}

		AllRGBGenerator gen;

		private void btnGenerateColours_Click(object sender, EventArgs e)
		{
			gen.CreateBuffer(Int32.Parse(tbWidth.Text), Int32.Parse(tbHeight.Text));
			gen.GenerateColours();
			pbPalette.Image = gen.GetPalette();
		}

		private void btnShuffleColours_Click(object sender, EventArgs e)
		{
			gen.ShuffleColours();
			pbPaletteShuffled.Image = gen.GetShuffledPalette();

			//lbColours.Items.Clear();
			//lbColours.Items.AddRange(gen.ShuffledColours
			//	.Select(c => c.ToString())
			//	.ToArray());
		}

		private void btnPaint_Click(object sender, EventArgs e)
		{
			gen.ClearSeenPoints();
			gen.Paint();
			pbFinalImage.Image = gen.GetCurrentImage();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			gen.Save();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			gen.UseMin = !gen.UseMin;
		}
	}
}
