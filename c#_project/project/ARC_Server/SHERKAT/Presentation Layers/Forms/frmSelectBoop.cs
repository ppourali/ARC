using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Mehr.Presentation_Layers
{
    public partial class FrmSelectBoop : Form
    {
        DataTable dt = new DataTable();

        public FrmSelectBoop()
        {
            InitializeComponent();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {

            if (txtmonth.Text == "" || txtyear.Text.Trim() == "")
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


        private void frmSelectBoop_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            chboxDaily.Checked = true;

            txtmonth.Focus();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (chboxDaily.Checked)
                printDaily();
            else
                printbytahvil();
        }

        private void printDaily()
        {

            # region date generator by combobox
            string year, fromdate = "", todate = "";

            year = txtyear.Value.ToString() + @"/";

            if (txtmonth.SelectedIndex == 0)
            {
                fromdate = year + "01/01";
                todate = year + "01/31";
            }
            else if (txtmonth.SelectedIndex == 1)
            {
                fromdate = year + "02/01";
                todate = year + "02/31";
            }
            else if (txtmonth.SelectedIndex == 2)
            {
                fromdate = year + "03/01";
                todate = year + "03/31";
            }
            else if (txtmonth.SelectedIndex == 3)
            {
                fromdate = year + "04/01";
                todate = year + "04/31";
            }
            else if (txtmonth.SelectedIndex == 4)
            {
                fromdate = year + "05/01";
                todate = year + "05/31";
            }
            else if (txtmonth.SelectedIndex == 5)
            {
                fromdate = year + "06/01";
                todate = year + "06/31";
            }
            else if (txtmonth.SelectedIndex == 6)
            {
                fromdate = year + "07/01";
                todate = year + "07/30";
            }
            else if (txtmonth.SelectedIndex == 7)
            {
                fromdate = year + "08/01";
                todate = year + "08/30";
            }
            else if (txtmonth.SelectedIndex == 8)
            {
                fromdate = year + "09/01";
                todate = year + "09/30";
            }
            else if (txtmonth.SelectedIndex == 9)
            {
                fromdate = year + "10/01";
                todate = year + "10/30";
            }
            else if (txtmonth.SelectedIndex == 10)
            {
                fromdate = year + "11/01";
                todate = year + "11/30";
            }
            else if (txtmonth.SelectedIndex == 11)
            {
                fromdate = year + "12/01";

                System.Globalization.PersianCalendar ly = new System.Globalization.PersianCalendar();
                if (ly.IsLeapYear(int.Parse(txtyear.Value.ToString())))
                {
                    todate = year + "12/30";
                }
                else
                {
                    todate = year + "12/29";
                }

            }
            # endregion

            FrmBoopTahvilPrintViewer fbtpv = new FrmBoopTahvilPrintViewer();

            DataTable id_dt = new tahvil().Search("select distinct id from tahvil where (daru_name like N'%بوپر%' and tahvil_date>='" + fromdate + "' and tahvil_date <='" + todate + "')");

            DataTable kol_boop_Query = new MehrDataSet.kol_boopDataTable();

            kol_boop_Query.Clear();

            int mard = 0, zan = 0;

            foreach (DataRow dr in id_dt.Rows)
            {
                #region B.4_Filler

                DataTable info_dt = new tahvil().Search("select id,name,id_no, father_name, darman_date, masrafi_type, b_date, city, sex, payan_date from sicks where (id='" + dr["id"].ToString() + "')");
                DataTable sb_dt = new tahvil().Search("select tahvil.id,date, tedad, daru_name from tahvil where (tahvil.id='" + dr["id"].ToString() + "' and  tahvil_date>='" + fromdate + "' and tahvil_date <='" + todate + "' and daru_name=N'قرص بوپرنورفین 0.4')");

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

                string[] dd = new string[31];
                for (int s = 0; s < 31; s++)
                    dd[s] = "";

                float sum_sb = 0;

                for (int i = 1; i <= int.Parse(todate.Substring(8, 2)); i++)
                    for (int j = 0; j < sb_dt.Rows.Count; j++)
                    {
                        string tempdate = fromdate.Substring(0, 8) + i.ToString("00");

                        if (sb_dt.Rows[j]["date"].ToString().Trim() == tempdate.Trim() && (tempdate.Trim() != todate.Trim()))
                        {
                            dd[i - 1] = sb_dt.Rows[j]["tedad"].ToString();
                            sum_sb += float.Parse(sb_dt.Rows[j]["tedad"].ToString());
                            break;
                        }

                        else if (sb_dt.Rows[j]["date"].ToString().Trim() == tempdate.Trim() && (tempdate.Trim() == todate.Trim()))
                        {
                            string temptedad = new tahvil().Search("select sum(tedad) as tedad from tahvil where (tahvil.id=N'" + sb_dt.Rows[j]["id"].ToString().Trim() + "' and tahvil_date>=N'" + fromdate + "' and tahvil_date <=N'" + todate + "' and date>=N'" + todate + "' and daru_name=N'" + sb_dt.Rows[j]["daru_name"].ToString().Trim() + "')").Rows[0]["tedad"].ToString();
                            dd[i - 1] = temptedad;
                            sum_sb += float.Parse(temptedad);
                            break;
                        }
                        else
                        {
                            dd[i - 1] = "";
                        }

                    }
                //if (sb_dt.Rows.Count > 0)
                //{
                //}
                #endregion

                #region B2_Filler
                DataTable m5_dt = new tahvil().Search("select tahvil.id,date, tedad, daru_name from tahvil where (tahvil.id='" + dr["id"].ToString() + "' and tahvil_date>='" + fromdate + "' and tahvil_date <='" + todate + "' and daru_name=N'قرص بوپرنورفین 2')");

                string[] ee = new string[31];
                for (int s = 0; s < 31; s++)
                    ee[s] = "";


                float sum_m5 = 0;

                for (int i = 1; i <= int.Parse(todate.Substring(8, 2)); i++)
                    for (int j = 0; j < m5_dt.Rows.Count; j++)
                    {
                        string tempdate = fromdate.Substring(0, 8) + i.ToString("00");

                        if (m5_dt.Rows[j]["date"].ToString().Trim() == tempdate.Trim() && (tempdate.Trim() != todate.Trim()))
                        {
                            ee[i - 1] = m5_dt.Rows[j]["tedad"].ToString();
                            sum_m5 += float.Parse(m5_dt.Rows[j]["tedad"].ToString());
                            break;
                        }

                        else if (m5_dt.Rows[j]["date"].ToString().Trim() == tempdate.Trim() && (tempdate.Trim() == todate.Trim()))
                        {
                            string temptedad = new tahvil().Search("select sum(tedad) as tedad from tahvil where (tahvil.id=N'" + m5_dt.Rows[j]["id"].ToString().Trim() + "' and tahvil_date>=N'" + fromdate + "' and tahvil_date <=N'" + todate + "' and date>=N'" + todate + "' and daru_name=N'" + m5_dt.Rows[j]["daru_name"].ToString().Trim() + "')").Rows[0]["tedad"].ToString();
                            ee[i - 1] = temptedad;
                            sum_m5 += float.Parse(temptedad);
                            break;
                        }
                        else
                        {
                            ee[i - 1] = "";
                        }
                    }
                //if (m5_dt.Rows.Count > 0)
                //{
                //}
                #endregion

                #region B8_Filler
                DataTable m20_dt = new tahvil().Search("select tahvil.id, date, tedad, daru_name from tahvil where (tahvil.id='" + dr["id"].ToString() + "' and tahvil_date>='" + fromdate + "' and tahvil_date <='" + todate + "' and daru_name=N'قرص بوپرنورفین 8')");

                string[] ff = new string[31];
                for (int s = 0; s < 31; s++)
                    ff[s] = "";

                float sum_m20 = 0;

                for (int i = 1; i <= int.Parse(todate.Substring(8, 2)); i++)
                    for (int j = 0; j < m20_dt.Rows.Count; j++)
                    {
                        string tempdate = fromdate.Substring(0, 8) + i.ToString("00");

                        if (m20_dt.Rows[j]["date"].ToString().Trim() == tempdate.Trim() && (tempdate.Trim() != todate.Trim()))
                        {
                            ff[i - 1] = m20_dt.Rows[j]["tedad"].ToString();
                            sum_m20 += float.Parse(m20_dt.Rows[j]["tedad"].ToString());
                            break;
                        }

                        else if (m20_dt.Rows[j]["date"].ToString().Trim() == tempdate.Trim() && (tempdate.Trim() == todate.Trim()))
                        {
                            string temptedad = new tahvil().Search("select sum(tedad) as tedad from tahvil where (tahvil.id=N'" + m20_dt.Rows[j]["id"].ToString().Trim() + "' and tahvil_date>=N'" + fromdate + "' and tahvil_date <=N'" + todate + "' and date>=N'" + todate.Trim() + "' and daru_name=N'" + m20_dt.Rows[j]["daru_name"].ToString().Trim() + "')").Rows[0]["tedad"].ToString();
                            ff[i - 1] = temptedad;
                            sum_m20 += float.Parse(temptedad);
                            break;
                        }
                        else
                        {
                            ff[i - 1] = "";
                        }

                    }
                //if (m20_dt.Rows.Count > 0)
                //{
                //}
                #endregion


                kol_boop_Query.Rows.Add(info_dt.Rows[0]["id"].ToString(), info_dt.Rows[0]["darman_date"].ToString(), info_dt.Rows[0]["name"].ToString(), info_dt.Rows[0]["father_name"].ToString(), info_dt.Rows[0]["b_date"].ToString(), info_dt.Rows[0]["city"].ToString(), info_dt.Rows[0]["id_no"].ToString(), info_dt.Rows[0]["masrafi_type"].ToString(),
                        dd[0], dd[1], dd[2], dd[3], dd[4], dd[5], dd[6], dd[7], dd[8], dd[9], dd[10], dd[11], dd[12], dd[13], dd[14], dd[15], dd[16], dd[17], dd[18], dd[19], dd[20], dd[21], dd[22], dd[23], dd[24], dd[25], dd[26], dd[27], dd[28], dd[29], dd[30], sum_sb,
                        ee[0], ee[1], ee[2], ee[3], ee[4], ee[5], ee[6], ee[7], ee[8], ee[9], ee[10], ee[11], ee[12], ee[13], ee[14], ee[15], ee[16], ee[17], ee[18], ee[19], ee[20], ee[21], ee[22], ee[23], ee[24], ee[25], ee[26], ee[27], ee[28], ee[29], ee[30], sum_m5,
                        ff[0], ff[1], ff[2], ff[3], ff[4], ff[5], ff[6], ff[7], ff[8], ff[9], ff[10], ff[11], ff[12], ff[13], ff[14], ff[15], ff[16], ff[17], ff[18], ff[19], ff[20], ff[21], ff[22], ff[23], ff[24], ff[25], ff[26], ff[27], ff[28], ff[29], ff[30], sum_m20);
            }

            fbtpv.filler_kol = kol_boop_Query;

            Darmangah sh = new Darmangah();
            fbtpv.markaz_name = sh.Select().Rows[0]["name"].ToString().Trim();
            fbtpv.shahr = sh.Select().Rows[0]["address"].ToString().Trim(); ;
            fbtpv.mah = txtmonth.Text;
            fbtpv.sal = txtyear.Value.ToString();

            // Yekkasseh Parameters
            fbtpv.mard = mard.ToString();
            fbtpv.zan = zan.ToString();


            string lastdate = "", last4 = "0", last2 = "0", last8 = "0";
            string mandeh4 = "0", mandeh2 = "0", mandeh8 = "0";
            string masrafi4 = "0", masrafi2 = "0", masrafi8 = "0";
            string lf4 = "0", lf2 = "0", lf8 = "0";
            DataTable lastdate_dt, last4_dt, last2_dt, last8_dt;

            Anbar an = new Anbar();
            factors fa = new factors();
            tahvil_koli tk = new tahvil_koli();
            DataTable temp_db = new DataTable();
            DataTable dttah = new DataTable();
            DataTable lastf_dt = new DataTable();

            an.daru_name = "قرص بوپرنورفین 0.4";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh4 = temp_db.Rows[0]["mandeh"].ToString();
            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص بوپرنورفین 0.4";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf4 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf4.Trim() == "")
                lf4 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil where (tahvil_date>=N'" + fromdate + "' and daru_name=N'قرص بوپرنورفین 0.4')");
            if (dttah.Rows.Count > 0)
                masrafi4 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi4 == null || masrafi4 == "")
                masrafi4 = "0";

            fbtpv.mandeh4 = (double.Parse(mandeh4) + double.Parse(masrafi4) - double.Parse(lf4)).ToString();



            an.daru_name = "قرص بوپرنورفین 2";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh2 = temp_db.Rows[0]["mandeh"].ToString();
            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص بوپرنورفین 2";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf2 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf2.Trim() == "")
                lf2 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil where (tahvil_date>=N'" + fromdate + "' and daru_name=N'قرص بوپرنورفین 2')");
            if (dttah.Rows.Count > 0)
                masrafi2 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi2 == null || masrafi2 == "")
                masrafi2 = "0";

            fbtpv.mandeh2 = (double.Parse(mandeh2) + double.Parse(masrafi2) - double.Parse(lf2)).ToString();




            an.daru_name = "قرص بوپرنورفین 8";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh8 = temp_db.Rows[0]["mandeh"].ToString();
            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص بوپرنورفین 8";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf8 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf8.Trim() == "")
                lf8 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil where (tahvil_date>=N'" + fromdate + "' and daru_name=N'قرص بوپرنورفین 8')");
            if (dttah.Rows.Count > 0)
                masrafi8 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi8 == null || masrafi8 == "")
                masrafi8 = "0";

            fbtpv.mandeh8 = (double.Parse(mandeh8) + double.Parse(masrafi8) - double.Parse(lf8)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            lastdate_dt = fa.Search("select max(date) as last from factors where (date>=N'" + fromdate + "' and date<='" + todate + "')");
            if (lastdate_dt.Rows.Count > 0)
                lastdate = lastdate_dt.Rows[0]["last"].ToString();

            fbtpv.lastdate = lastdate;

            fa.fromdate = fromdate;
            fa.todate = todate;

            fa.daru_name = "قرص بوپرنورفین 0.4";
            last4_dt = fa.gettedad();
            if (last4_dt.Rows.Count > 0)
                last4 = last4_dt.Rows[0]["tedad"].ToString();

            if (last4.Trim() == "")
                last4 = "0";

            fbtpv.last4 = last4;

            fa.daru_name = "قرص بوپرنورفین 2";
            last2_dt = fa.gettedad();
            if (last2_dt.Rows.Count > 0)
                last2 = last2_dt.Rows[0]["tedad"].ToString();

            if (last2.Trim() == "")
                last2 = "0";

            fbtpv.last2 = last2;

            fa.daru_name = "قرص بوپرنورفین 8";
            last8_dt = fa.gettedad();
            if (last8_dt.Rows.Count > 0)
                last8 = last8_dt.Rows[0]["tedad"].ToString();

            if (last8.Trim() == "")
                last8 = "0";

            fbtpv.last8 = last8;

            fbtpv.Show();
            this.Close();
 
        }

        private void printbytahvil()
        {

            # region date generator by combobox
            string year, fromdate = "", todate = "";

            year = txtyear.Value.ToString() + @"/";

            if (txtmonth.SelectedIndex == 0)
            {
                fromdate = year + "01/01";
                todate = year + "01/31";
            }
            else if (txtmonth.SelectedIndex == 1)
            {
                fromdate = year + "02/01";
                todate = year + "02/31";
            }
            else if (txtmonth.SelectedIndex == 2)
            {
                fromdate = year + "03/01";
                todate = year + "03/31";
            }
            else if (txtmonth.SelectedIndex == 3)
            {
                fromdate = year + "04/01";
                todate = year + "04/31";
            }
            else if (txtmonth.SelectedIndex == 4)
            {
                fromdate = year + "05/01";
                todate = year + "05/31";
            }
            else if (txtmonth.SelectedIndex == 5)
            {
                fromdate = year + "06/01";
                todate = year + "06/31";
            }
            else if (txtmonth.SelectedIndex == 6)
            {
                fromdate = year + "07/01";
                todate = year + "07/30";
            }
            else if (txtmonth.SelectedIndex == 7)
            {
                fromdate = year + "08/01";
                todate = year + "08/30";
            }
            else if (txtmonth.SelectedIndex == 8)
            {
                fromdate = year + "09/01";
                todate = year + "09/30";
            }
            else if (txtmonth.SelectedIndex == 9)
            {
                fromdate = year + "10/01";
                todate = year + "10/30";
            }
            else if (txtmonth.SelectedIndex == 10)
            {
                fromdate = year + "11/01";
                todate = year + "11/30";
            }
            else if (txtmonth.SelectedIndex == 11)
            {
                fromdate = year + "12/01";

                System.Globalization.PersianCalendar ly = new System.Globalization.PersianCalendar();
                if (ly.IsLeapYear(int.Parse(txtyear.Value.ToString())))
                {
                    todate = year + "12/30";
                }
                else
                {
                    todate = year + "12/29";
                }

            }
            # endregion

            FrmBoopTahvilPrintViewer fbtpv = new FrmBoopTahvilPrintViewer();

            DataTable id_dt = new tahvil().Search("select distinct id from tahvil where (daru_name like N'%بوپر%' and tahvil_date>='" + fromdate + "' and tahvil_date <='" + todate + "')");

            DataTable kol_boop_Query = new MehrDataSet.kol_boopDataTable();

            kol_boop_Query.Clear();

            int mard = 0, zan = 0;

            foreach (DataRow dr in id_dt.Rows)
            {
                #region B.4_Filler

                DataTable info_dt = new tahvil().Search("select id,name,id_no, father_name, darman_date, masrafi_type, b_date, city, sex, payan_date from sicks where (id='" + dr["id"].ToString() + "')");
                DataTable sb_dt = new tahvil().Search("select tahvil_koli.id, from_date, tedad, daru_name from tahvil_koli where (tahvil_koli.id=N'" + dr["id"].ToString() + "' and from_date>=N'" + fromdate + "' and from_date <=N'" + todate + "' and daru_name=N'قرص بوپرنورفین 0.4')");

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

                string[] dd = new string[31];
                for (int s = 0; s < 31; s++)
                    dd[s] = "";

                float sum_sb = 0;

                for (int i = 1; i <= int.Parse(todate.Substring(8, 2)); i++)
                    for (int j = 0; j < sb_dt.Rows.Count; j++)
                    {
                        string tempdate = fromdate.Substring(0, 8) + i.ToString("00");

                        if (sb_dt.Rows[j]["from_date"].ToString().Trim() == tempdate.Trim())
                        {
                            dd[i - 1] = sb_dt.Rows[j]["tedad"].ToString();
                            sum_sb += float.Parse(sb_dt.Rows[j]["tedad"].ToString());
                            break;
                        }

                        else
                        {
                            dd[i - 1] = "";
                        }

                    }
                //if (sb_dt.Rows.Count > 0)
                //{
                //}
                #endregion

                #region B2_Filler
                DataTable m5_dt = new tahvil().Search("select tahvil_koli.id, from_date, tedad, daru_name from tahvil_koli where (tahvil_koli.id=N'" + dr["id"].ToString() + "' and from_date>=N'" + fromdate + "' and from_date <=N'" + todate + "' and daru_name=N'قرص بوپرنورفین 2')");

                string[] ee = new string[31];
                for (int s = 0; s < 31; s++)
                    ee[s] = "";


                float sum_m5 = 0;

                for (int i = 1; i <= int.Parse(todate.Substring(8, 2)); i++)
                    for (int j = 0; j < m5_dt.Rows.Count; j++)
                    {
                        string tempdate = fromdate.Substring(0, 8) + i.ToString("00");

                        if (m5_dt.Rows[j]["from_date"].ToString().Trim() == tempdate.Trim())
                        {
                            ee[i - 1] = m5_dt.Rows[j]["tedad"].ToString();
                            sum_m5 += float.Parse(m5_dt.Rows[j]["tedad"].ToString());
                            break;
                        }

                        else
                        {
                            ee[i - 1] = "";
                        }
                    }
                //if (m5_dt.Rows.Count > 0)
                //{
                //}
                #endregion

                #region B8_Filler
                DataTable m20_dt = new tahvil().Search("select tahvil_koli.id, from_date, tedad, daru_name from tahvil_koli where (tahvil_koli.id=N'" + dr["id"].ToString() + "' and from_date>=N'" + fromdate + "' and from_date <=N'" + todate + "' and daru_name=N'قرص بوپرنورفین 8')");

                string[] ff = new string[31];
                for (int s = 0; s < 31; s++)
                    ff[s] = "";

                float sum_m20 = 0;

                for (int i = 1; i <= int.Parse(todate.Substring(8, 2)); i++)
                    for (int j = 0; j < m20_dt.Rows.Count; j++)
                    {
                        string tempdate = fromdate.Substring(0, 8) + i.ToString("00");

                        if (m20_dt.Rows[j]["from_date"].ToString().Trim() == tempdate.Trim())
                        {
                            ff[i - 1] = m20_dt.Rows[j]["tedad"].ToString();
                            sum_m20 += float.Parse(m20_dt.Rows[j]["tedad"].ToString());
                            break;
                        }

                        else
                        {
                            ff[i - 1] = "";
                        }

                    }
                //if (m20_dt.Rows.Count > 0)
                //{
                //}
                #endregion


                kol_boop_Query.Rows.Add(info_dt.Rows[0]["id"].ToString(), info_dt.Rows[0]["darman_date"].ToString(), info_dt.Rows[0]["name"].ToString(), info_dt.Rows[0]["father_name"].ToString(), info_dt.Rows[0]["b_date"].ToString(), info_dt.Rows[0]["city"].ToString(), info_dt.Rows[0]["id_no"].ToString(), info_dt.Rows[0]["masrafi_type"].ToString(),
                        dd[0], dd[1], dd[2], dd[3], dd[4], dd[5], dd[6], dd[7], dd[8], dd[9], dd[10], dd[11], dd[12], dd[13], dd[14], dd[15], dd[16], dd[17], dd[18], dd[19], dd[20], dd[21], dd[22], dd[23], dd[24], dd[25], dd[26], dd[27], dd[28], dd[29], dd[30], sum_sb,
                        ee[0], ee[1], ee[2], ee[3], ee[4], ee[5], ee[6], ee[7], ee[8], ee[9], ee[10], ee[11], ee[12], ee[13], ee[14], ee[15], ee[16], ee[17], ee[18], ee[19], ee[20], ee[21], ee[22], ee[23], ee[24], ee[25], ee[26], ee[27], ee[28], ee[29], ee[30], sum_m5,
                        ff[0], ff[1], ff[2], ff[3], ff[4], ff[5], ff[6], ff[7], ff[8], ff[9], ff[10], ff[11], ff[12], ff[13], ff[14], ff[15], ff[16], ff[17], ff[18], ff[19], ff[20], ff[21], ff[22], ff[23], ff[24], ff[25], ff[26], ff[27], ff[28], ff[29], ff[30], sum_m20);
            }

            fbtpv.filler_kol = kol_boop_Query;

            Darmangah sh = new Darmangah();
            fbtpv.markaz_name = sh.Select().Rows[0]["name"].ToString().Trim();
            fbtpv.shahr = sh.Select().Rows[0]["address"].ToString().Trim(); ;
            fbtpv.mah = txtmonth.Text;
            fbtpv.sal = txtyear.Value.ToString();

            // Yekkasseh Parameters
            fbtpv.mard = mard.ToString();
            fbtpv.zan = zan.ToString();


            string lastdate = "", last4 = "0", last2 = "0", last8 = "0";
            string mandeh4 = "0", mandeh2 = "0", mandeh8 = "0";
            string masrafi4 = "0", masrafi2 = "0", masrafi8 = "0";
            string lf4 = "0", lf2 = "0", lf8 = "0";
            DataTable lastdate_dt, last4_dt, last2_dt, last8_dt;

            Anbar an = new Anbar();
            factors fa = new factors();
            tahvil_koli tk = new tahvil_koli();
            DataTable temp_db = new DataTable();
            DataTable dttah = new DataTable();
            DataTable lastf_dt = new DataTable();

            an.daru_name = "قرص بوپرنورفین 0.4";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh4 = temp_db.Rows[0]["mandeh"].ToString();
            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص بوپرنورفین 0.4";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf4 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf4.Trim() == "")
                lf4 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil where (tahvil_date>=N'" + fromdate + "' and daru_name=N'قرص بوپرنورفین 0.4')");
            if (dttah.Rows.Count > 0)
                masrafi4 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi4 == null || masrafi4 == "")
                masrafi4 = "0";

            fbtpv.mandeh4 = (double.Parse(mandeh4) + double.Parse(masrafi4) - double.Parse(lf4)).ToString();



            an.daru_name = "قرص بوپرنورفین 2";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh2 = temp_db.Rows[0]["mandeh"].ToString();
            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص بوپرنورفین 2";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf2 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf2.Trim() == "")
                lf2 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil where (tahvil_date>=N'" + fromdate + "' and daru_name=N'قرص بوپرنورفین 2')");
            if (dttah.Rows.Count > 0)
                masrafi2 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi2 == null || masrafi2 == "")
                masrafi2 = "0";

            fbtpv.mandeh2 = (double.Parse(mandeh2) + double.Parse(masrafi2) - double.Parse(lf2)).ToString();




            an.daru_name = "قرص بوپرنورفین 8";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh8 = temp_db.Rows[0]["mandeh"].ToString();
            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص بوپرنورفین 8";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf8 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf8.Trim() == "")
                lf8 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil where (tahvil_date>=N'" + fromdate + "' and daru_name=N'قرص بوپرنورفین 8')");
            if (dttah.Rows.Count > 0)
                masrafi8 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi8 == null || masrafi8 == "")
                masrafi8 = "0";

            fbtpv.mandeh8 = (double.Parse(mandeh8) + double.Parse(masrafi8) - double.Parse(lf8)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            lastdate_dt = fa.Search("select max(date) as last from factors where (date>=N'" + fromdate + "' and date<='" + todate + "')");
            if (lastdate_dt.Rows.Count > 0)
                lastdate = lastdate_dt.Rows[0]["last"].ToString();

            fbtpv.lastdate = lastdate;

            fa.fromdate = fromdate;
            fa.todate = todate;

            fa.daru_name = "قرص بوپرنورفین 0.4";
            last4_dt = fa.gettedad();
            if (last4_dt.Rows.Count > 0)
                last4 = last4_dt.Rows[0]["tedad"].ToString();

            if (last4.Trim() == "")
                last4 = "0";

            fbtpv.last4 = last4;

            fa.daru_name = "قرص بوپرنورفین 2";
            last2_dt = fa.gettedad();
            if (last2_dt.Rows.Count > 0)
                last2 = last2_dt.Rows[0]["tedad"].ToString();

            if (last2.Trim() == "")
                last2 = "0";

            fbtpv.last2 = last2;

            fa.daru_name = "قرص بوپرنورفین 8";
            last8_dt = fa.gettedad();
            if (last8_dt.Rows.Count > 0)
                last8 = last8_dt.Rows[0]["tedad"].ToString();

            if (last8.Trim() == "")
                last8 = "0";

            fbtpv.last8 = last8;

            fbtpv.Show();
            this.Close();
        }

        private void btnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}