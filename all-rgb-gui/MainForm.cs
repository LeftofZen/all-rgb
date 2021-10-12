using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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
				});
			}
		}

		private void btnGenerateColours_Click(object sender, EventArgs e)
		{
			gen.CreateBuffer(int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
			pbPalette.Image = gen.GetImageFromColours(gen.GenerateColours().ToList(), pbPalette.Width, pbPalette.Height);
		}

		private void btnShuffleColours_Click(object sender, EventArgs e)
		{
			pbPaletteShuffled.Image = gen.GetImageFromColours(gen.ShuffleColours(), pbPaletteShuffled.Width, pbPaletteShuffled.Height);
		}

		private void btnPaint_Click(object sender, EventArgs e)
		{
			gen.Paint();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			gen.Save();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			gen.UseMin = !gen.UseMin;
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			gen.Pause = !gen.Pause;
			btnPause.Text = gen.Pause ? "Resume" : "Pause";
		}

		private void btnOpenDir_Click(object sender, EventArgs e)
		{
			Process.Start("explorer.exe", ImageBuffer.BaseFileName);
		}

		private void btnLoadTemplate_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
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
		}
	}
}
