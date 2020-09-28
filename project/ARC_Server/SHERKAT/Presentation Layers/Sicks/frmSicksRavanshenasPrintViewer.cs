using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Mehr.Presentation_Layers
{
    public partial class frmSicksRavanshenasPrintViewer : Form
    {
        public bool f6got = false;

        CurrencyManager objCurrencyManager;

        public string id = "";
        public string cur_date = "";
        public string darmangah_name = "";

        public DataTable idtable = new DataTable();

        public DataTable filler = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmSicksRavanshenasPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {


            FillDataSetAndView();

            objCurrencyManager.PositionChanged += new EventHandler(objCurrencyManager_PositionChanged); 
            
            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptRavanshenas.rdlc";

            objCurrencyManager.Position = 0;
            //foreach (DataRow dtr in idtable.Rows)
            //{
            //    id = dtr["id"].ToString();
            //    LoadData();
            //}

            id = idtable.Rows[0]["id"].ToString();
            LoadData();
            ShowPosition();
        }


        private void LoadData()
        {
            filler.Clear();

            reportDataSource1.Value = null;

            GetAzmayeshForSick();
            
            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }

        private void GetAzmayeshForSick()
        {

            filler = new ravanshenas().Search("SELECT * from ravanshenas Where (sick_id=N'" + id + "')");
            reportDataSource1.Name = "MehrDataSet_ravanshenas";
            reportDataSource1.Value = filler;
        }
        
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            // Move to the previous record...
            objCurrencyManager.Position -= 1;
            // Show the current record position...
            ShowPosition();
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            // Set the record position to the first record...
            objCurrencyManager.Position = 0;
            // Show the current record position...
            ShowPosition();
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            objCurrencyManager.Position += 1;
            //Show the current record position...
            ShowPosition();
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            // Set the record position to the last record...
            objCurrencyManager.Position = objCurrencyManager.Count - 1;
            // Show the current record position...
            ShowPosition();
        }

        private void ShowPosition()
        {
            // Display the current position and the number of records
            txtRecordPosition.Text = (objCurrencyManager.Position + 1) + " of " + objCurrencyManager.Count;
        }

        private void FillDataSetAndView()
        {
            // Initialize a new instance of the DataSet object...
            // Set our CurrencyManager object to the DataView object...
            objCurrencyManager = (CurrencyManager)(this.BindingContext[idtable]);

           
        }

        void objCurrencyManager_PositionChanged(object sender, EventArgs e)
        {
            id = idtable.Rows[objCurrencyManager.Position]["id"].ToString();
            LoadData();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                try
                {
                    this.reportViewer1.PrintDialog();
                    e.SuppressKeyPress = true;
                }
                catch
                {
                }
            }
        }
    }

}