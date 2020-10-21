namespace Mehr.Presentation_Layers
{
    partial class frmParastar_AnbarView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParastar_AnbarView));
            this.btnexit = new System.Windows.Forms.Button();
            this.grdDataViewer = new System.Windows.Forms.DataGridView();
            this.daru_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mandeh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vahed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnreturn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnedit = new System.Windows.Forms.Button();
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
            this.btnexit.Location = new System.Drawing.Point(12, 230);
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
            this.daru_name,
            this.mandeh,
            this.vahed,
            this.btnreturn});
            this.grdDataViewer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDataViewer.Location = new System.Drawing.Point(0, 0);
            this.grdDataViewer.Name = "grdDataViewer";
            this.grdDataViewer.ReadOnly = true;
            this.grdDataViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdDataViewer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataViewer.Size = new System.Drawing.Size(569, 222);
            this.grdDataViewer.TabIndex = 31;
            this.grdDataViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDataViewer_CellContentClick);
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
            // btnedit
            // 
            this.btnedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnedit.BackColor = System.Drawing.SystemColors.Control;
            this.btnedit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnedit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnedit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(346, 230);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(211, 42);
            this.btnedit.TabIndex = 42;
            this.btnedit.Text = "برگشت به صورت کلی به گاوصندوق";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // frmParastar_AnbarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(569, 279);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.grdDataViewer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmParastar_AnbarView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نمایش اطلاعات داروهای پرستار";
            this.Load += new System.EventHandler(this.frmParastar_AnbarView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView grdDataViewer;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.DataGridViewTextBoxColumn daru_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mandeh;
        private System.Windows.Forms.DataGridViewTextBoxColumn vahed;
        private System.Windows.Forms.DataGridViewButtonColumn btnreturn;
    }
}