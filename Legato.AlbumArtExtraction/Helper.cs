using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Legato.AlbumArtExtraction
{
	public static class Helper
	{
		public static void Skip(Stream stream, int skip)
		{
			if (skip > 0)
				stream.Seek(skip, SeekOrigin.Current);
		}

		/// <summary>
		/// 指定した長さのデータを List<byte> として読み取ります
		/// </summary>
		/// <param name="stream">対象の Stream</param>
		/// <param name="count">読み取るデータの長さ(バイト数)</param>
		/// <param name="skip">読み飛ばす長さ(バイト数)</param>
		public static List<byte> ReadAsByteList(Stream stream, int count, int skip = 0)
		{
			Skip(stream, skip);
			var buf = new byte[count];
			stream.Read(buf, 0, count);

			return new List<byte>(buf);
		}

		/// <summary>
		/// byte(1 Bytes) として読み取ります
		/// </summary>
		/// <param name="stream">対象の Stream</param>
		/// <param name="skip">読み飛ばす長さ(バイト数)</param>
		public static byte ReadAsByte(Stream stream, int skip = 0) =>
			ReadAsByteList(stream, 1, skip)[0];

		private static byte[] _ReadAsUIntBase(int limit, Stream stream, int count, int skip = 0)
		{
			if (count < 1 || count > limit)
				throw new ArgumentOutOfRangeException("count");

			var buf = ReadAsByteList(stream, count, skip);
			foreach (var i in Enumerable.Range(0, limit - count))
				buf.Insert(0, 0);
			buf.Reverse();

			return buf.ToArray();
		}

		/// <summary>
		/// 指定した長さのデータを ushort(2 Bytes) として読み取ります(ビッグエンディアン)
		/// </summary>
		/// <param name="stream">対象の Stream</param>
		/// <param name="count">読み取るデータの長さ(バイト数) 範囲: 1-2</param>
		/// <param name="skip">読み飛ばす長さ(バイト数)</param>
		/// <exception cref="ArgumentOutOfRangeException" />
		public static ushort ReadAsUShort(Stream stream, int count = 2, int skip = 0) =>
			BitConverter.ToUInt16(_ReadAsUIntBase(2, stream, count, skip), 0);

		/// <summary>
		/// 指定した長さのデータを uint(4 Bytes) として読み取ります(ビッグエンディアン)
		/// </summary>
		/// <param name="stream">対象の Stream</param>
		/// <param name="count">読み取るデータの長さ(バイト数) 範囲: 1-4</param>
		/// <param name="skip">読み飛ばす長さ(バイト数)</param>
		/// <exception cref="ArgumentOutOfRangeException" />
		public static uint ReadAsUInt(Stream stream, int count = 4, int skip = 0) =>
			BitConverter.ToUInt32(_ReadAsUIntBase(4, stream, count, skip), 0);

		/// <summary>
		/// ASCII文字列として指定されたカウント数だけ読み取ります
		/// </summary>
		public static string ReadAsAsciiString(Stream stream, int count, int skip = 0)
		{
			Skip(stream, skip);
			var buf = new byte[count];
			stream.Read(buf, 0, count);

			return new string(Encoding.ASCII.GetChars(buf));
		}
	}
}
