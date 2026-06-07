using System;
using System.Windows.Forms;

namespace LegatoNowPlaying.Services.Misskey
{
	public partial class SettingForm : Form
	{
		public SettingForm(CredentialsJsonFile config)
		{
			InitializeComponent();

			Config = config;

			comboBox1.SelectedIndex = Config.VisibilityIndex.Value;
		}

		private CredentialsJsonFile Config;

		// save button
		private async void button1_Click(object sender, EventArgs e)
		{
			Config.VisibilityIndex = comboBox1.SelectedIndex;
			await Config.SaveAsync();

			this.Close();
		}
	}
}
