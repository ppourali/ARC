namespace Mehr.Presentation_Layers
{
    partial class frmAction_LogsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAction_LogsView));
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtsharh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtuser_code = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txttodate = new Mehr.DateMaskedTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfromdate = new Mehr.DateMaskedTextbox();
            this.txtuser_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.cmddel = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
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
            this.btnexit.Location = new System.Drawing.Point(12, 488);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 42);
            this.btnexit.TabIndex = 7;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // grdDataViewer
            // 
            this.grdDataViewer.AllowUserToAddRows = false;
            this.grdDataViewer.AllowUserToDeleteRows = false;
            this.grdDataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDataViewer.Location = new System.Drawing.Point(12, 88);
            this.grdDataViewer.MultiSelect = false;
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(744, 394);
            this.grdDataViewer.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtsharh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txtuser_code);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txttodate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtfromdate);
            this.panel1.Controls.Add(this.txtuser_name);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 70);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txtsharh
            // 
            this.txtsharh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsharh.BackColor = System.Drawing.Color.White;
            this.txtsharh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsharh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtsharh.ForeColor = System.Drawing.Color.Black;
            this.txtsharh.Location = new System.Drawing.Point(150, 8);
            this.txtsharh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsharh.MaxLength = 50;
            this.txtsharh.Name = "txtsharh";
            this.txtsharh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtsharh.Size = new System.Drawing.Size(130, 22);
            this.txtsharh.TabIndex = 4;
            this.txtsharh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsharh.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtsharh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtsharh.Leave += new System.EventHandler(this.Leave_Action);
            this.txtsharh.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(288, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 106;
            this.label3.Text = "شرح عملیات";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(150, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(163, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "نـمـایـش ریز عملیات روز جـاری";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtuser_code
            // 
            this.txtuser_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuser_code.BackColor = System.Drawing.Color.White;
            this.txtuser_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtuser_code.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtuser_code.ForeColor = System.Drawing.Color.Black;
            this.txtuser_code.Location = new System.Drawing.Point(388, 8);
            this.txtuser_code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtuser_code.MaxLength = 4;
            this.txtuser_code.Name = "txtuser_code";
            this.txtuser_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtuser_code.Size = new System.Drawing.Size(104, 22);
            this.txtuser_code.TabIndex = 2;
            this.txtuser_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtuser_code.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtuser_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtuser_code.Leave += new System.EventHandler(this.Leave_Action);
            this.txtuser_code.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(500, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 103;
            this.label5.Text = "کد کاربر";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttodate
            // 
            this.txttodate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttodate.BackColor = System.Drawing.Color.White;
            this.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttodate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txttodate.ForeColor = System.Drawing.Color.Black;
            this.txttodate.Location = new System.Drawing.Point(567, 36);
            this.txttodate.Mask = "1300/00/00";
            this.txttodate.Name = "txttodate";
            this.txttodate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttodate.Size = new System.Drawing.Size(112, 22);
            this.txttodate.TabIndex = 1;
            this.txttodate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttodate.Leave += new System.EventHandler(this.Leave_Action);
            this.txttodate.Enter += new System.EventHandler(this.Enter_Action);
            this.txttodate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(685, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 100;
            this.label1.Text = "تا تاریخ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtfromdate
            // 
            this.txtfromdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtfromdate.BackColor = System.Drawing.Color.White;
            this.txtfromdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfromdate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtfromdate.ForeColor = System.Drawing.Color.Black;
            this.txtfromdate.Location = new System.Drawing.Point(567, 6);
            this.txtfromdate.Mask = "1300/00/00";
            this.txtfromdate.Name = "txtfromdate";
            this.txtfromdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfromdate.Size = new System.Drawing.Size(112, 22);
            this.txtfromdate.TabIndex = 0;
            this.txtfromdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfromdate.Leave += new System.EventHandler(this.Leave_Action);
            this.txtfromdate.Enter += new System.EventHandler(this.Enter_Action);
            this.txtfromdate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtuser_name
            // 
            this.txtuser_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuser_name.BackColor = System.Drawing.Color.White;
            this.txtuser_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtuser_name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtuser_name.ForeColor = System.Drawing.Color.Black;
            this.txtuser_name.Location = new System.Drawing.Point(388, 38);
            this.txtuser_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtuser_name.MaxLength = 50;
            this.txtuser_name.Name = "txtuser_name";
            this.txtuser_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtuser_name.Size = new System.Drawing.Size(104, 22);
            this.txtuser_name.TabIndex = 3;
            this.txtuser_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtuser_name.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtuser_name.Leave += new System.EventHandler(this.Leave_Action);
            this.txtuser_name.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(500, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 14);
            this.label4.TabIndex = 81;
            this.label4.Text = "نام کاربر";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(685, 10);
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
            this.btnfilter.Location = new System.Drawing.Point(12, 12);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(96, 42);
            this.btnfilter.TabIndex = 6;
            this.btnfilter.Text = "جستجو";
            this.btnfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // cmddel
            // 
            this.cmddel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmddel.BackColor = System.Drawing.Color.White;
            this.cmddel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmddel.Image = ((System.Drawing.Image)(resources.GetObject("cmddel.Image")));
            this.cmddel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmddel.Location = new System.Drawing.Point(571, 488);
            this.cmddel.Name = "cmddel";
            this.cmddel.Size = new System.Drawing.Size(185, 42);
            this.cmddel.TabIndex = 33;
            this.cmddel.Text = "حذف تمامی ریز عملیات";
            this.cmddel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmddel.UseVisualStyleBackColor = true;
            this.cmddel.Click += new System.EventHandler(this.cmddel_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.SystemColors.Control;
            this.btnprint.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnprint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(114, 488);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(96, 42);
            this.btnprint.TabIndex = 34;
            this.btnprint.Text = "چاپ";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // frmAction_LogsView
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(768, 542);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.cmddel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdDataViewer);
            this.Controls.Add(this.btnexit);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAction_LogsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "نمایش لیست ریز عملیات کاربران";
            this.Load += new System.EventHandler(this.frmAction_LogsView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnfilter;
        public DateMaskedTextbox txtfromdate;
        private System.Windows.Forms.Label label2;
        public DateMaskedTextbox txttodate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtuser_code;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtuser_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtsharh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmddel;
        private System.Windows.Forms.Button btnprint;
    }
}