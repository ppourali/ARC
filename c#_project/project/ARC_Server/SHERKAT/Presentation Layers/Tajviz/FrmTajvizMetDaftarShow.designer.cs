namespace Mehr.Presentation_Layers
{
    partial class FrmTajvizMetDaftarShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTajvizMetDaftarShow));
            this.btnexit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txttodate = new Mehr.DateMaskedTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdate = new Mehr.DateMaskedTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfilter = new System.Windows.Forms.Button();
            this.grdDaftar = new System.Windows.Forms.DataGridView();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaftar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.SystemColors.Control;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnexit, "btnexit");
            this.btnexit.Name = "btnexit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txttodate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtdate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnfilter);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.TabStop = true;
            // 
            // txttodate
            // 
            resources.ApplyResources(this.txttodate, "txttodate");
            this.txttodate.BackColor = System.Drawing.Color.White;
            this.txttodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttodate.ForeColor = System.Drawing.Color.Black;
            this.txttodate.Name = "txttodate";
            this.txttodate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txttodate.Leave += new System.EventHandler(this.Leave_Action);
            this.txttodate.Enter += new System.EventHandler(this.Enter_Action);
            this.txttodate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Name = "label7";
            // 
            // txtdate
            // 
            resources.ApplyResources(this.txtdate, "txtdate");
            this.txtdate.BackColor = System.Drawing.Color.White;
            this.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdate.ForeColor = System.Drawing.Color.Black;
            this.txtdate.Name = "txtdate";
            this.txtdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtdate.Leave += new System.EventHandler(this.Leave_Action);
            this.txtdate.Enter += new System.EventHandler(this.Enter_Action);
            this.txtdate.TextChanged += new System.EventHandler(this.TextChanged_Action);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // btnfilter
            // 
            resources.ApplyResources(this.btnfilter, "btnfilter");
            this.btnfilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnfilter.ForeColor = System.Drawing.Color.Black;
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // grdDaftar
            // 
            this.grdDaftar.AllowUserToAddRows = false;
            this.grdDaftar.AllowUserToDeleteRows = false;
            this.grdDaftar.BackgroundColor = System.Drawing.Color.SeaShell;
            this.grdDaftar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdDaftar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.grdDaftar, "grdDaftar");
            this.grdDaftar.MultiSelect = false;
            this.grdDaftar.Name = "grdDaftar";
            this.grdDaftar.ReadOnly = true;
            this.grdDaftar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdDaftar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDaftar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnprint
            // 
            resources.ApplyResources(this.btnprint, "btnprint");
            this.btnprint.BackColor = System.Drawing.SystemColors.Control;
            this.btnprint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnprint.Name = "btnprint";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // frmTajMetDaftarShow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnexit;
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.grdDaftar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnexit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmTajMetDaftarShow";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmTajMetDaftarShow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaftar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Panel panel1;
        public DateMaskedTextbox txtdate;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.DataGridView grdDaftar;
        public DateMaskedTextbox txttodate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnprint;
    }
}