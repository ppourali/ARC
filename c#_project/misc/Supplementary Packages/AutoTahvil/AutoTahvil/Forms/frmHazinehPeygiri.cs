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
    public partial class frmHazinehPeygiri : Form
    {

        public string cur_date;
        public DataTable filler = new DataTable();

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmHazinehPeygiri()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            txtdate.Text = cur_date;
        }


        private string[] lastmonthcalc(string darmandate)
        {
            string startyear, startmonth, startday, endyear, endmonth, endday;

            if (int.Parse(txtdate.Text.Substring(8, 2)) <= int.Parse(darmandate.Substring(8, 2)))
            {
                endyear = txtdate.Text.Substring(0, 4);
                endmonth = txtdate.Text.Substring(5, 2);
                endday = darmandate.Substring(8, 2);

                startday = darmandate.Substring(8, 2);
                if (txtdate.Text.Substring(5, 2).Equals("01"))
                {
                    startyear = (int.Parse(endyear) - 1).ToString("0000");
                    startmonth = "12";
                }
                else
                {
                    startyear = txtdate.Text.Substring(0, 4);
                    startmonth = (int.Parse(txtdate.Text.Substring(5, 2)) - 1).ToString("00");
                }
            }
            else
            {
                startyear = txtdate.Text.Substring(0, 4);
                startmonth = txtdate.Text.Substring(5, 2);
                startday = darmandate.Substring(8, 2);

                endday = darmandate.Substring(8, 2);
                if (txtdate.Text.Substring(5, 2).Equals("12"))
                {
                    endyear = (int.Parse(startday) + 1).ToString("0000");
                    endmonth = "01";
                }
                else
                {
                    endyear = txtdate.Text.Substring(0, 4);
                    endmonth = (int.Parse(txtdate.Text.Substring(5, 2)) + 1).ToString("00");
                }
            }

            string fromdate = startyear + "/" + startmonth + "/" + startday;
            string todate = endyear + "/" + endmonth + "/" + endday;
            string[] rstring = { fromdate, todate };
            return rstring;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataTable dt = new DataTable();
            dt.Columns.Add("radif");
            dt.Columns.Add("id"); 
            dt.Columns.Add("name");
            dt.Columns.Add("darman_date");
            dt.Columns.Add("Fromdate");
            dt.Columns.Add("Todate");
            dt.Columns.Add("allmet");
            dt.Columns.Add("allboop");
            dt.Columns.Add("allsoob");
            dt.Columns.Add("allpaid");
            dt.Columns.Add("averagepaid");

            dt.Columns["allpaid"].DataType = typeof(float);
            dt.Columns["averagepaid"].DataType = typeof(long);

            Sicks si = new Sicks();
            DataTable allsicks = si.Search("select id,name,darman_date from sicks where (len(payan_date)!=10 and darman_date<=N'" + txtdate.Text + "') order by darman_date desc");

            tajviz_koli taj=new tajviz_koli();

            string fromdate = lastmonthcalc(txtdate.Text)[0];
            DataTable tajdata = taj.Search("SELECT id, tajviz_date, tedad, daru_name from tajviz_koli where (tajviz_date>=N'"+fromdate+"')");
            DataTable ghabzdata = new ghabz().Search("SELECT id, paid, date from ghabz where (date>=N'" + fromdate + "')");

            int counter = 0;

            foreach (DataRow dtr in allsicks.Rows)
            {
                float averagepaid = 0;
                string fd = dtr["darman_date"].ToString();

                string[] pe = lastmonthcalc(fd);
                string period = pe[0] + pe[1];

                object met5, met20, met40, sb;
                met5 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص متادون 5' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                met20 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص متادون 20' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                met40 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص متادون 40' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                sb = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='شربت متادون' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                //DataTable met5 = taj.Search("select sum(tedad) from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'قرص متادون 5' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");
                //DataTable met20 = taj.Search("select sum(tedad)*4 from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'قرص متادون 20' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");
                //DataTable met40 = taj.Search("select sum(tedad)*8 from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'قرص متادون 40' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");
                //DataTable sb = taj.Search("select sum(tedad)/5 from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'شربت متادون' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");

                float all = 0;

                float allmet = 0;

                if (met5.ToString().Trim() != "")
                    allmet += float.Parse(met5.ToString());
                if (met20.ToString().Trim() != "")
                    allmet += float.Parse(met20.ToString()) * 4;
                if (met40.ToString().Trim() != "")
                    allmet += float.Parse(met40.ToString()) * 8;
                if (sb.ToString().Trim() != "")
                    allmet += float.Parse(sb.ToString());

                //if (sb.Rows.Count > 0)
                //allmet += float.Parse(sb.Rows[0][0].ToString());

                all += allmet;

                //////////////////////////////BOOPERNORFIN/////////////////////////////////

                object boop04, boop2, boop8;
                boop04 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص بوپرنورفین 0.4' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                boop2 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص بوپرنورفین 2' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                boop8 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص بوپرنورفین 8' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");

                //DataTable boop04 = taj.Search("select sum(tedad) from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'قرص بوپرنورفین 0.4' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");
                //DataTable boop2 = taj.Search("select sum(tedad)*5 from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'قرص بوپرنورفین 2' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");
                //DataTable boop8 = taj.Search("select sum(tedad)*20 from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'قرص بوپرنورفین 8' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");

                float allboop = 0;

                if (boop04.ToString().Trim() != "")
                {
                    allboop += float.Parse(boop04.ToString());
                    all += (float.Parse(boop04.ToString()) * (float.Parse(txtboop4.Text) / float.Parse(txtmet5.Text)));
                }
                if (boop2.ToString().Trim() != "")
                {
                    allboop += float.Parse(boop2.ToString()) * 5;
                    all += (float.Parse(boop2.ToString()) * (float.Parse(txtboop2.Text) / float.Parse(txtmet5.Text)));
                }
                if (boop8.ToString().Trim() != "")
                {
                    allboop += float.Parse(boop8.ToString()) * 20;
                    all += (float.Parse(boop8.ToString()) * (float.Parse(txtboop8.Text) / float.Parse(txtmet5.Text)));
                }

                //if (boop04.Rows.Count > 0)
                //    allboop += float.Parse(boop04.Rows[0][0].ToString());
                //if (boop2.Rows.Count > 0)
                //    allboop += float.Parse(boop2.Rows[0][0].ToString());
                //if (boop8.Rows.Count > 0)
                //    allboop += float.Parse(boop8.Rows[0][0].ToString());



                //////////////////////////////SUBAXON/////////////////////////////////

                object soob2, soob8;
                soob2 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص سوباکسون 2' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                soob8 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص سوباکسون 8' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");

                //DataTable soob2 = taj.Search("select sum(tedad) from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'قرص سوباکسون 2' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");
                //DataTable soob8 = taj.Search("select sum(tedad)*4 from tajviz_koli where (id=N'" + dtr["id"] + "' and daru_name=N'قرص سوباکسون 8' and tajviz_date>=N'" + pe[0] + "' and tajviz_date<=N'" + pe[1] + "') group by id");

                float allsoob = 0;
                if (soob2.ToString().Trim() != "")
                {
                    allsoob += float.Parse(soob2.ToString());
                    all += (float.Parse(soob2.ToString()) * (float.Parse(txtsoob2.Text) / float.Parse(txtmet5.Text)));
                }
                if (soob8.ToString().Trim() != "")
                {
                    allsoob += float.Parse(soob8.ToString()) * 4;
                    all += (float.Parse(soob8.ToString()) * (float.Parse(txtsoob8.Text) / float.Parse(txtmet5.Text)));
                }

                //if (soob2.Rows.Count > 0)
                //    allsoob += float.Parse(soob2.Rows[0][0].ToString());
                //if (soob8.Rows.Count > 0)
                //    allsoob += float.Parse(soob8.Rows[0][0].ToString());

                ////////////////////////////////////////GHABZ///////////////////////////////
                object paid;
                paid = ghabzdata.Compute("SUM(paid)", "id=" + dtr["id"] + " and date>='" + pe[0].ToString() + "' and date<'" + pe[1].ToString() + "'");

                long allpaid = 0;
                if (paid.ToString().Trim() != "")
                    allpaid += long.Parse(paid.ToString());

                if (all != 0)
                    averagepaid = (float)(allpaid / all);
                else
                    averagepaid = 0;



                string allmetstring = allmet.ToString(), allboopstring = allboop.ToString(), allsoobstring = allsoob.ToString();

                if (allmet == 0)
                    allmetstring = "";
                if (allboop == 0)
                    allboopstring= "";
                if (allsoob == 0)
                    allsoobstring= "";

                    dt.Rows.Add(new object[] { ++counter, dtr["id"], dtr["name"].ToString(), fd, pe[0], pe[1], allmetstring, allboopstring, allsoobstring, allpaid, averagepaid });
            }

            grdvisit.DataSource = dt;
            grdvisit.AutoGenerateColumns = true;

            string[] col_headers = { "ردیف", "شماره پرونده", "نام و نام خانوادگی", "شروع درمان", "دوره از تاریخ", "تا تاریخ", "مصرفی متادون", "مصرفی بوپرنورفین", "مصرفی سوباکسون", "جمع هزینه ها", "متوسط هزینه" };
            int[] col_width = { 60, 70, 150, 100, 100, 100, 100, 100, 100, 100, 100 };

            for (int i = 0; i < col_headers.Length; i++)
            {
                grdvisit.Columns[i].HeaderText = col_headers[i].ToString();
                grdvisit.Columns[i].Width = col_width[i];
            }

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdvisit.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;


            
            //DataGridViewColumn dgvc = new DataGridViewColumn();
            //dgvc = grdvisit.Columns["darman_date"];
            //grdvisit.Sort(dgvc, ListSortDirection.Descending);

            //foreach (DataGridViewRow dgvr in grdvisit.Rows)
            //{
            //    if (dgvr.Cells["period"].Value != null && dgvr.Cells["period"].Value.ToString() != "")
            //    {
            //        if (dgvr.Cells["period"].Value.ToString() == "دو هفته اول")
            //            dgvr.DefaultCellStyle.BackColor = Color.LightCyan;
            //        else if (dgvr.Cells["period"].Value.ToString() == "سه ماه اول")
            //            dgvr.DefaultCellStyle.BackColor = Color.PowderBlue;
            //        else if (dgvr.Cells["period"].Value.ToString() == "شش ماه اول")
            //            dgvr.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            //        else if (dgvr.Cells["period"].Value.ToString() == "شش ماه به بعد")
            //            dgvr.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            //    }

            //    if (dgvr.Cells["visit"].Value != null && dgvr.Cells["visit"].Value.ToString() != "")
            //        dgvr.Cells["visit"].Style.BackColor = Color.Pink;

            //    if (dgvr.Cells["ravan"].Value != null && dgvr.Cells["ravan"].Value.ToString() != "")
            //        dgvr.Cells["ravan"].Style.BackColor = Color.PeachPuff;

            //    if (dgvr.Cells["darman_date"].Value.ToString().Contains("لغزش"))
            //        dgvr.DefaultCellStyle.BackColor = Color.Tomato;

            //}

            grdvisit.CurrentCell = null;

            Font averfont = new Font("tahoma", 8, FontStyle.Bold);
            Font dosefont = new Font("tahoma", 7, FontStyle.Bold);
            
            DataGridViewCellStyle dataGridViewCellStyle1= new DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            grdvisit.Columns["allpaid"].DefaultCellStyle = dataGridViewCellStyle1;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle(); 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.Font = averfont;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.BackColor = Color.Pink;
            grdvisit.Columns["averagepaid"].DefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Font = dosefont;
            dataGridViewCellStyle3.NullValue = null;
            grdvisit.Columns["allmet"].DefaultCellStyle = dataGridViewCellStyle3;
            grdvisit.Columns["allboop"].DefaultCellStyle = dataGridViewCellStyle3;
            grdvisit.Columns["allsoob"].DefaultCellStyle = dataGridViewCellStyle3;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!txtdate.MaskCompleted && txtboop4.Text == "" && txtboop2.Text == "" && txtboop8.Text == "" && txtsoob2.Text == "" && txtsoob8.Text == "")
            {
                btnRefresh.Enabled = false;
            }
            else
            {
                btnRefresh.Enabled = true;
            }
        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnRiz_Click(object sender, EventArgs e)
        {
            if (grdvisit.CurrentRow != null)
            {
                int rindex = grdvisit.CurrentCell.RowIndex;

                frmHazinehEnferadiPeygiri fhepv = new frmHazinehEnferadiPeygiri();

                fhepv.zmet5 = txtmet5.Text;
                fhepv.zboop4 = txtboop4.Text;
                fhepv.zboop2 = txtboop2.Text;
                fhepv.zboop8 = txtboop8.Text;
                fhepv.zsoob2 = txtsoob2.Text;
                fhepv.zsoob8 = txtsoob8.Text;

                fhepv.txtdarman_date.Text = grdvisit["darman_date", rindex].Value.ToString();
                fhepv.txtid.Text = grdvisit["id", rindex].Value.ToString();
                fhepv.txtname.Text = grdvisit["name", rindex].Value.ToString();
                fhepv.txttodate.Text = grdvisit["todate", rindex].Value.ToString();

                fhepv.ShowDialog();
            }
        }
    }
}