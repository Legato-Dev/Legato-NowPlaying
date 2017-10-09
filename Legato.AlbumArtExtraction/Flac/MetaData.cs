using System.Collections.Generic;

namespace Legato.AlbumArtExtraction.Flac
{
	public class MetaData
	{
		public MetaData(MetaDataType type, bool isLast, List<byte> data)
		{
			Type = type;
			IsLast = isLast;
			Data = data;
		}

		public MetaDataType Type { get; set; }

		public bool IsLast { get; set; }

		public List<byte> Data { get; set; }

		public override string ToString() => $"FlacMetaData {{ Type = {Type}, IsLast = {IsLast}, DataSize = {Data.Count} }}";
	}
}
