using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace LegatoNowPlaying
{
	public class SoundService : IDisposable
	{

		#region Constractors

		private SoundService(string filePath, string aliasName)
		{
			FilePath = filePath;
			AliasName = aliasName;
		}

		#endregion Constractors

		#region Properties

		public string FilePath { get; private set; }

		public string AliasName { get; private set; }

		private static Random _Random { get; set; } = new Random();

		#endregion Properties

		#region External APIs

		[DllImport("winmm.dll")]
		private static extern int mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

		#endregion External APIs

		#region Methods

		private static int _MciCommand(string command)
		{
			return mciSendString(command, null, 0, IntPtr.Zero);
		}

		public static SoundService Open(string filePath)
		{
			var aliasName = $"{_Random.Next(0, 1000)}";

			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException($"file not found: {filePath}");
			}

			if (_MciCommand($"open \"{filePath}\" type mpegvideo alias {aliasName}") != 0)
			{
				throw new ApplicationException($"failed to open sound file \"{filePath}\"");
			}

			return new SoundService(filePath, aliasName);
		}

		public void Play()
		{
			_MciCommand($"play {AliasName}");
		}

		public void Stop()
		{
			_MciCommand($"stop {AliasName}");
		}

		public void Close()
		{
			_MciCommand($"close {AliasName}");
		}

		public void Dispose()
		{
			Close();
		}

		#endregion Methods

	}
}
