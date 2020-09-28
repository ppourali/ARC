namespace Mehr.Presentation_Layers
{
    partial class frmHazinehPeygiri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHazinehPeygiri));
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtdate = new DateMaskedTextbox();
            this.btnexit = new System.Windows.Forms.Button();
            this.grdvisit = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboop4 = new System.Windows.Forms.TextBox();
            this.txtboop2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsoob8 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsoob2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtmet5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtboop8 = new System.Windows.Forms.TextBox();
            this.btnRiz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdvisit)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1091, 33);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "تاریخ امروز :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 54);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "نمایش";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtdate
            // 
            this.txtdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdate.BackColor = System.Drawing.Color.White;
            this.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdate.ForeColor = System.Drawing.Color.Black;
            this.txtdate.Location = new System.Drawing.Point(955, 31);
            this.txtdate.Mask = "1300/00/00";
            this.txtdate.Name = "txtdate";
            this.txtdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdate.Size = new System.Drawing.Size(130, 21);
            this.txtdate.TabIndex = 1;
            this.txtdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdate.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdate.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdate.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnexit
            // 
            this.btnexit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(12, 484);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 42);
            this.btnexit.TabIndex = 117;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // grdvisit
            // 
            this.grdvisit.AllowUserToAddRows = false;
            this.grdvisit.AllowUserToDeleteRows = false;
            this.grdvisit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdvisit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdvisit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvisit.Location = new System.Drawing.Point(12, 72);
            this.grdvisit.MultiSelect = false;
            this.grdvisit.Name = "grdvisit";
            this.grdvisit.ReadOnly = true;
            this.grdvisit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdvisit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdvisit.Size = new System.Drawing.Size(1140, 406);
            this.grdvisit.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(584, 35);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "هزینه بوپرنورفین 0.4";
            // 
            // txtboop4
            // 
            this.txtboop4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboop4.Location = new System.Drawing.Point(478, 32);
            this.txtboop4.Name = "txtboop4";
            this.txtboop4.Size = new System.Drawing.Size(100, 21);
            this.txtboop4.TabIndex = 1;
            this.txtboop4.Text = "500";
            this.txtboop4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtboop4.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtboop4.Leave += new System.EventHandler(this.Leave_Action);
            this.txtboop4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtboop4.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // txtboop2
            // 
            this.txtboop2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboop2.Location = new System.Drawing.Point(265, 32);
            this.txtboop2.Name = "txtboop2";
            this.txtboop2.Size = new System.Drawing.Size(100, 21);
            this.txtboop2.TabIndex = 2;
            this.txtboop2.Text = "1500";
            this.txtboop2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtboop2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtboop2.Leave += new System.EventHandler(this.Leave_Action);
            this.txtboop2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtboop2.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(371, 35);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "هزینه بوپرنورفین 2";
            // 
            // txtsoob8
            // 
            this.txtsoob8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsoob8.Location = new System.Drawing.Point(35, 4);
            this.txtsoob8.Name = "txtsoob8";
            this.txtsoob8.Size = new System.Drawing.Size(100, 21);
            this.txtsoob8.TabIndex = 5;
            this.txtsoob8.Text = "6000";
            this.txtsoob8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsoob8.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtsoob8.Leave += new System.EventHandler(this.Leave_Action);
            this.txtsoob8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtsoob8.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(141, 7);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 125;
            this.label3.Text = "هزینه سوباکسون 8";
            // 
            // txtsoob2
            // 
            this.txtsoob2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsoob2.Location = new System.Drawing.Point(265, 4);
            this.txtsoob2.Name = "txtsoob2";
            this.txtsoob2.Size = new System.Drawing.Size(100, 21);
            this.txtsoob2.TabIndex = 4;
            this.txtsoob2.Text = "2100";
            this.txtsoob2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsoob2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtsoob2.Leave += new System.EventHandler(this.Leave_Action);
            this.txtsoob2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtsoob2.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(371, 7);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 123;
            this.label5.Text = "هزینه سوباکسون 2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtmet5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtboop8);
            this.panel1.Controls.Add(this.txtboop4);
            this.panel1.Controls.Add(this.txtsoob8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtboop2);
            this.panel1.Controls.Add(this.txtsoob2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(209, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 60);
            this.panel1.TabIndex = 127;
            this.panel1.TabStop = true;
            // 
            // txtmet5
            // 
            this.txtmet5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmet5.Location = new System.Drawing.Point(478, 3);
            this.txtmet5.Name = "txtmet5";
            this.txtmet5.Size = new System.Drawing.Size(100, 21);
            this.txtmet5.TabIndex = 128;
            this.txtmet5.Text = "300";
            this.txtmet5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(584, 6);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 129;
            this.label7.Text = "هزینه متادون 5";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(141, 35);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "هزینه بوپرنورفین 8";
            // 
            // txtboop8
            // 
            this.txtboop8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboop8.Location = new System.Drawing.Point(35, 32);
            this.txtboop8.Name = "txtboop8";
            this.txtboop8.Size = new System.Drawing.Size(100, 21);
            this.txtboop8.TabIndex = 3;
            this.txtboop8.Text = "5000";
            this.txtboop8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtboop8.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtboop8.Leave += new System.EventHandler(this.Leave_Action);
            this.txtboop8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtboop8.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // btnRiz
            // 
            this.btnRiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRiz.BackColor = System.Drawing.Color.White;
            this.btnRiz.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRiz.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRiz.Image = ((System.Drawing.Image)(resources.GetObject("btnRiz.Image")));
            this.btnRiz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRiz.Location = new System.Drawing.Point(969, 484);
            this.btnRiz.Name = "btnRiz";
            this.btnRiz.Size = new System.Drawing.Size(180, 42);
            this.btnRiz.TabIndex = 128;
            this.btnRiz.Text = "نمایش ریز هزینه های بیمار";
            this.btnRiz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRiz.UseVisualStyleBackColor = true;
            this.btnRiz.Click += new System.EventHandler(this.btnRiz_Click);
            // 
            // frmHazinehPeygiri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(1164, 538);
            this.Controls.Add(this.btnRiz);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdvisit);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "frmHazinehPeygiri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پیگیری متوسط هزینه بیماران";
            this.Load += new System.EventHandler(this.printviewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdvisit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefresh;
        public DateMaskedTextbox txtdate;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdvisit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboop4;
        private System.Windows.Forms.TextBox txtboop2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsoob8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsoob2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtboop8;
        private System.Windows.Forms.TextBox txtmet5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRiz;


        // private InvestmentDataSet InvestmentDataSet;
        //private Investment.InvestmentDataSetTableAdapters.PaymentsTableAdapter paymentsTableAdapter;




    }
}