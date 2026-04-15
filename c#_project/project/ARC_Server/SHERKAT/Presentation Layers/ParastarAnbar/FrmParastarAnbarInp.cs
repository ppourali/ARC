using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class FrmParastarAnbarInp : Form
    {
        DataTable datat = new DataTable();

        public string cur_date = "";

        public FrmParastarAnbarInp()
        {
            InitializeComponent();
        }


        private void frmParastar_AnbarInp_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            NewForm();
        }


        private void NewForm()
        {
            grpinfo_box.Enabled = true;


            tajviz_anbar an = new tajviz_anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select * from tajviz_anbar");
            txtdaru_name.DataSource = combosource;
            txtdaru_name.DisplayMember = "daru_name";
            txtdaru_name.ValueMember = "daru_name";
            lblvahed.DataBindings.Clear();
            lblvahed.DataBindings.Add("Text", combosource, "vahed");

            Contacts cn = new Contacts();
            DataTable dt = cn.Search("select id,fullname from contact");

            dt.Rows.Add(new object[] { "0000", "پرستار" });
            dt.DefaultView.Sort = "id";

            txtcontactname.DataSource = dt;
            txtcontactname.DisplayMember = dt.Columns["fullname"].ToString();
            txtcontactname.ValueMember = dt.Columns["fullname"].ToString();

            txtcontactid.DataBindings.Clear();
            txtcontactid.DataBindings.Add("Text", dt, "id");

            txtdate.Text = cur_date;
            txttedad.Text = "0";
            txtcomments.Text = "";
            // End of Reseting Boxes           

            btnAdd.Enabled = false;
            btnCancel.Visible = true;

            if (txtcontactname.Items.Count > 0)
            {
                txtcontactname.SelectedIndex = 0;
            }

            if (txtdaru_name.Text == "")
            {
                txtdaru_name.SelectedIndex = 0;
            }
           
            grpinfo_box.Focus();
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
                tajviz_anbar_history dar = new tajviz_anbar_history(); 
                dar.date = txtdate.Text;
                dar.contactname = txtcontactname.Text;
                dar.contactid = txtcontactid.Text;
                dar.daru_name = txtdaru_name.Text;
                dar.tedad = -float.Parse(txttedad.Text);
                dar.comments = txtcomments.Text.Trim();
                dar.Add();

                // Updating the Data to the DataBase Anbar
                tajviz_anbar tan = new tajviz_anbar();
                tan.daru_name = txtdaru_name.Text;
                tan.mandeh = -float.Parse(txttedad.Text);
                tan.UpdateAfterFactor();

                if (txtcontactid.Text.Equals("0000"))
                {
                    parastar_anbar pa = new parastar_anbar();
                    pa.daru_name = txtdaru_name.Text;
                    pa.mandeh = float.Parse(txttedad.Text);
                    pa.vahed = lblvahed.Text;
                    pa.Add();
                }
                else
                {
                    ContactsAnbar pa = new ContactsAnbar();
                    pa.contactid = txtcontactid.Text;
                    pa.contactname = txtcontactname.Text;
                    pa.daru_name = txtdaru_name.Text;
                    pa.mandeh = float.Parse(txttedad.Text);
                    pa.vahed = lblvahed.Text;
                    pa.Add();
                }

                // End of Inserting Data to the DataBase

                // Display a message that the record was added...
                MessageBox.Show("برداشت دارو از گاوصندوق با موفقیت انجام شد");

                NewForm();
            }
            catch
            {
                MessageBox.Show("لطفا تاریخ را بررسی نمایید");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            }

            if (txtdaru_name.Text == "" || txtcontactname.Text == "" || !txtdate.MaskCompleted || txttedad.Text == "0")
            {
                btnAdd.Enabled = false;
            }
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
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

    }
}