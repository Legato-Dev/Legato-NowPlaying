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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingWindow));
			this.buttonOk = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.UpDownNotifyTime = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.previewLabel = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxPostingFormat = new System.Windows.Forms.TextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label13 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.servicesListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.versionLabel = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.licenseLinkLabel = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.UpDownNotifyTime)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			resources.ApplyResources(this.buttonOk, "buttonOk");
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.panel1.Name = "panel1";
			// 
			// UpDownNotifyTime
			// 
			resources.ApplyResources(this.UpDownNotifyTime, "UpDownNotifyTime");
			this.UpDownNotifyTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.UpDownNotifyTime.Name = "UpDownNotifyTime";
			this.UpDownNotifyTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// tabControl1
			// 
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.previewLabel);
			this.tabPage4.Controls.Add(this.label12);
			this.tabPage4.Controls.Add(this.textBox1);
			this.tabPage4.Controls.Add(this.label1);
			this.tabPage4.Controls.Add(this.textBoxPostingFormat);
			resources.ApplyResources(this.tabPage4, "tabPage4");
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// previewLabel
			// 
			resources.ApplyResources(this.previewLabel, "previewLabel");
			this.previewLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.previewLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.previewLabel.ForeColor = System.Drawing.Color.Navy;
			this.previewLabel.Name = "previewLabel";
			// 
			// label12
			// 
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			// 
			// textBox1
			// 
			resources.ApplyResources(this.textBox1, "textBox1");
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.ForeColor = System.Drawing.Color.DimGray;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// textBoxPostingFormat
			// 
			resources.ApplyResources(this.textBoxPostingFormat, "textBoxPostingFormat");
			this.textBoxPostingFormat.Name = "textBoxPostingFormat";
			this.textBoxPostingFormat.TextChanged += new System.EventHandler(this.textBoxPostingFormat_TextChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.checkBox1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.UpDownNotifyTime);
			this.tabPage1.Controls.Add(this.label3);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			resources.ApplyResources(this.checkBox1, "checkBox1");
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.button6);
			this.tabPage2.Controls.Add(this.button5);
			this.tabPage2.Controls.Add(this.button4);
			this.tabPage2.Controls.Add(this.servicesListView);
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label13.Name = "label13";
			// 
			// button6
			// 
			resources.ApplyResources(this.button6, "button6");
			this.button6.Name = "button6";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			resources.ApplyResources(this.button5, "button5");
			this.button5.Name = "button5";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			resources.ApplyResources(this.button4, "button4");
			this.button4.Name = "button4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// servicesListView
			// 
			resources.ApplyResources(this.servicesListView, "servicesListView");
			this.servicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.servicesListView.FullRowSelect = true;
			this.servicesListView.GridLines = true;
			this.servicesListView.HideSelection = false;
			this.servicesListView.MultiSelect = false;
			this.servicesListView.Name = "servicesListView";
			this.servicesListView.UseCompatibleStateImageBehavior = false;
			this.servicesListView.View = System.Windows.Forms.View.Details;
			this.servicesListView.SelectedIndexChanged += new System.EventHandler(this.servicesListView_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			resources.ApplyResources(this.columnHeader1, "columnHeader1");
			// 
			// columnHeader2
			// 
			resources.ApplyResources(this.columnHeader2, "columnHeader2");
			// 
			// columnHeader3
			// 
			resources.ApplyResources(this.columnHeader3, "columnHeader3");
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.versionLabel);
			this.tabPage3.Controls.Add(this.label8);
			resources.ApplyResources(this.tabPage3, "tabPage3");
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// versionLabel
			// 
			resources.ApplyResources(this.versionLabel, "versionLabel");
			this.versionLabel.Name = "versionLabel";
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// licenseLinkLabel
			// 
			resources.ApplyResources(this.licenseLinkLabel, "licenseLinkLabel");
			this.licenseLinkLabel.Name = "licenseLinkLabel";
			this.licenseLinkLabel.TabStop = true;
			this.licenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.licenseLinkLabel_LinkClicked);
			// 
			// SettingWindow
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.licenseLinkLabel);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.buttonOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Load += new System.EventHandler(this.SettingWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.UpDownNotifyTime)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.NumericUpDown UpDownNotifyTime;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.LinkLabel licenseLinkLabel;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.ListView servicesListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxPostingFormat;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label previewLabel;
	}
}
