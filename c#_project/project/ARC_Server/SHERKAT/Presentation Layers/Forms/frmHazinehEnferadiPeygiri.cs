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
    public partial class FrmHazinehEnferadiPeygiri : Form
    {

        public string  operand;
        public Color col;
        public string cur_date, id;
        public DataTable filler = new DataTable();
        DataTable dtforchart = new DataTable();


        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public FrmHazinehEnferadiPeygiri()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            dtforchart.Columns.Add("income");
            dtforchart.Columns.Add("allpaid");
            dtforchart.Columns.Add("alldaru");
            dtforchart.Columns.Add("month");

            RefreshData();
        }

        private void RefreshData()
        {
            Cursor.Current = Cursors.WaitCursor;

            grdvisit.DataSource = null;

            string zboop4, zboop2, zboop8, zsoob2, zsoob8, zmet5;
            zboop4 = txtboop4.Text;
            zboop2 = txtboop2.Text;
            zboop8 = txtboop8.Text;
            zsoob2 = txtsoob2.Text;
            zsoob8 = txtsoob8.Text;
            zmet5 = txtmet5.Text;

            string min_hazineh = txtmin_hazineh.Text;

            dtforchart.Clear();

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

            string fromdate = txtdarman_date.Text;


            tajviz_koli taj = new tajviz_koli();
            DataTable tajdata = taj.Search("SELECT id, tajviz_date, tedad, daru_name from tajviz_koli where (id=N'" + txtid.Text + "' and tajviz_date>=N'" + fromdate + "')");
            DataTable ghabzdata = new ghabz().Search("SELECT id, paid, date from ghabz where (id=N'" + txtid.Text + "' and date>=N'" + fromdate + "')");


            float averagepaid = 0;

            string tod = txttodate.Text;
            string next_month = "", pre_next_week = "", fd = txtdarman_date.Text;

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

                //next_month = (Shamsi((temp_date.AddMonths(1)).Year.ToString("0000") + "/" +
                //                        (temp_date.AddMonths(1)).Month.ToString("00") + "/" +
                //                        (temp_date.AddMonths(1)).Day.ToString("00")));

                next_month = nextmonthcalc(fd);
                i++;



                object met5, met20, met40, sb;
                met5 = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='قرص متادون 5' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                met20 = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='قرص متادون 20' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                met40 = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='قرص متادون 40' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                sb = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='شربت متادون' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");

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
                boop04 = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='قرص بوپرنورفین 0.4' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                boop2 = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='قرص بوپرنورفین 2' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                boop8 = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='قرص بوپرنورفین 8' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");

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
                soob2 = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='قرص سوباکسون 2' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");
                soob8 = tajdata.Compute("SUM(tedad)", "id=" + txtid.Text + " and daru_name='قرص سوباکسون 8' and tajviz_date>='" + fd + "' and tajviz_date<'" + next_month + "'");

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
                paid = ghabzdata.Compute("SUM(paid)", "id=" + txtid.Text + " and date>='" + fd + "' and date<'" + next_month + "'");

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

                dt.Rows.Add(new object[] { i, fd, next_month, allmetstring, allboopstring, allsoobstring, allpaid, averagepaid });
                fd = next_month;



                dtforchart.Rows.Add(new object[] { averagepaid, allpaid, all, i });

            }

            dt.DefaultView.Sort = "todate desc";
            grdvisit.DataSource = dt;
            grdvisit.AutoGenerateColumns = true;

            string[] col_headers = { "ردیف", "دوره از تاریخ", "تا تاریخ", "مصرفی متادون", "مصرفی بوپرنورفین", "مصرفی سوباکسون", "جمع هزینه ها", "متوسط هزینه" };
            int[] col_width = { 60, 100, 100, 100, 100, 100, 100, 100, 100 };

            for (int j = 0; j < col_headers.Length; j++)
            {
                grdvisit.Columns[j].HeaderText = col_headers[j].ToString();
                grdvisit.Columns[j].Width = col_width[j];
            }

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdvisit.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;


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

            foreach (DataGridViewRow dgvr in grdvisit.Rows)
            {
                if (operand.Equals("<"))
                {
                    if (float.Parse(dgvr.Cells["averagepaid"].Value.ToString()) < float.Parse(min_hazineh) && (dgvr.Cells["allmet"].Value.ToString() != "" || dgvr.Cells[                               "allboop"].Value.ToString() != "" || dgvr.Cells["allsoob"].Value.ToString() != ""))
                    {
                        dgvr.DefaultCellStyle.BackColor = col;
                    }
                }
                else if (operand.Equals("<="))
                {
                    if (float.Parse(dgvr.Cells["averagepaid"].Value.ToString()) <= float.Parse(min_hazineh) && (dgvr.Cells["allmet"].Value.ToString() != "" || dgvr.Cells["allboop"].Value.ToString() != "" || dgvr.Cells["allsoob"].Value.ToString() != ""))
                    {
                        dgvr.DefaultCellStyle.BackColor = col;
                    }
                }
                else if (operand.Equals("="))
                {
                    if (float.Parse(dgvr.Cells["averagepaid"].Value.ToString()) == float.Parse(min_hazineh) && (dgvr.Cells["allmet"].Value.ToString() != "" || dgvr.Cells["allboop"].Value.ToString() != "" || dgvr.Cells["allsoob"].Value.ToString() != ""))
                    {
                        dgvr.DefaultCellStyle.BackColor = col;
                    }
                }
                else if (operand.Equals(">="))
                {
                    if (float.Parse(dgvr.Cells["averagepaid"].Value.ToString()) >= float.Parse(min_hazineh) && (dgvr.Cells["allmet"].Value.ToString() != "" || dgvr.Cells["allboop"].Value.ToString() != "" || dgvr.Cells["allsoob"].Value.ToString() != ""))
                    {
                        dgvr.DefaultCellStyle.BackColor = col;
                    }
                }
                else if (operand.Equals(">"))
                {
                    if (float.Parse(dgvr.Cells["averagepaid"].Value.ToString()) > float.Parse(min_hazineh) && (dgvr.Cells["allmet"].Value.ToString() != "" || dgvr.Cells["allboop"].Value.ToString() != "" || dgvr.Cells["allsoob"].Value.ToString() != ""))
                    {
                        dgvr.DefaultCellStyle.BackColor = col;
                    }
                }
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

            return enddate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMotevasetHazinehPrintViewer f = new FrmMotevasetHazinehPrintViewer();

            //DataTable dt = new DataTable();
            //dt.Columns.Add("income");
            //dt.Columns.Add("month");

            //string fromdate,todate;
            //for (int i = 1; i <= grdvisit.Rows.Count; i++)
            //{
            //    fromdate = grdvisit["fromdate", i - 1].Value.ToString();
            //    todate = grdvisit["todate", i - 1].Value.ToString();


            //    dt.Rows.Add(new object[] { grdvisit["averagepaid", i - 1].Value.ToString(), grdvisit["radif", i - 1].Value.ToString() });
            //}

            f.filler = dtforchart;

            f.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();

            string tempaverageprices = (txtmet5.Text + "-" + txtboop4.Text + "-" + txtboop2.Text + "-" + txtboop8.Text + "-" + txtsoob2.Text + "-" + txtsoob8.Text + "-" + txtmin_hazineh.Text).Trim();

            if (!tempaverageprices.Equals(Properties.Settings.Default.AveragePrices.ToString().Trim()))
            {
                Properties.Settings.Default.AveragePrices = tempaverageprices;
                Properties.Settings.Default.Save();
            }
        }
    }
}