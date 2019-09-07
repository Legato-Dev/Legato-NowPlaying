using System;
using System.Windows.Forms;

namespace LegatoNowPlaying
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			catch (Exception ex)
			{
				ErrorLogger.LogException(ex).Wait();
				MessageBox.Show($"エラーが発生しました。\r\n詳細についてはerrors.logを確認してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
