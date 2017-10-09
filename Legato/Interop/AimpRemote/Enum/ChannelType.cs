namespace Legato.Interop.AimpRemote.Enum
{
    public enum ChannelType : uint
    {
		/// <summary>
		/// 未定義を表します。
		/// </summary>
        None = 0,

		/// <summary>
		/// モノラルタイプを表します。
		/// </summary>
		Monoral,

		/// <summary>
		/// ステレオタイプを表します。
		/// </summary>
		Stereo,

		/// <summary>
		/// あり得ないタイプを表します。
		/// </summary>
		Exception
	}
}
