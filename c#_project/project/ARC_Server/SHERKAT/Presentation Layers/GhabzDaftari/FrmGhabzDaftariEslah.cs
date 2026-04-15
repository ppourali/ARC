using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmGhabzDaftariEslah : Form
    {
        public FrmGhabzDaftariEslah()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmGhabzDaftariEslah_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            txtghabz_id.Focus();
        }



        private void TextChanged_Action(object sender, EventArgs e)
        {
            
            if (txtid.Text != "")
                btnsabegheh.Enabled = true;
            else
                btnsabegheh.Enabled = false;

            if (sender == txtmablagh)
            {
                if (txtmablagh.Text == "")
                {
                    txtmablagh.Text = "0";
                }
                else
                {
                    //txtpaid.Text = txtmablagh.Text;
                    txtmandeh.Text = Math.Abs((long.Parse(txtmablagh.Text) - long.Parse(txtpaid.Text))).ToString("N0");
                }
            }

            if (sender == txtpaid)
            {
                if (txtpaid.Text == "")
                {
                    txtpaid.Text = "0";
                }
                else
                    txtmandeh.Text = Math.Abs((long.Parse(txtmablagh.Text) - long.Parse(txtpaid.Text))).ToString("N0");
            }


//            txtmandeh.Text = (long.Parse(txtmablagh.Text) - long.Parse(txtpaid.Text)).ToString("N0");

           
            if (sender == txtmablaghnew)
            {
                if (txtmablaghnew.Text == "")
                {
                    txtmablaghnew.Text = "0";
                }
                else
                {
                 //   txtpaidnew.Text = txtmablaghnew.Text;
                    txtmandehnew.Text = Math.Abs((long.Parse(txtmablaghnew.Text) - long.Parse(txtpaidnew.Text))).ToString("N0");
                }
            }

            if (sender == txtpaidnew)
            {
                if (txtpaidnew.Text == "")
                {
                    txtpaidnew.Text = "0";
                }
                else
                    txtmandehnew.Text = Math.Abs((long.Parse(txtmablaghnew.Text) - long.Parse(txtpaidnew.Text))).ToString("N0");
            }


            if (txtghabz_id.Text == "" || txtid.Text == "" || txtmablagh.Text=="" || txtsharh.Text=="" || !txtdate.MaskCompleted || txtname.Text=="" || txtpaid.Text=="" )
            {
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
            }


        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtid_Validated(object sender, EventArgs e)
        {

        }


        private void KeyDownforSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtghabz_id.Text = string.Format("{0:000000}", Convert.ToDecimal(txtghabz_id.Text));
                idsearch_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();

        }


        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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

            else if (sender.GetType() == typeof(CurrencyTextBox))
            {
                ((CurrencyTextBox)sender).BackColor = Color.Yellow;
                ((CurrencyTextBox)sender).Focus();
                ((CurrencyTextBox)sender).SelectAll();
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
            else if (sender.GetType() == typeof(CurrencyTextBox))
            {
                ((CurrencyTextBox)sender).BackColor = Color.White;
            }
        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void Validating_Action(object sender, CancelEventArgs e)
        {

        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            FrmSickDaftariHisView fsh = new FrmSickDaftariHisView();
            fsh.txtid.Text = this.txtid.Text;
            fsh.sabegheh = true;
            fsh.Show();
        }

      
        private void txtmandeh_TextChanged(object sender, EventArgs e)
        {
            if (long.Parse(txtmablagh.Text) < long.Parse(txtpaid.Text))
            {
                label5.Text = "تومان بستانکار";
            }
            else
            {
                label5.Text = "تومان بدهکار";
            }

            if (long.Parse(txtmablaghnew.Text) < long.Parse(txtpaidnew.Text))
            {
                label6.Text = "تومان بستانکار";
            }
            else
            {
                label6.Text = "تومان بدهکار";
            }
        }

        public void idsearch_Click(object sender, EventArgs e)
        {
            ghabz_daftari gh = new ghabz_daftari();
            gh.ghabz_id = txtghabz_id.Text;
            DataTable dt = gh.Selectforedit();
            if (dt.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                txtghabz_id.Enabled = false;
                idsearch.Enabled = false;
                groupBox1.Enabled = true;
                // Clear any previous bindings & Add new bindings to the DataView object...
                foreach (Control c in groupBox1.Controls)
                {
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(IDTextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(CurrencyTextBox))
                    {
                        if (c != txtmablaghnew && c != txtpaidnew && c != txtmandehnew && c!=txtmandeh && c.Enabled==true)
                        {
                            c.Text = dt.Rows[0][c.Name.Substring(3)].ToString();
                        }
                    }
                }
                // End of Clearing & Adding of Controls Binding
                
                txtdate.Focus();
            }
            else
            {
                MessageBox.Show("شماره قبض در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtmablaghnew.Text = txtmablagh.Text;
            txtpaidnew.Text = txtpaid.Text;

        }

        private void txtghabz_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ghabz_daftari gh = new ghabz_daftari();
            gh.ghabz_id = txtghabz_id.Text;
            gh.id = txtid.Text;
            gh.name = txtname.Text;
            gh.mablagh = long.Parse(txtmablaghnew.Text);
            gh.paid = long.Parse(txtpaidnew.Text);
            gh.sharh = txtsharh.Text;
            gh.date = txtdate.Text;
            gh.Update();

            sick_history_daftari si = new sick_history_daftari();
            si.ghabz_id = txtghabz_id.Text;
            si.date = txtdate.Text;
            si.sick_id = txtid.Text;
            si.sharh = txtsharh.Text;
            si.bedehkari = long.Parse(txtmablaghnew.Text);
            si.bestankari = 0;
            si.UpdateAfterEslahGhabz();

            si.ghabz_id = txtghabz_id.Text;
            si.sick_id = txtid.Text;
            si.sharh = "پرداخت وجه از بابت " + txtsharh.Text;
            si.bedehkari = 0;
            si.bestankari = long.Parse(txtpaidnew.Text);
            si.UpdateAfterEslahGhabz();

            MessageBox.Show("قبض با موفقیت ویرایش گردید");
            this.Close();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
            {
                btnsabegheh.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}