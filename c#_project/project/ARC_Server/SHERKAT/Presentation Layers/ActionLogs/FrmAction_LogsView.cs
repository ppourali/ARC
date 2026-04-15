using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmAction_LogsView : Form
    {
        public FrmAction_LogsView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void FrmAction_LogsView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            chkCurrentDate.Checked = true;
            btnSearch.PerformClick();

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


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from action_logs where ";
                check = false;


                if (txtUserCode.Text != "")
                {
                    SQL = SQL + "user_code=N'" + txtUserCode.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtUserName.Text != "")
                {
                    SQL = SQL + "user_name like N'%" + txtUserName.Text.Trim() + "%'AND ";
                    check = true;
                }
                if (txtDescription.Text != "")
                {
                    SQL = SQL + "sharh like N'%" + txtDescription.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtFromDate.MaskCompleted)
                {
                    chkCurrentDate.Checked = false;
                    SQL = SQL + "date>=N'" + txtFromDate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtToDate.MaskCompleted)
                {
                    chkCurrentDate.Checked = false;
                    SQL = SQL + "date<=N'" + txtToDate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (chkCurrentDate.Checked)
                {
                    SQL = SQL + "date=N'" + cur_date.Trim() + "'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4)+" order by date desc, time desc";
                }

                ActionLogs action_logs = new ActionLogs();
                DataTable dt = new DataTable();
                dt = action_logs.Search(SQL);
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtFromDate.Focus();
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtUserCode.Text == "" && txtUserName.Text == "" && txtDescription.Text == "" && !txtFromDate.MaskCompleted && !txtToDate.MaskCompleted && !chkCurrentDate.Checked)
            {
                btnSearch.Enabled = false;

                ActionLogs action_logs = new ActionLogs();
                DataTable dt = new DataTable();
                dt = action_logs.Select();
                grdDataViewer.DataSource = dt;
            }
            else
            {
                btnSearch.Enabled = true;
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

        private void ChkCurrentDate_CheckedChanged(object sender, EventArgs e)
        {
            if (txtUserCode.Text == "" && txtUserName.Text == "" && txtDescription.Text == "" && !txtFromDate.MaskCompleted && !txtToDate.MaskCompleted && !chkCurrentDate.Checked)
            {
                btnSearch.Enabled = false;

                ActionLogs action_logs = new ActionLogs();
                DataTable dt = new DataTable();
                dt = action_logs.Select();
                grdDataViewer.DataSource = dt;
            }
            else
            {
                btnSearch.Enabled = true;
            }
        }

        private void BtnDeleteAll_Click(object sender, EventArgs e)
        {

            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف تمامی تاریخچه ی ریز عملیات کاربران اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            if (dr == DialogResult.Yes)
            {
                ActionLogs action_logs = new ActionLogs();
                action_logs.DeleteAll();

                DataTable dt = new DataTable();
                dt = action_logs.Select();
                grdDataViewer.DataSource = dt;
            }

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            FrmActionLogsPrintViewer fd = new FrmActionLogsPrintViewer();
            fd.filler = (DataTable)(grdDataViewer.DataSource);
            fd.Show();

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnPrint.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                btnDeleteAll.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

    }
}