using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmAction_LogsView : Form
    {
        public frmAction_LogsView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmAction_LogsView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            //action_logs al = new action_logs();
            //DataTable dt = new DataTable();
            //dt = al.Select();

            checkBox1.Checked = true;
            btnfilter.PerformClick();

            //grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = {"شرح عملیات", "کد کاربر", "نام و نام خانوادگی", "تاریخ", "ساعت" };
            int[] col_width = {355, 70, 120, 70, 70 };

            for (int i = 0; i < col_headers.Length; i++)
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

                string SQL = "select * from action_logs where ";
                check = false;


                if (txtuser_code.Text != "")
                {
                    SQL = SQL + "user_code=N'" + txtuser_code.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtuser_name.Text != "")
                {
                    SQL = SQL + "user_name like N'%" + txtuser_name.Text.Trim() + "%'AND ";
                    check = true;
                }
                if (txtsharh.Text != "")
                {
                    SQL = SQL + "sharh like N'%" + txtsharh.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtfromdate.MaskCompleted)
                {
                    checkBox1.Checked = false;
                    SQL = SQL + "date>=N'" + txtfromdate.Text.Trim() + "'AND ";
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
                    SQL = SQL.Remove(SQL.Length - 4)+" order by date desc, time desc";
                }

                action_logs rm = new action_logs();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtfromdate.Focus();
            }
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtuser_code.Text == "" && txtuser_name.Text == "" && txtsharh.Text == "" && !txtfromdate.MaskCompleted && !txttodate.MaskCompleted && !checkBox1.Checked)
            {
                btnfilter.Enabled = false;

                action_logs pm = new action_logs();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtuser_code.Text == "" && txtuser_name.Text == "" && txtsharh.Text == "" && !txtfromdate.MaskCompleted && !txttodate.MaskCompleted && !checkBox1.Checked)
            {
                btnfilter.Enabled = false;

                action_logs pm = new action_logs();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }
            else
            {
                btnfilter.Enabled = true;
            }
        }

        private void cmddel_Click(object sender, EventArgs e)
        {

            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف تمامی تاریخچه ی ریز عملیات کاربران اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            if (dr == DialogResult.Yes)
            {
                action_logs al = new action_logs();
                al.DeleteAll();

                action_logs pm = new action_logs();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;
            }

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            frmActionLogsPrintViewer fd = new frmActionLogsPrintViewer();
            fd.filler = (DataTable)(grdDataViewer.DataSource);
            fd.Show();

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
                cmddel.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

    }
}