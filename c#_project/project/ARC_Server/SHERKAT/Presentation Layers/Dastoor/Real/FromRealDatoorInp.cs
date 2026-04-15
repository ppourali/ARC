using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class FromRealDatoorInp : Form
    {
        DataTable datat = new DataTable();

        public string cur_date = "";


        private void ShowPosition()
        {

            // Display the current position and the number of records
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public FromRealDatoorInp()
        {
            InitializeComponent();
        }

        private void frmRealdastoor_pezeshkInp_Load(object sender, EventArgs e)
        {

            // Create the list to use as the custom source. 
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            Accounts ac = new Accounts();
            DataTable pezeshkdt = new DataTable();
            pezeshkdt = ac.SelectDoctors();
            foreach (DataRow dtrow in pezeshkdt.Rows)
                source.Add(dtrow["name"].ToString().Trim());

            // Create and initialize the text box.
            txtdoctor_name.AutoCompleteCustomSource = source;
            txtdoctor_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtdoctor_name.AutoCompleteSource = AutoCompleteSource.CustomSource;


            if (Program.user_semat.Trim().Equals("پزشک"))
                txtdoctor_name.Text = Program.user_name;
            else
            {
                if (pezeshkdt.Rows.Count == 1)
                    txtdoctor_name.Text = pezeshkdt.Rows[0]["name"].ToString();
            }

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Sicks si = new Sicks();
            DataTable dtname = new DataTable();
            dtname = si.Search("SELECT id,name,darman_date,father_name FROM sicks where len(payan_date)!=10");
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
            toolStripStatusLabel1.Text = "آماده ثبت دستور جدید";
            ShowPosition();
            btnAdd.Enabled = false;


            groupBox1.Enabled = true;
            grpinfo_box.Enabled = false;

            txtdate.Text = cur_date;

            dastoor_pezeshk_real das_pez = new dastoor_pezeshk_real();
            txtcode.Text = das_pez.Selectmaxid().ToString();

            nemooneh nem = new nemooneh();
            DataTable dtcontext = new DataTable();
            nem.type="دستور پزشک";
            dtcontext = nem.Select();
            txtnemooneh.DataSource = dtcontext;
            txtnemooneh.DisplayMember = "context";
            txtnemooneh.ValueMember = "context";

            AzmayeshReal azm = new AzmayeshReal();
            DataTable dtazm = new DataTable();
            dtazm = azm.Search("SELECT code,type+date as name FROM azmayesh_real WHERE (sick_id=N'"+txtsick_id.Text+"')");
            txtazmayesh.DataSource = dtazm;
            txtazmayesh.DisplayMember = "name";
            txtazmayesh.ValueMember = "code";

            txtpre_text.Text = "";

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
            
            DataTable CanTake = new DataTable();
            CanTake = new tajviz_koli().Search("Select id from tajviz_koli where (id=N'" + txtsick_id.Text + "' and tajviz_date=N'" + txtdate.Text + "' and tedad>0)");

            bool CanTakeCheck = true;

            if (CanTake.Rows.Count == 0)
            {
                DialogResult dr;
                dr = MessageBox.Show("بیمار در این تاریخ داروی منزل و یا عدم مراجعه دارد، آیا از ثبت دستور پزشک اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                if (dr == DialogResult.No)
                {
                    CanTakeCheck = false;
                }
            }

            if (CanTakeCheck == true)
            {
                dastoor_pezeshk_real das_pez = new dastoor_pezeshk_real();

                txtcode.Text = das_pez.Selectmaxid().ToString();

                das_pez.code = long.Parse(txtcode.Text);
                das_pez.sick_id = txtsick_id.Text;
                das_pez.name = txtname.Text;
                das_pez.doctor_name = txtdoctor_name.Text;
                das_pez.darman_date = txtdarman_date.Text;
                das_pez.date = txtdate.Text;
                das_pez.pre_text = txtpre_text.Text.Trim();

                if (checkBox2.Checked)
                    das_pez.azmayesh = txtazmayesh.Text;

                das_pez.Add();


                if (checkBox1.Checked)
                {
                    nemooneh nem = new nemooneh();
                    nem.context = txtpre_text.Text;
                    nem.type = "دستور پزشک";
                    nem.Add();
                }

                // Show the current record position...
                ShowPosition();

                // Display a message that the record was added...
                MessageBox.Show("عملیات ثبت دستور با موفقیت انجام شد");

                newform();
            }
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
                    if (si.Search("select code from dastoor_pezeshk_real where (date='" + txtdate.Text + "' and sick_id=N'" + txtsick_id.Text + "')").Rows.Count > 0)
                    {
                        toolStripStatusLabel1.Text = "این بیمار در این روز دستور گرفته است";
                        toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "آماده عملیات";
                        toolStripStatusLabel1.ForeColor = Color.Black;
                    }
                }
            }

            if (sender == txtpre_text)
            {
                if (txtpre_text.Text.Trim() == "")
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

            if (txtsick_id.Text == "" || txtname.Text.Trim() == "" || txtdate.Text == "0" || txtcode.Text == "" || txtpre_text.Text == "")
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
        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {

        }

        private void idsearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Sicks si = new Sicks();
            si.id = txtsick_id.Text;
            dt = si.Selectforedit();
            if (dt.Rows.Count > 0)
            {

                grpinfo_box.Enabled = true;

                txtdate.Focus();

                if (si.Search("select code from dastoor_pezeshk_real where (date=N'" + txtdate.Text + "' and sick_id=N'"+txtsick_id.Text+"')").Rows.Count > 0)
                {
                    toolStripStatusLabel1.Text = "این بیمار در این روز دستور گرفته است";
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
            FrmRealDastoorHisView fsh = new FrmRealDastoorHisView();
            fsh.sid = this.txtsick_id.Text;
            fsh.cur_date = this.cur_date;
            fsh.name = txtname.Text;
            fsh.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            DialogResult diagr;
            diagr = MessageBox.Show("آیا از حذف این دستور از لیست نمونه ها اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (diagr == DialogResult.Yes)
            {
                nemooneh nemo = new nemooneh();
                nemo.context = txtnemooneh.Text;
                nemo.type = "دستور پزشک";
                nemo.Delete();

                nemooneh nem = new nemooneh();
                DataTable dtcontext = new DataTable();
                nem.type = "دستور پزشک";
                dtcontext = nem.Select();
                txtnemooneh.DataSource = dtcontext;
                txtnemooneh.DisplayMember = "context";
                txtnemooneh.ValueMember = "context";

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtazmayesh.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            txtnemooneh.Enabled = checkBox3.Checked;
            pictureBox1.Enabled = checkBox3.Checked;

            if (checkBox3.Checked)
            {
                if (txtpre_text.Text.Trim() == "")
                    txtpre_text.Text = txtnemooneh.Text;
            }

        }

        private void txtnemooneh_TextChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            txtpre_text.Text = txtnemooneh.Text;
        }

        private void txtsick_id_TextChanged(object sender, EventArgs e)
        {
            tajviz_koli tk = new tajviz_koli();
            dataGridView1.DataSource = tk.Search("SELECT distinct top(5) tk.name, tk.tajviz_date, tk.from_date, tk.to_date, tk.daru_name, tk.tedad, t.tedad as roozaneh FROM tajviz_koli tk " +
                                     "left join (select * from tajviz) t on tk.code=t.code  and tk.daru_name=t.daru_name " +
                                     "WHERE (tk.id=N'" + txtsick_id.Text + "' and tk.tedad>0) order by tk.tajviz_date desc, tk.from_date desc");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmSabeghehView frtv = new FrmSabeghehView();
            frtv.id = txtsick_id.Text;

            //if (Program.user.Trim() == "بازرس")
            frtv.tahORtaj = true;
            //else
            //frtv.tahORtaj = true;

            frtv.ShowDialog();
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