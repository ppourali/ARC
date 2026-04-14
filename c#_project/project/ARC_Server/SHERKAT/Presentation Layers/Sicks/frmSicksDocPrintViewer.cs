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
    public partial class frmSicksDocPrintViewer : Form
    {
        public bool f6got = false;

        CurrencyManager objCurrencyManager;

        public string id = "";
        public string cur_date = "";
        public string darmangah_name = "";

        public DataTable idtable = new DataTable();

        public DataTable f1 = new DataTable();
        public DataTable f2 = new DataTable();
        public DataTable f3_1 = new DataTable();
        public DataTable f3_2 = new DataTable();
        public DataTable f3_3 = new DataTable();
        public DataTable f3_4 = new DataTable();
        public DataTable f4 = new DataTable();
        public DataTable f5 = new DataTable();
        public DataTable f6 = new DataTable();
        public DataTable f7 = new DataTable();
        public DataTable f8 = new DataTable();
        public DataTable f9 = new DataTable();


        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3_1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3_2 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3_3 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3_4 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmSicksDocPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {


            FillDataSetAndView();

            objCurrencyManager.PositionChanged += new EventHandler(objCurrencyManager_PositionChanged); 
            
            reportViewer1.LocalReport.EnableExternalImages = true;

           

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptAll.rdlc";
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

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
            f1.Clear();
            f2.Clear();
            f3_1.Clear();
            f3_2.Clear();
            f3_3.Clear();
            f3_4.Clear();
            f4.Clear();
            f5.Clear();
            f6.Clear();
            f7.Clear();
            f8.Clear();
            f9.Clear();

            reportDataSource1.Value = null;
            reportDataSource2.Value = null;
            reportDataSource3_1.Value = null;
            reportDataSource3_2.Value = null;
            reportDataSource3_3.Value = null;
            reportDataSource3_4.Value = null;
            reportDataSource4.Value = null;
            reportDataSource5.Value = null;
            reportDataSource6.Value = null;
            reportDataSource7.Value = null;
            reportDataSource8.Value = null;
            reportDataSource9.Value = null;


            Form1and2();
            //Form3();
           // Form4();
           // Form7();
           // Form8();

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3_1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3_2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3_3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3_4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);


            darmangah_name = new Darmangah().Search("select name from darmangah").Rows[0]["name"].ToString();
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("darmangah_name", darmangah_name) });

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);


            this.reportViewer1.RefreshReport();
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            if (e.ReportPath.Equals("rptTanzimdozeNurse"))
            {
                Form9();
                e.DataSources.Add(reportDataSource9);
            }
            if (e.ReportPath.Equals("rptTanzimdozeDoctor"))
            {
                Form6();
                e.DataSources.Add(reportDataSource6);
            }
            if (e.ReportPath.Equals("rptAzmayesh"))
            {
                Form7();
                e.DataSources.Add(reportDataSource7);
            }

            if (e.ReportPath.Equals("rptRavanshenas"))
            {
                Form8();
                e.DataSources.Add(reportDataSource8);
            }
            if (e.ReportPath.Equals("rptDastoor"))
            {
                Form4();
                e.DataSources.Add(reportDataSource4);
            }
            if (e.ReportPath.Equals("rptMosahebeh"))
            {
                Form3();
                e.DataSources.Add(reportDataSource3_1);
                e.DataSources.Add(reportDataSource3_2);
                e.DataSources.Add(reportDataSource3_3);
                e.DataSources.Add(reportDataSource3_4);
            }
            if (e.ReportPath.Equals("rptTahod"))
            {
                Form1and2();
                e.DataSources.Add(reportDataSource2);
            }

            if (e.ReportPath.Equals("rptIndivSicks"))
            {
                Form1and2();
                e.DataSources.Add(reportDataSource1);
            }
        }

       private void Form1and2()
        {

            f1 = new Sicks().Search("SELECT * from Sicks Where (id=N'" + id + "')");
            reportDataSource1.Name = "MehrDataSet_Sicks";
            reportDataSource1.Value = f1;

            f2 = f1;
            reportDataSource2.Name = "MehrDataSet_Sicks";
            reportDataSource2.Value = f2;
        }

        private void Form3()
        {

            long val = 0;
            mos_list ml = new mos_list();
            try
            {
                val = long.Parse(ml.Search("select max(code) as code from mos_list where id=N'" + id + "'").Rows[0]["code"].ToString());
            }
            catch
            {
            }

            ml.code = val;
            f3_1 = ml.Selectforedit();

            map_a ma = new map_a();
            ma.code = val;
            f3_2 = ma.Selectforedit();

            MAP_BtoG mb = new MAP_BtoG();
            mb.code = val;
            f3_3 = mb.Selectforedit();

            map_history mh = new map_history();
            mh.code = val;
            f3_4 = mh.Selectforedit();

            reportDataSource3_1.Name = "MehrDataSet_mos_list";
            reportDataSource3_1.Value = f3_1;

            reportDataSource3_2.Name = "MehrDataSet_MAP_A";
            reportDataSource3_2.Value = f3_2;

            reportDataSource3_3.Name = "MehrDataSet_Map_BtoG";
            reportDataSource3_3.Value = f3_3;

            reportDataSource3_4.Name = "MehrDataSet_MAP_History";
            reportDataSource3_4.Value = f3_4;

        }

        private void Form4()
        {

            f4 = new Sicks().Search("SELECT * from dastoor_pezeshk Where (sick_id=N'" + id + "')");
            reportDataSource4.Name = "MehrDataSet_dastoor_pezeshk";
            reportDataSource4.Value = f4;

        }

        private void Form6()
        {

            tahvil ta = new tahvil();
            DataTable allMetTahvil = new DataTable();
            DataTable allBoopTahvil = new DataTable();
            DataTable allSubTahvil = new DataTable();

            string todate;
            string from_date;

                DataTable dtminmax = ta.Search("SELECT MIN(date) as mindate, Max(date) as maxdate FROM TAHVIL WHERE(id=N'" + id + "')");

                from_date = dtminmax.Rows[0]["mindate"].ToString();
                todate = dtminmax.Rows[0]["maxdate"].ToString();

            if (!DateUtils.isCompleteDate(from_date) && !DateUtils.isCompleteDate(todate))
            {
                    from_date = "";
                    todate = "";
                }

            allMetTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'متادون' as type, t0.id, t0.date, isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) + isnull(t4.tedad,0) as tedad " +
                        "FROM tahvil t0 " +
                        "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'شربت متادون' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                        "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 5' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                        "left JOIN ( SELECT tedad*20 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 20' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                        "left JOIN ( SELECT tedad*40 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 40' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t4 ON t0.date = t4.date " +
                        "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");



            allBoopTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type, t0.id, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0) as tedad " +
                        "FROM tahvil t0 " +
                        "left JOIN ( SELECT tedad * 0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                        "left JOIN ( SELECT tedad * 2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                        "left JOIN ( SELECT tedad * 8 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                        "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

            allSubTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'سوباکسون' as type, t0.id, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) as tedad " +
                        "FROM tahvil t0 " +
                        "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 2' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                        "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 8' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
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
                    lostdays.Rows.Add(new object[] {lostdate, "", id, lostdate, null });
                }
                all.Merge(lostdays);
            }

            all.Merge(allMetTahvil);
            all.Merge(allBoopTahvil);
            all.Merge(allSubTahvil);
            all.DefaultView.Sort = "date";


            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("frmNo", fno), 
            //                                                                     new ReportParameter("nurseordoc", nod),
            //                                                                     new ReportParameter("id", id), 
            //                                                                     new ReportParameter("name", txtname.Text), 
            //                                                                     new ReportParameter("darman_date", darm_datee)});
            f6 = all;
            reportDataSource6.Name = "MehrDataSet_tanzimdoz";
            reportDataSource6.Value = f6;
        }

        private void Form7()
        {
            f7 = new Azmayesh().Search("SELECT * from AZMAYESH Where (sick_id=N'" + id + "')");
            reportDataSource7.Name = "MehrDataSet_azmayesh";
            reportDataSource7.Value = f7;
        }

        private void Form8()
        {
            f8 = new ravanshenas().Search("SELECT * from ravanshenas Where (sick_id=N'" + id + "')");
            reportDataSource8.Name = "MehrDataSet_ravanshenas";
            reportDataSource8.Value = f8;
        }

        private void Form9()
        {

            tahvil ta = new tahvil();
            DataTable allMetTahvil = new DataTable();
            DataTable allBoopTahvil = new DataTable();
            DataTable allSubTahvil = new DataTable();

            string todate;
            string from_date;

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
                                  "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 5' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                                  "left JOIN ( SELECT tedad*20 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 20' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                                  "left JOIN ( SELECT tedad*40 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 40' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t4 ON t0.date = t4.date " +
                                  "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");


            allBoopTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type, t0.id, t0.date , (isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0))/0.4 as tedad " +
                        "FROM tahvil t0 " +
                        "left JOIN ( SELECT tedad*0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                        "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                        "left JOIN ( SELECT tedad*8  as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                        "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

            allSubTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'سوباکسون' as type, t0.id, t0.date , (isnull(t1.tedad,0) +isnull(t2.tedad,0))/2 as tedad " +
                        "FROM tahvil t0 " +
                        "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 2' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                        "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 8' and id=N'" + id + "' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
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


            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("frmNo", fno), 
            //                                                                     new ReportParameter("nurseordoc", nod),
            //                                                                     new ReportParameter("id", id), 
            //                                                                     new ReportParameter("name", txtname.Text), 
            //                                                                     new ReportParameter("darman_date", darm_datee)});
            f9 = all;
            reportDataSource9.Name = "MehrDataSet_tanzimdoz";
            reportDataSource9.Value = f9;
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
    }

}