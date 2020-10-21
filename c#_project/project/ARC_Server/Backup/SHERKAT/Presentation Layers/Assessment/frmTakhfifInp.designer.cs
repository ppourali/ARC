namespace Mehr.Presentation_Layers
{
    partial class frmTakhfifInp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTakhfifInp));
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.start_range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.takhfif_percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpinfo_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(123, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // grpinfo_box
            // 
            this.grpinfo_box.BackColor = System.Drawing.Color.Transparent;
            this.grpinfo_box.Controls.Add(this.dataGridView1);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(14, 15);
            this.grpinfo_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Size = new System.Drawing.Size(354, 174);
            this.grpinfo_box.TabIndex = 0;
            this.grpinfo_box.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.start_range,
            this.end_range,
            this.takhfif_percent});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(348, 151);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // start_range
            // 
            this.start_range.DataPropertyName = "start_range";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0 درصد";
            this.start_range.DefaultCellStyle = dataGridViewCellStyle2;
            this.start_range.HeaderText = "امتیاز از";
            this.start_range.MaxInputLength = 3;
            this.start_range.Name = "start_range";
            // 
            // end_range
            // 
            this.end_range.DataPropertyName = "end_range";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.end_range.DefaultCellStyle = dataGridViewCellStyle3;
            this.end_range.HeaderText = "امتیاز تا";
            this.end_range.MaxInputLength = 3;
            this.end_range.Name = "end_range";
            // 
            // takhfif_percent
            // 
            this.takhfif_percent.DataPropertyName = "takhfif_percent";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.takhfif_percent.DefaultCellStyle = dataGridViewCellStyle4;
            this.takhfif_percent.HeaderText = "مقدار تخفیف";
            this.takhfif_percent.MaxInputLength = 3;
            this.takhfif_percent.Name = "takhfif_percent";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnexit);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(66, 197);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(236, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnexit
            // 
            this.btnexit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnexit.BackColor = System.Drawing.SystemColors.Control;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(13, 21);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(101, 43);
            this.btnexit.TabIndex = 1;
            this.btnexit.TabStop = false;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(120, 21);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(101, 43);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // frmTakhfifInp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(377, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpinfo_box);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmTakhfifInp";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعیین میزان تخفیف بر اساس ارزیابی";
            this.Load += new System.EventHandler(this.frmTakhfifInp_Load);
            this.grpinfo_box.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox grpinfo_box;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_range;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_range;
        private System.Windows.Forms.DataGridViewTextBoxColumn takhfif_percent;
    }
}