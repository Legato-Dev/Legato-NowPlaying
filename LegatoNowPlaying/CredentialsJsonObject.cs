using System.Threading.Tasks;

namespace LegatoNowPlaying
{
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
			return SaveAsync("tokens.json", this);
		}

		#endregion Methods

	}
}
