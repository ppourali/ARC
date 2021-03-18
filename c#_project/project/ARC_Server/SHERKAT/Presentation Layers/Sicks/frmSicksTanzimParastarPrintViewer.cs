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
using Mehr.Utils;

namespace Mehr.Presentation_Layers
{
    public partial class frmSicksTanzimParastarPrintViewer : Form
    {
        public bool f6got = false;

        CurrencyManager objCurrencyManager;

        public string id = "";
        public string cur_date = "";
        public string darmangah_name = "";

        public DataTable idtable = new DataTable();

        public DataTable filler = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmSicksTanzimParastarPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {


            FillDataSetAndView();

            objCurrencyManager.PositionChanged += new EventHandler(objCurrencyManager_PositionChanged);

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTanzimdozeNurse.rdlc";

            objCurrencyManager.Position = 0;
            //foreach (DataRow dtr in idtable.Rows)
            //{
            //    id = dtr["id"].ToString();
            //    LoadData();
            //}

            id = idtable.Rows[0]["id"].ToString();
            LoadData();
            ShowPosition();
        }


        private void LoadData()
        {
            filler.Clear();

            reportDataSource1.Value = null;

            GetTanzimData();

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
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

        public void GetTanzimData()
        {
            Cursor.Current = Cursors.WaitCursor;

            string from_date = "", todate = "";

            tahvil ta = new tahvil();
            DataTable allMetTahvil = new DataTable();
            DataTable allBoopTahvil = new DataTable();
            DataTable allSubTahvil = new DataTable();

            DataTable dtminmax = ta.Search("SELECT MIN(date) as mindate, Max(date) as maxdate FROM TAHVIL WHERE(id=N'" + id + "')");

            from_date = dtminmax.Rows[0]["mindate"].ToString();
            todate = dtminmax.Rows[0]["maxdate"].ToString();

            if (!DateUtils.isCompleteDate(from_date) && !DateUtils.isCompleteDate(todate))
            {
                from_date = "";
                todate = "";
            }

            allMetTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'متادون' as type, t0.id, t0.date, (isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) + isnull(t4.tedad,0))/5 as tedad " +
                              "FROM tahvil t0 " +
                              "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'شربت متادون' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                              "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 5' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                              "left JOIN ( SELECT tedad*20 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 20' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                              "left JOIN ( SELECT tedad*40 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 40' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t4 ON t0.date = t4.date " +
                              "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");



            allBoopTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type, t0.id, t0.date , (isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0))/0.4 as tedad " +
                        "FROM tahvil t0 " +
                        "left JOIN ( SELECT tedad*0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                        "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                        "left JOIN ( SELECT tedad*8  as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                        "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

            allSubTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'سوباکسون' as type, t0.id, t0.date , (isnull(t1.tedad,0) +isnull(t2.tedad,0))/2 as tedad " +
                        "FROM tahvil t0 " +
                        "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 2' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                        "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 8' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                        "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%سوباکسون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");


            DataTable all = new DataTable();
            if (DateUtils.isCompleteDate(from_date) && DateUtils.isCompleteDate(todate))
            {
                DataTable lostdays = allMetTahvil.Clone();
                int minday = int.Parse(from_date.Substring(8, 2));
                string yearandmonth = from_date.Substring(0, 8);

                for (int d = 1; d < minday; d++)
                {
                    string lostdate = yearandmonth + d.ToString("00");
                    lostdays.Rows.Add(new object[] { lostdate, "", id, lostdate, null });
                }
                all.Merge(lostdays);
            }

            all.Merge(allMetTahvil);
            all.Merge(allBoopTahvil);
            all.Merge(allSubTahvil);
            all.DefaultView.Sort = "date";

            DataTable dtinfo = new Sicks().Search("SELECT name,darman_date FROM sicks WHERE (id=N'" + id + "')");

            string darm_datee = dtinfo.Rows[0]["darman_date"].ToString();
            string namee = dtinfo.Rows[0]["name"].ToString();

            filler = all;
            reportDataSource1.Name = "MehrDataSet_tanzimdoz";
            reportDataSource1.Value = filler;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTanzimdozeNurse.rdlc";
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("name",namee), 
                                                                                 new ReportParameter("darman_date", darm_datee)});

        }
    }
}