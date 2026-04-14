using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mehr.Presentation_Layers
{
    public partial class frmadddarmangah : Form
    {
        CurrencyManager objCurrencyManager;
        DataTable datat = new DataTable();
        DataTable dtpr = new DataTable();
        //string oldidno;

        byte[] photo = null;
        bool flag = false;

        private void FillDataSetAndView()
        {
            Darmangah st = new Darmangah();

            datat = st.Select();
            // Set our CurrencyManager object
            // to the DataView object...
            objCurrencyManager = (CurrencyManager)(this.BindingContext[datat]);
        }

        private void BindFields()
        {
            // Clear any previous bindings...
            txtaddress.DataBindings.Clear();
            txtname.DataBindings.Clear();
            txttel.DataBindings.Clear();
            txtGen_Pass.DataBindings.Clear();


            // Add new bindings to the DataView object...
            txtaddress.DataBindings.Add("Text", datat, "address");
            txtname.DataBindings.Add("Text", datat, "name");
            txttel.DataBindings.Add("Text", datat, "tel");
            txtGen_Pass.DataBindings.Add("Text", datat, "Gen_Pass");

            // Display a ready status...
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        private void ShowPosition()
        {

            // Display the current position
            // and the number of records
            //txtRecordPosition.Text = (objCurrencyManager.Position + 1) + " of " + objCurrencyManager.Count;
            toolStripStatusLabel1.Text = "آماده عملیات";
            txtname.Enabled = false;
            
            Darmangah st = new Darmangah();
            st.name = txtname.Text;

            SqlDataReader dstdr;

            try
            {
                dstdr = st.Selectimg();

                while (dstdr.Read())
                {
                    if (!dstdr.IsDBNull(0))
                    {

                        byte[] photo1 = (byte[])dstdr[0];

                        MemoryStream ms = new MemoryStream(photo1);
                        img_axbox.Image = Image.FromStream(ms);
                        pictureBox1.Enabled = true;

                    }
                    else
                    {
                        img_axbox.Image = null;
                        pictureBox1.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("در اطلاعات این مرکز عکس موجود نیست", "توجه    ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


            flag = false;

        }


        public frmadddarmangah()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Darmangah da = new Darmangah();
            if (da.Select().Rows.Count > 0)
            {
                frmEditPassInput fad = new frmEditPassInput();
                if (fad.ShowDialog() != DialogResult.Abort)
                {
                    Add();
                }
            }
            else
            {
                Add();
            }
        }

        private void Add()
        {
            string position;

            Darmangah st = new Darmangah();

            st.Delete();

            st.address = txtaddress.Text;
            st.name = txtname.Text;
            st.tel = txttel.Text;
            st.Gen_Pass = txtGen_Pass.Text;
            st.flag = flag;
            st.photo = photo;

            st.Add();

            Gen_settings te = new Gen_settings();
            te.PayType = "روزانه";
            te.Takhfif_Inc = "بلی";
            te.Delete();
            te.Add();

            FillDataSetAndView();
            BindFields();
            // Set the record position
            // to the one that you saved...
            objCurrencyManager.Position = objCurrencyManager.Count - 1;
            // Show the current record position...
            ShowPosition();
            // Display a message that the record was added...
            toolStripStatusLabel1.Text = "عملیات درج رکورد با موفقیت انجام شد";

            // Save the current record position...
            position = objCurrencyManager.Position.ToString();

            btnAdd.Enabled = false;
            //btnMoveFirst.Enabled = false;
            //btnMovePrevious.Enabled = false;
            //btnMoveNext.Enabled = false;
            //btnMoveLast.Enabled = false;
            btnUpdate.Enabled = false;
            btnNew.Visible = false;
            btnCancel.Visible = true;
            toolStripStatusLabel1.Text = "لطفا اطلاعات رکورد جدید را وارد نمایید";
            txtname.Focus();

            btnCancel_Click(null, null);
        }

        private void frmadddarmangah_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);


            FillDataSetAndView();
            if (objCurrencyManager.Count == 0)
            {
                txtaddress.Enabled = false;
                txtname.Enabled = false;
                txttel.Enabled = false;
                txtGen_Pass.Enabled = false;
                
                btnAdd.Enabled = false;
                //btnMoveFirst.Enabled = false;
                //btnMovePrevious.Enabled = false;
                //btnMoveNext.Enabled = false;
                //btnMoveLast.Enabled = false;
                ////btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnNew.Visible = true;
                btnCancel.Visible = false;
                //txtRecordPosition.Text = "No Record";
                toolStripStatusLabel1.Text = "آماده ایجاد رکورد جدید";
            }
            else
            {
                BindFields();
                objCurrencyManager.Position = objCurrencyManager.Count - 1;
                ShowPosition();
                btnAdd.Enabled = false;
            }
            btnNew.Focus();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            
            txtaddress.Enabled = true;
            txtname.Enabled = true;
            txttel.Enabled = true;
            txtGen_Pass.Enabled = true;
            // Clear the book title and price fields...
            //txtRecordPosition.Text = "رکورد جدید";

            txtaddress.Text = "";
            txtname.Text = "";
            txttel.Text = "";
            txtGen_Pass.Text = "";
            img_axbox.Image = null;


            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnNew.Visible = false;
            btnCancel.Visible = true;
            toolStripStatusLabel1.Text = "لطفا اطلاعات رکورد جدید را وارد نمایید";
            txtname.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmEditPassInput fad = new frmEditPassInput();
            if (fad.ShowDialog() != DialogResult.Abort)
            {
                // Declare local variables and objects...
                int intPosition;

                // Save the current record position...
                intPosition = objCurrencyManager.Position;
                // Set the SqlCommand object properties...


                Darmangah st = new Darmangah();

                st.address = txtaddress.Text;
                st.name = txtname.Text;
                st.tel = txttel.Text;
                st.flag = flag;
                st.photo = photo;
                st.Update();

                st.Gen_Pass = txtGen_Pass.Text;
                st.ChangePass();

                // Fill the DataSet and bind the fields...
                FillDataSetAndView();
                BindFields();
                // Set the record position
                // to the one that you saved...
                objCurrencyManager.Position = intPosition;
                // Show the current record position...
                ShowPosition();
                // Display a message that the record was updated...
                toolStripStatusLabel1.Text = "عملیات ویرایش رکورد با موفقیت انجام شد";
            }
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
                btnAdd.Enabled = false;
                //btnMoveFirst.Enabled = true;
                //btnMovePrevious.Enabled = true;
                //btnMoveNext.Enabled = true;
                //btnMoveLast.Enabled = true;
                btnUpdate.Enabled = true;
                btnNew.Visible = true;
                //btnCancel.Visible = false;
                txtname.Enabled = false;
                toolStripStatusLabel1.Text = "آماده عملیات";
            }
            else if (btnNew.Visible == true)
            {
                this.Close();
            }

        }


        private void addbtnTextChanged(object sender, EventArgs e)
        {
            if (txtaddress.Text == "" || txtname.Text == "" || txttel.Text == "" || txtGen_Pass.Text.Trim()=="")
                btnAdd.Enabled = false;
            else if (btnNew.Visible == false)
                btnAdd.Enabled = true;
        }

        private void picbtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String file1;
                img_axbox.ImageLocation = openFileDialog1.FileName.ToString();

                img_axbox.Load();
                file1 = openFileDialog1.FileName.ToString();
                FileStream stream = new FileStream(file1, FileMode.Open, FileAccess.Read);
                BinaryReader breader = new BinaryReader(stream);
                photo = breader.ReadBytes((int)stream.Length);
                breader.Close();
                stream.Close();
                flag = true;


            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult m;
            m = MessageBox.Show("آیا از حذف لوگوی مرکز اطمینان دارید ؟ ", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (m == DialogResult.Yes)
            {
                Darmangah st = new Darmangah();

                st.name = txtname.Text;
                st.Updateforpic();
                ShowPosition();
            }

        }

        //private void img_axbox_Click(object sender, EventArgs e)
        //{

        //    if (img_axbox.Image == null)
        //        MessageBox.Show("در اطلاعات این فروشگاه عکس موجود نیست", "توجه    ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        //    else
        //    {
        //        image img_view = new image(txtname.Text);
        //        img_view.ShowDialog();
        //    }
        //}

        private void txtaddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Darmangah dar = new Darmangah();
            if (dar.Select().Rows.Count == 0)
            {
                if (MessageBox.Show("برای اجرای صحیح نرم افزار، ثبت اطلاعات مرکز الزامیست! مجددا سعی می کنید؟", "خطا", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else if (dar.Select().Rows.Count > 0)
            {
                this.Close();
            }

        }
    }
}

