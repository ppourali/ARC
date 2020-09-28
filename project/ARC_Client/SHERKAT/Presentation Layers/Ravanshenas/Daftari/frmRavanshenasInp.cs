using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmRavanshenasInp : Form
    {
        DataTable datat = new DataTable();

        public string cur_date = "";
        public bool sentbyadamview = false;

        private void ShowPosition()
        {

            // Display the current position and the number of records
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public frmRavanshenasInp()
        {
            InitializeComponent();
        }

        private void frmRavanshenasInp_Load(object sender, EventArgs e)
        {
            // Create the list to use as the custom source. 
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            acc ac = new acc();
            DataTable pezeshkdt = new DataTable();
            pezeshkdt = ac.SelectRavans();
            foreach (DataRow dtrow in pezeshkdt.Rows)
                source.Add(dtrow["name"].ToString().Trim());

            // Create and initialize the text box.
            txtdoctor_name.AutoCompleteCustomSource = source;
            txtdoctor_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtdoctor_name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (Program.user_semat.Trim().Equals("روانشناس"))
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

            ravanshenas rava = new ravanshenas();
            txtcode.Text = rava.Selectmaxid().ToString();

            nemooneh nem = new nemooneh();
            DataTable dtcontext = new DataTable();
            nem.type = "روانشناس";
            dtcontext = nem.Select();
            txtnemooneh.DataSource = dtcontext;
            txtnemooneh.DisplayMember = "context";
            txtnemooneh.ValueMember = "context";

            txtcomments.Text = "";

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
            CanTake = new tahvil_koli().Search("Select id from tahvil_koli where (id=N'" + txtsick_id.Text + "' and tahvil_date=N'" + txtdate.Text + "' and tedad>0)");

            bool CanTakeCheck = true;

            if (CanTake.Rows.Count == 0)
            {
                DialogResult dr;
                dr = MessageBox.Show("بیمار در این تاریخ داروی منزل و یا عدم مراجعه دارد، آیا از ثبت نظر روانشناس اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                if (dr == DialogResult.No)
                {
                    CanTakeCheck = false;
                }
            }

            if (CanTakeCheck == true)
            {
                ravanshenas ravan = new ravanshenas();

                txtcode.Text = ravan.Selectmaxid().ToString();

                ravan.code = long.Parse(txtcode.Text);
                ravan.sick_id = txtsick_id.Text;
                ravan.name = txtname.Text;
                ravan.doctor_name = txtdoctor_name.Text;
                ravan.darman_date = txtdarman_date.Text;
                ravan.date = txtdate.Text;
                ravan.comments = txtcomments.Text;
                ravan.next_date = txtnext_date.Text;
                ravan.Add();


                if (checkBox1.Checked)
                {
                    nemooneh nem = new nemooneh();
                    nem.context = txtcomments.Text;
                    nem.type = "روانشناس";
                    nem.Add();
                }

                // Show the current record position...
                ShowPosition();

                // Display a message that the record was added...
                MessageBox.Show("عملیات ثبت نظر روانشناس با موفقیت انجام شد");

                if (checkBox4.Checked)
                {
                    DataTable ids = new DataTable();
                    ids.Columns.Add("id");

                    DataTable idsandcodes = new DataTable();
                    idsandcodes.Columns.Add("id");
                    idsandcodes.Columns.Add("code");


                    ids.Rows.Add(new object[] { txtsick_id.Text });

                    idsandcodes.Rows.Add(new object[] { txtsick_id.Text, txtcode.Text });

                    frmRavanshenasOnLinePrintViewer fd = new frmRavanshenasOnLinePrintViewer();
                    fd.RealOrNot = false;
                    fd.idtable = ids;
                    fd.idandcodestable = idsandcodes;
                    fd.ShowDialog();
                }

                if (sentbyadamview == true)
                {
                    try
                    {
                        newform();
                        Application.OpenForms["frmDaftariPeygiriPattern"].Activate();
                    }
                    catch
                    {
                    }
                }
                else
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
                    if (si.Search("select code from ravanshenas where (date='" + txtdate.Text + "' and sick_id=N'" + txtsick_id.Text + "')").Rows.Count > 0)
                    {
                        toolStripStatusLabel1.Text = "نظر روانشناس برای این بیمار در این تاریخ قبلا ثبت گردیده است";
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

            if (txtsick_id.Text == "" || txtname.Text.Trim() == "" || txtdate.Text == "0" || txtcode.Text == "" || txtcomments.Text == "")
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

        public void idsearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Sicks si = new Sicks();
            si.id = txtsick_id.Text;
            dt = si.Selectforedit();
            if (dt.Rows.Count > 0)
            {

                grpinfo_box.Enabled = true;

                txtdoctor_name.Focus();

                if (si.Search("select code from ravanshenas where (date=N'" + txtdate.Text + "' and sick_id=N'" + txtsick_id.Text + "')").Rows.Count > 0)
                {
                    toolStripStatusLabel1.Text = "نظر روانشناس برای این بیمار در این تاریخ قبلا ثبت گردیده است";
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
            frmRavanshenasHisView fsh = new frmRavanshenasHisView();
            fsh.sid = this.txtsick_id.Text;
            fsh.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            DialogResult diagr;
            diagr = MessageBox.Show("آیا از حذف این نظر از لیست نمونه ها اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (diagr == DialogResult.Yes)
            {
                nemooneh nemo = new nemooneh();
                nemo.context = txtnemooneh.Text;
                nemo.type = "روانشناس";
                nemo.Delete();

                nemooneh nem = new nemooneh();
                DataTable dtcontext = new DataTable();
                nem.type = "روانشناس";
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
            if (checkBox3.Checked)
                txtcomments.Text = txtnemooneh.Text;
        }

        private void txtsick_id_TextChanged(object sender, EventArgs e)
        {
            tahvil_koli tk = new tahvil_koli();
            dataGridView1.DataSource = tk.Search("SELECT top(5) name, tahvil_date, from_date, to_date, daru_name,tedad FROM tahvil_koli WHERE (id=N'" + txtsick_id.Text + "' and tedad>0) order by tahvil_date desc");

            ravanshenas rav = new ravanshenas();
            dataGridView2.DataSource = rav.Search("SELECT top(1) date, comments FROM ravanshenas WHERE (sick_id=N'" + txtsick_id.Text + "') order by date desc");


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