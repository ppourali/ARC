using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmAmar_RecordsView : Form
    {
        public frmAmar_RecordsView()
        {
            InitializeComponent();
        }

        string[] row_headers = { "شربت متادون", "قرص متادون 5", "قرص متادون 20", "قرص متادون 40", "با احتساب ضرایب", "قرص بوپرنورفین 0.4", "قرص بوپرنورفین 2", "قرص بوپرنورفین 8", "با احتساب ضرایب", "قرص سوباکسون 2", "قرص سوباکسون 8", "با احتساب ضرایب" };
        public string cur_date;

        private void frmAmar_RecordsView_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);


            btnfilter.PerformClick();
        }


        public void btnfilter_Click(object sender, EventArgs e)
        {

            try
            {
                Boolean check = false;

                string SQL = "select reg_date, daru_name, kol_masrafi_daftar, pookeh, last_tedad_on_date_daftar, nowtedad_daftar, kol_masrafi_sandogh, last_tedad_on_date_sandogh, nowtedad_kol, nowtedad_sandogh, nowtedad_parastar, differences FROM amar_records where ";
                check = false;



                if (txtdate.MaskCompleted)
                {
                    SQL = SQL + "date=N'" + txtdate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);
                }

                amar_records tk = new amar_records();
                DataTable dt = new DataTable();
                dt = tk.Search(SQL);
                grdAllDataView.DataSource = dt;

            string[] col_headers = { "تاریخ ثبت", "نام دارو", "تعداد کل مصرفی دفتر", "تعداد پوکه", "آخرین تعداد موجود در دفتر در تاریخ " + txtdate.Text, "تعداد موجودی فعلی دفتر", "تعداد کل مصرفی بیماران", "آخرین تعداد موجود  مصرفی در تاریخ " + txtdate.Text,  "تعداد کل موجودی مرکز","تعداد موجودی فعلی گاوصندوق", "تعداد موجودی فعلی پرستار", "تفاوت موجودی دفتر و مرکز" };
            
            for (int i = 0; i < col_headers.Length; i++)
            {
                grdAllDataView.Columns[i].HeaderText = col_headers[i].ToString();
                grdAllDataView.Columns[i].Width = 80;
            }

            grdAllDataView.Columns[0].Width = 90;
            grdAllDataView.Columns[1].Width = 150;


            grdAllDataView.Columns[2].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            grdAllDataView.Columns[3].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            grdAllDataView.Columns[4].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            grdAllDataView.Columns[5].DefaultCellStyle.BackColor = Color.LightSkyBlue;

            grdAllDataView.Columns[6].DefaultCellStyle.BackColor = Color.MistyRose;
            grdAllDataView.Columns[7].DefaultCellStyle.BackColor = Color.MistyRose;
            grdAllDataView.Columns[8].DefaultCellStyle.BackColor = Color.MistyRose;
            grdAllDataView.Columns[9].DefaultCellStyle.BackColor = Color.MistyRose;
            grdAllDataView.Columns[10].DefaultCellStyle.BackColor = Color.MistyRose;

            if (grdAllDataView.Rows.Count <= 0)
                return;
            
            Font f = new Font("Tahoma", 9, FontStyle.Bold);

            grdAllDataView.Rows[0].DefaultCellStyle.BackColor = Color.Khaki;
            grdAllDataView.Rows[0].DefaultCellStyle.Font = f;

            grdAllDataView.Rows[4].DefaultCellStyle.BackColor = Color.Khaki;
            grdAllDataView.Rows[4].DefaultCellStyle.Font = f;

            grdAllDataView.Rows[8].DefaultCellStyle.BackColor = Color.Khaki;
            grdAllDataView.Rows[8].DefaultCellStyle.Font = f;

            grdAllDataView.Rows[11].DefaultCellStyle.BackColor = Color.Khaki;
            grdAllDataView.Rows[11].DefaultCellStyle.Font = f;

            grdAllDataView.CurrentCell = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                MessageBox.Show(ex.Message);
                mydataaccess.Log(ex);
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
                e.SuppressKeyPress = true;
                this.ProcessTabKey(true);
                //e.Handled = true; 
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
            DataTable qdt = new MehrDataSet.amarkoliroozanehDataTable();

            for (int i = 0; i < grdAllDataView.Rows.Count; i++)
            {
                qdt.Rows.Add(new object[] {grdAllDataView.Rows[i].Cells[0].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[1].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[2].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[3].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[4].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[5].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[6].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[7].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[8].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[9].Value.ToString(),
                                            grdAllDataView.Rows[i].Cells[10].Value.ToString()});
            }


            frmAmar_koliPrintViewer fsipv = new frmAmar_koliPrintViewer();
            fsipv.filler = (DataTable)(qdt);
            fsipv.fd = txtdate.Text;
            fsipv.Show();
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