using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmContactView : Form
    {
        public FrmContactView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmContactView_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Contacts si = new Contacts();
            DataTable dt = new DataTable();
            dt = si.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers={"شماره ","نام مخاطب","تلفن تماس","آدرس"};
            int[] col_width = {70, 120, 120, 170};

            for (int i = 0; i < col_headers.Length; i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }
            
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            Contacts cn = new Contacts();
            DataTable cndt = cn.Search("SELECT fullname FROM contact");

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < cndt.Rows.Count; i++)
            {
                //add the student name into auto complete collection
                collection.Add(cndt.Rows[i]["fullname"].ToString());
            }

            txtfullname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtfullname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtfullname.AutoCompleteCustomSource = collection;
        }

      
        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from contact where ";
                check = false;

                if (txtfullname.Text != "")
                {
                    SQL = SQL + "fullname like '%" + txtfullname.Text.Trim() + "%'AND ";
                    check = true;
                }
                

                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);
                }

                Contacts rm = new Contacts();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtfullname.Text = "";
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmContactView_Activated(object sender, EventArgs e)
        {
            if (btnfilter.Enabled == false)
            {
                Contacts pm = new Contacts();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف رکورد اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int icol = 0;
                int irow = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[icol, irow].Value.ToString();

                Contacts cont = new Contacts();
                cont.id = val;
                cont.Delete();

                Contacts pm = new Contacts();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtfullname.Text == "")
            {
                btnfilter.Enabled = false;

                Contacts pm = new Contacts();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
            else
            {
                btnfilter.Enabled = true;
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            FrmContactInp fsi = new FrmContactInp();
            fsi.cur_date = this.cur_date;
            fsi.MdiParent = this.MdiParent;
            fsi.Show();

            Contacts pm = new Contacts();
            DataTable dt = new DataTable();
            dt = pm.Select();
            grdDataViewer.DataSource = dt;
            
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[col, row].Value.ToString();

                Contacts si = new Contacts();
                DataTable datat = new DataTable();
                si.id = val;

                datat = si.Selectforedit();

                FrmContactEdit fse = new FrmContactEdit();

                fse.txtid.Text = val;
                fse.idsearch_Click(null,null);
                fse.ShowDialog();

                Contacts pm = new Contacts();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
                
            }
        }

    }
}