using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GISProcessing;
using GISProcessing.Models;
using System.Threading;

namespace UI
{
    public partial class InterpolatorForm : Form
    {
        public List<Measurement> Results;
        
        private MainForm parent;
        private Interpolator i;

        public InterpolatorForm()
        {
            InitializeComponent();
            this.parent = (MainForm)MainForm.ActiveForm;
        }

        private void InterpolatorForm_Load(object sender, EventArgs e)
        {
            // Populate combo boxes.
            foreach (UI.MainForm.TabData data in this.parent.DataSets)
            {
                ctlKnown.Items.Add(data.Name);
                ctlMissing.Items.Add(data.Name);
            }
            ctlKnown.SelectedItem = 0;
            ctlMissing.SelectedItem = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get interpolation parameters.
            int n = (int)ctlN.Value;
            double p = (double)ctlP.Value;

            // Get the known and missing data sets.
            List<Measurement> known = new List<Measurement>();
            List<Measurement> missing = new List<Measurement>();
            foreach (UI.MainForm.TabData data in this.parent.DataSets)
            {
                if (data.Name == (string)ctlKnown.SelectedItem)
                {
                    known = data.List;
                }

                if (data.Name == (string)ctlMissing.SelectedItem)
                {
                    missing = data.List;
                }
            }

            // Initialize progress bar.
            ctlProgress.Minimum = 0;
            ctlProgress.Maximum = (int)(missing.Count * known[0].Time.TMax);

            // Begin the calculation in a new thread.
            this.i = new Interpolator(known, missing, n, p);
            Thread t = new Thread(delegate()
                {
                    // Run algorithm.
                    this.Results = i.GetResults();
                }
            );
            t.Start();

            // Begin the timer.
            ctlTimer.Start();
        }

        private void ctlTimer_Tick(object sender, EventArgs e)
        {
            this.ctlProgress.Value = this.i.Current;
            if (this.i.Current == this.i.Max)
            {
                this.Close();
            }
        }
    }
}
