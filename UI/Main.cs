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
        public List<TabData> DataSets;

        public MainForm()
        {
            InitializeComponent();
            this.DataSets = new List<TabData>();
        }

        private void ctlLoader_Click(object sender, EventArgs e)
        {
            LoadForm loader = new LoadForm();
            loader.ShowDialog();
            if (loader.Loader != null)
            {
                this.AddTab(loader.Loader.Name, loader.Loader.Data);
            }
        }

        private void ctlInterpolate_Click(object sender, EventArgs e)
        {
            InterpolatorForm interpolator = new InterpolatorForm();
            interpolator.ShowDialog();
            if (interpolator.Results != null)
            {
                this.AddTab("IDW Result", interpolator.Results);
            }
        }

        private void AddTab(string name, List<Measurement> data)
        {
            // Create a DataTable.
            DataTable t = new DataTable();
            t.Columns.Add(new DataColumn("ID"));
            t.Columns.Add(new DataColumn("X"));
            t.Columns.Add(new DataColumn("Y"));
            t.Columns.Add(new DataColumn("Value"));
            t.Columns.Add(new DataColumn("Time"));
            for (var i = 0; i < data.Count; i++)
            {
                DataRow r = t.NewRow();
                r["ID"] = data[i].ID;
                r["X"] = data[i].X;
                r["Y"] = data[i].Y;
                r["Value"] = data[i].Value;
                try
                {
                    r["Time"] = data[i].Time.DateTime.ToString("d");
                }
                catch (Exception e)
                {
                    r["Time"] = "n/a";
                }
                t.Rows.Add(r);
            }

            // Greate a grid.
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.DataSource = t;

            // Create a tab for the grid.
            TabPage page = new TabPage(name);
            page.Controls.Add(grid);

            // Add the tab into the tab container.
            ctlTabs.TabPages.Add(page);

            // Make this data publicly accesible.
            TabData tabData = new TabData();
            tabData.List = data;
            tabData.Name = name;
            this.DataSets.Add(tabData);
        }

        /// <summary>
        /// Defines a set of data accesible to child windows.
        /// </summary>
        public class TabData
        {
            public List<Measurement> List;
            public string Name;
        }
    }
}
