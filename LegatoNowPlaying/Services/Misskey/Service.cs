using Misq;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;

namespace LegatoNowPlaying.Services.Misskey
{
	public class Service : IService
	{
		public const string appKey = "z31SlkbuIonQ5G1tdx4j7xvGRL7XS51y";

		private Misq.Me me;
		private CredentialsJsonFile config;

		public Service(Me me)
		{
			this.me = me;
		}

		static public void Install(Accounts accounts)
		{
			var form = new Services.Misskey.AuthForm(async (Misq.Me me) => {
				var config = await CredentialsJsonFile.LoadAsync();
				config.Token = me.UserToken;
				config.Host = me.Host;
				await config.SaveAsync();

				accounts.Misskey = await Use();
			});
			form.Show();
		}

		static public void Setting()
		{
			var form = new Services.Misskey.SettingForm();
			form.Show();
		}

		static public async Task<Service> Use()
		{
			var config = await CredentialsJsonFile.LoadAsync();

			if (config.Token != null)
			{
				return new Service(new Misq.Me(config.Host, config.Token, appKey));
			}
			else
			{
				return null;
			}
		}

		public async Task Post(string text, Image albumArt)
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
				var stream = new System.IO.MemoryStream();
				albumArt.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
				var img = stream.ToArray();

				var form = new MultipartFormDataContent
				{
					{ new ByteArrayContent(img), "file", "cover.jpg" }
				};

				var file = await this.me.RequestWithBinary("drive/files/create", form);

				ps.Add("mediaIds", new string[] { file.id });
			}

			await this.me.Request("notes/create", ps);
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
		/// tokens.json からアカウント情報を読み込みます
		/// </summary>
		public static Task<CredentialsJsonFile> LoadAsync()
		{
			return LoadAsync<CredentialsJsonFile>("misskey.json");
		}

		/// <summary>
		/// tokens.json を生成します
		/// </summary>
		public Task SaveAsync()
		{
			return SaveAsync("misskey.json");
		}

		#endregion Methods

	}
}
