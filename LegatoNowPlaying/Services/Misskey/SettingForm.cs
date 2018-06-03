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
	public partial class SettingForm : Form
	{
		public SettingForm()
		{
			InitializeComponent();
		}

		private async void SettingForm_Load(object sender, EventArgs e)
		{
			var config = await CredentialsJsonFile.LoadAsync();
			this.checkBox1.Checked = config.PostToLtl;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			var config = await CredentialsJsonFile.LoadAsync();
			config.PostToLtl = this.checkBox1.Checked;
			await config.SaveAsync();
			this.Close();
		}
	}
}
