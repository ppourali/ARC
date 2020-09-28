namespace Daru.Presentation_Layers
{
    partial class frmDaruInp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDaruInp));
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtRecordPosition = new System.Windows.Forms.TextBox();
            this.btnMoveLast = new System.Windows.Forms.Button();
            this.btnMoveNext = new System.Windows.Forms.Button();
            this.btnMovePrevious = new System.Windows.Forms.Button();
            this.btnMoveFirst = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.lblvahed = new System.Windows.Forms.Label();
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
            this.txtid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttahvil_be = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtfee_kol = new Daru.CurrencyTextBox();
            this.txtfee = new Daru.CurrencyTextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpinfo_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(123, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(16, 0, 1, 0);
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(548, 22);
            this.statusStrip1.TabIndex = 52;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtRecordPosition
            // 
            this.txtRecordPosition.BackColor = System.Drawing.Color.White;
            this.txtRecordPosition.Enabled = false;
            this.txtRecordPosition.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtRecordPosition.ForeColor = System.Drawing.Color.Black;
            this.txtRecordPosition.Location = new System.Drawing.Point(117, 102);
            this.txtRecordPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRecordPosition.Name = "txtRecordPosition";
            this.txtRecordPosition.ReadOnly = true;
            this.txtRecordPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRecordPosition.Size = new System.Drawing.Size(154, 22);
            this.txtRecordPosition.TabIndex = 22;
            this.txtRecordPosition.TabStop = false;
            this.txtRecordPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMoveLast
            // 
            this.btnMoveLast.BackColor = System.Drawing.Color.White;
            this.btnMoveLast.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMoveLast.Location = new System.Drawing.Point(326, 102);
            this.btnMoveLast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveLast.Name = "btnMoveLast";
            this.btnMoveLast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveLast.Size = new System.Drawing.Size(40, 28);
            this.btnMoveLast.TabIndex = 13;
            this.btnMoveLast.TabStop = false;
            this.btnMoveLast.Text = ">|";
            this.btnMoveLast.UseVisualStyleBackColor = true;
            this.btnMoveLast.Click += new System.EventHandler(this.btnMoveLast_Click);
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.BackColor = System.Drawing.Color.White;
            this.btnMoveNext.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMoveNext.Location = new System.Drawing.Point(279, 102);
            this.btnMoveNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveNext.Size = new System.Drawing.Size(40, 28);
            this.btnMoveNext.TabIndex = 10;
            this.btnMoveNext.TabStop = false;
            this.btnMoveNext.Text = ">";
            this.btnMoveNext.UseVisualStyleBackColor = true;
            this.btnMoveNext.Click += new System.EventHandler(this.btnMoveNext_Click);
            // 
            // btnMovePrevious
            // 
            this.btnMovePrevious.BackColor = System.Drawing.Color.White;
            this.btnMovePrevious.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMovePrevious.Location = new System.Drawing.Point(71, 102);
            this.btnMovePrevious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMovePrevious.Name = "btnMovePrevious";
            this.btnMovePrevious.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMovePrevious.Size = new System.Drawing.Size(40, 28);
            this.btnMovePrevious.TabIndex = 11;
            this.btnMovePrevious.TabStop = false;
            this.btnMovePrevious.Text = "<";
            this.btnMovePrevious.UseVisualStyleBackColor = true;
            this.btnMovePrevious.Click += new System.EventHandler(this.btnMovePrevious_Click);
            // 
            // btnMoveFirst
            // 
            this.btnMoveFirst.BackColor = System.Drawing.Color.White;
            this.btnMoveFirst.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMoveFirst.Location = new System.Drawing.Point(24, 102);
            this.btnMoveFirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveFirst.Name = "btnMoveFirst";
            this.btnMoveFirst.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMoveFirst.Size = new System.Drawing.Size(40, 28);
            this.btnMoveFirst.TabIndex = 13;
            this.btnMoveFirst.TabStop = false;
            this.btnMoveFirst.Text = "| <";
            this.btnMoveFirst.UseVisualStyleBackColor = true;
            this.btnMoveFirst.Click += new System.EventHandler(this.btnMoveFirst_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(24, 24);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(114, 71);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "اضافه";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(251, 22);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(114, 71);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(251, 22);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(114, 71);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "جدید";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.txtRecordPosition);
            this.groupBox2.Controls.Add(this.btnMoveLast);
            this.groupBox2.Controls.Add(this.btnMoveNext);
            this.groupBox2.Controls.Add(this.btnMovePrevious);
            this.groupBox2.Controls.Add(this.btnMoveFirst);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(76, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(393, 149);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
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
            this.grpinfo_box.Controls.Add(this.txtid);
            this.grpinfo_box.Controls.Add(this.label3);
            this.grpinfo_box.Controls.Add(this.txttahvil_be);
            this.grpinfo_box.Controls.Add(this.label1);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(14, 15);
            this.grpinfo_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Size = new System.Drawing.Size(519, 157);
            this.grpinfo_box.TabIndex = 1;
            this.grpinfo_box.TabStop = false;
            // 
            // lblvahed
            // 
            this.lblvahed.BackColor = System.Drawing.Color.Transparent;
            this.lblvahed.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblvahed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblvahed.ForeColor = System.Drawing.Color.Black;
            this.lblvahed.Location = new System.Drawing.Point(6, 60);
            this.lblvahed.Name = "lblvahed";
            this.lblvahed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblvahed.Size = new System.Drawing.Size(55, 15);
            this.lblvahed.TabIndex = 99;
            this.lblvahed.Text = "-";
            this.lblvahed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(30, 119);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 98;
            this.label7.Text = "تومان";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(192, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 14);
            this.label8.TabIndex = 97;
            this.label8.Text = "مبلغ کل";
            // 
            // txttedad
            // 
            this.txttedad.BackColor = System.Drawing.Color.White;
            this.txttedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttedad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txttedad.ForeColor = System.Drawing.Color.Black;
            this.txttedad.Location = new System.Drawing.Point(67, 53);
            this.txttedad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttedad.MaxLength = 50;
            this.txttedad.Name = "txttedad";
            this.txttedad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttedad.Size = new System.Drawing.Size(119, 22);
            this.txttedad.TabIndex = 5;
            this.txttedad.Text = "0";
            this.txttedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttedad.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txttedad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txttedad.Leave += new System.EventHandler(this.Leave_Action);
            this.txttedad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txttedad.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(194, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 14);
            this.label6.TabIndex = 95;
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
            this.txtdaru_name.Location = new System.Drawing.Point(37, 24);
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
            this.label17.Location = new System.Drawing.Point(30, 90);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 94;
            this.label17.Text = "تومان";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(192, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 14);
            this.label15.TabIndex = 88;
            this.label15.Text = "مبلغ واحد";
            // 
            // txtdaru_date
            // 
            this.txtdaru_date.BackColor = System.Drawing.Color.White;
            this.txtdaru_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdaru_date.ForeColor = System.Drawing.Color.Black;
            this.txtdaru_date.Location = new System.Drawing.Point(290, 56);
            this.txtdaru_date.Mask = "1300/00/00";
            this.txtdaru_date.Name = "txtdaru_date";
            this.txtdaru_date.ResetOnSpace = false;
            this.txtdaru_date.Size = new System.Drawing.Size(149, 22);
            this.txtdaru_date.TabIndex = 1;
            this.txtdaru_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdaru_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdaru_date.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdaru_date.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdaru_date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
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
            this.txtdaryaft_az.Location = new System.Drawing.Point(290, 85);
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
            this.label5.Location = new System.Drawing.Point(447, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "دریافت از";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(194, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "نام دارو";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(445, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "تاریخ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(290, 23);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtid.MaxLength = 4;
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(149, 22);
            this.txtid.TabIndex = 0;
            this.txtid.TabStop = false;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
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
            this.label3.Location = new System.Drawing.Point(445, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "شماره";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txttahvil_be.Location = new System.Drawing.Point(290, 117);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(445, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "تحویل به";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // txtfee_kol
            // 
            this.txtfee_kol.BackColor = System.Drawing.Color.White;
            this.txtfee_kol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfee_kol.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtfee_kol.ForeColor = System.Drawing.Color.Black;
            this.txtfee_kol.Location = new System.Drawing.Point(67, 115);
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
            this.txtfee_kol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtfee_kol.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // txtfee
            // 
            this.txtfee.BackColor = System.Drawing.Color.White;
            this.txtfee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfee.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtfee.ForeColor = System.Drawing.Color.Black;
            this.txtfee.Location = new System.Drawing.Point(67, 86);
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
            this.txtfee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtfee.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // frmDaruInp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(548, 362);
            this.Controls.Add(this.grpinfo_box);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmDaruInp";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ورود اطلاعات داروها";
            this.Load += new System.EventHandler(this.frmDaruInp_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpinfo_box.ResumeLayout(false);
            this.grpinfo_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtRecordPosition;
        private System.Windows.Forms.Button btnMoveLast;
        private System.Windows.Forms.Button btnMoveNext;
        private System.Windows.Forms.Button btnMovePrevious;
        private System.Windows.Forms.Button btnMoveFirst;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpinfo_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txttahvil_be;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtdaryaft_az;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtdaru_date;
        private CurrencyTextBox txtfee;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox txtdaru_name;
        private System.Windows.Forms.TextBox txttedad;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        private CurrencyTextBox txtfee_kol;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblvahed;
    }
}