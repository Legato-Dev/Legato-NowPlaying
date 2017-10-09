using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Legato.AlbumArtExtraction
{
	/// <summary>
	/// ディレクトリからアルバムアートを抽出する機能を表します
	/// </summary>
	public class DirectoryAlbumArtExtractor : IAlbumArtExtractor
	{
		/// <summary>
		/// アルバムアートのようなファイル名のFileInfo一覧を取得します
		/// </summary>
		/// <param name="directoryFiles"></param>
		private IEnumerable<FileInfo> _GetFilesLikeAlbumArts(DirectoryInfo directory) =>
			from i in directory.GetFiles()
			where i.Extension == ".png" || i.Extension == ".jpeg" || i.Extension == ".jpg" || i.Extension == ".bmp"
			where i.Name.IndexOf(Path.GetFileNameWithoutExtension(i.Name)) != -1 || i.Name.IndexOf("folder") != -1 || i.Name.IndexOf("front") != -1 || i.Name.IndexOf("cover") != -1
			orderby i.Length descending
			select i;

		/// <summary>
		/// 対象のファイルが形式と一致しているかを判別します
		/// </summary>
		public bool CheckType(string filePath) => _GetFilesLikeAlbumArts(new FileInfo(filePath).Directory).Count() != 0;

		/// <summary>
		/// アルバムアートを抽出します
		/// </summary>
		public Image Extract(string filePath)
		{
			var fileInfo = _GetFilesLikeAlbumArts(new FileInfo(filePath).Directory).ElementAt(0);
			return Image.FromFile(fileInfo.FullName);
		}
	}
}
