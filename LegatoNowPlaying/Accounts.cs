using System.Drawing;
using System.Threading.Tasks;

namespace LegatoNowPlaying
{
	public class Accounts
	{
		public Services.Misskey.Service Misskey;
		public Services.Twitter.Service Twitter;

		public async void Init()
		{
			this.Misskey = await Services.Misskey.Service.Use();
			this.Twitter = await Services.Twitter.Service.Use();
		}

		public async Task Post(string text, Image albumArt)
		{
			if (this.Misskey != null) await this.Misskey.Post(text, albumArt);
			if (this.Twitter != null) await this.Twitter.Post(text, albumArt);
		}
	}
}
