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
    public partial class frmTanzimdozePrintViewer : Form
    {
        public string fromdate = "", todate = "";
        public DataTable filler = new DataTable();
        public byte choose;

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmTanzimdozePrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {

            reportDataSource1.Name = "MehrDataSet_tanzimdoz";

            reportDataSource1.Value = filler;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);


            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTanzimdoze.rdlc";


            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }



    }

}