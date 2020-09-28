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
    public partial class frmTahvil_ResidPrintViewer : Form
    {
       
        public DataTable filler = new DataTable();
        public DataTable idTable = new DataTable();
        public bool ResidById;

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmTahvil_ResidPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ResidById)
            {
                string fd = null;
                string td = null;

                if (txtdate.MaskCompleted)
                    fd = txtdate.Text;


                if (txttodate.MaskCompleted)
                    td = txttodate.Text;

                //if (!txtdate.MaskCompleted && !txttodate.MaskCompleted)
                //    filler = new tahvil_koli().TahvilResidById(idTable, "", "");
                //else if (!txtdate.MaskCompleted && txttodate.MaskCompleted)
                //    filler = new tahvil_koli().TahvilResidById(idTable, "", txttodate.Text);
                //else if (txtdate.MaskCompleted && txttodate.MaskCompleted)
                    filler = new tahvil_koli().TahvilResidById(idTable, fd, td);
            }
            else
            {
                string fd = null;
                string td = null;

                if (txtdate.MaskCompleted)
                    fd = txtdate.Text;

                if (txttodate.MaskCompleted)
                    td = txttodate.Text;

                filler = new tahvil_koli().TahvilResidByDate(fd, td);
            }

            reportViewer1.Reset();

            reportDataSource1.Name = "MehrDataSet_tahvil_resid";
            reportDataSource1.Value = filler;

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            if (ResidById)
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTahvil_Resid_Id.rdlc";
            else
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTahvil_Resid_Date.rdlc";

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }
    }

}