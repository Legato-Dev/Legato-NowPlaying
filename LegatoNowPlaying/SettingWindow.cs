using Legato.Interop.AimpRemote.Entities;
using LegatoNowPlaying.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace LegatoNowPlaying
{
	public partial class SettingWindow : Form
	{
		#region Constructor

		public SettingWindow(SettingJsonFile settingSource, Accounts accounts)
		{
			this.InitializeComponent();

			this.SettingSource = settingSource;
			this._Accounts = accounts;
		}

		#endregion Constructor

		#region Properties

		public SettingJsonFile SettingSource { get; set; }

		private Accounts _Accounts { get; set; }

		#endregion Properties

		#region Event Handlers

		private void SettingWindow_Load(object sender, EventArgs e)
		{
			this.Icon = Properties.Resources.legato;
			this.textBoxPostingFormat.Text = this.SettingSource.PostingFormat;

			// render version
			var assembly = Assembly.GetExecutingAssembly();
			var v = assembly.GetName().Version;
			this.versionLabel.Text = $"Version: {v.Major}.{v.Minor}.{v.Revision}";

			// add services list
			foreach (var service in this._Accounts.Services)
			{
				var item = new ListViewItem(new[] { service.Name, "", "" });
				item.UseItemStyleForSubItems = false;
				item.SubItems[0].Font = new Font(this.servicesListView.Font, FontStyle.Bold);
				item.SubItems[2].ForeColor = Color.Navy;
				this.servicesListView.Items.Add(item);
				this._UpdateListViewItem(item, service);
			}

			try
			{
				this.previewLabel.Text = this._RenderPreview();
			}
			catch
			{
				this.previewLabel.Text = "(！)投稿フォーマットが無効です";
			}
		}

		/// <summary>
		/// 設定完了時に押下されるボタン設定
		/// </summary>
		private void buttonOk_Click(object sender, EventArgs e)
		{
			// 結果に反映
			this.SettingSource.PostingFormat = this.textBoxPostingFormat.Text;
			this.SettingSource.NotifyTime = TimeSpan.FromSeconds((double)this.UpDownNotifyTime.Value);
			this.SettingSource.TopMost = this.checkBox1.Checked;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private async void button4_Click(object sender, EventArgs e)
		{
			if (this.servicesListView.SelectedItems.Count != 1) return;

			var listViewItem = this.servicesListView.SelectedItems[0];
			var serviceName = listViewItem.SubItems[0].Text;
			var service = this._Accounts.Services.Find(i => i.Name == serviceName);
			if (service == null) return;

			await service.Install();

			this._UpdateListViewItem(listViewItem, service);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (this.servicesListView.SelectedItems.Count != 1) return;

			var listViewItem = this.servicesListView.SelectedItems[0];
			var serviceName = listViewItem.SubItems[0].Text;
			var service = this._Accounts.Services.Find(i => i.Name == serviceName);
			if (service == null) return;

			service.ToggleEnable();
			this._UpdateListViewItem(listViewItem, service);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (this.servicesListView.SelectedItems.Count != 1) return;

			var serviceName = this.servicesListView.SelectedItems[0].SubItems[0].Text;
			var service = this._Accounts.Services.Find(i => i.Name == serviceName);
			if (service == null) return;

			service.Setting();
		}

		private void servicesListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.servicesListView.SelectedItems.Count != 1)
			{
				this.button4.Enabled = false;
				this.button5.Enabled = false;
				this.button6.Enabled = false;
				return;
			}

			var serviceName = this.servicesListView.SelectedItems[0].SubItems[0].Text;
			var service = this._Accounts.Services.Find(i => i.Name == serviceName);
			if (service == null) return;

			this.button4.Enabled = true;
			this.button5.Enabled = true;
			this.button6.Enabled = service.HasSetting;
		}

		private void textBoxPostingFormat_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.previewLabel.Text = this._RenderPreview();
				this.buttonOk.Enabled = true;
			}
			catch
			{
				this.previewLabel.Text = "(！)投稿フォーマットが無効です";
				this.buttonOk.Enabled = false;
			}
		}

		private void licenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/Legato-Dev/Legato-NowPlaying/blob/22d7312e4b24645e92d1facbee23350f499ad7bf/LICENSE.md");
		}

		#endregion Event Handlers

		#region Private Methods

		private string _RenderPreview()
		{
			var track = new TrackInfo
			{
				Album = "Colory Starry",
				Artist = "ななひら",
				Title = "ほしにねがいを",
				TrackNumber = 10,
				Year = "2015",
				Genre = "Electronic"
			};

			return Common.ComposeText(this.textBoxPostingFormat.Text, track);
		}

		private void _UpdateListViewItem(ListViewItem item, Service service)
		{
			item.SubItems[0].Text = service.Name;
			item.SubItems[1].Text = service.IsInstalled ? (service.Enabled ? "Enabled" : "Disabled") : "Not Connected";
			item.SubItems[2].Text = service.IsInstalled ? (service.AccountName ?? "?") : "";
		}

		#endregion Private Methods

		#region Public Methods

		#endregion Public Methods
	}
}
