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
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace Mehr.Presentation_Layers
{
    public partial class FrmOnLineResidPrintViewer : Form
    {
        public string cur_date;

        CurrencyManager objCurrencyManager;

        public DataTable idtable = new DataTable();

        public DataTable filler = new DataTable();
       
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
   

        public FrmOnLineResidPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            loadReport();  
        }



        private void loadReport()
        {
            reportViewer1.Reset();
            
            reportDataSource1.Name = "MehrDataSet_tahvil_resid";

            filler = new tahvil_koli().TahvilResidByDate(cur_date, cur_date);
            filler.DefaultView.Sort = "id";
            reportDataSource1.Value = filler;

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTahvil_Resid_DateOnLine.rdlc";

            string cur_code = "";
            foreach (DataRow dr in idtable.Rows)
            {
                //if (dr["id"].ToString().Equals(id))
                cur_code += "-" + dr["id"].ToString() + "-";
            }

            string isFirst="1";
            if (checkBox1.Checked)
                isFirst = "1";
            else
                isFirst = "0";

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("cur_code", cur_code),
            new ReportParameter("isFirst", isFirst)});

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            loadReport();
        }
    }

}