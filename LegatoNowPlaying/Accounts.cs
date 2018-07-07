using LegatoNowPlaying.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace LegatoNowPlaying
{
	public class Accounts
	{
		public List<IService> Services { get; set; } = new List<IService>();

		public async void Init()
		{
			Services.Add(new Services.Misskey.Service());
			Services.Add(new Services.Twitter.Service());

			foreach (var service in Services)
			{
				await service.Setup();
			}
		}

		public async Task Post(string text, Image albumArt)
		{
			foreach (var service in Services)
			{
				if ((service as ServiceBase).Enabled)
				{
					try
					{
						await service.Post(text, albumArt);
						Console.WriteLine($"{service.Name} への投稿が完了しました");
					}
					catch (Exception ex)
					{
						Console.Error.WriteLine(ex.Message);
					}
				}
			}
		}
	}
}
