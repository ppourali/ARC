using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmEditPassInput : Form
    {
        public frmEditPassInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Darmangah da = new Darmangah();
            DataTable dt = da.Select();

            string pass = dt.Rows[0]["Gen_Pass"].ToString();

            if (txtpass.Text.Equals(pass))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("رمز عبور صحیح نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.SelectAll();
                txtpass.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void txtidno_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;

        }

        private void frmEditPassInput_Load(object sender, EventArgs e)
        {
            txtpass.Text = "";
        }
    }
}