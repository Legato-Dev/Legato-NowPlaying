using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misq;
using Legato.Interop.AimpRemote.Entities;
using System.Drawing;
using System.Net.Http;

namespace LegatoNowPlaying.Services.Misskey
{
	class Service : IService
	{
		private Misq.Me me;

		public Service(Me me)
		{
			this.me = me;
		}

		static public void Install()
		{
			var form = new Services.Misskey.AuthForm(OnComplete);
			form.Show();
		}

		static public async Task<Service> Use()
		{
			var config = await CredentialsJsonFile.LoadAsync();

			if (config.Token != null)
			{
				return new Service(new Misq.Me(config.Host, config.Token, "z31SlkbuIonQ5G1tdx4j7xvGRL7XS51y"));
			}
			else
			{
				return null;
			}
		}

		static private async void OnComplete(Misq.Me me)
		{
			var config = await CredentialsJsonFile.LoadAsync();
			config.Token = me.UserToken;
			config.Host = me.Host;
			await config.SaveAsync();

			Core.Misskey = await Use();
		}

		public async void Post(string text, Image albumArt)
		{
			var ps = new Dictionary<string, object>
			{
				{ "text", text }
			};

			if (albumArt != null)
			{
				var form = new MultipartFormDataContent();

				var stream = new System.IO.MemoryStream();
				albumArt.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
				var img = stream.ToArray();

				var data = new ByteArrayContent(img);

				form.Add(data, "file", "cover.jpg");

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
