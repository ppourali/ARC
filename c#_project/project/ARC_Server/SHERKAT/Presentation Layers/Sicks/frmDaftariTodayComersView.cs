using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmDaftariTodayComersView : Form
    {
        public frmDaftariTodayComersView()
        {
            InitializeComponent();
        }


        public string cur_date;

        private void frmDaftariTodayComersView_Load(object sender, EventArgs e)
        {

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            //DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            //objAlternatingCellStyle.BackColor = Color.Khaki;
            //grdDataViewer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            if (Program.user_semat.Trim() == "بازرس")
            {
                btnsabegheh.Visible = false;
            }

            txtdarman_date.Text = cur_date;
            //btnfilter.PerformClick();
        }


        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Sicks rm = new Sicks();
                DataTable dt = new DataTable();
                dt = rm.Search("SELECT row_number() over (order by t2.lastdate DESC) as rowid, t1.id,t1.[name], t1.darman_date, t2.lastdate, t1.home, t1.mobile, t1.masrafi_type, t1.ravesh_tark, t1.hesab, t1.status FROM SICKS t1 " +
                                "left join (select id, max(to_date) as lastdate from tahvil_koli where (tedad>0) GROUP BY id) t2 on t1.id=t2.id " +
                                "WHERE (t1.id not in(SELECT id FROM Tahvil_koli WHERE from_date<=N'" + txtdarman_date.Text + "' and to_date>N'" + txtdarman_date.Text + "' and tedad>0) and  trim(payan_date)='') order by lastdate desc");


                grdDataViewer.DataSource = dt;

                foreach (DataGridViewRow dgvr in grdDataViewer.Rows)
                {
                    if (dgvr.Cells["lastdate"].Value != null && dgvr.Cells["lastdate"].Value.ToString() != "")
                    {
                        string temp_date = dgvr.Cells["lastdate"].Value.ToString();
                        System.Globalization.PersianCalendar x = new System.Globalization.PersianCalendar();


                        DateTime lastdate = x.ToDateTime(int.Parse(temp_date.Substring(0, 4)),
                                                    int.Parse(temp_date.Substring(5, 2)),
                                                    int.Parse(temp_date.Substring(8, 2)),
                                                    0, 0, 0, 0, 0);

                        DateTime todaydate = x.ToDateTime(int.Parse(txtdarman_date.Text.Substring(0, 4)),
                                                    int.Parse(txtdarman_date.Text.Substring(5, 2)),
                                                    int.Parse(txtdarman_date.Text.Substring(8, 2)),
                                                    0, 0, 0, 0, 0);

                        TimeSpan ts = todaydate.Subtract(lastdate);

                        dgvr.Cells["gheybat"].Value = ts.Days;
                        if (ts.Days > 5 && ts.Days <= 14)
                            dgvr.DefaultCellStyle.BackColor = ControlPaint.LightLight(Color.Pink);
                        if (ts.Days > 14 && ts.Days <= 30)
                            dgvr.DefaultCellStyle.BackColor = Color.Pink;
                        if (ts.Days > 30 && ts.Days <= 60)
                            dgvr.DefaultCellStyle.BackColor = ControlPaint.LightLight(Color.IndianRed);
                        if (ts.Days > 60 && ts.Days <= 90)
                            dgvr.DefaultCellStyle.BackColor = ControlPaint.Light(Color.IndianRed);
                        if (ts.Days > 90)
                            dgvr.DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        dgvr.Cells["gheybat"].Value = "----";
                        dgvr.DefaultCellStyle.BackColor = Color.Red;

                    }
                }


            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtdarman_date.Text = "";
            }
        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (!txtdarman_date.MaskCompleted)
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

       

        //private void btnprint_Click(object sender, EventArgs e)
        //{
        //    frmSicksGroupPrintViewer fsgpv = new frmSicksGroupPrintViewer();
        //    fsgpv.filler = (DataTable)(grdDataViewer.DataSource);
        //    fsgpv.Show();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow!=null)
            {
                frmSabeghehView frtv = new frmSabeghehView();
                frtv.id = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());
                
                if (Program.user_semat.Trim() == "بازرس")
                    frtv.tahORtaj = false;
                else
                    frtv.tahORtaj = false;

                frtv.ShowDialog();
            }
        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                frmSickHisView fsh = new frmSickHisView();
                fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                fsh.sabegheh = true;
                fsh.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                grdDataViewer.Focus();
                bool IsOpen = false;

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(frmPeygiriInp))
                    {
                        IsOpen = true;
                        ((frmPeygiriInp)f).cur_date = cur_date;
                        f.Focus();
                        ((frmPeygiriInp)f).txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                        ((frmPeygiriInp)f).idsearch_Click(null, null);
                        //f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    frmPeygiriInp fsh = new frmPeygiriInp();
                    fsh.sentbyadamview = true;
                    fsh.cur_date = cur_date;
                    fsh.Left = this.Left;
                    fsh.Top = this.Top;
                    fsh.MdiParent = this.MdiParent;
                    fsh.Show();
                    fsh.txtname.Text = grdDataViewer["name", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                    fsh.idsearch_Click(null, null);
                }

            }
        }

        private void grdDataViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button2.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void grdDataViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.PerformClick();
        }
    }
}