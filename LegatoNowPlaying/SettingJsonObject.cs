using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LegatoNowPlaying {
	/// <summary>
	/// 設定のJSONファイルを管理します
	/// </summary>
	public class SettingJsonObject {
		private SettingJsonObject() { }

		[JsonProperty("format"), DefaultValue("{TrackNum}. {Title}\r\nArtist: {Artist}\r\nAlbum: {Album}\r\n#nowplaying")]
		public string PostingFormat { get; set; }

		[JsonProperty("postsound"), DefaultValue("please your hope voice file.")]
		public string PostingSound { get; set; }

		[JsonProperty("exitsound"), DefaultValue("please your hope voice file.")]
		public string ExitingSound { get; set; }

		/// <summary>
		/// settings.json から設定を読み込みます
		/// <para>settings.json が存在しないときは新規に生成します</para>
		/// </summary>
		public static async Task<SettingJsonObject> LoadAsync() {
			try {
				string jsonString = null;
				using (var reader = new StreamReader("settings.json", Encoding.UTF8))
					jsonString = await reader.ReadToEndAsync();

				return JsonConvert.DeserializeObject<SettingJsonObject>(jsonString);
			}
			catch {
				var data = new SettingJsonObject();
				await data.SaveAsync();

				return data;
			}
		}

		/// <summary>
		/// settings.json に設定を保存します
		/// </summary>
		public async Task SaveAsync() {
			var jsonString = JsonConvert.SerializeObject(this, new JsonSerializerSettings {
				StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
			});

			using (var writer = new StreamWriter("settings.json", false, Encoding.UTF8))
				await writer.WriteAsync(jsonString);
		}
	}
}
