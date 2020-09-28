using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmSabeghehView : Form
    {
        public frmSabeghehView()
        {
            InitializeComponent();
        }

        public bool tahORtaj;
        public string id;

        private void frmSabeghehView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            DataTable dt = new DataTable();
            if (tahORtaj == false)
            {
                tahvil ta = new tahvil();
                ta.id = id;
                dt = ta.SelectSabegheh();
                this.Text = "نمایش سابقه ی دفتری داروهای بیمار";
            }
            else if (tahORtaj == true)
            {
                tajviz ta = new tajviz();
                ta.id = id;
                dt = ta.SelectSabegheh();
                this.Text = "نمایش سابقه ی مصرفی داروهای بیمار";
            }

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "مشخصه تحویل", "شماره پرونده", "نام بیمار", "نوع درمان", "روز تحویل", "تاریخ تحویل", "تاریخ مصرف دارو", "نام دارو", "دوز مصرف" };
            int[] col_width = { 70, 100, 128, 140, 75, 80, 90, 110, 70 };

            for (int i = 0; i < col_headers.Length; i++)
            {
                grdDataViewer.Columns[i].HeaderText = col_headers[i].ToString();
                grdDataViewer.Columns[i].Width = col_width[i];
            }

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
            grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            for (int i = 0; i < grdDataViewer.Rows.Count - 1; i++)
            {
                if (grdDataViewer["tedad", i].Value.ToString().Equals("0"))
                {
                    grdDataViewer.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                }
                else
                {
                    if (!grdDataViewer[0, i].Value.ToString().Equals(grdDataViewer[0, i + 1].Value.ToString()))
                    {
                        grdDataViewer.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    }
                }
            }

            int lastrow = grdDataViewer.Rows.Count - 1;
            if (lastrow >= 0)
            {
                if (grdDataViewer["tedad", lastrow].Value.ToString().Equals("0"))
                {
                    grdDataViewer.Rows[lastrow].DefaultCellStyle.BackColor = Color.Pink;
                }
                else
                {
                    grdDataViewer.Rows[lastrow].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
            }
            grdDataViewer.CurrentCell = null;
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (tahORtaj == false)
            {
                frmTahvilPrintViewer ftpv = new frmTahvilPrintViewer();
                ftpv.filler = (DataTable)(grdDataViewer.DataSource);
                ftpv.ShowDialog();
            }
            else if (tahORtaj == true)
            {
                frmTajvizPrintViewer ftpv = new frmTajvizPrintViewer();
                ftpv.filler = (DataTable)(grdDataViewer.DataSource);
                ftpv.ShowDialog();
            }
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