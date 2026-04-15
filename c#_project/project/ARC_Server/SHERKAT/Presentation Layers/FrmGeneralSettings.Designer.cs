
namespace Mehr.Presentation_Layers
{
    partial class FrmGeneralSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGeneralSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpboxMaliReal = new System.Windows.Forms.GroupBox();
            this.txttakhfif_Inc = new System.Windows.Forms.ComboBox();
            this.txtPayType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpboxMaliDaftari = new System.Windows.Forms.GroupBox();
            this.txtDaftariPayType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpboxBazrasKey = new System.Windows.Forms.GroupBox();
            this.txtBazrasKey = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.grpboxMaliReal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpboxMaliDaftari.SuspendLayout();
            this.grpboxBazrasKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(372, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 103;
            this.label1.Text = "روش پرداخت";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(124, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 134;
            this.label2.Text = "محاسبه ی تخفیف";
            // 
            // grpboxMaliReal
            // 
            this.grpboxMaliReal.BackColor = System.Drawing.Color.Transparent;
            this.grpboxMaliReal.Controls.Add(this.txttakhfif_Inc);
            this.grpboxMaliReal.Controls.Add(this.txtPayType);
            this.grpboxMaliReal.Controls.Add(this.label1);
            this.grpboxMaliReal.Controls.Add(this.label2);
            this.grpboxMaliReal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpboxMaliReal.Location = new System.Drawing.Point(13, 84);
            this.grpboxMaliReal.Name = "grpboxMaliReal";
            this.grpboxMaliReal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpboxMaliReal.Size = new System.Drawing.Size(449, 66);
            this.grpboxMaliReal.TabIndex = 1;
            this.grpboxMaliReal.TabStop = false;
            this.grpboxMaliReal.Text = "امور مالی واقعی";
            // 
            // txttakhfif_Inc
            // 
            this.txttakhfif_Inc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txttakhfif_Inc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txttakhfif_Inc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txttakhfif_Inc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txttakhfif_Inc.FormattingEnabled = true;
            this.txttakhfif_Inc.Items.AddRange(new object[] {
            "بلی",
            "خیر"});
            this.txttakhfif_Inc.Location = new System.Drawing.Point(6, 27);
            this.txttakhfif_Inc.Name = "txttakhfif_Inc";
            this.txttakhfif_Inc.Size = new System.Drawing.Size(112, 24);
            this.txttakhfif_Inc.TabIndex = 3;
            this.txttakhfif_Inc.SelectedIndexChanged += new System.EventHandler(this.addbtnTextChanged);
            this.txttakhfif_Inc.Leave += new System.EventHandler(this.txtmablagh_Leave);
            this.txttakhfif_Inc.Enter += new System.EventHandler(this.txtmablagh_Enter);
            this.txttakhfif_Inc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthesab_KeyDown);
            this.txttakhfif_Inc.TextChanged += new System.EventHandler(this.addbtnTextChanged);
            // 
            // txtPayType
            // 
            this.txtPayType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPayType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtPayType.FormattingEnabled = true;
            this.txtPayType.Items.AddRange(new object[] {
            "روزانه",
            "دارویی"});
            this.txtPayType.Location = new System.Drawing.Point(254, 27);
            this.txtPayType.Name = "txtPayType";
            this.txtPayType.Size = new System.Drawing.Size(112, 24);
            this.txtPayType.TabIndex = 2;
            this.txtPayType.SelectedIndexChanged += new System.EventHandler(this.addbtnTextChanged);
            this.txtPayType.Leave += new System.EventHandler(this.txtmablagh_Leave);
            this.txtPayType.Enter += new System.EventHandler(this.txtmablagh_Enter);
            this.txtPayType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthesab_KeyDown);
            this.txtPayType.TextChanged += new System.EventHandler(this.addbtnTextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnexit);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(13, 157);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(237, 71);
            this.groupBox2.TabIndex = 3;
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
            this.btnexit.Location = new System.Drawing.Point(10, 20);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(101, 43);
            this.btnexit.TabIndex = 6;
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
            this.btnAdd.Location = new System.Drawing.Point(117, 20);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(101, 43);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpboxMaliDaftari
            // 
            this.grpboxMaliDaftari.BackColor = System.Drawing.Color.Transparent;
            this.grpboxMaliDaftari.Controls.Add(this.txtDaftariPayType);
            this.grpboxMaliDaftari.Controls.Add(this.label3);
            this.grpboxMaliDaftari.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpboxMaliDaftari.Location = new System.Drawing.Point(256, 12);
            this.grpboxMaliDaftari.Name = "grpboxMaliDaftari";
            this.grpboxMaliDaftari.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpboxMaliDaftari.Size = new System.Drawing.Size(206, 72);
            this.grpboxMaliDaftari.TabIndex = 0;
            this.grpboxMaliDaftari.TabStop = false;
            this.grpboxMaliDaftari.Text = "امور مالی دفتری";
            // 
            // txtDaftariPayType
            // 
            this.txtDaftariPayType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDaftariPayType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDaftariPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtDaftariPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDaftariPayType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtDaftariPayType.FormattingEnabled = true;
            this.txtDaftariPayType.Items.AddRange(new object[] {
            "ماهانه",
            "دارویی"});
            this.txtDaftariPayType.Location = new System.Drawing.Point(11, 21);
            this.txtDaftariPayType.Name = "txtDaftariPayType";
            this.txtDaftariPayType.Size = new System.Drawing.Size(112, 24);
            this.txtDaftariPayType.TabIndex = 0;
            this.txtDaftariPayType.TextChanged += new System.EventHandler(this.addbtnTextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(129, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 103;
            this.label3.Text = "روش پرداخت";
            // 
            // grpboxBazrasKey
            // 
            this.grpboxBazrasKey.BackColor = System.Drawing.Color.Transparent;
            this.grpboxBazrasKey.Controls.Add(this.checkBox1);
            this.grpboxBazrasKey.Controls.Add(this.txtBazrasKey);
            this.grpboxBazrasKey.Controls.Add(this.label5);
            this.grpboxBazrasKey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpboxBazrasKey.Location = new System.Drawing.Point(13, 12);
            this.grpboxBazrasKey.Name = "grpboxBazrasKey";
            this.grpboxBazrasKey.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpboxBazrasKey.Size = new System.Drawing.Size(237, 72);
            this.grpboxBazrasKey.TabIndex = 2;
            this.grpboxBazrasKey.TabStop = false;
            this.grpboxBazrasKey.Text = "کلید ورود بازرس";
            // 
            // txtBazrasKey
            // 
            this.txtBazrasKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBazrasKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBazrasKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtBazrasKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBazrasKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtBazrasKey.FormattingEnabled = true;
            this.txtBazrasKey.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "F1",
            "F2",
            "F3",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.txtBazrasKey.Location = new System.Drawing.Point(6, 21);
            this.txtBazrasKey.Name = "txtBazrasKey";
            this.txtBazrasKey.Size = new System.Drawing.Size(112, 24);
            this.txtBazrasKey.TabIndex = 4;
            this.txtBazrasKey.SelectedIndexChanged += new System.EventHandler(this.txtBazrasKey_TextChanged);
            this.txtBazrasKey.TextChanged += new System.EventHandler(this.txtBazrasKey_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(124, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 103;
            this.label5.Text = "انتخاب کلید";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(10, 46);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox1.Size = new System.Drawing.Size(65, 20);
            this.checkBox1.TabIndex = 104;
            this.checkBox1.Text = "Control";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmGen_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(474, 242);
            this.Controls.Add(this.grpboxBazrasKey);
            this.Controls.Add(this.grpboxMaliDaftari);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpboxMaliReal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGen_Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmGen_Settings_Load);
            this.grpboxMaliReal.ResumeLayout(false);
            this.grpboxMaliReal.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpboxMaliDaftari.ResumeLayout(false);
            this.grpboxMaliDaftari.PerformLayout();
            this.grpboxBazrasKey.ResumeLayout(false);
            this.grpboxBazrasKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpboxMaliReal;
        private System.Windows.Forms.ComboBox txttakhfif_Inc;
        private System.Windows.Forms.ComboBox txtPayType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpboxMaliDaftari;
        private System.Windows.Forms.ComboBox txtDaftariPayType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpboxBazrasKey;
        private System.Windows.Forms.ComboBox txtBazrasKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}