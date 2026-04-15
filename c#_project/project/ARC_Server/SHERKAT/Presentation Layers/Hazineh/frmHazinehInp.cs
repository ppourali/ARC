using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class FrmHazinehInp : Form
    {
        CurrencyManager objCurrencyManager;
        DataTable datat = new DataTable();

        public string cur_date;

        private void FillDataSetAndView()
        {
            // Initialize a new instance of the DataSet object...

            hazineh dp = new hazineh();
            datat = dp.Select();
            // Set our CurrencyManager object to the DataView object...
            objCurrencyManager = (CurrencyManager)(this.BindingContext[datat]);
        }

        private void BindFields()
        {
            // Clear any previous bindings & Add new bindings to the DataView object...
            foreach (Control c in grpinfo_box.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(CurrencyTextBox) || c.GetType() == typeof(ComboBox))
                {
                    c.DataBindings.Clear();
                    c.DataBindings.Add("Text", datat, c.Name.Substring(3));
                }
            }
            // End of Clearing & Adding of Controls Binding
            // Create the list to use as the custom source. 
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            hazineh ac = new hazineh();
            ac.type = txttype.Text.Trim();

            DataTable hazinehdt = new DataTable();
            hazinehdt = ac.SelectforAutoComplete();
            foreach (DataRow dtrow in hazinehdt.Rows)
                source.Add(dtrow["comments"].ToString().Trim());

            // Create and initialize the text box.
            txtcomments.AutoCompleteCustomSource = source;
            txtcomments.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtcomments.AutoCompleteSource = AutoCompleteSource.CustomSource;
            
            // Display a ready status...
            toolStripStatusLabel1.Text = "آماده عملیات";
        }


        private void ShowPosition()
        {

            // Display the current position and the number of records
            txtRecordPosition.Text = (objCurrencyManager.Position + 1) + " of " + objCurrencyManager.Count;
            toolStripStatusLabel1.Text = "آماده عملیات";
        }

        public FrmHazinehInp()
        {
            InitializeComponent();
        }


        private void frmHazinehInp_Load(object sender, EventArgs e)
        {
            hazineh_types ba = new hazineh_types();
            txttype.DataSource = ba.SelectforComboBox();
            txttype.DisplayMember = "htype";

           

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

                txtRecordPosition.Text = "No Records";
                toolStripStatusLabel1.Text = "آماده ایجاد رکورد جدید";

                txtdate.Text = cur_date;
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

            txtRecordPosition.Text = "هزینه ی جدید";

            // Resets the Boxes
            foreach (Control c in grpinfo_box.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(CurrencyTextBox) || c.GetType() == typeof(ComboBox))
                    if (c != txtdate)
                        c.ResetText();
            }

            txtradif.Text = new hazineh().Selectmaxid().ToString();

            // End of Reseting Boxes           

            btnAdd.Enabled = false;
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
            btnNew.Visible = false;
            btnCancel.Visible = true;

            toolStripStatusLabel1.Text = "لطفا اطلاعات هزینه ی جدید را وارد نمایید";
            
            txtdate.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
                DateTime dd = x.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                            int.Parse(txtdate.Text.Substring(5, 2)),
                                            int.Parse(txtdate.Text.Substring(8, 2)),
                                            0, 0, 0, 0, 0);


                // Inserting the Data to the DataBase
                hazineh fa = new hazineh();
                fa.radif = long.Parse(txtradif.Text);
                fa.type = txttype.Text.Trim();
                fa.date = txtdate.Text;
                fa.mablagh = long.Parse(txtmablagh.Text);
                fa.comments = txtcomments.Text;
                fa.Add();
                // End of Inserting Data to the DataBase

                FillDataSetAndView();
                BindFields();

                // Set the record position to the one that you saved...
                objCurrencyManager.Position = objCurrencyManager.Count - 1;

                // Show the current record position...
                ShowPosition();

                // Display a message that the record was added...
                toolStripStatusLabel1.Text = "عملیات ثبت هزینه با موفقیت انجام شد";

                btnNew_Click(null, null);
            }
            catch
            {
                MessageBox.Show("لطفا اطلاعات وارد شده را بررسی نمایید");
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
            if (sender == txttype)
            {
                // Create the list to use as the custom source. 
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                hazineh ac = new hazineh();
                ac.type = txttype.Text.Trim();

                DataTable hazinehdt = new DataTable();
                hazinehdt = ac.SelectforAutoComplete();
                foreach (DataRow dtrow in hazinehdt.Rows)
                    source.Add(dtrow["comments"].ToString().Trim());

                // Create and initialize the text box.
                txtcomments.AutoCompleteCustomSource = source;
                txtcomments.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtcomments.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            if (sender == txtmablagh)
            {
                if (txtmablagh.Text == "")
                {
                    txtmablagh.Text = "0";
                    txtmablagh.Focus();
                    txtmablagh.SelectAll();
                }
            }

        
            if (txtradif.Text == "" || txtcomments.Text == "" || txtmablagh.Text.Trim() == "" || !txtdate.MaskCompleted || txttype.Text.Trim()=="")
                btnAdd.Enabled = false;
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
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            FrmShortHazinehInp fbi = new FrmShortHazinehInp();
            fbi.ShowDialog();

            hazineh_types ba = new hazineh_types();
            txttype.DataSource = ba.SelectforComboBox();
            txttype.DisplayMember = "htype";

            txttype.Focus();
            txttype.SelectAll();
        }


    }
}