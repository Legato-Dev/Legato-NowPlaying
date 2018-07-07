using System.Drawing;
using System.Threading.Tasks;

namespace LegatoNowPlaying.Services
{
	public abstract class ServiceBase
	{
		public bool Enabled { get; set; } = true;
		public string AccountName { get; set; }
	}

	public interface IService
	{
		string Name { get; }
		bool IsInstalled { get; }
		bool HasSetting { get; }

		Task<bool> Install();
		Task Setup();
		Task ToggleEnable();
		Task Post(string text, Image albumArt);
		Task Setting();
	}
}
