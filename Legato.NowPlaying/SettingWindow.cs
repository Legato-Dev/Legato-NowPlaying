using System;
using System.IO;
using System.Windows.Forms;

namespace Legato.NowPlaying
{
	public partial class SettingWindow : Form
	{
		public string PostingFormat { get; set; }
		public TimeSpan notifyTime { get; private set; }
		public string PostingSound { get; set; }

		public SettingWindow(string postingFormat, string postingSound)
		{
			InitializeComponent();

			PostingFormat = postingFormat;
			PostingSound = postingSound;
		}

		private void SettingWindow_Load(object sender, EventArgs e)
		{
			textBoxPostingFormat.Text = PostingFormat;
			VoicePath.Text = PostingSound;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			PostingFormat = textBoxPostingFormat.Text;
			notifyTime = TimeSpan.FromSeconds((double)UpDownNotifyTime.Value);
			PostingSound = VoicePath.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void VoiceSetting_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string str = openFileDialog.FileName;
				VoicePath.Text = Path.GetDirectoryName(str) + @"\" + Path.GetFileName(str);
			}
		}
	}
}
