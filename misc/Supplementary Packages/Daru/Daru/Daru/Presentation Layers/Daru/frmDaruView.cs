using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Daru.Presentation_Layers
{
    public partial class frmDaruView : Form
    {
        public frmDaruView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmDaruView_Load(object sender, EventArgs e)
        {
            txtdaru_name.SelectedIndex = 0;

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            daru si = new daru();
            DataTable dt = new DataTable();
            dt = si.Select();

            if (dt.Rows.Count == 0)
            {
                btnedit.Enabled = false;
                btndel.Enabled = false;
            }

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "شماره ", "تاریخ", "نام دارو", "تعداد", "دریافت از", "تحویل به", "مبلغ واحد(تومان)", "مبلغ کل(تومان)" };
            int[] col_width = {50, 80, 120, 50, 120, 120, 90, 90};

            for (int i = 0; i < col_headers.Length; i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }
            
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            grdDataViewer.Columns["fee"].DefaultCellStyle = dataGridViewCellStyle1;
            grdDataViewer.Columns["fee_kol"].DefaultCellStyle = dataGridViewCellStyle1;

            contact cn=new contact();
            DataTable cndt= cn.Search("SELECT fullname FROM contact");
            
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < cndt.Rows.Count; i++)
            {
                //add the student name into auto complete collection
                collection.Add(cndt.Rows[i]["fullname"].ToString());
            }

            txtdaryaft_az.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtdaryaft_az.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtdaryaft_az.AutoCompleteCustomSource = collection;

            txttahvil_be.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txttahvil_be.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txttahvil_be.AutoCompleteCustomSource = collection;

            anbar an = new anbar();
            DataTable andt = an.Search("SELECT daru_name FROM anbar");

            AutoCompleteStringCollection darucollection = new AutoCompleteStringCollection();
            for (int i = 0; i < andt.Rows.Count; i++)
            {
                //add the student name into auto complete collection
                txtdaru_name.Items.Add(andt.Rows[i]["daru_name"].ToString());
            }

        }

      
        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from daru where ";
                check = false;

                if (txtid.Text != "")
                {
                    SQL = SQL + "id=" + txtid.Text.Trim() + "AND ";
                    check = true;
                }

                if (txtdaryaft_az.Text != "")
                {
                    SQL = SQL + "daryaft_az like '%" + txtdaryaft_az.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtfrom_date.MaskCompleted)
                {
                    SQL = SQL + "daru_date>='" + txtfrom_date.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    SQL = SQL + "daru_date<='" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttahvil_be.Text != "")
                {
                    SQL = SQL + "tahvil_be like '%" + txttahvil_be.Text.Trim() + "%'AND ";
                    check = true;
                }
                
                if (txtdaru_name.SelectedIndex > 0)
                {
                    SQL = SQL + "daru_name like '%" + txtdaru_name.Text.Trim() + "%'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);
                }

                daru rm = new daru();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

                long sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum += Convert.ToInt64(dt.Rows[i]["fee_kol"]);
                }
                txtsum.Visible = true;
                txtsum.Text = sum.ToString("N0");

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtid.Text = "";
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmDaruView_Activated(object sender, EventArgs e)
        {
            if (btnfilter.Enabled == false)
            {
                daru pm = new daru();
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

                daru dar = new daru();
                dar.id = int.Parse(val);
                dar.Delete();

                daru pm = new daru();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    btnedit.Enabled = false;
                    btndel.Enabled = false;
                }
                else
                {
                    btnedit.Enabled = true;
                    btndel.Enabled = true;
                }
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtdaryaft_az.Text == "" && !txtfrom_date.MaskCompleted && !txttodate.MaskCompleted && txttahvil_be.Text == "" && txtdaru_name.SelectedIndex == 0)
            {
                btnfilter.Enabled = false;

                daru pm = new daru();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                txtsum.Visible = false;
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
            frmDaruInp fsi = new frmDaruInp();
            fsi.cur_date = this.cur_date;
            fsi.ShowDialog();

            daru pm = new daru();
            DataTable dt = new DataTable();
            dt = pm.Select();
            grdDataViewer.DataSource = dt;


            if (dt.Rows.Count == 0)
            {
                btnedit.Enabled = false;
                btndel.Enabled = false;
            }
            else
            {
                btnedit.Enabled = true;
                btndel.Enabled = true;
            }     
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[col, row].Value.ToString();

                daru si = new daru();
                DataTable datat = new DataTable();
                si.id = int.Parse(val);

                datat = si.Selectforedit();

                frmDaruEdit fse = new frmDaruEdit();

                fse.txtid.Text = val;
                fse.idsearch_Click(null,null);
                fse.ShowDialog();

                daru pm = new daru();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
                
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

            frmDaruPrintViewer fsgpv = new frmDaruPrintViewer();
            fsgpv.filler = (DataTable)(grdDataViewer.DataSource);
            fsgpv.ShowDialog();
            
        }
    }
}