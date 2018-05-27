using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace LegatoNowPlaying
{
	/// <summary>
	/// Legato-NowPlaying 終了時のメッセージウィンドウ管理クラス。
	/// </summary>
	internal class LegatoMessageBox
	{

		#region Constractors

		public LegatoMessageBox(string text, string caption, int timeout)
		{
			_Timer = new System.Threading.Timer((state) => {
				var mbWnd = FindWindow(null, caption);

				if (mbWnd != IntPtr.Zero)
					SendMessage(mbWnd, 0x0010, IntPtr.Zero, IntPtr.Zero);

				_Timer.Dispose();
			}, null, timeout, Timeout.Infinite);

			MessageBox.Show(text, caption);
		}

		#endregion Constractors

		#region Properties

		private System.Threading.Timer _Timer { get; set; }

		#endregion Properties

		#region External APIs

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		#endregion External APIs

	}
}
