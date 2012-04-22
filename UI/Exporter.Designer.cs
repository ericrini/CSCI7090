namespace UI
{
    partial class ExportForm
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
            this.lblPath = new System.Windows.Forms.Label();
            this.ctlPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlDataSet = new System.Windows.Forms.ComboBox();
            this.ctlExport = new System.Windows.Forms.Button();
            this.ctlAvailableCol = new System.Windows.Forms.ListBox();
            this.ctlSelectedCol = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlAdd = new System.Windows.Forms.Button();
            this.ctlRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(93, 17);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(48, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "File Path";
            // 
            // ctlPath
            // 
            this.ctlPath.Location = new System.Drawing.Point(12, 12);
            this.ctlPath.Name = "ctlPath";
            this.ctlPath.Size = new System.Drawing.Size(75, 23);
            this.ctlPath.TabIndex = 2;
            this.ctlPath.Text = "Choose File";
            this.ctlPath.UseVisualStyleBackColor = true;
            this.ctlPath.Click += new System.EventHandler(this.ctlPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Set";
            // 
            // ctlDataSet
            // 
            this.ctlDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlDataSet.FormattingEnabled = true;
            this.ctlDataSet.Location = new System.Drawing.Point(69, 41);
            this.ctlDataSet.Name = "ctlDataSet";
            this.ctlDataSet.Size = new System.Drawing.Size(193, 21);
            this.ctlDataSet.TabIndex = 4;
            this.ctlDataSet.SelectedIndexChanged += new System.EventHandler(this.ctlDataSet_SelectedIndexChanged);
            // 
            // ctlExport
            // 
            this.ctlExport.Location = new System.Drawing.Point(12, 223);
            this.ctlExport.Name = "ctlExport";
            this.ctlExport.Size = new System.Drawing.Size(248, 23);
            this.ctlExport.TabIndex = 6;
            this.ctlExport.Text = "Export";
            this.ctlExport.UseVisualStyleBackColor = true;
            this.ctlExport.Click += new System.EventHandler(this.ctlExport_Click);
            // 
            // ctlAvailableCol
            // 
            this.ctlAvailableCol.FormattingEnabled = true;
            this.ctlAvailableCol.Location = new System.Drawing.Point(12, 90);
            this.ctlAvailableCol.Name = "ctlAvailableCol";
            this.ctlAvailableCol.Size = new System.Drawing.Size(122, 95);
            this.ctlAvailableCol.TabIndex = 7;
            // 
            // ctlSelectedCol
            // 
            this.ctlSelectedCol.FormattingEnabled = true;
            this.ctlSelectedCol.Location = new System.Drawing.Point(140, 90);
            this.ctlSelectedCol.Name = "ctlSelectedCol";
            this.ctlSelectedCol.Size = new System.Drawing.Size(120, 95);
            this.ctlSelectedCol.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Available Columns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Export Columns";
            // 
            // ctlAdd
            // 
            this.ctlAdd.Location = new System.Drawing.Point(12, 191);
            this.ctlAdd.Name = "ctlAdd";
            this.ctlAdd.Size = new System.Drawing.Size(122, 23);
            this.ctlAdd.TabIndex = 11;
            this.ctlAdd.Text = "Add";
            this.ctlAdd.UseVisualStyleBackColor = true;
            this.ctlAdd.Click += new System.EventHandler(this.ctlAdd_Click);
            // 
            // ctlRemove
            // 
            this.ctlRemove.Location = new System.Drawing.Point(140, 191);
            this.ctlRemove.Name = "ctlRemove";
            this.ctlRemove.Size = new System.Drawing.Size(120, 23);
            this.ctlRemove.TabIndex = 12;
            this.ctlRemove.Text = "Remove";
            this.ctlRemove.UseVisualStyleBackColor = true;
            this.ctlRemove.Click += new System.EventHandler(this.ctlRemove_Click);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 258);
            this.Controls.Add(this.ctlRemove);
            this.Controls.Add(this.ctlAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctlSelectedCol);
            this.Controls.Add(this.ctlAvailableCol);
            this.Controls.Add(this.ctlExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlDataSet);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.ctlPath);
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exporter";
            this.Load += new System.EventHandler(this.Exporter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button ctlPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ctlDataSet;
        private System.Windows.Forms.Button ctlExport;
        private System.Windows.Forms.ListBox ctlAvailableCol;
        private System.Windows.Forms.ListBox ctlSelectedCol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ctlAdd;
        private System.Windows.Forms.Button ctlRemove;
    }
}