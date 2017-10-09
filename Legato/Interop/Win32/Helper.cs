using System.Windows.Forms;

namespace Legato.Interop.Win32
{
	/// <summary>
	/// Win32API に関するヘルパーを提供します
	/// </summary>
	public static class Helper
	{
		/// <summary>
		/// 対象をメッセージ専用ウインドウに変更します
		/// </summary>
		public static void ChangeMessageOnlyWindow(IWin32Window window)
		{
			API.SetParent(window.Handle, API.HWND_MESSAGE);
		}
	}
}
