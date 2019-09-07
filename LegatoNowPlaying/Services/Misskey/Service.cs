using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;

namespace LegatoNowPlaying.Services.Misskey
{
	public class Service : Services.Service
	{
		private Misq.Me Me;

		private CredentialsJsonFile Config { get; set; }

		public override string Name { get; } = "Misskey";

		public override bool IsInstalled => this.Me != null && this.Me.UserToken != null;

		public override bool HasSetting { get; } = true;

		public override Task<bool> Install()
		{
			var s = new TaskCompletionSource<bool>();
			
			var form = new Services.Misskey.AuthForm(async (Misq.Me me, Misq.App app) => {
				this.Config.Token = me.UserToken;
				this.Config.Secret = app.Secret;
				this.Config.Host = me.Host;
				this.Config.AccountName = "@" + me.Username;
				await this.Config.SaveAsync();
				await Setup();

				s.SetResult(true);
			});
			form.Show();

			return s.Task;
		}

		public override async Task Setup()
		{
			this.Config = await CredentialsJsonFile.LoadAsync();

			if (this.Config.Host != null && this.Config.Token != null && this.Config.Secret != null)
			{
				this.Me = new Misq.Me(this.Config.Host, this.Config.Token, this.Config.Secret);
			}
			this.Enabled = this.Config.Enabled;
			this.AccountName = this.Config.AccountName;
		}

		public override async Task ToggleEnable()
		{
			this.Enabled = !this.Enabled;

			this.Config.Enabled = this.Enabled;
			await this.Config.SaveAsync();
		}

		public override async Task Post(string text, Image albumArt)
		{
			var ps = new Dictionary<string, object>
			{
				{ "text", text }
			};

			if (!this.Config.PostToLtl)
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

				var file = await this.Me.RequestWithBinary("drive/files/create", form);

				ps.Add("mediaIds", new string[] { file.id });
			}

			await this.Me.Request("notes/create", ps);
		}

		public override Task Setting()
		{
			var form = new Services.Misskey.SettingForm(this.Config);
			form.Show();

			return Task.CompletedTask;
		}
	}

	public class CredentialsJsonFile : JsonFile
	{

		#region Properties/Fields

		public bool Enabled { get; set; } = true;

		public string Token { get; set; }

		public string Secret { get; set; }

		public string Host { get; set; }

		public bool PostToLtl { get; set; }

		public string AccountName { get; set; }

		#endregion Properties/Fields

		#region Methods

		/// <summary>
		/// misskey.json からアカウント情報を読み込みます
		/// </summary>
		public static async Task<CredentialsJsonFile> LoadAsync()
		{
			var setting = await LoadAsync<CredentialsJsonFile>("misskey.json");

			if (setting.Token == null || setting.Secret == null)
			{
				setting.Token = null;
				setting.Secret = null;
			}

			return setting;
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
