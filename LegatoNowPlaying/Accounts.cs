using System.Drawing;

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

		public void Post(string text, Image albumArt)
		{
			if (this.Misskey != null) this.Misskey.Post(text, albumArt);
			if (this.Twitter != null) this.Twitter.Post(text, albumArt);
		}
	}
}
