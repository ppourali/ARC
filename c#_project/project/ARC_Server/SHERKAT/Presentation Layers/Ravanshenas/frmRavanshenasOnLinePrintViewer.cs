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
    public partial class FrmRavanshenasOnLinePrintViewer : Form
    {
        CurrencyManager objCurrencyManager;
        public string id = "";
        public DataTable idtable = new DataTable();
        public DataTable idandcodestable = new DataTable();
        public bool RealOrNot = false;        
        public DataTable filler = new DataTable();
       
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
       string cur_code = "";

        public FrmRavanshenasOnLinePrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            FillDataSetAndView();

            objCurrencyManager.PositionChanged += new EventHandler(objCurrencyManager_PositionChanged);

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptRavanshenasOnLine.rdlc";

            objCurrencyManager.Position = 0;

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

            if (RealOrNot == false)
                filler = new Azmayesh().Search("SELECT * from ravanshenas Where (sick_id=N'" + id + "')");
            else
                filler = new Azmayesh().Search("SELECT * from ravanshenas_real Where (sick_id=N'" + id + "')");

            txtname.Text = filler.Rows[0]["name"].ToString();

            cur_code = "";
            foreach (DataRow dr in idandcodestable.Rows)
            {
                if (dr["id"].ToString().Equals(id))
                    cur_code += "-" + dr["code"].ToString() + "-";
            }

            reportDataSource1.Name = "MehrDataSet_ravanshenas";
            reportDataSource1.Value = filler;

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("cur_code", cur_code) });
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                DirectPrint dp = new DirectPrint();
                dp.Run(this.reportViewer1.LocalReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}