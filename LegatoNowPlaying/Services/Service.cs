using System.Drawing;
using System.Threading.Tasks;

namespace LegatoNowPlaying.Services
{
	public abstract class Service
	{
		public abstract string Name { get; }
		public abstract bool IsInstalled { get; }
		public abstract bool HasSetting { get; }
		public bool Enabled { get; set; } = true;
		public string AccountName { get; set; }

		public abstract Task<bool> Install();
		public abstract Task Setup();
		public abstract Task ToggleEnable();
		public abstract Task Post(string text, Image albumArt);
		public abstract Task Setting();
	}
}
