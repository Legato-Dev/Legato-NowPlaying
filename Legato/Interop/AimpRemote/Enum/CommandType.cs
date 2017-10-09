namespace Legato.Interop.AimpRemote.Enum
{
	/// <summary>
	/// コマンドメッセージの種類を表します
	/// </summary>
	public enum CommandType
	{
		/// <summary>
		/// 通知の登録( value に windowHandle を与えてください)
		/// </summary>
		RegisterNotify = 11,

		/// <summary>
		/// 通知の登録解除( value に windowHandle を与えてください)
		/// </summary>
		UnregisterNotify = 12,

		/// <summary>
		/// 再生
		/// </summary>
		Playing = 13,

		/// <summary>
		/// 再生と一時停止の切り替え
		/// </summary>
		PlayPause = 14,

		/// <summary>
		/// 一時停止
		/// </summary>
		Pausing = 15,

		/// <summary>
		/// 停止
		/// </summary>
		Stopped = 16,

		/// <summary>
		/// 次の曲へ移動
		/// </summary>
		Next = 17,

		/// <summary>
		/// 前の曲へ移動
		/// </summary>
		Previous = 18,

		/// <summary>
		/// AIMPの終了
		/// </summary>
		Quit = 21,

		/// <summary>
		/// アルバムアートの取得(このコマンドは 32bit アプリケーションでのみ動作します)
		/// </summary>
		RequestAlbumArt = 29,
	}
}
