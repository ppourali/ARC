namespace Mehr.Presentation_Layers
{
    partial class frmHazinehShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHazinehShow));
            this.btnprint = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtto_date = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfrom_date = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.txttype = new System.Windows.Forms.TextBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtsum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnprint.BackColor = System.Drawing.SystemColors.Control;
            this.btnprint.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnprint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(114, 465);
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
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(12, 465);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 42);
            this.btnexit.TabIndex = 30;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 104);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(613, 345);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtto_date);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtfrom_date);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnfilter);
            this.groupBox1.Controls.Add(this.txttype);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtto_date
            // 
            this.txtto_date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtto_date.BackColor = System.Drawing.Color.White;
            this.txtto_date.ForeColor = System.Drawing.Color.Black;
            this.txtto_date.Location = new System.Drawing.Point(26, 20);
            this.txtto_date.Mask = "1300/00/00";
            this.txtto_date.Name = "txtto_date";
            this.txtto_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtto_date.Size = new System.Drawing.Size(102, 21);
            this.txtto_date.TabIndex = 2;
            this.txtto_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtto_date.TextChanged += new System.EventHandler(this.txtcus_name_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(542, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "نوع هزینه";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(134, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "تا تاریخ";
            // 
            // txtfrom_date
            // 
            this.txtfrom_date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtfrom_date.BackColor = System.Drawing.Color.White;
            this.txtfrom_date.ForeColor = System.Drawing.Color.Black;
            this.txtfrom_date.Location = new System.Drawing.Point(177, 20);
            this.txtfrom_date.Mask = "1300/00/00";
            this.txtfrom_date.Name = "txtfrom_date";
            this.txtfrom_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtfrom_date.Size = new System.Drawing.Size(103, 21);
            this.txtfrom_date.TabIndex = 1;
            this.txtfrom_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfrom_date.TextChanged += new System.EventHandler(this.txtcus_name_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(286, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "از تاریخ";
            // 
            // btnfilter
            // 
            this.btnfilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnfilter.BackColor = System.Drawing.Color.White;
            this.btnfilter.Enabled = false;
            this.btnfilter.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnfilter.ForeColor = System.Drawing.Color.Black;
            this.btnfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnfilter.Location = new System.Drawing.Point(26, 53);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(82, 26);
            this.btnfilter.TabIndex = 3;
            this.btnfilter.Text = "جستجو";
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // txttype
            // 
            this.txttype.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txttype.BackColor = System.Drawing.Color.White;
            this.txttype.ForeColor = System.Drawing.Color.Black;
            this.txttype.Location = new System.Drawing.Point(353, 20);
            this.txttype.MaxLength = 50;
            this.txttype.Name = "txttype";
            this.txttype.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttype.Size = new System.Drawing.Size(183, 21);
            this.txttype.TabIndex = 0;
            this.txttype.TextChanged += new System.EventHandler(this.txtcus_name_TextChanged);
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
            this.btnedit.Location = new System.Drawing.Point(519, 465);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(96, 42);
            this.btnedit.TabIndex = 44;
            this.btnedit.Text = "ویرایش";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(388, 478);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 108;
            this.pictureBox1.TabStop = false;
            // 
            // txtsum
            // 
            this.txtsum.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtsum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsum.Location = new System.Drawing.Point(216, 478);
            this.txtsum.Name = "txtsum";
            this.txtsum.ReadOnly = true;
            this.txtsum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtsum.Size = new System.Drawing.Size(78, 21);
            this.txtsum.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(300, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "مجموع هزینه ها";
            // 
            // frmHazinehShow
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(627, 519);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtsum);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmHazinehShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمایش تاریخچه هزینه های شرکت";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmHazinehShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.MaskedTextBox txtto_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.MaskedTextBox txtfrom_date;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.TextBox txttype;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtsum;
        private System.Windows.Forms.Label label1;
    }
}