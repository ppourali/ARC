using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmdastoor_pezeshkEdit : Form
    {
        DataTable datat = new DataTable();

        DataTable dt = new DataTable();
        public string cur_date = "";


        private void ShowPosition()
        {

            // Display the current position and the number of records
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public frmdastoor_pezeshkEdit()
        {
            InitializeComponent();
        }

        private void frmdastoor_pezeshkEdit_Load(object sender, EventArgs e)
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


            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            //Sicks si = new Sicks();
            //DataTable dtname = new DataTable();
            //dtname = si.Search("SELECT id,name,darman_date,father_name FROM sicks");
            //txtname.DataSource = dtname;
            //txtname.DisplayMember = "name";
            //txtname.ValueMember = "name";
            //txtsick_id.DataBindings.Clear();
            //txtsick_id.DataBindings.Add("Text", dtname, "id");
            //txtdarman_date.DataBindings.Clear();
            //txtdarman_date.DataBindings.Add("Text", dtname, "darman_date");
            //txtfather_name.DataBindings.Clear();
            //txtfather_name.DataBindings.Add("Text", dtname, "father_name");

            newform();
            idsearch.PerformClick();
        }

        private void newform()
        {
            grpinfo_box.Enabled = false;

            nemooneh nem = new nemooneh();
            DataTable dtcontext = new DataTable();
            nem.type="دستور پزشک";
            dtcontext = nem.Select();
            txtnemooneh.DataSource = dtcontext;
            txtnemooneh.DisplayMember = "context";
            txtnemooneh.ValueMember = "context";

            azmayesh azm = new azmayesh();
            DataTable dtazm = new DataTable();
            dtazm = azm.Search("SELECT code,type+date as name FROM azmayesh WHERE (sick_id=N'"+txtsick_id.Text+"')");
            txtazmayesh.DataSource = dtazm;
            txtazmayesh.DisplayMember = "name";
            txtazmayesh.ValueMember = "code";

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
                    if (si.Search("select code from dastoor_pezeshk where (date='" + txtdate.Text + "' and sick_id=N'" + txtsick_id.Text + "')").Rows.Count > 0)
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
            //DataTable dt = new DataTable();
            dastoor_pezeshk das = new dastoor_pezeshk();
            das.code =long.Parse( txtcode.Text);
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
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(DateMaskedTextbox))
                    {
                        c.DataBindings.Clear();
                        c.DataBindings.Add("Text", dt, c.Name.Substring(3));
                    }
                }
                if (dt.Rows[0]["azmayesh"].ToString().Trim() != "")
                {
                    txtazmayesh.Text = dt.Rows[0]["azmayesh"].ToString();
                    checkBox2.Checked = true;
                }
                else
                    checkBox2.Checked = false;

                    // End of Clearing & Adding of Controls Binding

                    txtdate.Focus();
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
            frmDastoorHisView fsh = new frmDastoorHisView();
            fsh.sid = this.txtsick_id.Text;
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

        }

        private void txtnemooneh_TextChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            txtpre_text.Text = txtnemooneh.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable CanTake = new DataTable();
            CanTake = new tahvil_koli().Search("Select id from tahvil_koli where (id=N'" + txtsick_id.Text + "' and tahvil_date=N'" + txtdate.Text + "' and tedad>0)");

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
                dastoor_pezeshk das_pez = new dastoor_pezeshk();
                das_pez.code = long.Parse(txtcode.Text);
                das_pez.doctor_name = txtdoctor_name.Text;
                das_pez.date = txtdate.Text;
                das_pez.pre_text = txtpre_text.Text.Trim();

                if (checkBox2.Checked)
                    das_pez.azmayesh = txtazmayesh.Text;
                else
                    das_pez.azmayesh = "";

                das_pez.sick_id = txtsick_id.Text;
                das_pez.Update();


                if (checkBox1.Checked)
                {
                    nemooneh nem = new nemooneh();
                    nem.context = txtpre_text.Text;
                    nem.type = "دستور پزشک";
                    nem.Add();
                }

                this.Close();
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