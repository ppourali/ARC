namespace Mehr.Presentation_Layers
{
    partial class frmTajdidSelectInp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTajdidSelectInp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtname = new System.Windows.Forms.ComboBox();
            this.txtravesh_tark = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSabegheh = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahvil_day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahvil_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daru_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.txtravesh_tark);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtid);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(761, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات پایه بیمار";
            // 
            // txtname
            // 
            this.txtname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtname.BackColor = System.Drawing.Color.White;
            this.txtname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtname.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtname.ForeColor = System.Drawing.Color.Black;
            this.txtname.FormattingEnabled = true;
            this.txtname.Location = new System.Drawing.Point(481, 22);
            this.txtname.Name = "txtname";
            this.txtname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtname.Size = new System.Drawing.Size(148, 21);
            this.txtname.TabIndex = 0;
            this.txtname.Leave += new System.EventHandler(this.Leave_Action);
            this.txtname.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // txtravesh_tark
            // 
            this.txtravesh_tark.BackColor = System.Drawing.Color.White;
            this.txtravesh_tark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtravesh_tark.Enabled = false;
            this.txtravesh_tark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtravesh_tark.ForeColor = System.Drawing.Color.Black;
            this.txtravesh_tark.Location = new System.Drawing.Point(6, 22);
            this.txtravesh_tark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtravesh_tark.MaxLength = 30;
            this.txtravesh_tark.Name = "txtravesh_tark";
            this.txtravesh_tark.ReadOnly = true;
            this.txtravesh_tark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtravesh_tark.Size = new System.Drawing.Size(149, 22);
            this.txtravesh_tark.TabIndex = 2;
            this.txtravesh_tark.TabStop = false;
            this.txtravesh_tark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(161, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "نوع درمان";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(635, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 14);
            this.label16.TabIndex = 2;
            this.label16.Text = "نام و نام خانوادگی";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtid.Enabled = false;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtid.ForeColor = System.Drawing.Color.Black;
            this.txtid.Location = new System.Drawing.Point(261, 22);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtid.MaxLength = 4;
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtid.Size = new System.Drawing.Size(98, 22);
            this.txtid.TabIndex = 1;
            this.txtid.TabStop = false;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            this.txtid.Leave += new System.EventHandler(this.Leave_Action);
            this.txtid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Action);
            this.txtid.Enter += new System.EventHandler(this.Enter_Action);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(365, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 14);
            this.label17.TabIndex = 0;
            this.label17.Text = "شماره پرونده";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSabegheh
            // 
            this.btnSabegheh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSabegheh.BackColor = System.Drawing.SystemColors.Control;
            this.btnSabegheh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSabegheh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSabegheh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSabegheh.Image = ((System.Drawing.Image)(resources.GetObject("btnSabegheh.Image")));
            this.btnSabegheh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSabegheh.Location = new System.Drawing.Point(253, 18);
            this.btnSabegheh.Name = "btnSabegheh";
            this.btnSabegheh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSabegheh.Size = new System.Drawing.Size(137, 55);
            this.btnSabegheh.TabIndex = 48;
            this.btnSabegheh.TabStop = false;
            this.btnSabegheh.Text = "سابقه دارویی بیمار";
            this.btnSabegheh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSabegheh.UseVisualStyleBackColor = true;
            this.btnSabegheh.Click += new System.EventHandler(this.btnSabegheh_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox3.Location = new System.Drawing.Point(12, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(761, 100);
            this.groupBox3.TabIndex = 1001;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "آخرین دوز تجویز پزشک";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.id,
            this.name,
            this.tahvil_day,
            this.tahvil_date,
            this.from_date,
            this.to_date,
            this.daru_name,
            this.tedad});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 15;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(745, 71);
            this.dataGridView1.TabIndex = 53;
            this.dataGridView1.TabStop = false;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "مشخصه";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 60;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "کد بیمار";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "نام بیمار";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 130;
            // 
            // tahvil_day
            // 
            this.tahvil_day.DataPropertyName = "tajviz_day";
            this.tahvil_day.HeaderText = "روز تجویز";
            this.tahvil_day.Name = "tahvil_day";
            this.tahvil_day.ReadOnly = true;
            this.tahvil_day.Width = 80;
            // 
            // tahvil_date
            // 
            this.tahvil_date.DataPropertyName = "tajviz_date";
            this.tahvil_date.HeaderText = "تاریخ تجویز";
            this.tahvil_date.Name = "tahvil_date";
            this.tahvil_date.ReadOnly = true;
            this.tahvil_date.Width = 80;
            // 
            // from_date
            // 
            this.from_date.DataPropertyName = "from_date";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            this.from_date.DefaultCellStyle = dataGridViewCellStyle4;
            this.from_date.HeaderText = "از تاریخ";
            this.from_date.Name = "from_date";
            this.from_date.ReadOnly = true;
            this.from_date.Width = 80;
            // 
            // to_date
            // 
            this.to_date.DataPropertyName = "to_date";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            this.to_date.DefaultCellStyle = dataGridViewCellStyle5;
            this.to_date.HeaderText = "تا تاریخ";
            this.to_date.Name = "to_date";
            this.to_date.ReadOnly = true;
            this.to_date.Width = 80;
            // 
            // daru_name
            // 
            this.daru_name.DataPropertyName = "daru_name";
            this.daru_name.HeaderText = "نام دارو";
            this.daru_name.Name = "daru_name";
            this.daru_name.ReadOnly = true;
            // 
            // tedad
            // 
            this.tedad.DataPropertyName = "tedad";
            this.tedad.HeaderText = "تعداد";
            this.tedad.Name = "tedad";
            this.tedad.ReadOnly = true;
            this.tedad.Width = 65;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(13, 18);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(114, 55);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "خـــروج";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(133, 18);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(114, 55);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "تجدید دارو";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnSabegheh);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(184, 185);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(404, 84);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // frmTajdidSelectInp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(795, 295);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmTajdidSelectInp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "فرم تجدید دارو";
            this.Load += new System.EventHandler(this.frmTajdidSelectInp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtravesh_tark;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox txtname;
        private System.Windows.Forms.Button btnSabegheh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahvil_day;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahvil_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn from_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn daru_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tedad;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
    }
}