using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmRavanshenasHisView : Form
    {
        public FrmRavanshenasHisView()
        {
            InitializeComponent();
        }

        public string sid;       

        private void frmRavanshenasHisView_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            ravanshenas ds = new ravanshenas();
            ds.sick_id = sid;
            dataGridView1.DataSource = ds.SelectSabegheh();
            dataGridView1.AutoGenerateColumns = true;


            string[] col_headers = { "مشخصه", "شماره پرونده", "نام بیمار", "روانشناس", "شروع درمان", "تاریخ", "تاریخ ویزیت بعدی", "شرح نظر روانشناس" };
            int[] col_width = { 60, 100, 120, 90, 80, 80, 80, 302 };

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

                FrmRavanshenasPrintViewer fgkpv = new FrmRavanshenasPrintViewer();
                fgkpv.filler = new ravanshenas().Search("select * from ravanshenas where (sick_id=N'" + dataGridView1.CurrentRow.Cells["sick_id"].Value.ToString() + "')");
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