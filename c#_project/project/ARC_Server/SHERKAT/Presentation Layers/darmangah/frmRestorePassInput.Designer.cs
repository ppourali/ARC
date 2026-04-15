namespace Mehr.Presentation_Layers
{
    partial class FrmRestorePassInput
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtBackupPass = new System.Windows.Forms.TextBox();
            this.chkSameAsCurrent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(142, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "رمز امنیتی مرکز";
            // 
            // txtpass
            // 
            this.txtpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtpass.Location = new System.Drawing.Point(30, 17);
            this.txtpass.MaxLength = 8;
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(106, 21);
            this.txtpass.TabIndex = 0;
            this.txtpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtpass.UseSystemPasswordChar = true;
            this.txtpass.TextChanged += new System.EventHandler(this.txtidno_TextChanged);
            this.txtpass.Leave += new System.EventHandler(this.Leave_Action);
            this.txtpass.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(135, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "تایید";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.Location = new System.Drawing.Point(37, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "انصراف";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBackupPass
            // 
            this.txtBackupPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBackupPass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBackupPass.Location = new System.Drawing.Point(30, 44);
            this.txtBackupPass.MaxLength = 8;
            this.txtBackupPass.Name = "txtBackupPass";
            this.txtBackupPass.Size = new System.Drawing.Size(106, 21);
            this.txtBackupPass.TabIndex = 1;
            this.txtBackupPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBackupPass.UseSystemPasswordChar = true;
            this.txtBackupPass.TextChanged += new System.EventHandler(this.txtidno_TextChanged);
            this.txtBackupPass.Leave += new System.EventHandler(this.Leave_Action);
            this.txtBackupPass.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // chkSameAsCurrent
            // 
            this.chkSameAsCurrent.AutoSize = true;
            this.chkSameAsCurrent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkSameAsCurrent.Location = new System.Drawing.Point(142, 48);
            this.chkSameAsCurrent.Name = "chkSameAsCurrent";
            this.chkSameAsCurrent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSameAsCurrent.Size = new System.Drawing.Size(103, 17);
            this.chkSameAsCurrent.TabIndex = 5;
            this.chkSameAsCurrent.Text = "رمز فایل پشتیبان";
            this.chkSameAsCurrent.UseVisualStyleBackColor = true;
            this.chkSameAsCurrent.CheckedChanged += new System.EventHandler(this.chkSameAsCurrent_CheckedChanged);
            // 
            // frmRestorePassInput
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(264, 120);
            this.ControlBox = false;
            this.Controls.Add(this.chkSameAsCurrent);
            this.Controls.Add(this.txtBackupPass);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmRestorePassInput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmRestorePassInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBackupPass;
        private System.Windows.Forms.CheckBox chkSameAsCurrent;
    }
}