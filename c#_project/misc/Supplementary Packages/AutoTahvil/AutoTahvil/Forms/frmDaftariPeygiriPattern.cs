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
    public partial class frmDaftariPeygiriPattern : Form
    {

        public string cur_date;
        public DataTable filler = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmDaftariPeygiriPattern()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            txtdate.Text = cur_date;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataTable vis_date = new dastoor_pezeshk().Search("select sick_id, max (date) as date from dastoor_pezeshk group by sick_id");
            DataTable rav_date = new ravanshenas().Search("select sick_id, max (date) as date from ravanshenas group by sick_id");
            DataTable az_date = new ravanshenas().Search("select sick_id, max (date) as date from azmayesh group by sick_id");

            DataTable visitsdata = new dastoor_pezeshk().Search("select sick_id, date from dastoor_pezeshk where (date=N'" + txtdate.Text.ToString() + "')");
            DataTable ravandata = new ravanshenas().Search("select sick_id, date from ravanshenas where (date=N'" + txtdate.Text.ToString() + "')");
            DataTable azdata = new ravanshenas().Search("select sick_id, date from azmayesh where (date=N'" + txtdate.Text.ToString() + "')");

            DataTable Azmayeshdata = new azmayesh().Search("select sick_id, max( date) as date from azmayesh where (type=N'U/A' and result=N'مثبت') group by sick_id");

            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("darman_date");
            dt.Columns.Add("period");
            dt.Columns.Add("last_visit");
            dt.Columns.Add("visit");
            dt.Columns.Add("last_ravan");
            dt.Columns.Add("ravan");
            dt.Columns.Add("last_azm");
            dt.Columns.Add("azm");


            Sicks si = new Sicks();
            DataTable allsicks = si.Search("select id,name,darman_date from sicks where (len(payan_date)!=10 and darman_date<=N'" + txtdate.Text + "') order by darman_date desc");

            foreach (DataRow dtr in allsicks.Rows)
            {

                DataRow[] vd = vis_date.Select("sick_id=" + dtr["id"]);
                DataRow[] rd = rav_date.Select("sick_id=" + dtr["id"]);
                DataRow[] ad = az_date.Select("sick_id=" + dtr["id"]);


                string fd;
                
                DataRow[] azmdt = Azmayeshdata.Select("sick_id=" + dtr["id"]);
                if (azmdt.Length > 0)
                    fd = azmdt[0][1].ToString();
                else
                    fd = dtr["darman_date"].ToString();

                //int i = 0;
                string period = "", visit = "", ravan = "", azm = "" , last_visit="", last_ravan="", last_azm="";

                if (vd.Length > 0)
                    last_visit = vd[0][1].ToString();
                if (rd.Length > 0)
                    last_ravan = rd[0][1].ToString();
                if (ad.Length > 0)
                    last_azm = ad[0][1].ToString();

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


                DataRow[] tempvisdr = visitsdata.Select("sick_id=" + dtr["id"]);
                DataRow[] tempravdr = ravandata.Select("sick_id=" + dtr["id"]);
                DataRow[] tempazmdr = azdata.Select("sick_id=" + dtr["id"]);

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
                        azm = "انجام شد";
                    else if (date_dif % 14 == 0)
                        azm = "O";
                }

                else if (date_dif > 14)
                {
                    int yeardif = (int.Parse(txtdate.Text.Substring(0, 4)) - int.Parse(fd.Substring(0, 4)));
                    int daydiff=0;
                    int monthdif;

                    if (yeardif != 0)
                    {
                        monthdif = int.Parse(txtdate.Text.Substring(5, 2)) + (yeardif * 12) - int.Parse(fd.Substring(5, 2));
                    }
                    else
                    {
                        monthdif = (int.Parse(txtdate.Text.Substring(5, 2)) - int.Parse(fd.Substring(5, 2)));
                    }

                    
                    if (int.Parse(fd.Substring(8, 2))==31){
                        if (int.Parse(txtdate.Text.Substring(5, 2)) > 6 && (int.Parse(txtdate.Text.Substring(8, 2))) == 30)
                            daydiff = 0;
                        else
                            daydiff = (int.Parse(txtdate.Text.Substring(8, 2)) - int.Parse(fd.Substring(8, 2)));

                    }
                    else
                    daydiff= (int.Parse(txtdate.Text.Substring(8, 2)) - int.Parse(fd.Substring(8, 2)));
                    

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
                            azm = "انجام شد";
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
                            azm = "انجام شد";
                        else if (date_dif % 14 == 0)
                            azm = "O";
                    }

                    else if (monthdif > 6)
                    {
                        period = "شش ماه به بعد";

                        if (tempvisdr.Length > 0)
                            visit = "انجام شد";
                        if (daydiff == 0)
                            visit = "O";


                        if (tempravdr.Length > 0)
                            ravan = "انجام شد";
                        else if (daydiff == 0)
                            ravan = "O";

                        if (tempazmdr.Length > 0)
                            azm = "انجام شد";
                        else if (daydiff == 0)
                            azm = "O";
                    }
                }

                if (azmdt.Length > 0)
                    fd = fd + "لغزش";

                //if (vd.Length == 0 && rd.Length > 0)
                //    dt.Rows.Add(new object[] { dtr["name"].ToString(), fd, period, "", visit, rd[0][1].ToString(), ravan });
                //else if (vd.Length == 0 && rd.Length == 0)
                //    dt.Rows.Add(new object[] { dtr["name"].ToString(), fd, period, "", visit, "", ravan });
                //else if (vd.Length > 0 && rd.Length == 0)
                //    dt.Rows.Add(new object[] { dtr["name"].ToString(), fd, period, vd[0][1].ToString(), visit, "", ravan });
                //else
                //    dt.Rows.Add(new object[] { dtr["name"].ToString(), fd, period, vd[0][1].ToString(), visit, rd[0][1].ToString(), ravan });
                dt.Rows.Add(new object[] { dtr["name"].ToString(), fd, period, last_visit, visit, last_ravan, ravan, last_azm, azm });


            }
            grdvisit.DataSource = dt;
            grdvisit.AutoGenerateColumns = true;

            DataGridViewColumn dgvc = new DataGridViewColumn();
            dgvc = grdvisit.Columns["darman_date"];
            grdvisit.Sort(dgvc, ListSortDirection.Descending);

            foreach (DataGridViewRow dgvr in grdvisit.Rows)
            {
                if (dgvr.Cells["period"].Value != null && dgvr.Cells["period"].Value.ToString() != "")
                {
                    if (dgvr.Cells["period"].Value.ToString() == "دو هفته اول")
                        dgvr.DefaultCellStyle.BackColor = Color.LightCyan;
                    else if (dgvr.Cells["period"].Value.ToString() == "سه ماه اول")
                        dgvr.DefaultCellStyle.BackColor = Color.PowderBlue;
                    else if (dgvr.Cells["period"].Value.ToString() == "شش ماه اول")
                        dgvr.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    else if (dgvr.Cells["period"].Value.ToString() == "شش ماه به بعد")
                        dgvr.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                }

                if (dgvr.Cells["visit"].Value != null && dgvr.Cells["visit"].Value.ToString() != "")
                    dgvr.Cells["visit"].Style.BackColor = Color.Pink;

                if (dgvr.Cells["ravan"].Value != null && dgvr.Cells["ravan"].Value.ToString() != "")
                    dgvr.Cells["ravan"].Style.BackColor = Color.PeachPuff;

                if (dgvr.Cells["azm"].Value != null && dgvr.Cells["azm"].Value.ToString() != "")
                    dgvr.Cells["azm"].Style.BackColor = Color.PaleGoldenrod;

                if (dgvr.Cells["darman_date"].Value.ToString().Contains("لغزش"))
                    dgvr.DefaultCellStyle.BackColor = Color.Tomato;

            }

            grdvisit.CurrentCell = null; ;

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
                ((DateMaskedTextbox)sender).Select(0, 10);
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdvisit.CurrentRow != null)
            {
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmdastoor_pezeshkInp))
                    {
                        IsOpen = true;
                        ((frmdastoor_pezeshkInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmdastoor_pezeshkInp)f).txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                        ((frmdastoor_pezeshkInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    frmdastoor_pezeshkInp fsh = new frmdastoor_pezeshkInp();
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grdvisit.CurrentRow != null)
            {
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmRavanshenasInp))
                    {
                        IsOpen = true;
                        ((frmRavanshenasInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmRavanshenasInp)f).txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                        ((frmRavanshenasInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    frmRavanshenasInp fsh = new frmRavanshenasInp();
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (grdvisit.CurrentRow != null)
            {
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmAzmayeshInp))
                    {
                        IsOpen = true;
                        ((frmAzmayeshInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmAzmayeshInp)f).txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                        ((frmAzmayeshInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    frmAzmayeshInp fsh = new frmAzmayeshInp();
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }

            }
        }
    }
}