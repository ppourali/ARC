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
    public partial class FrmMain : Form
    {
        FrmCalender fc = new FrmCalender();

        public FrmMain()
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


            String prodVersion = Application.ProductVersion;

            Darmangah sh = new Darmangah();
            toolStripStatusLabel3.Text = "مرکز مشاوره و درمان سوء مصرف مواد " + sh.Select().Rows[0]["name"].ToString();
            this.Text = toolStripStatusLabel3.Text + "("+ prodVersion+")";


            Accounts acnt = new Accounts();
            if (acnt.checkpass().Rows.Count > 0)
            {
                FrmLogin frl = new FrmLogin();
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

            Accounts acnt = new Accounts();
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
                if (f.GetType() == typeof(FrmChpass))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmChpass fcp = new FrmChpass();
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

                    new ActionLogs().Add("تهیه ی فایل پشتیبان از پایگاه داده");
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

                FrmRestorePassInput fad = new FrmRestorePassInput(a);
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
                if (f.GetType() == typeof(FrmSickInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSickInp fsi = new FrmSickInp();
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
                if (f.GetType() == typeof(FrmSicksEdit))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSicksEdit fse = new FrmSicksEdit();
                fse.MdiParent = this;
                fse.Show();
            }

        }

        private void نمایشاطلاعاتبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmSicksView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSicksView fsv = new FrmSicksView();
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
                if (f.GetType() == typeof(FrmMosahebehInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmMosahebehInp fmi = new FrmMosahebehInp();
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
                if (f.GetType() == typeof(FrmMosahebehView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmMosahebehView fmv = new FrmMosahebehView();
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
                if (f.GetType() == typeof(FrmGhabzDaryaft))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzDaryaft fgs = new FrmGhabzDaryaft();
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
                if (f.GetType() == typeof(FrmGhabzView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzView fgv = new FrmGhabzView();
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
                if (f.GetType() == typeof(FrmGhabzEslah))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzEslah fge = new FrmGhabzEslah();
                fge.MdiParent = this;
                fge.Show();
            }
        }

        private void تعریفوثبتداروToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmAnbarInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAnbarInp fai = new FrmAnbarInp();
                fai.MdiParent = this;
                fai.Show();
            }
        }

        private void نمایشلیستداروهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAnbarView fav = new FrmAnbarView();
                fav.MdiParent = this;
                fav.Show();
            }
        }

        private void ثبتداروازفاکتورخریدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmFactorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmFactorInp ffi = new FrmFactorInp();
                ffi.MdiParent = this;
                ffi.Show();
            }
        }

        private void نمایشلیستفاکتورهایخریدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmFactorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmFactorView ffv = new FrmFactorView();
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
                if (f.GetType() == typeof(FrmTahvilView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTahvilView ftv = new FrmTahvilView();
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
                if (f.GetType() == typeof(FrmSelectMet))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSelectMet fsm = new FrmSelectMet();
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
                if (f.GetType() == typeof(FrmAddDarmangah))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAddDarmangah fad = new FrmAddDarmangah();
                fad.MdiParent = this;
                fad.Show();
            }
        }

        private void چاپآمارماهانهبوپرنورفینToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmSelectBoop))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSelectBoop fsb = new FrmSelectBoop();
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
                if (f.GetType() == typeof(FrmSelectSub))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSelectSub fss = new FrmSelectSub();
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
                if (f.GetType() == typeof(FrmTajvizView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizView ftv = new FrmTajvizView();
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
                if (f.GetType() == typeof(FrmTajvizSelectMet))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizSelectMet ftsm = new FrmTajvizSelectMet();
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
                if (f.GetType() == typeof(FrmTajvizSelectBoop))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizSelectBoop ftsb = new FrmTajvizSelectBoop();
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
                if (f.GetType() == typeof(FrmTajvizSelectSub))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizSelectSub ftss = new FrmTajvizSelectSub();
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
                if (f.GetType() == typeof(FrmResultView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {

                FrmResultView frv = new FrmResultView();
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
                if (f.GetType() == typeof(FrmAmarKoliView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAmarKoliView fav = new FrmAmarKoliView();
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
                if (f.GetType() == typeof(FrmAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAnbarView fav = new FrmAnbarView();
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
                if (f.GetType() == typeof(FrmSickInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSickInp fsi = new FrmSickInp();
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
                if (f.GetType() == typeof(FrmGhabzDaryaft))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzDaryaft fgs = new FrmGhabzDaryaft();
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

                FrmRestorePassInput fad = new FrmRestorePassInput(a);
                fad.restoreAdvance = true;
                fad.ShowDialog();
            }
        }

        private void دفترمعیینبیمارانToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmSickHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSickHisView fshv = new FrmSickHisView();
                fshv.MdiParent = this;
                fshv.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizAnbarView fav = new FrmTajvizAnbarView();
                fav.MdiParent = this;
                fav.Show();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizAnbarInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizAnbarInp fai = new FrmTajvizAnbarInp();
                fai.MdiParent = this;
                fai.Show();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizFactorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {

                FrmTajvizFactorInp ffi = new FrmTajvizFactorInp();
                ffi.MdiParent = this;
                ffi.Show();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizFactorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizFactorView ffv = new FrmTajvizFactorView();
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
                if (f.GetType() == typeof(FrmTajvizAnbarInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizAnbarInp fti = new FrmTajvizAnbarInp();
                fti.MdiParent = this;
                fti.Show();
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizAnbarView fav = new FrmTajvizAnbarView();
                fav.MdiParent = this;
                fav.Show();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizFactorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizFactorInp ffi = new FrmTajvizFactorInp();
                ffi.MdiParent = this;
                ffi.Show();
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizFactorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizFactorView ffv = new FrmTajvizFactorView();
                ffv.MdiParent = this;
                ffv.Show();
            }
        }

        private void مصرفیمتادونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmMetDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmMetDaftarShow fmdv = new FrmMetDaftarShow();
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
                if (f.GetType() == typeof(FrmBoopDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmBoopDaftarShow fbdv = new FrmBoopDaftarShow();
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
                if (f.GetType() == typeof(FrmSubDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSubDaftarShow fsdv = new FrmSubDaftarShow();
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
                if (f.GetType() == typeof(FrmTajvizMetDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizMetDaftarShow fmdv = new FrmTajvizMetDaftarShow();
                fmdv.MdiParent = this;
                fmdv.Show();
            }
        }

        private void مصرفیبوپرنورفینToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizBoopDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizBoopDaftarShow fbdv = new FrmTajvizBoopDaftarShow();
                fbdv.MdiParent = this;
                fbdv.Show();
            }
        }

        private void مToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmTajvizSubDaftarShow))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizSubDaftarShow fsdv = new FrmTajvizSubDaftarShow();
                fsdv.MdiParent = this;
                fsdv.Show();
            }

        }

        private void ویرایشقبوضToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmGhabzEslah))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzEslah fsdv = new FrmGhabzEslah();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشلیستغائبینبراساستاریخToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmAbsentSicksView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAbsentSicksView fsdv = new FrmAbsentSicksView();
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

                Darmangah darm = new Darmangah();
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
                if (f.GetType() == typeof(FrmLastTajvizView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmLastTajvizView fsdv = new FrmLastTajvizView();
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
                if (f.GetType() == typeof(FrmDastoorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmDastoorInp fsdv = new FrmDastoorInp();
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
                if (f.GetType() == typeof(FrmDastoorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmDastoorView fsdv = new FrmDastoorView();
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
                if (f.GetType() == typeof(FrmRavanshenasInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRavanshenasInp fsdv = new FrmRavanshenasInp();
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
                if (f.GetType() == typeof(FrmRavanshenasView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRavanshenasView fsdv = new FrmRavanshenasView();
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
                if (f.GetType() == typeof(FrmAzmayeshInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAzmayeshInp fsdv = new FrmAzmayeshInp();
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
                if (f.GetType() == typeof(FrmAzmayeshView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAzmayeshView fsdv = new FrmAzmayeshView();
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
                if (f.GetType() == typeof(FrmGhabzJoinTajviz))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzJoinTajviz fsdv = new FrmGhabzJoinTajviz();
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
                if (f.GetType() == typeof(FrmTahvilAdam))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTahvilAdam fsdv = new FrmTahvilAdam();
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
                if (f.GetType() == typeof(FrmTajvizAdam))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizAdam fsdv = new FrmTajvizAdam();
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
                if (f.GetType() == typeof(FrmTodayComersView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTodayComersView fsdv = new FrmTodayComersView();
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
                if (f.GetType() == typeof(FrmIncomePrintViewer))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmIncomePrintViewer fsm = new FrmIncomePrintViewer();
                fsm.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsm.Show();
            }
        }

        private void نمودارگزارشمیزانمصرفداروهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmِDarueePrintViewer))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmِDarueePrintViewer fsm = new FrmِDarueePrintViewer();
                fsm.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsm.Show();
            }
        }

        private void نمودارروندمراجعهبیماراندرماههایمختلفسالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmNafarPrintViewer))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmNafarPrintViewer fsm = new FrmNafarPrintViewer();
                fsm.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsm.Show();
            }
        }

        private void فرمپیگیریبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMasrafiPeygiriPrintViewer fppv = new FrmMasrafiPeygiriPrintViewer();
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
            FrmDaftariPeygiriPrintViewer fppv = new FrmDaftariPeygiriPrintViewer();
            fppv.cur_date = DateUtils.Shamsi();
            fppv.Show();
        }

        private void ثبتپیگیریانجامشدهبرایبیمارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmPeygiriInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmPeygiriInp fsm = new FrmPeygiriInp();
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
                if (f.GetType() == typeof(FrmPeygiriHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmPeygiriHisView fsdv = new FrmPeygiriHisView();
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
                if (f.GetType() == typeof(FrmDastoorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmDastoorInp fsdv = new FrmDastoorInp();
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
                if (f.GetType() == typeof(FrmDastoorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmDastoorView fsdv = new FrmDastoorView();
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
                if (f.GetType() == typeof(FrmAzmayeshInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAzmayeshInp fsdv = new FrmAzmayeshInp();
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
                if (f.GetType() == typeof(FrmAzmayeshView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAzmayeshView fsdv = new FrmAzmayeshView();
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
                if (f.GetType() == typeof(FrmRavanshenasInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRavanshenasInp fsdv = new FrmRavanshenasInp();
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
                if (f.GetType() == typeof(FrmRavanshenasView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRavanshenasView fsdv = new FrmRavanshenasView();
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
                if (f.GetType() == typeof(FrmPeygiriInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmPeygiriInp fsm = new FrmPeygiriInp();
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
                if (f.GetType() == typeof(FrmPeygiriHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmPeygiriHisView fsdv = new FrmPeygiriHisView();
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
                if (f.GetType() == typeof(FromRealDatoorInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FromRealDatoorInp fsdv = new FromRealDatoorInp();
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
                if (f.GetType() == typeof(FrmRealDatoorView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRealDatoorView fsdv = new FrmRealDatoorView();
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
                if (f.GetType() == typeof(FrmRealAzmayeshInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRealAzmayeshInp fsdv = new FrmRealAzmayeshInp();
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
                if (f.GetType() == typeof(FrmRealAzmayeshHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRealAzmayeshView fsdv = new FrmRealAzmayeshView();
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
                if (f.GetType() == typeof(FrmRealRavanshenasInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRealRavanshenasInp fsdv = new FrmRealRavanshenasInp();
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
                if (f.GetType() == typeof(FrmRealRavanshenasView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRealRavanshenasView fsdv = new FrmRealRavanshenasView();
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
                if (f.GetType() == typeof(FrmRealPeygiriInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRealPeygiriInp fsm = new FrmRealPeygiriInp();
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
                if (f.GetType() == typeof(FrmRealPeygiriHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmRealPeygiriHisView fsdv = new FrmRealPeygiriHisView();
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
                if (f.GetType() == typeof(FrmDaftariTodayComersView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmDaftariTodayComersView fsdv = new FrmDaftariTodayComersView();
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
                if (f.GetType() == typeof(FrmDaftariPeygiriPattern))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmDaftariPeygiriPattern fsdv = new FrmDaftariPeygiriPattern();
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
                if (f.GetType() == typeof(FrmHazinehPeygiri))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmHazinehPeygiri fsdv = new FrmHazinehPeygiri();
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
                if (f.GetType() == typeof(FrmAdamTahvilView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAdamTahvilView fsdv = new FrmAdamTahvilView();
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
                if (f.GetType() == typeof(FrmAdamTajvizView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAdamTajvizView fsdv = new FrmAdamTajvizView();
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
                if (f.GetType() == typeof(FrmPeyvast))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmPeyvast fsdv = new FrmPeyvast();
                //fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.txtmonth.SelectedIndex = int.Parse(DateUtils.Shamsi().Substring(5, 2)) - 1;
                fsdv.txtyear.Value = decimal.Parse(DateUtils.Shamsi().Substring(0, 4));
                fsdv.Show();
            }
        }

        private void فرمتنظیمدوزتوسطپرستارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTanzimPrintViewer ftpv = new FrmTanzimPrintViewer();
            ftpv.cur_date = DateUtils.Shamsi();
            ftpv.Show();
        }

        private void ثبتهزینههایمرکزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmHazinehInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmHazinehInp fsdv = new FrmHazinehInp();
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
                if (f.GetType() == typeof(FrmHazinehView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmHazinehView fsdv = new FrmHazinehView();
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
                if (f.GetType() == typeof(FrmMarkazHazinehPeygiri))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmMarkazHazinehPeygiri fsdv = new FrmMarkazHazinehPeygiri();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.Show();
            }

        }

        private void تعویضکاربرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bazrasVorood();
            Accounts acnt = new Accounts();
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
                if (f.GetType() == typeof(FrmAction_LogsView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAction_LogsView fsdv = new FrmAction_LogsView();
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
                if (f.GetType() == typeof(FrmGhabzJoinTajviz))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzJoinTajviz fsdv = new FrmGhabzJoinTajviz();
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

            ActionLogs action_logs = new ActionLogs();
            DataTable maxdatedt = action_logs.SelectMaxDate();

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
                if (f.GetType() == typeof(FrmAssessmentInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAssessmentInp fsdv = new FrmAssessmentInp();
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
                if (f.GetType() == typeof(FrmAssessmentView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAssessmentView fsdv = new FrmAssessmentView();
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
                if (f.GetType() == typeof(FrmTakhfifInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTakhfifInp fsdv = new FrmTakhfifInp();
                fsdv.cur_date = DateUtils.Shamsi();
                fsdv.MdiParent = this;
                fsdv.Show();

            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            FrmGeneralSettings fsdv = new FrmGeneralSettings(ورودبازرسToolStripMenuItem);
            fsdv.ShowDialog();
        }

        private void عملیاتمرتبطبالیستسیاهبیمارانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmBlackListView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmBlackListView fsdv = new FrmBlackListView();
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
                if (f.GetType() == typeof(FrmAmar_RecordsView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmAmar_RecordsView fsdv = new FrmAmar_RecordsView();
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
                if (f.GetType() == typeof(FrmSelSicksFor))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSelSicksFor fsdv = new FrmSelSicksFor();
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
                if (f.GetType() == typeof(FrmParastarAnbarInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmParastarAnbarInp fsdv = new FrmParastarAnbarInp();
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
                if (f.GetType() == typeof(FrmContactInp))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmContactInp fsdv = new FrmContactInp();
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
                if (f.GetType() == typeof(FrmContactView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmContactView fsdv = new FrmContactView();
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
                if (f.GetType() == typeof(FrmParastarAnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmParastarAnbarView fsdv = new FrmParastarAnbarView();
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
                if (f.GetType() == typeof(FrmTajvizAnbarHistoryView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmTajvizAnbarHistoryView fsdv = new FrmTajvizAnbarHistoryView();
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
                if (f.GetType() == typeof(FrmContact_AnbarView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmContact_AnbarView fsdv = new FrmContact_AnbarView();
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
                if (f.GetType() == typeof(FrmSelectMetYear))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSelectMetYear fsdv = new FrmSelectMetYear();
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
                if (f.GetType() == typeof(FrmSelectBoopYear))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSelectBoopYear fsdv = new FrmSelectBoopYear();
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
                if (f.GetType() == typeof(FrmSelectSubYear))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSelectSubYear fsdv = new FrmSelectSubYear();
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
                if (f.GetType() == typeof(FrmSicksStatusView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSicksStatusView fsdv = new FrmSicksStatusView();
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
                if (f.GetType() == typeof(FrmGhabzDaftariDaryaft))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzDaftariDaryaft fgs = new FrmGhabzDaftariDaryaft();
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
                if (f.GetType() == typeof(FrmGhabzDaftariEslah))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzDaftariEslah fsdv = new FrmGhabzDaftariEslah();
                fsdv.MdiParent = this;
                fsdv.Show();
            }
        }

        private void نمایشقبوضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmGhabzDaftariView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmGhabzDaftariView fgv = new FrmGhabzDaftariView();
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
                if (f.GetType() == typeof(FrmSickDaftariHisView))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmSickDaftariHisView fshv = new FrmSickDaftariHisView();
                fshv.MdiParent = this;
                fshv.Show();
            }
        }

        private void ارسالپیامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(FrmContactAdmin))
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                FrmContactAdmin fshv = new FrmContactAdmin();
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