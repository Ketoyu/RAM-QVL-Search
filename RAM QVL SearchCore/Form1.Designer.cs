namespace RAM_QVL_Search
{
	partial class Form1
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
			this.btnPaste = new System.Windows.Forms.Button();
			this.clmVdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmPartNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmSze = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmSsDs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmChp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ClmTmg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmVlt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmSpd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmSpd_3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmDim1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmDim2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmDim4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvQVL = new System.Windows.Forms.ListView();
			this.gbStickSze = new System.Windows.Forms.GroupBox();
			this.gbVdr = new System.Windows.Forms.GroupBox();
			this.gbChp = new System.Windows.Forms.GroupBox();
			this.gbSpd = new System.Windows.Forms.GroupBox();
			this.gbSpd5k = new System.Windows.Forms.GroupBox();
			this.lstSort = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnQry = new System.Windows.Forms.Button();
			this.btnCpy = new System.Windows.Forms.Button();
			this.gbSS_DS = new System.Windows.Forms.GroupBox();
			this.gbTmgs = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// btnPaste
			// 
			this.btnPaste.Location = new System.Drawing.Point(12, 12);
			this.btnPaste.Name = "btnPaste";
			this.btnPaste.Size = new System.Drawing.Size(103, 23);
			this.btnPaste.TabIndex = 0;
			this.btnPaste.Text = "Fill from clipboard";
			this.btnPaste.UseVisualStyleBackColor = true;
			this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
			// 
			// clmVdr
			// 
			this.clmVdr.Text = "Vendor";
			this.clmVdr.Width = 100;
			// 
			// clmPartNo
			// 
			this.clmPartNo.Text = "Part No.";
			this.clmPartNo.Width = 200;
			// 
			// clmSze
			// 
			this.clmSze.Text = "Size";
			this.clmSze.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.clmSze.Width = 80;
			// 
			// clmSsDs
			// 
			this.clmSsDs.Text = "SS/DS";
			this.clmSsDs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.clmSsDs.Width = 50;
			// 
			// clmChp
			// 
			this.clmChp.Text = "Chip Brand";
			this.clmChp.Width = 70;
			// 
			// ClmTmg
			// 
			this.ClmTmg.Text = "Timing";
			this.ClmTmg.Width = 70;
			// 
			// clmVlt
			// 
			this.clmVlt.Text = "Volt.";
			this.clmVlt.Width = 50;
			// 
			// clmSpd
			// 
			this.clmSpd.Text = "Speed";
			this.clmSpd.Width = 50;
			// 
			// clmSpd_3
			// 
			this.clmSpd_3.Text = "Speed (5k)";
			this.clmSpd_3.Width = 70;
			// 
			// clmDim1
			// 
			this.clmDim1.Text = "1 DIMM";
			this.clmDim1.Width = 50;
			// 
			// clmDim2
			// 
			this.clmDim2.Text = "2 DIMM";
			this.clmDim2.Width = 50;
			// 
			// clmDim4
			// 
			this.clmDim4.Text = "4 DIMM";
			this.clmDim4.Width = 50;
			// 
			// lvQVL
			// 
			this.lvQVL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.lvQVL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmVdr,
            this.clmPartNo,
            this.clmSze,
            this.clmSsDs,
            this.clmChp,
            this.ClmTmg,
            this.clmVlt,
            this.clmSpd,
            this.clmSpd_3,
            this.clmDim1,
            this.clmDim2,
            this.clmDim4});
			this.lvQVL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.lvQVL.FullRowSelect = true;
			this.lvQVL.HideSelection = false;
			this.lvQVL.Location = new System.Drawing.Point(12, 41);
			this.lvQVL.MultiSelect = false;
			this.lvQVL.Name = "lvQVL";
			this.lvQVL.Size = new System.Drawing.Size(920, 397);
			this.lvQVL.TabIndex = 1;
			this.lvQVL.UseCompatibleStateImageBehavior = false;
			this.lvQVL.View = System.Windows.Forms.View.Details;
			// 
			// gbStickSze
			// 
			this.gbStickSze.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.gbStickSze.Location = new System.Drawing.Point(151, 456);
			this.gbStickSze.Name = "gbStickSze";
			this.gbStickSze.Size = new System.Drawing.Size(70, 88);
			this.gbStickSze.TabIndex = 3;
			this.gbStickSze.TabStop = false;
			this.gbStickSze.Text = "Stick size";
			// 
			// gbVdr
			// 
			this.gbVdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.gbVdr.Location = new System.Drawing.Point(12, 456);
			this.gbVdr.Name = "gbVdr";
			this.gbVdr.Size = new System.Drawing.Size(72, 88);
			this.gbVdr.TabIndex = 4;
			this.gbVdr.TabStop = false;
			this.gbVdr.Text = "Vendor";
			// 
			// gbChp
			// 
			this.gbChp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.gbChp.Location = new System.Drawing.Point(303, 456);
			this.gbChp.Name = "gbChp";
			this.gbChp.Size = new System.Drawing.Size(92, 88);
			this.gbChp.TabIndex = 5;
			this.gbChp.TabStop = false;
			this.gbChp.Text = "Chip";
			// 
			// gbSpd
			// 
			this.gbSpd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.gbSpd.Location = new System.Drawing.Point(477, 456);
			this.gbSpd.Name = "gbSpd";
			this.gbSpd.Size = new System.Drawing.Size(64, 88);
			this.gbSpd.TabIndex = 6;
			this.gbSpd.TabStop = false;
			this.gbSpd.Text = "Speed";
			// 
			// gbSpd5k
			// 
			this.gbSpd5k.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.gbSpd5k.Location = new System.Drawing.Point(706, 456);
			this.gbSpd5k.Name = "gbSpd5k";
			this.gbSpd5k.Size = new System.Drawing.Size(84, 88);
			this.gbSpd5k.TabIndex = 7;
			this.gbSpd5k.TabStop = false;
			this.gbSpd5k.Text = "Speed (5k)";
			// 
			// lstSort
			// 
			this.lstSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.lstSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.lstSort.FormattingEnabled = true;
			this.lstSort.Items.AddRange(new object[] {
            "Vendor",
            "Stick size",
            "SS / DS",
            "Chip",
            "Timings",
            "Speed",
            "Speed (5k)"});
			this.lstSort.Location = new System.Drawing.Point(859, 472);
			this.lstSort.Name = "lstSort";
			this.lstSort.Size = new System.Drawing.Size(65, 108);
			this.lstSort.TabIndex = 8;
			this.lstSort.Click += new System.EventHandler(this.lstSort_Click);
			this.lstSort.SelectedIndexChanged += new System.EventHandler(this.lstSort_SelectedIndexChanged);
			this.lstSort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstSort_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.label1.Location = new System.Drawing.Point(856, 456);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Sort:";
			// 
			// btnQry
			// 
			this.btnQry.Location = new System.Drawing.Point(859, 582);
			this.btnQry.Name = "btnQry";
			this.btnQry.Size = new System.Drawing.Size(75, 23);
			this.btnQry.TabIndex = 10;
			this.btnQry.Text = "Run query";
			this.btnQry.UseVisualStyleBackColor = true;
			this.btnQry.Click += new System.EventHandler(this.btnQry_Click);
			// 
			// btnCpy
			// 
			this.btnCpy.Location = new System.Drawing.Point(731, 12);
			this.btnCpy.Name = "btnCpy";
			this.btnCpy.Size = new System.Drawing.Size(89, 23);
			this.btnCpy.TabIndex = 11;
			this.btnCpy.Text = "Copy selection";
			this.btnCpy.UseVisualStyleBackColor = true;
			this.btnCpy.Click += new System.EventHandler(this.btnCpy_Click);
			// 
			// gbSS_DS
			// 
			this.gbSS_DS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.gbSS_DS.Location = new System.Drawing.Point(227, 456);
			this.gbSS_DS.Name = "gbSS_DS";
			this.gbSS_DS.Size = new System.Drawing.Size(70, 88);
			this.gbSS_DS.TabIndex = 4;
			this.gbSS_DS.TabStop = false;
			this.gbSS_DS.Text = "SS / DS";
			// 
			// gbTmgs
			// 
			this.gbTmgs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(136)))), ((int)(((byte)(198)))));
			this.gbTmgs.Location = new System.Drawing.Point(401, 456);
			this.gbTmgs.Name = "gbTmgs";
			this.gbTmgs.Size = new System.Drawing.Size(70, 88);
			this.gbTmgs.TabIndex = 5;
			this.gbTmgs.TabStop = false;
			this.gbTmgs.Text = "Timings";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
			this.ClientSize = new System.Drawing.Size(940, 610);
			this.Controls.Add(this.gbTmgs);
			this.Controls.Add(this.gbSS_DS);
			this.Controls.Add(this.btnCpy);
			this.Controls.Add(this.btnQry);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstSort);
			this.Controls.Add(this.gbSpd5k);
			this.Controls.Add(this.gbSpd);
			this.Controls.Add(this.gbChp);
			this.Controls.Add(this.gbVdr);
			this.Controls.Add(this.gbStickSze);
			this.Controls.Add(this.lvQVL);
			this.Controls.Add(this.btnPaste);
			this.Name = "Form1";
			this.Text = "RAM QVL Search";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPaste;
		private System.Windows.Forms.ColumnHeader clmVdr;
		private System.Windows.Forms.ColumnHeader clmPartNo;
		private System.Windows.Forms.ColumnHeader clmSze;
		private System.Windows.Forms.ColumnHeader clmSsDs;
		private System.Windows.Forms.ColumnHeader clmChp;
		private System.Windows.Forms.ColumnHeader ClmTmg;
		private System.Windows.Forms.ColumnHeader clmVlt;
		private System.Windows.Forms.ColumnHeader clmSpd;
		private System.Windows.Forms.ColumnHeader clmSpd_3;
		private System.Windows.Forms.ColumnHeader clmDim1;
		private System.Windows.Forms.ColumnHeader clmDim2;
		private System.Windows.Forms.ColumnHeader clmDim4;
		private System.Windows.Forms.ListView lvQVL;
		private System.Windows.Forms.GroupBox gbStickSze;
		private System.Windows.Forms.GroupBox gbVdr;
		private System.Windows.Forms.GroupBox gbChp;
		private System.Windows.Forms.GroupBox gbSpd;
		private System.Windows.Forms.GroupBox gbSpd5k;
		private System.Windows.Forms.ListBox lstSort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnQry;
		private System.Windows.Forms.Button btnCpy;
		private System.Windows.Forms.GroupBox gbSS_DS;
		private System.Windows.Forms.GroupBox gbTmgs;
	}
}

