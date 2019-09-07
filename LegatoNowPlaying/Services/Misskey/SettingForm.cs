using System;
using System.Windows.Forms;

namespace LegatoNowPlaying.Services.Misskey
{
	public partial class SettingForm : Form
	{
		public SettingForm(CredentialsJsonFile config)
		{
			InitializeComponent();

			this.Config = config;

			this.checkBox1.Checked = config.PostToLtl;
		}

		private CredentialsJsonFile Config;

		// save button
		private async void button1_Click(object sender, EventArgs e)
		{
			this.Config.PostToLtl = this.checkBox1.Checked;
			await this.Config.SaveAsync();

			this.Close();
		}
	}
}
