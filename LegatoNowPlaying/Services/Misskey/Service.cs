using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misq;
using Legato.Interop.AimpRemote.Entities;
using System.Drawing;

namespace LegatoNowPlaying.Services.Misskey
{
	class Service : IService
	{
		private SettingJsonFile settings;

		private Misq.App app;

		public async void Install(SettingJsonFile settings)
		{
			this.settings = settings;

			var config = await CredentialsJsonFile.LoadAsync();
			var token = config.Token;

			if (token == null)
			{
				new Services.Misskey.AuthForm();
			}

		}

		public async void Post(TrackInfo track, Image albumArt, Boolean withAlbumArt)
		{
			
		}
	}

	public class CredentialsJsonFile : JsonFile
	{

		#region Properties/Fields

		public string Token { get; set; }

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
