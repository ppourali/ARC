using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmTakhfifInp : Form
    {
        CurrencyManager objCurrencyManager;
        DataTable datat = new DataTable();

        public string cur_date;


        public frmTakhfifInp()
        {
            InitializeComponent();
        }


        private void frmTakhfifInp_Load(object sender, EventArgs e)
        {


            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            dataGridView1.DataSource = new takhfif().Select();

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.MistyRose;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;


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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

                short last_End_Range = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[0, i].Value != null || dataGridView1[1, i].Value != null || dataGridView1[2, i].Value != null)
                    {
                        if (short.Parse(dataGridView1["start_range", i].Value.ToString()) < last_End_Range || short.Parse(dataGridView1["start_range", i].Value.ToString()) >
                        short.Parse(dataGridView1["end_range", i].Value.ToString()))
                        {
                            MessageBox.Show("لطفا اطلاعات وارد شده را بررسی نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            last_End_Range = short.Parse(dataGridView1["end_range", i].Value.ToString());
                        }
                    }
                }


                takhfif takh = new takhfif();
                takh.Delete();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[0, i].Value != null && dataGridView1[1, i].Value != null && dataGridView1[2, i].Value != null)
                    {
                        takh.start_range = short.Parse(dataGridView1["start_range", i].Value.ToString());
                        takh.end_range = short.Parse(dataGridView1["end_range", i].Value.ToString());
                        takh.takhfif_percent = short.Parse(dataGridView1["takhfif_percent", i].Value.ToString());

                        takh.Add();
                    }
                }

                MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد");

                this.Close();

            }
            catch
            {
                MessageBox.Show("لطفا اطلاعات وارد شده را بررسی نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.Format = "0 درصد";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCell sr = this.dataGridView1.Rows[e.RowIndex].Cells["start_range"];
            DataGridViewCell er = this.dataGridView1.Rows[e.RowIndex].Cells["end_range"];
            DataGridViewCell ta = this.dataGridView1.Rows[e.RowIndex].Cells["takhfif_percent"];
            try
            {
                short temp = short.Parse(sr.Value.ToString());
                sr.Value = temp;
                dataGridView1.Columns["start_range"].DefaultCellStyle = dataGridViewCellStyle2;
            }
            catch
            {
                sr.Value = null;
            }
         
            try
            {
                short temp = short.Parse(er.Value.ToString());
                er.Value = temp;
                dataGridView1.Columns["end_range"].DefaultCellStyle = dataGridViewCellStyle2;
            }
            catch
            {
                er.Value = null;
            }
            try
            {
                short temp = short.Parse(ta.Value.ToString());
                ta.Value = temp;
                dataGridView1.Columns["takhfif_percent"].DefaultCellStyle = dataGridViewCellStyle2;
            }
            catch
            {
                ta.Value = null;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

    }
}