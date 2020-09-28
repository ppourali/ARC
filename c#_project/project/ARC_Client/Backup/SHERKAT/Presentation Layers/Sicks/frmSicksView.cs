using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mehr.Presentation_Layers
{
    public partial class frmSicksView : Form
    {
        public frmSicksView()
        {
            InitializeComponent();
        }

        public string cur_date;

        private void frmSicksView_Load(object sender, EventArgs e)
        {
            txtravesh_tark.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            //Sicks si = new Sicks();
            //DataTable dt = new DataTable();
            //dt = si.Select();

            txtstatus.SelectedIndex = 0;

            txtOpenOrClose.SelectedIndex = 1;
            btnfilter.PerformClick();

            //grdDataViewer.DataSource = dt;
            grdDataViewer.AutoGenerateColumns = true;

            string[] col_headers = { "شماره پرونده", "شروع درمان", "پایان درمان", "نام و نام خانوادگی", "نام پدر", "تاریخ تولد", "شهر", "شماره شناسنامه", "جنسیت", "تلفن منزل", "تلفن همراه", "مخدر مصرفی", "روش  ترک", "آدرس", "هزینه روزانه", "هزینه ماهانه", "مانده حساب", "وضعیت حساب" };
            int[] col_width = { 100, 70, 70, 130, 80, 70, 50, 80, 50, 80, 80, 100, 135, 120, 70, 70, 70, 70 };

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
            grdDataViewer.Columns["hesab"].DefaultCellStyle = dataGridViewCellStyle1;
            grdDataViewer.Columns["roozaneh"].DefaultCellStyle = dataGridViewCellStyle1;
            grdDataViewer.Columns["monthfee"].DefaultCellStyle = dataGridViewCellStyle1;

            if (Program.user_semat.Trim() == "بازرس")
            {
               // btnsabegheh.Visible = false;
                سابقهمالیبیمارToolStripMenuItem.Visible = false;
                
                button2.Visible = false;
                سابقهداروییبیمارواقعیToolStripMenuItem.Visible = false;

                label5.Visible = false;
                txtOpenOrClose.Visible = false;

                label6.Visible = false;
                txtstatus.Visible = false;

                comboBox1.Items.RemoveAt(14);
                comboBox1.Items.RemoveAt(13);
                
                p11.Visible = false;


                grdDataViewer.Columns["roozaneh"].Visible = false;
                grdDataViewer.Columns["hesab"].Visible = false;
                grdDataViewer.Columns["status"].Visible = false;
            }
        }


        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from Sicks where ";
                check = false;


                if (txtid.Text != "")
                {
                    SQL = SQL + "id=N'" + txtid.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtname.Text != "")
                {
                    SQL = SQL + "name like N'%" + txtname.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtdarman_date.MaskCompleted)
                {
                    SQL = SQL + "darman_date>=N'" + txtdarman_date.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txttodate.MaskCompleted)
                {
                    SQL = SQL + "darman_date<=N'" + txttodate.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtmasrafi_type.Text != "")
                {
                    SQL = SQL + "masrafi_type like N'%" + txtmasrafi_type.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtravesh_tark.SelectedIndex > 0)
                {
                    SQL = SQL + "ravesh_tark like N'%" + txtravesh_tark.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtstatus.SelectedIndex > 0)
                {
                    SQL = SQL + "hesab>0 and status=N'" + txtstatus.Text.Trim() + "'AND ";
                    check = true;
                }

                if (txtOpenOrClose.SelectedIndex == 0)
                {
                    SQL = SQL + "len(payan_date)!=10 OR len(payan_date)=10AND ";
                    check = true;
                }
                else if (txtOpenOrClose.SelectedIndex==1)
                {
                    SQL = SQL + "len(payan_date)!=10AND ";
                    check = true;
                }
                else if (txtOpenOrClose.SelectedIndex == 2)
                {
                    SQL = SQL + "len(payan_date)=10AND ";
                    check = true;
                }

                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4) + " ORDER BY darman_date DESC";
                }

                Sicks rm = new Sicks();
                DataTable dt = new DataTable();
                dt = rm.Search(SQL);
                grdDataViewer.DataSource = dt;

                if (Program.user_semat.Trim() == "بازرس")
                {
                    grdDataViewer.Columns["roozaneh"].Visible = false;
                    grdDataViewer.Columns["hesab"].Visible = false;
                    grdDataViewer.Columns["status"].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات را به صورت درست وارد نمایید!!!");
                txtid.Text = "";
            }
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmSicksView_Activated(object sender, EventArgs e)
        {
            if (btnfilter.Enabled == false)
            {
                Sicks pm = new Sicks();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                if (Program.user_semat.Trim() == "بازرس")
                {
                    grdDataViewer.Columns["roozaneh"].Visible = false;
                    grdDataViewer.Columns["hesab"].Visible = false;
                    grdDataViewer.Columns["status"].Visible = false;
                }
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            int icol = 0;
            int irow = grdDataViewer.CurrentRow.Index;
            string val = grdDataViewer[icol, irow].Value.ToString();

            if (new tahvil().Search("SELECT id FROM tahvil WHERE (id=N'" + val + "' and date>=N'" + cur_date + "')").Rows.Count > 0)
            {
                MessageBox.Show("بیمار مورد نظر در روزهای بعد از تاریخ پایان درمان، دارو دریافت کرده است. ابتدا داروهای دریافتی پس از این تاریخ را حدف نموده و مجددا سعی نمایید");

            }
            else
            {
                DialogResult dr;
                dr = MessageBox.Show("آیا از بستن پرونده ی بیمار اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Sicks sic = new Sicks();
                        sic.id = val;
                        sic.payan_date = cur_date;
                        sic.Delete();

                        MessageBox.Show("عملیات بستن پرونده بیمار با موفقیت انجام شد");

                        Sicks pm = new Sicks();
                        DataTable dt = new DataTable();
                        dt = pm.Select();
                        grdDataViewer.DataSource = dt;

                        if (Program.user_semat.Trim() == "بازرس")
                        {
                            grdDataViewer.Columns["roozaneh"].Visible = false;
                            grdDataViewer.Columns["hesab"].Visible = false;
                            grdDataViewer.Columns["status"].Visible = false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("عملیات بستن پرونده بیمار با مشکل مواجه شد");
                    }
                }
            }
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text == "" && !txtdarman_date.MaskCompleted && !txttodate.MaskCompleted && txtmasrafi_type.Text == "" && txtravesh_tark.SelectedIndex == 0 && txtOpenOrClose.SelectedIndex == 0 && txtstatus.SelectedIndex == 0)
            {
                btnfilter.Enabled = false;

                Sicks pm = new Sicks();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                if (Program.user_semat.Trim() == "بازرس")
                {
                    grdDataViewer.Columns["roozaneh"].Visible = false;
                    grdDataViewer.Columns["hesab"].Visible = false;
                    grdDataViewer.Columns["status"].Visible = false;
                }
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

        }


        private void Validating_Action(object sender, CancelEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmSickInp fsi = new frmSickInp();
            fsi.cur_date = this.cur_date;
            //fsi.MdiParent = this.MdiParent;
            fsi.ShowDialog();

            btnfilter.PerformClick();

            //Sicks pm = new Sicks();
            //DataTable dt = new DataTable();
            //dt = pm.Select();
            //grdDataViewer.DataSource = dt;

            if (Program.user_semat.Trim() == "بازرس")
            {
                grdDataViewer.Columns["roozaneh"].Visible = false;
                grdDataViewer.Columns["hesab"].Visible = false;
                grdDataViewer.Columns["status"].Visible = false;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.CurrentRow != null)
            {
                int col = 0;
                int row = grdDataViewer.CurrentRow.Index;
                string val = grdDataViewer[col, row].Value.ToString();

                Sicks si = new Sicks();
                DataTable datat = new DataTable();
                si.id = val;

                datat = si.Selectforedit();

                frmSicksEdit fse = new frmSicksEdit();

                fse.txtoldid.Text = val;
                fse.idsearch_Click(null, null);
                fse.ShowDialog();

                //Sicks pm = new Sicks();
                //DataTable dt = new DataTable();
                //dt = pm.Select();
                //grdDataViewer.DataSource = dt;

                btnfilter.PerformClick();

                if (Program.user_semat.Trim() == "بازرس")
                {
                    grdDataViewer.Columns["roozaneh"].Visible = false;
                    grdDataViewer.Columns["hesab"].Visible = false;
                    grdDataViewer.Columns["status"].Visible = false;
                }
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksDocPrintViewer fd = new frmSicksDocPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksAzmayeshPrintViewer fd = new frmSicksAzmayeshPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksDastoorPrintViewer fd = new frmSicksDastoorPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksRavanshenasPrintViewer fd = new frmSicksRavanshenasPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 4)
            {

                DataTable ids = new DataTable();
                ids.Columns.Add("id");
                ids.Columns.Add("name");
                ids.Columns.Add("darman_date");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString(), dgvr.Cells["darman_date"].Value.ToString() });
                }
                frmDaftariPeygiriPrintViewerEntekhaabi fd = new frmDaftariPeygiriPrintViewerEntekhaabi();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");
                ids.Columns.Add("name");
                ids.Columns.Add("darman_date");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString(), dgvr.Cells["darman_date"].Value.ToString() });
                }
                frmDaftariPeygiriPrintViewerAllInOne fd = new frmDaftariPeygiriPrintViewerAllInOne();
                fd.idtable = ids;
                fd.cur_date = cur_date;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksTanzimPezeshkPrintViewer fd = new frmSicksTanzimPezeshkPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");
                ids.Columns.Add("name");
                ids.Columns.Add("darman_date");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString(), dgvr.Cells["darman_date"].Value.ToString() });
                }
                frmSicksTanzimPezeshkPrintViewerAllInOne fd = new frmSicksTanzimPezeshkPrintViewerAllInOne();
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksTanzimParastarPrintViewer fd = new frmSicksTanzimParastarPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");
                ids.Columns.Add("name");
                ids.Columns.Add("darman_date");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString(), dgvr.Cells["darman_date"].Value.ToString() });
                }
                frmSicksTanzimParastarPrintViewerAllInOne fd = new frmSicksTanzimParastarPrintViewerAllInOne();
                fd.idtable = ids;
                fd.Show();
            }
            else if (comboBox1.SelectedIndex == 10)
            {
                frmSicksIndiPrintViewer fsipv = new frmSicksIndiPrintViewer();
                fsipv.filler = (DataTable)(grdDataViewer.DataSource);
                fsipv.Show();
            }
            else if (comboBox1.SelectedIndex == 11)
            {
                frmSicksGroupPrintViewer fsgpv = new frmSicksGroupPrintViewer();
                fsgpv.filler = (DataTable)(grdDataViewer.DataSource);
                fsgpv.Show();
            }
            else if (comboBox1.SelectedIndex == 12)
            {
                frmTahodPrintViewer ftpv = new frmTahodPrintViewer();
                ftpv.filler = (DataTable)(grdDataViewer.DataSource);
                ftpv.Show();
            }
            else if (comboBox1.SelectedIndex == 13)
            {
                frmSicksHesabPrintViewer ftpv = new frmSicksHesabPrintViewer();
                ftpv.filler = (DataTable)(grdDataViewer.DataSource);
                ftpv.Show();
            }
            else if (comboBox1.SelectedIndex == 14)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }

                frmTahvil_ResidPrintViewer ftkpv = new frmTahvil_ResidPrintViewer();
                ftkpv.ResidById = true;;
                ftkpv.idTable = ids;
                ftkpv.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmSabeghehView frtv = new frmSabeghehView();
                frtv.id = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());

                frtv.tahORtaj = false;

                frtv.ShowDialog();
            }
        }

        private void btnsabegheh_Click(object sender, EventArgs e)
        {
            if (Program.user_semat.Trim() == "بازرس")
            {
                frmSickDaftariHisView fsh = new frmSickDaftariHisView();
                fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                fsh.sabegheh = true;
                fsh.Show();
            }
            else
            {
                frmSickHisView fsh = new frmSickHisView();
                fsh.txtid.Text = grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString();
                fsh.sabegheh = true;
                fsh.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtname.Text == "" && !txtdarman_date.MaskCompleted && !txttodate.MaskCompleted && txtmasrafi_type.Text == "" && txtravesh_tark.SelectedIndex == 0 && txtOpenOrClose.SelectedIndex==0)
            {
                btnfilter.Enabled = false;

                Sicks pm = new Sicks();
                DataTable dt = new DataTable();
                dt = pm.Select();
                grdDataViewer.DataSource = dt;

                if (Program.user_semat.Trim() == "بازرس")
                {
                    grdDataViewer.Columns["roozaneh"].Visible = false;
                    grdDataViewer.Columns["hesab"].Visible = false;
                    grdDataViewer.Columns["status"].Visible = false;
                }
            }
            else
            {
                btnfilter.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grdDataViewer.Rows.Count > 0)
            {
                frmSabeghehView frtv = new frmSabeghehView();
                frtv.id = (grdDataViewer["id", grdDataViewer.CurrentCell.RowIndex].Value.ToString());

                frtv.tahORtaj = true;

                frtv.ShowDialog();
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btnprint.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
            {
                btndel.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
            {
                btnedit.PerformClick();
                e.SuppressKeyPress = true;
            }

        }

        private void استخراجشمارههمراهبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Application.StartupPath;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = saveFileDialog1.FileName.ToString();

                StreamWriter writer = File.CreateText(a);
                int allcounter = 0, correctcounter = 0;
                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    allcounter++;
                    if (!dgvr.Cells["mobile"].Value.ToString().Trim().Equals("") && dgvr.Cells["mobile"].Value.ToString().Trim().Length == 11)
                    {
                        if (dgvr.Cells["mobile"].Value.ToString().Trim().Substring(0, 2).Equals("09"))
                        {
                            writer.WriteLine(dgvr.Cells["mobile"].Value.ToString().Trim());
                            correctcounter++;
                        }
                    }
                }

                writer.Close();
                MessageBox.Show("عملیات استخراج شماره تماس مخاطبین با موفقیت انجام شد\nتعداد شماره های معتبر: "+correctcounter.ToString()+" از "+allcounter.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        private void ContextMenuPrint(object sender, EventArgs e)
        {
            if (sender == p0)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksDocPrintViewer fd = new frmSicksDocPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (sender == p1)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksAzmayeshPrintViewer fd = new frmSicksAzmayeshPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (sender == p2)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksDastoorPrintViewer fd = new frmSicksDastoorPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (sender == p3)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksRavanshenasPrintViewer fd = new frmSicksRavanshenasPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (sender == p4)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksTanzimPezeshkPrintViewer fd = new frmSicksTanzimPezeshkPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (sender == p5)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");
                ids.Columns.Add("name");
                ids.Columns.Add("darman_date");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString(), dgvr.Cells["darman_date"].Value.ToString() });
                }
                frmSicksTanzimPezeshkPrintViewerAllInOne fd = new frmSicksTanzimPezeshkPrintViewerAllInOne();
                fd.idtable = ids;
                fd.Show();
            }
            else if (sender == p6)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString() });
                }
                frmSicksTanzimParastarPrintViewer fd = new frmSicksTanzimParastarPrintViewer();
                fd.cur_date = cur_date;
                fd.idtable = ids;
                fd.Show();
            }
            else if (sender == p7)
            {
                DataTable ids = new DataTable();
                ids.Columns.Add("id");
                ids.Columns.Add("name");
                ids.Columns.Add("darman_date");

                foreach (DataGridViewRow dgvr in grdDataViewer.SelectedRows)
                {
                    ids.Rows.Add(new object[] { dgvr.Cells["id"].Value.ToString(), dgvr.Cells["name"].Value.ToString(), dgvr.Cells["darman_date"].Value.ToString() });
                }
                frmSicksTanzimParastarPrintViewerAllInOne fd = new frmSicksTanzimParastarPrintViewerAllInOne();
                fd.idtable = ids;
                fd.Show();
            }
            else if (sender == p8)
            {
                frmSicksIndiPrintViewer fsipv = new frmSicksIndiPrintViewer();
                fsipv.filler = (DataTable)(grdDataViewer.DataSource);
                fsipv.Show();
            }
            else if (sender == p9)
            {
                frmSicksGroupPrintViewer fsgpv = new frmSicksGroupPrintViewer();
                fsgpv.filler = (DataTable)(grdDataViewer.DataSource);
                fsgpv.Show();
            }
            else if (sender == p10)
            {
                frmTahodPrintViewer ftpv = new frmTahodPrintViewer();
                ftpv.filler = (DataTable)(grdDataViewer.DataSource);
                ftpv.Show();
            }
            else if (sender == p11)
            {
                frmSicksHesabPrintViewer ftpv = new frmSicksHesabPrintViewer();
                ftpv.filler = (DataTable)(grdDataViewer.DataSource);
                ftpv.Show();
            }

        }
    }
}