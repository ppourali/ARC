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
    public partial class frmMosPrintViewer : Form
    {
       
        public DataTable filler_mos_list = new DataTable();
        public DataTable filler_MAP_A = new DataTable();
        public DataTable filler_MAP_BtoG = new DataTable();
        public DataTable filler_MAP_History = new DataTable();
       
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmMosPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {           
            reportDataSource1.Name = "MehrDataSet_mos_list";
            reportDataSource1.Value = filler_mos_list;

            reportDataSource2.Name = "MehrDataSet_MAP_A";
            reportDataSource2.Value = filler_MAP_A;

            reportDataSource3.Name = "MehrDataSet_Map_BtoG";
            reportDataSource3.Value = filler_MAP_BtoG;

            reportDataSource4.Name = "MehrDataSet_MAP_History";
            reportDataSource4.Value = filler_MAP_History;

            reportViewer1.LocalReport.EnableExternalImages = true;           

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptMosahebeh.rdlc";
          
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