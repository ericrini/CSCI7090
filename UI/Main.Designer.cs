namespace UI
{
    partial class frmMain
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
            this.SuspendLayout();
            // 
            // ctlLoader
            // 
            this.ctlLoader.Location = new System.Drawing.Point(12, 299);
            this.ctlLoader.Name = "ctlLoader";
            this.ctlLoader.Size = new System.Drawing.Size(75, 23);
            this.ctlLoader.TabIndex = 0;
            this.ctlLoader.Text = "Load Data";
            this.ctlLoader.UseVisualStyleBackColor = true;
            this.ctlLoader.Click += new System.EventHandler(this.ctlLoader_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 334);
            this.Controls.Add(this.ctlLoader);
            this.Name = "frmMain";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ctlLoader;
    }
}

