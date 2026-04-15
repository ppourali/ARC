using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class FrmRealPeygiriInp : Form
    {
        DataTable datat = new DataTable();

        public string cur_date = "";
        public bool sentbyadamview = false;

        private void ShowPosition()
        {

            // Display the current position and the number of records
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public FrmRealPeygiriInp()
        {
            InitializeComponent();
        }

        private void frmRealPeygiriInp_Load(object sender, EventArgs e)
        {
          
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Sicks si = new Sicks();
            DataTable dtname = new DataTable();
            dtname = si.Search("SELECT id,name,darman_date,father_name FROM sicks where len(payan_date)!=10 order by name");
            txtname.DataSource = dtname;
            txtname.DisplayMember = "name";
            txtname.ValueMember = "name";
            txtsick_id.DataBindings.Clear();
            txtsick_id.DataBindings.Add("Text", dtname, "id");
            txtdarman_date.DataBindings.Clear();
            txtdarman_date.DataBindings.Add("Text", dtname, "darman_date");
            txtfather_name.DataBindings.Clear();
            txtfather_name.DataBindings.Add("Text", dtname, "father_name");

            newform();
        }

        private void newform()
        {
            grpinfo_box.Enabled = false;

            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Text = "آماده ثبت پیگیری جدید";
            ShowPosition();
            btnAdd.Enabled = false;


            groupBox1.Enabled = true;
            grpinfo_box.Enabled = false;

            txtdate.Text = cur_date;

            Peygiri_real peyg = new Peygiri_real();
            txtcode.Text = peyg.Selectmaxid().ToString();

            nemooneh nem = new nemooneh();
            DataTable dtcontext = new DataTable();
            nem.type="پیگیری";
            dtcontext = nem.Select();
            txtnemooneh.DataSource = dtcontext;
            txtnemooneh.DisplayMember = "context";
            txtnemooneh.ValueMember = "context";

            txtcomments.Text = "";
            txtnatijeh.Text = "";

            groupBox1.Focus();            
            txtname.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sicks sicksname = new Sicks();
            sicksname.id = txtsick_id.Text;
            if (!sicksname.SelectfornameCheck().Equals(txtname.Text))
            {
                MessageBox.Show("نام بیمار با شماره پرونده مطابقت ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtname.Focus();
                return;
            }
            
            Sicks si = new Sicks();
            if (si.Search("select code from peygiri_real where (date='" + txtdate.Text + "' and sick_id=N'" + txtsick_id.Text + "')").Rows.Count > 0)
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
                    peyg.sick_id = txtsick_id.Text;
                    peyg.name = txtname.Text;
                    peyg.peygiriNo = (long)txtpeygiriNo.Value; ;
                    peyg.darman_date = txtdarman_date.Text;
                    peyg.date = txtdate.Text;
                    peyg.comments = txtcomments.Text;
                    peyg.natijeh = txtnatijeh.Text;
                    peyg.Add();


                    if (checkBox1.Checked)
                    {
                        nemooneh nem = new nemooneh();
                        nem.context = txtcomments.Text;
                        nem.type = "پیگیری";
                        nem.Add();
                    }

                    // Show the current record position...
                    ShowPosition();

                    // Display a message that the record was added...
                    MessageBox.Show("عملیات ثبت پیگیری با موفقیت انجام شد");

                    if (sentbyadamview == true)
                        this.Close();
                    else
                        newform();
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی رخ داده است. لطفا اطلاعات وارد شده را بررسی نمایید");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void TextChanged_Action(object sender, EventArgs e)
        {
           
            if (sender == txtpeygiriNo )
            {
                if (txtpeygiriNo.Text == "")
                {
                    txtpeygiriNo.Value = 1;
                    txtsick_id.SelectAll();
                    txtsick_id.Focus();
                }
            }
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
                btnAdd.Enabled = false;
            else
            {
                btnAdd.Enabled = true;
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
            else if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Yellow;
            }
            else if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.Yellow;
                ((NumericUpDown)sender).Focus();
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
            else if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Transparent;
            }
            else if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.White;
            }
        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {

        }

        public void idsearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Sicks si = new Sicks();
            si.id = txtsick_id.Text;
            dt = si.Selectforedit();
            if (dt.Rows.Count > 0)
            {

                grpinfo_box.Enabled = true;

                txtpeygiriNo.Value = new Peygiri_real().SelectmaxPeygiriNo(txtsick_id.Text);
                txtpeygiriNo.Focus();

                if (si.Search("select code from peygiri_real where (date=N'" + txtdate.Text + "' and sick_id=N'" + txtsick_id.Text + "')").Rows.Count > 0)
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
            else
            {
                MessageBox.Show("مشخصات  در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtdate.Text = cur_date;
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
            fsh.txtid.Text = this.txtsick_id.Text;
            fsh.txtname.Text = this.txtname.Text;
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
                nemo.type = "پیگیری";
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

            if (checkBox3.Checked)
            {
                if (txtcomments.Text.Trim() == "")
                    txtcomments.Text = txtnemooneh.Text;
            }

        }

        private void txtnemooneh_TextChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                txtcomments.Text = txtnemooneh.Text;
        }

        private void txtsick_id_TextChanged(object sender, EventArgs e)
        {
            Peygiri_real pe = new Peygiri_real();
            dataGridView1.DataSource = pe.Search("SELECT name,peygiriNo,date,comments FROM peygiri_real WHERE (sick_id=N'" + txtsick_id.Text + "')");
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