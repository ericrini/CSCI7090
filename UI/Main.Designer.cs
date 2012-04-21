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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ctlInterpolate = new System.Windows.Forms.Button();
            this.ctlTabs = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlLoader
            // 
            this.ctlLoader.Location = new System.Drawing.Point(7, 19);
            this.ctlLoader.Name = "ctlLoader";
            this.ctlLoader.Size = new System.Drawing.Size(175, 23);
            this.ctlLoader.TabIndex = 0;
            this.ctlLoader.Text = "Import Data Set";
            this.ctlLoader.UseVisualStyleBackColor = true;
            this.ctlLoader.Click += new System.EventHandler(this.ctlLoader_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ctlInterpolate);
            this.groupBox1.Controls.Add(this.ctlLoader);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(452, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 334);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toolbox";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Export Data Set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ctlInterpolate
            // 
            this.ctlInterpolate.Location = new System.Drawing.Point(7, 48);
            this.ctlInterpolate.Name = "ctlInterpolate";
            this.ctlInterpolate.Size = new System.Drawing.Size(175, 23);
            this.ctlInterpolate.TabIndex = 0;
            this.ctlInterpolate.Text = "IDW Interpolation";
            this.ctlInterpolate.UseVisualStyleBackColor = true;
            this.ctlInterpolate.Click += new System.EventHandler(this.ctlInterpolate_Click);
            // 
            // ctlTabs
            // 
            this.ctlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlTabs.Location = new System.Drawing.Point(0, 0);
            this.ctlTabs.Name = "ctlTabs";
            this.ctlTabs.SelectedIndex = 0;
            this.ctlTabs.Size = new System.Drawing.Size(452, 334);
            this.ctlTabs.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 334);
            this.Controls.Add(this.ctlTabs);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ctlLoader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ctlInterpolate;
        private System.Windows.Forms.TabControl ctlTabs;
        private System.Windows.Forms.Button button1;
    }
}

