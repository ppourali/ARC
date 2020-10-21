namespace Mehr.Presentation_Layers
{
    partial class frmSicksStatusView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSicksStatusView));
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk0 = new System.Windows.Forms.CheckBox();
            this.chkDeActive = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.btnsabegheh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txttodate = new Mehr.DateMaskedTextbox();
            this.txtfrom_date = new Mehr.DateMaskedTextbox();
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
            this.grdDataViewer.Location = new System.Drawing.Point(20, 80);
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(1215, 407);
            this.grdDataViewer.TabIndex = 31;
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
            this.button1.Location = new System.Drawing.Point(1096, 493);
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
            this.panel1.Controls.Add(this.chk3);
            this.panel1.Controls.Add(this.chk1);
            this.panel1.Controls.Add(this.chk2);
            this.panel1.Controls.Add(this.chk0);
            this.panel1.Controls.Add(this.chkDeActive);
            this.panel1.Controls.Add(this.chkActive);
            this.panel1.Controls.Add(this.txttodate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtfrom_date);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1215, 62);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.BackColor = System.Drawing.Color.MistyRose;
            this.chk3.Checked = true;
            this.chk3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk3.Location = new System.Drawing.Point(217, 35);
            this.chk3.Name = "chk3";
            this.chk3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk3.Size = new System.Drawing.Size(182, 17);
            this.chk3.TabIndex = 106;
            this.chk3.Text = "3- پرونده غیرفعال - عدم تجویز دارو";
            this.chk3.UseVisualStyleBackColor = false;
            this.chk3.CheckedChanged += new System.EventHandler(this.chkS_CheckedChanged);
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.chk1.Checked = true;
            this.chk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1.Location = new System.Drawing.Point(417, 35);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(159, 17);
            this.chk1.TabIndex = 105;
            this.chk1.Text = "1- پرونده غیرفعال - تجویز دارو";
            this.chk1.UseVisualStyleBackColor = false;
            this.chk1.CheckedChanged += new System.EventHandler(this.chkS_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chk2.Checked = true;
            this.chk2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2.Location = new System.Drawing.Point(227, 14);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(172, 17);
            this.chk2.TabIndex = 104;
            this.chk2.Text = "2- پرونده فعــال - عدم تجویز دارو";
            this.chk2.UseVisualStyleBackColor = false;
            this.chk2.CheckedChanged += new System.EventHandler(this.chkS_CheckedChanged);
            // 
            // chk0
            // 
            this.chk0.AutoSize = true;
            this.chk0.BackColor = System.Drawing.Color.Pink;
            this.chk0.Checked = true;
            this.chk0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk0.Location = new System.Drawing.Point(427, 14);
            this.chk0.Name = "chk0";
            this.chk0.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk0.Size = new System.Drawing.Size(149, 17);
            this.chk0.TabIndex = 103;
            this.chk0.Text = "0- پرونده فعــال - تجویز دارو";
            this.chk0.ThreeState = true;
            this.chk0.UseVisualStyleBackColor = false;
            this.chk0.CheckedChanged += new System.EventHandler(this.chkS_CheckedChanged);
            // 
            // chkDeActive
            // 
            this.chkDeActive.AutoSize = true;
            this.chkDeActive.Location = new System.Drawing.Point(667, 37);
            this.chkDeActive.Name = "chkDeActive";
            this.chkDeActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDeActive.Size = new System.Drawing.Size(150, 17);
            this.chkDeActive.TabIndex = 102;
            this.chkDeActive.Text = "نمایش پرونده های غیرفعال";
            this.chkDeActive.UseVisualStyleBackColor = true;
            this.chkDeActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(683, 14);
            this.chkActive.Name = "chkActive";
            this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkActive.Size = new System.Drawing.Size(134, 17);
            this.chkActive.TabIndex = 101;
            this.chkActive.Text = "نمایش پرونده های فعال";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(968, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 100;
            this.label1.Text = "تا تاریخ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1157, 26);
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
            this.btnfilter.Location = new System.Drawing.Point(12, 10);
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
            this.btnsabegheh.Location = new System.Drawing.Point(783, 493);
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
            this.button2.Location = new System.Drawing.Point(924, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 42);
            this.button2.TabIndex = 48;
            this.button2.Text = "سابقه دارویی بیمار-واقعی";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txttodate
            // 
            this.txttodate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txttodate.BackColor = System.Drawing.Color.White;
            this.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttodate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txttodate.ForeColor = System.Drawing.Color.Black;
            this.txttodate.Location = new System.Drawing.Point(832, 22);
            this.txttodate.Mask = "1300/00/00";
            this.txttodate.Name = "txttodate";
            this.txttodate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttodate.Size = new System.Drawing.Size(130, 22);
            this.txttodate.TabIndex = 3;
            this.txttodate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttodate.Leave += new System.EventHandler(this.Leave_Action);
            this.txttodate.Enter += new System.EventHandler(this.Enter_Action);
            this.txttodate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtfrom_date
            // 
            this.txtfrom_date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtfrom_date.BackColor = System.Drawing.Color.White;
            this.txtfrom_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfrom_date.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtfrom_date.ForeColor = System.Drawing.Color.Black;
            this.txtfrom_date.Location = new System.Drawing.Point(1021, 22);
            this.txtfrom_date.Mask = "1300/00/00";
            this.txtfrom_date.Name = "txtfrom_date";
            this.txtfrom_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfrom_date.Size = new System.Drawing.Size(130, 22);
            this.txtfrom_date.TabIndex = 2;
            this.txtfrom_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfrom_date.Leave += new System.EventHandler(this.Leave_Action);
            this.txtfrom_date.Enter += new System.EventHandler(this.Enter_Action);
            this.txtfrom_date.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // frmSicksStatusView
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(1247, 542);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnsabegheh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(972, 500);
            this.Name = "frmSicksStatusView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "نمایش وضعیت بیماران";
            this.Load += new System.EventHandler(this.frmSicksStatusView_Load);
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
        public DateMaskedTextbox txttodate;
        private System.Windows.Forms.Label label1;
        public DateMaskedTextbox txtfrom_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.Button btnsabegheh;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkDeActive;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk0;
    }
}