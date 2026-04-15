using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Accounts acnt = new Accounts();
            DataTable dt = new DataTable();
            acnt.user_code = txtuser.Text.Trim();
            acnt.pass = txtpass.Text;
            dt = acnt.Select();

            if (dt.Rows.Count > 0)
            {
                Program.user_code = dt.Rows[0]["user_code"].ToString();
                Program.user_name = dt.Rows[0]["fname"].ToString() + " " + dt.Rows[0]["lname"].ToString();
                Program.user_semat = dt.Rows[0]["semat"].ToString();
                this.Close();
            }
            else
            {

                MessageBox.Show("کلمه عبور نادرست است! دوباره سعی کنید!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Focus();
                txtpass.SelectAll();
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
                btnok.Enabled = false;
            else
                btnok.Enabled = true;

        }


        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }

        }

        private void Enter_Action(object sender, EventArgs e)
        {

            ((TextBox)sender).BackColor = Color.Khaki;
            ((TextBox)sender).Focus();
            ((TextBox)sender).SelectAll();
        }


        private void Leave_Action(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

    }
}