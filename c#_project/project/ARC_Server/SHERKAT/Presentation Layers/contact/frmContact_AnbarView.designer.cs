namespace Mehr.Presentation_Layers
{
    partial class FrmContact_AnbarView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContact_AnbarView));
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.contactid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daru_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mandeh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vahed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnreturn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtcontactid = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtcontactname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnexit
            // 
            this.btnexit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnexit.BackColor = System.Drawing.SystemColors.Control;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(12, 271);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 42);
            this.btnexit.TabIndex = 30;
            this.btnexit.Text = "خروج";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // grdDataViewer
            // 
            this.grdDataViewer.AllowUserToAddRows = false;
            this.grdDataViewer.AllowUserToDeleteRows = false;
            this.grdDataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDataViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contactid,
            this.contactname,
            this.daru_name,
            this.mandeh,
            this.vahed,
            this.btnreturn});
            this.grdDataViewer.Location = new System.Drawing.Point(0, 50);
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(770, 215);
            this.grdDataViewer.TabIndex = 31;
            this.grdDataViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDataViewer_CellContentClick);
            // 
            // contactid
            // 
            this.contactid.DataPropertyName = "contactid";
            this.contactid.Frozen = true;
            this.contactid.HeaderText = "کد مخاطب";
            this.contactid.Name = "contactid";
            this.contactid.ReadOnly = true;
            this.contactid.Width = 70;
            // 
            // contactname
            // 
            this.contactname.DataPropertyName = "contactname";
            this.contactname.Frozen = true;
            this.contactname.HeaderText = "نام مخاطب";
            this.contactname.Name = "contactname";
            this.contactname.ReadOnly = true;
            this.contactname.Width = 130;
            // 
            // daru_name
            // 
            this.daru_name.DataPropertyName = "daru_name";
            this.daru_name.Frozen = true;
            this.daru_name.HeaderText = "نام دارو";
            this.daru_name.Name = "daru_name";
            this.daru_name.ReadOnly = true;
            this.daru_name.Width = 150;
            // 
            // mandeh
            // 
            this.mandeh.DataPropertyName = "mandeh";
            this.mandeh.Frozen = true;
            this.mandeh.HeaderText = "تعداد مانده";
            this.mandeh.Name = "mandeh";
            this.mandeh.ReadOnly = true;
            this.mandeh.Width = 150;
            // 
            // vahed
            // 
            this.vahed.DataPropertyName = "vahed";
            this.vahed.Frozen = true;
            this.vahed.HeaderText = "واحد";
            this.vahed.Name = "vahed";
            this.vahed.ReadOnly = true;
            this.vahed.Width = 125;
            // 
            // btnreturn
            // 
            this.btnreturn.Frozen = true;
            this.btnreturn.HeaderText = "برگشت دارو";
            this.btnreturn.Name = "btnreturn";
            this.btnreturn.ReadOnly = true;
            this.btnreturn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnreturn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnreturn.Text = "برگشت دارو";
            this.btnreturn.UseColumnTextForButtonValue = true;
            // 
            // txtcontactid
            // 
            this.txtcontactid.BackColor = System.Drawing.Color.White;
            this.txtcontactid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcontactid.Enabled = false;
            this.txtcontactid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtcontactid.ForeColor = System.Drawing.Color.Black;
            this.txtcontactid.Location = new System.Drawing.Point(400, 13);
            this.txtcontactid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcontactid.MaxLength = 4;
            this.txtcontactid.Name = "txtcontactid";
            this.txtcontactid.ReadOnly = true;
            this.txtcontactid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtcontactid.Size = new System.Drawing.Size(63, 22);
            this.txtcontactid.TabIndex = 104;
            this.txtcontactid.TabStop = false;
            this.txtcontactid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(469, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 14);
            this.label17.TabIndex = 105;
            this.label17.Text = "کد مخاطب";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcontactname
            // 
            this.txtcontactname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtcontactname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtcontactname.BackColor = System.Drawing.Color.White;
            this.txtcontactname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtcontactname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtcontactname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtcontactname.ForeColor = System.Drawing.Color.Black;
            this.txtcontactname.Location = new System.Drawing.Point(554, 13);
            this.txtcontactname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcontactname.MaxLength = 100;
            this.txtcontactname.Name = "txtcontactname";
            this.txtcontactname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtcontactname.Size = new System.Drawing.Size(149, 22);
            this.txtcontactname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(709, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 103;
            this.label1.Text = "تحویل به";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnfilter
            // 
            this.btnfilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnfilter.BackColor = System.Drawing.Color.White;
            this.btnfilter.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnfilter.ForeColor = System.Drawing.Color.Black;
            this.btnfilter.Image = ((System.Drawing.Image)(resources.GetObject("btnfilter.Image")));
            this.btnfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfilter.Location = new System.Drawing.Point(12, 2);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(96, 42);
            this.btnfilter.TabIndex = 106;
            this.btnfilter.Text = "جستجو";
            this.btnfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // frmContact_AnbarView
            // 
            this.AcceptButton = this.btnfilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(769, 320);
            this.Controls.Add(this.btnfilter);
            this.Controls.Add(this.txtcontactid);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtcontactname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmContact_AnbarView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نمایش اطلاعات داروهای مخاطب";
            this.Load += new System.EventHandler(this.frmContact_AnbarView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.TextBox txtcontactid;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox txtcontactname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactid;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactname;
        private System.Windows.Forms.DataGridViewTextBoxColumn daru_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mandeh;
        private System.Windows.Forms.DataGridViewTextBoxColumn vahed;
        private System.Windows.Forms.DataGridViewButtonColumn btnreturn;
    }
}