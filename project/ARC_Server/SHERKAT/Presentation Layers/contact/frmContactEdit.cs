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
    public partial class frmContactEdit : Form
    {
        DataTable dt = new DataTable();
        public string cur_date;

        public frmContactEdit()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            // Updating the Data to the DataBase
            contact cont = new contact();
            cont.id = txtid.Text;
            cont.fullname = txtFullname.Text;
            cont.phone = txtPhone.Text;
            cont.address = txtAddress.Text;
            cont.Update();
            // End of Updating Data to the DataBase

            MessageBox.Show("عملیات ویرایش اطلاعات مخاطب با موفقیت انجام شد");
            this.Close();
        }

        private void editmembers_Load_1(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

        }


        public void idsearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            contact cu = new contact();
            cu.id = txtid.Text;
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
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(MaskedTextBox) )
                    {
                        c.DataBindings.Clear();
                        c.DataBindings.Add("Text", dt, c.Name.Substring(3));
                    }
                }
                // End of Clearing & Adding of Controls Binding

                grpinfo_box.Focus();
                txtFullname.Focus();
            }
            else
            {
                MessageBox.Show("شماره مخاطب در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtid.Text == "" || txtFullname.Text == "")
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

        private void txtid_Validating(object sender, CancelEventArgs e)
        {
            txtid.Text = string.Format("{0:0000}", Convert.ToDecimal(txtid.Text));
        }

    }
}