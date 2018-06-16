using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;

namespace LegatoNowPlaying.Services.Misskey
{
	public class Service : Services.Service
	{
		public const string appKey = "z31SlkbuIonQ5G1tdx4j7xvGRL7XS51y";

		private Misq.Me me;
		private CredentialsJsonFile config;

		public override string Name { get; } = "Misskey";
		public override bool IsInstalled => me != null && me.UserToken != null;
		public override bool HasSetting { get; } = true;

		public override Task<bool> Install()
		{
			var s = new TaskCompletionSource<bool>();
			
			var form = new Services.Misskey.AuthForm(async (Misq.Me me) => {
				var config = await CredentialsJsonFile.LoadAsync();
				config.Token = me.UserToken;
				config.Host = me.Host;
				await config.SaveAsync();
				await Setup();

				s.SetResult(true);
			});
			form.Show();

			return s.Task;
		}

		public override async Task Setup()
		{
			var config = await CredentialsJsonFile.LoadAsync();

			this.me = new Misq.Me(config.Host, config.Token, appKey);
		}

		public override async Task Post(string text, Image albumArt)
		{
			var config = await CredentialsJsonFile.LoadAsync();

			var ps = new Dictionary<string, object>
			{
				{ "text", text }
			};

			if (!config.PostToLtl)
			{
				ps.Add("visibility", "home");
			}

			if (albumArt != null)
			{
				byte[] img;
				using (var stream = new System.IO.MemoryStream())
				{
					albumArt.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
					img = stream.ToArray();
				}

				var form = new MultipartFormDataContent
				{
					{ new ByteArrayContent(img), "file", "cover.jpg" }
				};

				var file = await this.me.RequestWithBinary("drive/files/create", form);

				ps.Add("mediaIds", new string[] { file.id });
			}

			await this.me.Request("notes/create", ps);
		}

		public override Task Setting()
		{
			var form = new Services.Misskey.SettingForm();
			form.Show();

			return Task.CompletedTask;
		}
	}

	public class CredentialsJsonFile : JsonFile
	{

		#region Properties/Fields

		public string Token { get; set; }
		public string Host { get; set; }
		public bool PostToLtl { get; set; }

		#endregion Properties/Fields

		#region Methods

		/// <summary>
		/// misskey.json からアカウント情報を読み込みます
		/// </summary>
		public static Task<CredentialsJsonFile> LoadAsync()
		{
			return LoadAsync<CredentialsJsonFile>("misskey.json");
		}

		/// <summary>
		/// misskey.json を生成します
		/// </summary>
		public Task SaveAsync()
		{
			return SaveAsync("misskey.json");
		}

		#endregion Methods

	}
}
