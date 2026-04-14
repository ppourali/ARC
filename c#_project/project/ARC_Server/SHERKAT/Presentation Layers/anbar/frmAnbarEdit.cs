using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Mehr.Presentation_Layers
{
    public partial class frmAnbarEdit : Form
    {
        DataTable dt = new DataTable();
        public string old_daru_name="",old_mandeh="";

        public frmAnbarEdit()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Updating the Data to the DataBase
            Anbar an = new Anbar();
            an.daru_name = txtdaru_name.Text;
            an.mandeh = float.Parse(txtmandeh.Text);
            an.vahed = txtvahed.Text;
            an.fee = long.Parse(txtfee.Text);
            an.old_daruname = old_daru_name;
            an.old_mandeh = float.Parse(old_mandeh);
            an.Update();
            // End of Updating Data to the DataBase

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtmandeh.Text == "" && sender == txtmandeh)
            {
                txtmandeh.Text = "0";
                txtmandeh.SelectAll();
                txtmandeh.Focus();
            }

            if (txtfee.Text == "" && sender == txtfee)
            {
                txtfee.Text = "0";
                txtfee.SelectAll();
                txtfee.Focus();
            }

            if (txtdaru_name.Text == "" || txtmandeh.Text.Trim() == "")
                btnUpdate.Enabled = false;
            else 
            {
                btnUpdate.Enabled = true;
            }
        }


        private void KeyDown_Action(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();

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

        }

        private void KeyPress_Action(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }


        private void frmAnbarEdit_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            txtmandeh.Focus();

        }


    }
}