using CoreTweet;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegatoNowPlaying.Services.Twitter
{
	public class Service : Services.Service
	{
		private Tokens _Twitter { get; set; }

		public override string Name { get; } = "Twitter";

		public override bool IsInstalled => _Twitter.AccessToken != null;

		public override bool HasSetting { get; } = false;

		public override async Task<bool> Install()
		{
			var config = await CredentialsJsonFile.LoadAsync();
			var twitter = await _LoadAndVerifyCredentialsAsync(config);
			if (twitter == null)
			{
				MessageBox.Show(
					"有効なTwitterトークンの設定が必要です。twitter.jsonの中身を編集してからアプリケーションを再実行してください。",
					"Information",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return false;
			}
			await Setup();

			MessageBox.Show($"Hello @{_Twitter.ScreenName}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

			return true;
		}

		public override async Task Setup()
		{
			var config = await CredentialsJsonFile.LoadAsync();
			var twitter = await _LoadAndVerifyCredentialsAsync(config);

			if (twitter == null) return;

			twitter.UserId = long.Parse(twitter.AccessToken.Split('-')[0]);
			var user = await twitter.Users.ShowAsync(twitter.UserId);
			twitter.ScreenName = user.ScreenName;

			_Twitter = twitter;

			Enabled = config.Enabled;
		}

		public override async Task ToggleEnable()
		{
			Enabled = !Enabled;

			var config = await CredentialsJsonFile.LoadAsync();
			config.Enabled = Enabled;
			await config.SaveAsync();
		}

		public override async Task Post(string text, Image albumArt)
		{
			if (_Twitter == null) return;

			if (albumArt != null)
			{
				using (var memory = new MemoryStream())
					albumArt.Save("temp.png", ImageFormat.Png);

				await _Twitter.Statuses.UpdateWithMediaAsync(text, new FileInfo("temp.png"));
			}
			else
			{
				await _Twitter.Statuses.UpdateAsync(text);
			}
		}

		public override Task Setting()
		{
			return Task.CompletedTask;
		}

		#region File IO Methods

		/// <summary>
		/// tokens.json からアカウント情報を読み込み、その有効性を検証します
		/// </summary>
		static private async Task<Tokens> _LoadAndVerifyCredentialsAsync(CredentialsJsonFile config)
		{
			var ck = config.ConsumerKey;
			var cs = config.ConsumerSecret;
			var at = config.AccessToken;
			var ats = config.AccessTokenSecret;

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

		public bool Enabled { get; set; } = true;

		public string ConsumerKey { get; set; }

		public string ConsumerSecret { get; set; }

		public string AccessToken { get; set; }

		public string AccessTokenSecret { get; set; }

		#endregion Properties/Fields

		#region Methods

		/// <summary>
		/// twitter.json からアカウント情報を読み込みます
		/// </summary>
		public static Task<CredentialsJsonFile> LoadAsync()
		{
			return LoadAsync<CredentialsJsonFile>("twitter.json");
		}

		/// <summary>
		/// twitter.json を生成します
		/// </summary>
		public Task SaveAsync()
		{
			return SaveAsync("twitter.json");
		}

		#endregion Methods

	}
}
