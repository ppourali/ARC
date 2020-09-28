using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoTahvil.Presentation_Layers
{
    public partial class frmAbsentSicksView : Form
    {
        public frmAbsentSicksView()
        {
            InitializeComponent();
        }


        public string cur_date;
        DataTable dt = new DataTable();

        private void frmAbsentSicksView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Sicks si = new Sicks();

            dt = si.Select().Clone();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "شماره پرونده", "شروع درمان", "پایان درمان", "نام و نام خانوادگی", "نام پدر", "سن", "شهر", "شماره شناسنامه", "جنسیت", "تلفن منزل", "تلفن همراه", "مخدر مصرفی", "روش  ترک", "آدرس", "هزینه روزانه", "مانده حساب", "وضعیت حساب" };
            int[] col_width = { 70, 70, 70, 130, 80, 40, 50, 80, 50, 80, 80, 100, 135, 120, 70, 70, 70 };

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
            grdDataViewer.Columns["roozaneh"].DefaultCellStyle = dataGridViewCellStyle1;
            grdDataViewer.Columns["hesab"].DefaultCellStyle = dataGridViewCellStyle1;

            txtdate.Text = cur_date;
            btnfilter.PerformClick();
        }


        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Sicks rm = new Sicks();
                DataTable dt = new DataTable();
                dt = rm.Search("SELECT * FROM SICKS WHERE ((payan_date>N'" + txtdate.Text + "' or payan_date='13  /  /') and id not in(SELECT id FROM TAHVIL WHERE DATE=N'" + txtdate.Text + "'))");
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtdate.Text = "";
            }
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (!txtdate.MaskCompleted)
            {
                btnfilter.Enabled = false;
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

            else if (sender.GetType() == typeof(System.Windows.Forms.MaskedTextBox))
            {
                ((System.Windows.Forms.MaskedTextBox)sender).BackColor = Color.Yellow;
                ((System.Windows.Forms.MaskedTextBox)sender).Focus();
                ((System.Windows.Forms.MaskedTextBox)sender).SelectAll();
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

            else if (sender.GetType() == typeof(System.Windows.Forms.MaskedTextBox))
            {
                ((System.Windows.Forms.MaskedTextBox)sender).BackColor = Color.White;
            }

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void btnprint_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                grdDataViewer.Focus();
                //int cr = grdDataViewer.CurrentRow.Index;
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmTahvilInput))
                    {
                        IsOpen = true;
                        ((frmTahvilInput)f).cur_date = txtdate.Text;
                        f.Focus();
                        ((frmTahvilInput)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmTahvilInput)f).txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmTahvilInput)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {

                    frmTahvilInput fsh = new frmTahvilInput();
                    fsh.sentbyadamview = true;
                    fsh.cur_date = txtdate.Text;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }


                //grdDataViewer.Rows[cr].Selected = true;

            }
        }

        private void grdDataViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.PerformClick();
        }

        private void grdDataViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button2.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void frmAbsentSicksView_Activated(object sender, EventArgs e)
        {
            btnfilter.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

    }
}