using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmAzmayeshHisView : Form
    {
        public frmAzmayeshHisView()
        {
            InitializeComponent();
        }

        public string sid;

        private void frmAzmayeshHisView_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            Azmayesh ds = new Azmayesh();
            ds.sick_id = sid;
            dataGridView1.DataSource = ds.SelectSabegheh();
            dataGridView1.AutoGenerateColumns = true;

            string[] col_headers = { "مشخصه", "شماره پرونده", "نام بیمار", "شروع درمان", "نوع آزمایش", "تاریخ آزمایش", "نتیجه آزمایش", "ملاحظات" };
            int[] col_width = { 60, 100, 120, 90, 80, 80, 80, 222 };

            for (int i = 0; i < col_headers.Length; i++)
            {
                dataGridView1.Columns[i].HeaderText = col_headers[i].ToString();
                dataGridView1.Columns[i].Width = col_width[i];
            }

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.Khaki;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
            
                    frmAzmayeshPrintViewer fgkpv = new frmAzmayeshPrintViewer();
                    fgkpv.filler = (DataTable)(dataGridView1.DataSource);
                    fgkpv.Show();
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
        }
    }
}