using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmDaruReturnTedad : Form
    {
        public string maxcanreturn = "", daru_name = "";
        public string cname, cid, type;

        public string cur_date = "";

        public frmDaruReturnTedad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(maxcanreturn) >= float.Parse(txttedad.Text))
                {
                    tajviz_anbar_history dar = new tajviz_anbar_history();
                    dar.id = long.Parse(new tajviz_anbar_history().Selectmaxid().ToString());
                    dar.date = txtdate.Text;
                    dar.contactname = cname;
                    dar.contactid = cid;
                    dar.daru_name = daru_name;
                    dar.tedad = float.Parse(txttedad.Text);
                    dar.comments = "برگشت دارو از بانک دارویی " + type; ;
                    dar.Add();

                    // Updating the Data to the DataBase Anbar
                    tajviz_anbar an = new tajviz_anbar();
                    an.mandeh = float.Parse(txttedad.Text);
                    an.daru_name = daru_name;
                    an.UpdateAfterFactor();
                    // End of Updating Data to the DataBase

                    if (type.Equals("پرستار"))
                    {
                        parastar_anbar pa = new parastar_anbar();
                        pa.daru_name = daru_name;
                        pa.mandeh = -float.Parse(txttedad.Text);
                        pa.MojoodiInc();
                    }
                    else
                    {
                        contact_anbar pa = new contact_anbar();
                        pa.contactid = cid;
                        pa.daru_name = daru_name;
                        pa.mandeh = -float.Parse(txttedad.Text);
                        pa.MojoodiInc();
                    }

                    MessageBox.Show("انجام عملیات با موفقیت به پایان رسید","",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("تعداد مجاز برای برگشت دارو " + maxcanreturn + "می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("کد فاکتور اشتباه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtidno_TextChanged(object sender, EventArgs e)
        {

            if (txttedad.Text.Trim() == "")
            {
                txttedad.Text = "0";
                txttedad.SelectAll();
            }

            if (txttedad.Text == "" || !txtdate.MaskCompleted)
                button1.Enabled = false;
            else
                button1.Enabled = true;
            
        }

        private void frmDaruReturnTedad_Load(object sender, EventArgs e)
        {
            txttedad.Text = maxcanreturn;
            txtdate.Text = cur_date;
        }


        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}