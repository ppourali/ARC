using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Mehr.Presentation_Layers
{
    public partial class frmMosahebehEdit : Form
    {
        DataTable datat = new DataTable();

        public frmMosahebehEdit()
        {
            InitializeComponent();
        }


        private void frmMosahebehEdit_Load(object sender, EventArgs e)
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


            System.Globalization.CultureInfo inp = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(inp);

            grpinfo_box.Focus();
            txtCode.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            # region UPDATE MOS_LIST
            // Inserting the Data to the DataBase  mos_list//
            mos_list ml = new mos_list();
            ml.code = long.Parse(txtCode.Text);
            ml.mos_date = txtmos_date.Text;
            ml.mos_name = txtmos_name.Text;
            ml.mos_semat = txtmos_semat.Text;
            ml.id = txtid.Text;
            ml.Update();
            // End of Inserting Data to the DataBase//
            # endregion

            #region UPDATE MAP_A
            map_a ma = new map_a();
            ma.code = long.Parse(txtCode.Text);
            ma.Delete();
            
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

            # region UPDATE MAP_BtoG

            // Inserting the Data to the DataBase MAP_BtoG //
            MAP_BtoG map = new MAP_BtoG();
            map.code = long.Parse(txtCode.Text);

            map.qoverdose = txtqoverdose.Value.ToString();

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
            map.qf2 = txtqf2.Value.ToString();
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


            map.qg1 = txtqg1.Value.ToString();
            map.qg2 = txtqg2.Value.ToString();
            map.qg3 = txtqg3.Value.ToString();

            map.Update();
            // End of Inserting Data to the DataBase

            #endregion

            #region UPDATE MAP_HISTORY
            map_history mh = new map_history();
            mh.code = long.Parse(txtCode.Text);
            mh.Delete();

            foreach (DataGridViewRow dr in grdMap_history.Rows)
            {
                if (dr.Cells["masrafi_type"].Value != null && dr.Cells["masrafi_type"].Value.ToString().Trim() != "")
                {
                    mh.id = txtid.Text;
                    mh.masrafi_type = dr.Cells["masrafi_type"].Value.ToString();
                    mh.start_age = dr.Cells["start_age"].Value.ToString();
                    mh.rooz = dr.Cells["rooz"].Value.ToString();
                    mh.masraf_life = dr.Cells["masraf_life"].Value.ToString();
                    mh.tarigheh = dr.Cells["tarigheh"].Value.ToString();
                    mh.Add();
                }
            }
            #endregion

            
            MessageBox.Show("عملیات ویرایش اطلاعات مصاحبه با موفقیت انجام شد");
            this.Close();
            //}
            //catch
            //{
            //    MessageBox.Show("درج اطلاعات مصاحبه با مشکل مواجه گریدید. لطفا اطلاعات ورودی را مجددا بررسی نمایید");
            //}
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextChanged_Action(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                txtCode.Text = "0000";
                txtCode.SelectAll();
                txtCode.Focus();
            }

            if (txtCode.Text == "" || txtid.Text == "" || txtname.Text.Trim() == "" || txtmos_name.Text.Trim() == "" || txtmos_semat.Text.Trim() == "" || !txtmos_date.MaskCompleted)
                btnSave.Enabled = false;
            else
            {
                btnSave.Enabled = true;
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
            //if (txtid.Text.Trim() != "")
                //txtid.Text = string.Format("{0:000000000000000}", Convert.ToDecimal(txtid.Text));
        }

        public void idsearch_Click(object sender, EventArgs e)
        {
            mos_list ml = new mos_list();
            ml.code = long.Parse(txtCode.Text);

            DataTable mosdt = ml.Selectforedit();
            if (mosdt.Rows.Count == 0)
            {
                MessageBox.Show("در ویرایش مصاحبه با این مشخصه مشکلی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = new Sicks().Search("select name, father_name, home from sicks where (id=N'" + mosdt.Rows[0]["id"].ToString() + "')");
                // Clear any previous bindings & Add new bindings to the DataView object...
                txtid.Text = mosdt.Rows[0]["id"].ToString();
                txtmos_name.Text = mosdt.Rows[0]["mos_name"].ToString();
                txtmos_semat.Text = mosdt.Rows[0]["mos_semat"].ToString();
                txtmos_date.Text = mosdt.Rows[0]["mos_date"].ToString();

                txtname.Text = dt.Rows[0]["name"].ToString();
                txtfather_name.Text = dt.Rows[0]["father_name"].ToString();
                txthome.Text = dt.Rows[0]["home"].ToString();
                // End of Clearing & Adding of Controls Binding


                FillDatasetAndView();

                tabControl1.Enabled = true;

                txtid.Enabled = false;
                txtCode.Enabled = false;
                txtname.Enabled = false;
                txtfather_name.Enabled = false;
                txthome.Enabled = false;
                idsearch.Enabled = false;
            }

            //else
            //{
            //    MessageBox.Show("شماره پرونده در سیستم موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void KeyDownforSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                idsearch_Click(null, null);
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
            if (((CheckBox)sender) == chk1 && ((CheckBox)sender).Checked == true)
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
                    if (((NumericUpDown)sender) == txtqoverdose)
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
                        btnSave.Focus();
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

        private void FillDatasetAndView()
        {
            #region MAP_A BINDINGS
            map_a mapa = new map_a();
            mapa.code = long.Parse(txtCode.Text);

            DataTable mapadt = mapa.Selectforedit();
            for (int i = 0; i < mapadt.Rows.Count; i++)
            {
                if (chk1.Text.Trim() == mapadt.Rows[i]["masrafi_type"].ToString().Trim())
                {
                    chk1.Checked = true;
                    nud11.Value = decimal.Parse(mapadt.Rows[i]["rooz"].ToString());
                    nud12.Value = decimal.Parse(mapadt.Rows[i]["mizan"].ToString());
                    tb1.Text = mapadt.Rows[i]["tarigheh"].ToString();
                }

                if (chk2.Text.Trim() == mapadt.Rows[i]["masrafi_type"].ToString().Trim())
                {
                    chk2.Checked = true;
                    nud21.Value = decimal.Parse(mapadt.Rows[i]["rooz"].ToString());
                    nud22.Value = decimal.Parse(mapadt.Rows[i]["mizan"].ToString());
                    tb2.Text = mapadt.Rows[i]["tarigheh"].ToString();
                }
                if (chk3.Text.Trim() == mapadt.Rows[i]["masrafi_type"].ToString().Trim())
                {
                    chk3.Checked = true;
                    nud31.Value = decimal.Parse(mapadt.Rows[i]["rooz"].ToString());
                    nud32.Value = decimal.Parse(mapadt.Rows[i]["mizan"].ToString(),System.Globalization.NumberStyles.AllowDecimalPoint);
                    tb3.Text = mapadt.Rows[i]["tarigheh"].ToString();
                }
                if (chk4.Text.Trim() == mapadt.Rows[i]["masrafi_type"].ToString().Trim())
                {
                    chk4.Checked = true;
                    nud41.Value = decimal.Parse(mapadt.Rows[i]["rooz"].ToString());
                    nud42.Value = decimal.Parse(mapadt.Rows[i]["mizan"].ToString());
                    tb4.Text = mapadt.Rows[i]["tarigheh"].ToString();
                }
                if (chk5.Text.Trim() == mapadt.Rows[i]["masrafi_type"].ToString().Trim())
                {
                    chk5.Checked = true;
                    nud51.Value = decimal.Parse(mapadt.Rows[i]["rooz"].ToString());
                    nud52.Value = decimal.Parse(mapadt.Rows[i]["mizan"].ToString());
                    tb5.Text = mapadt.Rows[i]["tarigheh"].ToString();
                }
                if (chk6.Text.Trim() == mapadt.Rows[i]["masrafi_type"].ToString().Trim())
                {
                    chk6.Checked = true;
                    nud61.Value = decimal.Parse(mapadt.Rows[i]["rooz"].ToString());
                    nud62.Value = decimal.Parse(mapadt.Rows[i]["mizan"].ToString());
                    tb6.Text = mapadt.Rows[i]["tarigheh"].ToString();
                }
                if (chk7.Text.Trim() == mapadt.Rows[i]["masrafi_type"].ToString().Trim())
                {
                    chk7.Checked = true;
                    nud71.Value = decimal.Parse(mapadt.Rows[i]["rooz"].ToString());
                    nud72.Value = decimal.Parse(mapadt.Rows[i]["mizan"].ToString());
                    tb7.Text = mapadt.Rows[i]["tarigheh"].ToString();
                }

                else if (mapadt.Rows[i]["masrafi_type"].ToString().Trim() != chk1.Text && mapadt.Rows[i]["masrafi_type"].ToString().Trim() != chk2.Text && mapadt.Rows[i]["masrafi_type"].ToString().Trim() != chk3.Text
                      && mapadt.Rows[i]["masrafi_type"].ToString().Trim() != chk4.Text && mapadt.Rows[i]["masrafi_type"].ToString().Trim() != chk5.Text && mapadt.Rows[i]["masrafi_type"].ToString().Trim() != chk6.Text
                      && mapadt.Rows[i]["masrafi_type"].ToString().Trim() != chk7.Text)
                {
                    chk8.Checked = true;
                    tbother.Text = mapadt.Rows[i]["masrafi_type"].ToString().Trim();
                    nud81.Value = decimal.Parse(mapadt.Rows[i]["rooz"].ToString());
                    nud82.Value = decimal.Parse(mapadt.Rows[i]["mizan"].ToString());
                    tb8.Text = mapadt.Rows[i]["tarigheh"].ToString();

                }
            }


            # endregion

            # region MAP_BtoG BINDINGS
            MAP_BtoG mpbg = new MAP_BtoG();
            mpbg.code = long.Parse(txtCode.Text);
            datat = mpbg.Selectforedit();


            foreach (Control tabpage in this.tabControl1.TabPages)
                foreach (Control g in tabpage.Controls)
                    foreach (Control p in g.Controls)
                        if (p.GetType() == typeof(Panel) && ((Panel)p) != pnl24 && ((Panel)p) != pnl25 && ((Panel)p) != pnl26)
                        {
                            foreach (Control t in p.Controls)
                                if ((t.GetType() == typeof(TextBox) || t.GetType() == typeof(ComboBox)) && t.Name.Substring(0, 3) == "txt")
                                {
                                    //t.DataBindings.Clear();
                                    //t.DataBindings.Add("Text", datat, t.Name.Substring(3));
                                    t.Text = datat.Rows[0][t.Name.Substring(3)].ToString();
                                }
                                else if (t.GetType() == typeof(NumericUpDown) && t.Name.Substring(0, 3) == "txt")
                                {
                                    //    t.DataBindings.Clear();
                                    //    t.DataBindings.Add("Value", datat, t.Name.Substring(3));
                                    t.Text = datat.Rows[0][t.Name.Substring(3)].ToString();
                                }
                        }
                        else if (p.GetType() == typeof(Panel) && ((Panel)p) == pnl24)
                        {
                            foreach (Control t in p.Controls)
                                if (t.GetType() == typeof(RadioButton))
                                {
                                    rdoqf4.Checked = true;
                                    txtqf4sayer.Text = datat.Rows[0]["qf4"].ToString();

                                    if (((RadioButton)t).Text.Trim() == datat.Rows[0]["qf4"].ToString().Trim())
                                    {
                                        ((RadioButton)t).Checked = true;
                                        txtqf4sayer.Text = "";
                                        break;
                                        
                                    }

                                }
                        }

                        else if (p.GetType() == typeof(Panel) && ((Panel)p) == pnl25)
                        {
                            foreach (Control t in p.Controls)
                                if (t.GetType() == typeof(RadioButton))
                                {
                                    if (((RadioButton)t).Text.Trim() == datat.Rows[0]["qf5"].ToString().Trim())
                                    {
                                        ((RadioButton)t).Checked = true;
                                        break;
                                    }
                                }
                        }
                        else if (p.GetType() == typeof(Panel) && ((Panel)p) == pnl26)
                        {
                            foreach (Control t in p.Controls)
                                if (t.GetType() == typeof(RadioButton))
                                {
                                    if (((RadioButton)t).Text.Trim() == datat.Rows[0]["qf6"].ToString().Trim())
                                    {
                                        ((RadioButton)t).Checked = true;
                                        break;
                                       
                                    }
                                }
                        }

            #endregion

            #region MAP_HISTORY BINDINGS
            map_history mh = new map_history();
            mh.code = long.Parse(txtCode.Text);

            DataTable hisdt = mh.Selectforedit();
            grdMap_history.AutoGenerateColumns = false;
            grdMap_history.DataSource = hisdt;

            grdMap_history.Columns[0].DataPropertyName = "masrafi_type";
            grdMap_history.Columns[1].DataPropertyName = "start_age";
            grdMap_history.Columns[2].DataPropertyName = "rooz";
            grdMap_history.Columns[3].DataPropertyName = "masraf_life";
            grdMap_history.Columns[4].DataPropertyName = "tarigheh";

            # endregion
        }


        private void txtqg3_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    # region UPDATE MAP_BtoG

        //    // Inserting the Data to the DataBase MAP_BtoG //
        //    MAP_BtoG map = new MAP_BtoG();
        //    map.id = txtid.Text;

        //    map.qoverdose = txtqoverdose.Value.ToString();

        //    map.qb1 = txtqb1.Value.ToString();
        //    map.qb2_1 = txtqb2_1.Value.ToString();
        //    map.qb2_2 = txtqb2_2.Value.ToString();
        //    map.qb2_3 = txtqb2_3.Value.ToString();
        //    map.qb2_4 = txtqb2_4.Value.ToString();
        //    map.qb3 = txtqb3.Text.ToString();
        //    map.qb4 = txtqb4.Text.ToString();
        //    map.qb5 = txtqb5.Text.ToString();
        //    map.qb6 = txtqb6.Text.ToString();
        //    map.qb7 = txtqb7.Text.ToString();
        //    map.qb8 = txtqb8.Text.ToString();
        //    map.qb9_1 = txtqb9_1.Value.ToString();
        //    map.qb9_2 = txtqb9_2.Text.ToString();
        //    map.qb9_3 = txtqb9_3.Text.ToString();

        //    map.qc1 = txtqc1.Value.ToString();
        //    map.qc2 = txtqc2.Value.ToString();
        //    map.qc3 = txtqc3.Value.ToString();
        //    map.qc4 = txtqc4.Value.ToString();
        //    map.qc5 = txtqc5.Value.ToString();

        //    map.qd1 = txtqd1.Text.ToString();
        //    map.qd2 = txtqd2.Text.ToString();
        //    map.qd3 = txtqd3.Text.ToString();
        //    map.qd4 = txtqd4.Text.ToString();
        //    map.qd5 = txtqd5.Text.ToString();
        //    map.qd6 = txtqd6.Text.ToString();
        //    map.qd7 = txtqd7.Text.ToString();
        //    map.qd8 = txtqd8.Text.ToString();
        //    map.qd9 = txtqd9.Text.ToString();
        //    map.qd10 = txtqd10.Text.ToString();
        //    map.qd11 = txtqd11.Text.ToString();
        //    map.qd12 = txtqd12.Text.ToString();
        //    map.qd13 = txtqd13.Text.ToString();
        //    map.qd14 = txtqd14.Text.ToString();
        //    map.qd15 = txtqd15.Text.ToString();
        //    map.qd16 = txtqd16.Text.ToString();
        //    map.qd17 = txtqd17.Text.ToString();
        //    map.qd18 = txtqd18.Text.ToString();
        //    map.qd19 = txtqd19.Text.ToString();
        //    map.qd20 = txtqd20.Text.ToString();

        //    map.qe1 = txtqe1.Value.ToString();
        //    map.qe2 = txtqe2.Value.ToString();
        //    map.qe3 = txtqe3.Value.ToString();
        //    map.qe4 = txtqe4.Value.ToString();
        //    map.qe5 = txtqe5.Value.ToString();
        //    map.qe6 = txtqe6.Value.ToString();
        //    map.qe7 = txtqe7.Value.ToString();

        //    map.qf1 = txtqf1.Text.Trim();
        //    map.qf2 = txtqf2.Value.ToString();
        //    map.qf3 = txtqf3.Text.Trim();
        //    foreach (Control t in pnl24.Controls)
        //    {
        //        if (t.GetType() == typeof(RadioButton))
        //        {
        //            if (((RadioButton)t).Checked && ((RadioButton)t) != rdoqf4)
        //            {
        //                map.qf4 = t.Text;
        //                break;
        //            }
        //            else if (((RadioButton)t).Checked && ((RadioButton)t) == rdoqf4)
        //            {
        //                map.qf4 = txtqf4sayer.Text;
        //                break;
        //            }
        //        }
        //    }

        //    foreach (Control t in pnl25.Controls)
        //    {
        //        if (t.GetType() == typeof(RadioButton))
        //        {
        //            if (((RadioButton)t).Checked)
        //            {
        //                map.qf5 = t.Text;
        //                break;
        //            }
        //        }

        //    }

        //    foreach (Control t in pnl26.Controls)
        //    {
        //        if (t.GetType() == typeof(RadioButton))
        //        {
        //            if (((RadioButton)t).Checked)
        //            {
        //                map.qf6 = t.Text;
        //                break;
        //            }
        //        }

        //    }


        //    map.qg1 = txtqg1.Value.ToString();
        //    map.qg2 = txtqg2.Value.ToString();
        //    map.qg3 = txtqg3.Value.ToString();

        //    map.Update();
        //    // End of Inserting Data to the DataBase

        //    #endregion

        //}

    }
}