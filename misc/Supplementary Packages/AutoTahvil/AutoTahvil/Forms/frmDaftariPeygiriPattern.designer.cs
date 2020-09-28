namespace Mehr.Presentation_Layers
{
    partial class frmDaftariPeygiriPattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDaftariPeygiriPattern));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grdvisit = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.darman_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_visit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_ravan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ravan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_azm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.azm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtdate = new Mehr.DateMaskedTextbox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdvisit)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(912, 32);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "پیگیری بیمار به تاریخ :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 54);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "نمایش";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdvisit
            // 
            this.grdvisit.AllowUserToAddRows = false;
            this.grdvisit.AllowUserToDeleteRows = false;
            this.grdvisit.AllowUserToResizeColumns = false;
            this.grdvisit.AllowUserToResizeRows = false;
            this.grdvisit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grdvisit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvisit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.darman_date,
            this.period,
            this.last_visit,
            this.visit,
            this.last_ravan,
            this.ravan,
            this.last_azm,
            this.azm});
            this.grdvisit.Location = new System.Drawing.Point(12, 72);
            this.grdvisit.MultiSelect = false;
            this.grdvisit.Name = "grdvisit";
            this.grdvisit.ReadOnly = true;
            this.grdvisit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdvisit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdvisit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdvisit.Size = new System.Drawing.Size(1013, 406);
            this.grdvisit.TabIndex = 113;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(754, 484);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(131, 42);
            this.button2.TabIndex = 115;
            this.button2.TabStop = false;
            this.button2.Text = "ثبت نظر روانشناس";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.button1.Location = new System.Drawing.Point(891, 484);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(130, 42);
            this.button1.TabIndex = 114;
            this.button1.TabStop = false;
            this.button1.Text = "ثبت دستور پزشک";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnexit
            // 
            this.btnexit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(12, 484);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 42);
            this.btnexit.TabIndex = 117;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.Frozen = true;
            this.name.HeaderText = "نام و نام خانوادگی";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // darman_date
            // 
            this.darman_date.DataPropertyName = "darman_date";
            this.darman_date.Frozen = true;
            this.darman_date.HeaderText = "شروع درمان";
            this.darman_date.Name = "darman_date";
            this.darman_date.ReadOnly = true;
            // 
            // period
            // 
            this.period.DataPropertyName = "period";
            this.period.Frozen = true;
            this.period.HeaderText = "دوره";
            this.period.Name = "period";
            this.period.ReadOnly = true;
            // 
            // last_visit
            // 
            this.last_visit.DataPropertyName = "last_visit";
            this.last_visit.Frozen = true;
            this.last_visit.HeaderText = "تاریخ آخرین ویزیت پزشک";
            this.last_visit.Name = "last_visit";
            this.last_visit.ReadOnly = true;
            // 
            // visit
            // 
            this.visit.DataPropertyName = "visit";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.visit.DefaultCellStyle = dataGridViewCellStyle9;
            this.visit.Frozen = true;
            this.visit.HeaderText = "ویزیت پزشک";
            this.visit.Name = "visit";
            this.visit.ReadOnly = true;
            // 
            // last_ravan
            // 
            this.last_ravan.DataPropertyName = "last_ravan";
            this.last_ravan.Frozen = true;
            this.last_ravan.HeaderText = "تاریخ آخرین نظر روانشناس";
            this.last_ravan.Name = "last_ravan";
            this.last_ravan.ReadOnly = true;
            // 
            // ravan
            // 
            this.ravan.DataPropertyName = "ravan";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ravan.DefaultCellStyle = dataGridViewCellStyle10;
            this.ravan.Frozen = true;
            this.ravan.HeaderText = "ویزیت روانشناس";
            this.ravan.Name = "ravan";
            this.ravan.ReadOnly = true;
            this.ravan.Width = 103;
            // 
            // last_azm
            // 
            this.last_azm.DataPropertyName = "last_azm";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.last_azm.DefaultCellStyle = dataGridViewCellStyle11;
            this.last_azm.Frozen = true;
            this.last_azm.HeaderText = "تاریخ آخرین آزمایش";
            this.last_azm.Name = "last_azm";
            this.last_azm.ReadOnly = true;
            // 
            // azm
            // 
            this.azm.DataPropertyName = "azm";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.azm.DefaultCellStyle = dataGridViewCellStyle12;
            this.azm.Frozen = true;
            this.azm.HeaderText = "آزمایش";
            this.azm.Name = "azm";
            this.azm.ReadOnly = true;
            // 
            // txtdate
            // 
            this.txtdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdate.BackColor = System.Drawing.Color.White;
            this.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdate.ForeColor = System.Drawing.Color.Black;
            this.txtdate.Location = new System.Drawing.Point(776, 30);
            this.txtdate.Mask = "1300/00/00";
            this.txtdate.Name = "txtdate";
            this.txtdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdate.Size = new System.Drawing.Size(130, 22);
            this.txtdate.TabIndex = 1;
            this.txtdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdate.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdate.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(617, 484);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(131, 42);
            this.button3.TabIndex = 118;
            this.button3.TabStop = false;
            this.button3.Text = "ثبت آزمایش بیمار";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmDaftariPeygiriPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(1033, 538);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdvisit);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "frmDaftariPeygiriPattern";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پیگیری بیماران";
            this.Load += new System.EventHandler(this.printviewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdvisit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefresh;
        public DateMaskedTextbox txtdate;
        private System.Windows.Forms.DataGridView grdvisit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn darman_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn period;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_visit;
        private System.Windows.Forms.DataGridViewTextBoxColumn visit;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_ravan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ravan;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_azm;
        private System.Windows.Forms.DataGridViewTextBoxColumn azm;
        private System.Windows.Forms.Button button3;


        // private InvestmentDataSet InvestmentDataSet;
        //private Investment.InvestmentDataSetTableAdapters.PaymentsTableAdapter paymentsTableAdapter;




    }
}