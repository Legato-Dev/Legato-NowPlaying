using System.Drawing;
using System.Threading.Tasks;

namespace LegatoNowPlaying.Services
{
	interface IService
	{
		Task Post(string text, Image albumArt);
	}
}
