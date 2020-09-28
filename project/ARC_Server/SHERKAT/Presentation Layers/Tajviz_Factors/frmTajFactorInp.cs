using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmTajFactorInp : Form
    {
        CurrencyManager objCurrencyManager;
        DataTable datat = new DataTable();

        string saved_date, saved_factor_no;
        private void FillDataSetAndView()
        {
            // Initialize a new instance of the DataSet object...

            tajviz_factors dp = new tajviz_factors();
            datat = dp.Select();
            // Set our CurrencyManager object to the DataView object...
            objCurrencyManager = (CurrencyManager)(this.BindingContext[datat]);
        }

        private void BindFields()
        {
            // Clear any previous bindings & Add new bindings to the DataView object...
            foreach (Control c in grpinfo_box.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateMaskedTextbox))
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

        public frmTajFactorInp()
        {
            InitializeComponent();
        }


        private void frmTajFactorInp_Load(object sender, EventArgs e)
        {
            
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            tajviz_anbar an = new tajviz_anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select distinct daru_name from tajviz_anbar");
            txtdaru_name.DataSource = combosource;
            txtdaru_name.DisplayMember = "daru_name";
            txtdaru_name.ValueMember = "daru_name";

            FillDataSetAndView();
            if (objCurrencyManager.Count == 0)
            {
                grpinfo_box.Enabled = false;

                txtdaru_name.SelectedIndex = 0;

                btnAdd.Enabled = false;
                btnMoveFirst.Enabled = false;
                btnMovePrevious.Enabled = false;
                btnMoveNext.Enabled = false;
                btnMoveLast.Enabled = false;
                btnNew.Visible = true;

                txtRecordPosition.Text = "No Factors";
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

            txtRecordPosition.Text = "داروی جدید";

            // Resets the Boxes
            foreach (Control c in grpinfo_box.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType()==typeof(CurrencyTextBox))
                    c.ResetText();
            }

            txtcode.Text = new tajviz_factors().Selectmaxid().ToString();

            txtdaru_name.SelectedIndex = 0;

            txtfactor_no.Text = saved_factor_no;
            txtdate.Text = saved_date;            
            // End of Reseting Boxes           

            btnAdd.Enabled = false;
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
            btnNew.Visible = false;
            btnCancel.Visible = true;

            toolStripStatusLabel1.Text = "لطفا اطلاعات داروی جدید را وارد نمایید";

            txtfactor_no.Focus();

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
                tajviz_factors fa = new tajviz_factors();
                fa.code = long.Parse(txtcode.Text);
                fa.factor_no = txtfactor_no.Text;
                fa.date = txtdate.Text;
                fa.daru_name = txtdaru_name.Text;
                fa.tedad = float.Parse(txttedad.Text);
                fa.masraf_price = long.Parse(txtmasraf_price.Text);
                fa.fee = long.Parse(txtfee.Text);
                fa.fee_kol = long.Parse(txtfee_kol.Text);
                fa.comments = txtcomments.Text.Trim();
                fa.Add();
                // End of Inserting Data to the DataBase

                tajviz_anbar_history dar = new tajviz_anbar_history();
                dar.id = long.Parse(new tajviz_anbar_history().Selectmaxid().ToString());
                dar.date = txtdate.Text;
                dar.contactname = "فاکتور ورود دارو";
                dar.contactid = string.Format("{0:0000}", Convert.ToDecimal(txtcode.Text));
                dar.daru_name = txtdaru_name.Text;
                dar.tedad = float.Parse(txttedad.Text);
                dar.comments = txtcomments.Text.Trim();
                dar.Add();

                // Updating the Data to the DataBase Anbar
                tajviz_anbar an = new tajviz_anbar();
                an.mandeh = float.Parse(txttedad.Text);
                an.daru_name = txtdaru_name.Text;
                an.UpdateAfterFactor();
                // End of Updating Data to the DataBase

                saved_factor_no = txtfactor_no.Text;
                saved_date = txtdate.Text;

                FillDataSetAndView();
                BindFields();

                // Set the record position to the one that you saved...
                objCurrencyManager.Position = objCurrencyManager.Count - 1;

                // Show the current record position...
                ShowPosition();

                // Display a message that the record was added...
                toolStripStatusLabel1.Text = "عملیات ثبت دارو با موفقیت انجام شد";

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
            if (sender == txttedad)
            {
                if (txttedad.Text == "")
                {
                    txttedad.Text = "0";
                    txttedad.Focus();
                    txttedad.SelectAll();
                }
                txtfee_kol.Text = (float.Parse(txttedad.Text) * long.Parse(txtfee.Text)).ToString("N0");
            }
            else if (sender == txtfee)
            {
                if (txtfee.Text == "")
                {
                    txtfee.Text = "0";
                    txtfee.Focus();
                    txtfee.SelectAll();
                }
                txtfee_kol.Text = (float.Parse(txttedad.Text) * long.Parse(txtfee.Text)).ToString("N0");
             
                if (btnNew.Visible == false)
                    txtmasraf_price.Text = txtfee.Text;
            }


            if (txtcode.Text=="" || txtfactor_no.Text == "" || txtdaru_name.Text.Trim() == "" || txtmasraf_price.Text.Trim() == "" || txttedad.Text.Trim() == "" || txtfee.Text.Trim() == "" || txtfee_kol.Text.Trim() == "" || !txtdate.MaskCompleted)
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


    }
}