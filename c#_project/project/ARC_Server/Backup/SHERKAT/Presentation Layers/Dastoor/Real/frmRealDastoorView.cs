using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmRealDastoorView : Form
    {
        public frmRealDastoorView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmRealDastoorView_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            comboBox1.SelectedIndex = 0;

            checkBox1.Checked = true;
            btnfilter.PerformClick();

            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "مشخصه", "شماره پرونده", "نام بیمار", "دکتر معالج", "شروع درمان", "تاریخ دستور", "شرح دستور", "آزمایش مربوطه" };
            int[] col_width = { 60, 100, 110, 90, 80, 80, 220, 70 };

            for (int i=0; i<col_headers.Length;i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }
            
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;      
        }

      
        private void btnfilter_Click(object sender, EventArgs e)
        {
            
            try
            {
                Boolean check = false;

                string SQL = "select * from dastoor_pezeshk_real where ";
                check = false;


                if (txtid.Text != "")
                {
                    SQL = SQL + "sick_id=N'" + txtid.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtname.Text != "")
                {
                    SQL = SQL + "name like N'%" + txtname.Text.Trim() + "%'AND ";
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

                if (checkBox1.Checked)
                {
                    SQL = SQL + "(sick_id in (select id from sicks where (len(payan_date)!=10)))AND ";
                    check = true;
                }
                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4)+" ORDER BY Code DESC";
                }

                dastoor_pezeshk_real tk=new dastoor_pezeshk_real();
                DataTable dt = new DataTable();
                dt = tk.Search(SQL);
                grdDataViewer.DataSource = dt;
               
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


        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف دستور اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int icol = 0;
                int irow = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[icol, irow].Value.ToString();

                dastoor_pezeshk_real das = new dastoor_pezeshk_real();
                das.code = long.Parse(val);
                das.sick_id = grdDataViewer["sick_id", irow].Value.ToString();
                das.Delete();

                btnfilter.PerformClick();
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text == "" && !txtdate.MaskCompleted && !txttodate.MaskCompleted && !checkBox1.Checked)
            {
                btnfilter.Enabled = false;

                dastoor_pezeshk_real tk = new dastoor_pezeshk_real();
                DataTable dt = new DataTable();
                dt = tk.Select();
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

        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            frmRealdastoor_pezeshkInp fdi = new frmRealdastoor_pezeshkInp();
            fdi.cur_date = this.cur_date;
            fdi.ShowDialog();

            btnfilter.PerformClick();
        }

       

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    DataTable ids = new DataTable();
                    ids.Columns.Add("id");

                    foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                    {
                        if (ids.Select("id='" + dgvr.Cells["sick_id"].Value.ToString() + "'").Length == 0)
                            ids.Rows.Add(new object[] { dgvr.Cells["sick_id"].Value.ToString() });
                    }
                    frmSicksDastoorPrintViewer fd = new frmSicksDastoorPrintViewer();
                    fd.cur_date = cur_date;
                    fd.idtable = ids;
                    fd.Show();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    frmDastoorPrintViewer fgkpv = new frmDastoorPrintViewer();
                    fgkpv.filler = (DataTable)(grdDataViewer.DataSource);
                    fgkpv.Show();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    DataTable ids = new DataTable();
                    ids.Columns.Add("id");

                    DataTable idsandcodes = new DataTable();
                    idsandcodes.Columns.Add("id");
                    idsandcodes.Columns.Add("code");

                    foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                    {
                        if (ids.Select("id='" + dgvr.Cells["sick_id"].Value.ToString() + "'").Length == 0)
                            ids.Rows.Add(new object[] { dgvr.Cells["sick_id"].Value.ToString() });

                        idsandcodes.Rows.Add(new object[] { dgvr.Cells["sick_id"].Value.ToString(), dgvr.Cells["code"].Value.ToString() });
                    }

                    frmDastoorOnLinePrintViewer fd = new frmDastoorOnLinePrintViewer();
                    fd.RealOrNot = true;
                    fd.idtable = ids;
                    fd.idandcodestable = idsandcodes;
                    fd.Show();
                }
            }
        }

        private void txtid_Validating(object sender, CancelEventArgs e)
        {

        }


        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[col, row].Value.ToString();

                frmRealdastoor_pezeshkEdit fde = new frmRealdastoor_pezeshkEdit();
                fde.txtcode.Text = val;
                //fde.idsearch_Click(null, null);
                fde.ShowDialog();

                btnfilter.PerformClick();

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
            else if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRealDastoorHisView fsh = new frmRealDastoorHisView();
            int irow = grdDataViewer.CurrentRow.Index;
            fsh.sid = grdDataViewer["sick_id", irow].Value.ToString();
            fsh.cur_date = this.cur_date;
            fsh.name = grdDataViewer["name", irow].Value.ToString(); 
            fsh.ShowDialog();
        }

        private void frmRealDastoorView_Shown(object sender, EventArgs e)
        {
            // Create the list to use as the custom source. 
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            Sicks ac = new Sicks();
            DataTable sickdt = new DataTable();
            sickdt = ac.Search("SELECT name FROM sicks WHERE (len(payan_date)!=10)");
            foreach (DataRow dtrow in sickdt.Rows)
                source.Add(dtrow["name"].ToString().Trim());

            // Create and initialize the text box.
            txtname.AutoCompleteCustomSource = source;
            txtname.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtname.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void grdDataViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (grdDataViewer["sick_id", e.RowIndex].Value != null)
                {
                    txtid.Text = grdDataViewer["sick_id", e.RowIndex].Value.ToString();
                    btnfilter.PerformClick();
                }
            }
        }
       
    }
}