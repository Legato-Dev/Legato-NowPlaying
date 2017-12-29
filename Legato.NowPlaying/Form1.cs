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

namespace Legato.NowPlaying {
	public partial class Form1 : Form {
		#region Constractor

		public Form1() {
			InitializeComponent();
		}

		#endregion

		#region Constants

		private static readonly string _DefaultPostingFormat = "{TrackNum}. {Title}\r\nArtist: {Artist}\r\nAlbum: {Album}\r\n#nowplaying";
		private static readonly string _DefaultPostingVoice = "please your hope voice file.";
		private static readonly string _DefaultExitingVoice = "please your hope voice file.";
		private static readonly string _DefaultTokensKey = "please your tokens";

		private bool _IsClosed;

		#endregion Constants

		#region Properties

		private AimpProperties _AimpProperties { get; set; } = new AimpProperties();
		private AimpCommands _AimpCommands { get; set; } = new AimpCommands();
		private AimpObserver _AimpObserver { get; set; } = new AimpObserver();

		private Tokens _Twitter { get; set; }
		private TimeSpan _NotifyTime { get; set; }

		private string _PostingFormat { get; set; }
		private string _PostingSound { get; set; }
		private string _ExitingSound { get; set; }

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
				var stringBuilder = new StringBuilder(_PostingFormat);
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
			catch (FileNotFoundException ex) {
				sound?.Close();

				MessageBox.Show(
					$"mp3 再生エラーが発生しました。\r\nファイルが見つかりません: {filePath}",
					"mp3 再生エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return null;
			}
			catch (ApplicationException ex) {
				sound?.Close();

				MessageBox.Show(
					$"mp3 再生エラーが発生しました。\r\n{ex.StackTrace}",
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
		/// settings.json から設定を読み込みます
		/// <para>settings.json が存在しないときは新規に生成します</para>
		/// </summary>
		private async Task _LoadSettingsAsync() {
			try {
				string jsonString = null;
				using (var reader = new StreamReader("settings.json", Encoding.UTF8))
					jsonString = await reader.ReadToEndAsync();

				dynamic json = JsonConvert.DeserializeObject(jsonString);

				_PostingFormat = json.format ?? _DefaultPostingFormat;
				_PostingSound = json.postsound ?? _DefaultPostingVoice;
				_ExitingSound = json.exitsound ?? _DefaultExitingVoice;
			}
			catch {
				_PostingFormat = _DefaultPostingFormat;
				_PostingSound = _DefaultPostingVoice;
				_ExitingSound = _DefaultExitingVoice;
				await _SaveSettingsAsync();
			}
		}

		/// <summary>
		/// settings.json に設定を保存します
		/// </summary>
		private async Task _SaveSettingsAsync() {
			// 設定ファイルに保存すべき情報がある場合
			if (_PostingFormat != null) {
				var data = new { format = _PostingFormat, postsound = _PostingSound, exitsound = _ExitingSound };

				var jsonString = JsonConvert.SerializeObject(data, new JsonSerializerSettings {
					StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
				});

				using (var writer = new StreamWriter("settings.json", false, Encoding.UTF8))
					await writer.WriteAsync(jsonString);
			}
		}

		/// <summary>
		/// tokens.json からアカウント情報を読み込みます
		/// </summary>
		private async Task _LoadTokensFileAsync() {
			try {
				string jsonString = null;
				using (var reader = new StreamReader("tokens.json", Encoding.UTF8))
					jsonString = await reader.ReadToEndAsync();

				dynamic json = JsonConvert.DeserializeObject(jsonString);

				var ck = (string)json.ConsumerKey;
				var cs = (string)json.ConsumerSecret;
				var at = (string)json.AccessToken;
				var ats = (string)json.AccessTokenSecret;

				var isNotDefaultTokens = ck != _DefaultTokensKey && cs != _DefaultTokensKey && at != _DefaultTokensKey && ats != _DefaultTokensKey;
				if (isNotDefaultTokens) {
					var tokens = Tokens.Create(ck, cs, at, ats);

					// トークンの有効性を検証
					try {
						var account = await tokens.Account.VerifyCredentialsAsync(include_entities: false, skip_status: true);
						_Twitter = tokens;
					}
					catch { }
				}
			}
			catch {
				// JSONの構造が間違っている、もしくは存在しなかった場合
				await _CreateTokensFileAsync();
			}
		}

		/// <summary>
		/// tokens.json を生成します
		/// </summary>
		private async Task _CreateTokensFileAsync() {
			var data = new {
				ConsumerKey = _DefaultTokensKey,
				ConsumerSecret = _DefaultTokensKey,
				AccessToken = _DefaultTokensKey,
				AccessTokenSecret = _DefaultTokensKey
			};

			var jsonString = JsonConvert.SerializeObject(data, new JsonSerializerSettings {
				StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
			});

			using (var writer = new StreamWriter("tokens.json", false, Encoding.UTF8))
				await writer.WriteAsync(jsonString);
		}

		#endregion File IO Methods

		#endregion Methods

		#region Procedures

		private async void Form1_Load(object sender, EventArgs e) {
			Icon = Properties.Resources.legato;
			_NotifyTime = new TimeSpan(0, 0, 1);
			_IsClosed = false;

			await _LoadTokensFileAsync();

			if (_Twitter == null) {
				MessageBox.Show(
					"有効なTwitterのトークン情報の設定が必要です。tokens.jsonの中身を編集してからアプリケーションを再実行してください。",
					"情報",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				Close();
				return;
			}

			await _LoadSettingsAsync();

			_AimpObserver.CurrentTrackChanged += async (track) => {
				_UpdateFormTrackInfo(track);
				_UpdateAlbumArt();

				// auto posting
				if (checkBoxAutoPosting.Checked) {
					var voice = await _PlayVoiceAsync(_PostingSound);
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
			_IsClosed = true;
			var voice = await _PlayVoiceAsync(_ExitingSound);

			_AimpObserver.Dispose();
			await _StopVoiceAsync(voice);
		}

		private async void buttonPostNowPlaying_Click(object sender, EventArgs e) {
			var voice = await _PlayVoiceAsync(_PostingSound);
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
			var settingWindow = new SettingWindow(_PostingFormat, _PostingSound, _ExitingSound);

			if (settingWindow.ShowDialog() == DialogResult.OK) {
				_PostingFormat = settingWindow.PostingFormat;
				_NotifyTime = settingWindow.notifyTime;
				_PostingSound = settingWindow.PostingSound;
				_ExitingSound = settingWindow.ExitingSound;
				await _SaveSettingsAsync();
			}
		}

		#endregion Procedures
	}
}
