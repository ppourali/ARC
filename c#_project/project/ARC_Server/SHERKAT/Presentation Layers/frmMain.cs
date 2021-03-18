using Mehr.Business_Layers;
using Mehr.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mehr.Presentation_Layers
{
    public partial class frmMain : Form
    {
        frmCalender fc = new frmCalender();

        public frmMain()
        {
            InitializeComponent();

            try
            {
                if (Properties.Settings.Default.backname.Equals("bg1"))
                    this.BackgroundImage = global::Mehr.Properties.Resources.bg1;
                else if (Properties.Settings.Default.backname.Equals("bg2"))
                    this.BackgroundImage = global::Mehr.Properties.Resources.bg2;
                else if (Properties.Settings.Default.backname.Equals("bg3"))
                    this.BackgroundImage = global::Mehr.Properties.Resources.bg3;
                else if (Properties.Settings.Default.backname.Equals("bg4"))
                    this.BackgroundImage = global::Mehr.Properties.Resources.bg4;
                else if (Properties.Settings.Default.backname.Equals("bg5"))
                    this.BackgroundImage = global::Mehr.Properties.Resources.bg5;
                else
                {
                    this.BackgroundImage = global::Mehr.Properties.Resources.bg1;
                    Properties.Settings.Default.backname = "bg1";
                    Properties.Settings.Default.Save();
                }
            }
            catch
            {
                this.BackgroundImage = global::Mehr.Properties.Resources.bg1;
                Properties.Settings.Default.backname = "bg1";
                Properties.Settings.Default.Save();
            }

            menuStrip1.Hide();
            toolStrip1.Hide();

        }

        private bool bazrasmode = false;

        

        private InputLanguage GetFarsiLanguage()
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.LayoutName.ToLower().Contains("farsi") || lang.LayoutName.ToLower().Contains("persian"))
                    return lang;
            }

            return null;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateUtils.Georgian();
            toolStripStatusLabel2.Text = DateUtils.Shamsi();

            fc.MdiParent = this;
            fc.cur_date = DateUtils.Shamsi();
            Point p = new Point(20, this.Height - 320);
            fc.Location = p;
            fc.Show();

            darmangah sh = new darmangah();
            toolStripStatusLabel3.Text = "مرکز مشاوره و درمان سوء مصرف مواد " + sh.Select().Rows[0]["name"].ToString();
            this.Text = toolStripStatusLabel3.Text;


            acc acnt = new acc();
            if (acnt.checkpass().Rows.Count > 0)
            {
                frmLogin frl = new frmLogin();
                frl.ShowDialog();

                if (Program.user_semat.Trim() == "بازرس")
                {
                    bazrasVorood();
                }
            }
            InputLanguage lang = GetFarsiLanguage();
            if (lang == null)
                MessageBox.Show("تنظیمات صفجه کلید ویندوز فاقد کیبورد فارسی می باشد، برای کسب اطالاعات بیشتر با پشتیبانی تماس بگیرید");

            InputLanguage.CurrentInputLanguage = lang;

            if (!TimeZone.CurrentTimeZone.StandardName.ToUpper().Contains("IRAN"))
            {
                MessageBox.Show("تنظیمات زمان سیستم صحیح نمی باشد، منطقه ی زمانی (Time Zone) سیستم باید بر روی Tehran تنظیم شود، برای کسب اطالاعات بیشتر با پشتیبانی تماس بگیرید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }

            setShortCutKeysForBazras();

            bazrasVorood();

            if (Program.isServerMachine)
                MI_datas.Enabled = true;
            else
                MI_datas.Enabled = false;

            menuStrip1.Show();
            toolStrip1.Show();
        }

        private void setShortCutKeysForBazras()
        {
            Keys keyToAssign;

            try
            {
                Gen_settings te = new Gen_settings();
                DataTable datat = te.Select();

                string[] keys = datat.Rows[0]["BazrasKey"].ToString().Split('+');

                if (keys.Length > 1)
                {
                    keyToAssign = Keys.Control | (Keys)Enum.Parse(typeof(Keys), keys[1]);
                }
                else
                {
                    keyToAssign = (Keys)Enum.Parse(typeof(Keys), keys[0]);
                }
            }
            catch
            {
                keyToAssign = (Keys)Enum.Parse(typeof(Keys), "F12");
            }

            ورودبازرسToolStripMenuItem.ShortcutKeys = keyToAssign;

        }

        private void bazrasVorood()
        {
            Cursor.Current = Cursors.WaitCursor;

            Program.user_semat = "بازرس";

            toolStripMenuItem6.Visible = false;

            نمایشوضعیتبیمارانToolStripMenuItem.Visible = false;

            تجویزپزشکToolStripMenuItem.Visible = false;
            تجویزToolStripMenuItem.Visible = false;
            دفترمخدربراساستجویزپزشکToolStripMenuItem.Visible = false;
            عدممراجعهبیمارانToolStripMenuItem.Visible = false;
            toolStripSeparator2.Visible = false;

            آمارکلیروزانهToolStripMenuItem.Visible = false;
            toolStripMenuItem16.Visible = false;
            بدستآوردنResultدرآخرروزToolStripMenuItem.Visible = false;

            toolStripSeparator5.Visible = false;
            toolStripButton2.Visible = false;
            toolStripSeparator7.Visible = false;
            toolStripButton6.Visible = false;
            toolStripSeparator12.Visible = false;
            toolStripButton7.Visible = false;

            آمارماهانهداخلیToolStripMenuItem.Visible = false;
            آمارماهانهبوپرنورفینداخلیToolStripMenuItem.Visible = false;
            آمارماهانهسوباکسونToolStripMenuItem.Visible = false;
            فرمپیگیریبیمارانToolStripMenuItem.Visible = false;

            MI_users.Visible = false;


            this.ثبتدستورپزشکبرایبیمارToolStripMenuItem.Click += new System.EventHandler(this.ثبتدستورپزشکبرایبیمارToolStripMenuItem_Click);
            this.نمایشتاریخچهدستوراتپزشکToolStripMenuItem.Click += new System.EventHandler(this.نمایشتاریخچهدستوراتپزشکToolStripMenuItem_Click);
            this.ثبتآزمایشبیمارToolStripMenuItem.Click += new System.EventHandler(this.ثبتآزمایشبیمارToolStripMenuItem_Click);
            this.نمایشلیستآزمایشاتبیمارانToolStripMenuItem.Click += new System.EventHandler(this.نمایشلیستآزمایشاتبیمارانToolStripMenuItem_Click);
            this.ثبتفرمروانشناسToolStripMenuItem.Click += new System.EventHandler(this.ثبتفرمروانشناسToolStripMenuItem_Click);
            this.نمایشنظراتروانشاسدرموردبیمارToolStripMenuItem.Click += new System.EventHandler(this.نمایشنظراتروانشاسدرموردبیمارToolStripMenuItem_Click);
            this.ثبتپیگیریانجامشدهبرایبیمارToolStripMenuItem.Click += new System.EventHandler(this.ثبتپیگیریانجامشدهبرایبیمارToolStripMenuItem_Click);
            this.نمایشلیستپیگیریبیمارانToolStripMenuItem.Click += new System.EventHandler(this.نمایشلیستپیگیریبیمارانToolStripMenuItem_Click);

            this.ثبتدستورپزشکبرایبیمارToolStripMenuItem.DropDownItems.Clear();
            this.نمایشتاریخچهدستوراتپزشکToolStripMenuItem.DropDownItems.Clear();
            this.ثبتآزمایشبیمارToolStripMenuItem.DropDownItems.Clear();
            this.نمایشلیستآزمایشاتبیمارانToolStripMenuItem.DropDownItems.Clear();
            this.ثبتفرمروانشناسToolStripMenuItem.DropDownItems.Clear();
            this.نمایشنظراتروانشاسدرموردبیمارToolStripMenuItem.DropDownItems.Clear();
            this.ثبتپیگیریانجامشدهبرایبیمارToolStripMenuItem.DropDownItems.Clear();
            this.نمایشلیستپیگیریبیمارانToolStripMenuItem.DropDownItems.Clear();

            عملیاتمرتبطبالیستسیاهبیمارانToolStripMenuItem.Visible = false;
            toolStripSeparator24.Visible = false;

            toolStripSeparator17.Visible = false;
            نمایشلیستمراجعینروزToolStripMenuItem.Visible = false;
            نمودارروندمراجعهبیماراندرماههایمختلفسالToolStripMenuItem.Visible = false;
            نمودارگزارشمیزانمصرفداروهاToolStripMenuItem.Visible = false;
            نموداردرآمدToolStripMenuItem.Visible = false;
            toolStripMenuItem14.Visible = false;
            toolStripSeparator4.Visible = false;

            صدورقبضToolStripMenuItem.Visible = false;
            نمایشلیستقبوضToolStripMenuItem.Visible = false;
            ویرایشقبوضToolStripMenuItem.Visible = false;
            toolStripSeparator19.Visible = false;
            دفترمعیینبیمارانToolStripMenuItem1.Visible = false;
            ghabzJoinTajvizToolStripMenuItem.Visible = false;
            پیگیریمتوسطهزینهیبیمارانToolStripMenuItem.Visible = false;
            toolStripSeparator20.Visible = false;
            toolStripButton4.Visible = false;

            toolStripMenuItem12.Visible = false;
            ورودبازرسToolStripMenuItem.Visible = false;
            نمایشریزعملیاتکاربرانToolStripMenuItem.Visible = false;
            تعویضکاربرToolStripMenuItem.Visible = false;
            toolStripSeparator21.Visible = false;

            toolStripSeparator23.Visible = false;
            ثبتارزیابیوضعیتبیمارToolStripMenuItem.Visible = false;
            نمایشارزیابیهایبیمارانToolStripMenuItem.Visible = false;
            تعیینمقدارتخفیفبراساسنمراتToolStripMenuItem.Visible = false;
            toolStripMenuItem15.Visible = false;

            bazrasmode = true;
        }

        private void bazrasKhorooj()
        {
            Cursor.Current = Cursors.WaitCursor;

            acc acnt = new acc();
            DataTable dt = new DataTable();
            dt = acnt.Search("select semat from acc where (user_code=N'" + Program.user_code + "')");

            if (dt.Rows.Count > 0)
            {
                //Program.user_code = dt.Rows[0]["user_code"].ToString();
                //Program.user_name = dt.Rows[0]["fname"].ToString() + " " + dt.Rows[0]["lname"].ToString();
                Program.user_semat = dt.Rows[0]["semat"].ToString();
            }

            toolStripMenuItem6.Visible = true;

            نمایشوضعیتبیمارانToolStripMenuItem.Visible = true;

            تجویزپزشکToolStripMenuItem.Visible = true;
            تجویزToolStripMenuItem.Visible = true;
            دفترمخدربراساستجویزپزشکToolStripMenuItem.Visible = true;
            عدممراجعهبیمارانToolStripMenuItem.Visible = true;
            toolStripSeparator2.Visible = true;

            آمارکلیروزانهToolStripMenuItem.Visible = true;
            toolStripMenuItem16.Visible = true;
            بدستآوردنResultدرآخرروزToolStripMenuItem.Visible = true;

            toolStripSeparator5.Visible = true;
            toolStripButton2.Visible = true;
            toolStripSeparator7.Visible = true;
            toolStripButton6.Visible = true;
            toolStripSeparator12.Visible = true;
            toolStripButton7.Visible = true;

            آمارماهانهداخلیToolStripMenuItem.Visible = true;
            آمارماهانهبوپرنورفینداخلیToolStripMenuItem.Visible = true;
            آمارماهانهسوباکسونToolStripMenuItem.Visible = true;
            فرمپیگیریبیمارانToolStripMenuItem.Visible = true;

            MI_users.Visible = true;


            this.ثبتدستورپزشکبرایبیمارToolStripMenuItem.Click -= new System.EventHandler(this.ثبتدستورپزشکبرایبیمارToolStripMenuItem_Click);
            this.نمایشتاریخچهدستوراتپزشکToolStripMenuItem.Click -= new System.EventHandler(this.نمایشتاریخچهدستوراتپزشکToolStripMenuItem_Click);
            this.ثبتآزمایشبیمارToolStripMenuItem.Click -= new System.EventHandler(this.ثبتآزمایشبیمارToolStripMenuItem_Click);
            this.نمایشلیستآزمایشاتبیمارانToolStripMenuItem.Click -= new System.EventHandler(this.نمایشلیستآزمایشاتبیمارانToolStripMenuItem_Click);
            this.ثبتفرمروانشناسToolStripMenuItem.Click -= new System.EventHandler(this.ثبتفرمروانشناسToolStripMenuItem_Click);
            this.نمایشنظراتروانشاسدرموردبیمارToolStripMenuItem.Click -= new System.EventHandler(this.نمایشنظراتروانشاسدرموردبیمارToolStripMenuItem_Click);
            this.ثبتپیگیریانجامشدهبرایبیمارToolStripMenuItem.Click -= new System.EventHandler(this.ثبتپیگیریانجامشدهبرایبیمارToolStripMenuItem_Click);
            this.نمایشلیستپیگیریبیمارانToolStripMenuItem.Click -= new System.EventHandler(this.نمایشلیستپیگیریبیمارانToolStripMenuItem_Click);

            this.ثبتدستورپزشکبرایبیمارToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.دفتریToolStripMenuItem,
            this.واقعیToolStripMenuItem});

            this.نمایشتاریخچهدستوراتپزشکToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.دفتریToolStripMenuItem1,
            this.واقعیToolStripMenuItem1});

            this.ثبتآزمایشبیمارToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.دفتریToolStripMenuItem2,
            this.واقعیToolStripMenuItem2});

            this.نمایشلیستآزمایشاتبیمارانToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.دفتریToolStripMenuItem3,
            this.واقعیToolStripMenuItem3});

            this.ثبتفرمروانشناسToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.دفتریToolStripMenuItem4,
            this.واقعیToolStripMenuItem4});

            this.نمایشنظراتروانشاسدرموردبیمارToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.دفتریToolStripMenuItem5,
            this.واقعیToolStripMenuItem5});

            this.ثبتپیگیریانجامشدهبرایبیمارToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.دفتریToolStripMenuItem6,
            this.واقعیToolStripMenuItem6});

            this.نمایشلیستپیگیریبیمارانToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.دفتریToolStripMenuItem7,
            this.واقعیToolStripMenuItem7});

            عملیاتمرتبطبالیستسیاهبیمارانToolStripMenuItem.Visible = true;
            toolStripSeparator24.Visible = true;

            toolStripSeparator17.Visible = true;
            نمایشلیستمراجعینروزToolStripMenuItem.Visible = true;
            نمودارروندمراجعهبیماراندرماههایمختلفسالToolStripMenuItem.Visible = true;
            نمودارگزارشمیزانمصرفداروهاToolStripMenuItem.Visible = true;
            نموداردرآمدToolStripMenuItem.Visible = true;
            toolStripMenuItem14.Visible = true;
            toolStripSeparator4.Visible = true;

            صدورقبضToolStripMenuItem.Visible = true;
            نمایشلیستقبوضToolStripMenuItem.Visible = true;
            ویرایشقبوضToolStripMenuItem.Visible = true;
            toolStripSeparator19.Visible = true;
            دفترمعیینبیمارانToolStripMenuItem1.Visible = true;
            ghabzJoinTajvizToolStripMenuItem.Visible = true;
            پیگیریمتوسطهزینهیبیمارانToolStripMenuItem.Visible = true;
            toolStripSeparator20.Visible = true;
            toolStripButton4.Visible = true;

            toolStripMenuItem12.Visible = true;
            ورودبازرسToolStripMenuItem.Visible = true;
            نمایشریزعملیاتکاربرانToolStripMenuItem.Visible = true;
            تعویضکاربرToolStripMenuItem.Visible = true;
            toolStripSeparator21.Visible = true;

            toolStripSeparator23.Visible = true;
            ثبتارزیابیوضعیتبیمارToolStripMenuItem.Visible = true;
            نمایشارزیابیهایبیمارانToolStripMenuItem.Visible = true;
            تعیینمقدارتخفیفبراساسنمراتToolStripMenuItem.Visible = true;
            toolStripMenuItem15.Visible = true;

            bazrasmode = false;
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void کاربرانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmChpass))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmChpass fcp = new frmChpass();
                fcp.MdiParent = this;
                fcp.Show();
            }
        }

        private void تهیهیفایلپشتیبانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            saveFileDialog1.InitialDirectory = Application.StartupPath + "\\Backup";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = saveFileDialog1.FileName.ToString();

                try
                {
                    DB back = new DB();
                    back.path = a;
                    back.Backup_name = DateUtils.Shamsi() + "-" + DateTime.Now.ToLongTimeString().Substring(0, 8);
                    back.CreateBackup();

                    new action_logs().Add("تهیه ی فایل پشتیبان از پایگاه داده");
                    MessageBox.Show("تهیه فایل پشتیبان با موفقیت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("تهیه فایل پشتیبان با مشکل مواجه شد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void بازیابیازفایلپشتیبانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Backup";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.FileName.ToString();

                frmRestorePassInput fad = new frmRestorePassInput(a);
                fad.restoreAdvance = false;
                fad.ShowDialog();
            }
        }
        



        private void Timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongTimeString();
        }

        private void ثبتاطلاعاتبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSickInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSickInp fsi = new frmSickInp();
                fsi.cur_date = DateUtils.Shamsi();
                fsi.MdiParent = this;
                fsi.Show();
            }

        }
        private void ویرایشاطلاعاتبیمارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSicksEdit))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSicksEdit fse = new frmSicksEdit();
                fse.MdiParent = this;
                fse.Show();
            }

        }

        private void نمایشاطلاعاتبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSicksView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSicksView fsv = new frmSicksView();
                fsv.cur_date = DateUtils.Shamsi();
                fsv.MdiParent = this;
                fsv.Show();
            }
        }

        private void مصاحبهبابیمارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmMosahebehInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmMosahebehInp fmi = new frmMosahebehInp();
                fmi.cur_date = DateUtils.Shamsi();
                fmi.MdiParent = this;
                fmi.Show();
            }
        }


        private void نمایشلیستمصاحبههاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmMosView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmMosView fmv = new frmMosView();
                fmv.cur_date = DateUtils.Shamsi();
                fmv.MdiParent = this;
                fmv.Show();
            }
        }

        private void صدورقبضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzDaryaft))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzDaryaft fgs = new frmGhabzDaryaft();
                fgs.cur_date = DateUtils.Shamsi();
                fgs.MdiParent = this;
                fgs.Show();
            }
        }

        private void نمایشلیستقبوضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzView fgv = new frmGhabzView();
                fgv.cur_date = DateUtils.Shamsi();
                fgv.MdiParent = this;
                fgv.Show();
            }
        }

        private void ویرایشقبوضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzEslah))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzEslah fge = new frmGhabzEslah();
                fge.MdiParent = this;
                fge.Show();
            }
        }

        private void تعریفوثبتداروToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAnbarInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAnbarInp fai = new frmAnbarInp();
                fai.MdiParent = this;
                fai.Show();
            }
        }

        private void نمایشلیستداروهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAnbarView fav = new frmAnbarView();
                fav.MdiParent = this;
                fav.Show();
            }
        }

        private void ثبتداروازفاکتورخریدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmFactorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmFactorInp ffi = new frmFactorInp();
                ffi.MdiParent = this;
                ffi.Show();
            }
        }

        private void نمایشلیستفاکتورهایخریدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmFactorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmFactorView ffv = new frmFactorView();
                ffv.MdiParent = this;
                ffv.Show();
            }
        }

        private void فرمتحویلداروToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTahvilInput))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTahvilInput fti = new frmTahvilInput();
                fti.cur_date = DateUtils.Shamsi();
                fti.MdiParent = this;
                fti.Show();
            }
        }

        private void تاریخچهتحویلداروToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTahvilView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTahvilView ftv = new frmTahvilView();
                ftv.cur_date = DateUtils.Shamsi();
                ftv.MdiParent = this;
                ftv.Show();
            }
        }

        private void چاپامارماهانهمتادونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSelectMet))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSelectMet fsm = new frmSelectMet();
                fsm.MdiParent = this;
                fsm.txtmonth.SelectedIndex = int.Parse(DateUtils.Shamsi().Substring(5, 2)) - 1;
                fsm.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsm.Show();
            }
        }

        private void MI_SHERKAT_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmadddarmangah))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmadddarmangah fad = new frmadddarmangah();
                fad.MdiParent = this;
                fad.Show();
            }
        }

        private void چاپآمارماهانهبوپرنورفینToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSelectBoop))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSelectBoop fsb = new frmSelectBoop();
                fsb.MdiParent = this;
                fsb.txtmonth.SelectedIndex = DateUtils.MonthIndex();
                fsb.txtyear.Value = DateUtils.YearValue();
                fsb.Show();
            }
        }

        private void چاپآمارماهانهسوباکسونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSelectSub))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSelectSub fss = new frmSelectSub();
                fss.MdiParent = this;
                fss.txtmonth.SelectedIndex = int.Parse(DateUtils.Shamsi().Substring(5, 2)) - 1;
                fss.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fss.Show();
            }
        }

        private void تجویزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajvizView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajvizView ftv = new frmTajvizView();
                ftv.cur_date = DateUtils.Shamsi();
                ftv.MdiParent = this;
                ftv.Show();
            }

        }

        private void تجویزپزشکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajvizInput))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajvizInput fti = new frmTajvizInput();
                fti.cur_date = DateUtils.Shamsi();
                fti.MdiParent = this;
                fti.Show();
            }
        }

        private void آمارماهانهداخلیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajvizSelectMet))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajvizSelectMet ftsm = new frmTajvizSelectMet();
                ftsm.MdiParent = this;
                ftsm.txtmonth.SelectedIndex = int.Parse(DateUtils.Shamsi().Substring(5, 2)) - 1;
                ftsm.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                ftsm.Show();
            }
        }

        private void آمارماهانهبوپرنورفینداخلیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajvizSelectBoop))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajvizSelectBoop ftsb = new frmTajvizSelectBoop();
                ftsb.MdiParent = this;
                ftsb.txtmonth.SelectedIndex = int.Parse(DateUtils.Shamsi().Substring(5, 2)) - 1;
                ftsb.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                ftsb.Show();
            }
        }

        private void آمارماهانهسوباکسونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajvizSelectSub))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajvizSelectSub ftss = new frmTajvizSelectSub();
                ftss.MdiParent = this;
                ftss.txtmonth.SelectedIndex = int.Parse(DateUtils.Shamsi().Substring(5, 2)) - 1;
                ftss.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                ftss.Show();
            }
        }

        private void بدستآوردنResultدرآخرروزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmResultView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {

                frmResultView frv = new frmResultView();
                frv.MdiParent = this;
                frv.txtfromdate.Text = DateUtils.Shamsi();
                frv.txttodate.Text = DateUtils.Shamsi();
                frv.btnfilter_Click(null, null);
                frv.Show();
            }
        }

        private void آمارکلیروزانهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAmarKoliView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAmarKoliView fav = new frmAmarKoliView();
                fav.MdiParent = this;
                fav.cur_date = DateUtils.Shamsi();
                fav.txtdate.Text = DateUtils.Shamsi();
                //fav.btnfilter_Click(null, null);
                fav.Show();
            }
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.isServerMachine)
                return;

            DialogResult dr;
            dr = MessageBox.Show("آیا مایل به تهیه ی فایل پشتیبان هستید؟", "اخطار", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (dr == DialogResult.Yes)
            {

                if (System.IO.Directory.Exists(Application.StartupPath + @"\Backup"))
                {
                    string a = Application.StartupPath + "\\Backup\\" + DateUtils.Shamsi().Replace('/', '.') + ".bak";

                    try
                    {
                        DB back = new DB();
                        back.path = a;
                        back.Backup_name = DateUtils.Shamsi() + "-" + DateTime.Now.ToLongTimeString().Substring(0, 8);
                        back.CreateBackup();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("تهیه فایل پشتیبان با مشکل مواجه شد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Backup");
                    string a = Application.StartupPath + "\\Backup\\" + DateUtils.Shamsi().Replace('/', '.') + ".bak";

                    try
                    {
                        DB back = new DB();
                        back.path = a;
                        back.Backup_name = DateUtils.Shamsi() + "-" + DateTime.Now.ToLongTimeString().Substring(0, 8);
                        back.CreateBackup();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("تهیه فایل پشتیبان با مشکل مواجه شد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAnbarView fav = new frmAnbarView();
                fav.MdiParent = this;
                fav.Show();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajvizInput))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajvizInput fti = new frmTajvizInput();
                fti.cur_date = DateUtils.Shamsi();
                fti.MdiParent = this;
                fti.Show();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSickInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSickInp fsi = new frmSickInp();
                fsi.cur_date = DateUtils.Shamsi();
                fsi.MdiParent = this;
                fsi.Show();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzDaryaft))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzDaryaft fgs = new frmGhabzDaryaft();
                fgs.cur_date = DateUtils.Shamsi();
                fgs.MdiParent = this;
                fgs.Show();
            }
        }

        private void بازیابیپیشرفتهاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Backup";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.FileName.ToString();

                frmRestorePassInput fad = new frmRestorePassInput(a);
                fad.restoreAdvance = true;
                fad.ShowDialog();
            }
        }

        private void دفترمعیینبیمارانToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSickHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSickHisView fshv = new frmSickHisView();
                fshv.MdiParent = this;
                fshv.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajAnbarView fav = new frmTajAnbarView();
                fav.MdiParent = this;
                fav.Show();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajAnbarInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajAnbarInp fai = new frmTajAnbarInp();
                fai.MdiParent = this;
                fai.Show();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajFactorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {

                frmTajFactorInp ffi = new frmTajFactorInp();
                ffi.MdiParent = this;
                ffi.Show();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajFactorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajFactorView ffv = new frmTajFactorView();
                ffv.MdiParent = this;
                ffv.Show();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTahvilInput))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTahvilInput fti = new frmTahvilInput();
                fti.cur_date = DateUtils.Shamsi();
                fti.MdiParent = this;
                fti.Show();
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajAnbarInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajAnbarInp fti = new frmTajAnbarInp();
                fti.MdiParent = this;
                fti.Show();
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajAnbarView fav = new frmTajAnbarView();
                fav.MdiParent = this;
                fav.Show();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajFactorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajFactorInp ffi = new frmTajFactorInp();
                ffi.MdiParent = this;
                ffi.Show();
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajFactorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajFactorView ffv = new frmTajFactorView();
                ffv.MdiParent = this;
                ffv.Show();
            }
        }

        private void مصرفیمتادونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmMetDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmMetDaftarShow fmdv = new frmMetDaftarShow();
                fmdv.MdiParent = this;
                fmdv.cur_date = DateUtils.Shamsi();
                fmdv.Show();
            }
        }

        private void مصرفیبوپرنورفینToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmBoopDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmBoopDaftarShow fbdv = new frmBoopDaftarShow();
                fbdv.MdiParent = this;
                fbdv.cur_date = DateUtils.Shamsi();
                fbdv.Show();
            }
        }

        private void مصرفیسوباکسونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSubDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSubDaftarShow fsdv = new frmSubDaftarShow();
                fsdv.MdiParent = this;
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.Show();
            }
        }

        private void مصرفیمتادونToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajMetDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajMetDaftarShow fmdv = new frmTajMetDaftarShow();
                fmdv.MdiParent = this;
                fmdv.Show();
            }
        }

        private void مصرفیبوپرنورفینToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajBoopDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajBoopDaftarShow fbdv = new frmTajBoopDaftarShow();
                fbdv.MdiParent = this;
                fbdv.Show();
            }
        }

        private void مToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajSubDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajSubDaftarShow fsdv = new frmTajSubDaftarShow();
                fsdv.MdiParent = this;
                fsdv.Show();
            }

        }

        private void ویرایشقبوضToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzEslah))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzEslah fsdv = new frmGhabzEslah();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشلیستغائبینبراساستاریخToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAbsentSicksView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAbsentSicksView fsdv = new frmAbsentSicksView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void تغییرنوعکاربریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkErrorHandler neh = new NetworkErrorHandler();
            neh.ShowDialog();
        }

        private void بازگردانیاطلاعاتخامنرمافزارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("آیا از حذف  تمامی اطلاعات پایگاه داده اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;

                darmangah darm = new darmangah();
                darm.RESET();

                MessageBox.Show("انجام عملیات با موفقیت به پایان رسید. لطفا نرم افزار را مجددا راه اندازی نمایید");
                Application.Exit();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmLastTajvizView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmLastTajvizView fsdv = new frmLastTajvizView();
                Point p = new Point(2, this.Height - 500);
                fsdv.Location = p;
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }


        private void ثبتدستورپزشکبرایبیمارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmdastoor_pezeshkInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmdastoor_pezeshkInp fsdv = new frmdastoor_pezeshkInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشتاریخچهدستوراتپزشکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmDastoorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmDastoorView fsdv = new frmDastoorView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void ثبتفرمروانشناسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRavanshenasInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRavanshenasInp fsdv = new frmRavanshenasInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشنظراتروانشاسدرموردبیمارToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRavanshenasView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRavanshenasView fsdv = new frmRavanshenasView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }

        }

        private void ثبتآزمایشبیمارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAzmayeshInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAzmayeshInp fsdv = new frmAzmayeshInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشلیستآزمایشاتبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAzmayeshView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAzmayeshView fsdv = new frmAzmayeshView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void ghabzJoinTajvizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzJoinTajviz))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzJoinTajviz fsdv = new frmGhabzJoinTajviz();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void عدممراجعهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTahvilAdam))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTahvilAdam fsdv = new frmTahvilAdam();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void عدممراجعهبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTajvizAdam))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTajvizAdam fsdv = new frmTajvizAdam();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void نمایشلیستمراجعینروزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTodayComersView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTodayComersView fsdv = new frmTodayComersView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void نموداردرآمدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmIncomePrintViewer))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmIncomePrintViewer fsm = new frmIncomePrintViewer();
                fsm.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsm.Show();
            }
        }

        private void نمودارگزارشمیزانمصرفداروهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmِDarueePrintViewer))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmِDarueePrintViewer fsm = new frmِDarueePrintViewer();
                fsm.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsm.Show();
            }
        }

        private void نمودارروندمراجعهبیماراندرماههایمختلفسالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmNafarPrintViewer))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmNafarPrintViewer fsm = new frmNafarPrintViewer();
                fsm.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsm.Show();
            }
        }

        private void فرمپیگیریبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasrafiPeygiriPrintViewer fppv = new frmMasrafiPeygiriPrintViewer();
            fppv.cur_date = DateUtils.Shamsi();
            fppv.Show();
        }

        //private void نمایشلیستانتخابیجهتانجامامورمرتبطبابیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    bool IsOpen = false;

        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f.GetType() == typeof(frmSelSicksFor))
        //        {
        //            IsOpen = true;
        //            f.Focus();
        //            break;
        //        }
        //    }

        //    if (IsOpen == false)
        //    {
        //        frmSelSicksFor fsm = new frmSelSicksFor();
        //        fsm.MdiParent = this;
        //        fsm.Show();
        //    }
        //}

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmDaftariPeygiriPrintViewer fppv = new frmDaftariPeygiriPrintViewer();
            fppv.cur_date = DateUtils.Shamsi();
            fppv.Show();
        }

        private void ثبتپیگیریانجامشدهبرایبیمارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmPeygiriInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmPeygiriInp fsm = new frmPeygiriInp();
                fsm.MdiParent = this;
                fsm.cur_date = DateUtils.Shamsi();
                fsm.Show();
            }
        }

        private void نمایشلیستپیگیریبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmPeygiriHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmPeygiriHisView fsdv = new frmPeygiriHisView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }

        }

        private void دفتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmdastoor_pezeshkInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmdastoor_pezeshkInp fsdv = new frmdastoor_pezeshkInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void دفتریToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmDastoorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmDastoorView fsdv = new frmDastoorView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void دفتریToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAzmayeshInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAzmayeshInp fsdv = new frmAzmayeshInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void دفتریToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAzmayeshView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAzmayeshView fsdv = new frmAzmayeshView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void دفتریToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRavanshenasInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRavanshenasInp fsdv = new frmRavanshenasInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void دفتریToolStripMenuItem5_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRavanshenasView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRavanshenasView fsdv = new frmRavanshenasView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }

        }

        private void دفتریToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmPeygiriInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmPeygiriInp fsm = new frmPeygiriInp();
                fsm.MdiParent = this;
                fsm.cur_date = DateUtils.Shamsi();
                fsm.Show();
            }
        }

        private void دفتریToolStripMenuItem7_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmPeygiriHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmPeygiriHisView fsdv = new frmPeygiriHisView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }

        }


        private void واقعیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRealdastoor_pezeshkInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRealdastoor_pezeshkInp fsdv = new frmRealdastoor_pezeshkInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void واقعیToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRealDastoorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRealDastoorView fsdv = new frmRealDastoorView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void واقعیToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRealAzmayeshInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRealAzmayeshInp fsdv = new frmRealAzmayeshInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void واقعیToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRealAzmayeshHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRealAzmayeshView fsdv = new frmRealAzmayeshView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void واقعیToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRealRavanshenasInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRealRavanshenasInp fsdv = new frmRealRavanshenasInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void واقعیToolStripMenuItem5_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRealRavanshenasView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRealRavanshenasView fsdv = new frmRealRavanshenasView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }

        }

        private void واقعیToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRealPeygiriInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRealPeygiriInp fsm = new frmRealPeygiriInp();
                fsm.MdiParent = this;
                fsm.cur_date = DateUtils.Shamsi();
                fsm.Show();
            }
        }

        private void واقعیToolStripMenuItem7_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmRealPeygiriHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmRealPeygiriHisView fsdv = new frmRealPeygiriHisView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }

        }

        private void نمایشلیستمراجعینروزدفتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmDaftariTodayComersView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmDaftariTodayComersView fsdv = new frmDaftariTodayComersView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void نمایشلیستToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmDaftariPeygiriPattern))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmDaftariPeygiriPattern fsdv = new frmDaftariPeygiriPattern();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void پیگیریمتوسطهزینهیبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmHazinehPeygiri))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmHazinehPeygiri fsdv = new frmHazinehPeygiri();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void نمایشلیستمختصعدممراجعهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAdamTahvilView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAdamTahvilView fsdv = new frmAdamTahvilView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAdamTajvizView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAdamTajvizView fsdv = new frmAdamTajvizView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void ورودبازرسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bazrasmode == true)
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name.ToString() != "frmCalender")
                        f.Close();
                }
                bazrasKhorooj();
            }
            else if (bazrasmode == false)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name.ToString() != "frmCalender")
                        f.Close();
                }

                bazrasVorood();
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmPeyvast))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmPeyvast fsdv = new frmPeyvast();
                //fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.txtmonth.SelectedIndex = int.Parse(DateUtils.Shamsi().Substring(5, 2)) - 1;
                fsdv.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsdv.Show();
            }
        }

        private void فرمتنظیمدوزتوسطپرستارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTanzimPrintViewer ftpv = new frmTanzimPrintViewer();
            ftpv.cur_date = DateUtils.Shamsi();
            ftpv.Show();
        }

        private void ثبتهزینههایمرکزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmHazinehInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmHazinehInp fsdv = new frmHazinehInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشهزینههایمرکزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmHazinehView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmHazinehView fsdv = new frmHazinehView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmMarkazHazinehPeygiri))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmMarkazHazinehPeygiri fsdv = new frmMarkazHazinehPeygiri();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.Show();
            }

        }

        private void تعویضکاربرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bazrasVorood();
            acc acnt = new acc();
            if (acnt.checkpass().Rows.Count > 0)
            {
                if (this.MdiChildren.Length > 1)
                {
                    DialogResult dr = MessageBox.Show("با تعویض کاربر پنجره های فعال، بسته می شوند، اطمینان دارید؟", "تعویض کاربر", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    if (dr == DialogResult.Yes)
                    {
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name != "frmCalender")
                                f.Close();
                        }
                        frmMain_Load(null, null);
                    }
                }
                else
                {
                    frmMain_Load(null, null);
                }

            }

        }

        private void نمایشریزعملیاتکاربرانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAction_LogsView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAction_LogsView fsdv = new frmAction_LogsView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzJoinTajviz))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzJoinTajviz fsdv = new frmGhabzJoinTajviz();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            Point p = new Point(20, this.Height - 320);
            fc.Location = p;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            string cur_date = DateUtils.Shamsi();

            action_logs acl = new action_logs();
            DataTable maxdatedt = acl.SelectMaxDate();

            if (maxdatedt.Rows.Count > 0)
            {
                string maxdate = maxdatedt.Rows[0]["Max_Date"].ToString().Trim();

                if (string.CompareOrdinal(cur_date, maxdate) < 0)
                {
                    MessageBox.Show("تاریخ سیستم خود را بررسی کنید، مشکلی در هماهنگ سازی تاریخ رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
            }

        }

        private void ثبتارزیابیوضعیتبیمارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAssessmentInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAssessmentInp fsdv = new frmAssessmentInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void نمایشارزیابیهایبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAssessmentView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAssessmentView fsdv = new frmAssessmentView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void تعیینمقدارتخفیفبراساسنمراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmTakhfifInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmTakhfifInp fsdv = new frmTakhfifInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            frmGen_Settings fsdv = new frmGen_Settings(ورودبازرسToolStripMenuItem);
            fsdv.ShowDialog();
        }

        private void عملیاتمرتبطبالیستسیاهبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmBlackListView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmBlackListView fsdv = new frmBlackListView();
                //fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmAmar_RecordsView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmAmar_RecordsView fsdv = new frmAmar_RecordsView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشکلیعملیاتمرتبطبابیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSelSicksFor))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSelSicksFor fsdv = new frmSelSicksFor();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void برداشتداروازگاوصندوقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmParastar_AnbarInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmParastar_AnbarInp fsdv = new frmParastar_AnbarInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void ثبتاطلاعاتمخاطبینToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmContactInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmContactInp fsdv = new frmContactInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشاطلاعاتمخاطبینToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmContactView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmContactView fsdv = new frmContactView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشبانکداروییپرستارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmParastar_AnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmParastar_AnbarView fsdv = new frmParastar_AnbarView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }

        }

        private void نمایشتاریخچهورودوخروجداروازگاوصندوقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmtaj_anbar_historyView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmtaj_anbar_historyView fsdv = new frmtaj_anbar_historyView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشبانکداروییمخاطبینToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmContact_AnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmContact_AnbarView fsdv = new frmContact_AnbarView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void bg1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::Mehr.Properties.Resources.bg1;
            Properties.Settings.Default.backname = "bg1";
            Properties.Settings.Default.Save();
        }

        private void bg2_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::Mehr.Properties.Resources.bg2;
            Properties.Settings.Default.backname = "bg2";
            Properties.Settings.Default.Save();
        }

        private void bg3_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::Mehr.Properties.Resources.bg3;
            Properties.Settings.Default.backname = "bg3";
            Properties.Settings.Default.Save();
        }

        private void bg4_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::Mehr.Properties.Resources.bg4;
            Properties.Settings.Default.backname = "bg4";
            Properties.Settings.Default.Save();
        }

        private void bg5_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::Mehr.Properties.Resources.bg5;
            Properties.Settings.Default.backname = "bg5";
            Properties.Settings.Default.Save();
        }

        private void آمارسالیانهدفتریمتادونToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSelectMetYear))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSelectMetYear fsdv = new frmSelectMetYear();
                fsdv.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void آمارسالیانهبوپرنورفینToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSelectBoopYear))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSelectBoopYear fsdv = new frmSelectBoopYear();
                fsdv.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void آمارسالیانهسوباکسونToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSelectSubYear))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSelectSubYear fsdv = new frmSelectSubYear();
                fsdv.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشوضعیتبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSicksStatusView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSicksStatusView fsdv = new frmSicksStatusView();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void صدورقبضToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzDaftariDaryaft))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzDaftariDaryaft fgs = new frmGhabzDaftariDaryaft();
                fgs.cur_date = DateUtils.Shamsi();
                fgs.MdiParent = this;
                fgs.Show();
            }
        }

        private void ویرایشقبضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzDaftariEslah))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzDaftariEslah fsdv = new frmGhabzDaftariEslah();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشقبوضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmGhabzDaftariView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmGhabzDaftariView fgv = new frmGhabzDaftariView();
                fgv.cur_date = DateUtils.Shamsi();
                fgv.MdiParent = this;
                fgv.Show();
            }
        }

        private void دفترمعیینبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmSickDaftariHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmSickDaftariHisView fshv = new frmSickDaftariHisView();
                fshv.MdiParent = this;
                fshv.Show();
            }
        }

        private void ارسالپیامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(frmContactAdmin))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frmContactAdmin fshv = new frmContactAdmin();
                fshv.MdiParent = this;
                fshv.darmangahName = this.Text.Trim();
                fshv.Show();
            }
        }

        private void بررسیمجددسروریاکلاینتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("با انتخاب این گزینه نرم افزار باید مجددا اجرا شود. موافقید؟", "اخطار", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.Cancel)
            {
                return;
            }

            Properties.Settings.Default.Location = "";
            Properties.Settings.Default.Save();

            Application.Exit();
        }

        private void btnCacheRefresh_Click(object sender, EventArgs e)
        {
            Cache.generateContents();
            MessageBox.Show("اطلاعات حافظه بروزرسانی شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}