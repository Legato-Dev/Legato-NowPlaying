using Legato.Interop.AimpRemote.Enum;

namespace Legato.Interop.AimpRemote.Entities
{
    /// <summary>
    /// 再生中のトラック情報を扱います。
    /// </summary>
    public class TrackInfo
    {
        /// <summary>
        /// 再生中の曲のビットレートを取得・設定します。
        /// </summary>
        public uint BitRate { get; set; }

		/// <summary>
		/// 音源の出力タイプを取得・設定します。
		/// </summary>
		public ChannelType ChannelType { get; set; }

		/// <summary>
		/// 再生中の曲の長さを取得・設定します。
		/// </summary>
		public uint Duration { get; set; }

        /// <summary>
        /// 再生中の曲のファイルサイズを取得・設定します。
        /// </summary>
        public ulong FileSize { get; set; }

        /// <summary>
        /// 再生中の曲のサンプルレートを取得・設定します。
        /// </summary>
        public uint SampleRate { get; set; }

        /// <summary>
        /// 再生中の曲順を取得・設定します。
        /// </summary>
        public uint TrackNumber { get; set; }

		/// <summary>
		/// 再生中の曲のアルバム情報を取得・設定します。
		/// </summary>
		public string Album { get; set; }

		/// <summary>
		/// 再生中の曲のアーティスト名を取得・設定します。
		/// </summary>
		public string Artist { get; set; }

		/// <summary>
		/// 再生中の曲のリリース年を取得・設定します。
		/// </summary>
		public string Year { get; set; }

		/// <summary>
		/// 再生中の曲のファイルパスを取得・設定します。
		/// </summary>
		public string FilePath { get; set; }

		/// <summary>
		/// 再生中の曲のジャンルを取得・設定します。
		/// </summary>
		public string Genre { get; set; }

		/// <summary>
		/// 再生中の曲名を取得・設定します。
		/// </summary>
		public string Title { get; set; }
    }
}