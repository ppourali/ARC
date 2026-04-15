namespace Mehr.Presentation_Layers
{
    partial class FrmSickMandehEditDaftari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSickMandehEditDaftari));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txthesab = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtmandeh = new Mehr.CurrencyTextBox();
            this.txttashkhis = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtid = new Mehr.IDTextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.btnUpdate.Location = new System.Drawing.Point(12, 21);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUpdate.Size = new System.Drawing.Size(114, 49);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "ذخیره";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grpinfo_box
            // 
            this.grpinfo_box.BackColor = System.Drawing.Color.Transparent;
            this.grpinfo_box.Controls.Add(this.label2);
            this.grpinfo_box.Controls.Add(this.label1);
            this.grpinfo_box.Controls.Add(this.txthesab);
            this.grpinfo_box.Controls.Add(this.label19);
            this.grpinfo_box.Controls.Add(this.txtstatus);
            this.grpinfo_box.Controls.Add(this.label20);
            this.grpinfo_box.Controls.Add(this.txtmandeh);
            this.grpinfo_box.Controls.Add(this.txttashkhis);
            this.grpinfo_box.Controls.Add(this.label15);
            this.grpinfo_box.Controls.Add(this.label16);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(8, 78);
            this.grpinfo_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Size = new System.Drawing.Size(478, 91);
            this.grpinfo_box.TabIndex = 11;
            this.grpinfo_box.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 24);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "تومان";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(274, 25);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "تومان";
            // 
            // txthesab
            // 
            this.txthesab.AcceptsReturn = true;
            this.txthesab.BackColor = System.Drawing.SystemColors.Control;
            this.txthesab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txthesab.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txthesab.Enabled = false;
            this.txthesab.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txthesab.ForeColor = System.Drawing.Color.Black;
            this.txthesab.Location = new System.Drawing.Point(311, 22);
            this.txthesab.MaxLength = 50;
            this.txthesab.Name = "txthesab";
            this.txthesab.ReadOnly = true;
            this.txthesab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txthesab.Size = new System.Drawing.Size(79, 21);
            this.txthesab.TabIndex = 93;
            this.txthesab.TabStop = false;
            this.txthesab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Cursor = System.Windows.Forms.Cursors.Default;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(396, 25);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 96;
            this.label19.Text = "مبلغ حساب";
            // 
            // txtstatus
            // 
            this.txtstatus.AcceptsReturn = true;
            this.txtstatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtstatus.Enabled = false;
            this.txtstatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtstatus.ForeColor = System.Drawing.Color.Black;
            this.txtstatus.Location = new System.Drawing.Point(277, 49);
            this.txtstatus.MaxLength = 50;
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.ReadOnly = true;
            this.txtstatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtstatus.Size = new System.Drawing.Size(113, 21);
            this.txtstatus.TabIndex = 94;
            this.txtstatus.TabStop = false;
            this.txtstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Cursor = System.Windows.Forms.Cursors.Default;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(391, 52);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 95;
            this.label20.Text = "وضعیت حساب";
            // 
            // txtmandeh
            // 
            this.txtmandeh.BackColor = System.Drawing.Color.White;
            this.txtmandeh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmandeh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtmandeh.ForeColor = System.Drawing.Color.Black;
            this.txtmandeh.Location = new System.Drawing.Point(51, 21);
            this.txtmandeh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmandeh.MaxLength = 20;
            this.txtmandeh.Name = "txtmandeh";
            this.txtmandeh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmandeh.Size = new System.Drawing.Size(79, 22);
            this.txtmandeh.TabIndex = 0;
            this.txtmandeh.Text = "0";
            this.txtmandeh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmandeh.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtmandeh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtmandeh.Leave += new System.EventHandler(this.Leave_Action);
            this.txtmandeh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtmandeh.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // txttashkhis
            // 
            this.txttashkhis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txttashkhis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txttashkhis.BackColor = System.Drawing.Color.White;
            this.txttashkhis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txttashkhis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txttashkhis.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txttashkhis.FormattingEnabled = true;
            this.txttashkhis.Items.AddRange(new object[] {
            "بدهکار",
            "بستانکار"});
            this.txttashkhis.Location = new System.Drawing.Point(17, 48);
            this.txttashkhis.Name = "txttashkhis";
            this.txttashkhis.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttashkhis.Size = new System.Drawing.Size(113, 21);
            this.txttashkhis.TabIndex = 1;
            this.txttashkhis.Leave += new System.EventHandler(this.Leave_Action);
            this.txttashkhis.Enter += new System.EventHandler(this.Enter_Action);
            this.txttashkhis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txttashkhis.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(136, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 92;
            this.label15.Text = "به مبلغ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(136, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 14);
            this.label16.TabIndex = 91;
            this.label16.Text = "وضعیت مانده حساب";
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(285, 48);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtid.MaxLength = 15;
            this.txtid.Name = "txtid";
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(113, 22);
            this.txtid.TabIndex = 0;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(404, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "شماره پرونده";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSickMandehEditDaftari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(498, 192);
            this.Controls.Add(this.grpinfo_box);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSickMandehEditDaftari";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش مانده حساب بیمار";
            this.Load += new System.EventHandler(this.frmSickMandehEditDaftari_Load);
            this.grpinfo_box.ResumeLayout(false);
            this.grpinfo_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        public IDTextBox txtid;
        private System.Windows.Forms.GroupBox grpinfo_box;
        private CurrencyTextBox txtmandeh;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox txttashkhis;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txthesab;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox txtstatus;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;

    }
}