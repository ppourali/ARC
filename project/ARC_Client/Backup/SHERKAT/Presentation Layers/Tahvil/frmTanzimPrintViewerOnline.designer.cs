namespace Mehr.Presentation_Layers
{
    partial class frmTanzimPrintViewerOnline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTanzimPrintViewerOnline));
            this.rptParastar = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtid = new Mehr.IDTextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.grpParastar = new System.Windows.Forms.GroupBox();
            this.grpPezeshk = new System.Windows.Forms.GroupBox();
            this.rptPezeshk = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMoveFirst = new System.Windows.Forms.Button();
            this.txtRecordPosition = new System.Windows.Forms.TextBox();
            this.btnMovePrevious = new System.Windows.Forms.Button();
            this.btnMoveLast = new System.Windows.Forms.Button();
            this.btnMoveNext = new System.Windows.Forms.Button();
            this.grpParastar.SuspendLayout();
            this.grpPezeshk.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptParastar
            // 
            this.rptParastar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptParastar.Location = new System.Drawing.Point(3, 17);
            this.rptParastar.Name = "rptParastar";
            this.rptParastar.ShowBackButton = false;
            this.rptParastar.ShowContextMenu = false;
            this.rptParastar.ShowCredentialPrompts = false;
            this.rptParastar.ShowDocumentMapButton = false;
            this.rptParastar.ShowFindControls = false;
            this.rptParastar.ShowParameterPrompts = false;
            this.rptParastar.Size = new System.Drawing.Size(446, 583);
            this.rptParastar.TabIndex = 0;
            this.rptParastar.TabStop = false;
            this.rptParastar.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Cursor = System.Windows.Forms.Cursors.Default;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(400, 18);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 110;
            this.label22.Text = "نام بیمار";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(127, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "شماره پرونده";
            // 
            // txtid
            // 
            this.txtid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Enabled = false;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(3, 15);
            this.txtid.MaxLength = 15;
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(118, 22);
            this.txtid.TabIndex = 107;
            this.txtid.TabStop = false;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            // 
            // txtname
            // 
            this.txtname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtname.BackColor = System.Drawing.Color.White;
            this.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtname.Enabled = false;
            this.txtname.ForeColor = System.Drawing.Color.Black;
            this.txtname.Location = new System.Drawing.Point(229, 15);
            this.txtname.MaxLength = 4;
            this.txtname.Name = "txtname";
            this.txtname.ReadOnly = true;
            this.txtname.Size = new System.Drawing.Size(165, 21);
            this.txtname.TabIndex = 115;
            this.txtname.TabStop = false;
            this.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpParastar
            // 
            this.grpParastar.Controls.Add(this.rptParastar);
            this.grpParastar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpParastar.Location = new System.Drawing.Point(460, 52);
            this.grpParastar.Name = "grpParastar";
            this.grpParastar.Size = new System.Drawing.Size(452, 603);
            this.grpParastar.TabIndex = 116;
            this.grpParastar.TabStop = false;
            this.grpParastar.Text = "8- فرم پرستار";
            // 
            // grpPezeshk
            // 
            this.grpPezeshk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPezeshk.Controls.Add(this.rptPezeshk);
            this.grpPezeshk.Location = new System.Drawing.Point(3, 52);
            this.grpPezeshk.Name = "grpPezeshk";
            this.grpPezeshk.Size = new System.Drawing.Size(451, 603);
            this.grpPezeshk.TabIndex = 117;
            this.grpPezeshk.TabStop = false;
            this.grpPezeshk.Text = "6- فرم پزشک";
            // 
            // rptPezeshk
            // 
            this.rptPezeshk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rptPezeshk.Location = new System.Drawing.Point(3, 17);
            this.rptPezeshk.Name = "rptPezeshk";
            this.rptPezeshk.ShowBackButton = false;
            this.rptPezeshk.ShowContextMenu = false;
            this.rptPezeshk.ShowCredentialPrompts = false;
            this.rptPezeshk.ShowDocumentMapButton = false;
            this.rptPezeshk.ShowFindControls = false;
            this.rptPezeshk.ShowParameterPrompts = false;
            this.rptPezeshk.Size = new System.Drawing.Size(445, 583);
            this.rptPezeshk.TabIndex = 0;
            this.rptPezeshk.TabStop = false;
            this.rptPezeshk.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpParastar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpPezeshk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 658);
            this.tableLayoutPanel1.TabIndex = 118;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.txtid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(460, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 43);
            this.groupBox1.TabIndex = 119;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMoveFirst);
            this.groupBox2.Controls.Add(this.txtRecordPosition);
            this.groupBox2.Controls.Add(this.btnMovePrevious);
            this.groupBox2.Controls.Add(this.btnMoveLast);
            this.groupBox2.Controls.Add(this.btnMoveNext);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 43);
            this.groupBox2.TabIndex = 120;
            this.groupBox2.TabStop = false;
            // 
            // btnMoveFirst
            // 
            this.btnMoveFirst.BackColor = System.Drawing.Color.White;
            this.btnMoveFirst.Font = new System.Drawing.Font("Tahoma", 7F);
            this.btnMoveFirst.Location = new System.Drawing.Point(9, 11);
            this.btnMoveFirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveFirst.Name = "btnMoveFirst";
            this.btnMoveFirst.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveFirst.Size = new System.Drawing.Size(25, 25);
            this.btnMoveFirst.TabIndex = 25;
            this.btnMoveFirst.TabStop = false;
            this.btnMoveFirst.Text = "|<";
            this.btnMoveFirst.UseVisualStyleBackColor = false;
            this.btnMoveFirst.Click += new System.EventHandler(this.btnMoveFirst_Click);
            // 
            // txtRecordPosition
            // 
            this.txtRecordPosition.BackColor = System.Drawing.Color.White;
            this.txtRecordPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecordPosition.Enabled = false;
            this.txtRecordPosition.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtRecordPosition.ForeColor = System.Drawing.Color.Black;
            this.txtRecordPosition.Location = new System.Drawing.Point(68, 13);
            this.txtRecordPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRecordPosition.Name = "txtRecordPosition";
            this.txtRecordPosition.ReadOnly = true;
            this.txtRecordPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRecordPosition.Size = new System.Drawing.Size(154, 22);
            this.txtRecordPosition.TabIndex = 27;
            this.txtRecordPosition.TabStop = false;
            this.txtRecordPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMovePrevious
            // 
            this.btnMovePrevious.BackColor = System.Drawing.Color.White;
            this.btnMovePrevious.Font = new System.Drawing.Font("Tahoma", 7F);
            this.btnMovePrevious.Location = new System.Drawing.Point(37, 11);
            this.btnMovePrevious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMovePrevious.Name = "btnMovePrevious";
            this.btnMovePrevious.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMovePrevious.Size = new System.Drawing.Size(25, 25);
            this.btnMovePrevious.TabIndex = 24;
            this.btnMovePrevious.TabStop = false;
            this.btnMovePrevious.Text = "<";
            this.btnMovePrevious.UseVisualStyleBackColor = false;
            this.btnMovePrevious.Click += new System.EventHandler(this.btnMovePrevious_Click);
            // 
            // btnMoveLast
            // 
            this.btnMoveLast.BackColor = System.Drawing.Color.White;
            this.btnMoveLast.Font = new System.Drawing.Font("Tahoma", 7F);
            this.btnMoveLast.Location = new System.Drawing.Point(256, 11);
            this.btnMoveLast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveLast.Name = "btnMoveLast";
            this.btnMoveLast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveLast.Size = new System.Drawing.Size(25, 25);
            this.btnMoveLast.TabIndex = 26;
            this.btnMoveLast.TabStop = false;
            this.btnMoveLast.Text = ">|";
            this.btnMoveLast.UseVisualStyleBackColor = false;
            this.btnMoveLast.Click += new System.EventHandler(this.btnMoveLast_Click);
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.BackColor = System.Drawing.Color.White;
            this.btnMoveNext.Font = new System.Drawing.Font("Tahoma", 7F);
            this.btnMoveNext.Location = new System.Drawing.Point(228, 11);
            this.btnMoveNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveNext.Size = new System.Drawing.Size(25, 25);
            this.btnMoveNext.TabIndex = 23;
            this.btnMoveNext.TabStop = false;
            this.btnMoveNext.Text = ">";
            this.btnMoveNext.UseVisualStyleBackColor = false;
            this.btnMoveNext.Click += new System.EventHandler(this.btnMoveNext_Click);
            // 
            // frmTanzimPrintViewerOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 658);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmTanzimPrintViewerOnline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم تنظیم دوز بیمار";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.printviewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.grpParastar.ResumeLayout(false);
            this.grpPezeshk.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer rptParastar;
        public System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        public IDTextBox txtid;
        public System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.GroupBox grpParastar;
        private System.Windows.Forms.GroupBox grpPezeshk;
        public Microsoft.Reporting.WinForms.ReportViewer rptPezeshk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMoveFirst;
        private System.Windows.Forms.TextBox txtRecordPosition;
        private System.Windows.Forms.Button btnMovePrevious;
        private System.Windows.Forms.Button btnMoveLast;
        private System.Windows.Forms.Button btnMoveNext;


        // private InvestmentDataSet InvestmentDataSet;
        //private Investment.InvestmentDataSetTableAdapters.PaymentsTableAdapter paymentsTableAdapter;




    }
}