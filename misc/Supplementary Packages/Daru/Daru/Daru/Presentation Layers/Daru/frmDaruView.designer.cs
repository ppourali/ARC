namespace Daru.Presentation_Layers
{
    partial class frmDaruView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDaruView));
            this.btnprint = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.btndel = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txttodate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txttahvil_be = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtdaru_name = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtfrom_date = new System.Windows.Forms.MaskedTextBox();
            this.txtdaryaft_az = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.txtsum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnprint.BackColor = System.Drawing.SystemColors.Control;
            this.btnprint.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnprint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(124, 505);
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
            this.btnexit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnexit.BackColor = System.Drawing.SystemColors.Control;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(22, 505);
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
            this.grdDataViewer.Location = new System.Drawing.Point(20, 105);
            this.grdDataViewer.MultiSelect = false;
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(764, 369);
            this.grdDataViewer.TabIndex = 31;
            // 
            // btndel
            // 
            this.btndel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btndel.BackColor = System.Drawing.SystemColors.Control;
            this.btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btndel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btndel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btndel.Image = ((System.Drawing.Image)(resources.GetObject("btndel.Image")));
            this.btndel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndel.Location = new System.Drawing.Point(471, 505);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(96, 42);
            this.btndel.TabIndex = 41;
            this.btndel.Text = "حذف";
            this.btndel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.BackColor = System.Drawing.SystemColors.Control;
            this.btnadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnadd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnadd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.Location = new System.Drawing.Point(675, 505);
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
            this.btnedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnedit.BackColor = System.Drawing.SystemColors.Control;
            this.btnedit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnedit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnedit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(573, 505);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(96, 42);
            this.btnedit.TabIndex = 42;
            this.btnedit.Text = "ویرایش";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txttodate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txttahvil_be);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtdaru_name);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtfrom_date);
            this.panel1.Controls.Add(this.txtdaryaft_az);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 87);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txttodate
            // 
            this.txttodate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txttodate.BackColor = System.Drawing.Color.White;
            this.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttodate.ForeColor = System.Drawing.Color.Black;
            this.txttodate.Location = new System.Drawing.Point(358, 48);
            this.txttodate.Mask = "1300/00/00";
            this.txttodate.Name = "txttodate";
            this.txttodate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttodate.Size = new System.Drawing.Size(130, 21);
            this.txttodate.TabIndex = 3;
            this.txttodate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttodate.Leave += new System.EventHandler(this.Leave_Action);
            this.txttodate.Enter += new System.EventHandler(this.Enter_Action);
            this.txttodate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(494, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 100;
            this.label1.Text = "تا تاریخ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttahvil_be
            // 
            this.txttahvil_be.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txttahvil_be.AutoCompleteCustomSource.AddRange(new string[] {
            "تریاک",
            "شیشه",
            "شیره",
            "هروئین",
            "کراک",
            "حشیش",
            "متادون",
            "کدیین",
            "شربت اکسپکتورانت"});
            this.txttahvil_be.BackColor = System.Drawing.Color.White;
            this.txttahvil_be.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttahvil_be.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txttahvil_be.ForeColor = System.Drawing.Color.Black;
            this.txttahvil_be.Location = new System.Drawing.Point(132, 17);
            this.txttahvil_be.MaxLength = 50;
            this.txttahvil_be.Name = "txttahvil_be";
            this.txttahvil_be.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttahvil_be.Size = new System.Drawing.Size(134, 22);
            this.txttahvil_be.TabIndex = 4;
            this.txttahvil_be.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttahvil_be.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txttahvil_be.Leave += new System.EventHandler(this.Leave_Action);
            this.txttahvil_be.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(273, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 98;
            this.label12.Text = "تحویل به";
            // 
            // txtdaru_name
            // 
            this.txtdaru_name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtdaru_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtdaru_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtdaru_name.BackColor = System.Drawing.Color.White;
            this.txtdaru_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtdaru_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtdaru_name.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtdaru_name.ForeColor = System.Drawing.Color.Black;
            this.txtdaru_name.FormattingEnabled = true;
            this.txtdaru_name.Items.AddRange(new object[] {
            "همه"});
            this.txtdaru_name.Location = new System.Drawing.Point(569, 48);
            this.txtdaru_name.Name = "txtdaru_name";
            this.txtdaru_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdaru_name.Size = new System.Drawing.Size(134, 21);
            this.txtdaru_name.TabIndex = 1;
            this.txtdaru_name.SelectedIndexChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtdaru_name.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdaru_name.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdaru_name.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(705, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 14);
            this.label8.TabIndex = 97;
            this.label8.Text = "نام دارو";
            // 
            // txtfrom_date
            // 
            this.txtfrom_date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtfrom_date.BackColor = System.Drawing.Color.White;
            this.txtfrom_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfrom_date.ForeColor = System.Drawing.Color.Black;
            this.txtfrom_date.Location = new System.Drawing.Point(358, 17);
            this.txtfrom_date.Mask = "1300/00/00";
            this.txtfrom_date.Name = "txtfrom_date";
            this.txtfrom_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfrom_date.Size = new System.Drawing.Size(130, 21);
            this.txtfrom_date.TabIndex = 2;
            this.txtfrom_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfrom_date.Leave += new System.EventHandler(this.Leave_Action);
            this.txtfrom_date.Enter += new System.EventHandler(this.Enter_Action);
            this.txtfrom_date.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtdaryaft_az
            // 
            this.txtdaryaft_az.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtdaryaft_az.BackColor = System.Drawing.Color.White;
            this.txtdaryaft_az.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdaryaft_az.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtdaryaft_az.ForeColor = System.Drawing.Color.Black;
            this.txtdaryaft_az.Location = new System.Drawing.Point(132, 47);
            this.txtdaryaft_az.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdaryaft_az.MaxLength = 50;
            this.txtdaryaft_az.Name = "txtdaryaft_az";
            this.txtdaryaft_az.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdaryaft_az.Size = new System.Drawing.Size(134, 22);
            this.txtdaryaft_az.TabIndex = 5;
            this.txtdaryaft_az.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdaryaft_az.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtdaryaft_az.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdaryaft_az.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(274, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 81;
            this.label4.Text = "دریافت از";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(494, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 80;
            this.label2.Text = "از تاریخ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtid
            // 
            this.txtid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(569, 17);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtid.MaxLength = 4;
            this.txtid.Name = "txtid";
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(134, 22);
            this.txtid.TabIndex = 0;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtid.Leave += new System.EventHandler(this.Leave_Action);
            this.txtid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtid.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(711, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 79;
            this.label3.Text = "شماره";
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
            // txtsum
            // 
            this.txtsum.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtsum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsum.Location = new System.Drawing.Point(20, 478);
            this.txtsum.Name = "txtsum";
            this.txtsum.ReadOnly = true;
            this.txtsum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtsum.Size = new System.Drawing.Size(87, 21);
            this.txtsum.TabIndex = 43;
            // 
            // frmDaruView
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(796, 559);
            this.Controls.Add(this.txtsum);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmDaruView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "نمایش اطلاعات";
            this.Load += new System.EventHandler(this.frmDaruView_Load);
            this.Activated += new System.EventHandler(this.frmDaruView_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.MaskedTextBox txttodate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttahvil_be;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox txtdaru_name;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.MaskedTextBox txtfrom_date;
        private System.Windows.Forms.TextBox txtdaryaft_az;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.TextBox txtsum;
    }
}