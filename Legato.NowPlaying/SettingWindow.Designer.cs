namespace Legato.NowPlaying
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
			this.VoicePath = new System.Windows.Forms.TextBox();
			this.VoiceSetting = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
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
			this.buttonOk.Location = new System.Drawing.Point(378, 314);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(124, 23);
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
			this.panel1.Location = new System.Drawing.Point(12, 303);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(490, 1);
			this.panel1.TabIndex = 9;
			// 
			// UpDownNotifyTime
			// 
			this.UpDownNotifyTime.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.UpDownNotifyTime.Location = new System.Drawing.Point(105, 249);
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
			this.label3.Location = new System.Drawing.Point(13, 250);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 18);
			this.label3.TabIndex = 11;
			this.label3.Text = "NotifyTime : ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(13, 278);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 18);
			this.label4.TabIndex = 12;
			this.label4.Text = "VoiceFile : ";
			// 
			// VoicePath
			// 
			this.VoicePath.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.VoicePath.Location = new System.Drawing.Point(105, 275);
			this.VoicePath.Name = "VoicePath";
			this.VoicePath.Size = new System.Drawing.Size(397, 25);
			this.VoicePath.TabIndex = 13;
			// 
			// VoiceSetting
			// 
			this.VoiceSetting.Location = new System.Drawing.Point(248, 314);
			this.VoiceSetting.Name = "VoiceSetting";
			this.VoiceSetting.Size = new System.Drawing.Size(124, 23);
			this.VoiceSetting.TabIndex = 14;
			this.VoiceSetting.Text = "voice setting";
			this.VoiceSetting.UseVisualStyleBackColor = true;
			this.VoiceSetting.Click += new System.EventHandler(this.VoiceSetting_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// SettingWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 349);
			this.Controls.Add(this.VoiceSetting);
			this.Controls.Add(this.VoicePath);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.UpDownNotifyTime);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxPostingFormat);
			this.MinimumSize = new System.Drawing.Size(322, 324);
			this.Name = "SettingWindow";
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
		private System.Windows.Forms.TextBox VoicePath;
		private System.Windows.Forms.Button VoiceSetting;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}