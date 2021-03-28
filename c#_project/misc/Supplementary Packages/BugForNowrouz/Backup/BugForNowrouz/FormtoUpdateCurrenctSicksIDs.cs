using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugForNowrouz
{
    public partial class FormtoUpdateCurrenctSicksIDs : Form
    {
        public FormtoUpdateCurrenctSicksIDs()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string SQL = "select row_number() over (order by id Desc) as radif, name , id_no, id from sicks";
            if (checkBox1.Checked && !checkBox2.Checked)//active
            {
                SQL = "select row_number() over (order by id Desc) as radif, name , id_no,id from sicks where(len(payan_date)!=10)";

            }

            else if (!checkBox1.Checked && checkBox2.Checked)//inActive
            {
                SQL = "select row_number() over (order by id Desc) as radif, name , id_no,id from sicks where(len(payan_date)=10)";

            }

            else if (checkBox1.Checked && checkBox2.Checked)//inActive
            {
                SQL = "select row_number() over (order by id Desc) as radif, name , id_no,id from sicks";

            }


            Sicks scks = new Sicks();
            DataTable dt = scks.Search(SQL);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewCell sr = this.dataGridView1.Rows[e.RowIndex].Cells["newid"];


            try
            {

                if (sr.Value.ToString().Trim() != "")
                    if ((IsAllDigits(sr.Value.ToString().Trim())))
                        sr.Value = sr.Value.ToString().Trim().PadLeft(4, '0');
                    else
                    {

                        sr.Value = "";
                    }
            }
            catch
            {
                sr.Value = "";
            }
        }

        public bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!(Char.IsDigit(c) || c.Equals('-')))
                    return false;
            }
            return true;
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            Sicks scks = new Sicks();
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (dgvr.Cells["newid"].Value != null)
                    if (dgvr.Cells["newid"].Value.ToString().Trim() != "")
                    {
                        scks.old_id =dgvr.Cells["id"].Value.ToString().Trim();
                        scks.id = dgvr.Cells["newid"].Value.ToString().Trim();
                        scks.UpdateCurrecntSicksIDtoNEWFormat();
                    }

            }

            MessageBox.Show("Update Successfull.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sicks scks = new Sicks();
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (dgvr.Cells["id"].Value != null)
                    if (dgvr.Cells["id"].Value.ToString().Trim() != "")
                    {
                        //scks.old_id = dgvr.Cells["id"].Value.ToString().Trim();
                        scks.id = dgvr.Cells["id"].Value.ToString().Trim();
                        scks.name = dgvr.Cells["name"].Value.ToString().Trim();
                        scks.Update();
                    }

            }

            MessageBox.Show("Update Successfull.");
        }
    }
}