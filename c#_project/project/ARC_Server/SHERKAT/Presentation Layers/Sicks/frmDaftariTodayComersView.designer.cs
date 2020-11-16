namespace Mehr.Presentation_Layers
{
    partial class frmDaftariTodayComersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDaftariTodayComersView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtdarman_date = new Mehr.DateMaskedTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.btnsabegheh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rowid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gheybat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.darman_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.home = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masrafi_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ravesh_tark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.grdDataViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowid,
            this.id,
            this.name,
            this.lastdate,
            this.gheybat,
            this.darman_date,
            this.home,
            this.mobile,
            this.masrafi_type,
            this.ravesh_tark,
            this.hesab,
            this.status});
            this.grdDataViewer.Location = new System.Drawing.Point(20, 76);
            this.grdDataViewer.MultiSelect = false;
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(1187, 411);
            this.grdDataViewer.TabIndex = 31;
            this.grdDataViewer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDataViewer_CellDoubleClick);
            this.grdDataViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDataViewer_KeyDown);
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
            this.button1.Location = new System.Drawing.Point(1072, 493);
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
            this.panel1.Controls.Add(this.txtdarman_date);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 58);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txtdarman_date
            // 
            this.txtdarman_date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtdarman_date.BackColor = System.Drawing.Color.White;
            this.txtdarman_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdarman_date.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdarman_date.ForeColor = System.Drawing.Color.Black;
            this.txtdarman_date.Location = new System.Drawing.Point(954, 18);

            this.txtdarman_date.Name = "txtdarman_date";
            this.txtdarman_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdarman_date.Size = new System.Drawing.Size(130, 22);
            this.txtdarman_date.TabIndex = 2;
            this.txtdarman_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdarman_date.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdarman_date.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdarman_date.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1090, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 80;
            this.label2.Text = "تاریخ مراجعه";
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
            this.btnfilter.Location = new System.Drawing.Point(3, 5);
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
            this.btnsabegheh.Location = new System.Drawing.Point(790, 493);
            this.btnsabegheh.Name = "btnsabegheh";
            this.btnsabegheh.Size = new System.Drawing.Size(135, 42);
            this.btnsabegheh.TabIndex = 46;
            this.btnsabegheh.Text = "سابقه مالی بیمار";
            this.btnsabegheh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsabegheh.UseVisualStyleBackColor = true;
            this.btnsabegheh.Click += new System.EventHandler(this.btnsabegheh_Click);
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
            this.button2.Location = new System.Drawing.Point(931, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 42);
            this.button2.TabIndex = 48;
            this.button2.Text = "ثبت پیگیری بیمار";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rowid
            // 
            this.rowid.DataPropertyName = "rowid";
            this.rowid.Frozen = true;
            this.rowid.HeaderText = "ردیف";
            this.rowid.Name = "rowid";
            this.rowid.ReadOnly = true;
            this.rowid.Width = 50;
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
            this.name.Width = 130;
            // 
            // lastdate
            // 
            this.lastdate.DataPropertyName = "lastdate";
            this.lastdate.Frozen = true;
            this.lastdate.HeaderText = "تاریخ مقرر مراجعه";
            this.lastdate.Name = "lastdate";
            this.lastdate.ReadOnly = true;
            // 
            // gheybat
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gheybat.DefaultCellStyle = dataGridViewCellStyle1;
            this.gheybat.Frozen = true;
            this.gheybat.HeaderText = "تعداد غیبت";
            this.gheybat.Name = "gheybat";
            this.gheybat.ReadOnly = true;
            this.gheybat.Width = 80;
            // 
            // darman_date
            // 
            this.darman_date.DataPropertyName = "darman_date";
            this.darman_date.Frozen = true;
            this.darman_date.HeaderText = "شروع درمان";
            this.darman_date.Name = "darman_date";
            this.darman_date.ReadOnly = true;
            this.darman_date.Width = 90;
            // 
            // home
            // 
            this.home.DataPropertyName = "home";
            this.home.Frozen = true;
            this.home.HeaderText = "تلفن منزل";
            this.home.Name = "home";
            this.home.ReadOnly = true;
            this.home.Width = 90;
            // 
            // mobile
            // 
            this.mobile.DataPropertyName = "mobile";
            this.mobile.Frozen = true;
            this.mobile.HeaderText = "تلفن همراه";
            this.mobile.Name = "mobile";
            this.mobile.ReadOnly = true;
            this.mobile.Width = 90;
            // 
            // masrafi_type
            // 
            this.masrafi_type.DataPropertyName = "masrafi_type";
            this.masrafi_type.Frozen = true;
            this.masrafi_type.HeaderText = "مخدر مصرفی";
            this.masrafi_type.Name = "masrafi_type";
            this.masrafi_type.ReadOnly = true;
            // 
            // ravesh_tark
            // 
            this.ravesh_tark.DataPropertyName = "ravesh_tark";
            this.ravesh_tark.Frozen = true;
            this.ravesh_tark.HeaderText = "روش ترک";
            this.ravesh_tark.Name = "ravesh_tark";
            this.ravesh_tark.ReadOnly = true;
            this.ravesh_tark.Width = 135;
            // 
            // hesab
            // 
            this.hesab.DataPropertyName = "hesab";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.hesab.DefaultCellStyle = dataGridViewCellStyle2;
            this.hesab.Frozen = true;
            this.hesab.HeaderText = "مبلغ حساب";
            this.hesab.Name = "hesab";
            this.hesab.ReadOnly = true;
            this.hesab.Width = 80;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.Frozen = true;
            this.status.HeaderText = "وضعیت حساب";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 80;
            // 
            // frmDaftariTodayComersView
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(1219, 542);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnsabegheh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(972, 500);
            this.Name = "frmDaftariTodayComersView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "نمایش لیست مراجعین روز";
            this.Load += new System.EventHandler(this.frmDaftariTodayComersView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        public DateMaskedTextbox txtdarman_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.Button btnsabegheh;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gheybat;
        private System.Windows.Forms.DataGridViewTextBoxColumn darman_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn home;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn masrafi_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ravesh_tark;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesab;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}