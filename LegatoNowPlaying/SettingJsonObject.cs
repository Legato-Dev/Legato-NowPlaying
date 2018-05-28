using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace LegatoNowPlaying
{
	/// <summary>
	/// 設定のJSONファイルを管理します
	/// </summary>
	public class SettingJsonFile : JsonFile
	{

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
		private void _Normalize()
		{
			PostingFormat = PostingFormat ?? PostingFormatDefault;

			if (!NotifyTime.HasValue)
				NotifyTime = new TimeSpan(0, 0, 1);

			if (PostingSound == "")
				PostingSound = null;

			if (ExitingSound == "")
				ExitingSound = null;
		}

		/// <summary>
		/// settings.json から設定を読み込みます
		/// <para>settings.json が存在しないときは新規に生成します</para>
		/// </summary>
		public static async Task<SettingJsonFile> LoadAsync()
		{
			var setting = await LoadAsync<SettingJsonFile>("settings.json");
			setting._Normalize();

			return setting;
		}

		/// <summary>
		/// settings.json に設定を保存します
		/// </summary>
		public Task SaveAsync()
		{
			_Normalize();
			return SaveAsync("settings.json", this);
		}

		#endregion Methods

	}
}
