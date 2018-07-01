namespace Moving_Averages
{
	partial class MainForm
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
			this.lbxDataSets = new System.Windows.Forms.ListBox();
			this.btnCalculateAll = new System.Windows.Forms.Button();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.sfdSave = new System.Windows.Forms.SaveFileDialog();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.lbxValues = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nudValue = new System.Windows.Forms.NumericUpDown();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnRemoveValue = new System.Windows.Forms.Button();
			this.nudWindowSize = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnAddValue = new System.Windows.Forms.Button();
			this.btnUpdateValue = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWindowSize)).BeginInit();
			this.SuspendLayout();
			// 
			// lbxDataSets
			// 
			this.lbxDataSets.DisplayMember = "name";
			this.lbxDataSets.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbxDataSets.FormattingEnabled = true;
			this.lbxDataSets.ItemHeight = 16;
			this.lbxDataSets.Location = new System.Drawing.Point(0, 0);
			this.lbxDataSets.Name = "lbxDataSets";
			this.lbxDataSets.Size = new System.Drawing.Size(143, 482);
			this.lbxDataSets.TabIndex = 0;
			this.lbxDataSets.TabStop = false;
			this.lbxDataSets.ValueMember = "name";
			this.lbxDataSets.SelectedIndexChanged += new System.EventHandler(this.lbxDataSets_SelectedIndexChanged);
			// 
			// btnCalculateAll
			// 
			this.btnCalculateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCalculateAll.Location = new System.Drawing.Point(494, 434);
			this.btnCalculateAll.Name = "btnCalculateAll";
			this.btnCalculateAll.Size = new System.Drawing.Size(234, 36);
			this.btnCalculateAll.TabIndex = 1;
			this.btnCalculateAll.Text = "Calculate All Moving Averages";
			this.btnCalculateAll.UseVisualStyleBackColor = true;
			this.btnCalculateAll.Click += new System.EventHandler(this.btnCalculateAll_Click);
			// 
			// btnCalculate
			// 
			this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCalculate.Location = new System.Drawing.Point(254, 434);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(234, 36);
			this.btnCalculate.TabIndex = 2;
			this.btnCalculate.Text = "Calculate Moving Average";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			// 
			// sfdSave
			// 
			this.sfdSave.DefaultExt = "txt";
			this.sfdSave.Filter = "Text File|*.txt|All Files|*.*";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(637, 392);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(91, 36);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Location = new System.Drawing.Point(540, 392);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(91, 36);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(443, 392);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(91, 36);
			this.btnNew.TabIndex = 5;
			this.btnNew.Text = "New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// lbxValues
			// 
			this.lbxValues.FormattingEnabled = true;
			this.lbxValues.ItemHeight = 16;
			this.lbxValues.Location = new System.Drawing.Point(149, 20);
			this.lbxValues.Name = "lbxValues";
			this.lbxValues.Size = new System.Drawing.Size(120, 356);
			this.lbxValues.TabIndex = 6;
			this.lbxValues.SelectedIndexChanged += new System.EventHandler(this.lbxValues_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(149, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Values:";
			// 
			// nudValue
			// 
			this.nudValue.DecimalPlaces = 4;
			this.nudValue.Location = new System.Drawing.Point(278, 175);
			this.nudValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudValue.Name = "nudValue";
			this.nudValue.Size = new System.Drawing.Size(120, 22);
			this.nudValue.TabIndex = 8;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(275, 40);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(123, 22);
			this.txtName.TabIndex = 9;
			// 
			// btnRemoveValue
			// 
			this.btnRemoveValue.Location = new System.Drawing.Point(149, 382);
			this.btnRemoveValue.Name = "btnRemoveValue";
			this.btnRemoveValue.Size = new System.Drawing.Size(120, 36);
			this.btnRemoveValue.TabIndex = 10;
			this.btnRemoveValue.Text = "Remove Value";
			this.btnRemoveValue.UseVisualStyleBackColor = true;
			this.btnRemoveValue.Click += new System.EventHandler(this.btnRemoveValue_Click);
			// 
			// nudWindowSize
			// 
			this.nudWindowSize.Location = new System.Drawing.Point(278, 103);
			this.nudWindowSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudWindowSize.Name = "nudWindowSize";
			this.nudWindowSize.Size = new System.Drawing.Size(120, 22);
			this.nudWindowSize.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(275, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 17);
			this.label2.TabIndex = 12;
			this.label2.Text = "Name:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(275, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "Window Size:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(275, 155);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 17);
			this.label4.TabIndex = 14;
			this.label4.Text = "Selected Data:";
			// 
			// btnAddValue
			// 
			this.btnAddValue.Location = new System.Drawing.Point(275, 203);
			this.btnAddValue.Name = "btnAddValue";
			this.btnAddValue.Size = new System.Drawing.Size(116, 36);
			this.btnAddValue.TabIndex = 15;
			this.btnAddValue.Text = "Add Value";
			this.btnAddValue.UseVisualStyleBackColor = true;
			this.btnAddValue.Click += new System.EventHandler(this.btnAddValue_Click);
			// 
			// btnUpdateValue
			// 
			this.btnUpdateValue.Location = new System.Drawing.Point(397, 203);
			this.btnUpdateValue.Name = "btnUpdateValue";
			this.btnUpdateValue.Size = new System.Drawing.Size(116, 36);
			this.btnUpdateValue.TabIndex = 16;
			this.btnUpdateValue.Text = "Update Value";
			this.btnUpdateValue.UseVisualStyleBackColor = true;
			this.btnUpdateValue.Click += new System.EventHandler(this.btnUpdateValue_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(740, 482);
			this.Controls.Add(this.btnUpdateValue);
			this.Controls.Add(this.btnAddValue);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nudWindowSize);
			this.Controls.Add(this.btnRemoveValue);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.nudValue);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbxValues);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCalculate);
			this.Controls.Add(this.btnCalculateAll);
			this.Controls.Add(this.lbxDataSets);
			this.Name = "MainForm";
			this.Text = "Moving Average Calculator";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWindowSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbxDataSets;
		private System.Windows.Forms.Button btnCalculateAll;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.SaveFileDialog sfdSave;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.ListBox lbxValues;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nudValue;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnRemoveValue;
		private System.Windows.Forms.NumericUpDown nudWindowSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnAddValue;
		private System.Windows.Forms.Button btnUpdateValue;
	}
}

