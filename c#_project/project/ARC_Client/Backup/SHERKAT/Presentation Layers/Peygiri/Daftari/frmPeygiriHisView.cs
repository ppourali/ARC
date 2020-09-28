using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmPeygiriHisView : Form
    {
        public frmPeygiriHisView()
        {
            InitializeComponent();
        }

        public string cur_date;
        public bool sabegheh = false;

        private void frmPeygiriHisView_Load(object sender, EventArgs e)
        {
            groupBox1.Focus();
            txtid.Focus();
            txtid.SelectAll();

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            dataGridView1.AutoGenerateColumns = true;

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            

            if (sabegheh == true)
            {
                btnfilter.PerformClick();
                txtname.Enabled = false;
                txtid.Enabled = false;
                btnedit.Enabled = false;
                btnadd.Enabled = false;
            }
            else
            {
                Sicks si = new Sicks();
                DataTable dtname = new DataTable();
                dtname = si.Search("SELECT id,name FROM sicks");
                txtname.DataSource = dtname;
                txtname.DisplayMember = "name";
                txtname.ValueMember = "name";
                txtid.DataBindings.Clear();
                txtid.DataBindings.Add("Text", dtname, "id");

                peygiri pm = new peygiri();
                DataTable dt = new DataTable();
                dt = pm.Select();
                dataGridView1.DataSource = dt;
            }

            ///////////////////////////////////////////////////////////////////
            dataGridView1.Columns[0].HeaderText = "مشخصه";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].HeaderText = "شماره پرونده";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "نام بیمار";
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].HeaderText = "شماره پیگیری";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].HeaderText = "شروع درمان";
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].HeaderText = "تاریخ";
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].HeaderText = "شرح پیگیری";
            dataGridView1.Columns[6].Width = 302;
            dataGridView1.Columns[7].HeaderText = "نتیجه گیری";
            dataGridView1.Columns[7].Width = 100;


            if (dataGridView1.Rows.Count > 0)
            {
                btnedit.Enabled = true;
                btndel.Enabled = true;
                btnprint.Enabled = true;
            }
            else if (dataGridView1.Rows.Count == 0)
            {
                btnedit.Enabled = false;
                btndel.Enabled = false;
                btnprint.Enabled = false;
            }

           
        }
        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from peygiri where ";
                check = false;


                if (txtid.Text != "")
                {
                    SQL = SQL + "sick_id=N'" + txtid.Text.Trim() + "'AND ";
                    check = true;
                }


                if (txtfrom_date.MaskCompleted)
                {
                    SQL = SQL + "date>=N'" + txtfrom_date.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    SQL = SQL + "date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4) + " ORDER BY date DESC";
                }

                peygiri peyh = new peygiri();
                DataTable dt = new DataTable();
                dt = peyh.Search(SQL);
                dataGridView1.DataSource = dt;
                
            }

            catch (Exception)
            {
                MessageBox.Show("اطلاعاتی موجود نمی باشد!!!");
                txtid.Text = "";
            }

        }

        private void addbtnTextChanged(object sender, EventArgs e)
        {
            if (txtname.Text == "" && sender==txtname)
            {
                txtid.Text = "";
            }

            if (txtid.Text == "" && txtname.Text == "" && !txtfrom_date.MaskCompleted && !txttodate.MaskCompleted)
            {
                btnfilter.Enabled = false;

                peygiri  pm = new peygiri();
                DataTable dt = new DataTable();
                dt = pm.Select();
                dataGridView1.DataSource = dt;
            }
            else
            {
                btnfilter.Enabled = true;
            }
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtid_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int col = 0;
                int row = dataGridView1.CurrentRow.Index;
                string val = dataGridView1[col, row].Value.ToString();

                frmPeygiriEdit fde = new frmPeygiriEdit();
                fde.txtcode.Text = val;
                //fde.idsearch_Click(null, null);
                fde.ShowDialog();

                btnfilter.PerformClick();

            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmPeygiriInp fdi = new frmPeygiriInp();
            fdi.cur_date = this.cur_date;
            fdi.ShowDialog();

            btnfilter.PerformClick();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            frmPeygiriPrintViewer fgkpv = new frmPeygiriPrintViewer();
            fgkpv.filler = (DataTable)(dataGridView1.DataSource);
            fgkpv.Show();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف پیگیری اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int icol = 0;
                int irow = dataGridView1.CurrentRow.Index;
                string val = dataGridView1[icol, irow].Value.ToString();

                peygiri das = new peygiri();
                das.code = long.Parse(val);
                das.sick_id = dataGridView1["sick_id", irow].Value.ToString(); 
                das.Delete();

                btnfilter.PerformClick();
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
            else if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Yellow;
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
            else if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Transparent;
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