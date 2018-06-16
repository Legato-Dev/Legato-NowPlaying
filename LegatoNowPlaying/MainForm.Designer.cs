namespace LegatoNowPlaying
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.buttonPostNowPlaying = new System.Windows.Forms.Button();
			this.pictureBoxAlbumArt = new System.Windows.Forms.PictureBox();
			this.labelTrackNumber = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelArtist = new System.Windows.Forms.Label();
			this.labelAlbum = new System.Windows.Forms.Label();
			this.checkBoxNeedAlbumArt = new System.Windows.Forms.CheckBox();
			this.checkBoxAutoPosting = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonShowSettingWindow = new System.Windows.Forms.Button();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonPostNowPlaying
			// 
			resources.ApplyResources(this.buttonPostNowPlaying, "buttonPostNowPlaying");
			this.buttonPostNowPlaying.Name = "buttonPostNowPlaying";
			this.buttonPostNowPlaying.UseVisualStyleBackColor = true;
			this.buttonPostNowPlaying.Click += new System.EventHandler(this.buttonPostNowPlaying_Click);
			// 
			// pictureBoxAlbumArt
			// 
			resources.ApplyResources(this.pictureBoxAlbumArt, "pictureBoxAlbumArt");
			this.pictureBoxAlbumArt.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxAlbumArt.Name = "pictureBoxAlbumArt";
			this.pictureBoxAlbumArt.TabStop = false;
			this.pictureBoxAlbumArt.Click += new System.EventHandler(this.pictureBoxAlbumArt_Click);
			// 
			// labelTrackNumber
			// 
			resources.ApplyResources(this.labelTrackNumber, "labelTrackNumber");
			this.labelTrackNumber.Name = "labelTrackNumber";
			// 
			// labelTitle
			// 
			resources.ApplyResources(this.labelTitle, "labelTitle");
			this.labelTitle.AutoEllipsis = true;
			this.labelTitle.ForeColor = System.Drawing.Color.Teal;
			this.labelTitle.Name = "labelTitle";
			// 
			// labelArtist
			// 
			resources.ApplyResources(this.labelArtist, "labelArtist");
			this.labelArtist.AutoEllipsis = true;
			this.labelArtist.Name = "labelArtist";
			// 
			// labelAlbum
			// 
			resources.ApplyResources(this.labelAlbum, "labelAlbum");
			this.labelAlbum.AutoEllipsis = true;
			this.labelAlbum.Name = "labelAlbum";
			// 
			// checkBoxNeedAlbumArt
			// 
			resources.ApplyResources(this.checkBoxNeedAlbumArt, "checkBoxNeedAlbumArt");
			this.checkBoxNeedAlbumArt.Name = "checkBoxNeedAlbumArt";
			this.checkBoxNeedAlbumArt.UseVisualStyleBackColor = true;
			// 
			// checkBoxAutoPosting
			// 
			resources.ApplyResources(this.checkBoxAutoPosting, "checkBoxAutoPosting");
			this.checkBoxAutoPosting.Name = "checkBoxAutoPosting";
			this.checkBoxAutoPosting.UseVisualStyleBackColor = true;
			this.checkBoxAutoPosting.CheckedChanged += new System.EventHandler(this.checkBoxAutoPosting_CheckedChanged);
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.panel1.Name = "panel1";
			// 
			// buttonShowSettingWindow
			// 
			resources.ApplyResources(this.buttonShowSettingWindow, "buttonShowSettingWindow");
			this.buttonShowSettingWindow.Name = "buttonShowSettingWindow";
			this.buttonShowSettingWindow.UseVisualStyleBackColor = true;
			this.buttonShowSettingWindow.Click += new System.EventHandler(this.buttonShowSettingWindow_Click);
			// 
			// notifyIcon
			// 
			resources.ApplyResources(this.notifyIcon, "notifyIcon");
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonShowSettingWindow);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.checkBoxAutoPosting);
			this.Controls.Add(this.checkBoxNeedAlbumArt);
			this.Controls.Add(this.labelAlbum);
			this.Controls.Add(this.labelArtist);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.labelTrackNumber);
			this.Controls.Add(this.pictureBoxAlbumArt);
			this.Controls.Add(this.buttonPostNowPlaying);
			this.Name = "MainForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumArt)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonPostNowPlaying;
		private System.Windows.Forms.PictureBox pictureBoxAlbumArt;
		private System.Windows.Forms.Label labelTrackNumber;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelArtist;
		private System.Windows.Forms.Label labelAlbum;
		private System.Windows.Forms.CheckBox checkBoxNeedAlbumArt;
		private System.Windows.Forms.CheckBox checkBoxAutoPosting;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonShowSettingWindow;
		private System.Windows.Forms.NotifyIcon notifyIcon;
	}
}

