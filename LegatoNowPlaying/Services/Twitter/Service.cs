using CoreTweet;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegatoNowPlaying.Services.Twitter
{
	public class Service : IService
	{
		private Tokens _Twitter { get; set; }

		public Service(Tokens Twitter)
		{
			_Twitter = Twitter;
		}

		static public async void Install(Accounts accounts)
		{
			var _Twitter = await _LoadAndVerifyCredentialsAsync();
			if (_Twitter == null)
			{
				MessageBox.Show(
					"有効なTwitterのトークン情報の設定が必要です。tokens.jsonの中身を編集してからアプリケーションを再実行してください。",
					"情報",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}
			else
			{
				accounts.Twitter = await Use();
			}
		}

		static public async Task<Service> Use()
		{
			var _Twitter = await _LoadAndVerifyCredentialsAsync();
			if (_Twitter != null)
			{
				return new Service(_Twitter);
			}
			else
			{
				return null;
			}
		}

		public async void Post(string text, Image albumArt)
		{
			try
			{
				if (albumArt != null)
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

		#region File IO Methods

		/// <summary>
		/// tokens.json からアカウント情報を読み込み、その有効性を検証します
		/// </summary>
		static private async Task<Tokens> _LoadAndVerifyCredentialsAsync()
		{
			var data = await CredentialsJsonFile.LoadAsync();
			var ck = data.ConsumerKey;
			var cs = data.ConsumerSecret;
			var at = data.AccessToken;
			var ats = data.AccessTokenSecret;

			var defaultTokensKey = "";

			var isNotDefaultTokens = ck != defaultTokensKey && cs != defaultTokensKey && at != defaultTokensKey && ats != defaultTokensKey;
			if (isNotDefaultTokens)
			{
				var tokens = Tokens.Create(ck, cs, at, ats);

				// トークンの有効性を検証
				try
				{
					var account = await tokens.Account.VerifyCredentialsAsync(include_entities: false, skip_status: true);
					return tokens;
				}
				catch { }
			}
			return null;
		}

		#endregion File IO Methods
	}

	/// <summary>
	/// 資格情報のJSONファイルを管理します
	/// </summary>
	public class CredentialsJsonFile : JsonFile
	{

		#region Properties/Fields

		public static string DefaultValue = "please set your tokens";

		public string ConsumerKey { get; set; }

		public string ConsumerSecret { get; set; }

		public string AccessToken { get; set; }

		public string AccessTokenSecret { get; set; }

		#endregion Properties/Fields

		#region Methods

		/// <summary>
		/// tokens.json からアカウント情報を読み込みます
		/// </summary>
		public static Task<CredentialsJsonFile> LoadAsync()
		{
			return LoadAsync<CredentialsJsonFile>("tokens.json");
		}

		/// <summary>
		/// tokens.json を生成します
		/// </summary>
		public Task SaveAsync()
		{
			return SaveAsync("tokens.json");
		}

		#endregion Methods

	}
}
