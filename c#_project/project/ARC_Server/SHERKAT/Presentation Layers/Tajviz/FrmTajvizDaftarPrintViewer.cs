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
    public partial class FrmTajvizDaftarPrintViewer : Form
    {
        public string fromdate = "", todate = "";
        public DataTable filler = new DataTable();
        public byte choose;

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public FrmTajvizDaftarPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            if (choose == 0)
            {
                reportDataSource1.Name = "MehrDataSet_daftar_met";
            }
            else if (choose == 1)
            {
                reportDataSource1.Name = "MehrDataSet_daftar_boop";
            }
            else if (choose == 2)
            {
                reportDataSource1.Name = "MehrDataSet_daftar_sub";
            }
            
            reportDataSource1.Value = filler;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            
            if (choose == 0)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptMetDaftar.rdlc";
            }
            else if (choose == 1)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptBoopDaftar.rdlc";
            }
            else if (choose == 2)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptSubDaftar.rdlc";
            }
            
            
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("fromdate", fromdate), 
                                                                                 new ReportParameter("todate", todate)});



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