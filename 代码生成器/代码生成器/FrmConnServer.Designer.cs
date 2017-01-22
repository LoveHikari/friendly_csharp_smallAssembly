namespace 代码生成器
{
    partial class FrmConnServer
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
            this.plSqlServer = new System.Windows.Forms.Panel();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDetermine = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbSerVerType = new System.Windows.Forms.ComboBox();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plSqlServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // plSqlServer
            // 
            this.plSqlServer.Controls.Add(this.txtPwd);
            this.plSqlServer.Controls.Add(this.cbDatabase);
            this.plSqlServer.Controls.Add(this.btnCancel);
            this.plSqlServer.Controls.Add(this.btnDetermine);
            this.plSqlServer.Controls.Add(this.btnTest);
            this.plSqlServer.Controls.Add(this.checkBox1);
            this.plSqlServer.Controls.Add(this.cbSerVerType);
            this.plSqlServer.Controls.Add(this.txtUid);
            this.plSqlServer.Controls.Add(this.txtServerName);
            this.plSqlServer.Controls.Add(this.label5);
            this.plSqlServer.Controls.Add(this.label4);
            this.plSqlServer.Controls.Add(this.label3);
            this.plSqlServer.Controls.Add(this.label2);
            this.plSqlServer.Controls.Add(this.label1);
            this.plSqlServer.Location = new System.Drawing.Point(12, 12);
            this.plSqlServer.Name = "plSqlServer";
            this.plSqlServer.Size = new System.Drawing.Size(264, 224);
            this.plSqlServer.TabIndex = 0;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(88, 104);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 14;
            // 
            // cbDatabase
            // 
            this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(80, 128);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(121, 20);
            this.cbDatabase.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(168, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDetermine
            // 
            this.btnDetermine.Location = new System.Drawing.Point(80, 184);
            this.btnDetermine.Name = "btnDetermine";
            this.btnDetermine.Size = new System.Drawing.Size(75, 23);
            this.btnDetermine.TabIndex = 11;
            this.btnDetermine.Text = "确定";
            this.btnDetermine.UseVisualStyleBackColor = true;
            this.btnDetermine.Click += new System.EventHandler(this.btnDetermine_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(0, 184);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "连接/测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(32, 152);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "高效连接模式";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbSerVerType
            // 
            this.cbSerVerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerVerType.FormattingEnabled = true;
            this.cbSerVerType.Location = new System.Drawing.Point(96, 56);
            this.cbSerVerType.Name = "cbSerVerType";
            this.cbSerVerType.Size = new System.Drawing.Size(121, 20);
            this.cbSerVerType.TabIndex = 8;
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(96, 80);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(100, 21);
            this.txtUid.TabIndex = 6;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(96, 24);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(100, 21);
            this.txtServerName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "数据库";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "登录名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务器类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器名称";
            // 
            // FrmConnServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.plSqlServer);
            this.Name = "FrmConnServer";
            this.Text = "连接到服务器";
            this.Load += new System.EventHandler(this.FrmConnServer_Load);
            this.plSqlServer.ResumeLayout(false);
            this.plSqlServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plSqlServer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDetermine;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSerVerType;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.TextBox txtPwd;
    }
}