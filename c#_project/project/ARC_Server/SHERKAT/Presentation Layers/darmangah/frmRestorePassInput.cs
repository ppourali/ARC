using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmRestorePassInput : Form
    {
        public int position;
        string path;
        public bool restoreAdvance;

        public frmRestorePassInput(string p)
        {
            InitializeComponent();
            this.path = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string mediaPassWord = "";
            if (chkSameAsCurrent.Checked)
                mediaPassWord = txtBackupPass.Text;
            else
                mediaPassWord = txtpass.Text;


            try
            {
                Darmangah da = new Darmangah();
                DataTable dt = da.Select();

                string pass = dt.Rows[0]["Gen_Pass"].ToString();

                if (txtpass.Text.Equals(pass))
                {

                    DB rest = new DB();
                    DataTable dtRestHeaders = new DataTable();
                    rest.Backup_name = path;
                    if (restoreAdvance == false)
                    {
                        dtRestHeaders = rest.restoreheader(mediaPassWord);
                        rest.fn = dtRestHeaders.Rows.Count;
                        rest.Restore(mediaPassWord);
                        MessageBox.Show("بازیابی فایل پشتیبان با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dtRestHeaders = rest.restoreheader(mediaPassWord);

                        frmBackupView fbv = new frmBackupView();
                        fbv.bname = path;
                        fbv.grddt = dtRestHeaders;
                        fbv.mp = mediaPassWord;
                        fbv.ShowDialog();
                    }
                    

                   
                    this.Close();
                }
                else
                {
                    MessageBox.Show("رمز امنیتی مرکز صحیح نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpass.SelectAll();
                    txtpass.Focus();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("بازیابی فایل پشتیبان با مشکل مواجه شد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void txtidno_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text == "" || (chkSameAsCurrent.Checked && txtBackupPass.Text==""))
                button1.Enabled = false;
            else
                button1.Enabled = true;

        }

        private void frmRestorePassInput_Load(object sender, EventArgs e)
        {
            txtpass.Text = "";
            txtBackupPass.Text = "";
            txtBackupPass.Enabled = false;
            chkSameAsCurrent.Checked = false;
        }

        private void chkSameAsCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSameAsCurrent.Checked)
            {
                txtBackupPass.Enabled = true;
            }
            else
            {
                txtBackupPass.Enabled = false;
            }
            if (txtpass.Text == "" || (chkSameAsCurrent.Checked && txtBackupPass.Text == ""))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void Enter_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.Yellow;
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }
        }

        private void Leave_Action(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.White;
            }
        }
    }
}