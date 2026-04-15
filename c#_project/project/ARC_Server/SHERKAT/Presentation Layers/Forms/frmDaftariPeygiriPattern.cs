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
    public partial class FrmDaftariPeygiriPattern : Form
    {

        public string cur_date;
        public DataTable filler = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public FrmDaftariPeygiriPattern()
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

            Sicks rm = new Sicks();
            DataTable tahvildarudt = new DataTable();
            tahvildarudt = rm.Search("SELECT id, tahvil_date, date FROM TAHVIL WHERE DATE=N'" + txtdate.Text + "'");

            DataTable vis_date = new dastoor_pezeshk().Search("select sick_id, max (date) as date from dastoor_pezeshk group by sick_id");
            DataTable rav_date = new ravanshenas().Search("select sick_id, max (date) as date from ravanshenas group by sick_id");
            DataTable az_date = new Azmayesh().Search("select sick_id, max (date) as date from azmayesh group by sick_id");
            DataTable map_date = new mos_list().Search("select id, max (mos_date) as date from mos_list group by id");

            DataTable visitsdata = new dastoor_pezeshk().Search("select sick_id, date from dastoor_pezeshk where (date=N'" + txtdate.Text.ToString() + "')");
            DataTable ravandata = new ravanshenas().Search("select sick_id, date from ravanshenas where (date=N'" + txtdate.Text.ToString() + "')");
            DataTable azdata = new Azmayesh().Search("select sick_id, date, type, result from azmayesh where (date=N'" + txtdate.Text.ToString() + "')");
            DataTable mapdata = new mos_list().Search("select id, mos_date from mos_list where (mos_date=N'" + txtdate.Text.ToString() + "')");

            DataTable AzmayeshdataMosbat = new Azmayesh().Search("select sick_id, max( date) as date from azmayesh where (type=N'U/A' and result=N'مثبت') group by sick_id");
            DataTable AzmayeshdataManfi = new Azmayesh().Search("select sick_id, max(date) as date from azmayesh where (type=N'U/A' and result=N'منفی') group by sick_id");

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("darman_date");
            dt.Columns.Add("period");
            dt.Columns.Add("last_visit");
            dt.Columns.Add("visit");
            dt.Columns.Add("last_ravan");
            dt.Columns.Add("ravan");
            dt.Columns.Add("last_azm");
            dt.Columns.Add("azm");
            dt.Columns.Add("last_map");
            dt.Columns.Add("map");
            dt.Columns.Add("tahvil");

            Sicks si = new Sicks();
            DataTable allsicks = si.Search("select id,name,darman_date from sicks where (len(payan_date)!=10 and darman_date<=N'" + txtdate.Text + "') order by darman_date desc");

            foreach (DataRow dtr in allsicks.Rows)
            {
                DataRow[] vd = vis_date.Select("sick_id='" + dtr["id"]+"'");
                DataRow[] rd = rav_date.Select("sick_id='" + dtr["id"] + "'");
                DataRow[] ad = az_date.Select("sick_id='" + dtr["id"] + "'");
                DataRow[] md = map_date.Select("id='" + dtr["id"] + "'");

                string fd;

                DataRow[] azmdtmosbat = AzmayeshdataMosbat.Select("sick_id='" + dtr["id"] + "'");
                DataRow[] azmdtmanfi = AzmayeshdataManfi.Select("sick_id='" + dtr["id"] + "'");
                if (azmdtmosbat.Length > 0 && azmdtmanfi.Length > 0)
                {
                    if (string.CompareOrdinal(azmdtmosbat[0]["date"].ToString(), azmdtmanfi[0]["date"].ToString()) > 0)
                    {
                        if (string.CompareOrdinal(azmdtmosbat[0][1].ToString(), dtr["darman_date"].ToString()) > 0)
                            fd = azmdtmosbat[0][1].ToString();
                        else
                            fd = dtr["darman_date"].ToString();
                    }
                    else
                        fd = dtr["darman_date"].ToString();
                }
                else
                    fd = dtr["darman_date"].ToString();

                //int i = 0;
                string period = "", visit = "", ravan = "", azm = "", map = "", last_visit = "", last_ravan = "", last_azm = "", last_map = "";

                if (vd.Length > 0)
                    last_visit = vd[0][1].ToString();
                if (rd.Length > 0)
                    last_ravan = rd[0][1].ToString();
                if (ad.Length > 0)
                    last_azm = ad[0][1].ToString();
                if (md.Length > 0)
                    last_map = md[0][1].ToString();

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


                DataRow[] tempvisdr = visitsdata.Select("sick_id='" + dtr["id"] + "'");
                DataRow[] tempravdr = ravandata.Select("sick_id='" + dtr["id"] + "'");
                DataRow[] tempazmdr = azdata.Select("sick_id='" + dtr["id"] + "'");
                DataRow[] tempmapdr = mapdata.Select("id='" + dtr["id"] + "'");

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


                    if (tempmapdr.Length > 0)
                        map = "انجام شد";
                    else if (date_dif % 30 == 0)
                        map = "O";
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

                        if (tempmapdr.Length > 0)
                            map = "انجام شد";
                        else if (daydiff == 0)
                            map = "O";
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

                        if (tempmapdr.Length > 0)
                            map = "انجام شد";
                        else if ((monthdif == 4 && daydiff == 0))
                            map = "O";
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

                        if (tempmapdr.Length > 0)
                            map = "انجام شد";
                        else if (monthdif >= 10 && monthdif % 3 == 1 && daydiff == 0)
                            map = "O";
                    }
                }


                if (azmdtmosbat.Length > 0 && azmdtmanfi.Length > 0)
                    if (string.CompareOrdinal(azmdtmosbat[0]["date"].ToString(), azmdtmanfi[0]["date"].ToString()) > 0)
                    {
                        if (string.CompareOrdinal(azmdtmosbat[0][1].ToString(), dtr["darman_date"].ToString()) > 0)
                        {
                            fd = fd + "لغزش";
                        }
                    }

                string tah = "";
                DataRow[] temptahdr = tahvildarudt.Select("id='" + dtr["id"] + "'");
                if (temptahdr.Length > 0)
                {
                    tah = "انجام شد";
                    if (tahvildarudt.Select("id='" + dtr["id"] + "' and date='" + txtdate.Text + "' and tahvil_date<>'"+txtdate.Text+"'").Length > 0)
                    {
                        tah = "دوز منزل";
                    }
                }
                else
                    tah = "O";


                tahvil_koli tahk = new tahvil_koli();
                tahk.id = dtr["id"].ToString().Trim();
                if (tahk.CheckDoseChanges(txtdate.Text) == true)
                {
                    tah = "ت.د - " + tah;
                }
                

                if (chketc.Checked)
                {
                    dt.Rows.Add(new object[] { dtr["id"].ToString(), dtr["name"].ToString(), fd, period, last_visit, visit, last_ravan, ravan, last_azm, azm, last_map, map, tah });
                }
                else
                {
                    if (chkdoze.Checked)
                    {
                        if (visit.Trim() != "" || ravan.Trim() != "" || azm.Trim() != "" || map.Trim() != "" || tah.Contains("ت.د"))
                        {
                            dt.Rows.Add(new object[] { dtr["id"].ToString(), dtr["name"].ToString(), fd, period, last_visit, visit, last_ravan, ravan, last_azm, azm, last_map, map, tah });
                        }
                    }
                    else
                    {
                        if (visit.Trim() != "" || ravan.Trim() != "" || azm.Trim() != "" || map.Trim() != "")
                        {
                            dt.Rows.Add(new object[] { dtr["id"].ToString(), dtr["name"].ToString(), fd, period, last_visit, visit, last_ravan, ravan, last_azm, azm, last_map, map, tah });
                        }
                    }
                }
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

                if (dgvr.Cells["map"].Value != null && dgvr.Cells["map"].Value.ToString() != "")
                    dgvr.Cells["map"].Style.BackColor = Color.MistyRose;

                if (dgvr.Cells["darman_date"].Value.ToString().Contains("لغزش"))
                    dgvr.DefaultCellStyle.BackColor = Color.Tomato;

                if (dgvr.Cells["tahvil"].Value.ToString().Contains("ت.د"))
                    dgvr.Cells["tahvil"].Style.BackColor = Color.Yellow;
                else
                    dgvr.Cells["tahvil"].Style.BackColor = Color.BlueViolet;

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
                    if (f.GetType() == typeof(FrmDastoorInp))
                    {
                        IsOpen = true;
                        ((FrmDastoorInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((FrmDastoorInp)f).txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                        ((FrmDastoorInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    FrmDastoorInp fsh = new FrmDastoorInp();
                    fsh.sentbyadamview = true;
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
                    if (f.GetType() == typeof(FrmRavanshenasInp))
                    {
                        IsOpen = true;
                        ((FrmRavanshenasInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((FrmRavanshenasInp)f).txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                        ((FrmRavanshenasInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    FrmRavanshenasInp fsh = new FrmRavanshenasInp();
                    fsh.sentbyadamview = true;
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
                    if (f.GetType() == typeof(FrmAzmayeshInp))
                    {
                        IsOpen = true;
                        ((FrmAzmayeshInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((FrmAzmayeshInp)f).txtname.Text = grdvisit["name", grdvisit.CurrentCell.RowIndex].Value.ToString();
                        ((FrmAzmayeshInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    FrmAzmayeshInp fsh = new FrmAzmayeshInp();
                    fsh.sentbyadamview = true;
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

        private void button4_Click(object sender, EventArgs e)
        {

            if (grdvisit.CurrentRow != null)
            {
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(FrmMosahebehInp))
                    {
                        IsOpen = true;
                        ((FrmMosahebehInp)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((FrmMosahebehInp)f).txtid.Text = grdvisit["id", grdvisit.CurrentCell.RowIndex].Value.ToString();
                        ((FrmMosahebehInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    FrmMosahebehInp fsh = new FrmMosahebehInp();
                    fsh.sentbyadamview = true;
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtid.Text = grdvisit["id", grdvisit.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }

            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            FrmPeygiriPatternPrintViewer fsgpv = new FrmPeygiriPatternPrintViewer();
            fsgpv.filler = (DataTable)(grdvisit.DataSource);
            fsgpv.Show();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void chketc_CheckedChanged(object sender, EventArgs e)
        {
            if (chketc.Checked)
            {
                chkdoze.Enabled = false;
            }
            else
                chkdoze.Enabled = true;
        }
    }
}