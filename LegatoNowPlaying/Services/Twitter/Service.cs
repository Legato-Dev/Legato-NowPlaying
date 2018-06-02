using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTweet;
using System.Windows.Forms;

namespace LegatoNowPlaying.Services.Twitter
{
	class Service : IService
	{
		private CredentialsJsonFile _Credentials { get; set; }

		private Tokens _Twitter { get; set; }

		public async void Install()
		{
			_Twitter = await _LoadAndVerifyCredentialsAsync();
			if (_Twitter == null)
			{
				MessageBox.Show(
					"有効なTwitterのトークン情報の設定が必要です。tokens.jsonの中身を編集してからアプリケーションを再実行してください。",
					"情報",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

		}

		public void Post()
		{

		}

		#region File IO Methods

		/// <summary>
		/// tokens.json からアカウント情報を読み込み、その有効性を検証します
		/// </summary>
		private async Task<Tokens> _LoadAndVerifyCredentialsAsync()
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
