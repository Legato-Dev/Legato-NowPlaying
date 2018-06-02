﻿using AlbumArtExtraction;
using Legato;
using Legato.Interop.AimpRemote.Entities;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegatoNowPlaying.Services;

namespace LegatoNowPlaying
{
	public partial class Form1 : Form
	{

		#region Constractors

		public Form1()
		{
			InitializeComponent();

			var misskey = new Services.Misskey.Service();
			misskey.Install();
		}

		#endregion Constractors

		#region Properties

		private AimpProperties _AimpProperties { get; set; } = new AimpProperties();

		private AimpCommands _AimpCommands { get; set; } = new AimpCommands();

		private AimpObserver _AimpObserver { get; set; } = new AimpObserver();

		private SettingJsonFile _Setting { get; set; }

		#endregion Properties

		#region Methods

		private Image _GetAlbumArt()
		{
			try
			{
				var trackFilePath = _AimpProperties.CurrentTrack.FilePath;
				var selector = new Selector();
				var extractor = selector.SelectAlbumArtExtractor(trackFilePath);
				return extractor.Extract(trackFilePath);
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
			try
			{
				var track = _AimpProperties.CurrentTrack;

				// 投稿内容を構築
				var stringBuilder = new StringBuilder(_Setting.PostingFormat);
				stringBuilder = stringBuilder.Replace("{Title}", "{0}");
				stringBuilder = stringBuilder.Replace("{Artist}", "{1}");
				stringBuilder = stringBuilder.Replace("{Album}", "{2}");
				stringBuilder = stringBuilder.Replace("{TrackNum}", "{3:D2}");
				var text = string.Format(stringBuilder.ToString(), track.Title, track.Artist, track.Album, track.TrackNumber);

				var albumArt = _GetAlbumArt();

				if (checkBoxNeedAlbumArt.Checked && albumArt != null)
				{
					using (var memory = new MemoryStream())
						albumArt.Save("temp.png", ImageFormat.Png);

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

		private async void Form1_Load(object sender, EventArgs e)
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
		}

		private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
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
			var settingWindow = new SettingWindow(_Setting);

			if (settingWindow.ShowDialog() == DialogResult.OK)
			{
				await _Setting.SaveAsync();
			}
		}

		#endregion Event Handlers

	}
}
