using System;
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

			var app = await Misq.App.Register(
				textBox1.Text, "Legato Nowplaying", "A NowPlaying App for AIMP4", new[] { "write:notes", "write:drive" });
			var me = await app.Authorize();
			this.Close();
			this.onComplete(me, app);

			MessageBox.Show(
				$"WELCOME {me.Username}",
				"Done",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
	}
}
