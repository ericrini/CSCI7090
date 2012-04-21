namespace UI
{
    partial class InterpolatorForm
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
            this.components = new System.ComponentModel.Container();
            this.ctlKnown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctlMissing = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlN = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ctlP = new System.Windows.Forms.NumericUpDown();
            this.ctlInterpolate = new System.Windows.Forms.Button();
            this.ctlProgress = new System.Windows.Forms.ProgressBar();
            this.ctlTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ctlN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlP)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlKnown
            // 
            this.ctlKnown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlKnown.FormattingEnabled = true;
            this.ctlKnown.Location = new System.Drawing.Point(105, 13);
            this.ctlKnown.Name = "ctlKnown";
            this.ctlKnown.Size = new System.Drawing.Size(167, 21);
            this.ctlKnown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Known Data Set";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Missing Data Set";
            // 
            // ctlMissing
            // 
            this.ctlMissing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlMissing.FormattingEnabled = true;
            this.ctlMissing.Location = new System.Drawing.Point(105, 43);
            this.ctlMissing.Name = "ctlMissing";
            this.ctlMissing.Size = new System.Drawing.Size(167, 21);
            this.ctlMissing.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Neighbor Count (n)";
            // 
            // ctlN
            // 
            this.ctlN.Location = new System.Drawing.Point(106, 70);
            this.ctlN.Name = "ctlN";
            this.ctlN.Size = new System.Drawing.Size(166, 20);
            this.ctlN.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Exponent (p)";
            // 
            // ctlP
            // 
            this.ctlP.DecimalPlaces = 2;
            this.ctlP.Location = new System.Drawing.Point(105, 96);
            this.ctlP.Name = "ctlP";
            this.ctlP.Size = new System.Drawing.Size(166, 20);
            this.ctlP.TabIndex = 7;
            // 
            // ctlInterpolate
            // 
            this.ctlInterpolate.Location = new System.Drawing.Point(7, 165);
            this.ctlInterpolate.Name = "ctlInterpolate";
            this.ctlInterpolate.Size = new System.Drawing.Size(265, 23);
            this.ctlInterpolate.TabIndex = 8;
            this.ctlInterpolate.Text = "Interpolate";
            this.ctlInterpolate.UseVisualStyleBackColor = true;
            this.ctlInterpolate.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctlProgress
            // 
            this.ctlProgress.Location = new System.Drawing.Point(7, 136);
            this.ctlProgress.Name = "ctlProgress";
            this.ctlProgress.Size = new System.Drawing.Size(264, 23);
            this.ctlProgress.TabIndex = 9;
            // 
            // ctlTimer
            // 
            this.ctlTimer.Tick += new System.EventHandler(this.ctlTimer_Tick);
            // 
            // InterpolatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.ctlProgress);
            this.Controls.Add(this.ctlInterpolate);
            this.Controls.Add(this.ctlP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctlN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctlMissing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlKnown);
            this.Name = "InterpolatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Interpolator";
            this.Load += new System.EventHandler(this.InterpolatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ctlKnown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ctlMissing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ctlN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ctlP;
        private System.Windows.Forms.Button ctlInterpolate;
        private System.Windows.Forms.ProgressBar ctlProgress;
        private System.Windows.Forms.Timer ctlTimer;
    }
}