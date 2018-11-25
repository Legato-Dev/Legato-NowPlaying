using AlbumArtExtraction;
using Legato;
using Legato.Interop.AimpRemote.Entities;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegatoNowPlaying
{
	public partial class MainForm : Form
	{
		#region Constractors

		public MainForm()
		{
			InitializeComponent();
		}

		#endregion Constractors

		#region Properties

		private AimpProperties _AimpProperties { get; set; } = new AimpProperties();

		private AimpCommands _AimpCommands { get; set; } = new AimpCommands();

		private AimpObserver _AimpObserver { get; set; } = new AimpObserver();

		private SettingJsonFile _Setting { get; set; }

		private Accounts Accounts;

		#endregion Properties

		#region Methods

		private Image _GetAlbumArt()
		{
			try
			{
				var trackFilePath = _AimpProperties.CurrentTrack.FilePath;
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
			var track = _AimpProperties.CurrentTrack;

			var text = Common.ComposeText(_Setting.PostingFormat, track);

			var albumArt = _GetAlbumArt();

			await Accounts.Post(text, checkBoxNeedAlbumArt.Checked ? albumArt : null);
		}

		/// <summary>
		/// 非同期で音声ファイルを再生します。
		/// </summary>
		private async Task<SoundService> _PlaySoundAsync(string filePath, bool isClosing)
		{
			SoundService sound = null;

			if (filePath == null)
				return null;

			try
			{
				// ファイルを開く
				sound = SoundService.Open(filePath);

				// 音声を再生 (音声が指定されない場合は、例外発生)
				sound.Play();

				// Legato-NowPlaying が終了される時
				if (isClosing)
				{
					// 終了メッセージ
					new LegatoMessageBox("Legato-NowPlaying を終了します。", "れがーとなうぷれしゅーりょー", 1500);
				}

				await Task.Delay(1000);
				return sound;
			}
			catch (FileNotFoundException)
			{
				sound?.Close();

				MessageBox.Show(
					$"mp3 再生エラーが発生しました。\r\nファイルが見つかりません: {filePath}",
					"mp3 再生エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>
		/// 非同期で音声ファイルを停止します。
		/// </summary>
		private async Task _StopSoundAsync(SoundService sound)
		{
			if (sound == null)
				return;

			// Sound を停止する
			sound.Stop();

			// 閉じる
			sound.Close();

			await Task.Delay(100);
		}

		/// <summary>
		/// フォームに表示されているアルバムアートを更新します
		/// </summary>
		private void _UpdateAlbumArt()
		{
			if (_AimpProperties.IsRunning)
			{
				var albumArt = _GetAlbumArt();
				pictureBoxAlbumArt.Image = albumArt ?? Properties.Resources.logo;
			}
			else
			{
				pictureBoxAlbumArt.Image = Properties.Resources.logo;
			}
		}

		private void _UpdateFormTrackInfo(TrackInfo track)
		{
			labelTrackNumber.Text = $"{track.TrackNumber:D2}.";
			labelTitle.Text = track.Title;
			labelArtist.Text = track.Artist;
			labelAlbum.Text = track.Album;

			var os = Environment.OSVersion;
			notifyIcon.Icon = Properties.Resources.legato;

			// トースト通知
			if (os.Version.Major >= 6 && os.Version.Minor >= 2)
			{
				notifyIcon.BalloonTipTitle = $"Legato NowPlaying\r\n{track.Title} - {track.Artist}";
				notifyIcon.BalloonTipText = $"Album : {track.Album}";
				Debug.WriteLine("トースト通知が表示されました。");
			}
			// バルーン通知
			else
			{
				notifyIcon.BalloonTipTitle = $"Legato NowPlaying";
				notifyIcon.BalloonTipText = $"{track.Title} - {track.Artist}\r\nAlbum : {track.Album}";
				Debug.WriteLine("バルーン通知が表示されました。");
			}
			notifyIcon.ShowBalloonTip((int)_Setting.NotifyTime.Value.TotalMilliseconds);
		}

		#endregion Methods

		#region Event Handlers

		private async void MainForm_Load(object sender, EventArgs e)
		{
			Icon = Properties.Resources.legato;

			_Setting = await SettingJsonFile.LoadAsync();

			_AimpObserver.CurrentTrackChanged += async (track) =>
			{
				_UpdateFormTrackInfo(track);
				_UpdateAlbumArt();

				// auto posting
				if (checkBoxAutoPosting.Checked)
				{
					var sound = await _PlaySoundAsync(_Setting.PostingSound, false);
					await _PostAsync();
					await _StopSoundAsync(sound);
				}
			};

			if (_AimpProperties.IsRunning)
			{
				_UpdateFormTrackInfo(_AimpProperties.CurrentTrack);
				_UpdateAlbumArt();
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
						_UpdateFormTrackInfo(_AimpProperties.CurrentTrack);
						_UpdateAlbumArt();
						break;

					// バッテリーや電源に関する通知があった場合
					case PowerModes.StatusChange:
						break;
				}
			};

			this.Accounts = new Accounts();
			this.Accounts.Init();

			this.TopMost = _Setting.TopMost != null ? (bool)_Setting.TopMost : false;
		}

		private async void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{

			SoundService sound = null;
			if (_Setting != null)
			{
				sound = await _PlaySoundAsync(_Setting.ExitingSound, true);
			}

			_AimpObserver.Dispose();

			if (_Setting != null)
			{
				await _StopSoundAsync(sound);
			}
		}

		private async void buttonPostNowPlaying_Click(object sender, EventArgs e)
		{
			var sound = await _PlaySoundAsync(_Setting.PostingSound, false);
			await _PostAsync();
			await _StopSoundAsync(sound);
		}

		private void pictureBoxAlbumArt_Click(object sender, EventArgs e)
		{
			var albumArt = _GetAlbumArt();

			if (albumArt != null)
			{
				albumArt.Save("temp.png", ImageFormat.Png);
				Process.Start("temp.png");
			}
		}

		private void checkBoxAutoPosting_CheckedChanged(object sender, EventArgs e)
		{
			buttonPostNowPlaying.Enabled = !checkBoxAutoPosting.Checked;
		}

		private async void buttonShowSettingWindow_Click(object sender, EventArgs e)
		{
			var settingWindow = new SettingWindow(_Setting, this.Accounts);

			if (settingWindow.ShowDialog() == DialogResult.OK)
			{
				await _Setting.SaveAsync();

				this.TopMost = _Setting.TopMost != null ? (bool)_Setting.TopMost : false;
			}
		}

		#endregion Event Handlers
	}
}
