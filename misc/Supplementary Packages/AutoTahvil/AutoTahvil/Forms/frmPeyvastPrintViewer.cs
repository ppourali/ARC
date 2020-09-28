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
    public partial class frmPeyvastPrintViewer : Form
    {
        public string markaz_name = "", shahr = "", mah = "0", sal = "0", mmtmard = "0", mmtzan = "0", bmtmard = "0", bmtzan = "0", smtmard = "0", smtzan = "0";

        public DataTable filler_kol = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
       
        public frmPeyvastPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {

            reportDataSource1.Name = "MehrDataSet_peyvast";
            reportDataSource1.Value = filler_kol;

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptPeyvast.rdlc";
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("markaz_name", markaz_name), 
                                                                                 new ReportParameter("shahr", shahr), 
                                                                                 new ReportParameter("mah", mah),
                                                                                 new ReportParameter("sal", sal),
                                                                                 new ReportParameter("bmtmard", bmtmard),
                                                                                 new ReportParameter("bmtzan", bmtzan),
                                                                                  new ReportParameter("smtmard", smtmard),
                                                                                 new ReportParameter("smtzan", smtzan),
                                                                                 new ReportParameter("mmtmard", mmtmard),
                                                                                 new ReportParameter("mmtzan", mmtzan)});

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }



    }

}