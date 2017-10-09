namespace Legato.Interop.AimpRemote.Enum
{
	/// <summary>
	/// 音楽プレーヤーの再生状態を定義します
	/// </summary>
	public enum PlayerState : uint
	{
		/// <summary>
		/// 音楽プレーヤーの再生状態は不明です
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 音楽プレーヤーは停止中です
		/// </summary>
		Stopped,

		/// <summary>
		/// 音楽プレーヤーは再生中です
		/// </summary>
		Playing,

		/// <summary>
		/// 音楽プレーヤーは一時停止中です
		/// </summary>
		Paused,

		/// <summary>
		/// 音楽プレーヤーは早送り中です
		/// </summary>
		FastForward,

		/// <summary>
		/// 音楽プレーヤーは巻き戻し中です
		/// </summary>
		Rewind,

		/// <summary>
		/// 音楽プレーヤーは逆再生中です
		/// </summary>
		PlayingReverse
	}
}
