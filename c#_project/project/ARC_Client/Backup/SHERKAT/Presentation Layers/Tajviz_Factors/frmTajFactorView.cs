using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmTajFactorView : Form
    {
        public frmTajFactorView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmTajFactorView_Load(object sender, EventArgs e)
        {

            tajviz_anbar an = new tajviz_anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select distinct daru_name from tajviz_anbar");

            txtdaru_name.Items.Add("همه"); 
            foreach (DataRow dr in combosource.Rows)
                txtdaru_name.Items.Add(dr[0].ToString());
            
            txtdaru_name.SelectedIndex = 0;

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            tajviz_factors fa = new tajviz_factors();
            DataTable dt = new DataTable();
            dt = fa.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "مشخصه", "شماره فاکتور", "تاریخ فاکتور", "نام دارو", "تعداد", "مبلغ واحد", "مبلغ کل", "قیمت مصرف کننده", "توضیحات" };
            int[] col_width = { 60, 80, 90, 130, 80, 80, 80, 100, 150 };

            for (int i=0; i<col_headers.Length;i++)
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
            grdDataViewer.Columns["masraf_price"].DefaultCellStyle = dataGridViewCellStyle1;
        }

      
        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from tajviz_Factors where ";
                check = false;


                if (txtfactor_no.Text != "")
                {
                    SQL = SQL + "factor_no=N'" + txtfactor_no.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtdate.MaskCompleted)
                {
                    SQL = SQL + "date>=N'" + txtdate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    SQL = SQL + "date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtcomments.Text != "")
                {
                    SQL = SQL + "comments like N'%" + txtcomments.Text.Trim() + "%'AND ";
                    check = true;
                } 
                
                if (txtdaru_name.SelectedIndex > 0)
                {
                    SQL = SQL + "daru_name = N'" + txtdaru_name.Text.Trim() + "'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4) + " order by code desc";
                }

                tajviz_factors rm = new tajviz_factors();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtfactor_no.Text = "";
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmTajFactorView_Activated(object sender, EventArgs e)
        {
            if (btnfilter.Enabled == true)
            {
                btnfilter.PerformClick();
            }
            else
            {
                tajviz_factors pm = new tajviz_factors();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف این سطر از فاکتور اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int irow = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["code", irow].Value.ToString();

                tajviz_factors fac = new tajviz_factors();
                fac.code = long.Parse(val);
                fac.Delete();

                // Updating the Data to the DataBase Anbar
                tajviz_anbar an = new tajviz_anbar();
                an.mandeh = -float.Parse( grdDataViewer["tedad", irow].Value.ToString());
                an.daru_name =  grdDataViewer["daru_name", irow].Value.ToString();
                an.UpdateAfterFactor();
                // End of Updating Data to the DataBase

                if (btnfilter.Enabled == true)
                {
                    btnfilter.PerformClick();
                }
                else
                {
                    tajviz_factors pm = new tajviz_factors();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdDataViewer.DataSource = dt;
                }
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtfactor_no.Text == "" && !txtdate.MaskCompleted && !txttodate.MaskCompleted && txtdaru_name.SelectedIndex == 0 && txtcomments.Text.Trim()=="")
            {
                btnfilter.Enabled = false;

                tajviz_factors pm = new tajviz_factors();
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


        private void btnadd_Click(object sender, EventArgs e)
        {
            frmTajFactorInp ffi = new frmTajFactorInp();
            ffi.MdiParent = this.MdiParent;
            ffi.Show();

            if (btnfilter.Enabled == true)
            {
                btnfilter.PerformClick();
            }
            else
            {
                tajviz_factors pm = new tajviz_factors();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
            
        }

        //private void btnedit_Click(object sender, EventArgs e)
        //{
        //    if (grdDataViewer.CurrentRow != null)
        //    {
        //        int col = 0;
        //        int row = grdDataViewer.CurrentRow.Index;
        //        string val = grdDataViewer[col, row].Value.ToString();

        //        factors fa = new factors();
        //        DataTable datat = new DataTable();
        //        fa.factor_no = val;

        //        datat = fa.Selectforedit();

        //        frmSicksEdit fse = new frmSicksEdit();

        //        fse.txtid.Text = val;
        //        fse.idsearch_Click(null,null);
        //        fse.ShowDialog();

        //        Sicks pm = new Sicks();
        //        DataTable dt = new DataTable();
        //        dt = pm.Select();
        //        grdDataViewer.DataSource = dt;
                
        //    }
        //}

        private void btnprint_Click(object sender, EventArgs e)
        {
        }

        private void btnprint_Click_1(object sender, EventArgs e)
        {
            frmFactorPrintViewer fgkpv = new frmFactorPrintViewer();
            fgkpv.filler = (DataTable)(grdDataViewer.DataSource);
            fgkpv.Show();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["code", row].Value.ToString();

                frmTajFactorEdit fse = new frmTajFactorEdit();

                fse.txtcode.Text = val;
                fse.first_tedad = float.Parse(grdDataViewer["tedad", row].Value.ToString());
                fse.first_daru_name = grdDataViewer["daru_name", row].Value.ToString();
                fse.idsearch_Click();
                fse.ShowDialog();

                if (btnfilter.Enabled == true)
                {
                    btnfilter.PerformClick();
                }
                else
                {
                    tajviz_factors pm = new tajviz_factors();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdDataViewer.DataSource = dt;
                }

            }

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                btndel.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
            {
                btnedit.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}