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
    public partial class FrmTajvizSelectMet : Form
    {
        DataTable dt = new DataTable();

        public FrmTajvizSelectMet()
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


        private void frmTajvizSelectMet_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            txtmonth.Focus();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
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



            FrmMetTahvilPrintViewer ftpv = new FrmMetTahvilPrintViewer();

            DataTable id_dt = new tajviz().Search("select distinct id from tajviz where (daru_name like N'%متادون%' and tajviz_date>='" + fromdate + "' and tajviz_date <='" + todate + "')");
            //int mard = new tajviz().Search("select count(id) from tajviz where (daru_name like N'%متادون%' and date>='" + fromdate + "' and date <='" + todate + "')");

            DataTable sb_query = new MehrDataSet.sbDataTable();
            DataTable m5_query = new MehrDataSet.m5DataTable();
            DataTable m20_query = new MehrDataSet.m20DataTable();
            DataTable m40_query = new MehrDataSet.m40DataTable();
            DataTable kol_Query = new MehrDataSet.kolDataTable();

            sb_query.Clear();
            m5_query.Clear();
            m20_query.Clear();
            m40_query.Clear();
            kol_Query.Clear();

            int mard = 0, zan = 0;

            foreach (DataRow dr in id_dt.Rows)
            {
                #region SB_Filler

                DataTable info_dt = new tajviz().Search("select id,name,id_no, father_name, darman_date, masrafi_type, b_date, city, sex, payan_date from sicks where (id=N'" + dr["id"].ToString() + "')");
                DataTable sb_dt = new tajviz().Search("select tajviz.id,date, sum(tedad) as tedad, daru_name from tajviz where (tajviz.id=N'" + dr["id"].ToString() + "' and  tajviz_date>=N'" + fromdate + "' and tajviz_date<=N'" + todate + "' and daru_name=N'شربت متادون') group by id,date,daru_name");

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
                String sbtedadformonthdifferent = new tajviz().Search("select sum(tedad) as tedad from tajviz_koli where (tajviz_koli.id=N'" + dr["id"].ToString().Trim() + "' and tajviz_date>=N'" + fromdate + "' and tajviz_date <=N'" + todate + "' and substring(from_date,6,2)>substring(tajviz_date,6,2) and daru_name=N'شربت متادون')").Rows[0]["tedad"].ToString();
                try
                {
                    sum_sb += float.Parse(sbtedadformonthdifferent);
                }
                catch
                {
                }
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
                            string temptedad = new tajviz().Search("select sum(tedad) as tedad from tajviz where (tajviz.id=N'" + sb_dt.Rows[j]["id"].ToString().Trim() + "' and tajviz_date>=N'" + fromdate + "' and tajviz_date <=N'" + todate + "' and date>=N'" + todate + "' and daru_name=N'" + sb_dt.Rows[j]["daru_name"].ToString().Trim() + "')").Rows[0]["tedad"].ToString();
                            dd[i - 1] = temptedad;
                            sum_sb += float.Parse(temptedad);
                            break;
                        }
                        
                        else
                        {
                            dd[i - 1] = "";
                        }

                    }

                sb_query.Rows.Add(info_dt.Rows[0]["id"].ToString(), info_dt.Rows[0]["darman_date"].ToString(), info_dt.Rows[0]["name"].ToString(), info_dt.Rows[0]["father_name"].ToString(), info_dt.Rows[0]["b_date"].ToString(), info_dt.Rows[0]["city"].ToString(), info_dt.Rows[0]["id_no"].ToString(), info_dt.Rows[0]["masrafi_type"].ToString(), dd[0], dd[1], dd[2], dd[3], dd[4], dd[5], dd[6], dd[7], dd[8], dd[9], dd[10], dd[11], dd[12], dd[13], dd[14], dd[15], dd[16], dd[17], dd[18], dd[19], dd[20], dd[21], dd[22], dd[23], dd[24], dd[25], dd[26], dd[27], dd[28], dd[29], dd[30], sum_sb);

                #endregion

                #region M5_Filler
                DataTable m5_dt = new tajviz().Search("select tajviz.id,date, sum(tedad) as tedad, daru_name from tajviz where (tajviz.id='" + dr["id"].ToString() + "' and tajviz_date>='" + fromdate + "' and tajviz_date <='" + todate + "' and daru_name=N'قرص متادون 5') group by id,date,daru_name");

                string[] ee = new string[31];
                for (int s = 0; s < 31; s++)
                    ee[s] = "";


                float sum_m5 = 0;
                String m5tedadformonthdifferent = new tajviz().Search("select sum(tedad) as tedad from tajviz_koli where (tajviz_koli.id=N'" + dr["id"].ToString().Trim() + "' and tajviz_date>=N'" + fromdate + "' and tajviz_date <=N'" + todate + "' and substring(from_date,6,2)>substring(tajviz_date,6,2) and daru_name=N'قرص متادون 5')").Rows[0]["tedad"].ToString();
                try
                {
                    sum_m5 += float.Parse(m5tedadformonthdifferent);
                }
                catch
                {
                }
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
                            string temptedad = new tajviz().Search("select sum(tedad) as tedad from tajviz where (tajviz.id=N'" + m5_dt.Rows[j]["id"].ToString().Trim() + "' and tajviz_date>=N'" + fromdate + "' and tajviz_date <=N'" + todate + "' and date>=N'" + todate + "' and daru_name=N'" + m5_dt.Rows[j]["daru_name"].ToString().Trim() + "')").Rows[0]["tedad"].ToString();
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
                m5_query.Rows.Add(info_dt.Rows[0]["id"].ToString(), info_dt.Rows[0]["darman_date"].ToString(), info_dt.Rows[0]["name"].ToString(), info_dt.Rows[0]["father_name"].ToString(), info_dt.Rows[0]["b_date"].ToString(), info_dt.Rows[0]["city"].ToString(), info_dt.Rows[0]["id_no"].ToString(), info_dt.Rows[0]["masrafi_type"].ToString(), ee[0], ee[1], ee[2], ee[3], ee[4], ee[5], ee[6], ee[7], ee[8], ee[9], ee[10], ee[11], ee[12], ee[13], ee[14], ee[15], ee[16], ee[17], ee[18], ee[19], ee[20], ee[21], ee[22], ee[23], ee[24], ee[25], ee[26], ee[27], ee[28], ee[29], ee[30], sum_m5);

                //}
                #endregion

                #region M20_Filler
                DataTable m20_dt = new tajviz().Search("select tajviz.id, date, sum(tedad) as tedad, daru_name from tajviz where (tajviz.id='" + dr["id"].ToString() + "' and tajviz_date>='" + fromdate + "' and tajviz_date <='" + todate + "' and daru_name=N'قرص متادون 20') group by id,date,daru_name");

                string[] ff = new string[31];
                for (int s = 0; s < 31; s++)
                    ff[s] = "";

                float sum_m20 = 0;
                String m20tedadformonthdifferent = new tajviz().Search("select sum(tedad) as tedad from tajviz_koli where (tajviz_koli.id=N'" + dr["id"].ToString().Trim() + "' and tajviz_date>=N'" + fromdate + "' and tajviz_date <=N'" + todate + "' and substring(from_date,6,2)>substring(tajviz_date,6,2) and daru_name=N'قرص متادون 20')").Rows[0]["tedad"].ToString();
                try
                {
                    sum_m20 += float.Parse(m20tedadformonthdifferent);
                }
                catch
                {
                }

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
                            string temptedad = new tajviz().Search("select sum(tedad) as tedad from tajviz where (tajviz.id=N'" + m20_dt.Rows[j]["id"].ToString().Trim() + "' and tajviz_date>=N'" + fromdate + "' and tajviz_date <=N'" + todate + "' and date>=N'" + todate.Trim() + "' and daru_name=N'" + m20_dt.Rows[j]["daru_name"].ToString().Trim() + "')").Rows[0]["tedad"].ToString();
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
                m20_query.Rows.Add(info_dt.Rows[0]["id"].ToString(), info_dt.Rows[0]["darman_date"].ToString(), info_dt.Rows[0]["name"].ToString(), info_dt.Rows[0]["father_name"].ToString(), info_dt.Rows[0]["b_date"].ToString(), info_dt.Rows[0]["city"].ToString(), info_dt.Rows[0]["id_no"].ToString(), info_dt.Rows[0]["masrafi_type"].ToString(), ff[0], ff[1], ff[2], ff[3], ff[4], ff[5], ff[6], ff[7], ff[8], ff[9], ff[10], ff[11], ff[12], ff[13], ff[14], ff[15], ff[16], ff[17], ff[18], ff[19], ff[20], ff[21], ff[22], ff[23], ff[24], ff[25], ff[26], ff[27], ff[28], ff[29], ff[30], sum_m20);




                //}
                #endregion

                #region M40_Filler
                DataTable m40_dt = new tajviz().Search("select tajviz.id,date, sum(tedad) as tedad, daru_name from tajviz where (tajviz.id='" + dr["id"].ToString() + "' and tajviz_date>='" + fromdate + "' and tajviz_date <='" + todate + "' and daru_name=N'قرص متادون 40') group by id,date,daru_name");

                string[] gg = new string[31];

                for (int s = 0; s < 31; s++)
                    gg[s] = "";

                float sum_m40 = 0;
                String m40tedadformonthdifferent = new tajviz().Search("select sum(tedad) as tedad from tajviz_koli where (tajviz_koli.id=N'" + dr["id"].ToString().Trim() + "' and tajviz_date>=N'" + fromdate + "' and tajviz_date <=N'" + todate + "' and substring(from_date,6,2)>substring(tajviz_date,6,2) and daru_name=N'قرص متادون 40')").Rows[0]["tedad"].ToString();
                try
                {
                    sum_m40 += float.Parse(m40tedadformonthdifferent);
                }
                catch
                {
                }
                for (int i = 1; i <= int.Parse(todate.Substring(8, 2)); i++)
                    for (int j = 0; j < m40_dt.Rows.Count; j++)
                    {
                        string tempdate = fromdate.Substring(0, 8) + i.ToString("00");

                        if (m40_dt.Rows[j]["date"].ToString().Trim() == tempdate.Trim() && (tempdate.Trim() != todate.Trim()))
                        {
                            gg[i - 1] = m40_dt.Rows[j]["tedad"].ToString();
                            sum_m40 += float.Parse(m40_dt.Rows[j]["tedad"].ToString());
                            break;
                        }

                        else if (m40_dt.Rows[j]["date"].ToString().Trim() == tempdate.Trim() && (tempdate.Trim() == todate.Trim()))
                        {
                            string temptedad = new tajviz().Search("select sum(tedad) as tedad from tajviz where (tajviz.id=N'" + m40_dt.Rows[j]["id"].ToString().Trim() + "' and tajviz_date>=N'" + fromdate + "' and tajviz_date <=N'" + todate + "' and date>=N'" + todate.Trim() + "' and daru_name=N'" + m40_dt.Rows[j]["daru_name"].ToString().Trim() + "')").Rows[0]["tedad"].ToString();
                            gg[i - 1] = temptedad;
                            sum_m40 += float.Parse(temptedad);
                            break;
                        }

                        else
                        {
                            gg[i - 1] = "";
                        }
                    }
                //if (m40_dt.Rows.Count > 0)
                //{
                m40_query.Rows.Add(info_dt.Rows[0]["id"].ToString(), info_dt.Rows[0]["darman_date"].ToString(), info_dt.Rows[0]["name"].ToString(), info_dt.Rows[0]["father_name"].ToString(), info_dt.Rows[0]["b_date"].ToString(), info_dt.Rows[0]["city"].ToString(), info_dt.Rows[0]["id_no"].ToString(), info_dt.Rows[0]["masrafi_type"].ToString(), gg[0], gg[1], gg[2], gg[3], gg[4], gg[5], gg[6], gg[7], gg[8], gg[9], gg[10], gg[11], gg[12], gg[13], gg[14], gg[15], gg[16], gg[17], gg[18], gg[19], gg[20], gg[21], gg[22], gg[23], gg[24], gg[25], gg[26], gg[27], gg[28], gg[29], gg[30], sum_m40);
                //}
                #endregion

                //if (info_dt.Rows.Count > 0)
                kol_Query.Rows.Add(info_dt.Rows[0]["id"].ToString(), info_dt.Rows[0]["darman_date"].ToString(), info_dt.Rows[0]["name"].ToString(), info_dt.Rows[0]["father_name"].ToString(), info_dt.Rows[0]["b_date"].ToString(), info_dt.Rows[0]["city"].ToString(), info_dt.Rows[0]["id_no"].ToString(), info_dt.Rows[0]["masrafi_type"].ToString(),
                        dd[0], dd[1], dd[2], dd[3], dd[4], dd[5], dd[6], dd[7], dd[8], dd[9], dd[10], dd[11], dd[12], dd[13], dd[14], dd[15], dd[16], dd[17], dd[18], dd[19], dd[20], dd[21], dd[22], dd[23], dd[24], dd[25], dd[26], dd[27], dd[28], dd[29], dd[30], sum_sb,
                        ee[0], ee[1], ee[2], ee[3], ee[4], ee[5], ee[6], ee[7], ee[8], ee[9], ee[10], ee[11], ee[12], ee[13], ee[14], ee[15], ee[16], ee[17], ee[18], ee[19], ee[20], ee[21], ee[22], ee[23], ee[24], ee[25], ee[26], ee[27], ee[28], ee[29], ee[30], sum_m5,
                        ff[0], ff[1], ff[2], ff[3], ff[4], ff[5], ff[6], ff[7], ff[8], ff[9], ff[10], ff[11], ff[12], ff[13], ff[14], ff[15], ff[16], ff[17], ff[18], ff[19], ff[20], ff[21], ff[22], ff[23], ff[24], ff[25], ff[26], ff[27], ff[28], ff[29], ff[30], sum_m20,
                        gg[0], gg[1], gg[2], gg[3], gg[4], gg[5], gg[6], gg[7], gg[8], gg[9], gg[10], gg[11], gg[12], gg[13], gg[14], gg[15], gg[16], gg[17], gg[18], gg[19], gg[20], gg[21], gg[22], gg[23], gg[24], gg[25], gg[26], gg[27], gg[28], gg[29], gg[30], sum_m40);


            }

            ftpv.filler_kol = kol_Query;

            Darmangah sh = new Darmangah();
            ftpv.markaz_name = sh.Select().Rows[0]["name"].ToString().Trim();
            ftpv.shahr = sh.Select().Rows[0]["address"].ToString().Trim(); ;
            ftpv.mah = txtmonth.Text;
            ftpv.sal = txtyear.Value.ToString();

            // Yekkasseh Parameters
            ftpv.mard = mard.ToString();
            ftpv.zan = zan.ToString();



            string lastdate = "", last5 = "0", last20 = "0", last40 = "0", lastsp = "0";
            string mandeh5 = "0", mandeh20 = "0", mandeh40 = "0", mandehsp = "0";
            string par_mandeh5 = "0", par_mandeh20 = "0", par_mandeh40 = "0", par_mandehsp = "0";
            string masrafi5 = "0", masrafi20 = "0", masrafi40 = "0", masrafisp = "0";
            string lf5 = "0", lf20 = "0", lf40 = "0", lfsp = "0";
            DataTable lastdate_dt, last5_dt, last20_dt, last40_dt, lastsp_dt;

            tajviz_anbar an = new tajviz_anbar();
            parastar_anbar pan = new parastar_anbar();
            DataTable dtpan = new DataTable();
            tajviz_factors fa = new tajviz_factors();
            tajviz_koli tk = new tajviz_koli();
            DataTable temp_db = new DataTable();
            DataTable dttah = new DataTable();
            DataTable lastf_dt = new DataTable();

            an.daru_name = "قرص متادون 5";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh5 = temp_db.Rows[0]["mandeh"].ToString();

            pan.daru_name = "قرص متادون 5";
            dtpan = pan.Selectforedit();
            if (dtpan.Rows.Count > 0)
                par_mandeh5 = dtpan.Rows[0]["mandeh"].ToString();

            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص متادون 5";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf5 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf5.Trim() == "")
                lf5 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tajviz where (tajviz_date>=N'" + fromdate + "' and daru_name=N'قرص متادون 5')");
            if (dttah.Rows.Count > 0)
                masrafi5 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi5 == null || masrafi5 == "")
                masrafi5 = "0";

            ftpv.mandeh5 = (double.Parse(mandeh5) + double.Parse(par_mandeh5) + double.Parse(masrafi5) - double.Parse(lf5)).ToString();



            an.daru_name = "قرص متادون 20";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh20 = temp_db.Rows[0]["mandeh"].ToString();

            pan.daru_name = "قرص متادون 20";
            dtpan = pan.Selectforedit();
            if (dtpan.Rows.Count > 0)
                par_mandeh20 = dtpan.Rows[0]["mandeh"].ToString();

            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص متادون 20";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf20 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf20.Trim() == "")
                lf20 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tajviz where (tajviz_date>=N'" + fromdate + "' and daru_name=N'قرص متادون 20')");
            if (dttah.Rows.Count > 0)
                masrafi20 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi20 == null || masrafi20 == "")
                masrafi20 = "0";

            ftpv.mandeh20 = (double.Parse(mandeh20) + double.Parse(par_mandeh20) + double.Parse(masrafi20) - double.Parse(lf20)).ToString();




            an.daru_name = "قرص متادون 40";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandeh40 = temp_db.Rows[0]["mandeh"].ToString();

            pan.daru_name = "قرص متادون 40";
            dtpan = pan.Selectforedit();
            if (dtpan.Rows.Count > 0)
                par_mandeh40 = dtpan.Rows[0]["mandeh"].ToString();

            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "قرص متادون 40";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lf40 = lastf_dt.Rows[0]["tedad"].ToString();

            if (lf40.Trim() == "")
                lf40 = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tajviz where (tajviz_date>=N'" + fromdate + "' and daru_name=N'قرص متادون 40')");
            if (dttah.Rows.Count > 0)
                masrafi40 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi40 == null || masrafi40 == "")
                masrafi40 = "0";

            ftpv.mandeh40 = (double.Parse(mandeh40) + double.Parse(par_mandeh40) + double.Parse(masrafi40) - double.Parse(lf40)).ToString();


            an.daru_name = "شربت متادون";
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehsp = temp_db.Rows[0]["mandeh"].ToString();

            pan.daru_name = "شربت متادون";
            dtpan = pan.Selectforedit();
            if (dtpan.Rows.Count > 0)
                par_mandehsp = dtpan.Rows[0]["mandeh"].ToString();

            dttah.Clear();
            lastf_dt.Clear();
            fa.todate = fromdate;
            fa.daru_name = "شربت متادون";
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lfsp = lastf_dt.Rows[0]["tedad"].ToString();

            if (lfsp.Trim() == "")
                lfsp = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tajviz where (tajviz_date>=N'" + fromdate + "' and daru_name=N'شربت متادون')");
            if (dttah.Rows.Count > 0)
                masrafisp = dttah.Rows[0]["masrafi"].ToString();

            if (masrafisp == null || masrafisp == "")
                masrafisp = "0";

            ftpv.mandehsp = (double.Parse(mandehsp) + double.Parse(par_mandehsp) + double.Parse(masrafisp) - double.Parse(lfsp)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////


            lastdate_dt = fa.Search("select max(date) as last from tajviz_factors where (date>=N'" + fromdate + "' and date<='" + todate + "')");
            if (lastdate_dt.Rows.Count > 0)
                lastdate = lastdate_dt.Rows[0]["last"].ToString();

            ftpv.lastdate = lastdate;

            fa.fromdate = fromdate;
            fa.todate = todate;

            fa.daru_name = "قرص متادون 5";
            last5_dt = fa.gettedad();
            if (last5_dt.Rows.Count > 0)
                last5 = last5_dt.Rows[0]["tedad"].ToString();

            if (last5.Trim() == "")
                last5 = "0";
            
            ftpv.last5 = last5;

            fa.daru_name = "قرص متادون 20";
            last20_dt = fa.gettedad();
            if (last20_dt.Rows.Count > 0)
                last20 = last20_dt.Rows[0]["tedad"].ToString();

            if (last20.Trim() == "")
                last20 = "0";
            
            ftpv.last20 = last20;

            fa.daru_name = "قرص متادون 40";
            last40_dt = fa.gettedad();
            if (last40_dt.Rows.Count > 0)
                last40 = last40_dt.Rows[0]["tedad"].ToString();

            if (last40.Trim() == "")
                last40 = "0";
            
            ftpv.last40 = last40;

            fa.daru_name = "شربت متادون";
            lastsp_dt = fa.gettedad();
            if (lastsp_dt.Rows.Count > 0)
                lastsp = lastsp_dt.Rows[0]["tedad"].ToString();

            if (lastsp.Trim() == "")
                lastsp = "0";
            
            ftpv.lastsp = lastsp;

            ftpv.Show();
            this.Close();
        }

        private void btnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}