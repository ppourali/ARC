using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace Mehr.Presentation_Layers
{
    public partial class FrmChpass : Form
    {
        CurrencyManager objCurrencyManager;
        DataTable datat = new DataTable();

        private void FillDataSetAndView()
        {
            Accounts ac = new Accounts();
            datat = ac.checkpass();
            // Set our CurrencyManager object
            // to the DataView object...
            objCurrencyManager = (CurrencyManager)(this.BindingContext[datat]);
        }

        private void BindFields()
        {
            // Clear any previous bindings...
            txtfname.DataBindings.Clear();
            txtlname.DataBindings.Clear();
            txtsemat.DataBindings.Clear();
            txttel.DataBindings.Clear();
            txtaddress.DataBindings.Clear();
            txtuser.DataBindings.Clear();
            txtnowpass.DataBindings.Clear();
            txtnewpass.Text = "";
            txtconfirmpass.Text = "";

            txtuser.DataBindings.Add("Text", datat, "user_code");
            txtfname.DataBindings.Add("Text", datat, "fname");
            txtlname.DataBindings.Add("Text", datat, "lname");
            txtsemat.DataBindings.Add("Text", datat, "semat");
            txttel.DataBindings.Add("Text", datat, "tel");
            txtaddress.DataBindings.Add("Text", datat, "address");
            txtnowpass.DataBindings.Add("Text", datat, "pass");

            // Display a ready status...
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        private void ShowPosition()
        {
            rdobtnaccess.Checked = true;
            txtRecordPosition.Text = (objCurrencyManager.Position + 1) + " of " + objCurrencyManager.Count;
            toolStripStatusLabel1.Text = "آماده عملیات";

        }

        public FrmChpass()
        {
            InitializeComponent();

        }
        private void chpass_Load(object sender, EventArgs e)
        {
            
            FillDataSetAndView();
            if (objCurrencyManager.Count == 0)
            {
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;


                txtuser.Text = "";
                txtaddress.Text = "";
                txtfname.Text = "";
                txtlname.Text = "";
                txtsemat.SelectedIndex = 0;
                txttel.Text = "";
                txtnewpass.Text = "";
                txtconfirmpass.Text = "";
                txtnowpass.Text = "";

                btnAdd.Enabled = false;
                btnMoveFirst.Enabled = false;
                btnMovePrevious.Enabled = false;
                btnMoveNext.Enabled = false;
                btnMoveLast.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnNew.Visible = true;
                btnCancel.Visible = true;
                txtRecordPosition.Text = "No Record";
                toolStripStatusLabel1.Text = "آماده ایجاد کاربر جدید";
            }
            else
            {
                BindFields();
                objCurrencyManager.Position = objCurrencyManager.Count - 1;
                ShowPosition();
                btnAdd.Enabled = false;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string position;

            if (txtconfirmpass.Text.CompareTo(txtnewpass.Text) == 0)
            {
                Accounts ac = new Accounts();
                ac.user_code = txtuser.Text.Trim();
                ac.pass = txtnewpass.Text;
                ac.fname = txtfname.Text;
                ac.lname = txtlname.Text;
                ac.tel = txttel.Text;
                ac.address = txtaddress.Text;
                ac.semat = txtsemat.Text.Trim();
                ac.Add();

                FillDataSetAndView();
                BindFields();
                // Set the record position
                // to the one that you saved...
                objCurrencyManager.Position = objCurrencyManager.Count - 1;
                // Show the current record position...
                ShowPosition();
                // Display a message that the record was added...
                toolStripStatusLabel1.Text = "عملیات ثبت کاربر با موفقیت انجام شد";

                // Save the current record position...
                position = objCurrencyManager.Position.ToString();

                btnNew_Click(null, null);

            }
            else
            {
                MessageBox.Show("کلمه های عبور جدید با هم مطابقت ندارد", "خطا");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Declare local variables and objects...
            int intPosition;

            // Save the current record position...
            intPosition = objCurrencyManager.Position;

            if (rdobtnaccess.Checked)
            {
                Accounts acnt = new Accounts();
                acnt.user_code = txtuser.Text.Trim();
                acnt.fname = txtfname.Text;
                acnt.lname = txtlname.Text;
                acnt.tel = txttel.Text;
                acnt.address = txtaddress.Text;
                acnt.semat = txtsemat.Text.Trim();
                acnt.UpdateAccess();

                FillDataSetAndView();
                BindFields();
                // Set the record position
                // to the one that you saved...
                objCurrencyManager.Position = intPosition;
                // Show the current record position...
                ShowPosition();
                // Display a message that the record was updated...
                toolStripStatusLabel1.Text = "عملیات ویرایش کاربر با موفقیت انجام شد";

            }
            else if (rdobtnpass.Checked)
            {

                if (txtconfirmpass.Text.CompareTo(txtnewpass.Text) == 0)
                {
                    Accounts acnt = new Accounts();
                    DataTable dt = new DataTable();

                    acnt.user_code = txtuser.Text.Trim();
                    acnt.pass = txtnowpass.Text;
                    dt = acnt.Select();

                    if (dt.Rows.Count > 0)// password dorost bashad
                    {
                        acnt.user_code = txtuser.Text.Trim();
                        acnt.pass = txtnewpass.Text;
                        acnt.UpdatePassword();
                        MessageBox.Show("کلمه عبور تغییر یافت", "توجه    ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        // Fill the DataSet and bind the fields...
                        FillDataSetAndView();
                        BindFields();
                        // Set the record position
                        // to the one that you saved...
                        objCurrencyManager.Position = intPosition;
                        // Show the current record position...
                        ShowPosition();
                        // Display a message that the record was updated...
                        toolStripStatusLabel1.Text = "عملیات ویرایش کاربر با موفقیت انجام شد";

                    }
                    else
                    {
                        MessageBox.Show("کلمه عبور فعلی را درست وارد نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else
                {
                    MessageBox.Show("کلمه های عبور جدید با هم مطابقت ندارد", "خطا");
                }
            }

        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            rdobtnaccess.Checked = false;
            rdobtnpass.Checked = false;

            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;

            txtRecordPosition.Text = "کاربر جدید";

            txtuser.Text = "";
            txtaddress.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            txtsemat.SelectedIndex = 0;
            txttel.Text="";
            txtnewpass.Text = "";
            txtconfirmpass.Text = "";
            txtnowpass.Text = "";

            btnAdd.Enabled = false;
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnNew.Visible = false;
            btnCancel.Visible = true;
            toolStripStatusLabel1.Text = "لطفا اطلاعات کاربر جدید را وارد نمایید";
            txtuser.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (btnNew.Visible == false)
            {
                // Clear the book title and price fields...
                FillDataSetAndView();
                BindFields();
                objCurrencyManager.Position = objCurrencyManager.Count - 1;
                ShowPosition();
                if (objCurrencyManager.Count == 0)
                    chpass_Load(null, null);
                else
                {
                    txtuser.Enabled = false;
                    btnAdd.Enabled = false;
                    btnMoveFirst.Enabled = true;
                    btnMovePrevious.Enabled = true;
                    btnMoveNext.Enabled = true;
                    btnMoveLast.Enabled = true;
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnNew.Visible = true;
                    btnCancel.Visible = true;
                    toolStripStatusLabel1.Text = "آماده عملیات";
                    rdobtnaccess.Checked = true;
                }
            }
            else if (btnNew.Visible == true)
            {
                this.Close();
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


        private void addbtnTextChanged(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtfname.Text == "" || txtlname.Text == "" || txtnewpass.Text == "" || txtconfirmpass.Text == "" || txtsemat.Text.Trim() == "")
                btnAdd.Enabled = false;
            else if (btnNew.Visible == false)
                btnAdd.Enabled = true;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف کاربر اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {

                Accounts ac = new Accounts();
                ac.user_code = txtuser.Text.Trim();
                ac.Delete();
                FillDataSetAndView();
                BindFields();
                ShowPosition();
                // Display a message that the record was updated...
                toolStripStatusLabel1.Text = "عملیات حذف کاربر با موفقیت انجام شد";
            }
        }

        private void rdobtnaccess_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtnaccess.Checked)
            {
                groupBox4.Enabled = true;
                groupBox1.Enabled = false;
            }
            else if (rdobtnpass.Checked)
            {
                groupBox4.Enabled = false;
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox4.Enabled = true;
                groupBox1.Enabled = true;
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

        }



    }
}