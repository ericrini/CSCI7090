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
    public partial class LoadForm : Form
    {
        public Loader Loader;

        public LoadForm()
        {
            InitializeComponent();
        }

        private void lblFilePath_Load(object sender, EventArgs e)
        {
            // Time Domains
            ctlDomain.DataSource = Enum.GetValues(typeof(Time.TimeDomain));
            ctlDomain.SelectedIndex = 0;
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

        private void ctlDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hehe dirty apps.
            int[][] data = new int[5][];
            data[0] = new int[] { 1, 2, 3, 4 };
            data[1] = new int[] { 1, 2, 3, 4, 5 };
            data[2] = new int[] { 1, 2, 3, 4, 5, 6 };
            data[3] = new int[] { 1, 2, 3, 4, 5, 7 };
            data[4] = new int[] { 1, 2, 3, 4, 5, 7, 8 };

            ctlColAvailable.Items.Clear();

            // Set the avaliable columns.
            int timeDomain = ctlDomain.SelectedIndex;
            int[] validColumns = data[timeDomain];

            //Remove columns not part of this time domain.
            foreach (Loader.Columns col in Enum.GetValues(typeof(Loader.Columns)))
            {
                // Loop through the valid columns and see if this column is there.
                for (int j = 0; j < validColumns.Length; j++)
                {
                    if ((int)col == validColumns[j])
                    {
                        ctlColAvailable.Items.Add(col);
                    }
                }
            }
        }
    }
}
