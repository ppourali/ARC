using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Daru.Presentation_Layers
{
    public partial class frmDaruEdit : Form
    {
        DataTable dt = new DataTable();
        public string cur_date;

        public frmDaruEdit()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
                DateTime dd = x.ToDateTime(int.Parse(txtdaru_date.Text.Substring(0, 4)),
                                            int.Parse(txtdaru_date.Text.Substring(5, 2)),
                                            int.Parse(txtdaru_date.Text.Substring(8, 2)),
                                            0, 0, 0, 0, 0);

                // Updating the Data to the DataBase
                daru dar = new daru();
                dar.id = int.Parse(txtid.Text);
                dar.daru_date = txtdaru_date.Text;
                dar.daru_name = txtdaru_name.Text;
                dar.tedad = txttedad.Text;
                dar.daryaft_az = txtdaryaft_az.Text;
                dar.tahvil_be = txttahvil_be.Text;
                dar.fee = long.Parse(txtfee.Text);
                dar.fee_kol = long.Parse(txtfee_kol.Text);
                dar.Update();
                // End of Updating Data to the DataBase

                this.Close();
            }
            catch
            {
                MessageBox.Show("لطفا تاریخ را بررسی نمایید");
            }

        }

        private void editmembers_Load_1(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

        }


        public void idsearch_Click(object sender, EventArgs e)
        {
            anbar an = new anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select * from anbar");
            txtdaru_name.DataSource = combosource;
            txtdaru_name.DisplayMember = "daru_name";
            txtdaru_name.ValueMember = "daru_name";
            lblvahed.DataBindings.Clear();
            lblvahed.DataBindings.Add("Text", combosource, "vahed");
            
            contact cn = new contact();
            DataTable dt1 = cn.Search("select fullname from contact");
            DataTable dt2 = cn.Search("select fullname from contact");
            txtdaryaft_az.DataSource = dt1;
            txttahvil_be.DataSource = dt2;
            txtdaryaft_az.DisplayMember = dt1.Columns["fullname"].ToString();
            txttahvil_be.DisplayMember = dt2.Columns["fullname"].ToString();
            
            //DataTable dt = new DataTable();
            daru cu = new daru();
            cu.id = int.Parse(txtid.Text);
            dt = cu.Selectforedit();
            if (dt.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                txtid.Enabled = false;
                idsearch.Enabled = false;
                grpinfo_box.Enabled = true;

                // Clear any previous bindings & Add new bindings to the DataView object...
                foreach (Control c in grpinfo_box.Controls)
                {
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(MaskedTextBox) || c.GetType() == typeof(CurrencyTextBox))
                    {
                        c.DataBindings.Clear();
                        c.DataBindings.Add("Text", dt, c.Name.Substring(3));
                    }
                }
                // End of Clearing & Adding of Controls Binding

                txtdaru_date.Focus();
            }
            else
            {
                MessageBox.Show("شماره پرونده در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void KeyDownforSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                idsearch_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (sender == txttedad)
            {
                if (txttedad.Text == "")
                {
                    txttedad.Text = "0";
                    txttedad.Focus();
                    txttedad.SelectAll();
                }
                txtfee_kol.Text = (long.Parse(txttedad.Text) * long.Parse(txtfee.Text)).ToString();
            }
            else if (sender == txtfee)
            {
                if (txtfee.Text == "")
                {
                    txtfee.Text = "0";
                    txtfee.Focus();
                    txtfee.SelectAll();
                }
                txtfee_kol.Text = (long.Parse(txttedad.Text) * long.Parse(txtfee.Text)).ToString();
            }

            if (txtid.Text == "")
            {
                btnUpdate.Enabled = false;
            }
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

        private void frmDaruEdit_Load(object sender, EventArgs e)
        {

        }

    }
}