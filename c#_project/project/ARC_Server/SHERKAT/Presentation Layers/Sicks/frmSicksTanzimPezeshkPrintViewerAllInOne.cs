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
    public partial class FrmSicksTanzimPezeshkPrintViewerAllInOne : Form
    {
       
        public string cur_date = "";
        public string darmangah_name = "";

        public DataTable idtable = new DataTable();

        public DataTable filler = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public FrmSicksTanzimPezeshkPrintViewerAllInOne()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.EnableExternalImages = true;

            GetDataForPezeshk();
        }

        private void GetDataForPezeshk()
        {
            Cursor.Current = Cursors.WaitCursor;

            foreach(DataRow dtr in idtable.Rows)
            {
                string id = dtr["id"].ToString();

                string from_date = "", todate = "";

                tahvil ta = new tahvil();
                DataTable allMetTahvil = new DataTable();
                DataTable allBoopTahvil = new DataTable();
                DataTable allSubTahvil = new DataTable();

                DataTable dtminmax = ta.Search("SELECT MIN(date) as mindate, Max(date) as maxdate FROM TAHVIL WHERE(id=N'" + id+ "')");

                from_date = dtminmax.Rows[0]["mindate"].ToString();
                todate = dtminmax.Rows[0]["maxdate"].ToString();

                if (!DateUtils.isCompleteDate(from_date) && !DateUtils.isCompleteDate(todate))
                {
                    from_date = "";
                    todate = "";
                }

                allMetTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'متادون' as type, t0.id, '" + dtr["name"].ToString() + "' as name, '" + dtr["darman_date"].ToString() + "' as darman_date, t0.date, isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) + isnull(t4.tedad,0) as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'شربت متادون' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 5' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                            "left JOIN ( SELECT tedad*20 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 20' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                            "left JOIN ( SELECT tedad*40 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 40' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t4 ON t0.date = t4.date " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and t0.id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

                allBoopTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type, t0.id, '" + dtr["name"].ToString() + "' as name, '" + dtr["darman_date"].ToString() + "' as darman_date, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0) as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad * 0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad * 2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                            "left JOIN ( SELECT tedad * 8 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and t0.id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

                allSubTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'سوباکسون' as type, t0.id, '" + dtr["name"].ToString() + "' as name, '" + dtr["darman_date"].ToString() + "' as darman_date, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 2' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 8' and id=N'" + id+ "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                            "Where (t0.id=N'" + id+ "'  and t0.daru_name like N'%سوباکسون%' and t0.id=N'" + id+ "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");


                DataTable all = new DataTable();
                if (DateUtils.isCompleteDate(from_date) && DateUtils.isCompleteDate(todate))
                {
                    DataTable lostdays = allMetTahvil.Clone();
                    int minday = int.Parse(from_date.Substring(8, 2));
                    string yearandmonth = from_date.Substring(0, 8);

                    for (int d = 1; d < minday; d++)
                    {
                        string lostdate = yearandmonth + d.ToString("00");
                        lostdays.Rows.Add(new object[] {lostdate, "", id, dtr["name"].ToString(), dtr["darman_date"].ToString(), lostdate, null });
                    }
                    all.Merge(lostdays);
                }

                all.Merge(allMetTahvil);
                all.Merge(allBoopTahvil);
                all.Merge(allSubTahvil);
                all.DefaultView.Sort = "date";
                
                filler.Merge(all);
            }

            reportDataSource1.Name = "MehrDataSet_tanzimdoz";
            reportDataSource1.Value = filler;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTanzimdozeDoctorAllInOne.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }

        private void GetDataForParastar()
        {
            Cursor.Current = Cursors.WaitCursor;

            foreach (DataRow dtr in idtable.Rows)
            {
                string id = dtr["id"].ToString();
                string from_date = "", todate = "";

                tahvil ta = new tahvil();
                DataTable allMetTahvil = new DataTable();
                DataTable allBoopTahvil = new DataTable();
                DataTable allSubTahvil = new DataTable();

                DataTable dtminmax = ta.Search("SELECT MIN(date) as mindate, Max(date) as maxdate FROM TAHVIL WHERE(id=N'" + id+ "')");

                from_date = dtminmax.Rows[0]["mindate"].ToString();
                todate = dtminmax.Rows[0]["maxdate"].ToString();

                if (!DateUtils.isCompleteDate(from_date) && !DateUtils.isCompleteDate(todate))
                {
                    from_date = "";
                    todate = "";
                }

                allMetTahvil = ta.Search("SELECT distinct  t0.tahvil_date, 'متادون' as type, t0.code, t0.id,t0.name, ts.darman_date, t0.date, isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) + isnull(t4.tedad,0) as tedad " +
                   "FROM tahvil t0 " +
                   "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'شربت متادون' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                   "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 5' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                   "left JOIN ( SELECT tedad*20 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 20' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                   "left JOIN ( SELECT tedad*40 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 40' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t4 ON t0.date = t4.date " +
                      "left JOIN (SELECT id,darman_date FROM sicks) ts ON t0.id = ts.id " +
                   "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");



                allBoopTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type,t0.code, t0.id,t0.name, ts.darman_date, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0) as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad * 0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad * 2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                            "left JOIN ( SELECT tedad * 8 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                               "left JOIN (SELECT id,darman_date FROM sicks) ts ON t0.id = ts.id " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and ts.id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");

                allSubTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'سوباکسون' as type,t0.code, t0.id,t0.name, ts.darman_date, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 2' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 8' and id=N'" + id + "' and date>=N'" + from_date + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                               "left JOIN (SELECT id,darman_date FROM sicks) ts ON t0.id = ts.id " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%سوباکسون%' and ts.id=N'" + id + "' and t0.date>=N'" + from_date + "' and t0.date<=N'" + todate + "') order by t0.date");


                DataTable all = new DataTable();
                if (DateUtils.isCompleteDate(from_date) && DateUtils.isCompleteDate(todate))
                {
                    DataTable lostdays = allMetTahvil.Clone();
                    int minday = int.Parse(from_date.Substring(8, 2));
                    string yearandmonth = from_date.Substring(0, 8);

                    for (int d = 1; d < minday; d++)
                    {
                        string lostdate = yearandmonth + d.ToString("00");
                        lostdays.Rows.Add(new object[] { lostdate,"", id, dtr["name"].ToString(), dtr["darman_date"].ToString(), lostdate, null });
                    }
                    all.Merge(lostdays);
                }

                all.Merge(allMetTahvil);
                all.Merge(allBoopTahvil);
                all.Merge(allSubTahvil);
                all.DefaultView.Sort = "date";

                filler.Merge(all);
            }

            reportDataSource1.Name = "MehrDataSet_tanzimdoz";
            reportDataSource1.Value = filler;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTanzimdozeNurseAllInOne.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("name", ""),
                                                                                 new ReportParameter("darman_date", "")});

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