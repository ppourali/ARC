using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Mehr.Presentation_Layers
{
    public partial class FrmHazinehEdit : Form
    {
        DataTable dt = new DataTable();

        public FrmHazinehEdit()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();
                DateTime dd = x.ToDateTime(int.Parse(txtdate.Text.Substring(0, 4)),
                                            int.Parse(txtdate.Text.Substring(5, 2)),
                                            int.Parse(txtdate.Text.Substring(8, 2)),
                                            0, 0, 0, 0, 0);

                // Updating the Data to the DataBase
                hazineh fa = new hazineh();
                fa.radif = long.Parse(txtradif.Text);
                fa.type = txttype.Text.Trim();
                fa.date = txtdate.Text;
                fa.mablagh = long.Parse(txtmablagh.Text);
                fa.comments = txtcomments.Text.Trim();
                fa.update();
                // End of Updating Data to the DataBase

                this.Close();
            }

            catch
            {
                MessageBox.Show("لطفا اطلاعات وارد شده را بررسی نمایید");
            }

        }

        private void editmembers_Load_1(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

        }


        public void idsearch_Click()
        {
            hazineh_types ba = new hazineh_types();
            txttype.DataSource = ba.SelectforComboBox();
            txttype.DisplayMember = "htype";

            hazineh fac = new hazineh();
            fac.radif = long.Parse(txtradif.Text);
            dt = fac.SelectForEslah();

            if (dt.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                txtradif.Enabled = false;
                grpinfo_box.Enabled = true;

                // Clear any previous bindings & Add new bindings to the DataView object...
                foreach (Control c in grpinfo_box.Controls)
                {
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(CurrencyTextBox))
                    {
                        if (c != txtradif)
                        {
                            c.Text = dt.Rows[0][c.Name.Substring(3)].ToString();
                        }
                    }
                }
                // End of Clearing & Adding of Controls Binding

                txtdate.Focus();
            }
            else
            {
                MessageBox.Show("شماره مشخصه در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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


            if (txtradif.Text == "" || txtmablagh.Text.Trim() == "" || txttype.Text.Trim()=="" || txtcomments.Text.Trim() == "" || !txtdate.MaskCompleted)
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
            else if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void Enter_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.Yellow;
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }

            if (sender.GetType() == typeof(CurrencyTextBox))
            {
                ((CurrencyTextBox)sender).BackColor = Color.Yellow;
                ((CurrencyTextBox)sender).Focus();
                ((CurrencyTextBox)sender).SelectAll();
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
            if (sender.GetType() == typeof(CurrencyTextBox))
            {
                ((CurrencyTextBox)sender).BackColor = Color.White;
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

        }


        private void frmHazinehEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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