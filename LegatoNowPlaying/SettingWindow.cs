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
		public SettingWindow(SettingJsonFile settingSource, Accounts accounts)
		{
			InitializeComponent();

			SettingSource = settingSource;
			this.Accounts = accounts;
		}

		#endregion Constractors

		#region Properties

		private OpenFileDialog _OpenFileDialog { get; set; } = new OpenFileDialog();

		public SettingJsonFile SettingSource { get; set; }

		private Accounts Accounts;

		#endregion Properties

		#region Event Hndlers

		/// <summary>
		/// SettingWindow が読み込まれる際に動作します。
		/// </summary>
		private void SettingWindow_Load(object sender, EventArgs e)
		{
			Icon = Properties.Resources.legato;

			textBoxPostingFormat.Text = SettingSource.PostingFormat;
			textBoxPostSoundPath.Text = SettingSource.PostingSound;
			textBoxExitSoundPath.Text = SettingSource.ExitingSound;
		}

		/// <summary>
		/// 設定完了時に押下するボタン設定です。
		/// </summary>
		private void buttonOk_Click(object sender, EventArgs e)
		{
			// 結果に反映
			SettingSource.PostingFormat = textBoxPostingFormat.Text;
			SettingSource.NotifyTime = TimeSpan.FromSeconds((double)UpDownNotifyTime.Value);
			SettingSource.PostingSound = textBoxPostSoundPath.Text;
			SettingSource.ExitingSound = textBoxExitSoundPath.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// 投稿時にお知らせを行う音声ファイルを決定します。
		/// </summary>
		private void buttonOpenPostSound_Click(object sender, EventArgs e)
		{
			if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				string str = _OpenFileDialog.FileName;
				textBoxPostSoundPath.Text = Path.GetDirectoryName(str) + @"\" + Path.GetFileName(str);
			}
		}

		/// <summary>
		/// アプリケーション終了時に再生する音声ファイルを選択します。
		/// </summary>
		private void buttonOpenExitSound_Click(object sender, EventArgs e)
		{
			if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				string str = _OpenFileDialog.FileName;
				textBoxExitSoundPath.Text = Path.GetDirectoryName(str) + @"\" + Path.GetFileName(str);
			}
		}

		#endregion Event Hndlers

		private void button1_Click(object sender, EventArgs e)
		{
			Services.Twitter.Service.Install(this.Accounts);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Services.Misskey.Service.Install(this.Accounts);
		}
	}
}
