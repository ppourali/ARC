namespace Mehr.Presentation_Layers
{
    partial class frmGhabzView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGhabzView));
            this.btnprint = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtid = new Mehr.IDTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txttodate = new Mehr.DateMaskedTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmos_date = new Mehr.DateMaskedTextbox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtghabz_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnsabegheh = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtsummablagh = new System.Windows.Forms.TextBox();
            this.txtsumpaid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.btnprint.Location = new System.Drawing.Point(122, 493);
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
            this.grdDataViewer.Location = new System.Drawing.Point(20, 105);
            this.grdDataViewer.MultiSelect = false;
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(802, 382);
            this.grdDataViewer.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txttodate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtmos_date);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtghabz_id);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 87);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txtid
            // 
            this.txtid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(382, 17);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtid.MaxLength = 15;
            this.txtid.Name = "txtid";
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(130, 22);
            this.txtid.TabIndex = 1;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(520, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 103;
            this.label5.Text = "شماره پرونده";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(643, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(147, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "نـمـایـش قـبـوض روز جـاری";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txttodate
            // 
            this.txttodate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txttodate.BackColor = System.Drawing.Color.White;
            this.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttodate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txttodate.ForeColor = System.Drawing.Color.Black;
            this.txttodate.Location = new System.Drawing.Point(144, 48);
            
            this.txttodate.Name = "txttodate";
            this.txttodate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttodate.Size = new System.Drawing.Size(130, 22);
            this.txttodate.TabIndex = 4;
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
            this.label1.Location = new System.Drawing.Point(280, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 100;
            this.label1.Text = "تا تاریخ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmos_date
            // 
            this.txtmos_date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtmos_date.BackColor = System.Drawing.Color.White;
            this.txtmos_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmos_date.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtmos_date.ForeColor = System.Drawing.Color.Black;
            this.txtmos_date.Location = new System.Drawing.Point(144, 17);
            
            this.txtmos_date.Name = "txtmos_date";
            this.txtmos_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmos_date.Size = new System.Drawing.Size(130, 22);
            this.txtmos_date.TabIndex = 3;
            this.txtmos_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmos_date.Leave += new System.EventHandler(this.Leave_Action);
            this.txtmos_date.Enter += new System.EventHandler(this.Enter_Action);
            this.txtmos_date.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtname.BackColor = System.Drawing.Color.White;
            this.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtname.ForeColor = System.Drawing.Color.Black;
            this.txtname.Location = new System.Drawing.Point(382, 48);
            this.txtname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtname.MaxLength = 50;
            this.txtname.Name = "txtname";
            this.txtname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtname.Size = new System.Drawing.Size(130, 22);
            this.txtname.TabIndex = 2;
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
            this.label4.Location = new System.Drawing.Point(520, 51);
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
            this.label2.Location = new System.Drawing.Point(280, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 80;
            this.label2.Text = "قبض از تاریخ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtghabz_id
            // 
            this.txtghabz_id.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtghabz_id.BackColor = System.Drawing.Color.White;
            this.txtghabz_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghabz_id.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtghabz_id.ForeColor = System.Drawing.Color.Black;
            this.txtghabz_id.Location = new System.Drawing.Point(643, 17);
            this.txtghabz_id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtghabz_id.MaxLength = 6;
            this.txtghabz_id.Name = "txtghabz_id";
            this.txtghabz_id.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtghabz_id.Size = new System.Drawing.Size(73, 22);
            this.txtghabz_id.TabIndex = 0;
            this.txtghabz_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtghabz_id.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtghabz_id.Leave += new System.EventHandler(this.Leave_Action);
            this.txtghabz_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtghabz_id.Enter += new System.EventHandler(this.Enter_Action);
            this.txtghabz_id.Validating += new System.ComponentModel.CancelEventHandler(this.Validating_Action);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(724, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 79;
            this.label3.Text = "شماره قبض";
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
            this.btnfilter.Location = new System.Drawing.Point(14, 21);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(96, 42);
            this.btnfilter.TabIndex = 6;
            this.btnfilter.Text = "جستجو";
            this.btnfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
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
            this.btndel.Location = new System.Drawing.Point(621, 493);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(96, 42);
            this.btndel.TabIndex = 42;
            this.btndel.Text = "حذف";
            this.btndel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click_1);
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
            this.btnedit.Location = new System.Drawing.Point(723, 493);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(96, 42);
            this.btnedit.TabIndex = 43;
            this.btnedit.Text = "ویرایش";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click_1);
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
            this.btnsabegheh.Location = new System.Drawing.Point(480, 493);
            this.btnsabegheh.Name = "btnsabegheh";
            this.btnsabegheh.Size = new System.Drawing.Size(135, 42);
            this.btnsabegheh.TabIndex = 47;
            this.btnsabegheh.Text = "سابقه مالی بیمار";
            this.btnsabegheh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsabegheh.UseVisualStyleBackColor = true;
            this.btnsabegheh.Click += new System.EventHandler(this.btnsabegheh_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(408, 494);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 116;
            this.pictureBox1.TabStop = false;
            // 
            // txtsummablagh
            // 
            this.txtsummablagh.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtsummablagh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsummablagh.Location = new System.Drawing.Point(321, 493);
            this.txtsummablagh.Name = "txtsummablagh";
            this.txtsummablagh.ReadOnly = true;
            this.txtsummablagh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtsummablagh.Size = new System.Drawing.Size(81, 21);
            this.txtsummablagh.TabIndex = 115;
            this.txtsummablagh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtsumpaid
            // 
            this.txtsumpaid.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtsumpaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsumpaid.Location = new System.Drawing.Point(240, 493);
            this.txtsumpaid.Name = "txtsumpaid";
            this.txtsumpaid.ReadOnly = true;
            this.txtsumpaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtsumpaid.Size = new System.Drawing.Size(81, 21);
            this.txtsumpaid.TabIndex = 117;
            this.txtsumpaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmGhabzView
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(834, 542);
            this.Controls.Add(this.txtsumpaid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtsummablagh);
            this.Controls.Add(this.btnsabegheh);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGhabzView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "نمایش لیست قبوض - واقعی";
            this.Load += new System.EventHandler(this.frmGhabzView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnfilter;
        public DateMaskedTextbox txtmos_date;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtghabz_id;
        private System.Windows.Forms.Label label3;
        public DateMaskedTextbox txttodate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.CheckBox checkBox1;
        private IDTextBox txtid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnsabegheh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtsummablagh;
        private System.Windows.Forms.TextBox txtsumpaid;
    }
}