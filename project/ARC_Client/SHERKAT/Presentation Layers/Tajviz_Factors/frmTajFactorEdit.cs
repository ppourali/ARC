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
    public partial class frmTajFactorEdit : Form
    {
        DataTable dt = new DataTable();

        public string cur_date, first_daru_name;
        public float first_tedad = 0;

        public frmTajFactorEdit()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
                DateTime dd = x.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                            int.Parse(txtdate.Text.Substring(5, 2)),
                                            int.Parse(txtdate.Text.Substring(8, 2)),
                                            0, 0, 0, 0, 0);

                // Updating the Data to the DataBase
                tajviz_factors fa = new tajviz_factors();
                fa.code = long.Parse(txtcode.Text);
                fa.factor_no = txtfactor_no.Text;
                fa.date = txtdate.Text;
                fa.daru_name = txtdaru_name.Text;
                fa.tedad = float.Parse(txttedad.Text);
                fa.masraf_price = long.Parse(txtmasraf_price.Text);
                fa.fee = long.Parse(txtfee.Text);
                fa.fee_kol = long.Parse(txtfee_kol.Text);
                fa.comments = txtcomments.Text.Trim();
                fa.Update();
                // End of Updating Data to the DataBase


                // DELETE the Data to the DataBase Anbar
                tajviz_anbar an = new tajviz_anbar();
                an.mandeh = -first_tedad;
                an.daru_name = first_daru_name;
                an.UpdateAfterFactor();
                // End of DELETE Data to the DataBase


                // Adding the Data to the DataBase Anbar
                an.mandeh = float.Parse(txttedad.Text);
                an.daru_name = txtdaru_name.Text;
                an.UpdateAfterFactor();
                // End of Adding Data to the DataBase

                
                this.Close();
            }
         
            catch
            {
                MessageBox.Show("لطفا اطلاعات وارد شده را بررسی نمایید");
            }

        }

        private void editmembers_Load_1(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

        }


        public void idsearch_Click()
        {
            tajviz_anbar an = new tajviz_anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select distinct daru_name from tajviz_anbar");
            txtdaru_name.DataSource = combosource;
            txtdaru_name.DisplayMember = "daru_name";
            txtdaru_name.ValueMember = "daru_name";
            //DataTable dt = new DataTable();
            tajviz_factors fac = new tajviz_factors();
            fac.code = long.Parse(txtcode.Text);
            dt = fac.Selectforedit();

            if (dt.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                txtfactor_no.Enabled = false;
                grpinfo_box.Enabled = true;

                // Clear any previous bindings & Add new bindings to the DataView object...
                foreach (Control c in grpinfo_box.Controls)
                {
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(CurrencyTextBox))
                    {
                        if (c != txtcode)
                        {
                            c.DataBindings.Clear();
                            c.DataBindings.Add("Text", dt, c.Name.Substring(3));
                        }
                    }
                }
                // End of Clearing & Adding of Controls Binding
                txtdaru_name.Text = first_daru_name;
                txtdate.Focus();
            }
            else
            {
                MessageBox.Show("شماره مشخصه در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (sender == txtmasraf_price)
            {
                if (txtmasraf_price.Text == "")
                {
                    txtmasraf_price.Text = "0";
                    txtmasraf_price.Focus();
                    txtmasraf_price.SelectAll();
                }
            }
            
            if (sender == txtfee || sender == txttedad)
            {
                if (txttedad.Text == "")
                {
                    txttedad.Text = "0";
                    txttedad.Focus();
                    txttedad.SelectAll();
                }

                if (txtfee.Text == "")
                {
                    txtfee.Text = "0";
                    txtfee.Focus();
                    txtfee.SelectAll();
                }

                txtfee_kol.Text = (float.Parse(txttedad.Text) * long.Parse(txtfee.Text)).ToString("N0");
            }

            
            if (txtcode.Text=="" || txtfactor_no.Text == "" || txtdaru_name.Text.Trim() == "" || txttedad.Text.Trim() == "" || txtfee.Text.Trim() == "" || txtfee_kol.Text.Trim() == "" || !txtdate.MaskCompleted)
                btnUpdate.Enabled = false;
            else 
            {
                btnUpdate.Enabled = true;
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

            if (sender.GetType() == typeof(CurrencyTextBox))
            {
                ((CurrencyTextBox)sender).BackColor = Color.Yellow;
                ((CurrencyTextBox)sender).Focus();
                ((CurrencyTextBox)sender).SelectAll();
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
            if (sender.GetType() == typeof(CurrencyTextBox))
            {
                ((CurrencyTextBox)sender).BackColor = Color.White;
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
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


        private void frmTajFactorEdit_Load(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}