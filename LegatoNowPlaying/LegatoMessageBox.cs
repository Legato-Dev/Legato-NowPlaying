using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LegatoNowPlaying
{
	/// <summary>
	/// Legato-NowPlaying 終了時のメッセージウィンドウ管理クラス。
	/// </summary>
	internal class LegatoMessageBox
	{
		#region Fields

		private System.Threading.Timer _timer;
		private string _caption;

		#endregion

		#region External APIs

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		#endregion

		#region Constractor 

		public LegatoMessageBox(string text, string caption, int timeout)
		{
			this._caption = caption;
			_timer = new System.Threading.Timer(_OnTimerElapsed, null, timeout, Timeout.Infinite);

			MessageBox.Show(text, caption);
		}

		#endregion

		#region Method
		 
		private void _OnTimerElapsed(object state)
		{
			var mbWnd = FindWindow(null, _caption);

			if (mbWnd != IntPtr.Zero)
				SendMessage(mbWnd, 0x0010, IntPtr.Zero, IntPtr.Zero);

			_timer.Dispose();
		}

		#endregion
	}
}
