namespace Mehr.Presentation_Layers
{
    partial class FrmTajvizAnbarEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTajvizAnbarEdit));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtfee = new Mehr.CurrencyTextBox();
            this.txtdaru_name = new System.Windows.Forms.ComboBox();
            this.txtmandeh = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtvahed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnUpdate.Location = new System.Drawing.Point(21, 19);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUpdate.Size = new System.Drawing.Size(114, 63);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "ذخیره";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grpinfo_box
            // 
            this.grpinfo_box.BackColor = System.Drawing.Color.Transparent;
            this.grpinfo_box.Controls.Add(this.label2);
            this.grpinfo_box.Controls.Add(this.label9);
            this.grpinfo_box.Controls.Add(this.txtfee);
            this.grpinfo_box.Controls.Add(this.txtdaru_name);
            this.grpinfo_box.Controls.Add(this.txtmandeh);
            this.grpinfo_box.Controls.Add(this.btnUpdate);
            this.grpinfo_box.Controls.Add(this.label10);
            this.grpinfo_box.Controls.Add(this.label3);
            this.grpinfo_box.Controls.Add(this.txtvahed);
            this.grpinfo_box.Controls.Add(this.label1);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(12, 13);
            this.grpinfo_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Size = new System.Drawing.Size(450, 146);
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
            this.label2.Location = new System.Drawing.Point(216, 64);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "تومان";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(369, 64);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 88;
            this.label9.Text = "قیمت";
            // 
            // txtfee
            // 
            this.txtfee.AcceptsReturn = true;
            this.txtfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtfee.BackColor = System.Drawing.Color.White;
            this.txtfee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtfee.ForeColor = System.Drawing.Color.Black;
            this.txtfee.Location = new System.Drawing.Point(253, 61);
            this.txtfee.MaxLength = 10;
            this.txtfee.Name = "txtfee";
            this.txtfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfee.Size = new System.Drawing.Size(110, 21);
            this.txtfee.TabIndex = 1;
            this.txtfee.Text = "0";
            this.txtfee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfee.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtfee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            // 
            // txtdaru_name
            // 
            this.txtdaru_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdaru_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtdaru_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtdaru_name.BackColor = System.Drawing.Color.White;
            this.txtdaru_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtdaru_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtdaru_name.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtdaru_name.ForeColor = System.Drawing.Color.Black;
            this.txtdaru_name.FormattingEnabled = true;
            this.txtdaru_name.Items.AddRange(new object[] {
            "شربت متادون",
            "قرص متادون 5",
            "قرص متادون 20",
            "قرص متادون 40",
            "قرص بوپرنورفین 0.4",
            "قرص بوپرنورفین 2",
            "قرص بوپرنورفین 8",
            "قرص سوباکسون 2",
            "قرص سوباکسون 8"});
            this.txtdaru_name.Location = new System.Drawing.Point(214, 34);
            this.txtdaru_name.Name = "txtdaru_name";
            this.txtdaru_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdaru_name.Size = new System.Drawing.Size(149, 21);
            this.txtdaru_name.TabIndex = 0;
            this.txtdaru_name.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdaru_name.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdaru_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdaru_name.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtmandeh
            // 
            this.txtmandeh.BackColor = System.Drawing.Color.White;
            this.txtmandeh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmandeh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtmandeh.ForeColor = System.Drawing.Color.Black;
            this.txtmandeh.Location = new System.Drawing.Point(214, 90);
            this.txtmandeh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmandeh.MaxLength = 10;
            this.txtmandeh.Name = "txtmandeh";
            this.txtmandeh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmandeh.Size = new System.Drawing.Size(149, 22);
            this.txtmandeh.TabIndex = 2;
            this.txtmandeh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmandeh.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtmandeh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtmandeh.Leave += new System.EventHandler(this.Leave_Action);
            this.txtmandeh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtmandeh.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(371, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "مانده اولیه";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(369, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "نام دارو";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtvahed
            // 
            this.txtvahed.AutoCompleteCustomSource.AddRange(new string[] {
            "میلی گرم",
            "گرم",
            "عدد",
            "سی سی",
            "قرص"});
            this.txtvahed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtvahed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtvahed.BackColor = System.Drawing.Color.White;
            this.txtvahed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtvahed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtvahed.ForeColor = System.Drawing.Color.Black;
            this.txtvahed.Location = new System.Drawing.Point(6, 90);
            this.txtvahed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtvahed.MaxLength = 15;
            this.txtvahed.Name = "txtvahed";
            this.txtvahed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtvahed.Size = new System.Drawing.Size(149, 22);
            this.txtvahed.TabIndex = 3;
            this.txtvahed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtvahed.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtvahed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtvahed.Leave += new System.EventHandler(this.Leave_Action);
            this.txtvahed.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(161, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "واحد";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTajAnbarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(474, 172);
            this.Controls.Add(this.grpinfo_box);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTajAnbarEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش اطلاعات داروهای گاوصندوق";
            this.Load += new System.EventHandler(this.frmTajAnbarEdit_Load);
            this.grpinfo_box.ResumeLayout(false);
            this.grpinfo_box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpinfo_box;
        public System.Windows.Forms.TextBox txtmandeh;
        public System.Windows.Forms.TextBox txtvahed;
        public System.Windows.Forms.ComboBox txtdaru_name;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label9;
        public CurrencyTextBox txtfee;

    }
}