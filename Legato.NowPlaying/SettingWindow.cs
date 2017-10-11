using System;
using System.IO;
using System.Windows.Forms;

namespace Legato.NowPlaying
{
	public partial class SettingWindow : Form
	{
		#region Properties

		public string PostingFormat { get; set; }
		public TimeSpan notifyTime { get; private set; }
		public string PostingSound { get; set; }
		public string ExitingSound { get; set; }

		#endregion

		#region Constractor

		/// <summary>
		/// SettingWindow コンストラクタ
		/// </summary>
		public SettingWindow(string postingFormat, string postingSound, string exitingSound)
		{
			InitializeComponent();

			PostingFormat = postingFormat;
			PostingSound = postingSound;
			ExitingSound = exitingSound;
		}

		#endregion

		#region Settings

		/// <summary>
		/// SettingWindow が読み込まれる際に動作します。
		/// </summary>
		private void SettingWindow_Load(object sender, EventArgs e)
		{
			textBoxPostingFormat.Text = PostingFormat;
			PostVoicePath.Text = PostingSound;
			ExitVoicePath.Text = ExitingSound;
		}

		/// <summary>
		/// 設定完了時に押下するボタン設定です。
		/// </summary>
		private void buttonOk_Click(object sender, EventArgs e)
		{
			PostingFormat = textBoxPostingFormat.Text;
			notifyTime = TimeSpan.FromSeconds((double)UpDownNotifyTime.Value);
			PostingSound = PostVoicePath.Text;
			ExitingSound = ExitVoicePath.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// 投稿時にお知らせを行うボイスファイルを決定します。
		/// </summary>
		private void PostVoiceSetting_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string str = openFileDialog.FileName;
				PostVoicePath.Text = Path.GetDirectoryName(str) + @"\" + Path.GetFileName(str);
			}
		}

		/// <summary>
		/// Lagato-NowPlaying 終了時に再生するボイスファイルを決定します。
		/// </summary>
		private void ExitVoiceSetting_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string str = openFileDialog.FileName;
				ExitVoicePath.Text = Path.GetDirectoryName(str) + @"\" + Path.GetFileName(str);
			}
		}
		#endregion
	}
}
