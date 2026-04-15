namespace Mehr.Presentation_Layers
{
    partial class FrmSelectBoop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectBoop));
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.txtmonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtyear = new System.Windows.Forms.NumericUpDown();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chboxDaily = new System.Windows.Forms.CheckBox();
            this.grpinfo_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtyear)).BeginInit();
            this.SuspendLayout();
            // 
            // grpinfo_box
            // 
            this.grpinfo_box.Controls.Add(this.chboxDaily);
            this.grpinfo_box.Controls.Add(this.txtmonth);
            this.grpinfo_box.Controls.Add(this.label4);
            this.grpinfo_box.Controls.Add(this.label2);
            this.grpinfo_box.Controls.Add(this.txtyear);
            this.grpinfo_box.Controls.Add(this.btnPrint);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(12, 10);
            this.grpinfo_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpinfo_box.Size = new System.Drawing.Size(284, 111);
            this.grpinfo_box.TabIndex = 11;
            this.grpinfo_box.TabStop = false;
            // 
            // txtmonth
            // 
            this.txtmonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtmonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtmonth.BackColor = System.Drawing.Color.White;
            this.txtmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtmonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtmonth.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtmonth.ForeColor = System.Drawing.Color.Black;
            this.txtmonth.FormattingEnabled = true;
            this.txtmonth.Items.AddRange(new object[] {
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی",
            "بهمن",
            "اسفند"});
            this.txtmonth.Location = new System.Drawing.Point(123, 36);
            this.txtmonth.Name = "txtmonth";
            this.txtmonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmonth.Size = new System.Drawing.Size(86, 21);
            this.txtmonth.TabIndex = 1;
            this.txtmonth.Leave += new System.EventHandler(this.Leave_Action);
            this.txtmonth.Enter += new System.EventHandler(this.Enter_Action);
            this.txtmonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtmonth.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(215, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "سال";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(215, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "ماه";
            // 
            // txtyear
            // 
            this.txtyear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtyear.Location = new System.Drawing.Point(123, 63);
            this.txtyear.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.txtyear.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.txtyear.Name = "txtyear";
            this.txtyear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtyear.Size = new System.Drawing.Size(86, 22);
            this.txtyear.TabIndex = 1;
            this.txtyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtyear.Value = new decimal(new int[] {
            1389,
            0,
            0,
            0});
            this.txtyear.ValueChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtyear.Leave += new System.EventHandler(this.Leave_Action);
            this.txtyear.Enter += new System.EventHandler(this.Enter_Action);
            this.txtyear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(6, 43);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(96, 42);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPrint_KeyDown);
            // 
            // chboxDaily
            // 
            this.chboxDaily.AutoSize = true;
            this.chboxDaily.Checked = true;
            this.chboxDaily.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxDaily.Location = new System.Drawing.Point(13, 22);
            this.chboxDaily.Name = "chboxDaily";
            this.chboxDaily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxDaily.Size = new System.Drawing.Size(89, 18);
            this.chboxDaily.TabIndex = 52;
            this.chboxDaily.Text = "نمایش روزانه";
            this.chboxDaily.UseVisualStyleBackColor = true;
            // 
            // frmSelectBoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(306, 134);
            this.Controls.Add(this.grpinfo_box);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectBoop";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmSelectBoop_Load);
            this.grpinfo_box.ResumeLayout(false);
            this.grpinfo_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtyear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpinfo_box;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown txtyear;
        public System.Windows.Forms.ComboBox txtmonth;
        private System.Windows.Forms.CheckBox chboxDaily;

    }
}