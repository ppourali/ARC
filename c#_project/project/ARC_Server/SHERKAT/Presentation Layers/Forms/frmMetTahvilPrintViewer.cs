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
    public partial class frmMetTahvilPrintViewer : Form
    {
        public string markaz_name = "", shahr = "", mah = "0", sal = "0", mard = "0", zan = "0";
        //public string ghabl5, ghabl20, ghabl40, ghablsp;
        public string lastdate = "0", last5 = "0", last20 = "0", last40 = "0", lastsp = "0";
        public string mandeh5 = "0", mandeh20 = "0", mandeh40 = "0", mandehsp = "0";

        public DataTable filler_kol = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
       
        public frmMetTahvilPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {

            reportDataSource1.Name = "MehrDataSet_kol";
            reportDataSource1.Value = filler_kol;

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptMet.rdlc";
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("markaz_name", markaz_name), 
                                                                                 new ReportParameter("shahr", shahr), 
                                                                                 new ReportParameter("mah", mah),
                                                                                 new ReportParameter("sal", sal),
                                                                                 new ReportParameter("mard", mard),
                                                                                 new ReportParameter("zan", zan),
                                                                                 
                                                                                 new ReportParameter("mandeh5", mandeh5), 
                                                                                 new ReportParameter("mandeh20", mandeh20), 
                                                                                 new ReportParameter("mandeh40", mandeh40),
                                                                                 new ReportParameter("mandehsp", mandehsp),
                                            
                                                                                 new ReportParameter("lastdate", lastdate), 
                                                                                 new ReportParameter("last5", last5), 
                                                                                 new ReportParameter("last20", last20), 
                                                                                 new ReportParameter("last40", last40),
                                                                                 new ReportParameter("lastsp", lastsp)});

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
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