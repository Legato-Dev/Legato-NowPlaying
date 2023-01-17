using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LegatoNowPlaying.Services.Misskey
{
	public partial class AuthForm : Form
	{
		public delegate void OnComplete(Misq.Me me, Misq.App app);

		private OnComplete onComplete;

		public AuthForm(OnComplete onComplete)
		{
			this.onComplete = onComplete;
			InitializeComponent();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			try
			{
				new Uri(textBox1.Text);
			}
			catch(UriFormatException ex)
			{
				MessageBox.Show(
					$"url of target instance is invalid",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			panel1.Visible = false;

			JToken metaRes = await Misq.Core.Request(textBox1.Text, "meta", new Dictionary<string, object> { });
			var versionSource = metaRes.Value<string>("version");
			var versionMajorStr = versionSource.Split('.')[0];

			if (!int.TryParse(versionMajorStr, out int version))
			{
				MessageBox.Show(
					$"invalid format of the Misskey version",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			var permissionsList = new List<string>();

			if (version == 10)
			{
				permissionsList.AddRange(new[] { "note-write", "drive-write" });
			}
			else if (version >= 11)
			{
				permissionsList.AddRange(new[] { "write:notes", "write:drive" });
			}
			else
			{
				MessageBox.Show(
					$"Unsupported the Misskey instance version",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			var app = await Misq.App.Register(
				textBox1.Text, "Legato Nowplaying", "A NowPlaying App for AIMP4", permissionsList);
			var me = await app.Authorize();
			this.Close();
			this.onComplete(me, app);

			MessageBox.Show(
				$"WELCOME @{me.Username}",
				"Done",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
	}
}
