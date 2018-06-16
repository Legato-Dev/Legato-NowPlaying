using Legato.Interop.AimpRemote.Entities;
using LegatoNowPlaying.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
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

		#region Event Handlers

		/// <summary>
		/// SettingWindow が読み込まれる際に動作します。
		/// </summary>
		private void SettingWindow_Load(object sender, EventArgs e)
		{
			Icon = Properties.Resources.legato;

			textBoxPostingFormat.Text = SettingSource.PostingFormat;
			textBoxPostSoundPath.Text = SettingSource.PostingSound;
			textBoxExitSoundPath.Text = SettingSource.ExitingSound;

			// render version
			var assembly = Assembly.GetExecutingAssembly();
			var v = assembly.GetName().Version;
			versionLabel.Text = $"Version: {v.Major}.{v.Minor}.{v.Revision}";

			// add services list
			foreach(var service in this.Accounts.Services)
			{
				var item = new ListViewItem(new[] { service.Name, "" });
				servicesListView.Items.Add(item);
				UpdateListViewItem(item, service);
			}

			this.renderPreview();
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

		private void textBoxPostingFormat_TextChanged(object sender, EventArgs e)
		{
			this.renderPreview();
		}

		private void licenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/Legato-Dev/Legato-NowPlaying/blob/22d7312e4b24645e92d1facbee23350f499ad7bf/LICENSE.md");
		}

		#endregion Event Handlers

		#region Methods

		private void renderPreview()
		{
			var track = new TrackInfo();
			track.Album = "Colory Starry";
			track.Artist = "ななひら";
			track.Title = "ほしにねがいを";
			track.TrackNumber = 10;
			track.Year = "2015";
			track.Genre = "Electronic";

			this.previewLabel.Text = Common.ComposeText(textBoxPostingFormat.Text, track);
		}

		#endregion Methods

		private void UpdateListViewItem(ListViewItem item, Service service)
		{
			item.SubItems[0].Text = service.Name;
			item.SubItems[1].Text = service.IsInstalled ? (service.Enabled ? "Enabled" : "Disabled") : "Not Connected";
		}

		private async void button4_Click(object sender, EventArgs e)
		{
			if (servicesListView.SelectedItems.Count != 1) return;

			var listViewItem = servicesListView.SelectedItems[0];
			var serviceName = listViewItem.SubItems[0].Text;
			var service = Accounts.Services.Find(i => i.Name == serviceName);
			if (service == null) return;

			await service.Install();

			UpdateListViewItem(listViewItem, service);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (servicesListView.SelectedItems.Count != 1) return;

			var listViewItem = servicesListView.SelectedItems[0];
			var serviceName = listViewItem.SubItems[0].Text;
			var service = Accounts.Services.Find(i => i.Name == serviceName);
			if (service == null) return;

			service.ToggleEnable();
			UpdateListViewItem(listViewItem, service);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (servicesListView.SelectedItems.Count != 1) return;

			var serviceName = servicesListView.SelectedItems[0].SubItems[0].Text;
			var service = Accounts.Services.Find(i => i.Name == serviceName);
			if (service == null) return;

			service.Setting();
		}

		private void servicesListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(servicesListView.SelectedItems.Count != 1)
			{
				button4.Enabled = false;
				button5.Enabled = false;
				button6.Enabled = false;
				return;
			}

			var serviceName = servicesListView.SelectedItems[0].SubItems[0].Text;
			var service = Accounts.Services.Find(i => i.Name == serviceName);
			if (service == null) return;

			button4.Enabled = true;
			button5.Enabled = true;
			button6.Enabled = service.HasSetting;
		}
	}
}
