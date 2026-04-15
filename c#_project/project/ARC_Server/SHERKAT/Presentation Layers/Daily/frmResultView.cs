using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmResultView : Form
    {
        public FrmResultView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmResultView_Load(object sender, EventArgs e)
        {
            
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);
            btnfilter.PerformClick();
        }

      
        public void btnfilter_Click(object sender, EventArgs e)
        {
            foreach (Control grp in this.Controls)
            {
                if (grp.GetType() == typeof(GroupBox))
                {
                    foreach (Control con in grp.Controls)
                    {
                        if (con.GetType() == typeof(TextBox))
                            con.Text = "0";
                    }
                }
            }

            try
            {
                string tahvilsp = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'شربت متادون' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tahvilm5 = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'قرص متادون 5' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tahvilm20 = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'قرص متادون 20' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tahvilm40 = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'قرص متادون 40' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tahvilb4 = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'قرص بوپرنورفین 0.4' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tahvilb2 = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'قرص بوپرنورفین 2' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tahvilb8 = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'قرص بوپرنورفین 8' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tahvils2 = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'قرص سوباکسون 2' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tahvils8 = "select sum(tedad) as tahviltedad from tahvil_koli  where(daru_name=N'قرص سوباکسون 8' and tahvil_date>=N'" + txtfromdate.Text.Trim() + "' and tahvil_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";

                tahvil_koli tk=new tahvil_koli();
                DataTable dttahsp = tk.Search(tahvilsp);
                DataTable dttahm5 = tk.Search(tahvilm5);
                DataTable dttahm20 = tk.Search(tahvilm20);
                DataTable dttahm40 = tk.Search(tahvilm40);
                DataTable dttahb4 = tk.Search(tahvilb4);
                DataTable dttahb2 = tk.Search(tahvilb2);
                DataTable dttahb8 = tk.Search(tahvilb8);
                DataTable dttahs2 = tk.Search(tahvils2);
                DataTable dttahs8 = tk.Search(tahvils8);

                if(dttahsp.Rows.Count>0)
                    txttahvilsp.Text = dttahsp.Rows[0]["tahviltedad"].ToString();
                if (dttahm5.Rows.Count > 0)
                txttahvilm5.Text = dttahm5.Rows[0]["tahviltedad"].ToString();;
                if (dttahm20.Rows.Count > 0) 
                    txttahvilm20.Text = dttahm20.Rows[0]["tahviltedad"].ToString();;
                if (dttahm40.Rows.Count > 0)
                    txttahvilm40.Text = dttahm40.Rows[0]["tahviltedad"].ToString();
                if (dttahb4.Rows.Count > 0)
                    txttahvilb4.Text = dttahb4.Rows[0]["tahviltedad"].ToString();
                if (dttahb2.Rows.Count > 0)
                    txttahvilb2.Text = dttahb2.Rows[0]["tahviltedad"].ToString();
                if (dttahb8.Rows.Count > 0)
                    txttahvilb8.Text = dttahb8.Rows[0]["tahviltedad"].ToString();
                if (dttahs2.Rows.Count > 0)
                    txttahvils2.Text = dttahs2.Rows[0]["tahviltedad"].ToString();
                if (dttahs8.Rows.Count > 0)
                    txttahvils8.Text = dttahs8.Rows[0]["tahviltedad"].ToString();


                string tajvizsp = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'شربت متادون' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tajvizm5 = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'قرص متادون 5' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tajvizm20 = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'قرص متادون 20' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tajvizm40 = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'قرص متادون 40' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tajvizb4 = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'قرص بوپرنورفین 0.4' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tajvizb2 = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'قرص بوپرنورفین 2' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tajvizb8 = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'قرص بوپرنورفین 8' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tajvizs2 = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'قرص سوباکسون 2' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";
                string tajvizs8 = "select sum(tedad) as tajviztedad from tajviz_koli  where(daru_name=N'قرص سوباکسون 8' and tajviz_date>=N'" + txtfromdate.Text.Trim() + "' and tajviz_date<=N'" + txttodate.Text.Trim() + "') group by daru_name";


                tajviz_koli tj = new tajviz_koli();
                DataTable dttajsp = tj.Search(tajvizsp);
                DataTable dttajm5 = tj.Search(tajvizm5);
                DataTable dttajm20 = tj.Search(tajvizm20);
                DataTable dttajm40 = tj.Search(tajvizm40);
                DataTable dttajb4 = tj.Search(tajvizb4);
                DataTable dttajb2 = tj.Search(tajvizb2);
                DataTable dttajb8 = tj.Search(tajvizb8);
                DataTable dttajs2 = tj.Search(tajvizs2);
                DataTable dttajs8 = tj.Search(tajvizs8);

                if (dttajsp.Rows.Count > 0)
                    txttajvizsp.Text = dttajsp.Rows[0]["tajviztedad"].ToString();
                if (dttajm5.Rows.Count > 0)
                    txttajvizm5.Text = dttajm5.Rows[0]["tajviztedad"].ToString(); ;
                if (dttajm20.Rows.Count > 0)
                    txttajvizm20.Text = dttajm20.Rows[0]["tajviztedad"].ToString(); ;
                if (dttajm40.Rows.Count > 0)
                    txttajvizm40.Text = dttajm40.Rows[0]["tajviztedad"].ToString();
                if (dttajb4.Rows.Count > 0)
                    txttajvizb4.Text = dttajb4.Rows[0]["tajviztedad"].ToString();
                if (dttajb2.Rows.Count > 0)
                    txttajvizb2.Text = dttajb2.Rows[0]["tajviztedad"].ToString();
                if (dttajb8.Rows.Count > 0)
                    txttajvizb8.Text = dttajb8.Rows[0]["tajviztedad"].ToString();
                if (dttajs2.Rows.Count > 0)
                    txttajvizs2.Text = dttajs2.Rows[0]["tajviztedad"].ToString();
                if (dttajs8.Rows.Count > 0)
                    txttajvizs8.Text = dttajs8.Rows[0]["tajviztedad"].ToString();

                txtresultsp.Text = (-float.Parse(txttajvizsp.Text) + float.Parse(txttahvilsp.Text)).ToString();
                txtresultm5.Text = (-float.Parse(txttajvizm5.Text) + float.Parse(txttahvilm5.Text)).ToString();
                txtresultm20.Text = (-float.Parse(txttajvizm20.Text) + float.Parse(txttahvilm20.Text)).ToString();
                txtresultm40.Text = (-float.Parse(txttajvizm40.Text) + float.Parse(txttahvilm40.Text)).ToString();
                txtresultb4.Text = (-float.Parse(txttajvizb4.Text) + float.Parse(txttahvilb4.Text)).ToString();
                txtresultb2.Text = (-float.Parse(txttajvizb2.Text) + float.Parse(txttahvilb2.Text)).ToString();
                txtresultb8.Text = (-float.Parse(txttajvizb8.Text) + float.Parse(txttahvilb8.Text)).ToString();
                txtresults2.Text = (-float.Parse(txttajvizs2.Text) + float.Parse(txttahvils2.Text)).ToString();
                txtresults8.Text = (-float.Parse(txttajvizs8.Text) + float.Parse(txttahvils8.Text)).ToString();


                jamtaj.Text = ((float.Parse(txttajvizm5.Text)) + (float.Parse(txttajvizm20.Text) * 4) + (float.Parse(txttajvizm40.Text) * 8)).ToString();
                jamtah.Text = ((float.Parse(txttahvilm5.Text)) + (float.Parse(txttahvilm20.Text) * 4) + (float.Parse(txttahvilm40.Text) * 8)).ToString();
                jamres.Text = (-float.Parse(jamtaj.Text) + float.Parse(jamtah.Text)).ToString();
                
                jamtajb.Text = ((float.Parse(txttajvizb4.Text)) + (float.Parse(txttajvizb2.Text) * 5) + (float.Parse(txttajvizb8.Text) * 20)).ToString();
                jamtahb.Text = ((float.Parse(txttahvilb4.Text)) + (float.Parse(txttahvilb2.Text) * 5) + (float.Parse(txttahvilb8.Text) * 20)).ToString();
                jamresb.Text = (-float.Parse(jamtajb.Text) + float.Parse(jamtahb.Text)).ToString();

                
                jamtajs.Text = ((float.Parse(txttajvizs2.Text)) + (float.Parse(txttajvizs8.Text) * 4)).ToString();
                jamtahs.Text = ((float.Parse(txttahvils2.Text)) + (float.Parse(txttahvils8.Text) * 4)).ToString();
                jamress.Text = (-float.Parse(jamtajs.Text) + float.Parse(jamtahs.Text)).ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
     
        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (!txtfromdate.MaskCompleted || !txttodate.MaskCompleted)
            {
                btnfilter.Enabled = false;
            }
            else
            {
                btnfilter.Enabled = true;
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

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {
                ((DateMaskedTextbox)sender).BackColor = Color.Yellow;
                ((DateMaskedTextbox)sender).Focus();
                ((DateMaskedTextbox)sender).SelectAll();
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

            else if (sender.GetType() == typeof(DateMaskedTextbox))
            {
                ((DateMaskedTextbox)sender).BackColor = Color.White;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
                e.Handled = true;
                
            }
        }

    }
}