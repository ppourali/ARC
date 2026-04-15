using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmTajvizDaftarView : Form
    {
        public FrmTajvizDaftarView()
        {
            InitializeComponent();
        }


        public long code;

        private void frmTajvizdaftarView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            tajviz_anbar an = new tajviz_anbar();
            DataTable combosource = new DataTable();
            combosource = an.Search("select distinct daru_name from tajviz_anbar");

            txtdaru_name.Items.Add("همه");
            foreach (DataRow dr in combosource.Rows)
                txtdaru_name.Items.Add(dr[0].ToString());

            txtdaru_name.SelectedIndex = 0;

            tajviz ta = new tajviz();
            DataTable dt = new DataTable();
            //ta.code = code;
            dt = ta.Select();

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "مشخصه تحویل", "شماره پرونده", "نام", "نوع درمان", "روز تحویل", "تاریخ تحویل", "تاریخ مصرف دارو", "نام دارو", "دوز مصرف" };
            int[] col_width = { 70, 75, 100, 150, 80, 90, 110, 110, 78 };

            for (int i = 0; i < col_headers.Length; i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.PowderBlue;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            panel1.Focus();
            txtdate.Focus();
            txtdate.SelectAll();

        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmTajvizdaftarView_Activated(object sender, EventArgs e)
        {
            if (btnfilter.Enabled == false)
            {
                tajviz ta = new tajviz();
                DataTable dt = new DataTable();
                ta.code = code;
                dt = ta.Select();
                grdDataViewer.DataSource = dt;
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

        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from tajviz where ";
                check = false;


                if (txtdate.MaskCompleted)
                {
                    SQL = SQL + "date=N'" + txtdate.Text.Trim() + "'AND ";
                    check = true;
                }


                if (txtdaru_name.SelectedIndex > 0)
                {
                    SQL = SQL + "daru_name = N'" + txtdaru_name.Text.Trim() + "'AND ";
                    check = true;
                }


                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4) + " ORDER BY date";
                }

                tahvil tk = new tahvil();
                DataTable dt = new DataTable();
                dt = tk.Search(SQL);
                grdDataViewer.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
            }

        }

        private void txtdate_TextChanged(object sender, EventArgs e)
        {
            if (!txtdate.MaskCompleted && txtdaru_name.SelectedIndex == 0)
            {
                btnfilter.Enabled = false;

                tajviz tk = new tajviz();
                DataTable dt = new DataTable();
                dt = tk.Select();
                grdDataViewer.DataSource = dt;
            }
            else
            {
                btnfilter.Enabled = true;
            }
        }
    }
}