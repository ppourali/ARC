namespace Daru.Presentation_Layers
{
    partial class frmDaruEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDaruEdit));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.idsearch = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txttedad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdaru_name = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtdaru_date = new System.Windows.Forms.MaskedTextBox();
            this.txtdaryaft_az = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txttahvil_be = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtfee_kol = new Daru.CurrencyTextBox();
            this.txtfee = new Daru.CurrencyTextBox();
            this.lblvahed = new System.Windows.Forms.Label();
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
            this.btnUpdate.Location = new System.Drawing.Point(28, 21);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUpdate.Size = new System.Drawing.Size(114, 49);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "ذخیره";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // idsearch
            // 
            this.idsearch.BackColor = System.Drawing.Color.Transparent;
            this.idsearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("idsearch.BackgroundImage")));
            this.idsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.idsearch.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.idsearch.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.idsearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.idsearch.ForeColor = System.Drawing.Color.Black;
            this.idsearch.Location = new System.Drawing.Point(338, 23);
            this.idsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idsearch.Name = "idsearch";
            this.idsearch.Size = new System.Drawing.Size(37, 35);
            this.idsearch.TabIndex = 1;
            this.idsearch.UseVisualStyleBackColor = true;
            this.idsearch.Click += new System.EventHandler(this.idsearch_Click);
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(381, 36);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtid.MaxLength = 4;
            this.txtid.Name = "txtid";
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(102, 22);
            this.txtid.TabIndex = 0;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownforSearch);
            this.txtid.Leave += new System.EventHandler(this.Leave_Action);
            this.txtid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtid.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(489, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "شماره";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpinfo_box
            // 
            this.grpinfo_box.BackColor = System.Drawing.Color.Transparent;
            this.grpinfo_box.Controls.Add(this.lblvahed);
            this.grpinfo_box.Controls.Add(this.label7);
            this.grpinfo_box.Controls.Add(this.txtfee_kol);
            this.grpinfo_box.Controls.Add(this.label8);
            this.grpinfo_box.Controls.Add(this.txttedad);
            this.grpinfo_box.Controls.Add(this.label6);
            this.grpinfo_box.Controls.Add(this.txtdaru_name);
            this.grpinfo_box.Controls.Add(this.label17);
            this.grpinfo_box.Controls.Add(this.txtfee);
            this.grpinfo_box.Controls.Add(this.label15);
            this.grpinfo_box.Controls.Add(this.txtdaru_date);
            this.grpinfo_box.Controls.Add(this.txtdaryaft_az);
            this.grpinfo_box.Controls.Add(this.label5);
            this.grpinfo_box.Controls.Add(this.label4);
            this.grpinfo_box.Controls.Add(this.label2);
            this.grpinfo_box.Controls.Add(this.txttahvil_be);
            this.grpinfo_box.Controls.Add(this.label9);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(12, 78);
            this.grpinfo_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Size = new System.Drawing.Size(519, 158);
            this.grpinfo_box.TabIndex = 0;
            this.grpinfo_box.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(23, 95);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 116;
            this.label7.Text = "تومان";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(185, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 14);
            this.label8.TabIndex = 115;
            this.label8.Text = "مبلغ کل";
            // 
            // txttedad
            // 
            this.txttedad.BackColor = System.Drawing.Color.White;
            this.txttedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttedad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txttedad.ForeColor = System.Drawing.Color.Black;
            this.txttedad.Location = new System.Drawing.Point(60, 29);
            this.txttedad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttedad.MaxLength = 50;
            this.txttedad.Name = "txttedad";
            this.txttedad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttedad.Size = new System.Drawing.Size(119, 22);
            this.txttedad.TabIndex = 5;
            this.txttedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttedad.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txttedad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txttedad.Leave += new System.EventHandler(this.Leave_Action);
            this.txttedad.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(187, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 14);
            this.label6.TabIndex = 114;
            this.label6.Text = "تعداد";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtdaru_name.Location = new System.Drawing.Point(293, 120);
            this.txtdaru_name.Name = "txtdaru_name";
            this.txtdaru_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdaru_name.Size = new System.Drawing.Size(149, 21);
            this.txtdaru_name.TabIndex = 4;
            this.txtdaru_name.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdaru_name.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdaru_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdaru_name.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Cursor = System.Windows.Forms.Cursors.Default;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(23, 66);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 113;
            this.label17.Text = "تومان";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(185, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 14);
            this.label15.TabIndex = 112;
            this.label15.Text = "مبلغ واحد";
            // 
            // txtdaru_date
            // 
            this.txtdaru_date.BackColor = System.Drawing.Color.White;
            this.txtdaru_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdaru_date.ForeColor = System.Drawing.Color.Black;
            this.txtdaru_date.Location = new System.Drawing.Point(293, 28);
            this.txtdaru_date.Mask = "1300/00/00";
            this.txtdaru_date.Name = "txtdaru_date";
            this.txtdaru_date.ResetOnSpace = false;
            this.txtdaru_date.Size = new System.Drawing.Size(149, 22);
            this.txtdaru_date.TabIndex = 1;
            this.txtdaru_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdaru_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdaru_date.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdaru_date.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdaru_date.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // txtdaryaft_az
            // 
            this.txtdaryaft_az.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtdaryaft_az.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtdaryaft_az.BackColor = System.Drawing.Color.White;
            this.txtdaryaft_az.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtdaryaft_az.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtdaryaft_az.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtdaryaft_az.ForeColor = System.Drawing.Color.Black;
            this.txtdaryaft_az.Location = new System.Drawing.Point(293, 57);
            this.txtdaryaft_az.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdaryaft_az.MaxLength = 100;
            this.txtdaryaft_az.Name = "txtdaryaft_az";
            this.txtdaryaft_az.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdaryaft_az.Size = new System.Drawing.Size(149, 22);
            this.txtdaryaft_az.TabIndex = 2;
            this.txtdaryaft_az.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdaryaft_az.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdaryaft_az.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdaryaft_az.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(450, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 105;
            this.label5.Text = "دریافت از";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(450, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 103;
            this.label4.Text = "نام دارو";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(448, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 101;
            this.label2.Text = "تاریخ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttahvil_be
            // 
            this.txttahvil_be.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txttahvil_be.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txttahvil_be.BackColor = System.Drawing.Color.White;
            this.txttahvil_be.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txttahvil_be.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txttahvil_be.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txttahvil_be.ForeColor = System.Drawing.Color.Black;
            this.txttahvil_be.Location = new System.Drawing.Point(293, 89);
            this.txttahvil_be.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttahvil_be.MaxLength = 100;
            this.txttahvil_be.Name = "txttahvil_be";
            this.txttahvil_be.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttahvil_be.Size = new System.Drawing.Size(149, 22);
            this.txttahvil_be.TabIndex = 3;
            this.txttahvil_be.Leave += new System.EventHandler(this.Leave_Action);
            this.txttahvil_be.Enter += new System.EventHandler(this.Enter_Action);
            this.txttahvil_be.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txttahvil_be.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(448, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 108;
            this.label9.Text = "تحویل به";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtfee_kol
            // 
            this.txtfee_kol.BackColor = System.Drawing.Color.White;
            this.txtfee_kol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfee_kol.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtfee_kol.ForeColor = System.Drawing.Color.Black;
            this.txtfee_kol.Location = new System.Drawing.Point(60, 91);
            this.txtfee_kol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtfee_kol.MaxLength = 20;
            this.txtfee_kol.Name = "txtfee_kol";
            this.txtfee_kol.ReadOnly = true;
            this.txtfee_kol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfee_kol.Size = new System.Drawing.Size(119, 22);
            this.txtfee_kol.TabIndex = 7;
            this.txtfee_kol.TabStop = false;
            this.txtfee_kol.Text = "0";
            this.txtfee_kol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfee_kol.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtfee_kol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtfee_kol.Leave += new System.EventHandler(this.Leave_Action);
            this.txtfee_kol.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // txtfee
            // 
            this.txtfee.BackColor = System.Drawing.Color.White;
            this.txtfee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfee.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtfee.ForeColor = System.Drawing.Color.Black;
            this.txtfee.Location = new System.Drawing.Point(60, 62);
            this.txtfee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtfee.MaxLength = 20;
            this.txtfee.Name = "txtfee";
            this.txtfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfee.Size = new System.Drawing.Size(119, 22);
            this.txtfee.TabIndex = 6;
            this.txtfee.Text = "0";
            this.txtfee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfee.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtfee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtfee.Leave += new System.EventHandler(this.Leave_Action);
            this.txtfee.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // lblvahed
            // 
            this.lblvahed.BackColor = System.Drawing.Color.Transparent;
            this.lblvahed.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblvahed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblvahed.ForeColor = System.Drawing.Color.Black;
            this.lblvahed.Location = new System.Drawing.Point(2, 31);
            this.lblvahed.Name = "lblvahed";
            this.lblvahed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblvahed.Size = new System.Drawing.Size(55, 15);
            this.lblvahed.TabIndex = 117;
            this.lblvahed.Text = "-";
            this.lblvahed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDaruEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(551, 250);
            this.Controls.Add(this.grpinfo_box);
            this.Controls.Add(this.idsearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDaruEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش اطلاعات";
            this.Load += new System.EventHandler(this.frmDaruEdit_Load);
            this.grpinfo_box.ResumeLayout(false);
            this.grpinfo_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtid;
        public System.Windows.Forms.Button idsearch;
        private System.Windows.Forms.GroupBox grpinfo_box;
        public System.Windows.Forms.Label label7;
        private CurrencyTextBox txtfee_kol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttedad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtdaru_name;
        public System.Windows.Forms.Label label17;
        private CurrencyTextBox txtfee;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox txtdaru_date;
        private System.Windows.Forms.ComboBox txtdaryaft_az;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txttahvil_be;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lblvahed;

    }
}