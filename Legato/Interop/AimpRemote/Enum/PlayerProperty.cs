namespace Legato.Interop.AimpRemote.Enum
{
	public enum PlayerProperty : uint
	{
		/* TODO
		/// <summary>
		/// <para>プレイヤーのバージョンを示すプロパティです</para>
		/// </summary>
		Version = 0x10,
		*/

		/// <summary>
		/// <para>再生中の曲の位置を示すプロパティです(単位:ミリ秒)</para>
		/// </summary>
		Position = 0x20,

		/// <summary>
		/// <para>再生中の曲の長さを示すプロパティです(単位:ミリ秒)</para>
		/// </summary>
		Duration = 0x30,

		/// <summary>
		/// <para>曲の再生状態を示すプロパティです</para>
		/// <para>[0:停止中, 1:一時停止中, 2:再生中]</para>
		/// </summary>
		State = 0x40,

		/// <summary>
		/// <para>音量を示すプロパティです(単位:%)</para>
		/// <para>(Get:[lp : 不使用, res:0 - 100])</para>
		/// <para>(Set:[lp : 0-100, res:{0以外 : 成功, 0 : 失敗}])</para>
		/// </summary>
		Volume = 0x50,

		/// <summary>
		/// <para>ミュートを示すプロパティです</para>
		/// <para>(Get : [lp:不使用, res:{0以外 : ミュート, 0:非ミュート}])</para>
		/// <para>(Set : [lp:{0以外:ミュート, 0 : 非ミュート}, res:不使用])</para>
		/// </summary>
		IsMute = 0x60,

		/// <summary>
		/// <para>リピート再生を示すプロパティです</para>
		/// <para>(Get : [lp:不使用, res:{0以外:リピート再生, 0:一巡再生}])</para>
		/// <para>(Set : [lp:{0以外:リピート再生, 0:一巡再生}, res:不使用])</para>
		/// </summary>
		IsRepeat = 0x70,

		/// <summary>
		/// <para>シャッフル再生を示すプロパティです</para>
		/// <para>(Get : [lp : 不使用, res:{0以外:シャッフル再生, 0:順次再生}])</para>
		/// <para>(Set : [lp : {0以外:シャッフル再生, 0:順次再生}, res:不使用])</para>
		/// </summary>
		IsShuffle = 0x80,
	}
}
