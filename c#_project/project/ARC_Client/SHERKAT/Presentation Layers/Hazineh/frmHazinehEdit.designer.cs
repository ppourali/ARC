namespace Mehr.Presentation_Layers
{
    partial class frmHazinehEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHazinehEdit));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txttype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdate = new Mehr.DateMaskedTextbox();
            this.txtmablagh = new Mehr.CurrencyTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcomments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtradif = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpinfo_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(53, 14);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUpdate.Size = new System.Drawing.Size(114, 49);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "ذخیره";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnUpdate_KeyDown);
            // 
            // grpinfo_box
            // 
            this.grpinfo_box.BackColor = System.Drawing.Color.Transparent;
            this.grpinfo_box.Controls.Add(this.button1);
            this.grpinfo_box.Controls.Add(this.txttype);
            this.grpinfo_box.Controls.Add(this.label4);
            this.grpinfo_box.Controls.Add(this.label1);
            this.grpinfo_box.Controls.Add(this.txtdate);
            this.grpinfo_box.Controls.Add(this.txtmablagh);
            this.grpinfo_box.Controls.Add(this.label9);
            this.grpinfo_box.Controls.Add(this.label2);
            this.grpinfo_box.Controls.Add(this.txtcomments);
            this.grpinfo_box.Controls.Add(this.label3);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(8, 69);
            this.grpinfo_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Size = new System.Drawing.Size(492, 122);
            this.grpinfo_box.TabIndex = 0;
            this.grpinfo_box.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 108;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txttype
            // 
            this.txttype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txttype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txttype.BackColor = System.Drawing.Color.White;
            this.txttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txttype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txttype.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txttype.ForeColor = System.Drawing.Color.Black;
            this.txttype.FormattingEnabled = true;
            this.txttype.Location = new System.Drawing.Point(45, 54);
            this.txttype.MaxLength = 250;
            this.txttype.Name = "txttype";
            this.txttype.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttype.Size = new System.Drawing.Size(368, 22);
            this.txttype.Sorted = true;
            this.txttype.TabIndex = 2;
            this.txttype.SelectedIndexChanged += new System.EventHandler(this.TextChanged_Action);
            this.txttype.Leave += new System.EventHandler(this.Leave_Action);
            this.txttype.Enter += new System.EventHandler(this.Enter_Action);
            this.txttype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txttype.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(419, 58);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 107;
            this.label4.Text = "نوع هزینه";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "تومان";
            // 
            // txtdate
            // 
            this.txtdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdate.BackColor = System.Drawing.Color.White;
            this.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtdate.ForeColor = System.Drawing.Color.Black;
            this.txtdate.Location = new System.Drawing.Point(261, 27);
            
            this.txtdate.Name = "txtdate";
            this.txtdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdate.Size = new System.Drawing.Size(149, 22);
            this.txtdate.TabIndex = 0;
            this.txtdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdate.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdate.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtmablagh
            // 
            this.txtmablagh.BackColor = System.Drawing.Color.White;
            this.txtmablagh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmablagh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtmablagh.ForeColor = System.Drawing.Color.Black;
            this.txtmablagh.Location = new System.Drawing.Point(45, 26);
            this.txtmablagh.MaxLength = 8;
            this.txtmablagh.Name = "txtmablagh";
            this.txtmablagh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmablagh.Size = new System.Drawing.Size(153, 22);
            this.txtmablagh.TabIndex = 1;
            this.txtmablagh.Text = "0";
            this.txtmablagh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmablagh.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtmablagh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtmablagh.Leave += new System.EventHandler(this.Leave_Action);
            this.txtmablagh.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(204, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 14);
            this.label9.TabIndex = 105;
            this.label9.Text = "مبلغ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(416, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 101;
            this.label2.Text = "تاریخ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcomments
            // 
            this.txtcomments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtcomments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtcomments.BackColor = System.Drawing.Color.White;
            this.txtcomments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcomments.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtcomments.ForeColor = System.Drawing.Color.Black;
            this.txtcomments.Location = new System.Drawing.Point(9, 82);
            this.txtcomments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcomments.Name = "txtcomments";
            this.txtcomments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtcomments.Size = new System.Drawing.Size(404, 22);
            this.txtcomments.TabIndex = 3;
            this.txtcomments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtcomments.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtcomments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtcomments.Leave += new System.EventHandler(this.Leave_Action);
            this.txtcomments.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(419, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 99;
            this.label3.Text = "شرح هزینه";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtradif
            // 
            this.txtradif.BackColor = System.Drawing.Color.White;
            this.txtradif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtradif.Enabled = false;
            this.txtradif.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtradif.ForeColor = System.Drawing.Color.Black;
            this.txtradif.Location = new System.Drawing.Point(269, 28);
            this.txtradif.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtradif.MaxLength = 15;
            this.txtradif.Name = "txtradif";
            this.txtradif.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtradif.Size = new System.Drawing.Size(149, 22);
            this.txtradif.TabIndex = 0;
            this.txtradif.TabStop = false;
            this.txtradif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtradif.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtradif.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtradif.Leave += new System.EventHandler(this.Leave_Action);
            this.txtradif.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(424, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = "مشخصه";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmHazinehEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(511, 212);
            this.Controls.Add(this.grpinfo_box);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtradif);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHazinehEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش هزینه";
            this.Load += new System.EventHandler(this.frmHazinehEdit_Load);
            this.grpinfo_box.ResumeLayout(false);
            this.grpinfo_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox grpinfo_box;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtradif;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox txttype;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DateMaskedTextbox txtdate;
        private CurrencyTextBox txtmablagh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcomments;
        private System.Windows.Forms.Label label3;

    }
}