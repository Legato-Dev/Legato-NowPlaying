using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrostAPI = FrostSDK.RestApi;

namespace LegatoNowPlaying.Services.Frost
{
	public class Service : Services.Service
	{
		#region inner class

		/// <summary>
		/// 資格情報のJSONファイルを管理します
		/// </summary>
		public class CredentialsJsonFile : JsonFile
		{

			#region Properties/Fields

			public bool Enabled { get; set; } = true;

			public string ClientID { get; set; }

			public string ClientSecret { get; set; }

			public string AccessToken { get; set; }

			#endregion Properties/Fields

			#region Methods

			/// <summary>
			/// frost.json からアカウント情報を読み込みます
			/// </summary>
			public static Task<CredentialsJsonFile> LoadAsync()
			{
				return LoadAsync<CredentialsJsonFile>("frost.json");
			}

			/// <summary>
			/// frost.json を生成します
			/// </summary>
			public Task SaveAsync()
			{
				return SaveAsync("frost.json");
			}

			#endregion Methods

		}

		#endregion inner class

		#region readonly field

		private static readonly string at = "access token";
		private static readonly string apiUrl = "https://api.frost-social.ml/";

		#endregion readonly field

		#region Properties

		private FrostAPI _Frost { get; set; } = new FrostAPI(at, apiUrl);
		private CredentialsJsonFile _Config { get; set; }

		public override string Name { get; } = "Frost";
		public override bool IsInstalled => this._Frost != null;
		public override bool HasSetting { get; } = true;

		#endregion Properties

		#region Methods

		public override async Task<bool> Install()
		{
			await this.Setup();
			MessageBox.Show($"Hello @hoge", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return true;
		}

		public override async Task Setup()
		{
			this._Config = await CredentialsJsonFile.LoadAsync();
			this.Enabled = this._Config.Enabled;
		}

		public override async Task Post(string text, Image albumArt = null)
		{
			try
			{
				Console.WriteLine("ポストを投稿しています...");
				var statusPost = await this._Frost.CreateStatusPost(text);
				Console.WriteLine($"成功しました！ Text={statusPost.Text} CreatedAt={statusPost.CreatedAt}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"失敗しました: {ex.Message}");
			}
		}

		public override async Task ToggleEnable()
		{
			this.Enabled = !Enabled;
			this._Config.Enabled = this.Enabled;
			await this._Config.SaveAsync();
		}

		public override Task Setting()
		{
			return Task.CompletedTask;
		}

		#endregion Methods
	}
}
