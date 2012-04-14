namespace UI
{
    partial class frmLoader
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
            this.ctlPath = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.ctlDomain = new System.Windows.Forms.ComboBox();
            this.ctlColAvailable = new System.Windows.Forms.ListBox();
            this.ctlColSelected = new System.Windows.Forms.ListBox();
            this.ctlAddCol = new System.Windows.Forms.Button();
            this.ctlRemoveCol = new System.Windows.Forms.Button();
            this.ctlBegin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlDelimiter = new System.Windows.Forms.TextBox();
            this.ctlSkip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ctlPath
            // 
            this.ctlPath.Location = new System.Drawing.Point(13, 13);
            this.ctlPath.Name = "ctlPath";
            this.ctlPath.Size = new System.Drawing.Size(75, 23);
            this.ctlPath.TabIndex = 0;
            this.ctlPath.Text = "Choose File";
            this.ctlPath.UseVisualStyleBackColor = true;
            this.ctlPath.Click += new System.EventHandler(this.ctlPath_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(94, 18);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(48, 13);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "File Path";
            // 
            // ctlDomain
            // 
            this.ctlDomain.FormattingEnabled = true;
            this.ctlDomain.Location = new System.Drawing.Point(97, 59);
            this.ctlDomain.Name = "ctlDomain";
            this.ctlDomain.Size = new System.Drawing.Size(166, 21);
            this.ctlDomain.TabIndex = 2;
            // 
            // ctlColAvailable
            // 
            this.ctlColAvailable.FormattingEnabled = true;
            this.ctlColAvailable.Location = new System.Drawing.Point(14, 104);
            this.ctlColAvailable.Name = "ctlColAvailable";
            this.ctlColAvailable.Size = new System.Drawing.Size(120, 95);
            this.ctlColAvailable.TabIndex = 3;
            // 
            // ctlColSelected
            // 
            this.ctlColSelected.FormattingEnabled = true;
            this.ctlColSelected.Location = new System.Drawing.Point(140, 104);
            this.ctlColSelected.Name = "ctlColSelected";
            this.ctlColSelected.Size = new System.Drawing.Size(120, 95);
            this.ctlColSelected.TabIndex = 4;
            // 
            // ctlAddCol
            // 
            this.ctlAddCol.Location = new System.Drawing.Point(14, 206);
            this.ctlAddCol.Name = "ctlAddCol";
            this.ctlAddCol.Size = new System.Drawing.Size(120, 23);
            this.ctlAddCol.TabIndex = 5;
            this.ctlAddCol.Text = "Add Selected";
            this.ctlAddCol.UseVisualStyleBackColor = true;
            this.ctlAddCol.Click += new System.EventHandler(this.ctlAddCol_Click);
            // 
            // ctlRemoveCol
            // 
            this.ctlRemoveCol.Location = new System.Drawing.Point(140, 206);
            this.ctlRemoveCol.Name = "ctlRemoveCol";
            this.ctlRemoveCol.Size = new System.Drawing.Size(120, 23);
            this.ctlRemoveCol.TabIndex = 6;
            this.ctlRemoveCol.Text = "Remove Selected";
            this.ctlRemoveCol.UseVisualStyleBackColor = true;
            this.ctlRemoveCol.Click += new System.EventHandler(this.ctlRemoveCol_Click);
            // 
            // ctlBegin
            // 
            this.ctlBegin.Location = new System.Drawing.Point(15, 340);
            this.ctlBegin.Name = "ctlBegin";
            this.ctlBegin.Size = new System.Drawing.Size(74, 23);
            this.ctlBegin.TabIndex = 7;
            this.ctlBegin.Text = "Begin Loading";
            this.ctlBegin.UseVisualStyleBackColor = true;
            this.ctlBegin.Click += new System.EventHandler(this.ctlBegin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Time Domain";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Avaliable Columns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Input Columns";
            // 
            // ctlDelimiter
            // 
            this.ctlDelimiter.Location = new System.Drawing.Point(15, 236);
            this.ctlDelimiter.Name = "ctlDelimiter";
            this.ctlDelimiter.Size = new System.Drawing.Size(100, 20);
            this.ctlDelimiter.TabIndex = 11;
            this.ctlDelimiter.Text = " ";
            // 
            // ctlSkip
            // 
            this.ctlSkip.Location = new System.Drawing.Point(15, 263);
            this.ctlSkip.Name = "ctlSkip";
            this.ctlSkip.Size = new System.Drawing.Size(100, 20);
            this.ctlSkip.TabIndex = 12;
            this.ctlSkip.Text = "1";
            // 
            // frmLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 400);
            this.Controls.Add(this.ctlSkip);
            this.Controls.Add(this.ctlDelimiter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlBegin);
            this.Controls.Add(this.ctlRemoveCol);
            this.Controls.Add(this.ctlAddCol);
            this.Controls.Add(this.ctlColSelected);
            this.Controls.Add(this.ctlColAvailable);
            this.Controls.Add(this.ctlDomain);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.ctlPath);
            this.Name = "frmLoader";
            this.Text = "Load File";
            this.Load += new System.EventHandler(this.lblFilePath_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ctlPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ComboBox ctlDomain;
        private System.Windows.Forms.ListBox ctlColAvailable;
        private System.Windows.Forms.ListBox ctlColSelected;
        private System.Windows.Forms.Button ctlAddCol;
        private System.Windows.Forms.Button ctlRemoveCol;
        private System.Windows.Forms.Button ctlBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ctlDelimiter;
        private System.Windows.Forms.TextBox ctlSkip;
    }
}