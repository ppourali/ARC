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
    public partial class frmMarkazHazinehPeygiri : Form
    {

        public string cur_date;
        public DataTable filler = new DataTable();

        string AveragePrice = "";
        string[] price;

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        public frmMarkazHazinehPeygiri()
        {
            InitializeComponent();
        }

        private void printviewer_Load(object sender, EventArgs e)
        {
            AveragePrice = Properties.Settings.Default.AveragePrices.ToString().Trim();

            try
            {
                price = AveragePrice.Split('-');

                txtmet5.Text = price[0];
                txtboop4.Text = price[1];
                txtboop2.Text = price[2];
                txtboop8.Text = price[3];
                txtsoob2.Text = price[4];
                txtsoob8.Text = price[5];
            }
            catch
            {
                txtmet5.Text = "0";
                txtboop4.Text = "0";
                txtboop2.Text = "0";
                txtboop8.Text = "0";
                txtsoob2.Text = "0";
                txtsoob8.Text = "0";
            }
            
            txtyear.Text = cur_date.Substring(0, 4);
            reportDataSource1.Name = "MehrDataSet_markazhazinehpeygiri";
            reportDataSource1.Value = filler;

            reportViewer1.LocalReport.EnableExternalImages = true;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mehr.Presentation_Layers.Reports.Charts.rptMarkazHazineh_Chart.rdlc";

            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataTable dt = new DataTable();
            dt.Columns.Add("month");
            dt.Columns.Add("allmet");
            dt.Columns.Add("allboop");
            dt.Columns.Add("allsoob");
            dt.Columns.Add("allpaid");
            dt.Columns.Add("averagepaid");

            dt.Columns["allpaid"].DataType = typeof(float);
            dt.Columns["averagepaid"].DataType = typeof(long);



            string[] monthname = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            string year = "";

            tajviz_koli taj = new tajviz_koli();

            string fromdate = txtyear.Value.ToString() + @"/01/01";
            string todate = txtyear.Value.ToString() + @"/12/30";
            DataTable tajdata = taj.Search("SELECT id, tajviz_date, tedad, daru_name from tajviz_koli where (tajviz_date>=N'" + fromdate + "' and tajviz_date<=N'" + todate + "')");
            DataTable ghabzdata = new ghabz().Search("SELECT id, paid, date from ghabz where (date>=N'" + fromdate + "' and date<=N'" + todate + "')");



            for (int i = 0; i < monthname.Length; i++)
            {

                year = txtyear.Value.ToString() + @"/";
                if (i == 0)
                {
                    fromdate = year + "01/01";
                    todate = year + "01/31";
                }
                else if (i == 1)
                {
                    fromdate = year + "02/01";
                    todate = year + "02/31";
                }
                else if (i == 2)
                {
                    fromdate = year + "03/01";
                    todate = year + "03/31";
                }
                else if (i == 3)
                {
                    fromdate = year + "04/01";
                    todate = year + "04/31";
                }
                else if (i == 4)
                {
                    fromdate = year + "05/01";
                    todate = year + "05/31";
                }
                else if (i == 5)
                {
                    fromdate = year + "06/01";
                    todate = year + "06/31";
                }
                else if (i == 6)
                {
                    fromdate = year + "07/01";
                    todate = year + "07/30";
                }
                else if (i == 7)
                {
                    fromdate = year + "08/01";
                    todate = year + "08/30";
                }
                else if (i == 8)
                {
                    fromdate = year + "09/01";
                    todate = year + "09/30";
                }
                else if (i == 9)
                {
                    fromdate = year + "10/01";
                    todate = year + "10/30";
                }
                else if (i == 10)
                {
                    fromdate = year + "11/01";
                    todate = year + "11/30";
                }
                else if (i == 11)
                {
                    fromdate = year + "12/01";
                    todate = year + "12/30";
                }


                float averagepaid = 0;

                object met5, met20, met40, sb;
                met5 = tajdata.Compute("SUM(tedad)", "daru_name='قرص متادون 5' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");
                met20 = tajdata.Compute("SUM(tedad)", "daru_name='قرص متادون 20' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");
                met40 = tajdata.Compute("SUM(tedad)", "daru_name='قرص متادون 40' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");
                sb = tajdata.Compute("SUM(tedad)", "daru_name='شربت متادون' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");

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
                boop04 = tajdata.Compute("SUM(tedad)", "daru_name='قرص بوپرنورفین 0.4' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");
                boop2 = tajdata.Compute("SUM(tedad)", "daru_name='قرص بوپرنورفین 2' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");
                boop8 = tajdata.Compute("SUM(tedad)", "daru_name='قرص بوپرنورفین 8' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");

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
                soob2 = tajdata.Compute("SUM(tedad)", "daru_name='قرص سوباکسون 2' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");
                soob8 = tajdata.Compute("SUM(tedad)", "daru_name='قرص سوباکسون 8' and tajviz_date>='" + fromdate + "' and tajviz_date<='" + todate + "'");

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
                paid = ghabzdata.Compute("SUM(paid)", "date>='" + fromdate + "' and date<='" + todate + "'");

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

                dt.Rows.Add(new object[] { monthname[i], allmetstring, allboopstring, allsoobstring, allpaid, averagepaid });
            }

            this.reportDataSource1.Value = dt;
            this.reportViewer1.RefreshReport();

            string tempaverageprices = (txtmet5.Text + "-" + txtboop4.Text + "-" + txtboop2.Text + "-" + txtboop8.Text + "-" + txtsoob2.Text + "-" + txtsoob8.Text + "-" + price[6].Trim()).Trim();

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



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtyear.Text == "" && txtboop4.Text == "" && txtboop2.Text == "" && txtboop8.Text == "" && txtsoob2.Text == "" && txtsoob8.Text == "")
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

    }
}