using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftwareLocker
{
    public partial class frmAuthurize : Form
    {
        public frmAuthurize()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string auth = txtAuth.Text, strserial="";

            int[] fibo = new int[] { 3, 5, 8, 13, 21, 34, 55, 89 };

            for (int i = 0; i < auth.Length; i++)
            {
                int temp = ((int)auth[i]);

                strserial += (temp * fibo[i % 8]).ToString();

            }

            txtSerial.Text=strserial;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
