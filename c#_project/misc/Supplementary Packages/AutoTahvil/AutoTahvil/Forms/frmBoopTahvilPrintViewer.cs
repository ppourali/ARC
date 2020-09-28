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
    public partial class frmBoopTahvilPrintViewer : Form
    {
        public string markaz_name = "", shahr = "0", mah = "0", sal = "0", mard = "0", zan = "0";
        //public string ghabl5, ghabl20, ghabl40, ghablsp;
        public string lastdate = "0", last4 = "0", last2 = "0", last8 = "0";
        public string mandeh4 = "0", mandeh2 = "0", mandeh8 = "0";

        public DataTable filler_kol = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
       
        public frmBoopTahvilPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {           
            reportDataSource1.Name = "MehrDataSet_kol_boop";
            reportDataSource1.Value = filler_kol;
            
            reportViewer1.LocalReport.EnableExternalImages = true;           

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptBoopre.rdlc";
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("markaz_name", markaz_name), 
                                                                                 new ReportParameter("shahr", shahr), 
                                                                                 new ReportParameter("mah", mah),
                                                                                 new ReportParameter("sal", sal),
                                                                                 new ReportParameter("mard", mard),
                                                                                 new ReportParameter("zan", zan),
                                                                                 
                                                                                 new ReportParameter("mandeh4", mandeh4), 
                                                                                 new ReportParameter("mandeh2", mandeh2), 
                                                                                 new ReportParameter("mandeh8", mandeh8),
                                            
                                                                                 new ReportParameter("lastdate", lastdate), 
                                                                                 new ReportParameter("last4", last4), 
                                                                                 new ReportParameter("last2", last2), 
                                                                                 new ReportParameter("last8", last8)});
          
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }



    }

}