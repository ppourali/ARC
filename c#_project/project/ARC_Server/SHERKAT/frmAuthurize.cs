using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mehr
{
    public partial class frmAuthurize : Form
    {
        public frmAuthurize(string str)
        {

            InitializeComponent();
            txtAuth.Text = str;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string auth = txtAuth.Text, strserial = "";

            int[] fibo = new int[] { 3, 5, 8, 13, 21, 34, 55, 89 };

            for (int i = 0; i < auth.Length; i++)
            {
                int temp = ((int)auth[i]);

                strserial += (temp * fibo[i % 8]).ToString();

            }

            if (txtSerial.Text.Equals(strserial))
            {
                Properties.Settings.Default.SerialNo = txtAuth.Text;
                Properties.Settings.Default.Save();

                MessageBox.Show("سریال وارد شده صحیح و نرم افزار آماده ی استفاده می باشد. لطفا نرم افزار را مجددا راه اندازی کنید.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (MessageBox.Show("سریال نرم افزار صحیح نمی باشد", "خطا", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }

                txtSerial.Focus();
                txtSerial.SelectAll();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}