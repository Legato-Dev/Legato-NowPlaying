using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using CoreTweet;
using Newtonsoft.Json;
using Legato.Interop.AimpRemote.Entities;

namespace Legato.NowPlaying
{
	public partial class Form1 : Form
	{
		#region Constractor

		public Form1()
		{
			InitializeComponent();
		}

		#endregion

		#region Constants

		private static readonly string _DefaultPostingFormat = "{TrackNum}. {Title}\r\nArtist: {Artist}\r\nAlbum: {Album}\r\n#nowplaying";
		private static readonly string _DefaultPostingVoice = "please your hope voice file.";
		private static readonly string _DefaultTokensKey = "please your tokens";
		private static readonly string _AliasName = "MediaFile";

		#endregion Constants

		#region Properties

		private Legato _Legato { get; set; }
		private Tokens _Twitter { get; set; }
		private TimeSpan _NotifyTime { get; set; }
		private string _PostingFormat { get; set; }
		private string _PostingSound { get; set; }

		#endregion Properties

		#region externs

		[DllImport("winmm.dll")]
		private static extern int mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

		#endregion

		#region Methods

		private async Task _PostAsync()
		{
			try
			{
				var track = _Legato.CurrentTrack;

				// 投稿内容を構築
				var stringBuilder = new StringBuilder(_PostingFormat);
				stringBuilder = stringBuilder.Replace("{Title}", "{0}");
				stringBuilder = stringBuilder.Replace("{Artist}", "{1}");
				stringBuilder = stringBuilder.Replace("{Album}", "{2}");
				stringBuilder = stringBuilder.Replace("{TrackNum}", "{3:D2}");
				var text = string.Format(stringBuilder.ToString(), track.Title, track.Artist, track.Album, track.TrackNumber);

				if (checkBoxNeedAlbumArt.Checked && _Legato.AlbumArt != null)
				{
					using (var memory = new MemoryStream())
						_Legato.AlbumArt.Save("temp.png", ImageFormat.Png);

					await _Twitter.Statuses.UpdateWithMediaAsync(text, new FileInfo("temp.png"));
				}
				else
					await _Twitter.Statuses.UpdateAsync(text);

				Console.WriteLine("Twitter への投稿が完了しました");
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Twitter に投稿する際に、Voice 再生を行います。
		/// </summary>
		/// <param name="filePath"> 再生する Voice ファイル</param>
		/// <param name="aliasName">規定ワード</param>
		private async Task _PostingVoiceAsync(string filePath, string aliasName)
		{
			await _PlayingVoiceAsync(filePath, aliasName);
		}

		/// <summary>
		/// 再生した Voice を停止します。
		/// </summary>
		/// <param name="aliasName">規定ワード</param>
		private async Task _UnPostingVoiceAsync(string aliasName)
		{
			await _StoppedVoiceAsync(aliasName);
		}

		/// <summary>
		/// 非同期でボイスファイルを再生します。
		/// </summary>
		private async Task _PlayingVoiceAsync(string fileName, string aliasName)
		{
			string cmd;

			try
			{
				// ファイルを開く
				cmd = "open \"" + fileName + "\" type mpegvideo alias " + aliasName;

				if (mciSendString(cmd, null, 0, IntPtr.Zero) != 0)
					throw new ApplicationException();

				// 再生する
				cmd = "play " + aliasName;
				mciSendString(cmd, null, 0, IntPtr.Zero);

				await Task.Delay(1000);
			}
			catch (ApplicationException ex)
			{
				MessageBox.Show($"mp3 再生エラーが発生しました。\r\n{ex.StackTrace}",
								"mp3 再生エラー", 
								MessageBoxButtons.OK, 
								MessageBoxIcon.Error);
			}
			finally
			{
				//今のところ、常に実行したいものはない。
			}
		}

		/// <summary>
		/// 非同期でボイスファイルを停止します。
		/// </summary>
		private async Task _StoppedVoiceAsync(string aliasName)
		{
			string cmd;

			// Voice を停止する
			cmd = "stop " + aliasName;
			mciSendString(cmd, null, 0, IntPtr.Zero);

			// 閉じる
			cmd = "close " + aliasName;
			mciSendString(cmd, null, 0, IntPtr.Zero);

			await Task.Delay(100);
		}

		/// <summary>
		/// フォームに表示されているアルバムアートを更新します
		/// </summary>
		private void _UpdateAlbumArt()
		{
			if (_Legato?.IsRunning ?? false)
				pictureBoxAlbumArt.Image = _Legato.AlbumArt ?? Properties.Resources.logo;
			else
				pictureBoxAlbumArt.Image = Properties.Resources.logo;
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
			notifyIcon.ShowBalloonTip((int)_NotifyTime.TotalMilliseconds);
		}

		#region File IO Methods

		/// <summary>
		/// settings.json から設定を読み込みます
		/// <para>settings.json が存在しないときは新規に生成します</para>
		/// </summary>
		private async Task _LoadSettingsAsync()
		{
			try
			{
				string jsonString = null;
				using (var reader = new StreamReader("settings.json", Encoding.UTF8))
					jsonString = await reader.ReadToEndAsync();

				dynamic json = JsonConvert.DeserializeObject(jsonString);

				_PostingFormat = json.format ?? _DefaultPostingFormat;
				_PostingSound = json.sound ?? _DefaultPostingVoice;
			}
			catch
			{
				_PostingFormat = _DefaultPostingFormat;
				_PostingSound = _DefaultPostingVoice;
				await _SaveSettingsAsync();
			}
		}

		/// <summary>
		/// settings.json に設定を保存します
		/// </summary>
		private async Task _SaveSettingsAsync()
		{
			// 設定ファイルに保存すべき情報がある場合
			if (_PostingFormat != null)
			{
				var data = new { format = _PostingFormat, sound = _PostingSound };

				var jsonString = JsonConvert.SerializeObject(data, new JsonSerializerSettings
				{
					StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
				});

				using (var writer = new StreamWriter("settings.json", false, Encoding.UTF8))
					await writer.WriteAsync(jsonString);
			}
		}

		/// <summary>
		/// tokens.json からアカウント情報を読み込みます
		/// </summary>
		private async Task _LoadTokensFileAsync()
		{
			try
			{
				string jsonString = null;
				using (var reader = new StreamReader("tokens.json", Encoding.UTF8))
					jsonString = await reader.ReadToEndAsync();

				dynamic json = JsonConvert.DeserializeObject(jsonString);

				var ck = (string)json.ConsumerKey;
				var cs = (string)json.ConsumerSecret;
				var at = (string)json.AccessToken;
				var ats = (string)json.AccessTokenSecret;

				var isNotDefaultTokens = ck != _DefaultTokensKey && cs != _DefaultTokensKey && at != _DefaultTokensKey && ats != _DefaultTokensKey;
				if (isNotDefaultTokens)
				{
					var tokens = Tokens.Create(ck, cs, at, ats);

					// トークンの有効性を検証
					try
					{
						var account = await tokens.Account.VerifyCredentialsAsync(include_entities: false, skip_status: true);
						_Twitter = tokens;
					}
					catch { }
				}
			}
			catch
			{
				// JSONの構造が間違っている、もしくは存在しなかった場合
				await _CreateTokensFileAsync();
			}
		}

		/// <summary>
		/// tokens.json を生成します
		/// </summary>
		private async Task _CreateTokensFileAsync()
		{
			var data = new
			{
				ConsumerKey = _DefaultTokensKey,
				ConsumerSecret = _DefaultTokensKey,
				AccessToken = _DefaultTokensKey,
				AccessTokenSecret = _DefaultTokensKey
			};

			var jsonString = JsonConvert.SerializeObject(data, new JsonSerializerSettings
			{
				StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
			});

			using (var writer = new StreamWriter("tokens.json", false, Encoding.UTF8))
				await writer.WriteAsync(jsonString);
		}

		#endregion File IO Methods

		#endregion Methods

		#region Procedures

		private async void Form1_Load(object sender, EventArgs e)
		{
			Icon = Properties.Resources.legato;
			_NotifyTime = new TimeSpan(0, 0, 1);

			await _LoadTokensFileAsync();

			if (_Twitter == null)
			{
				MessageBox.Show(
					"有効なTwitterのトークン情報の設定が必要です。tokens.jsonの中身を編集してからアプリケーションを再実行してください。",
					"情報",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				this.Close();
				return;
			}

			await _LoadSettingsAsync();

			_Legato = new Legato();

			_Legato.Communicator.CurrentTrackChanged += async (track) =>
			{
				_UpdateFormTrackInfo(track);
				_UpdateAlbumArt();

				// auto posting
				if (checkBoxAutoPosting.Checked)
				{
					await _PostingVoiceAsync(_PostingSound, _AliasName);
					await _PostAsync();
					await _UnPostingVoiceAsync(_AliasName);
				}
			};

			if (_Legato.IsRunning)
			{
				_UpdateFormTrackInfo(_Legato.CurrentTrack);
				_UpdateAlbumArt();
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			_Legato?.Dispose();
		}

		private async void buttonPostNowPlaying_Click(object sender, EventArgs e)
		{
			await _PostingVoiceAsync(_PostingSound, _AliasName);
			await _PostAsync();
			await _UnPostingVoiceAsync(_AliasName);
		}

		private void pictureBoxAlbumArt_Click(object sender, EventArgs e)
		{
			if (_Legato.AlbumArt != null)
			{
				_Legato.AlbumArt.Save("temp.png", ImageFormat.Png);
				Process.Start("temp.png");
			}
		}

		private void checkBoxAutoPosting_CheckedChanged(object sender, EventArgs e)
		{
			buttonPostNowPlaying.Enabled = !checkBoxAutoPosting.Checked;
		}

		private async void buttonShowSettingWindow_Click(object sender, EventArgs e)
		{
			var settingWindow = new SettingWindow(_PostingFormat, _PostingSound);

			if (settingWindow.ShowDialog() == DialogResult.OK)
			{
				_PostingFormat = settingWindow.PostingFormat;
				_NotifyTime = settingWindow.notifyTime;
				_PostingSound = settingWindow.PostingSound;
				await _SaveSettingsAsync();
			}
		}

		#endregion Procedures
	}
}
