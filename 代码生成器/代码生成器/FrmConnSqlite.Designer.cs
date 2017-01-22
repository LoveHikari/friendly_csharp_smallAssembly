namespace 代码生成器
{
    partial class FrmConnSqlite
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDetermine = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.rbConnStr = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatabaseFile = new System.Windows.Forms.TextBox();
            this.rbDatabaseFile = new System.Windows.Forms.RadioButton();
            this.btnSelect = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnDetermine);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(19, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 227);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(167, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDetermine
            // 
            this.btnDetermine.Location = new System.Drawing.Point(48, 193);
            this.btnDetermine.Name = "btnDetermine";
            this.btnDetermine.Size = new System.Drawing.Size(75, 23);
            this.btnDetermine.TabIndex = 2;
            this.btnDetermine.Text = "确定";
            this.btnDetermine.UseVisualStyleBackColor = true;
            this.btnDetermine.Click += new System.EventHandler(this.btnDetermine_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtConnStr);
            this.groupBox2.Controls.Add(this.rbConnStr);
            this.groupBox2.Location = new System.Drawing.Point(22, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 66);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtConnStr
            // 
            this.txtConnStr.Enabled = false;
            this.txtConnStr.Location = new System.Drawing.Point(127, 29);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(239, 21);
            this.txtConnStr.TabIndex = 1;
            // 
            // rbConnStr
            // 
            this.rbConnStr.AccessibleName = "";
            this.rbConnStr.AutoSize = true;
            this.rbConnStr.Location = new System.Drawing.Point(12, 29);
            this.rbConnStr.Name = "rbConnStr";
            this.rbConnStr.Size = new System.Drawing.Size(95, 16);
            this.rbConnStr.TabIndex = 0;
            this.rbConnStr.TabStop = true;
            this.rbConnStr.Text = "连接字符串：";
            this.rbConnStr.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDatabaseFile);
            this.groupBox1.Controls.Add(this.rbDatabaseFile);
            this.groupBox1.Location = new System.Drawing.Point(21, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择数据库";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "(可选)";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(67, 46);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "密";
            // 
            // txtDatabaseFile
            // 
            this.txtDatabaseFile.AllowDrop = true;
            this.txtDatabaseFile.Location = new System.Drawing.Point(119, 20);
            this.txtDatabaseFile.Name = "txtDatabaseFile";
            this.txtDatabaseFile.Size = new System.Drawing.Size(100, 21);
            this.txtDatabaseFile.TabIndex = 1;
            this.txtDatabaseFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDatabaseFile_DragDrop);
            // 
            // rbDatabaseFile
            // 
            this.rbDatabaseFile.AccessibleName = "";
            this.rbDatabaseFile.AutoSize = true;
            this.rbDatabaseFile.Checked = true;
            this.rbDatabaseFile.Location = new System.Drawing.Point(11, 23);
            this.rbDatabaseFile.Name = "rbDatabaseFile";
            this.rbDatabaseFile.Size = new System.Drawing.Size(95, 16);
            this.rbDatabaseFile.TabIndex = 0;
            this.rbDatabaseFile.TabStop = true;
            this.rbDatabaseFile.Text = "数据库文件：";
            this.rbDatabaseFile.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(235, 20);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmConnSqlite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 261);
            this.Controls.Add(this.panel1);
            this.Name = "FrmConnSqlite";
            this.Text = "选择SQlite数据库";
            this.Load += new System.EventHandler(this.FrmConnSqlite_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.RadioButton rbConnStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDatabaseFile;
        private System.Windows.Forms.RadioButton rbDatabaseFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDetermine;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}