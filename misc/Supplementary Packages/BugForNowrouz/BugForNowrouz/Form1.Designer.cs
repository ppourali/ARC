namespace BugForNowrouz
{
    partial class Form1
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
            this.txttd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfd = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txttd
            // 
            this.txttd.Location = new System.Drawing.Point(74, 12);
            this.txttd.Name = "txttd";
            this.txttd.Size = new System.Drawing.Size(100, 20);
            this.txttd.TabIndex = 0;
            this.txttd.Text = "1389/12/30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "to date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "from date";
            // 
            // txtfd
            // 
            this.txtfd.Location = new System.Drawing.Point(255, 12);
            this.txtfd.Name = "txtfd";
            this.txtfd.Size = new System.Drawing.Size(100, 20);
            this.txtfd.TabIndex = 2;
            this.txtfd.Text = "1390/01/01";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.del_code,
            this.from_date,
            this.p1,
            this.edit_code,
            this.p2});
            this.dataGridView1.Location = new System.Drawing.Point(27, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(494, 483);
            this.dataGridView1.TabIndex = 4;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(362, 8);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 5;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // id
            // 
            this.id.HeaderText = "ردیف";
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // del_code
            // 
            this.del_code.HeaderText = "کد برای حذف";
            this.del_code.Name = "del_code";
            // 
            // from_date
            // 
            this.from_date.HeaderText = "شروع بخش اول";
            this.from_date.Name = "from_date";
            // 
            // p1
            // 
            this.p1.HeaderText = "پایان بخش اول";
            this.p1.Name = "p1";
            // 
            // edit_code
            // 
            this.edit_code.HeaderText = "کد برای ویرایش";
            this.edit_code.Name = "edit_code";
            // 
            // p2
            // 
            this.p2.HeaderText = "بخش دوم";
            this.p2.Name = "p2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 550);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtfd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttd);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtfd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn from_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn edit_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2;
    }
}

