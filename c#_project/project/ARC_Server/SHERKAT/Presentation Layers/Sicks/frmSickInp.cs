using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmSickInp : Form
    {
        CurrencyManager objCurrencyManager;
        DataTable datat = new DataTable();

        public string cur_date = "";
        private void FillDataSetAndView()
        {
            // Initialize a new instance of the DataSet object...

            Sicks dp = new Sicks();
            datat = dp.Select();
            datat.DefaultView.Sort = "darman_date";
            // Set our CurrencyManager object to the DataView object...
            objCurrencyManager = (CurrencyManager)(this.BindingContext[datat]);
        }

        private void BindFields()
        {
            // Clear any previous bindings & Add new bindings to the DataView object...
            foreach (Control c in grpinfo_box.Controls)
            {
                if (c.GetType() == typeof(IDTextBox) || c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(CurrencyTextBox))
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

        public frmSickInp()
        {
            InitializeComponent();
        }


        private void frmSickInp_Load(object sender, EventArgs e)
        {

            if (Program.user_semat.Trim() == "بازرس")
            {
                txtroozaneh.Visible = false;
                lblroozaaneh.Visible = false;
                lbltooman.Visible = false;
                lblvaziathesab.Visible = false;
                lblbemablagh.Visible = false;
                lbltooman2.Visible = false;
                txthesab.Visible = false;
                txtstatus.Visible = false;
            }
            
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            FillDataSetAndView();
            if (objCurrencyManager.Count == 0)
            {
                grpinfo_box.Enabled = false;
                txtravesh_tark.SelectedIndex = 0;
                txtstatus.SelectedIndex = 0;

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
            
            txtRecordPosition.Text = "بیمار جدید";

            // Resets the Boxes
            foreach (Control c in grpinfo_box.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(CurrencyTextBox))
                {
                    c.ResetText();
                }
            }
          
            //txtdarman_date.Text = cur_date;
            txtravesh_tark.SelectedIndex = 0;
            txtstatus.SelectedIndex = 0;
            // End of Reseting Boxes           
            
            btnAdd.Enabled = false;
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
            btnNew.Visible = false;
            btnCancel.Visible = true;

            toolStripStatusLabel1.Text = "لطفا اطلاعات بیمار جدید را وارد نمایید";
            
            txtid.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (new Sicks().Search("SELECT * FROM sicks WHERE (name=N'" + txtname.Text.Trim() + "')").Rows.Count > 0)
                {

                    DialogResult dr;
                    dr = MessageBox.Show("این نام قبلا در سیستم ثبت گردیده است، با ثبت مجدد ممکن است سیستم با مشکل مواجه شود، آیا اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                    if (dr == DialogResult.No)
                    {
                        txtname.Focus();
                        return;
                    }
                }

                System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
                DateTime dd = x.ToDateTime(int.Parse(txtdarman_date.Text.Substring(0, 4)),
                                            int.Parse(txtdarman_date.Text.Substring(5, 2)),
                                            int.Parse(txtdarman_date.Text.Substring(8, 2)),
                                            0, 0, 0, 0, 0);

                if (txtpayan_date.MaskCompleted)
                {
                    DateTime pd = x.ToDateTime(int.Parse(txtpayan_date.Text.Substring(0, 4)),
                                                int.Parse(txtpayan_date.Text.Substring(5, 2)),
                                                int.Parse(txtpayan_date.Text.Substring(8, 2)),
                                                0, 0, 0, 0, 0);
                }

                // Inserting the Data to the DataBase
                Sicks si = new Sicks();
                si.id = txtid.Text;
                si.darman_date = txtdarman_date.Text;
                si.payan_date = txtpayan_date.Text;
                si.name = txtname.Text.Trim();
                si.father_name = txtfather_name.Text.Trim();
                si.b_date = txtb_date.Text.Trim();
                si.city = txtcity.Text.Trim();
                si.id_no = txtid_no.Text.Trim();
                si.sex = txtsex.Text.Trim();
                si.home = txthome.Text.Trim();
                si.mobile = txtmobile.Text.Trim();
                si.masrafi_type = txtmasrafi_type.Text.Trim();
                si.ravesh_tark = txtravesh_tark.Text.Trim();
                si.address = txtaddress.Text.Trim();
                si.roozaneh = long.Parse(txtroozaneh.Text);
                si.monthFee = long.Parse(txtmonthFee.Text);
                si.hesab = long.Parse(txthesab.Text);
                si.status = txtstatus.Text.Trim();

                if (si.Selectforedit().Rows.Count > 0)
                {
                    MessageBox.Show("شماره پرونده وارد شده قبلا در پایگاه داده ثبت گردیده است. لطفا مجددا بررسی نمایید");
                }
                else
                {

                    si.Add();
                    // End of Inserting Data to the DataBase

                    sick_history sickh = new sick_history();
                    sickh.ghabz_id = "-";
                    sickh.sharh = "مانده اولیه";
                    sickh.date = cur_date;
                    sickh.sick_id = txtid.Text;
                    sickh.tashkhis = txtstatus.Text.Trim();
                    sickh.mandeh = long.Parse(txthesab.Text);
                    sickh.Add_firstly();

                    sick_history_daftari sickhd = new sick_history_daftari();
                    sickhd.ghabz_id = "-";
                    sickhd.sharh = "مانده اولیه";
                    sickhd.date = cur_date;
                    sickhd.sick_id = txtid.Text;
                    sickhd.tashkhis = "بدهکار";
                    sickhd.mandeh = 0;
                    sickhd.Add_firstly();
                                                            
                    FillDataSetAndView();
                    BindFields();

                    // Set the record position to the one that you saved...
                    objCurrencyManager.Position = objCurrencyManager.Count - 1;

                    // Show the current record position...
                    ShowPosition();

                    // Display a message that the record was added...
                    toolStripStatusLabel1.Text = "عملیات ثبت بیمار با موفقیت انجام شد";

                    btnNew_Click(null, null);

                }
            }
            catch
            {
                MessageBox.Show("لطفا تاریخ شروع درمان و پایان درمان را بررسی نمایید");
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
            if (txtid.Text == "")
            {
                txtid.Text = "000000000000000";
                txtid.SelectAll();
                txtid.Focus();
            }


            if (txthesab.Text == "")
            {
                txthesab.Text = "0";
                txthesab.SelectAll();
                txthesab.Focus();
            }


            if (txtroozaneh.Text == "")
            {
                txtroozaneh.Text = "0";
                txtroozaneh.SelectAll();
                txtroozaneh.Focus();
            }

            if (txtmonthFee.Text == "")
            {
                txtmonthFee.Text = "0";
                txtmonthFee.SelectAll();
                txtmonthFee.Focus();
            }

            if (txtid.Text == "" || txtname.Text.Trim() == "" || txtid_no.Text.Trim() == "" || txtmasrafi_type.Text.Trim() == "" ||
                !txtdarman_date.MaskCompleted || (!txtpayan_date.MaskCompleted && txtpayan_date.Text != "    /  /") || txtsex.Text == "" || txtroozaneh.Text == "" || txtmonthFee.Text == ""  || txthesab.Text == "" || txtstatus.Text == "")
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

        private void txtdarman_date_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}