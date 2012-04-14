namespace UI
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
            this.ctlLoader = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctlInterpolate = new System.Windows.Forms.Button();
            this.ctlData = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlData)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlLoader
            // 
            this.ctlLoader.Location = new System.Drawing.Point(6, 19);
            this.ctlLoader.Name = "ctlLoader";
            this.ctlLoader.Size = new System.Drawing.Size(175, 23);
            this.ctlLoader.TabIndex = 0;
            this.ctlLoader.Text = "Load File";
            this.ctlLoader.UseVisualStyleBackColor = true;
            this.ctlLoader.Click += new System.EventHandler(this.ctlLoader_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Active Data Set";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctlInterpolate);
            this.groupBox1.Controls.Add(this.ctlLoader);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(456, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 334);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toolbox";
            // 
            // ctlInterpolate
            // 
            this.ctlInterpolate.Location = new System.Drawing.Point(6, 48);
            this.ctlInterpolate.Name = "ctlInterpolate";
            this.ctlInterpolate.Size = new System.Drawing.Size(175, 23);
            this.ctlInterpolate.TabIndex = 0;
            this.ctlInterpolate.Text = "Interpolate";
            this.ctlInterpolate.UseVisualStyleBackColor = true;
            this.ctlInterpolate.Click += new System.EventHandler(this.ctlInterpolate_Click);
            // 
            // ctlData
            // 
            this.ctlData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlData.Location = new System.Drawing.Point(0, 0);
            this.ctlData.Name = "ctlData";
            this.ctlData.Size = new System.Drawing.Size(456, 334);
            this.ctlData.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 334);
            this.Controls.Add(this.ctlData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ctlLoader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ctlInterpolate;
        private System.Windows.Forms.DataGridView ctlData;
    }
}

