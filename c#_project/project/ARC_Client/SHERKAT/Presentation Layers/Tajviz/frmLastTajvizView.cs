using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmLastTajvizView : Form
    {
        public frmLastTajvizView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmLastTajvizView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            tajviz_koli tk = new tajviz_koli();
            DataTable dt = new DataTable();
            dt = tk.Search("SELECT code,name, from_date, to_date, daru_name, tedad From TAJVIZ_KOLI WHERE (tajviz_date=N'" + cur_date.Trim() + "') ORDER BY CODE DESC");

            grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "مشخصه تحویل", "نام", "از تاریخ", "تا تاریخ", "نام دارو", "دوز مصرف دوره" };
            int[] col_width = { 75, 100, 80, 80, 110, 90 };

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
                tajviz_koli tk = new tajviz_koli();
                DataTable dt = new DataTable();
                dt = tk.Search("SELECT code,name, from_date, to_date, daru_name, tedad From TAJVIZ_KOLI WHERE (tajviz_date=N'" + cur_date.Trim() + "') ORDER BY CODE DESC");
                grdDataViewer.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
            }
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnfilter.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                frmRizTajvizView frtv = new frmRizTajvizView();
                frtv.code = long.Parse(grdDataViewer["code", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                frtv.MdiParent = this.MdiParent;
                frtv.Show();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {

                try
                {
                    string fromdate = grdDataViewer["from_date", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    string todate = grdDataViewer["to_date", grdDataViewer.CurrentCell.RowIndex].Value.ToString();

                    System.Globalization.PersianCalendar xd = new System.Globalization.PersianCalendar();
                    TimeSpan ts = xd.ToDateTime(int.Parse(todate.Substring(0, 4)),
                                                int.Parse(todate.Substring(5, 2)),
                                                int.Parse(todate.Substring(8, 2)),
                                                0, 0, 0, 0, 0)
                                  - xd.ToDateTime(int.Parse(fromdate.Substring(0, 4)),
                                                int.Parse(fromdate.Substring(5, 2)),
                                                int.Parse(fromdate.Substring(8, 2)),
                                                0, 0, 0, 0, 0);

                    double datedif = ts.TotalDays;


                    bool IsOpen = false;

                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.GetType() == typeof(frmGhabzDaryaft))
                        {
                            IsOpen = true;
                            ((frmGhabzDaryaft)f).cur_date = cur_date;
                            f.Focus();
                            ((frmGhabzDaryaft)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                            ((frmGhabzDaryaft)f).txtmablagh.Text = (datedif * int.Parse(((frmGhabzDaryaft)f).txtroozaneh.Text)).ToString();
                            ((frmGhabzDaryaft)f).txtmablagh.Focus();
                            break;
                        }
                    }

                    if (IsOpen == false)
                    {
                        frmGhabzDaryaft fsh = new frmGhabzDaryaft();
                        fsh.cur_date = cur_date;
                        fsh.MdiParent = this.MdiParent;
                        fsh.Show();
                        fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        fsh.txtmablagh.Text = (datedif * int.Parse(fsh.txtroozaneh.Text)).ToString();
                        fsh.txtmablagh.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("عملیات صدور قبض با مشکل مواجه شد");
                }
            }
        }
    }


}