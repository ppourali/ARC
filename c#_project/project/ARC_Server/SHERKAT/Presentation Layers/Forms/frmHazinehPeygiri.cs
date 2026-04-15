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
    public partial class FrmHazinehPeygiri : Form
    {
        int tedadforchartprint = 0;

        public string cur_date;
        public DataTable filler = new DataTable();

        string AveragePrice = "";

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public FrmHazinehPeygiri()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            txtdate.Text = cur_date;
            txtOpernad.SelectedIndex = 0;
            txtcolor.Text = colorDialog1.Color.Name;
            txtcolor.ForeColor = colorDialog1.Color;

            AveragePrice = Properties.Settings.Default.AveragePrices.ToString().Trim();

            try
            {
                string[] price = AveragePrice.Split('-');

                txtmet5.Text = price[0];
                txtboop4.Text = price[1];
                txtboop2.Text = price[2];
                txtboop8.Text = price[3];
                txtsoob2.Text = price[4];
                txtsoob8.Text = price[5];
                txtmin_hazineh.Text = price[6];
            }
            catch
            {
                txtmet5.Text = "0";
                txtboop4.Text = "0";
                txtboop2.Text = "0";
                txtboop8.Text = "0";
                txtsoob2.Text = "0";
                txtsoob8.Text = "0";

                txtmin_hazineh.Text = "0";
            }
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

            tedadforchartprint = 0;

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

            tajviz_koli taj = new tajviz_koli();

            string fromdate = lastmonthcalc(txtdate.Text)[0];
            DataTable tajdata = taj.Search("SELECT id, tajviz_date, tedad, daru_name from tajviz_koli where (tajviz_date>=N'" + fromdate + "')");
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

                all += allmet;

                //////////////////////////////BOOPERNORFIN/////////////////////////////////

                object boop04, boop2, boop8;
                boop04 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص بوپرنورفین 0.4' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                boop2 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص بوپرنورفین 2' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                boop8 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص بوپرنورفین 8' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");


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


                //////////////////////////////SUBAXON/////////////////////////////////

                object soob2, soob8;
                soob2 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص سوباکسون 2' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");
                soob8 = tajdata.Compute("SUM(tedad)", "id=" + dtr["id"] + " and daru_name='قرص سوباکسون 8' and tajviz_date>='" + pe[0].ToString() + "' and tajviz_date<'" + pe[1].ToString() + "'");

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
                    allboopstring = "";
                if (allsoob == 0)
                    allsoobstring = "";

                dt.Rows.Add(new object[] { ++counter, dtr["id"], dtr["name"].ToString(), fd, pe[0], pe[1], allmetstring, allboopstring, allsoobstring, allpaid, averagepaid });
            }

            grdvisit.DataSource = dt;
            grdvisit.AutoGenerateColumns = true;

            string[] col_headers = { "ردیف", "شماره پرونده", "نام و نام خانوادگی", "شروع درمان", "دوره از تاریخ", "تا تاریخ", "مصرفی متادون", "مصرفی بوپرنورفین", "مصرفی سوباکسون", "جمع هزینه ها", "متوسط هزینه" };
            int[] col_width = { 60, 100, 135, 95, 95, 95, 100, 100, 100, 100, 100 };

            for (int i = 0; i < col_headers.Length; i++)
            {
                grdvisit.Columns[i].HeaderText = col_headers[i].ToString();
                grdvisit.Columns[i].Width = col_width[i];
            }

            grdvisit.CurrentCell = null;

            Font averfont = new Font("tahoma", 8, FontStyle.Bold);
            Font dosefont = new Font("tahoma", 7, FontStyle.Bold);

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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

            FindUnderTreaShld(txtboop4.Text, txtboop2.Text, txtboop8.Text, txtsoob2.Text, txtsoob8.Text, txtmet5.Text);

            string tempaverageprices = (txtmet5.Text + "-" + txtboop4.Text + "-" + txtboop2.Text + "-" + txtboop8.Text + "-" + txtsoob2.Text + "-" + txtsoob8.Text + "-" + txtmin_hazineh.Text).Trim();

            if (!tempaverageprices.Equals(AveragePrice))
            {
                Properties.Settings.Default.AveragePrices = tempaverageprices;
                Properties.Settings.Default.Save();
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
                ((DateMaskedTextbox)sender).Select(0, 10);
            }

            else if (sender.GetType() == typeof(DomainUpDown))
            {

                ((DomainUpDown)sender).BackColor = Color.Yellow;
                ((DomainUpDown)sender).Focus();
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
            else if (sender.GetType() == typeof(DomainUpDown))
            {
                ((DomainUpDown)sender).BackColor = Color.White;
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
            if (sender != txtdate && sender != txtOpernad)
            {
                if (((TextBox)sender).Text.Trim() == "")
                {
                    ((TextBox)sender).Text = "0";
                    ((TextBox)sender).SelectAll();
                }
            }

            if (!txtdate.MaskCompleted && txtmin_hazineh.Text == "" && txtboop4.Text == "" && txtboop2.Text == "" && txtboop8.Text == "" && txtsoob2.Text == "" && txtsoob8.Text == "")
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

                FrmHazinehEnferadiPeygiri fhepv = new FrmHazinehEnferadiPeygiri();

                fhepv.txtmet5.Text = txtmet5.Text;
                fhepv.txtboop4.Text = txtboop4.Text;
                fhepv.txtboop2.Text = txtboop2.Text;
                fhepv.txtboop8.Text = txtboop8.Text;
                fhepv.txtsoob2.Text = txtsoob2.Text;
                fhepv.txtsoob8.Text = txtsoob8.Text;
                fhepv.txtmin_hazineh.Text = txtmin_hazineh.Text;
                fhepv.operand = txtOpernad.Text;
                fhepv.col = colorDialog1.Color;

                fhepv.txtdarman_date.Text = grdvisit["darman_date", rindex].Value.ToString();
                fhepv.txtid.Text = grdvisit["id", rindex].Value.ToString();
                fhepv.txtname.Text = grdvisit["name", rindex].Value.ToString();
                fhepv.txttodate.Text = grdvisit["todate", rindex].Value.ToString();

                fhepv.ShowDialog();
            }
        }

        private void FindUnderTreaShld(string zboop4, string zboop2, string zboop8, string zsoob2, string zsoob8, string zmet5)
        {

            Cursor.Current = Cursors.WaitCursor;

            foreach (DataGridViewRow dgvr in grdvisit.Rows)
            {
                int numbertocount = 0;

                string darman_date = dgvr.Cells["darman_date"].Value.ToString();
                string id = dgvr.Cells["id"].Value.ToString();
                string name = dgvr.Cells["name"].Value.ToString();
                string todate = dgvr.Cells["todate"].Value.ToString();

                DataTable dt = new DataTable();
                dt.Columns.Add("radif");
                dt.Columns.Add("Fromdate");
                dt.Columns.Add("Todate");
                dt.Columns.Add("allmet");
                dt.Columns.Add("allboop");
                dt.Columns.Add("allsoob");
                dt.Columns.Add("allpaid");
                dt.Columns.Add("averagepaid");

                dt.Columns["allpaid"].DataType = typeof(float);
                dt.Columns["averagepaid"].DataType = typeof(long);

                string fromdate = darman_date;



                tajviz_koli taj = new tajviz_koli();
                DataTable tajdata = taj.Search("SELECT id, tajviz_date, tedad, daru_name from tajviz_koli where (id=N'" + id + "' and tajviz_date>=N'" + fromdate + "')");
                DataTable ghabzdata = new ghabz().Search("SELECT id, paid, date from ghabz where (id=N'" + id + "' and date>=N'" + fromdate + "')");


                float averagepaid = 0;

                string tod = todate;
                string next_month = "", pre_next_week = "", fd = darman_date;

                int i = 0;

                while (string.CompareOrdinal(next_month, tod) < 0)
                {

                    System.Globalization.PersianCalendar td = new System.Globalization.PersianCalendar();
                    DateTime temp_date = td.ToDateTime(int.Parse(fd.Substring(0, 4)),
                                                            int.Parse(fd.Substring(5, 2)),
                                                            int.Parse(fd.Substring(8, 2)),
                                                            0, 0, 0, 0, 0);



                    pre_next_week = (Shamsi((temp_date.AddMonths(1)).Year.ToString("0000") + "/" +
                                          (temp_date.AddMonths(1)).Month.ToString("00") + "/" +
                                          (temp_date.AddMonths(1)).Day.ToString("00")));


                    next_month = nextmonthcalc(fd);
                    i++;


                    object met5, met20, met40, sb;
                    met5 = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='قرص متادون 5' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                    met20 = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='قرص متادون 20' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                    met40 = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='قرص متادون 40' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                    sb = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='شربت متادون' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");

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

                    all += allmet;

                    //////////////////////////////BOOPERNORFIN/////////////////////////////////

                    object boop04, boop2, boop8;
                    boop04 = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='قرص بوپرنورفین 0.4' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                    boop2 = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='قرص بوپرنورفین 2' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                    boop8 = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='قرص بوپرنورفین 8' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");

                    float allboop = 0;

                    if (boop04.ToString().Trim() != "")
                    {
                        allboop += float.Parse(boop04.ToString());
                        all += (float.Parse(boop04.ToString()) * (float.Parse(zboop4) / float.Parse(zmet5)));
                    }
                    if (boop2.ToString().Trim() != "")
                    {
                        allboop += float.Parse(boop2.ToString()) * 5;
                        all += (float.Parse(boop2.ToString()) * (float.Parse(zboop2) / float.Parse(zmet5)));
                    }
                    if (boop8.ToString().Trim() != "")
                    {
                        allboop += float.Parse(boop8.ToString()) * 20;
                        all += (float.Parse(boop8.ToString()) * (float.Parse(zboop8) / float.Parse(zmet5)));
                    }


                    //////////////////////////////SUBAXON/////////////////////////////////

                    object soob2, soob8;
                    soob2 = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='قرص سوباکسون 2' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                    soob8 = tajdata.Compute("SUM(tedad)", "id=" + id + " and daru_name='قرص سوباکسون 8' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");

                    float allsoob = 0;
                    if (soob2.ToString().Trim() != "")
                    {
                        allsoob += float.Parse(soob2.ToString());
                        all += (float.Parse(soob2.ToString()) * (float.Parse(zsoob2) / float.Parse(zmet5)));
                    }
                    if (soob8.ToString().Trim() != "")
                    {
                        allsoob += float.Parse(soob8.ToString()) * 4;
                        all += (float.Parse(soob8.ToString()) * (float.Parse(zsoob8) / float.Parse(zmet5)));
                    }


                    ////////////////////////////////////////GHABZ///////////////////////////////
                    object paid;
                    paid = ghabzdata.Compute("SUM(paid)", "id=" + id + " and date>='" + fd + "' and date<'" + next_month + "'");

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
                        allboopstring = "";
                    if (allsoob == 0)
                        allsoobstring = "";

                    fd = next_month;


                    if (txtOpernad.Text.Equals("<"))
                    {
                        if (averagepaid < float.Parse(txtmin_hazineh.Text) && (allmetstring != "" || allboopstring != "" || allsoobstring != ""))
                        {
                            if ((++numbertocount) == int.Parse(txtNumber.Text))
                            {
                                dgvr.DefaultCellStyle.BackColor = colorDialog1.Color;
                                tedadforchartprint++;
                                break;
                            }
                        }
                    }
                    else if (txtOpernad.Text.Equals("<="))
                    {
                        if (averagepaid <= float.Parse(txtmin_hazineh.Text) && (allmetstring != "" || allboopstring != "" || allsoobstring != ""))
                        {
                            if ((++numbertocount) == int.Parse(txtNumber.Text))
                            {
                                dgvr.DefaultCellStyle.BackColor = colorDialog1.Color;
                                tedadforchartprint++;
                                break;
                            }
                        }
                    }
                    else if (txtOpernad.Text.Equals("="))
                    {
                        if (averagepaid == float.Parse(txtmin_hazineh.Text) && (allmetstring != "" || allboopstring != "" || allsoobstring != ""))
                        {
                            if ((++numbertocount) == int.Parse(txtNumber.Text))
                            {
                                dgvr.DefaultCellStyle.BackColor = colorDialog1.Color;
                                tedadforchartprint++;
                                break;
                            }
                        }
                    }
                    else if (txtOpernad.Text.Equals(">"))
                    {
                        if (averagepaid > float.Parse(txtmin_hazineh.Text) && (allmetstring != "" || allboopstring != "" || allsoobstring != ""))
                        {
                            if ((++numbertocount) == int.Parse(txtNumber.Text))
                            {
                                dgvr.DefaultCellStyle.BackColor = colorDialog1.Color;
                                tedadforchartprint++;
                                break;
                            }
                        }
                    }
                    else if (txtOpernad.Text.Equals(">="))
                    {
                        if (averagepaid >= float.Parse(txtmin_hazineh.Text) && (allmetstring != "" || allboopstring != "" || allsoobstring != ""))
                        {
                            if ((++numbertocount) == int.Parse(txtNumber.Text))
                            {
                                dgvr.DefaultCellStyle.BackColor = colorDialog1.Color;
                                tedadforchartprint++;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private string nextmonthcalc(string nowdate)
        {
            string enddate = "";
            if (int.Parse(nowdate.Substring(5, 2)) < 12)
            {

                string endyear = int.Parse(nowdate.Substring(0, 4)).ToString("0000");
                string endday = int.Parse(nowdate.Substring(8, 2)).ToString("00");

                string endmonth = (int.Parse(nowdate.Substring(5, 2)) + 1).ToString("00");

                enddate = endyear + "/" + endmonth + "/" + endday;
            }
            else
            {
                string endyear = (int.Parse(nowdate.Substring(0, 4)) + 1).ToString("0000");
                string endday = int.Parse(nowdate.Substring(8, 2)).ToString("00");

                string endmonth = "01";

                enddate = endyear + "/" + endmonth + "/" + endday;
            }

            if (enddate.Substring(5, 5).Equals("12/30"))
            {
                System.Globalization.PersianCalendar ly = new System.Globalization.PersianCalendar();
                if (!ly.IsLeapYear(int.Parse(enddate.Substring(0,4))))
                {
                    enddate = enddate.Substring(0, 8) + "29";
                }
            }
            return enddate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = false;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtcolor.Text = colorDialog1.Color.Name;
                txtcolor.ForeColor = colorDialog1.Color;
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            DataTable dt = new MehrDataSet.AverageHazinehGroupDataTable();

            dt.Rows.Add(new object[] { "تعداد بیماران زیر هزینه پایه", tedadforchartprint });


            int count1000 = ((DataTable)grdvisit.DataSource).Select("averagepaid>=1000").Length;
            if (count1000 > 0)
                dt.Rows.Add(new object[] { "متوسط هزینه از 1000 به بالا", count1000 });


            int range = 100;
            for (int i = 1000; i > 0; i -= range)
            {
                int count = ((DataTable)grdvisit.DataSource).Select("averagepaid<" + i.ToString() + " and averagepaid>=" + (i - range).ToString()).Length;

                dt.Rows.Add(new object[] { "متوسط هزینه از " + (i - range).ToString() + " تا " + i.ToString(), count });
            }


            FrmAverageHazinehChartPrintViewer fahc = new FrmAverageHazinehChartPrintViewer();
            fahc.filler = dt;
            fahc.Show();
        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            if (grdvisit.CurrentRow != null)
            {
                FrmSickHisView fsh = new FrmSickHisView();
                fsh.txtid.Text = grdvisit["id", grdvisit.CurrentCell.RowIndex].Value.ToString();
                fsh.sabegheh = true;
                fsh.Show();
            }
        }
    }
}