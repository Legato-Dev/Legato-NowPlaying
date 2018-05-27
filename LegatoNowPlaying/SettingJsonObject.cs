using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LegatoNowPlaying
{
	/// <summary>
	/// 設定のJSONファイルを管理します
	/// </summary>
	public class SettingJsonObject
	{

		#region Constractors

		private SettingJsonObject() { }

		#endregion Constractors

		#region Properties/Fields

		[JsonProperty("format")]
		public string PostingFormat { get; set; }
		public static string PostingFormatDefault = "{TrackNum}. {Title}\r\nArtist: {Artist}\r\nAlbum: {Album}\r\n#nowplaying";

		[JsonProperty("postsound")]
		public string PostingSound { get; set; }

		[JsonProperty("exitsound")]
		public string ExitingSound { get; set; }

		[JsonProperty("notifyTime")]
		public TimeSpan? NotifyTime { get; set; }

		#endregion Properties/Fields

		#region Methods

		/// <summary>
		/// 適宜、デフォルト値を設定することによって値の整合性を取ります
		/// </summary>
		/// <param name="target"></param>
		private static void _Normalize(SettingJsonObject target)
		{
			target.PostingFormat = target.PostingFormat ?? PostingFormatDefault;

			if (!target.NotifyTime.HasValue)
				target.NotifyTime = new TimeSpan(0, 0, 1);

			if (target.PostingSound == "")
				target.PostingSound = null;

			if (target.ExitingSound == "")
				target.ExitingSound = null;
		}

		/// <summary>
		/// settings.json から設定を読み込みます
		/// <para>settings.json が存在しないときは新規に生成します</para>
		/// </summary>
		public static async Task<SettingJsonObject> LoadAsync()
		{
			try
			{
				string jsonString = null;
				using (var reader = new StreamReader("settings.json", Encoding.UTF8))
					jsonString = await reader.ReadToEndAsync();

				var data = JsonConvert.DeserializeObject<SettingJsonObject>(jsonString);

				// 整合性を取る
				_Normalize(data);

				return data;
			}
			catch
			{
				var data = new SettingJsonObject();
				await data.SaveAsync();

				return data;
			}
		}

		/// <summary>
		/// settings.json に設定を保存します
		/// </summary>
		public async Task SaveAsync()
		{

			// 整合性を取る
			_Normalize(this);

			// JSON生成
			var jsonString = JsonConvert.SerializeObject(this, new JsonSerializerSettings
			{
				StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
			});

			// ファイルへ書き込み
			using (var writer = new StreamWriter("settings.json", false, Encoding.UTF8))
				await writer.WriteAsync(jsonString);
		}

		#endregion Methods

	}
}
