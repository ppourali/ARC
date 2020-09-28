
namespace Mehr.Presentation_Layers
{
    partial class frmShortHazinehInp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShortHazinehInp));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnMoveLast = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtRecordPosition = new System.Windows.Forms.TextBox();
            this.btnMoveNext = new System.Windows.Forms.Button();
            this.btnMovePrevious = new System.Windows.Forms.Button();
            this.btnMoveFirst = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txthtype = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpinfo_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(388, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 103;
            this.label1.Text = "ردیف";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG)|*.BMP;*.JPG";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Select Image";
            // 
            // btnMoveLast
            // 
            this.btnMoveLast.BackColor = System.Drawing.SystemColors.Control;
            this.btnMoveLast.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMoveLast.Location = new System.Drawing.Point(296, 83);
            this.btnMoveLast.Name = "btnMoveLast";
            this.btnMoveLast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveLast.Size = new System.Drawing.Size(34, 23);
            this.btnMoveLast.TabIndex = 13;
            this.btnMoveLast.Text = ">|";
            this.btnMoveLast.UseVisualStyleBackColor = true;
            this.btnMoveLast.Click += new System.EventHandler(this.btnMoveLast_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(123, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.txtRecordPosition);
            this.groupBox2.Controls.Add(this.btnMoveLast);
            this.groupBox2.Controls.Add(this.btnMoveNext);
            this.groupBox2.Controls.Add(this.btnMovePrevious);
            this.groupBox2.Controls.Add(this.btnMoveFirst);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(43, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(373, 118);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(15, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(72, 36);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "حذف";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtRecordPosition
            // 
            this.txtRecordPosition.BackColor = System.Drawing.Color.White;
            this.txtRecordPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecordPosition.Enabled = false;
            this.txtRecordPosition.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtRecordPosition.ForeColor = System.Drawing.Color.Black;
            this.txtRecordPosition.Location = new System.Drawing.Point(117, 83);
            this.txtRecordPosition.Name = "txtRecordPosition";
            this.txtRecordPosition.ReadOnly = true;
            this.txtRecordPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRecordPosition.Size = new System.Drawing.Size(133, 22);
            this.txtRecordPosition.TabIndex = 22;
            this.txtRecordPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnMoveNext.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMoveNext.Location = new System.Drawing.Point(256, 83);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveNext.Size = new System.Drawing.Size(34, 23);
            this.btnMoveNext.TabIndex = 11;
            this.btnMoveNext.Text = ">";
            this.btnMoveNext.UseVisualStyleBackColor = true;
            this.btnMoveNext.Click += new System.EventHandler(this.btnMoveNext_Click);
            // 
            // btnMovePrevious
            // 
            this.btnMovePrevious.BackColor = System.Drawing.SystemColors.Control;
            this.btnMovePrevious.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMovePrevious.Location = new System.Drawing.Point(77, 83);
            this.btnMovePrevious.Name = "btnMovePrevious";
            this.btnMovePrevious.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMovePrevious.Size = new System.Drawing.Size(34, 23);
            this.btnMovePrevious.TabIndex = 12;
            this.btnMovePrevious.Text = "<";
            this.btnMovePrevious.UseVisualStyleBackColor = true;
            this.btnMovePrevious.Click += new System.EventHandler(this.btnMovePrevious_Click);
            // 
            // btnMoveFirst
            // 
            this.btnMoveFirst.BackColor = System.Drawing.SystemColors.Control;
            this.btnMoveFirst.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMoveFirst.Location = new System.Drawing.Point(37, 83);
            this.btnMoveFirst.Name = "btnMoveFirst";
            this.btnMoveFirst.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveFirst.Size = new System.Drawing.Size(34, 23);
            this.btnMoveFirst.TabIndex = 14;
            this.btnMoveFirst.Text = "| <";
            this.btnMoveFirst.UseVisualStyleBackColor = true;
            this.btnMoveFirst.Click += new System.EventHandler(this.btnMoveFirst_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(106, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUpdate.Size = new System.Drawing.Size(72, 36);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "ویرایش";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(195, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(72, 36);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "اضافه";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(285, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(72, 36);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "جدید";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(285, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(72, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 241);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(474, 22);
            this.statusStrip1.TabIndex = 113;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(388, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 134;
            this.label2.Text = "نوع هزینه";
            // 
            // grpinfo_box
            // 
            this.grpinfo_box.BackColor = System.Drawing.Color.Transparent;
            this.grpinfo_box.Controls.Add(this.label1);
            this.grpinfo_box.Controls.Add(this.txtid);
            this.grpinfo_box.Controls.Add(this.label2);
            this.grpinfo_box.Controls.Add(this.txthtype);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(12, 12);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpinfo_box.Size = new System.Drawing.Size(449, 89);
            this.grpinfo_box.TabIndex = 142;
            this.grpinfo_box.TabStop = false;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Enabled = false;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(308, 28);
            this.txtid.MaxLength = 50;
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(74, 22);
            this.txtid.TabIndex = 0;
            this.txtid.TabStop = false;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.addbtnTextChanged);
            this.txtid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthesab_KeyDown);
            this.txtid.Leave += new System.EventHandler(this.txtmablagh_Leave);
            this.txtid.Enter += new System.EventHandler(this.txtmablagh_Enter);
            // 
            // txthtype
            // 
            this.txthtype.BackColor = System.Drawing.Color.White;
            this.txthtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txthtype.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txthtype.ForeColor = System.Drawing.Color.Black;
            this.txthtype.Location = new System.Drawing.Point(31, 56);
            this.txthtype.MaxLength = 250;
            this.txthtype.Name = "txthtype";
            this.txthtype.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txthtype.Size = new System.Drawing.Size(351, 22);
            this.txthtype.TabIndex = 1;
            this.txthtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txthtype.TextChanged += new System.EventHandler(this.addbtnTextChanged);
            this.txthtype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthesab_KeyDown);
            this.txthtype.Leave += new System.EventHandler(this.txtmablagh_Leave);
            this.txthtype.Enter += new System.EventHandler(this.txtmablagh_Enter);
            // 
            // frmShortHazinehInp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 263);
            this.Controls.Add(this.grpinfo_box);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShortHazinehInp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmShortHazinehInp_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpinfo_box.ResumeLayout(false);
            this.grpinfo_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecordPosition;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnMoveLast;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMoveNext;
        private System.Windows.Forms.Button btnMovePrevious;
        private System.Windows.Forms.Button btnMoveFirst;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txthtype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpinfo_box;
        private System.Windows.Forms.Button btnDelete;
    }
}