using Legato.Interop.AimpRemote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegatoNowPlaying
{
  public static class Common
  {
		public static string ComposeText(string pattern, TrackInfo track)
		{
			var stringBuilder = new StringBuilder(pattern);
			stringBuilder = stringBuilder.Replace("{Title}", "{0}");
			stringBuilder = stringBuilder.Replace("{Artist}", "{1}");
			stringBuilder = stringBuilder.Replace("{Album}", "{2}");
			stringBuilder = stringBuilder.Replace("{TrackNum}", "{3:D2}");
			return string.Format(stringBuilder.ToString(), track.Title, track.Artist, track.Album, track.TrackNumber);
		}
  }
}
