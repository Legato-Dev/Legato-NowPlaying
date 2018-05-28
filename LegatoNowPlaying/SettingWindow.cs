using System;
using System.IO;
using System.Windows.Forms;

namespace LegatoNowPlaying
{
	public partial class SettingWindow : Form
	{

		#region Constractors

		/// <summary>
		/// SettingWindow コンストラクタ
		/// </summary>
		public SettingWindow(SettingJsonFile settingSource)
		{
			InitializeComponent();

			SettingSource = settingSource;
		}

		#endregion Constractors

		#region Properties

		private OpenFileDialog _OpenFileDialog { get; set; } = new OpenFileDialog();

		public SettingJsonFile SettingSource { get; set; }

		#endregion Properties

		#region Event Hndlers

		/// <summary>
		/// SettingWindow が読み込まれる際に動作します。
		/// </summary>
		private void SettingWindow_Load(object sender, EventArgs e)
		{
			textBoxPostingFormat.Text = SettingSource.PostingFormat;
			PostVoicePath.Text = SettingSource.PostingSound;
			ExitVoicePath.Text = SettingSource.ExitingSound;
		}

		/// <summary>
		/// 設定完了時に押下するボタン設定です。
		/// </summary>
		private void buttonOk_Click(object sender, EventArgs e)
		{
			// 結果に反映
			SettingSource.PostingFormat = textBoxPostingFormat.Text;
			SettingSource.NotifyTime = TimeSpan.FromSeconds((double)UpDownNotifyTime.Value);
			SettingSource.PostingSound = PostVoicePath.Text;
			SettingSource.ExitingSound = ExitVoicePath.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// 投稿時にお知らせを行うボイスファイルを決定します。
		/// </summary>
		private void PostVoiceSetting_Click(object sender, EventArgs e)
		{
			if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				string str = _OpenFileDialog.FileName;
				PostVoicePath.Text = Path.GetDirectoryName(str) + @"\" + Path.GetFileName(str);
			}
		}

		/// <summary>
		/// Lagato-NowPlaying 終了時に再生するボイスファイルを決定します。
		/// </summary>
		private void ExitVoiceSetting_Click(object sender, EventArgs e)
		{
			if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				string str = _OpenFileDialog.FileName;
				ExitVoicePath.Text = Path.GetDirectoryName(str) + @"\" + Path.GetFileName(str);
			}
		}

		#endregion Event Hndlers

	}
}
