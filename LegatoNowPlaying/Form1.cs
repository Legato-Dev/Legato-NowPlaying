using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CoreTweet;
using Newtonsoft.Json;
using Legato.Interop.AimpRemote.Entities;
using AlbumArtExtraction;
using System.Drawing;
using Legato;

namespace LegatoNowPlaying {
	public partial class Form1 : Form {
		#region Constractor

		public Form1() {
			InitializeComponent();
		}

		#endregion

		#region Constants

		private bool _IsClosed;

		#endregion Constants

		#region Properties

		private AimpProperties _AimpProperties { get; set; } = new AimpProperties();
		private AimpCommands _AimpCommands { get; set; } = new AimpCommands();
		private AimpObserver _AimpObserver { get; set; } = new AimpObserver();

		private SettingJsonObject _Setting { get; set; }
		private CredentialsJsonObject _Credentials { get; set; }
		private Tokens _Twitter { get; set; }
		private TimeSpan _NotifyTime { get; set; }

		#endregion Properties

		#region Methods

		private Image _GetAlbumArt() {
			try {
				var trackFilePath = _AimpProperties.CurrentTrack.FilePath;
				var selector = new Selector();
				var extractor = selector.SelectAlbumArtExtractor(trackFilePath);
				return extractor.Extract(trackFilePath);
			}
			catch (Exception ex) {
				Console.WriteLine("album art extraction error:");
				Console.WriteLine(ex);
				return null;
			}
		}

		private async Task _PostAsync() {
			try {
				var track = _AimpProperties.CurrentTrack;

				// 投稿内容を構築
				var stringBuilder = new StringBuilder(_Setting.PostingFormat);
				stringBuilder = stringBuilder.Replace("{Title}", "{0}");
				stringBuilder = stringBuilder.Replace("{Artist}", "{1}");
				stringBuilder = stringBuilder.Replace("{Album}", "{2}");
				stringBuilder = stringBuilder.Replace("{TrackNum}", "{3:D2}");
				var text = string.Format(stringBuilder.ToString(), track.Title, track.Artist, track.Album, track.TrackNumber);

				var albumArt = _GetAlbumArt();

				if (checkBoxNeedAlbumArt.Checked && albumArt != null) {
					using (var memory = new MemoryStream())
						albumArt.Save("temp.png", ImageFormat.Png);

					await _Twitter.Statuses.UpdateWithMediaAsync(text, new FileInfo("temp.png"));
				}
				else
					await _Twitter.Statuses.UpdateAsync(text);

				Console.WriteLine("Twitter への投稿が完了しました");
			}
			catch (Exception ex) {
				Console.Error.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 非同期でボイスファイルを再生します。
		/// </summary>
		private async Task<SoundService> _PlayVoiceAsync(string filePath) {
			SoundService sound = null;
			try {
				// ファイルを開く
				sound = SoundService.Open(filePath);

				// Legato-NowPlaying が終了される時
				if (_IsClosed) {
					_IsClosed = false;

					// 終了メッセージ、ボイスを再生 (ボイスが指定されない場合は、例外発生)
					sound.Play();
					new LegatoMessageBox("Legato-NowPlaying を終了します。", "れがーとなうぷれしゅーりょー", 1500);
				}
				else {
					// ボイスを再生
					sound.Play();
				}
				await Task.Delay(1000);
				return sound;
			}
			catch (FileNotFoundException) {
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
		/// 非同期でボイスファイルを停止します。
		/// </summary>
		private async Task _StopVoiceAsync(SoundService sound) {
			// Voice を停止する
			sound?.Stop();

			// 閉じる
			sound?.Close();

			await Task.Delay(100);
		}

		/// <summary>
		/// フォームに表示されているアルバムアートを更新します
		/// </summary>
		private void _UpdateAlbumArt() {
			if (_AimpProperties.IsRunning) {
				var albumArt = _GetAlbumArt();
				pictureBoxAlbumArt.Image = albumArt ?? Properties.Resources.logo;
			}
			else {
				pictureBoxAlbumArt.Image = Properties.Resources.logo;
			}
		}

		private void _UpdateFormTrackInfo(TrackInfo track) {
			labelTrackNumber.Text = $"{track.TrackNumber:D2}.";
			labelTitle.Text = track.Title;
			labelArtist.Text = track.Artist;
			labelAlbum.Text = track.Album;

			var os = Environment.OSVersion;
			notifyIcon.Icon = Properties.Resources.legato;

			// トースト通知
			if (os.Version.Major >= 6 && os.Version.Minor >= 2) {
				notifyIcon.BalloonTipTitle = $"Legato NowPlaying\r\n{track.Title} - {track.Artist}";
				notifyIcon.BalloonTipText = $"Album : {track.Album}";
				Debug.WriteLine("トースト通知が表示されました。");
			}
			// バルーン通知
			else {
				notifyIcon.BalloonTipTitle = $"Legato NowPlaying";
				notifyIcon.BalloonTipText = $"{track.Title} - {track.Artist}\r\nAlbum : {track.Album}";
				Debug.WriteLine("バルーン通知が表示されました。");
			}
			notifyIcon.ShowBalloonTip((int)_NotifyTime.TotalMilliseconds);
		}

		#region File IO Methods

		/// <summary>
		/// tokens.json からアカウント情報を読み込み、その有効性を検証します
		/// </summary>
		private async Task<Tokens> _LoadAndVerifyCredentialsAsync() {
			var data = await CredentialsJsonObject.LoadAsync();
			var ck = data.ConsumerKey;
			var cs = data.ConsumerSecret;
			var at = data.AccessToken;
			var ats = data.AccessTokenSecret;

			var defaultTokensKey = "";

			var isNotDefaultTokens = ck != defaultTokensKey && cs != defaultTokensKey && at != defaultTokensKey && ats != defaultTokensKey;
			if (isNotDefaultTokens) {
				var tokens = Tokens.Create(ck, cs, at, ats);

				// トークンの有効性を検証
				try {
					var account = await tokens.Account.VerifyCredentialsAsync(include_entities: false, skip_status: true);
					return tokens;
				}
				catch { }
			}
			return null;
		}

		#endregion File IO Methods

		#endregion Methods

		#region Procedures

		private async void Form1_Load(object sender, EventArgs e) {
			Icon = Properties.Resources.legato;
			_NotifyTime = new TimeSpan(0, 0, 1);
			_IsClosed = false;

			_Twitter = await _LoadAndVerifyCredentialsAsync();

			if (_Twitter == null) {
				MessageBox.Show(
					"有効なTwitterのトークン情報の設定が必要です。tokens.jsonの中身を編集してからアプリケーションを再実行してください。",
					"情報",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				Close();
				return;
			}

			_Setting = await SettingJsonObject.LoadAsync();

			_AimpObserver.CurrentTrackChanged += async (track) => {
				_UpdateFormTrackInfo(track);
				_UpdateAlbumArt();

				// auto posting
				if (checkBoxAutoPosting.Checked) {
					var voice = await _PlayVoiceAsync(_Setting.PostingSound);
					await _PostAsync();
					await _StopVoiceAsync(voice);
				}
			};

			if (_AimpProperties.IsRunning) {
				_UpdateFormTrackInfo(_AimpProperties.CurrentTrack);
				_UpdateAlbumArt();
			}
		}

		private async void Form1_FormClosed(object sender, FormClosedEventArgs e) {

			SoundService voice = null;
			if (_Setting != null) {
				_IsClosed = true;
				voice = await _PlayVoiceAsync(_Setting.ExitingSound);
			}

			_AimpObserver.Dispose();

			if (_Setting != null) {
				await _StopVoiceAsync(voice);
			}
		}

		private async void buttonPostNowPlaying_Click(object sender, EventArgs e) {
			var voice = await _PlayVoiceAsync(_Setting.PostingSound);
			await _PostAsync();
			await _StopVoiceAsync(voice);
		}

		private void pictureBoxAlbumArt_Click(object sender, EventArgs e) {
			var albumArt = _GetAlbumArt();

			if (albumArt != null) {
				albumArt.Save("temp.png", ImageFormat.Png);
				Process.Start("temp.png");
			}
		}

		private void checkBoxAutoPosting_CheckedChanged(object sender, EventArgs e) {
			buttonPostNowPlaying.Enabled = !checkBoxAutoPosting.Checked;
		}

		private async void buttonShowSettingWindow_Click(object sender, EventArgs e) {
			var settingWindow = new SettingWindow(_Setting.PostingFormat, _Setting.PostingSound, _Setting.ExitingSound);

			if (settingWindow.ShowDialog() == DialogResult.OK) {
				_Setting.PostingFormat = settingWindow.PostingFormat;
				_Setting.PostingSound = settingWindow.PostingSound;
				_Setting.ExitingSound = settingWindow.ExitingSound;
				_NotifyTime = settingWindow.notifyTime; // TODO: 多分、設定ファイルへの項目追加忘れ
				await _Setting.SaveAsync();
			}
		}

		#endregion Procedures
	}
}
