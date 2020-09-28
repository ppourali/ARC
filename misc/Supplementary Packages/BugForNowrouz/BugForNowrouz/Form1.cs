using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugForNowrouz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            tahvil_koli tk = new tahvil_koli();
            DataTable dt = tk.Select();
            int counter = 0;

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                if (dt.Rows[i]["to_date"].ToString() == txttd.Text.Trim() && dt.Rows[i + 1]["from_date"].ToString() == txtfd.Text.Trim() && dt.Rows[i]["id"].ToString() == dt.Rows[i + 1]["id"].ToString())
                {
                    dataGridView1.Rows.Add(new object[] { ++counter, dt.Rows[i]["code"].ToString(),dt.Rows[i]["from_date"].ToString(), dt.Rows[i]["to_date"].ToString(), dt.Rows[i + 1]["code"].ToString(), dt.Rows[i + 1]["from_date"].ToString() });
                }

            }

            if (MessageBox.Show(counter.ToString() + " FOUND, Continue ??? ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                tahvil_koli tahk = new tahvil_koli();
                DataTable dttedad = new DataTable();

                anbar an = new anbar();

                int delc = 0;
                int editc = 0;

                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    int icol = 0;
                    int irow = dataGridView1.CurrentRow.Index;
                    string val = dataGridView1["del_code", j].Value.ToString();
                    dttedad.Clear();

                    tahk.code = long.Parse(val);
                    dttedad = tahk.SelectforDelete();

                    //foreach (DataRow dr in dttedad.Rows)
                    //{
                    //    an.daru_name = dr["daru_name"].ToString().Trim();
                    //    an.mandeh = float.Parse(dr["tedad"].ToString().Trim());
                    //    an.UpdateAfterFactor();
                    //}

                    tahk.Delete();
                    delc++;

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    string code = dataGridView1["edit_code", j].Value.ToString();

                    dttedad.Clear();

                    tahk.code = long.Parse(code);
                    dttedad = tahk.SelectforEdit();

                    //string code = dttedad.Rows[0]["code"].ToString();
                    string id = dttedad.Rows[0]["id"].ToString();
                    string sickname = dttedad.Rows[0]["name"].ToString();
                    string tahvil_date = dttedad.Rows[0]["tahvil_date"].ToString();
                    string from_date = dataGridView1["from_date", j].Value.ToString();
                    string to_date = dttedad.Rows[0]["to_date"].ToString();
                    string tahvil_day = dttedad.Rows[0]["tahvil_day"].ToString();

                    Sicks si = new Sicks();
                    si.id = id;
                    string ravesh_tark = si.Selectforedit().Rows[0]["ravesh_tark"].ToString();

                    // Get Date Differents of first PART
                    System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
                    TimeSpan ts = xd.ToDateTime(int.Parse(to_date.Substring(0, 4)),
                                                int.Parse(to_date.Substring(5, 2)),
                                                int.Parse(to_date.Substring(8, 2)),
                                                0, 0, 0, 0, 0)
                                  - xd.ToDateTime(int.Parse(dttedad.Rows[0]["from_date"].ToString().Substring(0, 4)),
                                                int.Parse(dttedad.Rows[0]["from_date"].ToString().Substring(5, 2)),
                                                int.Parse(dttedad.Rows[0]["from_date"].ToString().Substring(8, 2)),
                                                0, 0, 0, 0, 0);

                    double date_dif = (ts.TotalDays);
                    // End Of Dif


                    edit(code, id, sickname, ravesh_tark, from_date, from_date, to_date, dttedad, date_dif);

                    editc++;
                }

                MessageBox.Show(delc.ToString() + " Rows Deleted ");

                MessageBox.Show(editc.ToString() + " Rows Edited ");
            }
        }

        private void DeleteCode(string t_code)
        {
            tahvil_koli tahk = new tahvil_koli();
            DataTable dttedad = new DataTable();
            tahk.code = long.Parse(t_code);
            dttedad = tahk.SelectforDelete();

            anbar an = new anbar();
            foreach (DataRow dr in dttedad.Rows)
            {
                an.daru_name = dr["daru_name"].ToString().Trim();
                an.mandeh = float.Parse(dr["tedad"].ToString().Trim());
                an.UpdateAfterFactor();
            }

            tahk.Delete();
        }

        private void edit(string t_code, string txtid, string txtname, string txtravesh_tark, string txttahvil_date, string txtfrom_date, string txtto_date, DataTable daru, double firstPdif)
        {
            //Tahvil Day
            System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
            DateTime pdt = x.ToDateTime(int.Parse(txttahvil_date.Substring(0, 4)),
                                        int.Parse(txttahvil_date.Substring(5, 2)),
                                        int.Parse(txttahvil_date.Substring(8, 2)),
                                        0, 0, 0, 0, 0);
            string txttahvil_day = DayReader(pdt.DayOfWeek.ToString());
            ////////////////////////////////////////////////////////////////////////


            // Get Date Differents
            System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
            TimeSpan ts = xd.ToDateTime(int.Parse(txtto_date.Substring(0, 4)),
                                        int.Parse(txtto_date.Substring(5, 2)),
                                        int.Parse(txtto_date.Substring(8, 2)),
                                        0, 0, 0, 0, 0)
                          - xd.ToDateTime(int.Parse(txtfrom_date.Substring(0, 4)),
                                        int.Parse(txtfrom_date.Substring(5, 2)),
                                        int.Parse(txtfrom_date.Substring(8, 2)),
                                        0, 0, 0, 0, 0);

            string txtdate_dif = (ts.TotalDays).ToString();
            // End Of Dif

            DeleteCode(t_code);

            // Inserting the Data to the DataBase
            DataTable dt = new DataTable();
            tahvil_koli tk = new tahvil_koli();

            tk.code = long.Parse(t_code);
            tk.id = txtid;
            tk.name = txtname;
            tk.ravesh_tark = txtravesh_tark;
            tk.tahvil_day = txttahvil_day;
            tk.tahvil_date = txttahvil_date;
            tk.from_date = txtfrom_date;
            tk.to_date = txtto_date;


            foreach (DataRow dr in daru.Rows)
            {
                tk.daru_name = dr["daru_name"].ToString().Trim();
                tk.tedad =(float) (((double.Parse(dr["tedad"].ToString().Trim()) / firstPdif)) * double.Parse(txtdate_dif));
                tk.Add();
            }


            tahvil ta = new tahvil();
            for (int i = 0; i < int.Parse(txtdate_dif); i++)
            {
                ta.code = long.Parse(t_code);
                ta.id = txtid;
                ta.name = txtname;
                ta.ravesh_tark = txtravesh_tark;
                ta.tahvil_day = txttahvil_day;
                ta.tahvil_date = txtfrom_date;

                System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                DateTime temp_date = td.ToDateTime(int.Parse(txtfrom_date.Substring(0, 4)),
                                                        int.Parse(txtfrom_date.Substring(5, 2)),
                                                        int.Parse(txtfrom_date.Substring(8, 2)),
                                                        0, 0, 0, 0, 0);

                ta.date = (Shamsi((temp_date.AddDays(i)).Year.ToString("0000") + "/" +
                                        (temp_date.AddDays(i)).Month.ToString("00") + "/" +
                                        (temp_date.AddDays(i)).Day.ToString("00")));

                foreach (DataRow dr in daru.Rows)
                {
                    ta.daru_name = dr["daru_name"].ToString().Trim();
                    ta.tedad = (float)((double.Parse(dr["tedad"].ToString().Trim()) / firstPdif));
                    ta.Add();
                }
               
            }

            // Updating the Data to the DataBase Anbar
            anbar tan = new anbar();

            foreach (DataRow dr in daru.Rows)
            {
                tan.daru_name = dr["daru_name"].ToString().Trim();
                tan.mandeh = -float.Parse(dr["tedad"].ToString().Trim());
                tan.UpdateAfterFactor();
            } 
            
            // End of Updating Data to the DataBase


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
    }
}
