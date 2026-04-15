using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmGhabzDaryaft : Form
    {
        public FrmGhabzDaryaft()
        {
            InitializeComponent();
        }


        public string cur_date;
        DataTable dtname = new DataTable();

        private void frmGhabzDaryaft_Load(object sender, EventArgs e)
        {
            newform();
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);
        }

        private void newform()
        {
            //sabt ghabz
            //string count;
            Decimal counter_ghabz = 0;
            DataTable dt = new DataTable();
            string count;
            ghabz gh = new ghabz();
            try
            {
                dt = gh.Selectmaxid();
                count = dt.Rows[0][0].ToString();
                counter_ghabz = Convert.ToDecimal(count) + 1;
            }
            catch (Exception)
            {
                counter_ghabz = 1;
            }

            txtghabz_id.Text = string.Format("{0:000000}", counter_ghabz);

            txtmablagh.Text = "0";
            txtghabzdate.Text = cur_date;
            groupBox1.Focus();
            txtname.Focus();

            Sicks si = new Sicks();
            dtname = si.Search("SELECT id,name, roozaneh,hesab,status FROM sicks order by name");
            txtname.DataSource = dtname;
            txtname.DisplayMember = "name";
            txtname.ValueMember = "name";

            txtid.DataBindings.Clear();
            txtid.DataBindings.Add("Text", dtname, "id");

            txtroozaneh.DataBindings.Clear();
            txtroozaneh.DataBindings.Add("Text", dtname, "roozaneh");

            txthesab.DataBindings.Clear();
            txthesab.DataBindings.Add("Text", dtname, "hesab");

            txtstatus.DataBindings.Clear();
            txtstatus.DataBindings.Add("Text", dtname, "status");

            txtstatus.DataBindings.Clear();
            txtstatus.DataBindings.Add("Text", dtname, "status");

            Assessment ass=new Assessment();
            ass.sick_id = txtid.Text;
            txtTakhfif.Text = ass.SelectforGhabz().ToString();

        }

        private void cmdadd_Click(object sender, EventArgs e)
        {
            Decimal counter_ghabz = 0;
            DataTable dt = new DataTable();
            string count;
            ghabz gh = new ghabz();
            try
            {
                dt = gh.Selectmaxid();
                count = dt.Rows[0][0].ToString();
                counter_ghabz = Convert.ToDecimal(count) + 1;
            }
            catch (Exception)
            {
                counter_ghabz = 1;
            }
            txtghabz_id.Text = string.Format("{0:000000}", counter_ghabz);

            Sicks sicksname = new Sicks();
            sicksname.id = txtid.Text;
            if (!sicksname.SelectfornameCheck().Equals(txtname.Text))
            {
                MessageBox.Show("نام بیمار با شماره پرونده مطابقت ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtname.Focus();
                return;
            }

            ghabz ghab = new ghabz();
            ghab.ghabz_id = txtghabz_id.Text;
            ghab.id = txtid.Text;
            ghab.name = txtname.Text;
            ghab.mablagh = long.Parse(txtmablagh.Text);
            ghab.paid = long.Parse(txtpaid.Text);
            ghab.sharh = txtsharh.Text;
            ghab.date = txtghabzdate.Text;
            ghab.Add();

            //if (long.Parse(txtmablagh.Text) > 0)
            pardakht();

            //if (long.Parse(txtpaid.Text) > 0)
            Daryaft();


            MessageBox.Show("قبض با موفقیت ثبت گردید", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            newform();
        }

        private void pardakht()
        {
            sick_history sh = new sick_history();
            // Elame bedehkari
            sh.ghabz_id = txtghabz_id.Text;
            sh.sick_id = txtid.Text; ;
            sh.sharh = txtsharh.Text;
            sh.date = txtghabzdate.Text;
            sh.bedehkari = long.Parse(txtmablagh.Text);
            //sh.tashkhis = status_after;
            //sh.mandeh = long.Parse(hesab_after);
            sh.Add();

        }

        private void Daryaft()
        {

            sick_history sh = new sick_history();
            // Elame bedehkari
            sh.ghabz_id = txtghabz_id.Text;
            sh.sick_id = txtid.Text; ;
            sh.sharh = "پرداخت وجه از بابت " + txtsharh.Text;
            sh.date = txtghabzdate.Text;
            sh.bestankari = long.Parse(txtpaid.Text);
            //sh.tashkhis = status_after;
            //sh.mandeh = long.Parse(hesab_after);
            sh.Add();

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
                    txtpaid.Text = txtmablagh.Text;
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


            if (txtghabz_id.Text == "" || txtid.Text == "" || txtmablagh.Text=="" || txtsharh.Text=="" || !txtghabzdate.MaskCompleted || txtname.Text=="" || txtpaid.Text=="" || txtstatus.Text=="" || txthesab.Text.Trim()=="")
            {
                btntaeed.Enabled = false;
            }
            else
            {
                btntaeed.Enabled = true;
            }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtid_Validated(object sender, EventArgs e)
        {

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


        private void Validating_Action(object sender, CancelEventArgs e)
        {

        }
        

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            FrmSickHisView fsh = new FrmSickHisView();
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
        }

        private void txtname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text != "")
                btnsabegheh.Enabled = true;
            else
                btnsabegheh.Enabled = false;

            Assessment ass = new Assessment();
            ass.sick_id = txtid.Text;
            txtTakhfif.Text = ass.SelectforGhabz().ToString();

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