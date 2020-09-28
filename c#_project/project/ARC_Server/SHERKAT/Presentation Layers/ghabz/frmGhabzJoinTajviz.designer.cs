namespace Mehr.Presentation_Layers
{
    partial class frmGhabzJoinTajviz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGhabzJoinTajviz));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tajviz_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tajviz_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghabz_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mablagh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txttodate = new Mehr.DateMaskedTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfromdate = new Mehr.DateMaskedTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.btnsabegheh = new System.Windows.Forms.Button();
            this.pnlpaid = new System.Windows.Forms.Panel();
            this.pnlnotpaid = new System.Windows.Forms.Panel();
            this.pnlpaidnodrugs = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnexit
            // 
            this.btnexit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnexit.BackColor = System.Drawing.SystemColors.Control;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(20, 302);
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
            this.grdDataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDataViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.id,
            this.name,
            this.tajviz_day,
            this.tajviz_date,
            this.ghabz_id,
            this.mablagh,
            this.paid});
            this.grdDataViewer.Location = new System.Drawing.Point(20, 76);
            this.grdDataViewer.MultiSelect = false;
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(735, 220);
            this.grdDataViewer.TabIndex = 31;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            dataGridViewCellStyle1.NullValue = "----";
            this.code.DefaultCellStyle = dataGridViewCellStyle1;
            this.code.HeaderText = "مشخصه تحویل";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 75;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle2.NullValue = "----";
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "شماره پرونده";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 75;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            dataGridViewCellStyle3.NullValue = "----";
            this.name.DefaultCellStyle = dataGridViewCellStyle3;
            this.name.HeaderText = "نام بیمار";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 130;
            // 
            // tajviz_day
            // 
            this.tajviz_day.DataPropertyName = "tajviz_day";
            dataGridViewCellStyle4.NullValue = "----";
            this.tajviz_day.DefaultCellStyle = dataGridViewCellStyle4;
            this.tajviz_day.HeaderText = "روز تجویز";
            this.tajviz_day.Name = "tajviz_day";
            this.tajviz_day.ReadOnly = true;
            this.tajviz_day.Width = 80;
            // 
            // tajviz_date
            // 
            this.tajviz_date.DataPropertyName = "tajviz_date";
            dataGridViewCellStyle5.NullValue = "----";
            this.tajviz_date.DefaultCellStyle = dataGridViewCellStyle5;
            this.tajviz_date.HeaderText = "تاریخ تجویز";
            this.tajviz_date.Name = "tajviz_date";
            this.tajviz_date.ReadOnly = true;
            this.tajviz_date.Width = 80;
            // 
            // ghabz_id
            // 
            this.ghabz_id.DataPropertyName = "ghabz_id";
            dataGridViewCellStyle6.NullValue = "----";
            this.ghabz_id.DefaultCellStyle = dataGridViewCellStyle6;
            this.ghabz_id.HeaderText = "شماره قبض";
            this.ghabz_id.Name = "ghabz_id";
            this.ghabz_id.ReadOnly = true;
            this.ghabz_id.Width = 80;
            // 
            // mablagh
            // 
            this.mablagh.DataPropertyName = "mablagh";
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "----";
            this.mablagh.DefaultCellStyle = dataGridViewCellStyle7;
            this.mablagh.HeaderText = "هزینه درمان";
            this.mablagh.Name = "mablagh";
            this.mablagh.ReadOnly = true;
            this.mablagh.Width = 80;
            // 
            // paid
            // 
            this.paid.DataPropertyName = "paid";
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "----";
            this.paid.DefaultCellStyle = dataGridViewCellStyle8;
            this.paid.HeaderText = "مبلغ پرداختی";
            this.paid.Name = "paid";
            this.paid.ReadOnly = true;
            this.paid.Width = 80;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(474, 302);
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
            this.panel1.Controls.Add(this.txttodate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtfromdate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 58);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txttodate
            // 
            this.txttodate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txttodate.BackColor = System.Drawing.Color.White;
            this.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttodate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txttodate.ForeColor = System.Drawing.Color.Black;
            this.txttodate.Location = new System.Drawing.Point(335, 18);
            this.txttodate.Mask = "1300/00/00";
            this.txttodate.Name = "txttodate";
            this.txttodate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttodate.Size = new System.Drawing.Size(130, 22);
            this.txttodate.TabIndex = 1;
            this.txttodate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttodate.Leave += new System.EventHandler(this.Leave_Action);
            this.txttodate.Enter += new System.EventHandler(this.Enter_Action);
            this.txttodate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(471, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 82;
            this.label3.Text = "تا تاریخ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtfromdate
            // 
            this.txtfromdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtfromdate.BackColor = System.Drawing.Color.White;
            this.txtfromdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfromdate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtfromdate.ForeColor = System.Drawing.Color.Black;
            this.txtfromdate.Location = new System.Drawing.Point(548, 18);
            this.txtfromdate.Mask = "1300/00/00";
            this.txtfromdate.Name = "txtfromdate";
            this.txtfromdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfromdate.Size = new System.Drawing.Size(130, 22);
            this.txtfromdate.TabIndex = 0;
            this.txtfromdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfromdate.Leave += new System.EventHandler(this.Leave_Action);
            this.txtfromdate.Enter += new System.EventHandler(this.Enter_Action);
            this.txtfromdate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(684, 22);
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
            this.btnfilter.Location = new System.Drawing.Point(3, 5);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(96, 42);
            this.btnfilter.TabIndex = 3;
            this.btnfilter.Text = "جستجو";
            this.btnfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // btnsabegheh
            // 
            this.btnsabegheh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsabegheh.BackColor = System.Drawing.SystemColors.Control;
            this.btnsabegheh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnsabegheh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnsabegheh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnsabegheh.Image = ((System.Drawing.Image)(resources.GetObject("btnsabegheh.Image")));
            this.btnsabegheh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsabegheh.Location = new System.Drawing.Point(615, 302);
            this.btnsabegheh.Name = "btnsabegheh";
            this.btnsabegheh.Size = new System.Drawing.Size(135, 42);
            this.btnsabegheh.TabIndex = 46;
            this.btnsabegheh.Text = "سابقه مالی بیمار";
            this.btnsabegheh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsabegheh.UseVisualStyleBackColor = true;
            this.btnsabegheh.Click += new System.EventHandler(this.btnsabegheh_Click);
            // 
            // pnlpaid
            // 
            this.pnlpaid.BackColor = System.Drawing.Color.SeaShell;
            this.pnlpaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpaid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlpaid.Location = new System.Drawing.Point(136, 321);
            this.pnlpaid.Name = "pnlpaid";
            this.pnlpaid.Size = new System.Drawing.Size(18, 18);
            this.pnlpaid.TabIndex = 81;
            this.pnlpaid.Click += new System.EventHandler(this.pnlpaid_Click);
            // 
            // pnlnotpaid
            // 
            this.pnlnotpaid.BackColor = System.Drawing.Color.Pink;
            this.pnlnotpaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlnotpaid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlnotpaid.Location = new System.Drawing.Point(184, 321);
            this.pnlnotpaid.Name = "pnlnotpaid";
            this.pnlnotpaid.Size = new System.Drawing.Size(18, 18);
            this.pnlnotpaid.TabIndex = 82;
            this.pnlnotpaid.Click += new System.EventHandler(this.pnlnotpaid_Click);
            // 
            // pnlpaidnodrugs
            // 
            this.pnlpaidnodrugs.BackColor = System.Drawing.Color.PowderBlue;
            this.pnlpaidnodrugs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpaidnodrugs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlpaidnodrugs.Location = new System.Drawing.Point(160, 321);
            this.pnlpaidnodrugs.Name = "pnlpaidnodrugs";
            this.pnlpaidnodrugs.Size = new System.Drawing.Size(18, 18);
            this.pnlpaidnodrugs.TabIndex = 82;
            this.pnlpaidnodrugs.Click += new System.EventHandler(this.pnlpaidnodrugs_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(208, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 83;
            this.label1.Text = "راهنما";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmGhabzJoinTajviz
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(767, 351);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsabegheh);
            this.Controls.Add(this.pnlpaidnodrugs);
            this.Controls.Add(this.pnlnotpaid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlpaid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmGhabzJoinTajviz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "لسیت پیگیری امور مالی بیماران";
            this.Load += new System.EventHandler(this.frmGhabzJoinTajviz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        public DateMaskedTextbox txtfromdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.Button btnsabegheh;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tajviz_day;
        private System.Windows.Forms.DataGridViewTextBoxColumn tajviz_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghabz_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mablagh;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlpaidnodrugs;
        private System.Windows.Forms.Panel pnlnotpaid;
        private System.Windows.Forms.Panel pnlpaid;
        public DateMaskedTextbox txttodate;
        private System.Windows.Forms.Label label3;
    }
}