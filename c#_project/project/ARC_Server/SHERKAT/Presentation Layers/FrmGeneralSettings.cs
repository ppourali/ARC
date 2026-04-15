using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Mehr.Presentation_Layers
{
    public partial class FrmGeneralSettings : Form
    {

        DataTable datat = new DataTable();
        DataTable dtpr = new DataTable();

        ToolStripMenuItem bazrasMenuItem;

        public FrmGeneralSettings(ToolStripMenuItem bmi)
        {
            InitializeComponent();
            bazrasMenuItem = bmi;
        }

        private void FillDataSetAndView()
        {
            // Initialize a new instance of the DataSet object...

            Gen_settings te = new Gen_settings();

            datat = te.Select();
            // Set our CurrencyManager object
            // to the DataView object..  
        }

        private void BindFields()
        {
            // Clear any previous bindings & Add new bindings to the DataView object...
            foreach (Control c in grpboxMaliReal.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    c.Text = datat.Rows[0][c.Name.Substring(3)].ToString();
                }
            }

            foreach (Control c in grpboxMaliDaftari.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    c.Text = datat.Rows[0][c.Name.Substring(3)].ToString();
                }
            }

            string[] keys=datat.Rows[0]["BazrasKey"].ToString().Split('+');
            if (keys.Length > 1)
            {
                txtBazrasKey.Text = keys[1];
                checkBox1.Checked = true;
            }
            else
            {
                txtBazrasKey.Text = keys[0];
                checkBox1.Checked = false;
            }
            // End of Clearing & Adding of Controls Binding

        }

     
        private void frmGen_Settings_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            txtBazrasKey.SelectedIndex = 0;

            FillDataSetAndView();

            BindFields();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            String shortCutKey = "";
            if (checkBox1.Checked)
                shortCutKey = "Ctrl+";

            shortCutKey += txtBazrasKey.Text;

            bool canSet = checkShortcutAvailability(shortCutKey);

            if (canSet)
            {
                Gen_settings te = new Gen_settings();
                te.PayType = txtPayType.Text.Trim();
                te.Takhfif_Inc = txttakhfif_Inc.Text.Trim();
                te.DaftariPayType = txtDaftariPayType.Text.Trim();
                te.BazrasKey =shortCutKey;
                te.Update();

                FillDataSetAndView();
                BindFields();

                setShortCutKeysForBazras();

                this.Close();
            }
        }


        private void setShortCutKeysForBazras()
        {
            Gen_settings te = new Gen_settings();
            DataTable datat = te.Select();

            string[] keys = datat.Rows[0]["BazrasKey"].ToString().Split('+');

            Keys keyToAssign;
            if (keys.Length > 1)
            {
                keyToAssign = Keys.Control | (Keys)Enum.Parse(typeof(Keys), keys[1]);
            }
            else
            {
                keyToAssign = (Keys)Enum.Parse(typeof(Keys), keys[0]);
            }

            bazrasMenuItem.ShortcutKeys = keyToAssign;

        }

        private bool checkShortcutAvailability(string key)
        {
            if (txtBazrasKey.Text.Length == 1 && checkBox1.Checked==false)
            {
                MessageBox.Show("فعال شود Control برای کلیدهای نک حرفی حتما بایستی کلید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string[] reserverKeys = { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F11", "Ctrl+T", "Ctrl+M", "Ctrl+N", "Ctrl+X", "Ctrl+R", "Ctrl+L", "Ctrl+F4", "Ctrl+F5" };

            for (int i = 0; i < reserverKeys.Length; i++)
            {
                if (key.ToLower().Equals(reserverKeys[i].ToLower()))
                {
                    MessageBox.Show("کلید تعیین شده برای عملیات ورود بازرس قبلا در سیستم رزرو شده است، لطفا کلید دیگری را انتخاب نمایید.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }


        private void addbtnTextChanged(object sender, EventArgs e)
        {
            if (txtPayType.Text == "" || txttakhfif_Inc.Text == "" || txtBazrasKey.Text.Trim()=="" ||txtDaftariPayType.Text=="")
                btnAdd.Enabled = false;

            else
                btnAdd.Enabled = true;

        }

      
        private void txthesab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(true);
                e.SuppressKeyPress = true;
            }
        }

      
        private void txtmablagh_Enter(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).BackColor = Color.Yellow;
                ((TextBox)sender).Focus();
                ((TextBox)sender).SelectAll();
            }
            catch
            {

                ((ComboBox)sender).BackColor = Color.Yellow;
            }
        }

        private void txtmablagh_Leave(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).BackColor = Color.White;
            }
            catch
            {
                ((ComboBox)sender).BackColor = Color.White;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBazrasKey_TextChanged(object sender, EventArgs e)
        {
            if (  txtBazrasKey.Text.ToLower().Length==1 )
                checkBox1.Checked = true;

            if (txtPayType.Text == "" || txttakhfif_Inc.Text == "" || txtBazrasKey.Text.Trim() == "" || txtDaftariPayType.Text == "")
                btnAdd.Enabled = false;

            else
                btnAdd.Enabled = true;
        }

    }
}
