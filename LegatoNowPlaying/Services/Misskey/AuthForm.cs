using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			var app = new Misq.App("https://misskey.xyz", "z31SlkbuIonQ5G1tdx4j7xvGRL7XS51y");
			var done = await app.Authorize();
			Console.WriteLine(done);

			this.button1.Click += async (_1, _2) =>
			{
				var me = await done();

				this.Close();

				this.onComplete(me);
			};
		}
	}
}
