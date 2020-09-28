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
    public partial class frmPeyvast : Form
    {
        DataTable dt = new DataTable();

        public frmPeyvast()
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


        private void frmPeyvast_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            txtmonth.Focus();

        }


        private void btnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
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


            frmPeyvastPrintViewer ftpv = new frmPeyvastPrintViewer();

            DataTable mard_dt = new tahvil().Search("select count(id),sex from sicks where (id in (select distinct id from tahvil where (tahvil_date>=N'" + fromdate + "' and tahvil_date <=N'" + todate + "')) and len(payan_date)!=10) group by sex");


            darmangah sh = new darmangah();
            ftpv.markaz_name = sh.Select().Rows[0]["name"].ToString().Trim();
            ftpv.shahr = sh.Select().Rows[0]["address"].ToString().Trim(); ;
            ftpv.mah = txtmonth.Text;
            ftpv.sal = txtyear.Value.ToString();

            string darm5 = "0", darm20 = "0", darm40 = "0", darsp = "0", darb4 = "0", darb2 = "0", darb8 = "0", dars2 = "0", dars8 = "0";
            string mandehm5 = "0", mandehm20 = "0", mandehm40 = "0", mandehsp = "0", mandehb4 = "0", mandehb2 = "0", mandehb8 = "0", mandehs2 = "0", mandehs8 = "0";
            string m5 = "0", m20 = "0", m40 = "0", sp = "0", b4 = "0", b2 = "0", b8 = "0", s2 = "0", s8 = "0";
            string masrafim5 = "0", masrafim20 = "0", masrafim40 = "0", masrafisp = "0", masrafib4 = "0", masrafib2 = "0", masrafib8 = "0", masrafis2 = "0", masrafis8 = "0";
            string lastfactor = "", masrafi="";;
            
            DataTable lastm5_dt, lastm20_dt, lastm40_dt, lastsp_dt, lastb4_dt, lastb2_dt, lastb8_dt, lasts2_dt, lasts8_dt;


            anbar an = new anbar();
            factors fa = new factors();
            tahvil_koli tk = new tahvil_koli();
            DataTable temp_db = new DataTable();
            DataTable dttah = new DataTable();
            DataTable lastf_dt = new DataTable();


            fa.fromdate = fromdate;
            fa.todate = todate;

            string dname = "قرص متادون 5";

            an.daru_name = dname;
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehm5 = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'"+dname+"')");
            if (dttah.Rows.Count > 0)
                masrafim5 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafim5 == null || masrafim5 == "")
                masrafim5 = "0";


            fa.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            lastm5_dt = fa.gettedad();
            if (lastm5_dt.Rows.Count > 0)
                darm5 = lastm5_dt.Rows[0]["tedad"].ToString();

            if (darm5.Trim() == "")
                darm5 = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();
            
            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            m5=(double.Parse(mandehm5) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            dname = "قرص متادون 20";

            an.daru_name = dname;
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehm20 = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'"+dname+"')");
            if (dttah.Rows.Count > 0)
                masrafim20 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafim20 == null || masrafim20 == "")
                masrafim20 = "0";


            fa.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            lastm20_dt = fa.gettedad();
            if (lastm20_dt.Rows.Count > 0)
                darm20 = lastm20_dt.Rows[0]["tedad"].ToString();

            if (darm20.Trim() == "")
                darm20 = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();
            
            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            m20=(double.Parse(mandehm20) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            dname = "قرص متادون 40";

            an.daru_name = dname;
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehm40 = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafim40 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafim40 == null || masrafim40 == "")
                masrafim40 = "0";


            fa.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            lastm40_dt = fa.gettedad();
            if (lastm40_dt.Rows.Count > 0)
                darm40 = lastm40_dt.Rows[0]["tedad"].ToString();

            if (darm40.Trim() == "")
                darm40 = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            m40 = (double.Parse(mandehm40) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            dname = "شربت متادون";

            an.daru_name = dname;
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehsp = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafisp = dttah.Rows[0]["masrafi"].ToString();

            if (masrafisp == null || masrafisp == "")
                masrafisp = "0";


            fa.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            lastsp_dt = fa.gettedad();
            if (lastsp_dt.Rows.Count > 0)
                darsp = lastsp_dt.Rows[0]["tedad"].ToString();

            if (darsp.Trim() == "")
                darsp = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            sp = (double.Parse(mandehsp) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            dname = "قرص بوپرنورفین 0.4";

            an.daru_name = dname;
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehb4 = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafib4 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafib4 == null || masrafib4 == "")
                masrafib4 = "0";


            fa.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            lastb4_dt = fa.gettedad();
            if (lastb4_dt.Rows.Count > 0)
                darb4 = lastb4_dt.Rows[0]["tedad"].ToString();

            if (darb4.Trim() == "")
                darb4 = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            b4 = (double.Parse(mandehb4) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            dname = "قرص بوپرنورفین 2";

            an.daru_name = dname;
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehb2 = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafib2 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafib2 == null || masrafib2 == "")
                masrafib2 = "0";


            fa.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            lastb2_dt = fa.gettedad();
            if (lastb2_dt.Rows.Count > 0)
                darb2 = lastb2_dt.Rows[0]["tedad"].ToString();

            if (darb2.Trim() == "")
                darb2 = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            b2 = (double.Parse(mandehb2) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            dname = "قرص بوپرنورفین 8";

            an.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehb8 = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafib8 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafib8 == null || masrafib8 == "")
                masrafib8 = "0";


            fa.daru_name = dname;
            lastb8_dt = fa.gettedad();
            if (lastb8_dt.Rows.Count > 0)
                darb8 = lastb8_dt.Rows[0]["tedad"].ToString();

            if (darb8.Trim() == "")
                darb8 = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            b8 = (double.Parse(mandehb8) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            dname = "قرص سوباکسون 2";

            an.daru_name = dname;
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehs2 = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafis2 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafis2 == null || masrafis2 == "")
                masrafis2 = "0";


            fa.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            lasts2_dt = fa.gettedad();
            if (lasts2_dt.Rows.Count > 0)
                dars2 = lasts2_dt.Rows[0]["tedad"].ToString();

            if (dars2.Trim() == "")
                dars2 = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            s2 = (double.Parse(mandehs2) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            dname = "قرص سوباکسون 8";

            an.daru_name = dname;
            temp_db = an.Selectforedit();
            if (temp_db.Rows.Count > 0)
                mandehs8 = temp_db.Rows[0]["mandeh"].ToString();


            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafis8 = dttah.Rows[0]["masrafi"].ToString();

            if (masrafis8 == null || masrafis8 == "")
                masrafis8 = "0";


            fa.daru_name = dname;
            fa.fromdate = fromdate;
            fa.todate = todate; 
            lasts8_dt = fa.gettedad();
            if (lasts8_dt.Rows.Count > 0)
                dars8 = lasts8_dt.Rows[0]["tedad"].ToString();

            if (dars8.Trim() == "")
                dars8 = "0";


            fa.todate = fromdate;
            fa.daru_name = dname;
            lastf_dt = fa.gettedadAfter();
            if (lastf_dt.Rows.Count > 0)
                lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

            if (lastfactor.Trim() == "")
                lastfactor = "0";

            dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>=N'" + fromdate + "' and daru_name=N'" + dname + "')");
            if (dttah.Rows.Count > 0)
                masrafi = dttah.Rows[0]["masrafi"].ToString();

            if (masrafi == null || masrafi == "")
                masrafi = "0";

            s8 = (double.Parse(mandehs8) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable peydt = new DataTable();

            peydt.Columns.Add("darm5");
            peydt.Columns.Add("darm20");
            peydt.Columns.Add("darm40");
            peydt.Columns.Add("darsp");
            peydt.Columns.Add("darb4");
            peydt.Columns.Add("darb2");
            peydt.Columns.Add("darb8");
            peydt.Columns.Add("dars2");
            peydt.Columns.Add("dars8");

            peydt.Columns.Add("masm5");
            peydt.Columns.Add("masm20");
            peydt.Columns.Add("masm40");
            peydt.Columns.Add("massp");
            peydt.Columns.Add("masb4");
            peydt.Columns.Add("masb2");
            peydt.Columns.Add("masb8");
            peydt.Columns.Add("mass2");
            peydt.Columns.Add("mass8");

            peydt.Columns.Add("met5");
            peydt.Columns.Add("met20");
            peydt.Columns.Add("met40");
            peydt.Columns.Add("sp");
            peydt.Columns.Add("b4");
            peydt.Columns.Add("b2");
            peydt.Columns.Add("b8");
            peydt.Columns.Add("s2");
            peydt.Columns.Add("s8");

            peydt.Clear();
            peydt.Rows.Add(new object[] { darm5, darm20, darm40, darsp, darb4, darb2, darb8, dars2, dars8, masrafim5, masrafim20, masrafim40, masrafisp, masrafib4, masrafib2, masrafib8, masrafis2, masrafis8, m5, m20, m40, sp, b4, b2, b8, s2, s8 });


            //string mmtmard = "0", mmtzan = "0", bmtmard = "0", bmtzan = "0", smtmard = "0", smtzan = "0";

            tahvil_koli ta=new tahvil_koli();

            DataTable tatemp=new DataTable();
            
            tatemp = ta.Search("select count(distinct id) from tahvil_koli where ( tahvil_date>=N'"+fromdate+"' and tahvil_date<=N'"+todate+"' and id in (select id from sicks where (len(payan_date)!=10 and ravesh_tark=N'نگهدارنده با متادون (MMT)') and sex=N'مذکر'))");
            ftpv.mmtmard = tatemp.Rows[0][0].ToString();

            tatemp = ta.Search("select count(distinct id) from tahvil_koli where ( tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and id in (select id from sicks where (len(payan_date)!=10 and ravesh_tark=N'نگهدارنده با متادون (MMT)') and sex=N'مونث'))");
            ftpv.mmtzan= tatemp.Rows[0][0].ToString();


            tatemp = ta.Search("select count(distinct id) from tahvil_koli where ( tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and id in (select id from sicks where (len(payan_date)!=10 and ravesh_tark=N'سم زدایی با بوپرنورفین') and sex=N'مذکر'))");
            ftpv.bmtmard = tatemp.Rows[0][0].ToString();

            tatemp = ta.Search("select count(distinct id) from tahvil_koli where ( tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and id in (select id from sicks where (len(payan_date)!=10 and ravesh_tark=N'سم زدایی با بوپرنورفین') and sex=N'مونث'))");
            ftpv.bmtzan = tatemp.Rows[0][0].ToString();


            tatemp = ta.Search("select count(distinct id) from tahvil_koli where ( tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and id in (select id from sicks where (len(payan_date)!=10 and ravesh_tark=N'سم زدایی با سوباکسون') and sex=N'مذکر'))");
            ftpv.smtmard = tatemp.Rows[0][0].ToString();

            tatemp = ta.Search("select count(distinct id) from tahvil_koli where ( tahvil_date>=N'" + fromdate + "' and tahvil_date<=N'" + todate + "' and id in (select id from sicks where (len(payan_date)!=10 and ravesh_tark=N'سم زدایی با سوباکسون') and sex=N'مونث'))");
            ftpv.smtzan = tatemp.Rows[0][0].ToString();

            ftpv.filler_kol = peydt;

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ftpv.Show();
            this.Close();
        }


    }
}