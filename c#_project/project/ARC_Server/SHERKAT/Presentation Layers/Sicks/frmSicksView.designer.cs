namespace Mehr.Presentation_Layers
{
    partial class FrmSicksView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSicksView));
            this.btnprint = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.افزودنبیمارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ویرایشبیمارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.بستنپروندهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.سابقهداروییبیمارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.سابقهداروییبیمارواقعیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.سابقهمالیبیمارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.چاپگزارشاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.p0 = new System.Windows.Forms.ToolStripMenuItem();
            this.p11 = new System.Windows.Forms.ToolStripMenuItem();
            this.p10 = new System.Windows.Forms.ToolStripMenuItem();
            this.p9 = new System.Windows.Forms.ToolStripMenuItem();
            this.p8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.p1 = new System.Windows.Forms.ToolStripMenuItem();
            this.p2 = new System.Windows.Forms.ToolStripMenuItem();
            this.p3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.p4 = new System.Windows.Forms.ToolStripMenuItem();
            this.p5 = new System.Windows.Forms.ToolStripMenuItem();
            this.p6 = new System.Windows.Forms.ToolStripMenuItem();
            this.p7 = new System.Windows.Forms.ToolStripMenuItem();
            this.استخراجشمارههمراهبیمارانToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btndel = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOpenOrClose = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmasrafi_type = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtravesh_tark = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.btnsabegheh = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txttodate = new Mehr.DateMaskedTextbox();
            this.txtdarman_date = new Mehr.DateMaskedTextbox();
            this.txtid = new Mehr.IDTextBox();
            this.txtstatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnprint
            // 
            this.btnprint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnprint.BackColor = System.Drawing.SystemColors.Control;
            this.btnprint.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnprint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(353, 493);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(96, 42);
            this.btnprint.TabIndex = 28;
            this.btnprint.Text = "چاپ";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnexit
            // 
            this.btnexit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnexit.BackColor = System.Drawing.SystemColors.Control;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(20, 493);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 42);
            this.btnexit.TabIndex = 30;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // grdDataViewer
            // 
            this.grdDataViewer.AllowUserToAddRows = false;
            this.grdDataViewer.AllowUserToDeleteRows = false;
            this.grdDataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDataViewer.ContextMenuStrip = this.contextMenuStrip1;
            this.grdDataViewer.Location = new System.Drawing.Point(20, 105);
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(1215, 382);
            this.grdDataViewer.TabIndex = 31;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.افزودنبیمارToolStripMenuItem,
            this.ویرایشبیمارToolStripMenuItem,
            this.بستنپروندهToolStripMenuItem,
            this.سابقهداروییبیمارToolStripMenuItem,
            this.سابقهداروییبیمارواقعیToolStripMenuItem,
            this.سابقهمالیبیمارToolStripMenuItem,
            this.چاپگزارشاتToolStripMenuItem,
            this.استخراجشمارههمراهبیمارانToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 180);
            // 
            // افزودنبیمارToolStripMenuItem
            // 
            this.افزودنبیمارToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("افزودنبیمارToolStripMenuItem.Image")));
            this.افزودنبیمارToolStripMenuItem.Name = "افزودنبیمارToolStripMenuItem";
            this.افزودنبیمارToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.افزودنبیمارToolStripMenuItem.Text = "افزودن بیمار";
            this.افزودنبیمارToolStripMenuItem.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // ویرایشبیمارToolStripMenuItem
            // 
            this.ویرایشبیمارToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ویرایشبیمارToolStripMenuItem.Image")));
            this.ویرایشبیمارToolStripMenuItem.Name = "ویرایشبیمارToolStripMenuItem";
            this.ویرایشبیمارToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.ویرایشبیمارToolStripMenuItem.Text = "ویرایش بیمار";
            this.ویرایشبیمارToolStripMenuItem.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // بستنپروندهToolStripMenuItem
            // 
            this.بستنپروندهToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("بستنپروندهToolStripMenuItem.Image")));
            this.بستنپروندهToolStripMenuItem.Name = "بستنپروندهToolStripMenuItem";
            this.بستنپروندهToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.بستنپروندهToolStripMenuItem.Text = "بستن پرونده";
            this.بستنپروندهToolStripMenuItem.Click += new System.EventHandler(this.btndel_Click);
            // 
            // سابقهداروییبیمارToolStripMenuItem
            // 
            this.سابقهداروییبیمارToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("سابقهداروییبیمارToolStripMenuItem.Image")));
            this.سابقهداروییبیمارToolStripMenuItem.Name = "سابقهداروییبیمارToolStripMenuItem";
            this.سابقهداروییبیمارToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.سابقهداروییبیمارToolStripMenuItem.Text = "سابقه دارویی بیمار";
            this.سابقهداروییبیمارToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // سابقهداروییبیمارواقعیToolStripMenuItem
            // 
            this.سابقهداروییبیمارواقعیToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("سابقهداروییبیمارواقعیToolStripMenuItem.Image")));
            this.سابقهداروییبیمارواقعیToolStripMenuItem.Name = "سابقهداروییبیمارواقعیToolStripMenuItem";
            this.سابقهداروییبیمارواقعیToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.سابقهداروییبیمارواقعیToolStripMenuItem.Text = "سابقه دارویی بیمار-واقعی";
            this.سابقهداروییبیمارواقعیToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // سابقهمالیبیمارToolStripMenuItem
            // 
            this.سابقهمالیبیمارToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("سابقهمالیبیمارToolStripMenuItem.Image")));
            this.سابقهمالیبیمارToolStripMenuItem.Name = "سابقهمالیبیمارToolStripMenuItem";
            this.سابقهمالیبیمارToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.سابقهمالیبیمارToolStripMenuItem.Text = "سابقه مالی بیمار";
            this.سابقهمالیبیمارToolStripMenuItem.Click += new System.EventHandler(this.btnsabegheh_Click);
            // 
            // چاپگزارشاتToolStripMenuItem
            // 
            this.چاپگزارشاتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.p0,
            this.p11,
            this.p10,
            this.p9,
            this.p8,
            this.toolStripSeparator1,
            this.p1,
            this.p2,
            this.p3,
            this.toolStripSeparator2,
            this.p4,
            this.p5,
            this.p6,
            this.p7});
            this.چاپگزارشاتToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("چاپگزارشاتToolStripMenuItem.Image")));
            this.چاپگزارشاتToolStripMenuItem.Name = "چاپگزارشاتToolStripMenuItem";
            this.چاپگزارشاتToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.چاپگزارشاتToolStripMenuItem.Text = "چاپ گزارشات";
            // 
            // p0
            // 
            this.p0.Image = ((System.Drawing.Image)(resources.GetObject("p0.Image")));
            this.p0.Name = "p0";
            this.p0.Size = new System.Drawing.Size(261, 22);
            this.p0.Text = "پرونده ی کامل بیمار";
            this.p0.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p11
            // 
            this.p11.Image = ((System.Drawing.Image)(resources.GetObject("p11.Image")));
            this.p11.Name = "p11";
            this.p11.Size = new System.Drawing.Size(261, 22);
            this.p11.Text = "لیست حساب بیماران";
            this.p11.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p10
            // 
            this.p10.Image = ((System.Drawing.Image)(resources.GetObject("p10.Image")));
            this.p10.Name = "p10";
            this.p10.Size = new System.Drawing.Size(261, 22);
            this.p10.Text = "فرم تعهد نامه بیماران";
            this.p10.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p9
            // 
            this.p9.Image = ((System.Drawing.Image)(resources.GetObject("p9.Image")));
            this.p9.Name = "p9";
            this.p9.Size = new System.Drawing.Size(261, 22);
            this.p9.Text = "مشخصات-لیست گروهی";
            this.p9.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p8
            // 
            this.p8.Image = ((System.Drawing.Image)(resources.GetObject("p8.Image")));
            this.p8.Name = "p8";
            this.p8.Size = new System.Drawing.Size(261, 22);
            this.p8.Text = "مشخصات-فرم های انفرادی";
            this.p8.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // p1
            // 
            this.p1.Image = ((System.Drawing.Image)(resources.GetObject("p1.Image")));
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(261, 22);
            this.p1.Text = "سابقه ی آزمایشات";
            this.p1.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p2
            // 
            this.p2.Image = ((System.Drawing.Image)(resources.GetObject("p2.Image")));
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(261, 22);
            this.p2.Text = "سابقه ی دستورات پزشک";
            this.p2.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p3
            // 
            this.p3.Image = ((System.Drawing.Image)(resources.GetObject("p3.Image")));
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(261, 22);
            this.p3.Text = "سابقه ی نظرات روانشناسی";
            this.p3.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(258, 6);
            // 
            // p4
            // 
            this.p4.Image = ((System.Drawing.Image)(resources.GetObject("p4.Image")));
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(261, 22);
            this.p4.Text = "فرم شماره 6: تنظیم دوز پزشک-انتخابی";
            this.p4.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p5
            // 
            this.p5.Image = ((System.Drawing.Image)(resources.GetObject("p5.Image")));
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(261, 22);
            this.p5.Text = "فرم شماره 6: تنظیم دوز پزشک-یکسره";
            this.p5.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p6
            // 
            this.p6.Image = ((System.Drawing.Image)(resources.GetObject("p6.Image")));
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(261, 22);
            this.p6.Text = "فرم شماره 8: تنظیم دوز پرستار-انتخابی";
            this.p6.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // p7
            // 
            this.p7.Image = ((System.Drawing.Image)(resources.GetObject("p7.Image")));
            this.p7.Name = "p7";
            this.p7.Size = new System.Drawing.Size(261, 22);
            this.p7.Text = "فرم شماره 8: تنظیم دوز پرستار-یکسره";
            this.p7.Click += new System.EventHandler(this.ContextMenuPrint);
            // 
            // استخراجشمارههمراهبیمارانToolStripMenuItem
            // 
            this.استخراجشمارههمراهبیمارانToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("استخراجشمارههمراهبیمارانToolStripMenuItem.Image")));
            this.استخراجشمارههمراهبیمارانToolStripMenuItem.Name = "استخراجشمارههمراهبیمارانToolStripMenuItem";
            this.استخراجشمارههمراهبیمارانToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.استخراجشمارههمراهبیمارانToolStripMenuItem.Text = "استخراج شماره همراه بیماران";
            this.استخراجشمارههمراهبیمارانToolStripMenuItem.Click += new System.EventHandler(this.استخراجشمارههمراهبیمارانToolStripMenuItem_Click);
            // 
            // btndel
            // 
            this.btndel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btndel.BackColor = System.Drawing.SystemColors.Control;
            this.btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btndel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btndel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btndel.Image = ((System.Drawing.Image)(resources.GetObject("btndel.Image")));
            this.btndel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndel.Location = new System.Drawing.Point(909, 493);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(112, 42);
            this.btndel.TabIndex = 41;
            this.btndel.Text = "بستن پرونده";
            this.btndel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnadd.BackColor = System.Drawing.SystemColors.Control;
            this.btnadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnadd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnadd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.Location = new System.Drawing.Point(1129, 493);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(96, 42);
            this.btnadd.TabIndex = 40;
            this.btnadd.Text = "اضافه";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnedit
            // 
            this.btnedit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnedit.BackColor = System.Drawing.SystemColors.Control;
            this.btnedit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnedit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnedit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(1027, 493);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(96, 42);
            this.btnedit.TabIndex = 42;
            this.btnedit.Text = "ویرایش";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(627, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 42);
            this.button1.TabIndex = 45;
            this.button1.Text = "سابقه دارویی بیمار";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtstatus);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtOpenOrClose);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txttodate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtmasrafi_type);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtravesh_tark);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtdarman_date);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1215, 87);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txtOpenOrClose
            // 
            this.txtOpenOrClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtOpenOrClose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtOpenOrClose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtOpenOrClose.BackColor = System.Drawing.Color.White;
            this.txtOpenOrClose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtOpenOrClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtOpenOrClose.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtOpenOrClose.ForeColor = System.Drawing.Color.Black;
            this.txtOpenOrClose.FormattingEnabled = true;
            this.txtOpenOrClose.Items.AddRange(new object[] {
            "همه",
            "فعال",
            "غیر فعال"});
            this.txtOpenOrClose.Location = new System.Drawing.Point(140, 18);
            this.txtOpenOrClose.Name = "txtOpenOrClose";
            this.txtOpenOrClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOpenOrClose.Size = new System.Drawing.Size(134, 21);
            this.txtOpenOrClose.TabIndex = 103;
            this.txtOpenOrClose.SelectedIndexChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtOpenOrClose.Leave += new System.EventHandler(this.Leave_Action);
            this.txtOpenOrClose.Enter += new System.EventHandler(this.Enter_Action);
            this.txtOpenOrClose.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(276, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 104;
            this.label5.Text = "وضعیت پرونده";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(857, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 100;
            this.label1.Text = "تا تاریخ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmasrafi_type
            // 
            this.txtmasrafi_type.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtmasrafi_type.AutoCompleteCustomSource.AddRange(new string[] {
            "تریاک",
            "شیشه",
            "شیره",
            "هروئین",
            "کراک",
            "حشیش",
            "متادون",
            "کدیین",
            "شربت اکسپکتورانت"});
            this.txtmasrafi_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtmasrafi_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtmasrafi_type.BackColor = System.Drawing.Color.White;
            this.txtmasrafi_type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmasrafi_type.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtmasrafi_type.ForeColor = System.Drawing.Color.Black;
            this.txtmasrafi_type.Location = new System.Drawing.Point(404, 17);
            this.txtmasrafi_type.MaxLength = 50;
            this.txtmasrafi_type.Name = "txtmasrafi_type";
            this.txtmasrafi_type.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmasrafi_type.Size = new System.Drawing.Size(134, 22);
            this.txtmasrafi_type.TabIndex = 4;
            this.txtmasrafi_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmasrafi_type.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtmasrafi_type.Leave += new System.EventHandler(this.Leave_Action);
            this.txtmasrafi_type.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(545, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 14);
            this.label12.TabIndex = 98;
            this.label12.Text = "نوع ماده مخدر مصرفی";
            // 
            // txtravesh_tark
            // 
            this.txtravesh_tark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtravesh_tark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtravesh_tark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtravesh_tark.BackColor = System.Drawing.Color.White;
            this.txtravesh_tark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtravesh_tark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtravesh_tark.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtravesh_tark.ForeColor = System.Drawing.Color.Black;
            this.txtravesh_tark.FormattingEnabled = true;
            this.txtravesh_tark.Items.AddRange(new object[] {
            "همه",
            "سم زدایی با بوپرنورفین",
            "نگهدارنده با متادون (MMT)",
            "سم زدایی با سوباکسون"});
            this.txtravesh_tark.Location = new System.Drawing.Point(404, 48);
            this.txtravesh_tark.Name = "txtravesh_tark";
            this.txtravesh_tark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtravesh_tark.Size = new System.Drawing.Size(134, 21);
            this.txtravesh_tark.TabIndex = 5;
            this.txtravesh_tark.SelectedIndexChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtravesh_tark.Leave += new System.EventHandler(this.Leave_Action);
            this.txtravesh_tark.Enter += new System.EventHandler(this.Enter_Action);
            this.txtravesh_tark.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(540, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 14);
            this.label8.TabIndex = 97;
            this.label8.Text = "روش های ترک اعتیاد";
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtname.BackColor = System.Drawing.Color.White;
            this.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtname.ForeColor = System.Drawing.Color.Black;
            this.txtname.Location = new System.Drawing.Point(968, 47);
            this.txtname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtname.MaxLength = 50;
            this.txtname.Name = "txtname";
            this.txtname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtname.Size = new System.Drawing.Size(130, 22);
            this.txtname.TabIndex = 1;
            this.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtname.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtname.Leave += new System.EventHandler(this.Leave_Action);
            this.txtname.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1106, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 14);
            this.label4.TabIndex = 81;
            this.label4.Text = "نام و نام خانوادگی";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(857, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 14);
            this.label2.TabIndex = 80;
            this.label2.Text = "درمان از تاریخ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1106, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 79;
            this.label3.Text = "شماره پرونده";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnfilter
            // 
            this.btnfilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnfilter.Enabled = false;
            this.btnfilter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnfilter.ForeColor = System.Drawing.Color.Black;
            this.btnfilter.Image = ((System.Drawing.Image)(resources.GetObject("btnfilter.Image")));
            this.btnfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfilter.Location = new System.Drawing.Point(13, 22);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(96, 42);
            this.btnfilter.TabIndex = 6;
            this.btnfilter.Text = "جستجو";
            this.btnfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // btnsabegheh
            // 
            this.btnsabegheh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsabegheh.BackColor = System.Drawing.SystemColors.Control;
            this.btnsabegheh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnsabegheh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnsabegheh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnsabegheh.Image = ((System.Drawing.Image)(resources.GetObject("btnsabegheh.Image")));
            this.btnsabegheh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsabegheh.Location = new System.Drawing.Point(768, 493);
            this.btnsabegheh.Name = "btnsabegheh";
            this.btnsabegheh.Size = new System.Drawing.Size(135, 42);
            this.btnsabegheh.TabIndex = 46;
            this.btnsabegheh.Text = "سابقه مالی بیمار";
            this.btnsabegheh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsabegheh.UseVisualStyleBackColor = true;
            this.btnsabegheh.Click += new System.EventHandler(this.btnsabegheh_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "پرونده ی کامل بیمار",
            "سابقه ی آزمایشات",
            "سابقه ی دستورات پزشک",
            "سابقه ی نظرات روانشناسی",
            "فرم شماره 5: پیگیری بیماران-انتخابی",
            "فرم شماره 5: پیگیری بیماران-یکسره",
            "فرم شماره 6: تنظیم دوز پزشک-انتخابی",
            "فرم شماره 6: تنظیم دوز پزشک-یکسره",
            "فرم شماره 8: تنظیم دوز پرستار-انتخابی",
            "فرم شماره 8: تنظیم دوز پرستار-یکسره",
            "مشخصات-فرم های انفرادی",
            "مشخصات-لیست گروهی",
            "فرم تعهد نامه بیماران",
            "لیست حساب بیماران",
            "رسید دریافت دارو"});
            this.comboBox1.Location = new System.Drawing.Point(123, 505);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(224, 21);
            this.comboBox1.TabIndex = 47;
            this.comboBox1.Leave += new System.EventHandler(this.Leave_Action);
            this.comboBox1.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(455, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 42);
            this.button2.TabIndex = 48;
            this.button2.Text = "سابقه دارویی بیمار-واقعی";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.txt";
            this.saveFileDialog1.FileName = "Sicks_Contacts.txt";
            this.saveFileDialog1.Filter = "Text Files|*.txt";
            // 
            // txttodate
            // 
            this.txttodate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txttodate.BackColor = System.Drawing.Color.White;
            this.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttodate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txttodate.ForeColor = System.Drawing.Color.Black;
            this.txttodate.Location = new System.Drawing.Point(721, 48);
            
            this.txttodate.Name = "txttodate";
            this.txttodate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttodate.Size = new System.Drawing.Size(130, 22);
            this.txttodate.TabIndex = 3;
            this.txttodate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttodate.Leave += new System.EventHandler(this.Leave_Action);
            this.txttodate.Enter += new System.EventHandler(this.Enter_Action);
            this.txttodate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtdarman_date
            // 
            this.txtdarman_date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtdarman_date.BackColor = System.Drawing.Color.White;
            this.txtdarman_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdarman_date.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdarman_date.ForeColor = System.Drawing.Color.Black;
            this.txtdarman_date.Location = new System.Drawing.Point(721, 17);

            this.txtdarman_date.Name = "txtdarman_date";
            this.txtdarman_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdarman_date.Size = new System.Drawing.Size(130, 22);
            this.txtdarman_date.TabIndex = 2;
            this.txtdarman_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdarman_date.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdarman_date.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdarman_date.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtid
            // 
            this.txtid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(968, 17);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtid.MaxLength = 15;
            this.txtid.Name = "txtid";
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(130, 22);
            this.txtid.TabIndex = 0;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtstatus
            // 
            this.txtstatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtstatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtstatus.BackColor = System.Drawing.Color.White;
            this.txtstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtstatus.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtstatus.ForeColor = System.Drawing.Color.Black;
            this.txtstatus.FormattingEnabled = true;
            this.txtstatus.Items.AddRange(new object[] {
            "همه",
            "بدهکار",
            "بستانکار"});
            this.txtstatus.Location = new System.Drawing.Point(140, 47);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtstatus.Size = new System.Drawing.Size(134, 21);
            this.txtstatus.TabIndex = 117;
            this.txtstatus.SelectedIndexChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtstatus.Leave += new System.EventHandler(this.Leave_Action);
            this.txtstatus.Enter += new System.EventHandler(this.Enter_Action);
            this.txtstatus.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(278, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 14);
            this.label6.TabIndex = 118;
            this.label6.Text = "وضعیت حساب";
            // 
            // frmSicksView
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(1247, 542);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnsabegheh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(972, 500);
            this.Name = "frmSicksView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "نمایش اطلاعات بیماران";
            this.Load += new System.EventHandler(this.frmSicksView_Load);
            this.Activated += new System.EventHandler(this.frmSicksView_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        public DateMaskedTextbox txttodate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmasrafi_type;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox txtravesh_tark;
        private System.Windows.Forms.Label label8;
        public DateMaskedTextbox txtdarman_date;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private IDTextBox txtid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.Button btnsabegheh;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem افزودنبیمارToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ویرایشبیمارToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem بستنپروندهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem سابقهداروییبیمارToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem سابقهداروییبیمارواقعیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem سابقهمالیبیمارToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem چاپگزارشاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem p0;
        private System.Windows.Forms.ToolStripMenuItem p1;
        private System.Windows.Forms.ToolStripMenuItem p2;
        private System.Windows.Forms.ToolStripMenuItem p3;
        private System.Windows.Forms.ToolStripMenuItem p4;
        private System.Windows.Forms.ToolStripMenuItem p5;
        private System.Windows.Forms.ToolStripMenuItem p6;
        private System.Windows.Forms.ToolStripMenuItem p7;
        private System.Windows.Forms.ToolStripMenuItem p8;
        private System.Windows.Forms.ToolStripMenuItem p9;
        private System.Windows.Forms.ToolStripMenuItem p10;
        private System.Windows.Forms.ToolStripMenuItem p11;
        private System.Windows.Forms.ToolStripMenuItem استخراجشمارههمراهبیمارانToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ComboBox txtOpenOrClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtstatus;
        private System.Windows.Forms.Label label6;
    }
}