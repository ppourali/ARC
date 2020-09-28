namespace Mehr.Presentation_Layers
{
    partial class frmContactView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactView));
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.btndel = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtfullname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
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
            this.btnexit.Location = new System.Drawing.Point(22, 370);
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
            this.grdDataViewer.Location = new System.Drawing.Point(20, 72);
            this.grdDataViewer.MultiSelect = false;
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(528, 285);
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
            this.btndel.Location = new System.Drawing.Point(235, 370);
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
            this.btnadd.Location = new System.Drawing.Point(439, 370);
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
            this.btnedit.Location = new System.Drawing.Point(337, 370);
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
            this.panel1.Controls.Add(this.txtfullname);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 54);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txtfullname
            // 
            this.txtfullname.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtfullname.AutoCompleteCustomSource.AddRange(new string[] {
            "تریاک",
            "شیشه",
            "شیره",
            "هروئین",
            "کراک",
            "حشیش",
            "متادون",
            "کدیین",
            "شربت اکسپکتورانت"});
            this.txtfullname.BackColor = System.Drawing.Color.White;
            this.txtfullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfullname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtfullname.ForeColor = System.Drawing.Color.Black;
            this.txtfullname.Location = new System.Drawing.Point(315, 12);
            this.txtfullname.MaxLength = 50;
            this.txtfullname.Name = "txtfullname";
            this.txtfullname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfullname.Size = new System.Drawing.Size(134, 22);
            this.txtfullname.TabIndex = 4;
            this.txtfullname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfullname.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtfullname.Leave += new System.EventHandler(this.Leave_Action);
            this.txtfullname.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(456, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 14);
            this.label12.TabIndex = 98;
            this.label12.Text = "نام مخاطب";
            // 
            // btnfilter
            // 
            this.btnfilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnfilter.Enabled = false;
            this.btnfilter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnfilter.ForeColor = System.Drawing.Color.Black;
            this.btnfilter.Image = ((System.Drawing.Image)(resources.GetObject("btnfilter.Image")));
            this.btnfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfilter.Location = new System.Drawing.Point(3, 3);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(96, 42);
            this.btnfilter.TabIndex = 6;
            this.btnfilter.Text = "جستجو";
            this.btnfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // frmContactView
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(560, 424);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmContactView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "نمایش اطلاعات مخاطبین";
            this.Load += new System.EventHandler(this.frmContactView_Load);
            this.Activated += new System.EventHandler(this.frmContactView_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtfullname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnfilter;
    }
}