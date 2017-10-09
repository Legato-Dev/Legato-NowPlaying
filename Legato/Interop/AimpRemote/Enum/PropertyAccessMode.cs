namespace Legato.Interop.AimpRemote.Enum
{
	[System.Flags]
	public enum PropertyAccessMode : uint
	{
		/// <summary>
		/// プロパティを取得することを示す値
		/// </summary>
		Get = 0,

		/// <summary>
		/// プロパティを設定することを示す値
		/// </summary>
		Set = 1,
	}
}
