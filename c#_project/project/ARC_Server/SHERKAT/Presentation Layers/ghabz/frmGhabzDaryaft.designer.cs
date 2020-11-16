namespace Mehr.Presentation_Layers
{
    partial class frmGhabzDaryaft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGhabzDaryaft));
            this.btnexit = new System.Windows.Forms.Button();
            this.txtid = new Mehr.IDTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btntaeed = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTakhfif = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtroozaneh = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtmandeh = new Mehr.CurrencyTextBox();
            this.txtname = new System.Windows.Forms.ComboBox();
            this.txthesab = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpaid = new Mehr.CurrencyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsharh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtghabzdate = new Mehr.DateMaskedTextbox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtmablagh = new Mehr.CurrencyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtghabz_id = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnsabegheh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnexit
            // 
            this.btnexit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(12, 218);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 42);
            this.btnexit.TabIndex = 30;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // txtid
            // 
            this.txtid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtid.BackColor = System.Drawing.SystemColors.Control;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Enabled = false;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(296, 55);
            this.txtid.MaxLength = 15;
            this.txtid.Name = "txtid";
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(151, 22);
            this.txtid.TabIndex = 0;
            this.txtid.TabStop = false;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            this.txtid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(453, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره پرونده";
            // 
            // btntaeed
            // 
            this.btntaeed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btntaeed.BackColor = System.Drawing.SystemColors.Control;
            this.btntaeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btntaeed.Enabled = false;
            this.btntaeed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btntaeed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btntaeed.Image = ((System.Drawing.Image)(resources.GetObject("btntaeed.Image")));
            this.btntaeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntaeed.Location = new System.Drawing.Point(112, 218);
            this.btntaeed.Name = "btntaeed";
            this.btntaeed.Size = new System.Drawing.Size(96, 42);
            this.btntaeed.TabIndex = 6;
            this.btntaeed.Text = "تایید";
            this.btntaeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntaeed.UseVisualStyleBackColor = true;
            this.btntaeed.Click += new System.EventHandler(this.cmdadd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtTakhfif);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtroozaneh);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtmandeh);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.txthesab);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtstatus);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtpaid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtsharh);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtghabzdate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtmablagh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtghabz_id);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Cursor = System.Windows.Forms.Cursors.Default;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(35, 31);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 98;
            this.label13.Text = "درصد";
            // 
            // txtTakhfif
            // 
            this.txtTakhfif.AcceptsReturn = true;
            this.txtTakhfif.BackColor = System.Drawing.SystemColors.Control;
            this.txtTakhfif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTakhfif.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTakhfif.Enabled = false;
            this.txtTakhfif.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTakhfif.ForeColor = System.Drawing.Color.Black;
            this.txtTakhfif.Location = new System.Drawing.Point(72, 28);
            this.txtTakhfif.MaxLength = 50;
            this.txtTakhfif.Name = "txtTakhfif";
            this.txtTakhfif.ReadOnly = true;
            this.txtTakhfif.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTakhfif.Size = new System.Drawing.Size(124, 21);
            this.txtTakhfif.TabIndex = 96;
            this.txtTakhfif.TabStop = false;
            this.txtTakhfif.Text = "0";
            this.txtTakhfif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(202, 31);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 97;
            this.label11.Text = "میزان تخفیف";
            // 
            // txtroozaneh
            // 
            this.txtroozaneh.AcceptsReturn = true;
            this.txtroozaneh.BackColor = System.Drawing.SystemColors.Control;
            this.txtroozaneh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtroozaneh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtroozaneh.Enabled = false;
            this.txtroozaneh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtroozaneh.ForeColor = System.Drawing.Color.Red;
            this.txtroozaneh.Location = new System.Drawing.Point(296, 140);
            this.txtroozaneh.MaxLength = 50;
            this.txtroozaneh.Name = "txtroozaneh";
            this.txtroozaneh.ReadOnly = true;
            this.txtroozaneh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtroozaneh.Size = new System.Drawing.Size(151, 21);
            this.txtroozaneh.TabIndex = 94;
            this.txtroozaneh.TabStop = false;
            this.txtroozaneh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(453, 143);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 95;
            this.label10.Text = "هزینه روزانه";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "تومان ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(203, 113);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "مانده از قبض";
            // 
            // txtmandeh
            // 
            this.txtmandeh.AcceptsReturn = true;
            this.txtmandeh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmandeh.BackColor = System.Drawing.SystemColors.Control;
            this.txtmandeh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmandeh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmandeh.Enabled = false;
            this.txtmandeh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtmandeh.ForeColor = System.Drawing.Color.Black;
            this.txtmandeh.Location = new System.Drawing.Point(112, 111);
            this.txtmandeh.MaxLength = 10;
            this.txtmandeh.Name = "txtmandeh";
            this.txtmandeh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmandeh.Size = new System.Drawing.Size(84, 21);
            this.txtmandeh.TabIndex = 91;
            this.txtmandeh.TabStop = false;
            this.txtmandeh.Text = "0";
            this.txtmandeh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmandeh.TextChanged += new System.EventHandler(this.txtmandeh_TextChanged);
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtname.BackColor = System.Drawing.Color.White;
            this.txtname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtname.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtname.ForeColor = System.Drawing.Color.Black;
            this.txtname.FormattingEnabled = true;
            this.txtname.Location = new System.Drawing.Point(296, 27);
            this.txtname.Name = "txtname";
            this.txtname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtname.Size = new System.Drawing.Size(151, 21);
            this.txtname.TabIndex = 0;
            this.txtname.SelectedIndexChanged += new System.EventHandler(this.txtname_SelectedIndexChanged);
            this.txtname.Leave += new System.EventHandler(this.Leave_Action);
            this.txtname.Enter += new System.EventHandler(this.Enter_Action);
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtname.TextChanged += new System.EventHandler(this.TextChanged_Action);
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
            this.txthesab.Location = new System.Drawing.Point(296, 82);
            this.txthesab.MaxLength = 50;
            this.txthesab.Name = "txthesab";
            this.txthesab.ReadOnly = true;
            this.txthesab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txthesab.Size = new System.Drawing.Size(151, 21);
            this.txthesab.TabIndex = 87;
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
            this.label19.Location = new System.Drawing.Point(453, 85);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 90;
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
            this.txtstatus.Location = new System.Drawing.Point(296, 110);
            this.txtstatus.MaxLength = 50;
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.ReadOnly = true;
            this.txtstatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtstatus.Size = new System.Drawing.Size(151, 21);
            this.txtstatus.TabIndex = 88;
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
            this.label20.Location = new System.Drawing.Point(448, 113);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 89;
            this.label20.Text = "وضعیت حساب";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(35, 86);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "تومان";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(203, 86);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "مبلغ دریافتی";
            // 
            // txtpaid
            // 
            this.txtpaid.AcceptsReturn = true;
            this.txtpaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpaid.BackColor = System.Drawing.Color.White;
            this.txtpaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpaid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpaid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtpaid.ForeColor = System.Drawing.Color.Black;
            this.txtpaid.Location = new System.Drawing.Point(72, 84);
            this.txtpaid.MaxLength = 10;
            this.txtpaid.Name = "txtpaid";
            this.txtpaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtpaid.Size = new System.Drawing.Size(124, 21);
            this.txtpaid.TabIndex = 3;
            this.txtpaid.Text = "0";
            this.txtpaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtpaid.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtpaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtpaid.Leave += new System.EventHandler(this.Leave_Action);
            this.txtpaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtpaid.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(35, 57);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "تومان";
            // 
            // txtsharh
            // 
            this.txtsharh.AcceptsReturn = true;
            this.txtsharh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsharh.BackColor = System.Drawing.Color.White;
            this.txtsharh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsharh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsharh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtsharh.ForeColor = System.Drawing.Color.Black;
            this.txtsharh.Location = new System.Drawing.Point(45, 168);
            this.txtsharh.MaxLength = 100;
            this.txtsharh.Name = "txtsharh";
            this.txtsharh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtsharh.Size = new System.Drawing.Size(151, 21);
            this.txtsharh.TabIndex = 5;
            this.txtsharh.Text = "هزینه درمان";
            this.txtsharh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsharh.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtsharh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtsharh.Leave += new System.EventHandler(this.Leave_Action);
            this.txtsharh.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(202, 170);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "از بابت";
            // 
            // txtghabzdate
            // 
            this.txtghabzdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtghabzdate.BackColor = System.Drawing.Color.White;
            this.txtghabzdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghabzdate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtghabzdate.ForeColor = System.Drawing.Color.Black;
            this.txtghabzdate.Location = new System.Drawing.Point(45, 139);
            this.txtghabzdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtghabzdate.Name = "txtghabzdate";
            this.txtghabzdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtghabzdate.Size = new System.Drawing.Size(151, 22);
            this.txtghabzdate.TabIndex = 4;
            this.txtghabzdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtghabzdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtghabzdate.Leave += new System.EventHandler(this.Leave_Action);
            this.txtghabzdate.Enter += new System.EventHandler(this.Enter_Action);
            this.txtghabzdate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(203, 57);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "هزینه ی درمان";
            // 
            // txtmablagh
            // 
            this.txtmablagh.AcceptsReturn = true;
            this.txtmablagh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmablagh.BackColor = System.Drawing.Color.White;
            this.txtmablagh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmablagh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmablagh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtmablagh.ForeColor = System.Drawing.Color.Black;
            this.txtmablagh.Location = new System.Drawing.Point(72, 55);
            this.txtmablagh.MaxLength = 10;
            this.txtmablagh.Name = "txtmablagh";
            this.txtmablagh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtmablagh.Size = new System.Drawing.Size(124, 21);
            this.txtmablagh.TabIndex = 2;
            this.txtmablagh.Text = "0";
            this.txtmablagh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmablagh.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtmablagh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtmablagh.Leave += new System.EventHandler(this.Leave_Action);
            this.txtmablagh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtmablagh.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(454, 170);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "شماره قبض";
            // 
            // txtghabz_id
            // 
            this.txtghabz_id.AcceptsReturn = true;
            this.txtghabz_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtghabz_id.BackColor = System.Drawing.Color.White;
            this.txtghabz_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghabz_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtghabz_id.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtghabz_id.ForeColor = System.Drawing.Color.Black;
            this.txtghabz_id.Location = new System.Drawing.Point(296, 168);
            this.txtghabz_id.MaxLength = 10;
            this.txtghabz_id.Name = "txtghabz_id";
            this.txtghabz_id.ReadOnly = true;
            this.txtghabz_id.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtghabz_id.Size = new System.Drawing.Size(151, 21);
            this.txtghabz_id.TabIndex = 1;
            this.txtghabz_id.TabStop = false;
            this.txtghabz_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtghabz_id.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtghabz_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtghabz_id.Leave += new System.EventHandler(this.Leave_Action);
            this.txtghabz_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtghabz_id.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Cursor = System.Windows.Forms.Cursors.Default;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(449, 30);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 66;
            this.label22.Text = "نام بیمار";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(203, 142);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 72;
            this.label12.Text = "تاریخ صدور";
            // 
            // btnsabegheh
            // 
            this.btnsabegheh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsabegheh.BackColor = System.Drawing.SystemColors.Control;
            this.btnsabegheh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnsabegheh.Enabled = false;
            this.btnsabegheh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnsabegheh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnsabegheh.Image = ((System.Drawing.Image)(resources.GetObject("btnsabegheh.Image")));
            this.btnsabegheh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsabegheh.Location = new System.Drawing.Point(331, 218);
            this.btnsabegheh.Name = "btnsabegheh";
            this.btnsabegheh.Size = new System.Drawing.Size(128, 42);
            this.btnsabegheh.TabIndex = 45;
            this.btnsabegheh.Text = "سابقه مالی بیمار";
            this.btnsabegheh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsabegheh.UseVisualStyleBackColor = true;
            this.btnsabegheh.Click += new System.EventHandler(this.btnsabegheh_Click);
            // 
            // frmGhabzDaryaft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(574, 265);
            this.Controls.Add(this.btnsabegheh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btntaeed);
            this.Controls.Add(this.btnexit);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGhabzDaryaft";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "صدور قبض - واقعی";
            this.Load += new System.EventHandler(this.frmGhabzDaryaft_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private IDTextBox txtid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntaeed;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtghabz_id;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label9;
        public CurrencyTextBox txtmablagh;
        private DateMaskedTextbox txtghabzdate;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtsharh;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public CurrencyTextBox txtpaid;
        public System.Windows.Forms.TextBox txthesab;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox txtstatus;
        public System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnsabegheh;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label7;
        public Mehr.CurrencyTextBox txtmandeh;
        public System.Windows.Forms.ComboBox txtname;
        public System.Windows.Forms.TextBox txtroozaneh;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtTakhfif;
        public System.Windows.Forms.Label label11;
    }
}