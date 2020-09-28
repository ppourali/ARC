namespace Mehr.Presentation_Layers
{
    partial class frmContactEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactEdit));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.idsearch = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpinfo_box = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnUpdate.Size = new System.Drawing.Size(114, 55);
            this.btnUpdate.TabIndex = 6;
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
            this.txtid.Validating += new System.ComponentModel.CancelEventHandler(this.txtid_Validating);
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
            this.grpinfo_box.Controls.Add(this.txtAddress);
            this.grpinfo_box.Controls.Add(this.label6);
            this.grpinfo_box.Controls.Add(this.txtFullname);
            this.grpinfo_box.Controls.Add(this.label5);
            this.grpinfo_box.Controls.Add(this.txtPhone);
            this.grpinfo_box.Controls.Add(this.label2);
            this.grpinfo_box.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpinfo_box.Location = new System.Drawing.Point(20, 84);
            this.grpinfo_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Name = "grpinfo_box";
            this.grpinfo_box.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpinfo_box.Size = new System.Drawing.Size(519, 123);
            this.grpinfo_box.TabIndex = 7;
            this.grpinfo_box.TabStop = false;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(61, 83);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(334, 22);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtAddress.Leave += new System.EventHandler(this.Leave_Action);
            this.txtAddress.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(403, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 95;
            this.label6.Text = "آدرس";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullname
            // 
            this.txtFullname.BackColor = System.Drawing.Color.White;
            this.txtFullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFullname.ForeColor = System.Drawing.Color.Black;
            this.txtFullname.Location = new System.Drawing.Point(246, 23);
            this.txtFullname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFullname.MaxLength = 100;
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFullname.Size = new System.Drawing.Size(149, 22);
            this.txtFullname.TabIndex = 1;
            this.txtFullname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFullname.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtFullname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtFullname.Leave += new System.EventHandler(this.Leave_Action);
            this.txtFullname.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(403, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "نام مخاطب";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Location = new System.Drawing.Point(61, 53);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.MaxLength = 100;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.Size = new System.Drawing.Size(334, 22);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhone.TextChanged += new System.EventHandler(this.TextChanged_Action);
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Action);
            this.txtPhone.Leave += new System.EventHandler(this.Leave_Action);
            this.txtPhone.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(401, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "تلفن (های) تماس";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmContactEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(551, 225);
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
            this.Name = "frmContactEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش اطلاعات";
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
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;

    }
}