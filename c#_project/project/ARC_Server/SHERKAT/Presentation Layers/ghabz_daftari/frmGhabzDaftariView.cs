using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmGhabzDaftariView : Form
    {
        public frmGhabzDaftariView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmGhabzDaftariView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            //ghabz ml = new ghabz();
            //DataTable dt = new DataTable();
            //dt = ml.Select();

            checkBox1.Checked = true;
            btnfilter.PerformClick();

            //grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "ردیف", "شماره قبض", "شماره پرونده", "نام و نام خانوادگی", "مبلغ هزینه", "مبلغ دریافتی", "شرح", "تاریخ" };
            int[] col_width = { 60, 80, 80, 160, 80, 80, 110, 90 };

            for (int i = 0; i < col_headers.Length; i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.BackColor = Color.LightBlue;
            dataGridViewCellStyle1.Font = new Font("tahoma", 8, FontStyle.Bold);
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            grdDataViewer.Columns["mablagh"].DefaultCellStyle = dataGridViewCellStyle1;
            grdDataViewer.Columns["paid"].DefaultCellStyle = dataGridViewCellStyle1;

        }


        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select row_number() over (order by ghabz_id DESC) as rowid ,* from ghabz_daftari where ";
                check = false;


                if (txtghabz_id.Text != "")
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "ghabz_id=N'" + txtghabz_id.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtid.Text != "")
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "id=N'" + txtid.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtname.Text != "")
                {
                    SQL = SQL + "name like N'%" + txtname.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtmos_date.MaskCompleted)
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "date>=N'" + txtmos_date.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (checkBox1.Checked)
                {
                    SQL = SQL + "date=N'" + cur_date.Trim() + "'AND ";
                    check = true;
                }

                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);
                }

                ghabz_daftari rm = new ghabz_daftari();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

                long sum = 0, sumpaid=0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum += Convert.ToInt64(dt.Rows[i]["mablagh"]); 
                    sumpaid += Convert.ToInt64(dt.Rows[i]["paid"]);
                }
                txtsummablagh.Visible = true;
                txtsumpaid.Visible = true;
                pictureBox1.Visible = true;
                txtsummablagh.Text = sum.ToString("N0");
                txtsumpaid.Text = sumpaid.ToString("N0");

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtghabz_id.Text = "";
            }
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtghabz_id.Text == "" && txtid.Text == "" && txtname.Text == "" && !txtmos_date.MaskCompleted && !txttodate.MaskCompleted && !checkBox1.Checked)
            {
                btnfilter.Enabled = false;

                ghabz_daftari pm = new ghabz_daftari();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                txtsummablagh.Text = "";
                txtsumpaid.Text = "";
                pictureBox1.Visible = false;
                txtsummablagh.Visible = false;
                txtsumpaid.Visible = false;
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
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void Validating_Action(object sender, CancelEventArgs e)
        {
            if (txtghabz_id.Text.Trim() != "")
                txtghabz_id.Text = string.Format("{0:000000}", Convert.ToDecimal(txtghabz_id.Text));
            
            if (txtid.Text.Trim() != "")
                txtid.Text = string.Format("{0:0000}", Convert.ToDecimal(txtid.Text));
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmGhabzDaftariDaryaft fgd = new frmGhabzDaftariDaryaft();
            fgd.cur_date = this.cur_date;
            fgd.MdiParent = this.MdiParent;
            fgd.Show();

            if (btnfilter.Enabled == true)
            {
                btnfilter.PerformClick();
            }
            else
            {
                ghabz_daftari pm = new ghabz_daftari();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            frmGhabz_koliPrintViewer fgkpv = new frmGhabz_koliPrintViewer();
            fgkpv.filler = (DataTable)(grdDataViewer.DataSource);
            fgkpv.Show();
        }

        private void btndel_Click(object sender, EventArgs e)
        {

        }

        private void btndel_Click_1(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف این قبض اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                //int icol = 0;
                int irow = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["ghabz_id", irow].Value.ToString();
                string id = grdDataViewer["id", irow].Value.ToString();
                string mab = grdDataViewer["mablagh", irow].Value.ToString();
                string pay = grdDataViewer["paid", irow].Value.ToString();

                ghabz_daftari gha = new ghabz_daftari();
                gha.ghabz_id = val;
                gha.Delete();

                sick_history_daftari sh = new sick_history_daftari();
                sh.ghabz_id = val;
                sh.sick_id = grdDataViewer["id", irow].Value.ToString();
                sh.Delete();


                if (btnfilter.Enabled == true)
                {
                    btnfilter.PerformClick();
                }
                else
                {
                    ghabz_daftari pm = new ghabz_daftari();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdDataViewer.DataSource = dt;
                }
            }
        }


        private void btnedit_Click_1(object sender, EventArgs e)
        {
            //frmEditPassInput fad = new frmEditPassInput();
            //if (fad.ShowDialog() != DialogResult.Abort)
            //{
            if (grdDataViewer.CurrentRow != null)
            {
                //int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer["ghabz_id", row].Value.ToString();

                frmGhabzDaftariEslah fge = new frmGhabzDaftariEslah();

                fge.txtghabz_id.Text = val;
                fge.idsearch_Click(null, null);
                fge.ShowDialog();


                if (btnfilter.Enabled == true)
                {
                    btnfilter.PerformClick();
                }
                else
                {
                    ghabz_daftari pm = new ghabz_daftari();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdDataViewer.DataSource = dt;
                }
                grdDataViewer.CurrentCell = grdDataViewer[0, row];
                //}
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                frmSickDaftariHisView fsh = new frmSickDaftariHisView();
                fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                fsh.sabegheh = true;
                fsh.Show();
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
                btnsabegheh.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}