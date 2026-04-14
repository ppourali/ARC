using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmAmarView : Form
    {
        public frmAmarView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmAmarView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);


            if (Program.user_code.Trim() == "5")
            {
                groupBox2.Visible = false;
                this.Height = 380;
            }

            txttodate.Text = txtdate.Text;
            btnfilter.PerformClick();
        }


        public void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                tajviz_anbar atn = new tajviz_anbar();
                DataTable dtt = new DataTable();
                dtt = atn.Search("SELECT daru_name, mandeh from tajviz_anbar");

                grdtajvizAnbar.DataSource = dtt;
                grdtajvizAnbar.AutoGenerateColumns = false;

                ///////////////////////////////////////////////////////////////////////
                Anbar an = new Anbar();
                DataTable dt = new DataTable();
                dt = an.Search("SELECT daru_name, mandeh from anbar");

                grdAnbar.DataSource = dt;
                grdAnbar.AutoGenerateColumns = false;

                ///////////////////////////////////////////////////////////////////////
                tahvil_koli tk = new tahvil_koli();
                DataTable dttah = new DataTable();
                dttah = tk.Search("select daru_name,sum(tedad) as mandeh from tahvil_koli where (tahvil_date>=N'" + txtdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name");
                grdTahvil.DataSource = dttah;
                grdTahvil.AutoGenerateColumns = false;


                tajviz_koli tj = new tajviz_koli();
                DataTable dttaj = new DataTable();
                dttaj = tj.Search("select daru_name,sum(tedad) as mandeh from tajviz_koli where (tajviz_date>=N'" + txtdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name");
                grdTajviz.DataSource = dttaj;
                grdTajviz.AutoGenerateColumns = false;



                auto_calc();
                auto_calc_bimaran();


                label9.Text = "آخرین تعداد موجود در دفتر در تاریخ " + txttodate.Text;
                label10.Text = "آخرین تعداد موجود  مصرفی در تاریخ " + txttodate.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
            }
        }

        private void auto_calc()
        {
            string[] names = { "قرص متادون 5", "قرص متادون 20", "قرص متادون 40", "شربت متادون", "قرص بوپرنورفین 0.4", "قرص بوپرنورفین 2", "قرص بوپرنورفین 8", "قرص سوباکسون 2", "قرص سوباکسون 8" };

            Anbar an = new Anbar();
            DataTable temp_db = new DataTable();
            DataTable lastf_dt=new DataTable();

            factors fa = new factors();

            tahvil_koli tk = new tahvil_koli();
            DataTable dttah = new DataTable();

            DataTable feli = new DataTable();
            feli.Columns.Add("daru_name");
            feli.Columns.Add("mandeh");

            for (int i = 0; i < names.Length; i++)
            {
                string lastfactor = "0";
                string mandeh = "0"; ;
                string masrafi = "0";
                temp_db.Clear();
                lastf_dt.Clear();
                dttah.Clear();
                an.daru_name = names[i];

                temp_db = an.Selectforedit();
                if (temp_db.Rows.Count > 0)
                    mandeh = temp_db.Rows[0]["mandeh"].ToString();
                                

                fa.todate = txttodate.Text;
                fa.daru_name = names[i];
                lastf_dt = fa.gettedadAfterforAmar();
                if (lastf_dt.Rows.Count > 0)
                    lastfactor = lastf_dt.Rows[0]["tedad"].ToString();

                if (lastfactor.Trim() == "")
                    lastfactor = "0";
                
                dttah = tk.Search("select sum(tedad) as masrafi from tahvil_koli where (tahvil_date>N'" + txttodate.Text.Trim() + "' and daru_name=N'"+names[i]+"')");
                if (dttah.Rows.Count > 0)
                    masrafi = dttah.Rows[0]["masrafi"].ToString();

                if (masrafi == null || masrafi == "")
                    masrafi = "0";
                //DataRow dr=new DataRow();
                //dr[0] = names[i];
                //dr[1] = long.Parse(mandeh) + long.Parse(masrafi) - long.Parse(lastfactor);

                feli.Rows.Add(new object[] { names[i], (double.Parse(mandeh) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString() });
            }

            grdMojoodighabl.DataSource = feli;
        }

        private void auto_calc_bimaran()
        {
            string[] names = { "قرص متادون 5", "قرص متادون 20", "قرص متادون 40", "شربت متادون", "قرص بوپرنورفین 0.4", "قرص بوپرنورفین 2", "قرص بوپرنورفین 8", "قرص سوباکسون 2", "قرص سوباکسون 8" };

            tajviz_anbar an = new tajviz_anbar();
            DataTable temp_db = new DataTable();
            DataTable lastf_dt = new DataTable();

            tajviz_factors fa = new tajviz_factors();

            tajviz_koli tj = new tajviz_koli();
            DataTable dttaj = new DataTable();

            DataTable feli = new DataTable();
            feli.Columns.Add("daru_name");
            feli.Columns.Add("mandeh");

            for (int i = 0; i < names.Length; i++)
            {
                string lastfactor = "0";
                string mandeh = "0"; ;
                string masrafi = "0";
                temp_db.Clear();
                lastf_dt.Clear();
                dttaj.Clear();
                an.daru_name = names[i];

                temp_db = an.Selectforedit();
                if (temp_db.Rows.Count > 0)
                    mandeh = temp_db.Rows[0]["mandeh"].ToString();


                fa.todate = txttodate.Text;
                fa.daru_name = names[i];
                lastf_dt = fa.gettedadAfterforAmar();
                if (lastf_dt.Rows.Count > 0)
                    lastfactor = lastf_dt.Rows[0]["tedad"].ToString();


                if (lastfactor.Trim() == "")
                    lastfactor = "0";

                dttaj = tj.Search("select sum(tedad) as masrafi from tajviz_koli where (tajviz_date>N'" + txttodate.Text.Trim() + "' and daru_name=N'" + names[i] + "')");
                if (dttaj.Rows.Count > 0)
                    masrafi = dttaj.Rows[0]["masrafi"].ToString();

                if (masrafi == null || masrafi == "")
                    masrafi = "0";

                feli.Rows.Add(new object[] { names[i], (double.Parse(mandeh) + double.Parse(masrafi) - double.Parse(lastfactor)).ToString() });
            }

            grdMojoodiBimaran.DataSource = feli;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
     
        private void TextChanged_Action(object sender, EventArgs e)
        {
           
            if (!txtdate.MaskCompleted || !txttodate.MaskCompleted)
            {
                btnfilter.Enabled = false;
            }
            else
            {
                btnfilter.Enabled = true;
            }
        }                    



        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.Handled = true;
                e.SuppressKeyPress = true;
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

            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.Yellow;
                ((ComboBox)sender).Focus();
                ((ComboBox)sender).SelectAll();
            }

            else if (sender.GetType() == typeof(MaskedTextBox))
            {
                ((MaskedTextBox)sender).BackColor = Color.Yellow;
                ((MaskedTextBox)sender).Focus();
                ((MaskedTextBox)sender).SelectAll();
            }

        }


        private void Leave_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.White;
            }

            else if (sender.GetType() == typeof(MaskedTextBox))
            {
                ((MaskedTextBox)sender).BackColor = Color.White;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtdate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}