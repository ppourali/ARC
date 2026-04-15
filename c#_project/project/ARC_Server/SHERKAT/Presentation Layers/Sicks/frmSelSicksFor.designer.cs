namespace Mehr.Presentation_Layers
{
    partial class FrmSelSicksFor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelSicksFor));
            this.btnexit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnSabegheh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbldastoor = new System.Windows.Forms.Label();
            this.lblravanshenas = new System.Windows.Forms.Label();
            this.lblazmayesh = new System.Windows.Forms.Label();
            this.lbltahvil = new System.Windows.Forms.Label();
            this.lblall = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dascode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dasdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ravcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ravdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.azcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.azdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahvilcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahvil_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txttodate = new Mehr.DateMaskedTextbox();
            this.txtdate = new Mehr.DateMaskedTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnexit
            // 
            this.btnexit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(12, 483);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 42);
            this.btnexit.TabIndex = 34;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.dascode,
            this.dasdate,
            this.ravcode,
            this.ravdate,
            this.azcode,
            this.azdate,
            this.tahvilcode,
            this.tahvil_date,
            this.from_date,
            this.to_date});
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1071, 380);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 1;
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.BackColor = System.Drawing.SystemColors.Control;
            this.btnprint.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnprint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(297, 483);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(96, 42);
            this.btnprint.TabIndex = 33;
            this.btnprint.Text = "چاپ";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnSabegheh
            // 
            this.btnSabegheh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSabegheh.BackColor = System.Drawing.SystemColors.Control;
            this.btnSabegheh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSabegheh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSabegheh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSabegheh.Image = ((System.Drawing.Image)(resources.GetObject("btnSabegheh.Image")));
            this.btnSabegheh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSabegheh.Location = new System.Drawing.Point(617, 483);
            this.btnSabegheh.Name = "btnSabegheh";
            this.btnSabegheh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSabegheh.Size = new System.Drawing.Size(147, 42);
            this.btnSabegheh.TabIndex = 35;
            this.btnSabegheh.TabStop = false;
            this.btnSabegheh.Text = "سوابق آزمایشات بیمار";
            this.btnSabegheh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSabegheh.UseVisualStyleBackColor = true;
            this.btnSabegheh.Click += new System.EventHandler(this.btnSabegheh_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(932, 483);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(151, 42);
            this.button1.TabIndex = 36;
            this.button1.TabStop = false;
            this.button1.Text = "تاریخچه دستورات پزشک";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(770, 483);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(156, 42);
            this.button2.TabIndex = 37;
            this.button2.TabStop = false;
            this.button2.Text = "تاریخچه نظرات روانشناس";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txttodate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtdate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 54);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(780, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 100;
            this.label1.Text = "تا تاریخ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1011, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 80;
            this.label2.Text = "از تاریخ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnfilter
            // 
            this.btnfilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnfilter.Enabled = false;
            this.btnfilter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnfilter.ForeColor = System.Drawing.Color.Black;
            this.btnfilter.Image = ((System.Drawing.Image)(resources.GetObject("btnfilter.Image")));
            this.btnfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfilter.Location = new System.Drawing.Point(17, 3);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(96, 42);
            this.btnfilter.TabIndex = 2;
            this.btnfilter.Text = "جستجو";
            this.btnfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(476, 483);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 42);
            this.button3.TabIndex = 46;
            this.button3.Text = "سابقه دارویی بیمار";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "دستورات پزشک",
            "نظرات روانشناسی",
            "آزمایشات",
            "تنظیم دوز پزشک و پرستار"});
            this.comboBox1.Location = new System.Drawing.Point(114, 495);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(177, 21);
            this.comboBox1.TabIndex = 48;
            // 
            // lbldastoor
            // 
            this.lbldastoor.BackColor = System.Drawing.Color.Pink;
            this.lbldastoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbldastoor.Location = new System.Drawing.Point(681, 455);
            this.lbldastoor.Name = "lbldastoor";
            this.lbldastoor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbldastoor.Size = new System.Drawing.Size(157, 23);
            this.lbldastoor.TabIndex = 49;
            this.lbldastoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblravanshenas
            // 
            this.lblravanshenas.BackColor = System.Drawing.Color.PeachPuff;
            this.lblravanshenas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblravanshenas.Location = new System.Drawing.Point(515, 455);
            this.lblravanshenas.Name = "lblravanshenas";
            this.lblravanshenas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblravanshenas.Size = new System.Drawing.Size(160, 23);
            this.lblravanshenas.TabIndex = 50;
            this.lblravanshenas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblazmayesh
            // 
            this.lblazmayesh.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblazmayesh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblazmayesh.Location = new System.Drawing.Point(352, 455);
            this.lblazmayesh.Name = "lblazmayesh";
            this.lblazmayesh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblazmayesh.Size = new System.Drawing.Size(157, 23);
            this.lblazmayesh.TabIndex = 51;
            this.lblazmayesh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltahvil
            // 
            this.lbltahvil.BackColor = System.Drawing.Color.MistyRose;
            this.lbltahvil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltahvil.Location = new System.Drawing.Point(21, 455);
            this.lbltahvil.Name = "lbltahvil";
            this.lbltahvil.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbltahvil.Size = new System.Drawing.Size(325, 23);
            this.lbltahvil.TabIndex = 52;
            this.lbltahvil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblall
            // 
            this.lblall.BackColor = System.Drawing.Color.Khaki;
            this.lblall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblall.Location = new System.Drawing.Point(844, 455);
            this.lblall.Name = "lblall";
            this.lblall.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblall.Size = new System.Drawing.Size(239, 23);
            this.lblall.TabIndex = 53;
            this.lblall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.Frozen = true;
            this.id.HeaderText = "شماره پرونده";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.Frozen = true;
            this.name.HeaderText = "نام و نام خانوادگی";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 120;
            // 
            // dascode
            // 
            this.dascode.DataPropertyName = "dascode";
            this.dascode.Frozen = true;
            this.dascode.HeaderText = "کد دستور پزشک";
            this.dascode.Name = "dascode";
            this.dascode.ReadOnly = true;
            this.dascode.Width = 75;
            // 
            // dasdate
            // 
            this.dasdate.DataPropertyName = "dasdate";
            this.dasdate.Frozen = true;
            this.dasdate.HeaderText = "تاریخ دستور پزشک";
            this.dasdate.Name = "dasdate";
            this.dasdate.ReadOnly = true;
            this.dasdate.Width = 90;
            // 
            // ravcode
            // 
            this.ravcode.DataPropertyName = "ravcode";
            this.ravcode.Frozen = true;
            this.ravcode.HeaderText = "کد نظر روانشناس";
            this.ravcode.Name = "ravcode";
            this.ravcode.ReadOnly = true;
            this.ravcode.Width = 75;
            // 
            // ravdate
            // 
            this.ravdate.DataPropertyName = "ravdate";
            this.ravdate.Frozen = true;
            this.ravdate.HeaderText = "تاریخ روانشناسی";
            this.ravdate.Name = "ravdate";
            this.ravdate.ReadOnly = true;
            this.ravdate.Width = 90;
            // 
            // azcode
            // 
            this.azcode.DataPropertyName = "azcode";
            this.azcode.Frozen = true;
            this.azcode.HeaderText = "کد آزمایش";
            this.azcode.Name = "azcode";
            this.azcode.ReadOnly = true;
            this.azcode.Width = 75;
            // 
            // azdate
            // 
            this.azdate.DataPropertyName = "azdate";
            this.azdate.Frozen = true;
            this.azdate.HeaderText = "تاریخ آزمایش";
            this.azdate.Name = "azdate";
            this.azdate.ReadOnly = true;
            this.azdate.Width = 87;
            // 
            // tahvilcode
            // 
            this.tahvilcode.DataPropertyName = "tahvilcode";
            this.tahvilcode.Frozen = true;
            this.tahvilcode.HeaderText = "کد تحویل دارو";
            this.tahvilcode.Name = "tahvilcode";
            this.tahvilcode.ReadOnly = true;
            this.tahvilcode.Width = 70;
            // 
            // tahvil_date
            // 
            this.tahvil_date.DataPropertyName = "tahvil_date";
            this.tahvil_date.Frozen = true;
            this.tahvil_date.HeaderText = "تاریخ تحویل";
            this.tahvil_date.Name = "tahvil_date";
            this.tahvil_date.ReadOnly = true;
            this.tahvil_date.Width = 90;
            // 
            // from_date
            // 
            this.from_date.DataPropertyName = "from_date";
            this.from_date.Frozen = true;
            this.from_date.HeaderText = "از تاریخ";
            this.from_date.Name = "from_date";
            this.from_date.ReadOnly = true;
            this.from_date.Width = 80;
            // 
            // to_date
            // 
            this.to_date.DataPropertyName = "to_date";
            this.to_date.Frozen = true;
            this.to_date.HeaderText = "تا تاریخ";
            this.to_date.Name = "to_date";
            this.to_date.ReadOnly = true;
            this.to_date.Width = 80;
            // 
            // txttodate
            // 
            this.txttodate.BackColor = System.Drawing.Color.White;
            this.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttodate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txttodate.ForeColor = System.Drawing.Color.Black;
            this.txttodate.Location = new System.Drawing.Point(649, 15);
            
            this.txttodate.Name = "txttodate";
            this.txttodate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttodate.Size = new System.Drawing.Size(125, 22);
            this.txttodate.TabIndex = 1;
            this.txttodate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttodate.Leave += new System.EventHandler(this.Leave_Action);
            this.txttodate.Enter += new System.EventHandler(this.Enter_Action);
            this.txttodate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtdate
            // 
            this.txtdate.BackColor = System.Drawing.Color.White;
            this.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdate.ForeColor = System.Drawing.Color.Black;
            this.txtdate.Location = new System.Drawing.Point(880, 15);
            
            this.txtdate.Name = "txtdate";
            this.txtdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdate.Size = new System.Drawing.Size(125, 22);
            this.txtdate.TabIndex = 0;
            this.txtdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdate.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdate.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // frmSelSicksFor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(1095, 532);
            this.Controls.Add(this.lblall);
            this.Controls.Add(this.lbltahvil);
            this.Controls.Add(this.lblazmayesh);
            this.Controls.Add(this.lblravanshenas);
            this.Controls.Add(this.lbldastoor);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSabegheh);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnexit);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSelSicksFor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست کلی عملیات مرتبط با بیماران";
            this.Load += new System.EventHandler(this.frmSelSicksFor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnSabegheh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        public DateMaskedTextbox txttodate;
        private System.Windows.Forms.Label label1;
        public DateMaskedTextbox txtdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbldastoor;
        private System.Windows.Forms.Label lblravanshenas;
        private System.Windows.Forms.Label lblazmayesh;
        private System.Windows.Forms.Label lbltahvil;
        private System.Windows.Forms.Label lblall;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dascode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dasdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ravcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ravdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn azcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn azdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahvilcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahvil_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn from_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_date;
    }
}