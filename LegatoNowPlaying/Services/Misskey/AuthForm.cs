using System;
using System.Windows.Forms;

namespace LegatoNowPlaying.Services.Misskey
{
	public partial class AuthForm : Form
	{
		public delegate void OnComplete(Misq.Me me);

		private OnComplete onComplete;

		public AuthForm(OnComplete onComplete)
		{
			this.onComplete = onComplete;
			InitializeComponent();
		}

		private async void AuthForm_Load(object sender, EventArgs e)
		{
			var app = new Misq.App("https://misskey.xyz", Misskey.Service.appKey);
			var me = await app.Authorize();
			this.Close();
			this.onComplete(me);

			MessageBox.Show(
				$"WELCOME {me.Username}",
				"Done",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
	}
}
