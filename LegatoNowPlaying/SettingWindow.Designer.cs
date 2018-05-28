namespace LegatoNowPlaying
{
	partial class SettingWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxPostingFormat = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonOk = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.UpDownNotifyTime = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxPostSoundPath = new System.Windows.Forms.TextBox();
			this.buttonOpenPostSound = new System.Windows.Forms.Button();
			this.buttonOpenExitSound = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxExitSoundPath = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.UpDownNotifyTime)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxPostingFormat
			// 
			this.textBoxPostingFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPostingFormat.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxPostingFormat.Location = new System.Drawing.Point(12, 32);
			this.textBoxPostingFormat.Multiline = true;
			this.textBoxPostingFormat.Name = "textBoxPostingFormat";
			this.textBoxPostingFormat.Size = new System.Drawing.Size(490, 96);
			this.textBoxPostingFormat.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Posting format:";
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.buttonOk.Location = new System.Drawing.Point(407, 357);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(95, 23);
			this.buttonOk.TabIndex = 2;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(12, 131);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(236, 100);
			this.label2.TabIndex = 3;
			this.label2.Text = "Available tags:\r\n{Title} : Embed track title\r\n{TrackNum} : Embed track number\r\n{A" +
    "rtist} : Embed artist name\r\n{Album} : Embed album name\r\n";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.panel1.Location = new System.Drawing.Point(12, 346);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(490, 1);
			this.panel1.TabIndex = 9;
			// 
			// UpDownNotifyTime
			// 
			this.UpDownNotifyTime.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.UpDownNotifyTime.Location = new System.Drawing.Point(100, 248);
			this.UpDownNotifyTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.UpDownNotifyTime.Name = "UpDownNotifyTime";
			this.UpDownNotifyTime.Size = new System.Drawing.Size(120, 24);
			this.UpDownNotifyTime.TabIndex = 10;
			this.UpDownNotifyTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(12, 249);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 18);
			this.label3.TabIndex = 11;
			this.label3.Text = "NotifyTime :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(12, 278);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 18);
			this.label4.TabIndex = 12;
			this.label4.Text = "Post Sound :";
			// 
			// textBoxPostSoundPath
			// 
			this.textBoxPostSoundPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPostSoundPath.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxPostSoundPath.Location = new System.Drawing.Point(100, 275);
			this.textBoxPostSoundPath.Name = "textBoxPostSoundPath";
			this.textBoxPostSoundPath.Size = new System.Drawing.Size(363, 25);
			this.textBoxPostSoundPath.TabIndex = 13;
			// 
			// buttonOpenPostSound
			// 
			this.buttonOpenPostSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpenPostSound.Location = new System.Drawing.Point(469, 276);
			this.buttonOpenPostSound.Name = "buttonOpenPostSound";
			this.buttonOpenPostSound.Size = new System.Drawing.Size(33, 23);
			this.buttonOpenPostSound.TabIndex = 14;
			this.buttonOpenPostSound.Text = "...";
			this.buttonOpenPostSound.UseVisualStyleBackColor = true;
			this.buttonOpenPostSound.Click += new System.EventHandler(this.buttonOpenPostSound_Click);
			// 
			// buttonOpenExitSound
			// 
			this.buttonOpenExitSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpenExitSound.Location = new System.Drawing.Point(469, 305);
			this.buttonOpenExitSound.Name = "buttonOpenExitSound";
			this.buttonOpenExitSound.Size = new System.Drawing.Size(33, 23);
			this.buttonOpenExitSound.TabIndex = 15;
			this.buttonOpenExitSound.Text = "...";
			this.buttonOpenExitSound.UseVisualStyleBackColor = true;
			this.buttonOpenExitSound.Click += new System.EventHandler(this.buttonOpenExitSound_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.Location = new System.Drawing.Point(15, 307);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 18);
			this.label5.TabIndex = 16;
			this.label5.Text = "Exit Sound :";
			// 
			// textBoxExitSoundPath
			// 
			this.textBoxExitSoundPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExitSoundPath.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxExitSoundPath.Location = new System.Drawing.Point(100, 304);
			this.textBoxExitSoundPath.Name = "textBoxExitSoundPath";
			this.textBoxExitSoundPath.Size = new System.Drawing.Size(363, 25);
			this.textBoxExitSoundPath.TabIndex = 17;
			// 
			// SettingWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 392);
			this.Controls.Add(this.textBoxExitSoundPath);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.buttonOpenExitSound);
			this.Controls.Add(this.buttonOpenPostSound);
			this.Controls.Add(this.textBoxPostSoundPath);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.UpDownNotifyTime);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxPostingFormat);
			this.MaximumSize = new System.Drawing.Size(1024, 430);
			this.MinimumSize = new System.Drawing.Size(322, 430);
			this.Name = "SettingWindow";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.UpDownNotifyTime)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxPostingFormat;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.NumericUpDown UpDownNotifyTime;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxPostSoundPath;
		private System.Windows.Forms.Button buttonOpenPostSound;
		private System.Windows.Forms.Button buttonOpenExitSound;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxExitSoundPath;
	}
}