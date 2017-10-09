using Legato.Interop.Win32.Enum;

namespace Legato.Interop.AimpRemote.Enum
{
	/// <summary>
	/// 各種ウィンドウメッセージを示します
	/// </summary>
	public enum AimpWindowMessage : uint
	{
		/// <summary>
		/// コマンドを示すウインドウメッセージです
		/// </summary>
		Command = WindowMessage.USER + 0x75,

		/// <summary>
		/// 通知を示すウインドウメッセージです
		/// </summary>
		Notify = WindowMessage.USER + 0x76,

		/// <summary>
		/// プロパティを示すウインドウメッセージです
		/// </summary>
		Property = WindowMessage.USER + 0x77,
	}
}
