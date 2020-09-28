using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmBlackListView : Form
    {
        public frmBlackListView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmBlackListView_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Sicks si = new Sicks();
            DataTable dt = new DataTable();
            dt = si.SelectForBlackList();

            black_list bl = new black_list();
            DataTable dt_bl = new DataTable();
            dt_bl = bl.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "شماره پرونده", "نام و نام خانوادگی", "نام پدر" };
            int[] col_width = { 100, 100, 78 };

            for (int i = 0; i < col_headers.Length; i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }

            grdBlackListDataViewer.DataSource = dt_bl;
            grdBlackListDataViewer.AutoGenerateColumns = true;

            string[] col_headers_bl = { "مشخصه", "شماره پرونده", "نام و نام خانوادگی", "شرح" };
            int[] col_width_bl = { 60, 100, 100, 145 };

            for (int i = 0; i < col_headers_bl.Length; i++)
            {
                grdBlackListDataViewer.Columns[i].HeaderText = col_headers_bl[i].ToString();
                grdBlackListDataViewer.Columns[i].Width = col_width_bl[i];
            }

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            DataGridViewCellStyle objAlternatingCellStyle_bl = new DataGridViewCellStyle();
            objAlternatingCellStyle_bl.BackColor = Color.Pink;
            grdBlackListDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle_bl;

        }


        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select id, name, father_name from Sicks where ";
                check = false;


                if (txtid.Text != "")
                {
                    SQL = SQL + "id=N'" + txtid.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtname.Text != "")
                {
                    SQL = SQL + "name like N'%" + txtname.Text.Trim() + "%'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4)+" and (len(payan_date))!=10";
                }

                Sicks rm = new Sicks();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
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


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text == "")
            {
                btnfilter.Enabled = false;

                Sicks pm = new Sicks();
                DataTable dt = new DataTable();
                dt = pm.SelectForBlackList();
                grdDataViewer.DataSource = dt;
            }
            else
            {
                btnfilter.Enabled = true;
            }

            if (txtid_BL.Text == "" && txtname_BL.Text == "")
            {
                btnFilterForBlackList.Enabled = false;

                black_list pm = new black_list();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdBlackListDataViewer.DataSource = dt;
            }
            else
            {
                btnFilterForBlackList.Enabled = true;
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


        private void Validating_Action(object sender, CancelEventArgs e)
        {

        }



        private void btnprint_Click(object sender, EventArgs e)
        {

            frmBlackListPrintViewer fd = new frmBlackListPrintViewer();
            fd.filler = (DataTable)(grdBlackListDataViewer.DataSource);
            fd.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmSabeghehView frtv = new frmSabeghehView();
                frtv.id = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                frtv.tahORtaj = true;
                frtv.ShowDialog();
            }
        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmSickHisView fsh = new frmSickHisView();
                fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                fsh.sabegheh = true;
                fsh.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            otherSubject.Enabled = checkBox5.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
            {
                black_list bl = new black_list();
                bl.id = dgvr.Cells["id"].Value.ToString();
                bl.name = dgvr.Cells["name"].Value.ToString();
                if (checkBox1.Checked)
                {
                    bl.sharh = checkBox1.Text;
                    bl.Add();
                }
                if (checkBox2.Checked)
                {
                    bl.sharh = checkBox2.Text;
                    bl.Add();
                }
                if (checkBox3.Checked)
                {
                    bl.sharh = checkBox3.Text;
                    bl.Add();
                }
                if (checkBox4.Checked)
                {
                    bl.sharh = checkBox4.Text;
                    bl.Add();
                }
                if (checkBox5.Checked)
                {
                    bl.sharh = otherSubject.Text;
                    bl.Add();
                }
            }

            if (btnFilterForBlackList.Enabled)
                btnFilterForBlackList.PerformClick();
            else
            {
                black_list pm = new black_list();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdBlackListDataViewer.DataSource = dt;
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmRealAzmayeshHisView fsh = new frmRealAzmayeshHisView();
                fsh.sid = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                fsh.cur_date = this.cur_date;
                fsh.name = (grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                fsh.ShowDialog();
            }
        }

        private void btndel_Click_1(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از خروج بیماران از لیست سیاه اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow dgvr in grdBlackListDataViewer.SelectedRows)
                {
                    black_list bl = new black_list();
                    bl.radif = long.Parse(dgvr.Cells["radif"].Value.ToString());
                    bl.Delete();
                }

                if (btnFilterForBlackList.Enabled)
                    btnFilterForBlackList.PerformClick();
                else
                {
                    black_list pm = new black_list();
                    DataTable dt = new DataTable();
                    dt = pm.Select();
                    grdBlackListDataViewer.DataSource = dt;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmRealRavanshenasHisView fsh = new frmRealRavanshenasHisView();
                fsh.sid = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                fsh.cur_date = this.cur_date;
                fsh.name = (grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                fsh.ShowDialog();
            }
        }

        private void btnFilterForBlackList_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from BLACK_LIST where ";
                check = false;


                if (txtid_BL.Text != "")
                {
                    SQL = SQL + "id=N'" + txtid_BL.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtname_BL.Text != "")
                {
                    SQL = SQL + "name like N'%" + txtname_BL.Text.Trim() + "%'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);
                }

                black_list rm = new black_list();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdBlackListDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtid_BL.Text = "";
            }
        }

        private void grdDataViewer_SelectionChanged(object sender, EventArgs e)
        {
            lbltedad.Text = grdDataViewer.SelectedRows.Count.ToString();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

    }
}