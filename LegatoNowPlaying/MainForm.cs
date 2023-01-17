using AlbumArtExtraction;
using Legato;
using Legato.Interop.AimpRemote.Entities;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegatoNowPlaying
{
	public partial class MainForm : Form
	{
		#region Constructor

		public MainForm()
		{
			this.InitializeComponent();
		}

		#endregion Constructor

		#region Properties

		private AimpProperties _AimpProperties { get; set; } = new AimpProperties();

		private AimpCommands _AimpCommands { get; set; } = new AimpCommands();

		private AimpObserver _AimpObserver { get; set; } = new AimpObserver();

		private Accounts _Accounts { get; set; } = new Accounts();

		private SettingJsonFile _Setting { get; set; }

		#endregion Properties

		#region Event Handlers

		private async void MainForm_Load(object sender, EventArgs e)
		{
			this.Icon = Properties.Resources.legato;

			this._Setting = await SettingJsonFile.LoadAsync();

			this._AimpObserver.CurrentTrackChanged += async (track) =>
			{
				this._UpdateFormTrackInfo(track);
				this._UpdateAlbumArt();

				// auto posting
				if (this.checkBoxAutoPosting.Checked)
				{
					await this._PostAsync();
				}
			};

			if (this._AimpProperties.IsRunning)
			{
				this._UpdateFormTrackInfo(this._AimpProperties.CurrentTrack);
				this._UpdateAlbumArt();
			}

			SystemEvents.PowerModeChanged += (s, ev) =>
			{
				switch (ev.Mode)
				{
					// スリープ直前
					case PowerModes.Suspend:
						break;

					// 復帰直後は曲情報を再取得
					case PowerModes.Resume:
						this._UpdateFormTrackInfo(this._AimpProperties.CurrentTrack);
						this._UpdateAlbumArt();
						break;

					// バッテリーや電源に関する通知があった場合
					case PowerModes.StatusChange:
						break;
				}
			};

			this._Accounts.Init();

			this.TopMost = this._Setting.TopMost != null ? (bool)this._Setting.TopMost : false;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this._AimpObserver.Dispose();
		}

		private async void buttonPostNowPlaying_Click(object sender, EventArgs e)
		{
			await this._PostAsync();
		}

		private void pictureBoxAlbumArt_Click(object sender, EventArgs e)
		{
			var albumArt = this._GetAlbumArt();

			if (albumArt != null)
			{
				albumArt.Save("temp.png", ImageFormat.Png);
				Process.Start("temp.png");
			}
		}

		private void checkBoxAutoPosting_CheckedChanged(object sender, EventArgs e)
		{
			this.buttonPostNowPlaying.Enabled = !this.checkBoxAutoPosting.Checked;
		}

		private async void buttonShowSettingWindow_Click(object sender, EventArgs e)
		{
			var settingWindow = new SettingWindow(_Setting, this._Accounts);

			if (settingWindow.ShowDialog() == DialogResult.OK)
			{
				await this._Setting.SaveAsync();

				this.TopMost = this._Setting.TopMost != null ? (bool)this._Setting.TopMost : false;
			}
		}

		#endregion Event Handlers

		#region Private Methods

		private Image _GetAlbumArt()
		{
			try
			{
				var trackFilePath = this._AimpProperties.CurrentTrack.FilePath;
				var selector = new Selector();
				var extractor = selector.SelectAlbumArtExtractor(trackFilePath);
				var source = extractor.Extract(trackFilePath);
				return new Bitmap(source);
			}
			catch (Exception ex)
			{
				Console.WriteLine("album art extraction error:");
				Console.WriteLine(ex);
				return null;
			}
		}

		private async Task _PostAsync()
		{
			var track = this._AimpProperties.CurrentTrack;

			var text = Common.ComposeText(this._Setting.PostingFormat, track);

			var albumArt = this._GetAlbumArt();



			await _Accounts.Post(text, this.checkBoxNeedAlbumArt.Checked ? albumArt : null);
		}

		/// <summary>
		/// フォームに表示されているアルバムアートを更新します
		/// </summary>
		private void _UpdateAlbumArt()
		{
			if (this._AimpProperties.IsRunning)
			{
				var albumArt = this._GetAlbumArt();
				this.pictureBoxAlbumArt.Image = albumArt ?? Properties.Resources.logo;
			}
			else
			{
				this.pictureBoxAlbumArt.Image = Properties.Resources.logo;
			}
		}

		private void _UpdateFormTrackInfo(TrackInfo track)
		{
			this.labelTrackNumber.Text = $"{track.TrackNumber:D2}.";

			// タイトルラベルのみ、ニーモニックキーの無効化を実施
			this.labelTitle.UseMnemonic = false;
			this.labelTitle.Text = track.Title;

			this.labelArtist.Text = track.Artist;
			this.labelAlbum.Text = track.Album;

			var os = Environment.OSVersion;
			this.notifyIcon.Icon = Properties.Resources.legato;

			// トースト通知
			if (os.Version.Major >= 6 && os.Version.Minor >= 2)
			{
				this.notifyIcon.BalloonTipTitle = $"Legato NowPlaying\r\n{track.Title} - {track.Artist}";
				this.notifyIcon.BalloonTipText = $"Album : {track.Album}";
				Debug.WriteLine("トースト通知が表示されました。");
			}
			// バルーン通知
			else
			{
				this.notifyIcon.BalloonTipTitle = $"Legato NowPlaying";
				this.notifyIcon.BalloonTipText = $"{track.Title} - {track.Artist}\r\nAlbum : {track.Album}";
				Debug.WriteLine("バルーン通知が表示されました。");
			}

			this.notifyIcon.ShowBalloonTip((int)this._Setting.NotifyTime.Value.TotalMilliseconds);
		}

		#endregion Private Methods

		#region Public Methods

		#endregion Public Methods
	}
}
