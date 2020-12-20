namespace UI
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.toolStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.button3 = new System.Windows.Forms.Button();
			this.playerStatsButton = new System.Windows.Forms.Button();
			this.findPlayerButton = new System.Windows.Forms.Button();
			this.findClanButton = new System.Windows.Forms.Button();
			this.clanTagTextBox = new System.Windows.Forms.TextBox();
			this.playerTagTextBox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(12, 30);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(236, 439);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(254, 30);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(218, 352);
			this.textBox1.TabIndex = 2;
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.toolStripComboBox2});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(484, 27);
			this.menuStrip1.TabIndex = 4;
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.Items.AddRange(new object[] {
            "Všechny",
            "Aktivní v CW",
            "Neaktivní v CW"});
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
			this.toolStripComboBox1.Text = "Koho zobrazit";
			// 
			// toolStripComboBox2
			// 
			this.toolStripComboBox2.Items.AddRange(new object[] {
            "Podle pohárků",
            "Podle úrovně",
            "Podle jména",
            "Podle pořadí v klanu",
            "Podle donations sent",
            "Podle donations got",
            "Podle bodů slávy získané v CW",
            "Podle bodů oprav získané v CW",
            "Podle počtu útoků na lodě"});
			this.toolStripComboBox2.Name = "toolStripComboBox2";
			this.toolStripComboBox2.Size = new System.Drawing.Size(170, 23);
			this.toolStripComboBox2.Text = "V jakém pořadí";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(302, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Aktualizovat";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// toolStripComboBox3
			// 
			this.toolStripComboBox3.Name = "toolStripComboBox3";
			this.toolStripComboBox3.Size = new System.Drawing.Size(121, 23);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 23);
			this.toolStripMenuItem1.Text = "toolStripMenuItem1";
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Blue;
			this.button3.ForeColor = System.Drawing.Color.White;
			this.button3.Location = new System.Drawing.Point(408, 2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(69, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Facebook";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// playerStatsButton
			// 
			this.playerStatsButton.Location = new System.Drawing.Point(254, 446);
			this.playerStatsButton.Name = "playerStatsButton";
			this.playerStatsButton.Size = new System.Drawing.Size(218, 23);
			this.playerStatsButton.TabIndex = 6;
			this.playerStatsButton.Text = "Zobrazit složku hráče s informacemi";
			this.playerStatsButton.UseVisualStyleBackColor = true;
			this.playerStatsButton.Visible = false;
			this.playerStatsButton.Click += new System.EventHandler(this.showMorePlayerInfoButton_Click);
			// 
			// findPlayerButton
			// 
			this.findPlayerButton.Location = new System.Drawing.Point(393, 417);
			this.findPlayerButton.Name = "findPlayerButton";
			this.findPlayerButton.Size = new System.Drawing.Size(79, 23);
			this.findPlayerButton.TabIndex = 6;
			this.findPlayerButton.Text = "Najdi hráče";
			this.findPlayerButton.UseVisualStyleBackColor = true;
			this.findPlayerButton.Click += new System.EventHandler(this.findPlayerButton_Click);
			// 
			// findClanButton
			// 
			this.findClanButton.Location = new System.Drawing.Point(393, 388);
			this.findClanButton.Name = "findClanButton";
			this.findClanButton.Size = new System.Drawing.Size(79, 23);
			this.findClanButton.TabIndex = 6;
			this.findClanButton.Text = "Najdi clan";
			this.findClanButton.UseVisualStyleBackColor = true;
			this.findClanButton.Click += new System.EventHandler(this.findClanButton_Click);
			// 
			// clanTagTextBox
			// 
			this.clanTagTextBox.Location = new System.Drawing.Point(254, 388);
			this.clanTagTextBox.MaxLength = 8;
			this.clanTagTextBox.Name = "clanTagTextBox";
			this.clanTagTextBox.Size = new System.Drawing.Size(133, 23);
			this.clanTagTextBox.TabIndex = 7;
			this.clanTagTextBox.Text = "9UU2Y92J";
			this.clanTagTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// playerTagTextBox
			// 
			this.playerTagTextBox.Location = new System.Drawing.Point(254, 418);
			this.playerTagTextBox.Name = "playerTagTextBox";
			this.playerTagTextBox.Size = new System.Drawing.Size(133, 23);
			this.playerTagTextBox.TabIndex = 7;
			this.playerTagTextBox.Text = "QVJ2JVQ2";
			this.playerTagTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 481);
			this.Controls.Add(this.playerTagTextBox);
			this.Controls.Add(this.clanTagTextBox);
			this.Controls.Add(this.findClanButton);
			this.Controls.Add(this.findPlayerButton);
			this.Controls.Add(this.playerStatsButton);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.listBox1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(500, 520);
			this.MinimumSize = new System.Drawing.Size(500, 520);
			this.Name = "Form1";
			this.Text = "UnknownClanTagError - Statistics";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button playerStatsButton;
		private System.Windows.Forms.Button findPlayerButton;
		private System.Windows.Forms.Button findClanButton;
		private System.Windows.Forms.TextBox clanTagTextBox;
		private System.Windows.Forms.TextBox playerTagTextBox;
	}
}

