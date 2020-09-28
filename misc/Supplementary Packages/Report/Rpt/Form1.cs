using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rpt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mehrDataSet.tahvil' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter1.Fill(mehrDataSet.DataTable1);


            DataTable dtmax = new DataTable();
            DataTable temp = new DataTable();
            temp = mehrDataSet.DataTable1.Clone();

            temp.Clear();

            string frd = "1389/12/01", tod = "1389/12/31";

            tahvil ta = new tahvil();
            dtmax = ta.Search("select max (date) as max from tahvil where (tahvil_date<N'" + tod + "' and tahvil_date>N'" + frd + "')");

            string txtto_date = dtmax.Rows[0]["max"].ToString();

            // Get Date Differents
            System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
            TimeSpan ts = xd.ToDateTime(int.Parse(txtto_date.Substring(0, 4)),
                                        int.Parse(txtto_date.Substring(5, 2)),
                                        int.Parse(txtto_date.Substring(8, 2)),
                                        0, 0, 0, 0, 0)
                          - xd.ToDateTime(int.Parse(frd.Substring(0, 4)),
                                        int.Parse(frd.Substring(5, 2)),
                                        int.Parse(frd.Substring(8, 2)),
                                        0, 0, 0, 0, 0);

            string txtdate_dif = (ts.TotalDays).ToString();
            // End Of Dif
            DataTable dtttt = new DataTable();
            dtttt = ta.Search("SELECT * FROM tahvil");
            DataTable id_dt = new DataTable();
            id_dt = ta.Search("select distinct id from tahvil where (tahvil_date<N'" + tod + "' and tahvil_date>N'" + frd + "')");
            //DataRow[] dtr;
            //dtr = dtttt.Select("id=0071");// and date=1389/12/24 and daru_name='شربت متادون'");
            //MessageBox.Show(dtr[0]["tedad"].ToString());

            string[] daru_name = { "شربت متادون", "قرص متادون 5", "قرص متادون 20", "قرص متادون 40" };
            for (int i = 0; i <= int.Parse(txtdate_dif); i++)
            {
                foreach (DataRow dr in id_dt.Rows)
                {

                    DataTable mosh = new DataTable();
                    mosh = ta.Search("select distinct * from sicks where (id=N'" + dr["id"].ToString() + "')");

                    System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                    DateTime temp_date = td.ToDateTime(int.Parse(frd.Substring(0, 4)),
                                                            int.Parse(frd.Substring(5, 2)),
                                                            int.Parse(frd.Substring(8, 2)),
                                                            0, 0, 0, 0, 0);

                    string date = (Shamsi((temp_date.AddDays(i)).Year.ToString("0000") + "/" +
                                            (temp_date.AddDays(i)).Month.ToString("00") + "/" +
                                            (temp_date.AddDays(i)).Day.ToString("00")));

                    foreach (string dn in daru_name)
                    {
                        DataRow[] whatgot;
                        string tedad = "";
                        whatgot = dtttt.Select("id='" + mosh.Rows[0]["id"].ToString() + "' and date='" + date + "' and daru_name='" + dn + "'");

                        string dn2 = "";
                        if (dn == "شربت متادون")
                            dn2 = "SP";
                        if (dn == "قرص متادون 5")
                            dn2 = "M5";
                        if (dn == "قرص متادون 20")
                            dn2 = "M20";
                        if (dn == "قرص متادون 40")
                            dn2 = "M40";

                        try
                        {
                            tedad = whatgot[0]["tedad"].ToString();

                            temp.Rows.Add(mosh.Rows[0]["id_no"].ToString(), mosh.Rows[0]["id"].ToString(), mosh.Rows[0]["name"].ToString(), mosh.Rows[0]["ravesh_tark"].ToString(),
                                date, dn2.Trim(), tedad, mosh.Rows[0]["darman_date"].ToString(), mosh.Rows[0]["father_name"].ToString(), mosh.Rows[0]["age"].ToString(),
                                mosh.Rows[0]["city"].ToString(), mosh.Rows[0]["sex"].ToString(), mosh.Rows[0]["masrafi_type"].ToString());
                        }

                        catch
                        {
                            temp.Rows.Add(mosh.Rows[0]["id_no"].ToString(), mosh.Rows[0]["id"].ToString(), mosh.Rows[0]["name"].ToString(), mosh.Rows[0]["ravesh_tark"].ToString(),
                                 date, dn2.Trim(), tedad, mosh.Rows[0]["darman_date"].ToString(), mosh.Rows[0]["father_name"].ToString(), mosh.Rows[0]["age"].ToString(),
                                 mosh.Rows[0]["city"].ToString(), mosh.Rows[0]["sex"].ToString(), mosh.Rows[0]["masrafi_type"].ToString());
                        }
                    }
                }

            }


            this.reportViewer1.LocalReport.DataSources.Clear();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = "mehrDataSet_DataTable1";
            reportDataSource1.Value = temp;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
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
        private string DayReader(string EngDay)
        {

            string rtn = "";
            switch (EngDay)
            {
                case "Saturday":
                    {
                        rtn = "شنبه";
                        break;
                    }
                case "Sunday":
                    {
                        rtn = "یکشنبه";
                        break;
                    }
                case "Monday":
                    {
                        rtn = "دوشنبه";
                        break;
                    }
                case "Tuesday":
                    {
                        rtn = "سه شنبه";
                        break;
                    }
                case "Wednesday":
                    {
                        rtn = "چهارشنبه";
                        break;
                    }
                case "Thursday":
                    {
                        rtn = "پنج شنبه";
                        break;
                    }
                case "Friday":
                    {
                        rtn = "جمعه";
                        break;
                    }

            }
            return rtn;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
