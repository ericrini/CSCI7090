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
    public partial class frmLoader : Form
    {
        public Loader Loader;

        public frmLoader()
        {
            InitializeComponent();
        }

        private void lblFilePath_Load(object sender, EventArgs e)
        {
            // Time Domains
            ctlDomain.DataSource = Enum.GetValues(typeof(Time.TimeDomain));
            ctlDomain.SelectedIndex = 0;

            // Avaliable Columns
            ctlColAvailable.DataSource = Enum.GetValues(typeof(Loader.Columns));
        }

        private void ctlPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != null)
            {
                lblPath.Text = ofd.FileName;
            }
        }

        private void ctlAddCol_Click(object sender, EventArgs e)
        {
            ctlColSelected.Items.Add(ctlColAvailable.SelectedItem);
        }

        private void ctlRemoveCol_Click(object sender, EventArgs e)
        {
            ctlColSelected.Items.Remove(ctlColSelected.SelectedItem);
        }

        private void ctlBegin_Click(object sender, EventArgs e)
        {
            try
            {
                // Get an array of selected columns.
                Loader.Columns[] cols = new Loader.Columns[ctlColSelected.Items.Count];
                for (int i = 0; i < ctlColSelected.Items.Count; i++)
                {
                    cols[i] = (Loader.Columns)ctlColSelected.Items[i];
                }

                // Instantiate loader.
                this.Loader = new Loader(
                    lblPath.Text,
                    ctlDelimiter.Text,
                    cols,
                    (Time.TimeDomain)ctlDomain.SelectedIndex,
                    int.Parse(ctlSkip.Text)
                );

                // Close this dialog.
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
