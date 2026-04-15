using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class FrmRealPeygiriEdit : Form
    {
        DataTable datat = new DataTable();

        DataTable dt = new DataTable();
        public string cur_date = "";


        private void ShowPosition()
        {

            // Display the current position and the number of records
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public FrmRealPeygiriEdit()
        {
            InitializeComponent();
        }

        private void frmRealPeygiriEdit_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            newform();
            idsearch.PerformClick();
        }

        private void newform()
        {
            grpinfo_box.Enabled = false;

            nemooneh nem = new nemooneh();
            DataTable dtcontext = new DataTable();
            nem.type="پیگیری";
            dtcontext = nem.Select();
            txtnemooneh.DataSource = dtcontext;
            txtnemooneh.DisplayMember = "context";
            txtnemooneh.ValueMember = "context";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (sender == txtdate)
            {
                if (txtdate.MaskCompleted)
                {

                    Sicks si = new Sicks();
                    if (si.Search("select code from peygiri_real where (date='" + txtdate.Text + "' and sick_id=N'" + txtsick_id.Text + "')").Rows.Count > 0)
                    {
                        toolStripStatusLabel1.Text = "پیگیری برای این بیمار در این تاریخ قبلا ثبت گردیده است";
                        toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "آماده عملیات";
                        toolStripStatusLabel1.ForeColor = Color.Black;
                    }
                }
            }

            if (sender == txtcomments)
            {
                if (txtcomments.Text.Trim() == "")
                {
                    checkBox1.Checked = false;
                    checkBox1.Enabled = false;
                }
                else
                {
                    checkBox1.Enabled = true;
                }
            }

            if (txtsick_id.Text == "")
            {
                txtsick_id.Text = "000000000000000";
                txtsick_id.SelectAll();
                txtsick_id.Focus();
            }

            if (txtsick_id.Text == "" || txtname.Text.Trim() == "" || !txtdate.MaskCompleted || txtcode.Text.Trim() == "" || txtcomments.Text.Trim() == "" || txtpeygiriNo.Text.Trim() == "")
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
            else if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.Yellow;
                ((NumericUpDown)sender).Focus();
            }
            else if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Yellow;
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
            else if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.White;
            }
            else if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Transparent;
            }
        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {

        }

        private void idsearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            Peygiri_real das = new Peygiri_real();
            das.code = long.Parse(txtcode.Text);
            dt = das.Selectforedit();
            if (dt.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                groupBox1.Enabled = false;
                idsearch.Enabled = false;
                grpinfo_box.Enabled = true;

                // Clear any previous bindings & Add new bindings to the DataView object...
                foreach (Control c in groupBox1.Controls)
                {
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(IDTextBox))
                    {
                        c.DataBindings.Clear();
                        c.DataBindings.Add("Text", dt, c.Name.Substring(3));
                    }
                }
                foreach (Control c in grpinfo_box.Controls)
                {
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(NumericUpDown))
                    {
                        c.DataBindings.Clear();
                        c.DataBindings.Add("Text", dt, c.Name.Substring(3));
                    }
                }
                // End of Clearing & Adding of Controls Binding

                txtpeygiriNo.Focus();
            }
            else
            {
                MessageBox.Show("مشخصات در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void KeyDownforSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtsick_id.Text = string.Format("{0:000000000000000}", Convert.ToDecimal(txtsick_id.Text));
                idsearch.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRealPeygiriHisView fsh = new FrmRealPeygiriHisView();
            fsh.txtname.Text = this.txtname.Text;
            fsh.txtid.Text = this.txtsick_id.Text;
            fsh.sabegheh = true;
            fsh.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            DialogResult diagr;
            diagr = MessageBox.Show("آیا از حذف این پیگیری از لیست نمونه ها اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (diagr == DialogResult.Yes)
            {
                nemooneh nemo = new nemooneh();
                nemo.context = txtnemooneh.Text;
                nemo.type ="پیگیری";
                nemo.Delete();

                nemooneh nem = new nemooneh();
                DataTable dtcontext = new DataTable();
                nem.type = "پیگیری";
                dtcontext = nem.Select();
                txtnemooneh.DataSource = dtcontext;
                txtnemooneh.DisplayMember = "context";
                txtnemooneh.ValueMember = "context";

            }
        }

       
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            txtnemooneh.Enabled = checkBox3.Checked;
            pictureBox1.Enabled = checkBox3.Checked;

        }

        private void txtnemooneh_TextChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            txtcomments.Text = txtnemooneh.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Sicks si = new Sicks();
            if (si.Search("select code from peygiri_real where (code!=" + long.Parse(txtcode.Text) + " and date='" + txtdate.Text + "' and sick_id=N'" + txtsick_id.Text + "')").Rows.Count > 0)
            {
                MessageBox.Show("پیگیری برای این بیمار در این تاریخ قبلا ثبت گردیده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdate.Focus();
                return;
            }
            else
            {
                try
                {
                    Peygiri_real peyg = new Peygiri_real();
                    peyg.code = long.Parse(txtcode.Text);
                    peyg.peygiriNo = (long)txtpeygiriNo.Value;
                    peyg.date = txtdate.Text;
                    peyg.comments = txtcomments.Text;
                    peyg.natijeh = txtnatijeh.Text;
                    peyg.sick_id = txtsick_id.Text;
                    peyg.Update();


                    if (checkBox1.Checked)
                    {
                        nemooneh nem = new nemooneh();
                        nem.context = txtcomments.Text;
                        nem.type = "پیگیری";
                        nem.Add();
                    }

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی رخ داده است. لطفا اطلاعات وارد شده را بررسی نمایید");
                }
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
            {
                btnSabegheh.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}