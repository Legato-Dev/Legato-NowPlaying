using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LegatoNowPlaying
{
	public abstract class JsonFile
	{
		protected static async Task<T> LoadAsync<T>(string fileName) where T : JsonFile, new()
		{
			try
			{
				string jsonString = null;
				using (var reader = new StreamReader(fileName, Encoding.UTF8))
					jsonString = await reader.ReadToEndAsync();

				var data = JsonConvert.DeserializeObject<T>(jsonString);

				return data;
			}
			catch
			{
				var data = new T();
				await SaveAsync(fileName, data);

				return data;
			}
		}

		protected static async Task SaveAsync(string fileName, JsonFile source)
		{
			// JSON生成
			var jsonString = JsonConvert.SerializeObject(source, new JsonSerializerSettings
			{
				StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
			});

			// ファイルへ書き込み
			using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
				await writer.WriteAsync(jsonString);
		}
	}
}
