using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class FrmMosahebehInp : Form
    {
        DataTable datat = new DataTable();

        public bool sentbyadamview = false;

        public string cur_date = "";
           
        public FrmMosahebehInp()
        {
            InitializeComponent();
        }


        private void frmMosahebehInp_Load(object sender, EventArgs e)
        {
            // Create the list to use as the custom source. 
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            Accounts ac = new Accounts();
            DataTable ravandt = new DataTable();
            ravandt = ac.SelectRavans();
            foreach (DataRow dtrow in ravandt.Rows)
                source.Add(dtrow["name"].ToString().Trim());

            // Create and initialize the text box.
            txtmos_name.AutoCompleteCustomSource = source;
            txtmos_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtmos_name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (Program.user_semat.Trim().Equals("روانشناس"))
                txtmos_name.Text = Program.user_name;
            else
            {
                if (ravandt.Rows.Count == 1)
                    txtmos_name.Text = ravandt.Rows[0]["name"].ToString();
            }

            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            txtqf1.SelectedIndex = 0;
            txtqf3.SelectedIndex = 0;
            foreach (Control cb in pnl13.Controls)
            {
                if (cb.GetType() == typeof(ComboBox))
                    ((ComboBox)cb).SelectedIndex = 0;
            }
            foreach (Control cb in pnl14.Controls)
            {
                if (cb.GetType() == typeof(ComboBox))
                    ((ComboBox)cb).SelectedIndex = 0;
            }

            btnAdd.Enabled = false;

            grpinfo_box.Focus();
            txtid.Focus();

            txtcode.Text = new mos_list().Selectmaxid().ToString();
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                # region INSERT INTO MOS_LIST
                // Inserting the Data to the DataBase  mos_list//
                mos_list ml = new mos_list();
                ml.code = long.Parse(txtcode.Text);
                ml.id = txtid.Text.Trim();
                ml.name = txtname.Text;
                ml.home = txthome.Text;
                ml.mos_date = txtmos_date.Text;
                ml.mos_name = txtmos_name.Text;
                ml.mos_semat = txtmos_semat.Text;
                ml.Add();
                // End of Inserting Data to the DataBase//
                # endregion


                #region INSERT INTO MAP_A
                map_a ma = new map_a();
                ma.code = long.Parse(txtcode.Text); 
                ma.id = txtid.Text;
                if (chk1.Checked)
                {
                    ma.masrafi_type = chk1.Text;
                    ma.rooz = nud11.Value.ToString();
                    ma.mizan = nud12.Value.ToString();
                    ma.tarigheh = tb1.Text.Trim();
                    ma.Add();
                }

                if (chk2.Checked)
                {
                    ma.masrafi_type = chk2.Text;
                    ma.rooz = nud21.Value.ToString();
                    ma.mizan = nud22.Value.ToString();
                    ma.tarigheh = tb2.Text.Trim();
                    ma.Add();
                }

                if (chk3.Checked)
                {
                    ma.masrafi_type = chk3.Text;
                    ma.rooz = nud31.Value.ToString();
                    ma.mizan = nud32.Value.ToString();
                    ma.tarigheh = tb3.Text.Trim();
                    ma.Add();
                }

                if (chk4.Checked)
                {
                    ma.masrafi_type = chk4.Text;
                    ma.rooz = nud41.Value.ToString();
                    ma.mizan = nud42.Value.ToString();
                    ma.tarigheh = tb4.Text.Trim();
                    ma.Add();
                }

                if (chk5.Checked)
                {
                    ma.masrafi_type = chk5.Text;
                    ma.rooz = nud51.Value.ToString();
                    ma.mizan = nud52.Value.ToString();
                    ma.tarigheh = tb5.Text.Trim();
                    ma.Add();
                }

                if (chk6.Checked)
                {
                    ma.masrafi_type = chk6.Text;
                    ma.rooz = nud61.Value.ToString();
                    ma.mizan = nud62.Value.ToString();
                    ma.tarigheh = tb6.Text.Trim();
                    ma.Add();
                }

                if (chk7.Checked)
                {
                    ma.masrafi_type = chk7.Text;
                    ma.rooz = nud71.Value.ToString();
                    ma.mizan = nud72.Value.ToString();
                    ma.tarigheh = tb7.Text.Trim();
                    ma.Add();
                }

                if (chk8.Checked)
                {
                    ma.masrafi_type = tbother.Text.Trim();
                    ma.rooz = nud81.Value.ToString();
                    ma.mizan = nud82.Value.ToString();
                    ma.tarigheh = tb8.Text.Trim();
                    ma.Add();
                }

                #endregion

                # region INSERT INTO MAP_BtoG

                // Inserting the Data to the DataBase MAP_BtoG //
                MAP_BtoG map = new MAP_BtoG();
                map.code = long.Parse(txtcode.Text); 
                map.id = txtid.Text;

                map.qoverdose = txtoverdose.Value.ToString();

                map.qb1 = txtqb1.Value.ToString();
                map.qb2_1 = txtqb2_1.Value.ToString();
                map.qb2_2 = txtqb2_2.Value.ToString();
                map.qb2_3 = txtqb2_3.Value.ToString();
                map.qb2_4 = txtqb2_4.Value.ToString();
                map.qb3 = txtqb3.Text.ToString();
                map.qb4 = txtqb4.Text.ToString();
                map.qb5 = txtqb5.Text.ToString();
                map.qb6 = txtqb6.Text.ToString();
                map.qb7 = txtqb7.Text.ToString();
                map.qb8 = txtqb8.Text.ToString();
                map.qb9_1 = txtqb9_1.Value.ToString();
                map.qb9_2 = txtqb9_2.Text.ToString();
                map.qb9_3 = txtqb9_3.Text.ToString();

                map.qc1 = txtqc1.Value.ToString();
                map.qc2 = txtqc2.Value.ToString();
                map.qc3 = txtqc3.Value.ToString();
                map.qc4 = txtqc4.Value.ToString();
                map.qc5 = txtqc5.Value.ToString();

                map.qd1 = txtqd1.Text.ToString();
                map.qd2 = txtqd2.Text.ToString();
                map.qd3 = txtqd3.Text.ToString();
                map.qd4 = txtqd4.Text.ToString();
                map.qd5 = txtqd5.Text.ToString();
                map.qd6 = txtqd6.Text.ToString();
                map.qd7 = txtqd7.Text.ToString();
                map.qd8 = txtqd8.Text.ToString();
                map.qd9 = txtqd9.Text.ToString();
                map.qd10 = txtqd10.Text.ToString();
                map.qd11 = txtqd11.Text.ToString();
                map.qd12 = txtqd12.Text.ToString();
                map.qd13 = txtqd13.Text.ToString();
                map.qd14 = txtqd14.Text.ToString();
                map.qd15 = txtqd15.Text.ToString();
                map.qd16 = txtqd16.Text.ToString();
                map.qd17 = txtqd17.Text.ToString();
                map.qd18 = txtqd18.Text.ToString();
                map.qd19 = txtqd19.Text.ToString();
                map.qd20 = txtqd20.Text.ToString();

                map.qe1 = txtqe1.Value.ToString();
                map.qe2 = txtqe2.Value.ToString();
                map.qe3 = txtqe3.Value.ToString();
                map.qe4 = txtqe4.Value.ToString();
                map.qe5 = txtqe5.Value.ToString();
                map.qe6 = txtqe6.Value.ToString();
                map.qe7 = txtqe7.Value.ToString();

                map.qf1 = txtqf1.Text.Trim();
                map.qf2 = txtqf2.Text.Trim();
                map.qf3 = txtqf3.Text.Trim();
                foreach (Control t in pnl24.Controls)
                {
                    if (t.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)t).Checked && ((RadioButton)t) != rdoqf4)
                        {
                            map.qf4 = t.Text;
                            break;
                        }
                        else if (((RadioButton)t).Checked && ((RadioButton)t) == rdoqf4)
                        {
                            map.qf4 = txtqf4sayer.Text;
                            break;
                        }
                    }
                }

                foreach (Control t in pnl25.Controls)
                {
                    if (t.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)t).Checked)
                        {
                            map.qf5 = t.Text;
                            break;
                        }
                    }

                }

                foreach (Control t in pnl26.Controls)
                {
                    if (t.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)t).Checked)
                        {
                            map.qf6 = t.Text;
                            break;
                        }
                    }

                }


                map.qg1 = txtqg1.Text.Trim();
                map.qg2 = txtqg2.Text.Trim();
                map.qg3 = txtqg3.Text.Trim();

                map.Add();
                // End of Inserting Data to the DataBase

                #endregion

                #region INSERT INTO MAP_HISTORY
                map_history mh = new map_history();
                mh.code = long.Parse(txtcode.Text);
                mh.id = txtid.Text;
                foreach (DataGridViewRow dr in grdMap_history.Rows)
                {
                    if (dr.Cells["masrafi_type"].Value != null && dr.Cells["masrafi_type"].Value.ToString().Trim() != "")
                    {
                        if (dr.Cells["masrafi_type"].Value != null)
                            mh.masrafi_type = dr.Cells["masrafi_type"].Value.ToString();

                        if (dr.Cells["start_age"].Value != null)
                            mh.start_age = dr.Cells["start_age"].Value.ToString();

                        if (dr.Cells["rooz"].Value != null)
                            mh.rooz = dr.Cells["rooz"].Value.ToString();

                        if (dr.Cells["masraf_life"].Value != null)
                            mh.masraf_life = dr.Cells["masraf_life"].Value.ToString();

                        if (dr.Cells["tarigheh"].Value != null)
                            mh.tarigheh = dr.Cells["tarigheh"].Value.ToString();
                        mh.Add();
                    }
                }
                #endregion


                MessageBox.Show("عملیات ثبت اطلاعات مصاحبه با موفقیت انجام شد");

                if (sentbyadamview == true)
                {
                    try
                    {
                        this.Close();
                        Application.OpenForms["frmDaftariPeygiriPattern"].Activate();
                    }
                    catch
                    {
                    }
                }
                else
                    this.Close();
            }
            catch
            {
                MessageBox.Show("درج اطلاعات مصاحبه با مشکل مواجه گریدید. لطفا اطلاعات ورودی را مجددا بررسی نمایید");
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                txtid.Text = "000000000000000";
                txtid.SelectAll();
                txtid.Focus();
            }

            if (txtid.Text == "" || txtname.Text.Trim() == "" || txtmos_name.Text.Trim() == "" || txtmos_semat.Text.Trim() == "" || !txtmos_date.MaskCompleted || txtcode.Text == "")
                btnAdd.Enabled = false;
            else
            {
                btnAdd.Enabled = true;
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

            else if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.Yellow;
                ((NumericUpDown)sender).Focus();
                ((NumericUpDown)sender).Select(0, 5);
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

            if (sender.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)sender).BackColor = Color.White;
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


        private void Validating_Action(object sender, CancelEventArgs e)
        {

        }

        public void idsearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Sicks si = new Sicks();
            si.id = txtid.Text;
            dt = si.Selectforedit();
            if (dt.Rows.Count > 0)
            {
                mos_list ml = new mos_list();
                ml.id = txtid.Text;

                // Clear any previous bindings & Add new bindings to the DataView object...
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtfather_name.Text = dt.Rows[0]["father_name"].ToString();
                txthome.Text = dt.Rows[0]["home"].ToString();

                txtqf1.Text = dt.Rows[0]["sex"].ToString();
                // End of Clearing & Adding of Controls Binding

                tabControl1.Enabled = true;
                txtmos_name.Focus();
                grpinfo_box.TabStop = false;

                txtmos_date.Text = cur_date;
            }

            else
            {
                MessageBox.Show("شماره پرونده در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void KeyDownforSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtid.Text = string.Format("{0:000000000000000}", Convert.ToDecimal(txtid.Text));
                idsearch.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void EnabledChangedbyCheckboxes(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                if (((TextBox)sender).Enabled)
                    ((TextBox)sender).BackColor = Color.Yellow;
                else
                    ((TextBox)sender).BackColor = Color.WhiteSmoke;
            }
            else if (sender.GetType() == typeof(NumericUpDown))
            {
                if (((NumericUpDown)sender).Enabled)
                    ((NumericUpDown)sender).BackColor = Color.Yellow;
                else
                    ((NumericUpDown)sender).BackColor = Color.WhiteSmoke;
            }
        }


        private void ChechChangedforAform(object sender, EventArgs e)
        {
            if (((CheckBox)sender) == chk1 && ((CheckBox)sender).Checked==true)
            {
                nud11.Enabled = nud12.Enabled = tb1.Enabled = true;

            }
            else if (((CheckBox)sender) == chk1 && ((CheckBox)sender).Checked == false)
            {
                nud11.Enabled = nud12.Enabled = tb1.Enabled = false;
            }

            if (((CheckBox)sender) == chk2 && ((CheckBox)sender).Checked == true)
            {
                nud21.Enabled = nud22.Enabled = tb2.Enabled = true;

            }
            else if (((CheckBox)sender) == chk2 && ((CheckBox)sender).Checked == false)
            {
                nud21.Enabled = nud22.Enabled = tb2.Enabled = false;
            }

            if (((CheckBox)sender) == chk3 && ((CheckBox)sender).Checked == true)
            {
                nud31.Enabled = nud32.Enabled = tb3.Enabled = true;

            }
            else if (((CheckBox)sender) == chk3 && ((CheckBox)sender).Checked == false)
            {
                nud31.Enabled = nud32.Enabled = tb3.Enabled = false;
            }

            if (((CheckBox)sender) == chk4 && ((CheckBox)sender).Checked == true)
            {
                nud41.Enabled = nud42.Enabled = tb4.Enabled = true;

            }
            else if (((CheckBox)sender) == chk4 && ((CheckBox)sender).Checked == false)
            {
                nud41.Enabled = nud42.Enabled = tb4.Enabled = false;
            }

            if (((CheckBox)sender) == chk5 && ((CheckBox)sender).Checked == true)
            {
                nud51.Enabled = nud52.Enabled = tb5.Enabled = true;

            }
            else if (((CheckBox)sender) == chk5 && ((CheckBox)sender).Checked == false)
            {
                nud51.Enabled = nud52.Enabled = tb5.Enabled = false;
            }

            if (((CheckBox)sender) == chk6 && ((CheckBox)sender).Checked == true)
            {
                nud61.Enabled = nud62.Enabled = tb6.Enabled = true;

            }
            else if (((CheckBox)sender) == chk6 && ((CheckBox)sender).Checked == false)
            {
                nud61.Enabled = nud62.Enabled = tb6.Enabled = false;
            }

            if (((CheckBox)sender) == chk7 && ((CheckBox)sender).Checked == true)
            {
                nud71.Enabled = nud72.Enabled = tb7.Enabled = true;
            }
            else if (((CheckBox)sender) == chk7 && ((CheckBox)sender).Checked == false)
            {
                nud71.Enabled = nud72.Enabled = tb7.Enabled = false;
            }

            if (((CheckBox)sender) == chk8 && ((CheckBox)sender).Checked == true)
            {
                nud81.Enabled = nud82.Enabled = tb8.Enabled = tbother.Enabled = true;

            }
            else if (((CheckBox)sender) == chk8 && ((CheckBox)sender).Checked == false)
            {
                nud81.Enabled = nud82.Enabled = tb8.Enabled = tbother.Enabled = false;
            }

        }

        private void rdoqf4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoqf4.Checked)
                txtqf4sayer.Enabled = true;
            else
                txtqf4sayer.Enabled = false;
        }

        private void KeyDownforNextTab(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender.GetType() == typeof(NumericUpDown))
                {
                    if (((NumericUpDown)sender) == txtoverdose)
                    {
                        tabControl1.SelectedTab = tbp2;
                        txtqb1.Focus();
                        e.SuppressKeyPress = true;
                    }
                    else if (((NumericUpDown)sender) == txtqc5)
                    {
                        tabControl1.SelectedTab = tbp3;
                        txtqd1.Focus();
                        e.SuppressKeyPress = true;
                    }
                    else if (((NumericUpDown)sender) == txtqe7)
                    {
                        btnAdd.Focus();
                        e.SuppressKeyPress = true;
                    }

                }

                else if (sender.GetType() == typeof(TextBox))
                {
                    if (((TextBox)sender) == txtqb9_3)
                    {
                        tabControl1.SelectedTab = tbp0;
                        txtqc1.Focus();
                        e.SuppressKeyPress = true;
                    }
                }
                else if (sender.GetType() == typeof(ComboBox))
                {
                    if (((ComboBox)sender) == txtqd20)
                    {
                        tabControl1.SelectedTab = tbp4;
                        txtqe1.Focus();
                        e.SuppressKeyPress = true;
                    }
                }
               
            }
        }
       

           //int count = 0;
           // foreach (Control tabpage in this.tabControl1.TabPages)
           //     foreach (Control g in tabpage.Controls)
           //         foreach (Control p in g.Controls)
           //             if (p.GetType() == typeof(Panel) && ((Panel)p) != pnl24 && ((Panel)p) != pnl25 && ((Panel)p) != pnl26)
           //             {
           //                 foreach (Control t in p.Controls)
           //                     if ((t.GetType() == typeof(TextBox) || t.GetType() == typeof(NumericUpDown) || t.GetType() == typeof(ComboBox)) && t.Name.Substring(0, 3) == "txt")
           //                     {
           //                         temp += t.Name.Substring(3)+" ,";
           //                     }
           //             }
           //             else if (p.GetType() == typeof(Panel) && ((Panel)p) == pnl24)
           //             {
           //                 foreach (Control t in p.Controls)
           //                     if (t.GetType() == typeof(RadioButton))
           //                     {
           //                         if (((RadioButton)t).Checked && ((RadioButton)t) != rdoqf4)
           //                         {
           //                             count++;
           //                             break;
           //                         }
           //                         else if (((RadioButton)t).Checked && ((RadioButton)t) == rdoqf4)
           //                         {
           //                             count++;
           //                             break;
           //                         }
           //                     }
           //             }

           //             else if (p.GetType() == typeof(Panel) && ((Panel)p) == pnl25)
           //             {
           //                 foreach (Control t in p.Controls)
           //                     if (t.GetType() == typeof(RadioButton))
           //                     {
           //                         if (((RadioButton)t).Checked)
           //                         {
           //                             count++;
           //                             break;
           //                         }
           //                     }
           //             }
           //             else if (p.GetType() == typeof(Panel) && ((Panel)p) == pnl26)
           //             {
           //                 foreach (Control t in p.Controls)
           //                     if (t.GetType() == typeof(RadioButton))
           //                     {
           //                         if (((RadioButton)t).Checked)
           //                         {
           //                             count++;
           //                             break;
           //                         }
           //                     }
           //             }

           // MessageBox.Show(count.ToString());
         
    }
}