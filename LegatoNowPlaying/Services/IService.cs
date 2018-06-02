using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegatoNowPlaying.Services
{
	interface IService
	{
		void Install();
		void Post(Image albumArt);
	}
}
