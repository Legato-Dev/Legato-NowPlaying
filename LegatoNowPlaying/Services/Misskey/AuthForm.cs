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
			var app = new Misq.App("https://misskey.xyz", Service.appKey);
			var done = await app.Authorize();

			this.button1.Click += async (_1, _2) =>
			{
				var me = await done();

				this.Close();

				this.onComplete(me);
			};
		}
	}
}
