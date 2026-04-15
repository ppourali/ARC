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
    public partial class FrmSicksEdit : Form
    {
        DataTable dt = new DataTable();
        public string cur_date;

        public FrmSicksEdit()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Sicks isexistSicks = new Sicks();
            isexistSicks.id = txtid.Text;
            DataTable isExistdt = isexistSicks.Selectforedit();

            if (isExistdt.Rows.Count > 0 && !txtid.Text.Equals(txtoldid.Text))
            {
                MessageBox.Show("شماره پرونده ی جدید بیمار در سیستم موجود می باشد");
            }
            else
            {
                if (txtpayan_date.MaskCompleted && (new tahvil().Search("SELECT id FROM tahvil WHERE (id=N'" + txtoldid.Text + "' and date>=N'" + txtpayan_date.Text + "')").Rows.Count > 0))
                {
                    MessageBox.Show("بیمار مورد نظر در روزهای بعد از تاریخ پایان درمان، دارو دریافت کرده است. ابتدا داروهای دریافتی پس از این تاریخ را حدف نموده و مجددا سعی نمایید");

                }
                else
                {
                    try
                    {

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

                        // Updating the Data to the DataBase
                        Sicks si = new Sicks();
                        si.old_id = txtoldid.Text;
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
                        si.Update();
                        // End of Updating Data to the DataBase


                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        mydataaccess.Log(ex);
                        MessageBox.Show("لطفا تاریخ شروع درمان و پایان درمان را بررسی نمایید");
                    }

                }
            }
        }
        
        private void editmembers_Load_1(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

        }


        public void idsearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            Sicks cu = new Sicks();
            cu.id = txtoldid.Text;
            dt = cu.Selectforedit();
            if (dt.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                txtoldid.Enabled = false;
                idsearch.Enabled = false;
                grpinfo_box.Enabled = true;

                // Clear any previous bindings & Add new bindings to the DataView object...
                foreach (Control c in grpinfo_box.Controls)
                {
                    if (c.GetType() == typeof(IDTextBox) || c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(DateMaskedTextbox) || c.GetType() == typeof(CurrencyTextBox))
                    {
                        c.DataBindings.Clear();
                        c.DataBindings.Add("Text", dt, c.Name.Substring(3));
                    }
                }
                // End of Clearing & Adding of Controls Binding
                
                txtid.Focus();
            }
            else
            {
                MessageBox.Show("شماره پرونده در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void KeyDownforSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtoldid.Text.Trim() != "")
                {
                    idsearch.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtoldid.Text == "" || txtname.Text.Trim() == "" || txtid_no.Text.Trim() == "" || txtmasrafi_type.Text.Trim() == "" || txtroozaneh.Text=="" || txtmonthFee.Text==""||
                !txtdarman_date.MaskCompleted ||  (!txtpayan_date.MaskCompleted && txtpayan_date.Text!="    /  /") || txtsex.Text=="" )
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

        private void frmSicksEdit_Load(object sender, EventArgs e)
        {
            if (Program.user_semat.Trim() == "بازرس")
            {
                txtroozaneh.Visible = false;
                lblroozaaneh.Visible = false;
                lbltooman.Visible = false; 
            }
        }

    }
}