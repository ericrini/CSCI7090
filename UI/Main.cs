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
    public partial class frmMain : Form
    {
        public List<Measurement> data;

        public frmMain()
        {
            InitializeComponent();
        }

        private void ctlLoader_Click(object sender, EventArgs e)
        {
            Form loader = new frmLoader().Show();
            loader.Loader.Data;
        }
    }
}
