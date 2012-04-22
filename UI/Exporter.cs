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
    public partial class ExportForm : Form
    {
        private MainForm parent;
        private List<Measurement> selectedDataSet;

        public ExportForm()
        {
            InitializeComponent();
            this.parent = (MainForm)MainForm.ActiveForm;
        }

        private void Exporter_Load(object sender, EventArgs e)
        {
            // Populate combo boxes.
            foreach (UI.MainForm.TabData data in this.parent.DataSets)
            {
                ctlDataSet.Items.Add(data.Name);
            }
            ctlDataSet.SelectedItem = ctlDataSet.Items[0];
        }

        private void ctlPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.DefaultExt = "txt";
            ofd.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.ShowDialog();
            if (ofd.FileName != null)
            {
                lblPath.Text = ofd.FileName;
            }
        }

        private void ctlDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the data set time domain.
            List<Measurement> list = new List<Measurement>();
            foreach (UI.MainForm.TabData data in this.parent.DataSets)
            {
                if (data.Name == (string)ctlDataSet.SelectedItem)
                {
                    this.selectedDataSet = data.List;
                    list = data.List;
                }
            }

            // Hehe dirty apps.
            Dictionary<string, int> domainColumns = new Dictionary<string, int>();
            domainColumns.Add("None", 0);
            domainColumns.Add("Yearly", 1);
            domainColumns.Add("Quarterly", 2);
            domainColumns.Add("Monthly", 3);
            domainColumns.Add("Daily", 4);

            int[][] cols = new int[5][];
            cols[0] = new int[] { 1, 2, 3, 4 };
            cols[1] = new int[] { 1, 2, 3, 4, 5 };
            cols[2] = new int[] { 1, 2, 3, 4, 5, 6 };
            cols[3] = new int[] { 1, 2, 3, 4, 5, 7 };
            cols[4] = new int[] { 1, 2, 3, 4, 5, 7, 8 };

            // Determine the time domain from the selected value.
            string key = list[0].Time.Name;
            int value;
            domainColumns.TryGetValue(key, out value);
            int[] validColumns = cols[value];

            // Add only columns in this time domain.
            ctlAvailableCol.Items.Clear();
            ctlSelectedCol.Items.Clear();
            foreach (Exporter.Columns col in Enum.GetValues(typeof(Exporter.Columns)))
            {
                // Loop through the valid columns and see if this column is there.
                for (int j = 0; j < validColumns.Length; j++)
                {
                    if ((int)col == validColumns[j])
                    {
                        ctlAvailableCol.Items.Add(col);
                    }
                }
            }
        }

        private void ctlAdd_Click(object sender, EventArgs e)
        {
            ctlSelectedCol.Items.Add(ctlAvailableCol.SelectedItem);
        }

        private void ctlRemove_Click(object sender, EventArgs e)
        {
            ctlSelectedCol.Items.Remove(ctlSelectedCol.SelectedItem);
        }

        private void ctlExport_Click(object sender, EventArgs e)
        {
            // Get an array of selected columns.
            Exporter.Columns[] cols = new Exporter.Columns[ctlSelectedCol.Items.Count];
            for (int i = 0; i < ctlSelectedCol.Items.Count; i++)
            {
                cols[i] = (Exporter.Columns)ctlSelectedCol.Items[i];
            }

            // Run the exporter.
            Exporter exp = new Exporter(
                lblPath.Text,
                this.selectedDataSet,
                cols,
                "\r\n", // Windows style but could be configurable.
                "\t", // Could be config later.
                true // Could be config later.
            );

            try
            {
                exp.Save();
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
