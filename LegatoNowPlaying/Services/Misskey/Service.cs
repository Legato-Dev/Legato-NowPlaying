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
		private SettingJsonFile settings;
		private CredentialsJsonFile config;

		private Misq.Me me;

		public async void Install(SettingJsonFile settings)
		{
			this.settings = settings;

			this.config = await CredentialsJsonFile.LoadAsync();

			if (this.config.Token == null)
			{
				var form = new Services.Misskey.AuthForm(this.OnComplete);
				form.Show();
			}
			else
			{
				this.me = new Misq.Me(this.config.Host, this.config.Token, "z31SlkbuIonQ5G1tdx4j7xvGRL7XS51y");
			}

		}

		private void OnComplete(Misq.Me me)
		{
			this.config.Token = me.UserToken;
			this.config.Host = me.Host;
			this.config.SaveAsync();
			this.me = me;
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

				form.Add(new ByteArrayContent(img, 0, img.Length), "file");

				var file = await this.me.RequestWithBinary("drive/files/create", form);

				ps.Add("fileIds", new string[] { file.id });
			}

			//await this.me.Request("notes/create", ps);
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
