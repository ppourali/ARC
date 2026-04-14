using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmAssessmentInp : Form
    {
        DataTable datat = new DataTable();

        public string cur_date = "";

        public frmAssessmentInp()
        {
            InitializeComponent();
        }


        private void frmAssessmentInp_Load(object sender, EventArgs e)
        {
            Sicks si = new Sicks();
            DataTable dtname = new DataTable();
            dtname = si.Search("SELECT id,name,darman_date,father_name FROM sicks where len(payan_date)!=10");
            txtname.DataSource = dtname;
            txtname.DisplayMember = "name";
            txtname.ValueMember = "name";
            txtsick_id.DataBindings.Clear();
            txtsick_id.DataBindings.Add("Text", dtname, "id");

            txtass_date.Text = cur_date;

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);


            btnAdd.Enabled = false;

            grpinfo_box.Focus();
            txtname.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                # region INSERT INTO MOS_LIST
                // Inserting the Data to the DataBase  mos_list//
                Assessment ass = new Assessment();
                ass.sick_id = txtsick_id.Text.Trim();
                ass.name = txtname.Text;
                ass.ass_date = txtass_date.Text;

                ass.q1a = short.Parse(txtq1a.Value.ToString());
                ass.q1b = short.Parse(txtq1b.Value.ToString());
                ass.q2a = short.Parse(txtq2a.Value.ToString());
                ass.q2b = short.Parse(txtq2b.Value.ToString());
                ass.q2c = short.Parse(txtq2c.Value.ToString());
                ass.q2d = short.Parse(txtq2d.Value.ToString());
                ass.q3a = short.Parse(txtq3a.Value.ToString());
                ass.q3b = short.Parse(txtq3b.Value.ToString());
                ass.q3c = short.Parse(txtq3c.Value.ToString());
                ass.q3d = short.Parse(txtq3d.Value.ToString());
                ass.q4a = short.Parse(txtq4a.Value.ToString());
                ass.q4b = short.Parse(txtq4b.Value.ToString());
                ass.q4c = short.Parse(txtq4c.Value.ToString());
                ass.q4d = short.Parse(txtq4d.Value.ToString());
                ass.q4e = short.Parse(txtq4e.Value.ToString());
                ass.sum_all = short.Parse(txtsum_all.Text);

                ass.Add();
                // End of Inserting Data to the DataBase//
                # endregion


                MessageBox.Show("عملیات ثبت اطلاعات ارزیابی با موفقیت انجام شد");
                this.Close();
            }
            catch
            {
                MessageBox.Show("درج اطلاعات ارزیابی با مشکل مواجه گریدید. لطفا اطلاعات ورودی را مجددا بررسی نمایید");
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {

            if (sender.GetType() == typeof(NumericUpDown))
            {
                if (((NumericUpDown)(sender)).Text.Trim() == "" || ((NumericUpDown)(sender)).Value.ToString().Trim() == "")
                    ((NumericUpDown)(sender)).Value = 0;

                txtsum_all.Text = (txtq1a.Value + txtq1b.Value + txtq2a.Value + txtq2b.Value + txtq2c.Value + txtq2d.Value + txtq3a.Value + txtq3b.Value + txtq3c.Value + txtq3d.Value + txtq4a.Value + txtq4b.Value + txtq4c.Value + txtq4d.Value + txtq4e.Value).ToString();
            }

            if (txtsick_id.Text == "" || txtname.Text.Trim() == "" || !txtass_date.MaskCompleted)
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

            else if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.Yellow;
                ((NumericUpDown)sender).Focus();
                ((NumericUpDown)sender).Select(0, 5);
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

            if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.White;
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
            if (txtsick_id.Text.Trim() != "")
                txtsick_id.Text = string.Format("{0:0000}", Convert.ToDecimal(txtsick_id.Text));
        }

        private void txtsick_id_TextChanged(object sender, EventArgs e)
        {
            Assessment tk = new Assessment();
            dataGridView1.DataSource = tk.Search("SELECT top(1) code, sick_id, name, ass_date, sum_all FROM assessment WHERE (sick_id=N'" + txtsick_id.Text + "') order by ass_date desc");
        }

        private void txtq1a_Validating(object sender, CancelEventArgs e)
        {
            if (((NumericUpDown)(sender)).Text.Trim() == "" || ((NumericUpDown)(sender)).Value.ToString().Trim() == "")
            {
                ((NumericUpDown)(sender)).Value = 0;
                ((NumericUpDown)(sender)).Text = "0";
            }

            txtsum_all.Text = (txtq1a.Value + txtq1b.Value + txtq2a.Value + txtq2b.Value + txtq2c.Value + txtq2d.Value + txtq3a.Value + txtq3b.Value + txtq3c.Value + txtq3d.Value + txtq4a.Value + txtq4b.Value + txtq4c.Value + txtq4d.Value + txtq4e.Value).ToString();
        }


    }
}