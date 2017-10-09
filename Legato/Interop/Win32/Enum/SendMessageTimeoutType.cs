namespace Legato.Interop.Win32.Enum
{
	[System.Flags]
	public enum SendMessageTimeoutType : uint
	{
		NORMAL = 0x0,
		BLOCK = 0x1,
		ABORTIFHUNG = 0x2,
		NOTIMEOUTIFNOTHUNG = 0x8,
		ERRORONEXIT = 0x20
	}
}
