using Legato.Interop.Win32.Enum;
using System;
using System.Runtime.InteropServices;

namespace Legato.Interop.Win32
{
	/// <summary>
	/// Win32API をサポートします
	/// </summary>
	public static class API
	{
		#region Constants

		/// <summary>
		/// メッセージ専用ウインドウを表します
		/// </summary>
		public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

		#endregion Constants

		#region Structs

		/// <summary>
		/// コピーデータ構造体
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct CopyDataStruct
		{
			public IntPtr dwData;
			public uint cbData;
			public IntPtr lpData;
		}

		#endregion Structs

		#region Functions

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetParent(IntPtr windowHandle, IntPtr parentValue);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool PostMessage(IntPtr windowHandle, WindowMessage windowMessage, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessageTimeout(
			IntPtr windowHandle, WindowMessage windowMessage, IntPtr wParam, IntPtr lParam, SendMessageTimeoutType timeoutType, uint timeout, out IntPtr result);

		#endregion Functions
	}
}
