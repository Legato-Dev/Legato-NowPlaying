using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LegatoNowPlaying
{
	public static class ErrorLogger
	{
		public static async Task LogException(Exception ex, bool isInnerException = false)
		{
			using (var log = new StreamWriter("errors.log", true, Encoding.UTF8))
			{
				if (!isInnerException)
				{
					await log.WriteLineAsync("------------------------------");
					await log.WriteLineAsync("");
					await log.WriteLineAsync("# Exception");
					await log.WriteLineAsync($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
				}
				else
				{
					await log.WriteLineAsync("# Inner Exception");
				}

				await log.WriteLineAsync("");
				await log.WriteLineAsync($"[Message] {ex.Message}");
				await log.WriteLineAsync("[StackTrace]");
				await log.WriteLineAsync($"{ex.StackTrace}");
				await log.WriteLineAsync("");
			}

			if (ex.InnerException != null)
			{
				await LogException(ex.InnerException, true);
			}
		}
	}
}
