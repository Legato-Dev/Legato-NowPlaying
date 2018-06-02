using System.Drawing;

namespace LegatoNowPlaying.Services
{
	interface IService
	{
		void Post(string text, Image albumArt);
	}
}
