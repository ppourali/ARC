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
    public partial class FrmBoopYearTahvilPrintViewer : Form
    {
        public string markaz_name = "", shahr = "", sal = "0";

        public DataTable filler_kol = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
       
        public FrmBoopYearTahvilPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {

            reportDataSource1.Name = "MehrDataSet_metyear";
            reportDataSource1.Value = filler_kol;

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            string esfandrooz = "";
            System.Globalization.PersianCalendar ly = new System.Globalization.PersianCalendar();
            if (ly.IsLeapYear(int.Parse(sal)))
            {
                esfandrooz="30";
            }
            else
            {
                esfandrooz = "29";
            }

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptBoopYear.rdlc";
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("markaz_name", markaz_name), 
                                                                                 new ReportParameter("shahr", shahr), 
                                                                                 new ReportParameter("esfandrooz", esfandrooz), 
                                                                                 new ReportParameter("sal", sal)});

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