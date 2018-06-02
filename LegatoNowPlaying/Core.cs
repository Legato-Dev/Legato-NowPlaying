using System.Drawing;

namespace LegatoNowPlaying
{
	static class Core
	{
		static public Services.Misskey.Service Misskey;
		static public Services.Twitter.Service Twitter;

		static public async void Init()
		{
			Misskey = await Services.Misskey.Service.Use();
			Twitter = await Services.Twitter.Service.Use();
		}

		static public void Post(string text, Image albumArt)
		{
			if (Misskey != null) Misskey.Post(text, albumArt);
			if (Twitter != null) Twitter.Post(text, albumArt);
		}
	}
}
