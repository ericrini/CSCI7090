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

namespace UI
{
    public partial class MainForm : Form
    {
        public List<Measurement> data;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ctlLoader_Click(object sender, EventArgs e)
        {
            LoadForm loader = new LoadForm();
            loader.ShowDialog();
            if (loader.Loader != null)
            {
                ctlData.DataSource = loader.Loader.Data;
            }
        }

        private void ctlInterpolate_Click(object sender, EventArgs e)
        {
            InterpolatorForm interpolator = new InterpolatorForm();
            interpolator.ShowDialog();
        }
    }
}
