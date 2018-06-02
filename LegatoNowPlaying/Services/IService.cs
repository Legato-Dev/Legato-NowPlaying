using Legato.Interop.AimpRemote.Entities;
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
		void Install(SettingJsonFile settings);
		void Post(string text, Image albumArt);
	}
}
