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
    public partial class frmTanzimPrintViewer : Form
    {

        public string cur_date;
        public DataTable filler = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmTanzimPrintViewer()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            reportDataSource1.Name = "MehrDataSet_tanzimdoz";

            reportDataSource1.Value = filler;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTanzimdozeNurse.rdlc";


            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            //this.reportViewer1.RefreshReport();
 

            Sicks si = new Sicks();
            DataTable dtname = new DataTable();
            dtname = si.Search("SELECT id,name,darman_date,payan_date FROM sicks");
            txtname.DataSource = dtname;
            txtname.DisplayMember = "name";
            txtname.ValueMember = "name";
            txtid.DataBindings.Clear();
            txtid.DataBindings.Add("Text", dtname, "id");
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string from_date = "", todate = "";
            
            tahvil ta = new tahvil();
            DataTable allMetTahvil = new DataTable();
            DataTable allBoopTahvil = new DataTable();
            DataTable allSubTahvil = new DataTable();

            string id = txtid.Text;

            DataTable dtminmax = ta.Search("SELECT MIN(date) as mindate, Max(date) as maxdate FROM TAHVIL WHERE(id=N'" + id + "')");

            from_date=dtminmax.Rows[0]["mindate"].ToString();
            todate=dtminmax.Rows[0]["maxdate"].ToString();

            if (!DateUtils.isCompleteDate(from_date) && !DateUtils.isCompleteDate(todate))
            {
                from_date = "";
                todate = "";
            }

            if (radioButton2.Checked)
            {
                allMetTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'متادون' as type, t0.id, t0.date, isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) + isnull(t4.tedad,0) as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'شربت متادون' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 5' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t2 ON t0.date = t2.date " +
                            "left JOIN ( SELECT tedad*20 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 20' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t3 ON t0.date = t3.date " +
                            "left JOIN ( SELECT tedad*40 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 40' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t4 ON t0.date = t4.date " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and id=N'" + id + "' and t0.date>=N'" +from_date + "' and t0.date<=N'" + todate+ "') order by t0.date");



                allBoopTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type, t0.id, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0) as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad * 0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id  + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad * 2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id  + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t2 ON t0.date = t2.date " +
                            "left JOIN ( SELECT tedad * 8 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t3 ON t0.date = t3.date " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and id=N'" + id + "' and t0.date>=N'" +from_date + "' and t0.date<=N'" + todate+ "') order by t0.date");

                allSubTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'سوباکسون' as type, t0.id, t0.date , isnull(t1.tedad,0) +isnull(t2.tedad,0) as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 2' and id=N'" + id+ "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 8' and id=N'" + id+ "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t2 ON t0.date = t2.date " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%سوباکسون%' and id=N'" + id + "' and t0.date>=N'" +from_date + "' and t0.date<=N'" + todate+ "') order by t0.date");

            }
            else
            {
                allMetTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'متادون' as type, t0.id, t0.date, (isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) + isnull(t4.tedad,0))/5 as tedad " +
                              "FROM tahvil t0 " +
                              "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'شربت متادون' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t1 ON t0.date = t1.date " +
                              "left JOIN ( SELECT tedad*5 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 5' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t2 ON t0.date = t2.date " +
                              "left JOIN ( SELECT tedad*20 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 20' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t3 ON t0.date = t3.date " +
                              "left JOIN ( SELECT tedad*40 as tedad,date FROM tahvil where(daru_name=N'قرص متادون 40' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t4 ON t0.date = t4.date " +
                              "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%متادون%' and id=N'" + id + "' and t0.date>=N'" +from_date + "' and t0.date<=N'" + todate+ "') order by t0.date");

                allBoopTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type, t0.id, t0.date , (isnull(t1.tedad,0) +isnull(t2.tedad,0) + isnull(t3.tedad,0))/0.4 as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad*0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + id  + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t2 ON t0.date = t2.date " +
                            "left JOIN ( SELECT tedad*8  as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t3 ON t0.date = t3.date " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%بوپر%' and id=N'" + id + "' and t0.date>=N'" +from_date + "' and t0.date<=N'" + todate+ "') order by t0.date");

                allSubTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'سوباکسون' as type, t0.id, t0.date , (isnull(t1.tedad,0) +isnull(t2.tedad,0))/2 as tedad " +
                            "FROM tahvil t0 " +
                            "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 2' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t1 ON t0.date = t1.date " +
                            "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص سوباکسون 8' and id=N'" + id + "' and date>=N'" +from_date + "' and date<=N'" + todate+ "')) t2 ON t0.date = t2.date " +
                            "Where (t0.id=N'" + id + "'  and t0.daru_name like N'%سوباکسون%' and id=N'" + id + "' and t0.date>=N'" +from_date + "' and t0.date<=N'" + todate+ "') order by t0.date");

            }

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

            DataTable dtinfo= new Sicks().Search("SELECT name,darman_date FROM sicks WHERE (id=N'" + id + "')");

            string darm_datee =dtinfo.Rows[0]["darman_date"].ToString();
            string namee =dtinfo.Rows[0]["name"].ToString();

            this.reportViewer1.Reset();
            filler = all;
            if (radioButton1.Checked)
            {
                reportDataSource1.Name = "MehrDataSet_tanzimdoz";
                reportDataSource1.Value = filler;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTanzimdozeNurse.rdlc";
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("name",namee), 
                                                                                 new ReportParameter("darman_date", darm_datee)});
                this.reportViewer1.RefreshReport();
            }
            else
            {
                reportDataSource1.Name = "MehrDataSet_tanzimdoz";
                reportDataSource1.Value = filler;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.rptTanzimdozeDoctor.rdlc";
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("name",namee), 
                                                                                 new ReportParameter("darman_date", darm_datee)});
                this.reportViewer1.RefreshReport();
            }

            
        }

        private void Enter_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.Yellow;
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {

                ((DateMaskedTextbox)sender).BackColor = Color.Yellow;
                ((DateMaskedTextbox)sender).Focus();
                ((DateMaskedTextbox)sender).SelectAll();
            }
            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.Yellow;
                ((ComboBox)sender).Focus();
                ((ComboBox)sender).SelectAll();
            }


        }


        private void Leave_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {
                ((DateMaskedTextbox)sender).BackColor = Color.White;
            }
            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.White;
            }

        }
        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        public string Shamsi(string date)
        {

            int[] arrMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] arrStart = { 21, 20, 21, 21, 22, 22, 23, 23, 23, 23, 22, 22 };
            char[] sep = { '/' };
            string[] arrDate = date.Split(sep);
            int year = Convert.ToInt32(arrDate[0]);
            int month = Convert.ToInt32(arrDate[1]);
            int day = Convert.ToInt32(arrDate[2]);
            if (year % 4 == 0)
            {
                for (int i = 2; i < 12; i++)
                    arrStart[i]--;
                arrMonths[1]++;
                if (month == 1) arrStart[11]++;
            }
            else if (year % 4 == 1)
            {
                arrStart[0]--;
                arrStart[1]--;
                if (month == 1) arrStart[11]--;
            }
            year = month <= 3 ? year - 622 : year - 621;
            if (month == 3 && day >= arrStart[2]) year++;
            if (day < arrStart[month - 1])
            {
                int i = month == 1 ? 11 : month - 2;
                day = day - arrStart[i] + arrMonths[i] + 1;
                month -= 3;
            }
            else
            {
                day = day - arrStart[month - 1] + 1;
                month -= 2;
            }
            if (month <= 0) month += 12;
            return year + "/" + Convert.ToString(month).PadLeft(2, '0') + "/" +
            Convert.ToString(day).PadLeft(2, '0');
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text=="" || txtname.Text=="")
            {
                btnRefresh.Enabled = false;
            }
            else
            {
                btnRefresh.Enabled = true;


            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton1.Checked)
            //{
            //    nod = "پرستار";
            //    fno = "8";
            //}
            //else
            //{
            //    nod = "پزشک";
            //    fno = "6";
            //}

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.D6)
            {
                radioButton2.Checked = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.D8)
            {
                radioButton1.Checked = true;
                e.SuppressKeyPress = true;
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