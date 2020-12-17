namespace UI
{
	partial class UserStats
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
			this.Image = new System.Windows.Forms.DataGridViewImageColumn();
			this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// Image
			// 
			this.Image.HeaderText = "Obrázek";
			this.Image.Name = "Image";
			this.Image.ReadOnly = true;
			this.Image.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Image.Width = 75;
			// 
			// Name
			// 
			this.Name.HeaderText = "Jméno";
			this.Name.Name = "Name";
			this.Name.ReadOnly = true;
			this.Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Level
			// 
			this.Level.HeaderText = "Úroveň";
			this.Level.MaxInputLength = 2;
			this.Level.Name = "Level";
			this.Level.ReadOnly = true;
			this.Level.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Level.Width = 50;
			// 
			// Count
			// 
			this.Count.HeaderText = "Počet";
			this.Count.Name = "Count";
			this.Count.ReadOnly = true;
			this.Count.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Count.Width = 45;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Image,
            this.Name,
            this.Level,
            this.Count});
			this.dataGridView1.Location = new System.Drawing.Point(442, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(330, 437);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.Text = "dataGridView1";
			// 
			// Property
			// 
			this.Property.HeaderText = "Vlastnost";
			this.Property.Name = "Property";
			this.Property.ReadOnly = true;
			this.Property.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Property.Width = 250;
			// 
			// Value
			// 
			this.Value.HeaderText = "Hodnota";
			this.Value.Name = "Value";
			this.Value.ReadOnly = true;
			this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Value.Width = 130;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
			this.dataGridView2.Location = new System.Drawing.Point(12, 12);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.Size = new System.Drawing.Size(424, 275);
			this.dataGridView2.TabIndex = 2;
			this.dataGridView2.Text = "dataGridView2";
			// 
			// UserStats
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.dataGridView1);
			this.MaximumSize = new System.Drawing.Size(800, 500);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Text = "UserStats";
			this.Load += new System.EventHandler(this.UserStats_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewImageColumn Image;
		private System.Windows.Forms.DataGridViewTextBoxColumn Name;
		private System.Windows.Forms.DataGridViewTextBoxColumn Level;
		private System.Windows.Forms.DataGridViewTextBoxColumn Count;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Property;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
	}
}