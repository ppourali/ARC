using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmTajdidSelectInp : Form
    {
        DataTable datat = new DataTable();

        public frmTajdidSelectInp()
        {
            InitializeComponent();
        }


        private void frmTajdidSelectInp_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Sicks si = new Sicks();
            DataTable dtname = new DataTable();
            dtname = si.Search("SELECT id,name,ravesh_tark FROM sicks");
            txtname.DataSource = dtname;
            txtname.DisplayMember = "name";
            txtname.ValueMember = "name";
            txtid.DataBindings.Clear();
            txtid.DataBindings.Add("Text", dtname, "id");
            txtravesh_tark.DataBindings.Clear();
            txtravesh_tark.DataBindings.Add("Text", dtname, "ravesh_tark");

            groupBox1.Enabled = true;

            groupBox1.Focus();
            txtname.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string val = dataGridView1["code", 0].Value.ToString();

                tajviz_koli tk = new tajviz_koli();
                DataTable datat = new DataTable();
                tk.code = long.Parse(val);
                datat = tk.SelectforEdit();

                frmTajvizEdit te = new frmTajvizEdit();
                te.t_code = datat.Rows[0]["code"].ToString();
                te.sickname = datat.Rows[0]["name"].ToString();
                te.txtid.Text = datat.Rows[0]["id"].ToString();
                te.txttajviz_date.Text = datat.Rows[0]["tajviz_date"].ToString();
                te.txtfrom_date.Text = datat.Rows[0]["from_date"].ToString();
                te.txtto_date.Text = datat.Rows[0]["to_date"].ToString();
                te.txttajviz_day.Text = datat.Rows[0]["tajviz_day"].ToString();
                te.toolStripStatusLabel1.Text = "مشخصه ی تجویز : " + datat.Rows[0]["code"].ToString();
                try
                {
                    te.d1 = datat.Rows[0]["daru_name"].ToString();
                    te.txttedad1.Text = (double.Parse(datat.Rows[0]["tedad"].ToString()) / double.Parse(te.txtdate_dif.Text)).ToString();
                }
                catch
                {
                }

                try
                {
                    te.d2 = datat.Rows[1]["daru_name"].ToString();
                    te.txttedad2.Text = (double.Parse(datat.Rows[1]["tedad"].ToString()) / double.Parse(te.txtdate_dif.Text)).ToString();
                }
                catch
                {
                }

                try
                {
                    te.d3 = datat.Rows[2]["daru_name"].ToString();
                    te.txttedad3.Text = (double.Parse(datat.Rows[2]["tedad"].ToString()) / double.Parse(te.txtdate_dif.Text)).ToString();
                }
                catch
                {
                }

                try
                {
                    te.d4 = datat.Rows[3]["daru_name"].ToString();
                    te.txttedad4.Text = (double.Parse(datat.Rows[3]["tedad"].ToString()) / double.Parse(te.txtdate_dif.Text)).ToString();
                }
                catch
                {
                }

                te.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("بیمار تا کنون دارویی دریافت نداشته، جهت انجام عملیات تجدید دارو، بیمار باید قبلا دارو گرفته باشد");
            }
 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            
            if (txtid.Text == "")
            {
                txtid.Text = "0000";
                txtid.SelectAll();
                txtid.Focus();
            }

            if (txtid.Text == "" )
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

        
        
        private void btnSabegheh_Click(object sender, EventArgs e)
        {
            frmSabeghehView frtv = new frmSabeghehView();
            frtv.id = txtid.Text;
            frtv.tahORtaj = true; 
            frtv.ShowDialog();
            txtname.Focus();
            txtname.SelectAll();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            tajviz_koli tk = new tajviz_koli();
            dataGridView1.DataSource = tk.Search("SELECT * FROM tajviz_koli WHERE (id=N'" + txtid.Text + "' and tajviz_date in (select max (tajviz_date) from tajviz_koli where (id=N'" + txtid.Text + "') ) )");
        }

    }
}