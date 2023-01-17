using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegatoNowPlaying
{
	public class Accounts
	{
		public List<Services.Service> Services { get; set; } = new List<Services.Service>();

		public async void Init()
		{
			this.Services.Add(new Services.Misskey.Service());
			this.Services.Add(new Services.Twitter.Service());

			for (var i = 0; i < this.Services.Count; i++)
			{
				try
				{
					await this.Services[i].Setup();
				}
				catch
				{
					MessageBox.Show(
						$"サービス「{this.Services[i].Name}」の設定ファイル読込み時にエラーが発生しました。\r\n" +
						$"サービス「{this.Services[i].Name}」は無効化されます。\r\n" +
						"設定ファイルが古い形式で保存されている等が考えられるため、設定ファイルを削除して再設定すると問題が解決する可能性があります。",
						"エラー",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);

					this.Services.RemoveAt(i);
					i--;
				}
			}
		}

		public async Task Post(string text, Image albumArt)
		{
			foreach (var service in this.Services)
			{
				if (service.Enabled && service.IsInstalled)
				{
					try
					{
						await service.Post(text, albumArt);
						Console.WriteLine($"{service.Name} への投稿が完了しました");
					}
					catch (Exception ex)
					{
						Console.Error.WriteLine(ex.Message);
					}
				}
			}
		}
	}
}
