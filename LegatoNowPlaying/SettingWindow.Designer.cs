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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.previewLabel = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.UpDownNotifyTime)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxPostingFormat
			// 
			this.textBoxPostingFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPostingFormat.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxPostingFormat.Location = new System.Drawing.Point(6, 26);
			this.textBoxPostingFormat.Multiline = true;
			this.textBoxPostingFormat.Name = "textBoxPostingFormat";
			this.textBoxPostingFormat.Size = new System.Drawing.Size(485, 96);
			this.textBoxPostingFormat.TabIndex = 0;
			this.textBoxPostingFormat.TextChanged += new System.EventHandler(this.textBoxPostingFormat_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(6, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Posting format:";
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOk.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.buttonOk.Location = new System.Drawing.Point(422, 394);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(95, 25);
			this.buttonOk.TabIndex = 2;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(6, 125);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 20);
			this.label2.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.panel1.Location = new System.Drawing.Point(12, 386);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(505, 1);
			this.panel1.TabIndex = 9;
			// 
			// UpDownNotifyTime
			// 
			this.UpDownNotifyTime.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.UpDownNotifyTime.Location = new System.Drawing.Point(94, 242);
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
			this.label3.Location = new System.Drawing.Point(6, 243);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 18);
			this.label3.TabIndex = 11;
			this.label3.Text = "NotifyTime :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(6, 272);
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
			this.textBoxPostSoundPath.Location = new System.Drawing.Point(94, 269);
			this.textBoxPostSoundPath.Name = "textBoxPostSoundPath";
			this.textBoxPostSoundPath.Size = new System.Drawing.Size(397, 25);
			this.textBoxPostSoundPath.TabIndex = 13;
			// 
			// buttonOpenPostSound
			// 
			this.buttonOpenPostSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpenPostSound.Location = new System.Drawing.Point(784, 270);
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
			this.buttonOpenExitSound.Location = new System.Drawing.Point(784, 299);
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
			this.label5.Location = new System.Drawing.Point(9, 301);
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
			this.textBoxExitSoundPath.Location = new System.Drawing.Point(94, 298);
			this.textBoxExitSoundPath.Name = "textBoxExitSoundPath";
			this.textBoxExitSoundPath.Size = new System.Drawing.Size(397, 25);
			this.textBoxExitSoundPath.TabIndex = 17;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(505, 368);
			this.tabControl1.TabIndex = 18;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.previewLabel);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBoxExitSoundPath);
			this.tabPage1.Controls.Add(this.textBoxPostingFormat);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.buttonOpenExitSound);
			this.tabPage1.Controls.Add(this.UpDownNotifyTime);
			this.tabPage1.Controls.Add(this.buttonOpenPostSound);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.textBoxPostSoundPath);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(497, 337);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// previewLabel
			// 
			this.previewLabel.ForeColor = System.Drawing.Color.Navy;
			this.previewLabel.Location = new System.Drawing.Point(290, 146);
			this.previewLabel.Name = "previewLabel";
			this.previewLabel.Size = new System.Drawing.Size(201, 90);
			this.previewLabel.TabIndex = 20;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(290, 128);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(59, 18);
			this.label12.TabIndex = 19;
			this.label12.Text = "Preview:";
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.ForeColor = System.Drawing.Color.DimGray;
			this.textBox1.Location = new System.Drawing.Point(6, 128);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(241, 108);
			this.textBox1.TabIndex = 18;
			this.textBox1.Text = "Available tags:\r\n{Title} : Embed track title\r\n{TrackNum} : Embed track number\r\n{A" +
    "rtist} : Embed artist name\r\n{Album} : Embed album name\r\n";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button3);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Location = new System.Drawing.Point(4, 27);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(497, 337);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Accounts";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label11.Location = new System.Drawing.Point(6, 14);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(485, 2);
			this.label11.TabIndex = 6;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label10.Location = new System.Drawing.Point(6, 100);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(485, 2);
			this.label10.TabIndex = 5;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label9.Location = new System.Drawing.Point(6, 57);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(485, 2);
			this.label9.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 70);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 18);
			this.label7.TabIndex = 3;
			this.label7.Text = "Misskey";
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(73, 67);
			this.button2.Margin = new System.Windows.Forms.Padding(8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(87, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "Connect";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 27);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 18);
			this.label6.TabIndex = 1;
			this.label6.Text = "Twitter";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(73, 24);
			this.button1.Margin = new System.Windows.Forms.Padding(8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(87, 25);
			this.button1.TabIndex = 0;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Location = new System.Drawing.Point(4, 27);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(497, 337);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "About";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(48, 73);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(22, 18);
			this.label8.TabIndex = 0;
			this.label8.Text = "Yo";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(406, 67);
			this.button3.Margin = new System.Windows.Forms.Padding(8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(80, 25);
			this.button3.TabIndex = 7;
			this.button3.Text = "Setting";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// SettingWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(529, 431);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.buttonOk);
			this.MaximumSize = new System.Drawing.Size(1024, 470);
			this.MinimumSize = new System.Drawing.Size(322, 470);
			this.Name = "SettingWindow";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.UpDownNotifyTime)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.Label previewLabel;
	private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button button3;
	}
}