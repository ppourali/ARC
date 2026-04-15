using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Threading;

namespace Mehr.Presentation_Layers
{
    public partial class FrmSelectBoopYear : Form
    {
        DataTable dt = new DataTable();

        public FrmSelectBoopYear()
        {
            InitializeComponent();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {

            if (txtyear.Text.Trim() == "")
                btnPrint.Enabled = false;
            else
            {
                btnPrint.Enabled = true;
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

        private void Enter_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.Yellow;
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.Yellow;
                ((NumericUpDown)sender).Focus();
                ((NumericUpDown)sender).Select(0, 4);
            }

        }


        private void Leave_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.White;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void frmSelectBoopYear_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            txtyear.Focus();

        }


        private void btnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string fromdate = txtyear.Value.ToString() + "/01/01";
            string todate = txtyear.Value.ToString() + "/12/30";


            DataTable id_dt = new tahvil().Search("select distinct id from tahvil where (daru_name like N'%بوپر%' and tahvil_date>=N'" + fromdate + "' and tahvil_date <=N'" + todate + "')");


            FrmBoopYearTahvilPrintViewer ftpv = new FrmBoopYearTahvilPrintViewer();

            DataTable kol_Query = new MehrDataSet.metyearDataTable();

            kol_Query.Clear();

            int mard = 0, zan = 0;

            tahvil ta = new tahvil();
            foreach (DataRow dr in id_dt.Rows)
            {
                DataTable allDaruTahvil = ta.Search("SELECT distinct t0.tahvil_date, 'بوپرنورفین' as type, t0.id, t0.date, isnull(t1.tedad,0) + isnull(t2.tedad,0) + isnull(t3.tedad,0) as tedad FROM tahvil t0 " +
                "left JOIN ( SELECT tedad*0.4 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 0.4' and id=N'" + dr["id"].ToString() + "' and date>=N'" + fromdate + "' and date<=N'" + todate + "')) t1 ON t0.date = t1.date " +
                "left JOIN ( SELECT tedad*2 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 2' and id=N'" + dr["id"].ToString() + "' and date>=N'" + fromdate + "' and date<=N'" + todate + "')) t2 ON t0.date = t2.date " +
                "left JOIN ( SELECT tedad*8 as tedad,date FROM tahvil where(daru_name=N'قرص بوپرنورفین 8' and id=N'" + dr["id"].ToString() + "' and date>=N'" + fromdate + "' and date<=N'" + todate + "')) t3 ON t0.date = t3.date " +
                "Where (t0.id=N'" + dr["id"].ToString() + "'  and t0.daru_name like N'%بوپر%' and t0.date>=N'" + fromdate + "' and t0.date<=N'" + todate + "') order by t0.date");

                #region SB_Filler

                DataTable info_dt = new tahvil().Search("select id,name,id_no, father_name, darman_date,home+'-'+mobile as tel, b_date, city, sex, payan_date, address from sicks where (id='" + dr["id"].ToString() + "')");

                if (info_dt.Rows[0]["sex"].ToString() == "مذکر")
                {
                    mard++;
                }
                else if (info_dt.Rows[0]["sex"].ToString() == "مونث")
                {
                    zan++;
                }


                if (info_dt.Rows[0]["sex"].ToString() == "مذکر" && !info_dt.Rows[0]["payan_date"].ToString().Contains(" "))
                {
                    if (Decimal.Parse(info_dt.Rows[0]["payan_date"].ToString().Replace("/", "")) <= Decimal.Parse(todate.Replace("/", "")))
                        mard--;
                }
                else if (info_dt.Rows[0]["sex"].ToString() == "مونث" && !info_dt.Rows[0]["payan_date"].ToString().Contains(" "))
                {
                    if (Decimal.Parse(info_dt.Rows[0]["payan_date"].ToString().Replace("/", "")) <= Decimal.Parse(todate.Replace("/", "")))
                        zan--;
                }


                string[] dd = new string[12];
                for (int s = 0; s < 12; s++)
                    dd[s] = "";

                float sum_sb = 0;

                for (int i = 1; i <= 12; i++)
                    for (int j = 0; j < allDaruTahvil.Rows.Count; j++)
                    {
                        string tempdate = fromdate.Substring(0, 4) + "/" + i.ToString("00") + "/";

                        string dtr = allDaruTahvil.Compute("sum(tedad)", "substring(tahvil_date,1,8)='" + tempdate + "'").ToString();
                        if (dtr.Trim() == "")
                        {
                            dd[i - 1] = "0";
                        }
                        else
                        {
                            dd[i - 1] = dtr.Trim();
                        }
                    }

                #endregion

                kol_Query.Rows.Add(info_dt.Rows[0]["id"].ToString(), info_dt.Rows[0]["darman_date"].ToString(), info_dt.Rows[0]["name"].ToString(), info_dt.Rows[0]["father_name"].ToString(), info_dt.Rows[0]["b_date"].ToString(), info_dt.Rows[0]["city"].ToString(), info_dt.Rows[0]["id_no"].ToString(), info_dt.Rows[0]["tel"].ToString(),
                        dd[0], dd[1], dd[2], dd[3], dd[4], dd[5], dd[6], dd[7], dd[8], dd[9], dd[10], dd[11], info_dt.Rows[0]["address"].ToString());
            }

            ftpv.filler_kol = kol_Query;

            Darmangah sh = new Darmangah();
            ftpv.markaz_name = sh.Select().Rows[0]["name"].ToString().Trim();
            ftpv.shahr = sh.Select().Rows[0]["address"].ToString().Trim();
            ftpv.sal = txtyear.Value.ToString();

            ftpv.Show();
            this.Close();
        }
    }
}