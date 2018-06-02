using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misq;

namespace LegatoNowPlaying.Services.Misskey
{
	class Service : IService
	{
		private Misq.App app;

		public async void Install()
		{
			var config = await CredentialsJsonFile.LoadAsync();
			var token = config.Token;

			if (token == null)
			{
				new Services.Misskey.AuthForm();
			}

		}

		public void Post()
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
