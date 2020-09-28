using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Daru.Presentation_Layers
{
    public partial class frmDaruInp : Form
    {
        CurrencyManager objCurrencyManager;
        DataTable datat = new DataTable();

        public string cur_date = "";
        private void FillDataSetAndView()
        {
            // Initialize a new instance of the DataSet object...

            daru dp = new daru();
            datat = dp.Select();
            // Set our CurrencyManager object to the DataView object...
            objCurrencyManager = (CurrencyManager)(this.BindingContext[datat]);
        }

        private void BindFields()
        {
            // Clear any previous bindings & Add new bindings to the DataView object...
            foreach (Control c in grpinfo_box.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(MaskedTextBox) || c.GetType() == typeof(CurrencyTextBox))
                {
                    c.DataBindings.Clear();
                    c.DataBindings.Add("Text", datat, c.Name.Substring(3));
                }
            }
            // End of Clearing & Adding of Controls Binding
           
            
            // Display a ready status...
            toolStripStatusLabel1.Text = "آماده عملیات";
        }


        private void ShowPosition()
        {

            // Display the current position and the number of records
            txtRecordPosition.Text = (objCurrencyManager.Position + 1) + " of " + objCurrencyManager.Count;
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public frmDaruInp()
        {
            InitializeComponent();
        }


        private void frmDaruInp_Load(object sender, EventArgs e)
        {
            anbar an = new anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select * from anbar");
            txtdaru_name.DataSource = combosource;
            txtdaru_name.DisplayMember = "daru_name";
            txtdaru_name.ValueMember = "daru_name";
            lblvahed.DataBindings.Clear();
            lblvahed.DataBindings.Add("Text", combosource, "vahed");
            
            contact cn = new contact();
            DataTable dt = cn.Search("select fullname from contact");
            DataTable dt2 = cn.Search("select fullname from contact");
            txtdaryaft_az.DataSource = dt;
            txttahvil_be.DataSource = dt2;
            txtdaryaft_az.DisplayMember = dt.Columns["fullname"].ToString();
            txttahvil_be.DisplayMember = dt.Columns["fullname"].ToString();
            
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            FillDataSetAndView();
            if (objCurrencyManager.Count == 0)
            {
                grpinfo_box.Enabled = false;

                btnAdd.Enabled = false;
                btnMoveFirst.Enabled = false;
                btnMovePrevious.Enabled = false;
                btnMoveNext.Enabled = false;
                btnMoveLast.Enabled = false;
                btnNew.Visible = true;

                txtRecordPosition.Text = "No Sick";
                toolStripStatusLabel1.Text = "آماده ایجاد رکورد جدید";
            }
            else
            {
                BindFields();
                objCurrencyManager.Position = objCurrencyManager.Count - 1;
                ShowPosition();
                btnAdd.Enabled = false;
            }
           
        }

        
        private void btnNew_Click(object sender, EventArgs e)
        {
            grpinfo_box.Enabled = true;
            
            txtRecordPosition.Text = "اطلاعات جدید";

            // Resets the Boxes
            foreach (Control c in grpinfo_box.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(CurrencyTextBox))
                {
                    c.ResetText();
                }
            }

            // End of Reseting Boxes           
            
            btnAdd.Enabled = false;
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
            btnNew.Visible = false;
            btnCancel.Visible = true;
            
            if (txtdaryaft_az.Items.Count > 0)
            {
                txtdaryaft_az.SelectedIndex = 0;
            }

            if (txttahvil_be.Items.Count > 0)
            {
                txttahvil_be.SelectedIndex = 0;
            }

            if (txtdaru_name.Text == "")
            {
                txtdaru_name.SelectedIndex = 0;
            }
            toolStripStatusLabel1.Text = "لطفا اطلاعات جدید را وارد نمایید";
            txtid.Text = new daru().SelectMaxid();

            txtdaru_date.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
                DateTime dd = x.ToDateTime(int.Parse(txtdaru_date.Text.Substring(0, 4)),
                                            int.Parse(txtdaru_date.Text.Substring(5, 2)),
                                            int.Parse(txtdaru_date.Text.Substring(8, 2)),
                                            0, 0, 0, 0, 0);


                // Inserting the Data to the DataBase
                daru dar = new daru();
                dar.id = int.Parse(txtid.Text);
                dar.daru_date = txtdaru_date.Text;
                dar.daru_name = txtdaru_name.Text;
                dar.tedad = txttedad.Text;
                dar.daryaft_az = txtdaryaft_az.Text;
                dar.tahvil_be = txttahvil_be.Text;
                dar.fee = long.Parse(txtfee.Text);
                dar.fee_kol = long.Parse(txtfee_kol.Text);
                dar.Add();
                // End of Inserting Data to the DataBase

                FillDataSetAndView();
                BindFields();

                // Set the record position to the one that you saved...
                objCurrencyManager.Position = objCurrencyManager.Count - 1;

                // Show the current record position...
                ShowPosition();

                // Display a message that the record was added...
                toolStripStatusLabel1.Text = "عملیات ثبت  با موفقیت انجام شد";

                btnNew_Click(null, null);


            }
            catch
            {
                MessageBox.Show("لطفا تاریخ را بررسی نمایید");
            }
        }

        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            // Move to the previous record...
            objCurrencyManager.Position -= 1;
            // Show the current record position...
            ShowPosition();
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            // Set the record position to the first record...
            objCurrencyManager.Position = 0;
            // Show the current record position...
            ShowPosition();
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            objCurrencyManager.Position += 1;
            //Show the current record position...
            ShowPosition();
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            // Set the record position to the last record...
            objCurrencyManager.Position = objCurrencyManager.Count - 1;
            // Show the current record position...
            ShowPosition();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (btnNew.Visible == false)
            {
                FillDataSetAndView();
                BindFields();

                objCurrencyManager.Position = objCurrencyManager.Count - 1;
                ShowPosition();

                btnAdd.Enabled = false;
                btnMoveFirst.Enabled = true;
                btnMovePrevious.Enabled = true;
                btnMoveNext.Enabled = true;
                btnMoveLast.Enabled = true;
                btnNew.Visible = true;

                toolStripStatusLabel1.Text = "آماده عملیات";
                btnNew.Focus();
            }
            else if (btnNew.Visible == true)
            {
                this.Close();
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (sender == txttedad)
            {
                if (txttedad.Text == "")
                {
                    txttedad.Text = "0";
                    txttedad.Focus();
                    txttedad.SelectAll();
                }
                txtfee_kol.Text = (long.Parse(txttedad.Text) * long.Parse(txtfee.Text)).ToString();
            }
            else if (sender == txtfee)
            {
                if (txtfee.Text == "")
                {
                    txtfee.Text = "0";
                    txtfee.Focus();
                    txtfee.SelectAll();
                }
                txtfee_kol.Text = (long.Parse(txttedad.Text) * long.Parse(txtfee.Text)).ToString();
            }

            if (txtid.Text == "")
            {
                btnAdd.Enabled = false;
            }
            else if (btnNew.Visible == false)
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

            else if (sender.GetType() == typeof(MaskedTextBox))
            {
                ((MaskedTextBox)sender).BackColor = Color.Yellow;
                ((MaskedTextBox)sender).Focus();
                ((MaskedTextBox)sender).SelectAll();
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

            else if (sender.GetType() == typeof(MaskedTextBox))
            {
                ((MaskedTextBox)sender).BackColor = Color.White;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }      
  
    }
}