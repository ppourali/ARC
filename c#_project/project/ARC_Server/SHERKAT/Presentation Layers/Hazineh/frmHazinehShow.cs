using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class FrmHazinehShow : Form
    {
        public FrmHazinehShow()
        {
            InitializeComponent();
        }
        
        public string ld;

        private void frmHazinehShow_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            hazineh st = new hazineh();
            DataTable dt;
            dt = st.Select();
            

            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = true;


            string[] col_headers = {"ردیف", "شماره سند", "نوع هزینه", "تاریخ", "مبلغ", "توضیحات"};
            int[] col_width = { 50, 70, 100, 80, 60, 200 };

            for (int i = 0; i < col_headers.Length; i++)
            {
                dataGridView1.Columns[i].HeaderText = col_headers[i].ToString();
                dataGridView1.Columns[i].Width = col_width[i];
            }
            
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            dataGridView1.Columns["mablagh"].DefaultCellStyle = dataGridViewCellStyle2;

            dataGridView1.ClearSelection();
            btnexit.Focus();
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            frmHazinehPrintViewer pv = new frmHazinehPrintViewer();

            pv.P = ((DataTable)dataGridView1.DataSource);

            pv.ShowDialog(); 
          
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean check = false;

                string SQL = "select * from hazineh where ";
                check = false;

                if (txttype.Text != "")
                {
                    SQL = SQL + "type Like N'%" + txttype.Text.Trim() + "%'AND ";
                    check = true;
                }

                if (txtfrom_date.MaskCompleted)
                {
                    SQL = SQL + "date>=N'" + txtfrom_date.Text.Trim() + "'AND ";
                    check = true;
                }


                if (txtto_date.MaskCompleted)
                {
                    SQL = SQL + "date <=N'" + txtto_date.Text.Trim() + "'AND ";
                    check = true;
                }

                if (check == true)
                {
                    SQL = SQL.Remove(SQL.Length - 4);

                }


                hazineh pm = new hazineh();
                DataTable dt = new DataTable();
                dt = pm.Search(SQL);
                dataGridView1.DataSource = dt;


                long sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum += Convert.ToInt64(dt.Rows[i]["mablagh"]);
                }
                txtsum.Visible = true;
                txtsum.Text = sum.ToString("N0");

            }
            catch (Exception)
            {
                MessageBox.Show("لطفا اطلاعات جستجو را به صورت صحیح وارد نمایید!!!");
                txttype.Text = "";
            }
        }

        private void txtcus_name_TextChanged(object sender, EventArgs e)
        {
            if (!txtto_date.MaskCompleted && !txtfrom_date.MaskCompleted && txttype.Text == "")
            {
                btnfilter.Enabled = false;

                hazineh pm = new hazineh();
                DataTable dt = new DataTable();
                dt = pm.Select();
                dataGridView1.DataSource = dt;
                

                txtsum.Text = "";
            }
            else
            {
                btnfilter.Enabled = true;
            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int col = 0;
                int row = dataGridView1.CurrentRow.Index;
                string val = dataGridView1["radif", row].Value.ToString();

                FrmHazinehEdit fde = new FrmHazinehEdit();
                fde.txtradif.Text = val;
                //fde.idsearch_Click(null, null);
                fde.ShowDialog();

                btnfilter.PerformClick();

            }
        }

    }
}