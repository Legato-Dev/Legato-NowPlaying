using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LegatoNowPlaying
{
	/// <summary>
	/// 資格情報のJSONファイルを管理します
	/// </summary>
	public class CredentialsJsonObject
	{
		private CredentialsJsonObject() { }

		public static string DefaultValue = "please set your tokens";

		public string ConsumerKey { get; set; }

		public string ConsumerSecret { get; set; }

		public string AccessToken { get; set; }

		public string AccessTokenSecret { get; set; }

		/// <summary>
		/// tokens.json からアカウント情報を読み込みます
		/// </summary>
		public static async Task<CredentialsJsonObject> LoadAsync()
		{
			try
			{
				string jsonString = null;
				using (var reader = new StreamReader("tokens.json", Encoding.UTF8))
					jsonString = await reader.ReadToEndAsync();

				return JsonConvert.DeserializeObject<CredentialsJsonObject>(jsonString);
			}
			catch
			{
				// JSONの構造が間違っている、もしくは存在しなかった場合は新規に生成
				var data = new CredentialsJsonObject();
				await data.SaveAsync();

				return data;
			}
		}

		/// <summary>
		/// tokens.json を生成します
		/// </summary>
		public async Task SaveAsync()
		{
			var jsonString = JsonConvert.SerializeObject(this, new JsonSerializerSettings
			{
				StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
			});

			// 存在する場合は上書き
			using (var writer = new StreamWriter("tokens.json", false, Encoding.UTF8))
			{
				await writer.WriteAsync(jsonString);
			}
		}
	}
}
