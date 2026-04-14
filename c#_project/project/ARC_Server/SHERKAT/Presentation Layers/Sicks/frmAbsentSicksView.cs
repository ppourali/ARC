using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmAbsentSicksView : Form
    {
        public frmAbsentSicksView()
        {
            InitializeComponent();
        }


        public string cur_date;
        DataTable dt = new DataTable();
        DataTable Azmayeshdata = new DataTable();


        private void frmAbsentSicksView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            comboBox1.SelectedIndex = 0;

            //Sicks si = new Sicks();

            //dt = si.Select().Clone();


            //grdDataViewer.DataSource = dt;
            //grdDataViewer.AutoGenerateColumns = true;

            if (Program.user_semat.Trim() == "بازرس")
            {
                grdDataViewer.Columns["gheybat"].Visible = false;
                grdDataViewer.Columns["dailyAverage"].Visible = false;
                grdDataViewer.Columns["mandehgheybat"].Visible = false;
                this.Width -= 80;

                dataGridView1.Columns["gheybatGot"].Visible = false;
                dataGridView1.Columns["dailyAverageGot"].Visible = false;
                dataGridView1.Columns["mandehgheybatGot"].Visible = false;
                

                DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
                objAlternatingCellStyle.BackColor = Color.Khaki;
                grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;
               

            }
            txtdate.Text = cur_date;

            //Azmayeshdata = new azmayesh().Search("select sick_id, max(date) as date from azmayesh where (type=N'U/A' and result=N'مثبت') group by sick_id"); 
            //btnfilter.PerformClick();
        }


        private void btnfilter_Click(object sender, EventArgs e)
        {
            //try
            //{
            Cursor.Current = Cursors.WaitCursor;

            Sicks rm = new Sicks();
            DataTable dt = new DataTable();

            // if bazras , no need to find daily average
            if (Program.user_semat.Trim() == "بازرس")
            {
                dt = rm.Search("SELECT id, name,ravesh_tark, darman_date, '' as period,0 as gheybat, 0 as daftarigheybat, 0 as dailyAverage, monthFee as mandehgheybat  ,'' as last_visit, '' as visit, '' as last_ravan, '' as ravan, '' as last_azm,'' as azm FROM SICKS WHERE ((payan_date>N'" + txtdate.Text + "' or rtrim(ltrim(payan_date))='') and id not in(SELECT id FROM TAHVIL WHERE DATE=N'" + txtdate.Text + "'))");
            }
            else
            {
                dt = rm.Search("SELECT t0.id, name,ravesh_tark, darman_date, '' as period,0 as gheybat, 0 as daftarigheybat, isnull((t2.mablagh/t1.roozCount),0) as dailyAverage, monthFee as mandehgheybat, '' as last_visit, '' as visit, '' as last_ravan, '' as ravan, '' as last_azm,'' as azm FROM SICKS t0 " +
                    "left join (select id, count(code) as roozCount from tajviz as taj where tajviz_date in (select max (tajviz_date) from tajviz where (id=taj.id)) group by id) t1 on t0.id=t1.id " +
                    "left join (select id, sum(mablagh) as mablagh from ghabz as g where date in (select max (date) from ghabz where (mablagh>0 and id=g.id)) group by id) t2 on t1.id=t2.id " +
                    "WHERE ((payan_date>N'" + txtdate.Text + "' or rtrim(ltrim(payan_date))='') and t0.id not in(SELECT id FROM TAHVIL WHERE DATE=N'" + txtdate.Text + "'))");
            }

            grdDataViewer.DataSource = dt;


            DataTable dt2 = new DataTable();

            // if bazras , no need to find daily average
            if (Program.user_semat.Trim() == "بازرس")
            {
                dt2 = rm.Search("SELECT id, name,ravesh_tark, darman_date, '' as period,0 as gheybat, 0 as daftarigheybat, 0 as dailyAverage, monthFee as mandehgheybat  ,'' as last_visit, '' as visit, '' as last_ravan, '' as ravan, '' as last_azm,'' as azm FROM SICKS WHERE ((payan_date>N'" + txtdate.Text + "' or rtrim(ltrim(payan_date))='') and id in(SELECT id FROM TAHVIL WHERE tahvil_DATE=N'" + txtdate.Text + "'))");
            }
            else
            {
                dt2 = rm.Search("SELECT t0.id, name,ravesh_tark, darman_date, '' as period,0 as gheybat, 0 as daftarigheybat, isnull((t2.mablagh/t1.roozCount),0) as dailyAverage, monthFee as mandehgheybat, '' as last_visit, '' as visit, '' as last_ravan, '' as ravan, '' as last_azm,'' as azm FROM SICKS t0 " +
                    "left join (select id, count(code) as roozCount from tajviz as taj where tajviz_date in (select max (tajviz_date) from tajviz where (id=taj.id)) group by id) t1 on t0.id=t1.id " +
                    "left join (select id, sum(mablagh) as mablagh from ghabz as g where date in (select max (date) from ghabz where (mablagh>0 and id=g.id)) group by id) t2 on t1.id=t2.id " +
                    "WHERE ((payan_date>N'" + txtdate.Text + "' or rtrim(ltrim(payan_date))='') and t0.id in(SELECT id FROM TAHVIL WHERE tahvil_DATE=N'" + txtdate.Text + "'))");
            }

            //dt2.DefaultView.Sort = "id";
            dataGridView1.DataSource = dt2;

            DataTable vis_date = new dastoor_pezeshk().Search("select sick_id, max (date) as date from dastoor_pezeshk group by sick_id");
            DataTable rav_date = new ravanshenas().Search("select sick_id, max (date) as date from ravanshenas group by sick_id");
            DataTable az_date = new Azmayesh().Search("select sick_id, max (date) as date from azmayesh group by sick_id");

            DataTable visitsdata = new dastoor_pezeshk().Search("select sick_id, date from dastoor_pezeshk where (date=N'" + txtdate.Text.ToString() + "')");
            DataTable ravandata = new ravanshenas().Search("select sick_id, date from ravanshenas where (date=N'" + txtdate.Text.ToString() + "')");
            DataTable azdata = new Azmayesh().Search("select sick_id, date, type, result from azmayesh where (date=N'" + txtdate.Text.ToString() + "')");

            DataTable AzmayeshdataMosbat = new Azmayesh().Search("select sick_id, max(date) as date from azmayesh where (type=N'U/A' and result=N'مثبت') group by sick_id");
            DataTable AzmayeshdataManfi = new Azmayesh().Search("select sick_id, max(date) as date from azmayesh where (type=N'U/A' and result=N'منفی') group by sick_id");

            DataTable tajvizDaru_date = new dastoor_pezeshk().Search("select id, max(to_date) as lastdate from tajviz_koli where (tedad>0) GROUP BY id");

            string firstDataofMonth = txtdate.Text.Substring(0, 8) + "01";
            DataTable daftarigheybatRows = new tahvil().Search("select id,date from tahvil where (tedad=0 and date>=N'" + firstDataofMonth + "' and date<=N'" + txtdate.Text + "') group by id, date");


            foreach (DataGridViewRow dtr in grdDataViewer.Rows)
            {
                
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DataRow[] vd = vis_date.Select("sick_id='" + dtr.Cells["id"].Value.ToString() + "'");
                DataRow[] rd = rav_date.Select("sick_id='" + dtr.Cells["id"].Value.ToString()+"'");
                DataRow[] ad = az_date.Select("sick_id='" + dtr.Cells["id"].Value.ToString() + "'");
                DataRow[] tajd = tajvizDaru_date.Select("id='" + dtr.Cells["id"].Value.ToString() + "'");

                string fd;

                DataRow[] azmdtmosbat = AzmayeshdataMosbat.Select("sick_id='" + dtr.Cells["id"].Value.ToString() + "'");
                DataRow[] azmdtmanfi = AzmayeshdataManfi.Select("sick_id='" + dtr.Cells["id"].Value.ToString()+"'");
                if (azmdtmosbat.Length > 0 && azmdtmanfi.Length > 0)
                {
                    if (string.CompareOrdinal(azmdtmosbat[0]["date"].ToString(), azmdtmanfi[0]["date"].ToString()) > 0)
                    {
                        if (string.CompareOrdinal(azmdtmosbat[0][1].ToString(), dtr.Cells["darman_date"].Value.ToString()) > 0)
                            fd = azmdtmosbat[0][1].ToString();
                        else
                            fd = dtr.Cells["darman_date"].Value.ToString();
                    }
                    else
                        fd = dtr.Cells["darman_date"].Value.ToString();
                }
                else
                    fd = dtr.Cells["darman_date"].Value.ToString();

                //int i = 0;
                string period = "", visit = "", ravan = "", azm = "", last_visit = "", last_ravan = "", last_azm = "", lastTajvizDaru = "";

                if (vd.Length > 0)
                    last_visit = vd[0][1].ToString();
                if (rd.Length > 0)
                    last_ravan = rd[0][1].ToString();
                if (ad.Length > 0)
                    last_azm = ad[0][1].ToString();
                if (tajd.Length > 0)
                    lastTajvizDaru = tajd[0][1].ToString();

                System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
                TimeSpan ts = xd.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                            int.Parse(txtdate.Text.Substring(5, 2)),
                                            int.Parse(txtdate.Text.Substring(8, 2)),
                                            0, 0, 0, 0, 0)
                              - xd.ToDateTime(int.Parse(fd.Substring(0, 4)),
                                            int.Parse(fd.Substring(5, 2)),
                                            int.Parse(fd.Substring(8, 2)),
                                            0, 0, 0, 0, 0);

                double date_dif = ts.TotalDays;

                System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                DateTime temp_date = td.ToDateTime(int.Parse(fd.Substring(0, 4)),
                                                        int.Parse(fd.Substring(5, 2)),
                                                        int.Parse(fd.Substring(8, 2)),
                                                        0, 0, 0, 0, 0);


                DataRow[] tempvisdr = visitsdata.Select("sick_id='" + dtr.Cells["id"].Value.ToString() + "'");
                DataRow[] tempravdr = ravandata.Select("sick_id='" + dtr.Cells["id"].Value.ToString() + "'");
                DataRow[] tempazmdr = azdata.Select("sick_id='" + dtr.Cells["id"].Value.ToString() + "'");

                if (date_dif <= 14)
                {
                    period = "دو هفته اول";

                    if (tempvisdr.Length > 0)
                        visit = "انجام شد";
                    else if (date_dif % 2 == 0)
                        visit = "O";

                    if (tempravdr.Length > 0)
                        ravan = "انجام شد";
                    else if (date_dif % 7 == 0)
                        ravan = "O";

                    if (tempazmdr.Length > 0)
                        azm = tempazmdr[0]["type"].ToString() + " - " + tempazmdr[0]["result"].ToString();
                    else if (date_dif % 14 == 0)
                        azm = "O";
                }

                else if (date_dif > 14)
                {
                    int yeardif = (int.Parse(txtdate.Text.Substring(0, 4)) - int.Parse(fd.Substring(0, 4)));
                    int daydiff = 0;
                    int monthdif;

                    if (yeardif != 0)
                    {
                        monthdif = int.Parse(txtdate.Text.Substring(5, 2)) + (yeardif * 12) - int.Parse(fd.Substring(5, 2));
                    }
                    else
                    {
                        monthdif = (int.Parse(txtdate.Text.Substring(5, 2)) - int.Parse(fd.Substring(5, 2)));
                    }


                    if (int.Parse(fd.Substring(8, 2)) == 31)
                    {
                        if (int.Parse(txtdate.Text.Substring(5, 2)) > 6 && (int.Parse(txtdate.Text.Substring(8, 2))) == 30)
                            daydiff = 0;
                        else
                            daydiff = (int.Parse(txtdate.Text.Substring(8, 2)) - int.Parse(fd.Substring(8, 2)));

                    }
                    else
                        daydiff = (int.Parse(txtdate.Text.Substring(8, 2)) - int.Parse(fd.Substring(8, 2)));


                    if (monthdif == 3)
                    {
                        if (daydiff >= 0)
                        {
                            monthdif = 4;
                        }
                    }
                    else
                        if (monthdif == 6)
                        {
                            if (daydiff >= 0)
                            {
                                monthdif = 7;
                            }
                        }


                    if (monthdif <= 3)
                    {
                        period = "سه ماه اول";

                        if (tempvisdr.Length > 0)
                            visit = "انجام شد";
                        else if (date_dif % 7 == 0)
                            visit = "O";


                        if (tempravdr.Length > 0)
                            ravan = "انجام شد";
                        else if (date_dif % 7 == 0)
                            ravan = "O";

                        if (tempazmdr.Length > 0)
                            azm = tempazmdr[0]["type"].ToString() + " - " + tempazmdr[0]["result"].ToString();
                        else if (date_dif % 14 == 0)
                            azm = "O";
                    }

                    else if (monthdif > 3 && monthdif <= 6)
                    {

                        period = "شش ماه اول";

                        if (tempvisdr.Length > 0)
                            visit = "انجام شد";
                        else if (date_dif % 14 == 0)
                            visit = "O";


                        if (tempravdr.Length > 0)
                            ravan = "انجام شد";
                        else if (date_dif % 14 == 0)
                            ravan = "O";

                        if (tempazmdr.Length > 0)
                            azm = tempazmdr[0]["type"].ToString() + " - " + tempazmdr[0]["result"].ToString();
                        else if (date_dif % 14 == 0)
                            azm = "O";

                    }

                    else if (monthdif > 6)
                    {
                        period = "شش ماه به بعد";

                        if (tempvisdr.Length > 0)
                            visit = "انجام شد";
                        else if (daydiff == 0)
                            visit = "O";


                        if (tempravdr.Length > 0)
                            ravan = "انجام شد";
                        else if (daydiff == 0)
                            ravan = "O";

                        if (tempazmdr.Length > 0)
                            azm = tempazmdr[0]["type"].ToString() + " - " + tempazmdr[0]["result"].ToString();
                        else if (daydiff == 0)
                            azm = "O";
                    }
                }

                dtr.Cells["period"].Value = period;

                dtr.Cells["last_visit"].Value = last_ravan;
                dtr.Cells["last_ravan"].Value = last_ravan;
                dtr.Cells["last_azm"].Value = last_azm;

                dtr.Cells["visit"].Value = visit;
                dtr.Cells["ravan"].Value = ravan;
                dtr.Cells["azm"].Value = azm;


                DataRow[] gheybatedaftaridarmaah = daftarigheybatRows.Select("id='" + dtr.Cells["id"].Value.ToString()+"'");
                if (gheybatedaftaridarmaah.Length > 0)
                {
                    dtr.Cells["daftarigheybat"].Value = gheybatedaftaridarmaah.Length;
                }


                if (Program.user_semat.Trim() != "بازرس")
                {
                    
                    if (lastTajvizDaru != "")
                    {
                        string temp_date2 = lastTajvizDaru;
                        System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();


                        DateTime lastdate = x.ToDateTime(int.Parse(temp_date2.Substring(0, 4)),
                                                    int.Parse(temp_date2.Substring(5, 2)),
                                                    int.Parse(temp_date2.Substring(8, 2)),
                                                    0, 0, 0, 0, 0);

                        DateTime todaydate = x.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                                    int.Parse(txtdate.Text.Substring(5, 2)),
                                                    int.Parse(txtdate.Text.Substring(8, 2)),
                                                    0, 0, 0, 0, 0);


                        if (todaydate.CompareTo(lastdate) <= 0)
                        {
                            dtr.Cells["gheybat"].Value = 0;
                            dtr.DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                        else
                        {
                            TimeSpan ts2 = todaydate.Subtract(lastdate);

                            dtr.Cells["gheybat"].Value = ts2.Days;
                            dtr.DefaultCellStyle.BackColor = Color.PeachPuff;
                        }
                        //if (ts.Days > 5 && ts.Days <= 14)
                        //    dgvr.DefaultCellStyle.BackColor = Color.Pink;
                        //if (ts.Days > 14 && ts.Days <= 30)
                        //    dgvr.DefaultCellStyle.BackColor = Color.HotPink;
                        //if (ts.Days > 30)
                        //    dgvr.DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        dtr.Cells["gheybat"].Value = 0;
                        //dgvr.DefaultCellStyle.BackColor = Color.Red;

                    }
                }

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (azmdtmosbat.Length > 0 && azmdtmanfi.Length > 0)
                    if (string.CompareOrdinal(azmdtmosbat[0]["date"].ToString(), azmdtmanfi[0]["date"].ToString()) > 0)
                    {
                        if (string.CompareOrdinal(azmdtmosbat[0][1].ToString(), dtr.Cells["darman_date"].Value.ToString()) > 0)
                        {
                            dtr.Cells["darman_date"].Value = dtr.Cells["darman_date"].Value.ToString() + "لغزش";
                            dtr.DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }

                try
                {
                    long month = long.Parse(cur_date.Substring(5, 2));
                    int gheybatmandeh = 0;
                    if (month >= 1 && month <= 6)
                    {
                        gheybatmandeh = (int)(((31 * long.Parse(dtr.Cells["dailyAverage"].Value.ToString())) - long.Parse(dtr.Cells["mandehgheybat"].Value.ToString())) / long.Parse(dtr.Cells["dailyAverage"].Value.ToString()));
                    }
                    else
                    {
                        gheybatmandeh = (int)(((30 * long.Parse(dtr.Cells["dailyAverage"].Value.ToString())) - long.Parse(dtr.Cells["mandehgheybat"].Value.ToString())) / long.Parse(dtr.Cells["dailyAverage"].Value.ToString()));
                    }
                    dtr.Cells["mandehgheybat"].Value = gheybatmandeh - long.Parse(dtr.Cells["daftarigheybat"].Value.ToString());
                }
                catch
                {
                    dtr.Cells["mandehgheybat"].Value = 0;
                }

               
            }



            foreach (DataGridViewRow dtr in dataGridView1.Rows)
            {

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DataRow[] vd = vis_date.Select("sick_id='" + dtr.Cells["idGot"].Value.ToString() + "'");
                DataRow[] rd = rav_date.Select("sick_id='" + dtr.Cells["idGot"].Value.ToString() + "'");
                DataRow[] ad = az_date.Select("sick_id='" + dtr.Cells["idGot"].Value.ToString() + "'");
                DataRow[] tajd = tajvizDaru_date.Select("id='" + dtr.Cells["idGot"].Value.ToString() + "'");

                string fd;

                DataRow[] azmdtmosbat = AzmayeshdataMosbat.Select("sick_id='" + dtr.Cells["idGot"].Value.ToString() + "'");
                DataRow[] azmdtmanfi = AzmayeshdataManfi.Select("sick_id='" + dtr.Cells["idGot"].Value.ToString() + "'");
                if (azmdtmosbat.Length > 0 && azmdtmanfi.Length > 0)
                {
                    if (string.CompareOrdinal(azmdtmosbat[0]["date"].ToString(), azmdtmanfi[0]["date"].ToString()) > 0)
                    {
                        if (string.CompareOrdinal(azmdtmosbat[0][1].ToString(), dtr.Cells["darman_dateGot"].Value.ToString()) > 0)
                            fd = azmdtmosbat[0][1].ToString();
                        else
                            fd = dtr.Cells["darman_dateGot"].Value.ToString();
                    }
                    else
                        fd = dtr.Cells["darman_dateGot"].Value.ToString();
                }
                else
                    fd = dtr.Cells["darman_dateGot"].Value.ToString();

                //int i = 0;
                string period = "", visit = "", ravan = "", azm = "", last_visit = "", last_ravan = "", last_azm = "", lastTajvizDaru = "";

                if (vd.Length > 0)
                    last_visit = vd[0][1].ToString();
                if (rd.Length > 0)
                    last_ravan = rd[0][1].ToString();
                if (ad.Length > 0)
                    last_azm = ad[0][1].ToString();
                if (tajd.Length > 0)
                    lastTajvizDaru = tajd[0][1].ToString();

                System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
                TimeSpan ts = xd.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                            int.Parse(txtdate.Text.Substring(5, 2)),
                                            int.Parse(txtdate.Text.Substring(8, 2)),
                                            0, 0, 0, 0, 0)
                              - xd.ToDateTime(int.Parse(fd.Substring(0, 4)),
                                            int.Parse(fd.Substring(5, 2)),
                                            int.Parse(fd.Substring(8, 2)),
                                            0, 0, 0, 0, 0);

                double date_dif = ts.TotalDays;

                System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                DateTime temp_date = td.ToDateTime(int.Parse(fd.Substring(0, 4)),
                                                        int.Parse(fd.Substring(5, 2)),
                                                        int.Parse(fd.Substring(8, 2)),
                                                        0, 0, 0, 0, 0);


                DataRow[] tempvisdr = visitsdata.Select("sick_id='" + dtr.Cells["idGot"].Value.ToString()+"'");
                DataRow[] tempravdr = ravandata.Select("sick_id='" + dtr.Cells["idGot"].Value.ToString() + "'");
                DataRow[] tempazmdr = azdata.Select("sick_id='" + dtr.Cells["idGot"].Value.ToString() + "'");

                if (date_dif <= 14)
                {
                    period = "دو هفته اول";

                    if (tempvisdr.Length > 0)
                        visit = "انجام شد";
                    else if (date_dif % 2 == 0)
                        visit = "O";

                    if (tempravdr.Length > 0)
                        ravan = "انجام شد";
                    else if (date_dif % 7 == 0)
                        ravan = "O";

                    if (tempazmdr.Length > 0)
                        azm = tempazmdr[0]["type"].ToString() + " - " + tempazmdr[0]["result"].ToString();
                    else if (date_dif % 14 == 0)
                        azm = "O";
                }

                else if (date_dif > 14)
                {
                    int yeardif = (int.Parse(txtdate.Text.Substring(0, 4)) - int.Parse(fd.Substring(0, 4)));
                    int daydiff = 0;
                    int monthdif;

                    if (yeardif != 0)
                    {
                        monthdif = int.Parse(txtdate.Text.Substring(5, 2)) + (yeardif * 12) - int.Parse(fd.Substring(5, 2));
                    }
                    else
                    {
                        monthdif = (int.Parse(txtdate.Text.Substring(5, 2)) - int.Parse(fd.Substring(5, 2)));
                    }


                    if (int.Parse(fd.Substring(8, 2)) == 31)
                    {
                        if (int.Parse(txtdate.Text.Substring(5, 2)) > 6 && (int.Parse(txtdate.Text.Substring(8, 2))) == 30)
                            daydiff = 0;
                        else
                            daydiff = (int.Parse(txtdate.Text.Substring(8, 2)) - int.Parse(fd.Substring(8, 2)));

                    }
                    else
                        daydiff = (int.Parse(txtdate.Text.Substring(8, 2)) - int.Parse(fd.Substring(8, 2)));


                    if (monthdif == 3)
                    {
                        if (daydiff >= 0)
                        {
                            monthdif = 4;
                        }
                    }
                    else
                        if (monthdif == 6)
                        {
                            if (daydiff >= 0)
                            {
                                monthdif = 7;
                            }
                        }


                    if (monthdif <= 3)
                    {
                        period = "سه ماه اول";

                        if (tempvisdr.Length > 0)
                            visit = "انجام شد";
                        else if (date_dif % 7 == 0)
                            visit = "O";


                        if (tempravdr.Length > 0)
                            ravan = "انجام شد";
                        else if (date_dif % 7 == 0)
                            ravan = "O";

                        if (tempazmdr.Length > 0)
                            azm = tempazmdr[0]["type"].ToString() + " - " + tempazmdr[0]["result"].ToString();
                        else if (date_dif % 14 == 0)
                            azm = "O";
                    }

                    else if (monthdif > 3 && monthdif <= 6)
                    {

                        period = "شش ماه اول";

                        if (tempvisdr.Length > 0)
                            visit = "انجام شد";
                        else if (date_dif % 14 == 0)
                            visit = "O";


                        if (tempravdr.Length > 0)
                            ravan = "انجام شد";
                        else if (date_dif % 14 == 0)
                            ravan = "O";

                        if (tempazmdr.Length > 0)
                            azm = tempazmdr[0]["type"].ToString() + " - " + tempazmdr[0]["result"].ToString();
                        else if (date_dif % 14 == 0)
                            azm = "O";

                    }

                    else if (monthdif > 6)
                    {
                        period = "شش ماه به بعد";

                        if (tempvisdr.Length > 0)
                            visit = "انجام شد";
                        else if (daydiff == 0)
                            visit = "O";


                        if (tempravdr.Length > 0)
                            ravan = "انجام شد";
                        else if (daydiff == 0)
                            ravan = "O";

                        if (tempazmdr.Length > 0)
                            azm = tempazmdr[0]["type"].ToString() + " - " + tempazmdr[0]["result"].ToString();
                        else if (daydiff == 0)
                            azm = "O";
                    }
                }

                dtr.Cells["periodGot"].Value = period;

                dtr.Cells["last_visitGot"].Value = last_ravan;
                dtr.Cells["last_ravanGot"].Value = last_ravan;
                dtr.Cells["last_azmGot"].Value = last_azm;

                dtr.Cells["visitGot"].Value = visit;
                dtr.Cells["ravanGot"].Value = ravan;
                dtr.Cells["azmGot"].Value = azm;


                DataRow[] gheybatedaftaridarmaah = daftarigheybatRows.Select("id='" + dtr.Cells["idGot"].Value.ToString()+"'");
                if (gheybatedaftaridarmaah.Length > 0)
                {
                    dtr.Cells["daftarigheybatGot"].Value = gheybatedaftaridarmaah.Length;
                }


                if (Program.user_semat.Trim() != "بازرس")
                {

                    if (lastTajvizDaru != "")
                    {
                        string temp_date2 = lastTajvizDaru;
                        System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();


                        DateTime lastdate = x.ToDateTime(int.Parse(temp_date2.Substring(0, 4)),
                                                    int.Parse(temp_date2.Substring(5, 2)),
                                                    int.Parse(temp_date2.Substring(8, 2)),
                                                    0, 0, 0, 0, 0);

                        DateTime todaydate = x.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                                    int.Parse(txtdate.Text.Substring(5, 2)),
                                                    int.Parse(txtdate.Text.Substring(8, 2)),
                                                    0, 0, 0, 0, 0);


                        if (todaydate.CompareTo(lastdate) <= 0)
                        {
                            dtr.Cells["gheybatGot"].Value = 0;
                            //dtr.DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                        else
                        {
                            TimeSpan ts2 = todaydate.Subtract(lastdate);

                            dtr.Cells["gheybatGot"].Value = ts2.Days;
                            //dtr.DefaultCellStyle.BackColor = Color.PeachPuff;
                        }
                        //if (ts.Days > 5 && ts.Days <= 14)
                        //    dgvr.DefaultCellStyle.BackColor = Color.Pink;
                        //if (ts.Days > 14 && ts.Days <= 30)
                        //    dgvr.DefaultCellStyle.BackColor = Color.HotPink;
                        //if (ts.Days > 30)
                        //    dgvr.DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        dtr.Cells["gheybatGot"].Value = 0;
                        //dgvr.DefaultCellStyle.BackColor = Color.Red;

                    }
                }

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (azmdtmosbat.Length > 0 && azmdtmanfi.Length > 0)
                    if (string.CompareOrdinal(azmdtmosbat[0]["date"].ToString(), azmdtmanfi[0]["date"].ToString()) > 0)
                    {
                        if (string.CompareOrdinal(azmdtmosbat[0][1].ToString(), dtr.Cells["darman_dateGot"].Value.ToString()) > 0)
                        {
                            dtr.Cells["darman_dateGot"].Value = dtr.Cells["darman_dateGot"].Value.ToString() + "لغزش";
                            //dtr.DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }

                try
                {
                    long month = long.Parse(cur_date.Substring(5, 2));
                    int gheybatmandeh = 0;
                    if (month >= 1 && month <= 6)
                    {
                        gheybatmandeh = (int)(((31 * long.Parse(dtr.Cells["dailyAverageGot"].Value.ToString())) - long.Parse(dtr.Cells["mandehgheybatGot"].Value.ToString())) / long.Parse(dtr.Cells["dailyAverageGot"].Value.ToString()));
                    }
                    else
                    {
                        gheybatmandeh = (int)(((30 * long.Parse(dtr.Cells["dailyAverageGot"].Value.ToString())) - long.Parse(dtr.Cells["mandehgheybatGot"].Value.ToString())) / long.Parse(dtr.Cells["dailyAverageGot"].Value.ToString()));
                    }
                    dtr.Cells["mandehgheybatGot"].Value = gheybatmandeh - long.Parse(dtr.Cells["daftarigheybatGot"].Value.ToString());
                }
                catch
                {
                    dtr.Cells["mandehgheybatGot"].Value = 0;
                }


            }


            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
            //    txtdate.Text = "";
            //}
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (!txtdate.MaskCompleted)
            {
                btnfilter.Enabled = false;
            }
            else
            {
                btnfilter.Enabled = true;
            }
        }



        private void KeyDown_Action(object sender, KeyEventArgs e)
        {

        }

        private void Enter_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.Yellow;
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.Yellow;
                ((ComboBox)sender).Focus();
                ((ComboBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {
                ((DateMaskedTextbox)sender).BackColor = Color.Yellow;
                ((DateMaskedTextbox)sender).Focus();
                ((DateMaskedTextbox)sender).SelectAll();
            }

        }


        private void Leave_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {
                ((DateMaskedTextbox)sender).BackColor = Color.White;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void btnprint_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                frmOnLineResidPrintViewer ftkpv = new frmOnLineResidPrintViewer();

                DataTable dt = new MehrDataSet.tahvil_residDataTable().Clone();
                foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                {
                    dt.Rows.Add(new object[] { dgvr.Cells["idgot"].Value.ToString(), dgvr.Cells["namegot"].Value.ToString(), txtdate.Text, "", dgvr.Index, 0, "", "", "" });
                }
                ftkpv.idtable = dt;
                ftkpv.cur_date = txtdate.Text;
                ftkpv.filler = dt;

                if (dataGridView1.Rows[0].Selected)
                    ftkpv.checkBox1.Checked = true;
                else
                    ftkpv.checkBox1.Checked = false;
                
                ftkpv.Show();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                frmTahvil_Resid_Empty_PrintViewer ftkpv = new frmTahvil_Resid_Empty_PrintViewer();

                DataTable dt = new MehrDataSet.tahvil_residDataTable().Clone();
                foreach (DataGridViewRow dgvr in grdDataViewer.Rows)
                {
                    dt.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString(), txtdate.Text, "", dgvr.Index, 0, "", "", "" });
                }
                ftkpv.filler = dt;
                ftkpv.Show();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                frmSicksAbsentsPrintViewer fsgpv = new frmSicksAbsentsPrintViewer();
                fsgpv.filler = (DataTable)(grdDataViewer.DataSource);
                fsgpv.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmSabeghehView frtv = new frmSabeghehView();
                frtv.id = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());

                //if (Program.user.Trim() == "بازرس")
                frtv.tahORtaj = false;
                //else
                //frtv.tahORtaj = true;

                frtv.ShowDialog();
            }
        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                frmSickHisView fsh = new frmSickHisView();
                fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                fsh.sabegheh = true;
                fsh.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                grdDataViewer.Focus();
                //int cr = grdDataViewer.CurrentRow.Index;
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmTahvilInput))
                    {
                        IsOpen = true;
                        ((frmTahvilInput)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmTahvilInput)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmTahvilInput)f).txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmTahvilInput)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {

                    frmTahvilInput fsh = new frmTahvilInput();
                    fsh.sentbyadamview = true;
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }


                //grdDataViewer.Rows[cr].Selected = true;

            }
        }

        private void grdDataViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.PerformClick();
        }

        private void grdDataViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button2.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == 13 && e.Modifiers == Keys.Control)
            {
                button3.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void frmAbsentSicksView_Activated(object sender, EventArgs e)
        {
            btnfilter.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.SelectedRows != null)
            {
                grdDataViewer.Focus();
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmTahvilAdam))
                    {
                        IsOpen = true;
                        ((frmTahvilAdam)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmTahvilAdam)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmTahvilAdam)f).txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmTahvilAdam)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {

                    frmTahvilAdam fsh = new frmTahvilAdam();
                    fsh.sentbyadamview = true;
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }


                //grdDataViewer.Rows[cr].Selected = true;

            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void btndastoor_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmdastoor_pezeshkInp))
                    {
                        IsOpen = true;
                        ((frmdastoor_pezeshkInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmdastoor_pezeshkInp)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmdastoor_pezeshkInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    frmdastoor_pezeshkInp fsh = new frmdastoor_pezeshkInp();
                    fsh.sentbyadamview = true;
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }

            }

        }

        private void btnravan_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmRavanshenasInp))
                    {
                        IsOpen = true;
                        ((frmRavanshenasInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmRavanshenasInp)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmRavanshenasInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    frmRavanshenasInp fsh = new frmRavanshenasInp();
                    fsh.sentbyadamview = true;
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }

            }
        }

        private void btnazmayesh_Click(object sender, EventArgs e)
        {

            if (grdDataViewer.CurrentRow != null)
            {
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmAzmayeshInp))
                    {
                        IsOpen = true;
                        ((frmAzmayeshInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmAzmayeshInp)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmAzmayeshInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    frmAzmayeshInp fsh = new frmAzmayeshInp();
                    fsh.sentbyadamview = true;
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }

            }
        }

        private void grdDataViewer_Sorted(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvr in grdDataViewer.Rows)
            {
                if (dgvr.Cells["darman_date"].Value.ToString().Contains("لغزش"))
                {
                    dgvr.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                else if (Program.user_semat.Trim() != "بازرس")
                {

                    if (dgvr.Cells["gheybat"].Value.ToString() == "0")
                        dgvr.DefaultCellStyle.BackColor = Color.LightBlue;
                    else
                        dgvr.DefaultCellStyle.BackColor = Color.PeachPuff;
                }

            }

        }


    }
}