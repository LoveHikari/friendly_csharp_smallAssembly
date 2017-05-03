namespace 开发者工具.CreateCode
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddServer = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.单表代码生成器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbCodeForMvc = new System.Windows.Forms.GroupBox();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.rbContext2 = new System.Windows.Forms.RadioButton();
            this.rbBll2 = new System.Windows.Forms.RadioButton();
            this.rbIbll2 = new System.Windows.Forms.RadioButton();
            this.rbDal2 = new System.Windows.Forms.RadioButton();
            this.rbIDal2 = new System.Windows.Forms.RadioButton();
            this.rbModels2 = new System.Windows.Forms.RadioButton();
            this.gbArchitecture = new System.Windows.Forms.GroupBox();
            this.rbMvc = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.rbDbu = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbOld = new System.Windows.Forms.RadioButton();
            this.btnCreateCode = new System.Windows.Forms.Button();
            this.cbIdentityKey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBllSuffix = new System.Windows.Forms.TextBox();
            this.txtDalSuffix = new System.Windows.Forms.TextBox();
            this.txtModelSuffix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDalPath = new System.Windows.Forms.TextBox();
            this.txtBllPath = new System.Windows.Forms.TextBox();
            this.txtModelPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCodeForlayers = new System.Windows.Forms.GroupBox();
            this.rbBll = new System.Windows.Forms.RadioButton();
            this.rbDal = new System.Windows.Forms.RadioButton();
            this.rbModels = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConnstr = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.rbModels12 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbCodeForMvc.SuspendLayout();
            this.gbArchitecture.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbCodeForlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(8, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 480);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddServer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(187, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAddServer
            // 
            this.tsbtnAddServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddServer.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddServer.Image")));
            this.tsbtnAddServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddServer.Name = "tsbtnAddServer";
            this.tsbtnAddServer.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAddServer.Text = "新增服务器注册";
            this.tsbtnAddServer.ToolTipText = "新增服务器注册";
            this.tsbtnAddServer.Click += new System.EventHandler(this.tsbtnAddServer_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(184, 445);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单表代码生成器ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // 单表代码生成器ToolStripMenuItem
            // 
            this.单表代码生成器ToolStripMenuItem.Name = "单表代码生成器ToolStripMenuItem";
            this.单表代码生成器ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.单表代码生成器ToolStripMenuItem.Text = "单表代码生成器";
            this.单表代码生成器ToolStripMenuItem.Click += new System.EventHandler(this.单表代码生成器ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(214, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 547);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbCodeForMvc);
            this.tabPage1.Controls.Add(this.gbArchitecture);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.gbCodeForlayers);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(883, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生成设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbCodeForMvc
            // 
            this.gbCodeForMvc.Controls.Add(this.radioButton10);
            this.gbCodeForMvc.Controls.Add(this.rbContext2);
            this.gbCodeForMvc.Controls.Add(this.rbBll2);
            this.gbCodeForMvc.Controls.Add(this.rbIbll2);
            this.gbCodeForMvc.Controls.Add(this.rbDal2);
            this.gbCodeForMvc.Controls.Add(this.rbIDal2);
            this.gbCodeForMvc.Controls.Add(this.rbModels2);
            this.gbCodeForMvc.Location = new System.Drawing.Point(6, 443);
            this.gbCodeForMvc.Name = "gbCodeForMvc";
            this.gbCodeForMvc.Size = new System.Drawing.Size(871, 50);
            this.gbCodeForMvc.TabIndex = 16;
            this.gbCodeForMvc.TabStop = false;
            this.gbCodeForMvc.Text = "代码类型";
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(392, 21);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(101, 16);
            this.radioButton10.TabIndex = 6;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "radioButton10";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // rbContext2
            // 
            this.rbContext2.AutoSize = true;
            this.rbContext2.Location = new System.Drawing.Point(321, 21);
            this.rbContext2.Name = "rbContext2";
            this.rbContext2.Size = new System.Drawing.Size(65, 16);
            this.rbContext2.TabIndex = 5;
            this.rbContext2.TabStop = true;
            this.rbContext2.Text = "Context";
            this.rbContext2.UseVisualStyleBackColor = true;
            // 
            // rbBll2
            // 
            this.rbBll2.AutoSize = true;
            this.rbBll2.Location = new System.Drawing.Point(266, 21);
            this.rbBll2.Name = "rbBll2";
            this.rbBll2.Size = new System.Drawing.Size(41, 16);
            this.rbBll2.TabIndex = 4;
            this.rbBll2.TabStop = true;
            this.rbBll2.Text = "BLL";
            this.rbBll2.UseVisualStyleBackColor = true;
            // 
            // rbIbll2
            // 
            this.rbIbll2.AutoSize = true;
            this.rbIbll2.Location = new System.Drawing.Point(200, 21);
            this.rbIbll2.Name = "rbIbll2";
            this.rbIbll2.Size = new System.Drawing.Size(47, 16);
            this.rbIbll2.TabIndex = 3;
            this.rbIbll2.TabStop = true;
            this.rbIbll2.Text = "IBLL";
            this.rbIbll2.UseVisualStyleBackColor = true;
            // 
            // rbDal2
            // 
            this.rbDal2.AutoSize = true;
            this.rbDal2.Location = new System.Drawing.Point(147, 21);
            this.rbDal2.Name = "rbDal2";
            this.rbDal2.Size = new System.Drawing.Size(41, 16);
            this.rbDal2.TabIndex = 2;
            this.rbDal2.TabStop = true;
            this.rbDal2.Text = "DAL";
            this.rbDal2.UseVisualStyleBackColor = true;
            // 
            // rbIDal2
            // 
            this.rbIDal2.AutoSize = true;
            this.rbIDal2.Location = new System.Drawing.Point(94, 21);
            this.rbIDal2.Name = "rbIDal2";
            this.rbIDal2.Size = new System.Drawing.Size(47, 16);
            this.rbIDal2.TabIndex = 1;
            this.rbIDal2.TabStop = true;
            this.rbIDal2.Text = "IDAL";
            this.rbIDal2.UseVisualStyleBackColor = true;
            // 
            // rbModels2
            // 
            this.rbModels2.AutoSize = true;
            this.rbModels2.Checked = true;
            this.rbModels2.Location = new System.Drawing.Point(24, 21);
            this.rbModels2.Name = "rbModels2";
            this.rbModels2.Size = new System.Drawing.Size(59, 16);
            this.rbModels2.TabIndex = 0;
            this.rbModels2.TabStop = true;
            this.rbModels2.Text = "Models";
            this.rbModels2.UseVisualStyleBackColor = true;
            // 
            // gbArchitecture
            // 
            this.gbArchitecture.Controls.Add(this.rbMvc);
            this.gbArchitecture.Controls.Add(this.radioButton6);
            this.gbArchitecture.Controls.Add(this.rbDbu);
            this.gbArchitecture.Controls.Add(this.radioButton4);
            this.gbArchitecture.Location = new System.Drawing.Point(6, 328);
            this.gbArchitecture.Name = "gbArchitecture";
            this.gbArchitecture.Size = new System.Drawing.Size(871, 50);
            this.gbArchitecture.TabIndex = 15;
            this.gbArchitecture.TabStop = false;
            this.gbArchitecture.Text = "架构选择";
            // 
            // rbMvc
            // 
            this.rbMvc.AutoSize = true;
            this.rbMvc.Location = new System.Drawing.Point(280, 21);
            this.rbMvc.Name = "rbMvc";
            this.rbMvc.Size = new System.Drawing.Size(65, 16);
            this.rbMvc.TabIndex = 3;
            this.rbMvc.TabStop = true;
            this.rbMvc.Text = "MVC模式";
            this.rbMvc.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(179, 20);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(95, 16);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "工厂模式三层";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // rbDbu
            // 
            this.rbDbu.AutoSize = true;
            this.rbDbu.Checked = true;
            this.rbDbu.Location = new System.Drawing.Point(102, 21);
            this.rbDbu.Name = "rbDbu";
            this.rbDbu.Size = new System.Drawing.Size(71, 16);
            this.rbDbu.TabIndex = 1;
            this.rbDbu.TabStop = true;
            this.rbDbu.Text = "简单三层";
            this.rbDbu.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(24, 21);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(71, 16);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "单类结构";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(6, 263);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(871, 50);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "类型";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(159, 22);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Web页面";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(94, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "C#代码";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "DB脚本";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbNew);
            this.groupBox3.Controls.Add(this.rbOld);
            this.groupBox3.Controls.Add(this.btnCreateCode);
            this.groupBox3.Controls.Add(this.cbIdentityKey);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(871, 50);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Location = new System.Drawing.Point(351, 20);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(35, 16);
            this.rbNew.TabIndex = 9;
            this.rbNew.Text = "新";
            this.rbNew.UseVisualStyleBackColor = true;
            // 
            // rbOld
            // 
            this.rbOld.AutoSize = true;
            this.rbOld.Checked = true;
            this.rbOld.Location = new System.Drawing.Point(307, 21);
            this.rbOld.Name = "rbOld";
            this.rbOld.Size = new System.Drawing.Size(35, 16);
            this.rbOld.TabIndex = 8;
            this.rbOld.TabStop = true;
            this.rbOld.Text = "旧";
            this.rbOld.UseVisualStyleBackColor = true;
            // 
            // btnCreateCode
            // 
            this.btnCreateCode.Location = new System.Drawing.Point(519, 17);
            this.btnCreateCode.Name = "btnCreateCode";
            this.btnCreateCode.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCode.TabIndex = 7;
            this.btnCreateCode.Text = "生成代码";
            this.btnCreateCode.UseVisualStyleBackColor = true;
            this.btnCreateCode.Click += new System.EventHandler(this.btnCreateCode_Click);
            // 
            // cbIdentityKey
            // 
            this.cbIdentityKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdentityKey.FormattingEnabled = true;
            this.cbIdentityKey.Location = new System.Drawing.Point(166, 20);
            this.cbIdentityKey.Name = "cbIdentityKey";
            this.cbIdentityKey.Size = new System.Drawing.Size(121, 20);
            this.cbIdentityKey.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "主键";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBllSuffix);
            this.groupBox2.Controls.Add(this.txtDalSuffix);
            this.groupBox2.Controls.Add(this.txtModelSuffix);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDalPath);
            this.groupBox2.Controls.Add(this.txtBllPath);
            this.groupBox2.Controls.Add(this.txtModelPath);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(871, 81);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数";
            // 
            // txtBllSuffix
            // 
            this.txtBllSuffix.Location = new System.Drawing.Point(562, 45);
            this.txtBllSuffix.Name = "txtBllSuffix";
            this.txtBllSuffix.Size = new System.Drawing.Size(100, 21);
            this.txtBllSuffix.TabIndex = 22;
            // 
            // txtDalSuffix
            // 
            this.txtDalSuffix.Location = new System.Drawing.Point(349, 48);
            this.txtDalSuffix.Name = "txtDalSuffix";
            this.txtDalSuffix.Size = new System.Drawing.Size(102, 21);
            this.txtDalSuffix.TabIndex = 21;
            // 
            // txtModelSuffix
            // 
            this.txtModelSuffix.Location = new System.Drawing.Point(134, 47);
            this.txtModelSuffix.Name = "txtModelSuffix";
            this.txtModelSuffix.Size = new System.Drawing.Size(100, 21);
            this.txtModelSuffix.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(467, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "业务层类名后缀";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "数据层类名后缀";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "实体类名后缀";
            // 
            // txtDalPath
            // 
            this.txtDalPath.Location = new System.Drawing.Point(351, 20);
            this.txtDalPath.Name = "txtDalPath";
            this.txtDalPath.Size = new System.Drawing.Size(100, 21);
            this.txtDalPath.TabIndex = 16;
            // 
            // txtBllPath
            // 
            this.txtBllPath.Location = new System.Drawing.Point(562, 18);
            this.txtBllPath.Name = "txtBllPath";
            this.txtBllPath.Size = new System.Drawing.Size(100, 21);
            this.txtBllPath.TabIndex = 15;
            // 
            // txtModelPath
            // 
            this.txtModelPath.Location = new System.Drawing.Point(134, 19);
            this.txtModelPath.Name = "txtModelPath";
            this.txtModelPath.Size = new System.Drawing.Size(100, 21);
            this.txtModelPath.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "业务层命名空间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "数据层命名空间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "实体类命名空间";
            // 
            // gbCodeForlayers
            // 
            this.gbCodeForlayers.Controls.Add(this.rbModels12);
            this.gbCodeForlayers.Controls.Add(this.rbBll);
            this.gbCodeForlayers.Controls.Add(this.rbDal);
            this.gbCodeForlayers.Controls.Add(this.rbModels);
            this.gbCodeForlayers.Location = new System.Drawing.Point(6, 381);
            this.gbCodeForlayers.Name = "gbCodeForlayers";
            this.gbCodeForlayers.Size = new System.Drawing.Size(871, 50);
            this.gbCodeForlayers.TabIndex = 11;
            this.gbCodeForlayers.TabStop = false;
            this.gbCodeForlayers.Text = "代码类型";
            // 
            // rbBll
            // 
            this.rbBll.AutoSize = true;
            this.rbBll.Location = new System.Drawing.Point(210, 21);
            this.rbBll.Name = "rbBll";
            this.rbBll.Size = new System.Drawing.Size(41, 16);
            this.rbBll.TabIndex = 2;
            this.rbBll.Text = "BLL";
            this.rbBll.UseVisualStyleBackColor = true;
            // 
            // rbDal
            // 
            this.rbDal.AutoSize = true;
            this.rbDal.Location = new System.Drawing.Point(160, 21);
            this.rbDal.Name = "rbDal";
            this.rbDal.Size = new System.Drawing.Size(41, 16);
            this.rbDal.TabIndex = 1;
            this.rbDal.Text = "DAL";
            this.rbDal.UseVisualStyleBackColor = true;
            // 
            // rbModels
            // 
            this.rbModels.AutoSize = true;
            this.rbModels.Checked = true;
            this.rbModels.Location = new System.Drawing.Point(24, 21);
            this.rbModels.Name = "rbModels";
            this.rbModels.Size = new System.Drawing.Size(59, 16);
            this.rbModels.TabIndex = 0;
            this.rbModels.TabStop = true;
            this.rbModels.Text = "Models";
            this.rbModels.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(871, 107);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCode);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(883, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "代码查看";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(22, 10);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(825, 418);
            this.txtCode.TabIndex = 0;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "连接字符串";
            // 
            // txtConnstr
            // 
            this.txtConnstr.Location = new System.Drawing.Point(283, 21);
            this.txtConnstr.Name = "txtConnstr";
            this.txtConnstr.Size = new System.Drawing.Size(731, 21);
            this.txtConnstr.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1020, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // rbModels12
            // 
            this.rbModels12.AutoSize = true;
            this.rbModels12.Location = new System.Drawing.Point(89, 21);
            this.rbModels12.Name = "rbModels12";
            this.rbModels12.Size = new System.Drawing.Size(65, 16);
            this.rbModels12.TabIndex = 3;
            this.rbModels12.TabStop = true;
            this.rbModels12.Text = "Models2";
            this.rbModels12.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 628);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtConnstr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "代码生成器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbCodeForMvc.ResumeLayout(false);
            this.gbCodeForMvc.PerformLayout();
            this.gbArchitecture.ResumeLayout(false);
            this.gbArchitecture.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbCodeForlayers.ResumeLayout(false);
            this.gbCodeForlayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 单表代码生成器ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.GroupBox gbCodeForlayers;
        private System.Windows.Forms.RadioButton rbBll;
        private System.Windows.Forms.RadioButton rbDal;
        private System.Windows.Forms.RadioButton rbModels;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDalPath;
        private System.Windows.Forms.TextBox txtBllPath;
        private System.Windows.Forms.TextBox txtModelPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateCode;
        private System.Windows.Forms.ComboBox cbIdentityKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox gbArchitecture;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton rbDbu;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConnstr;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbOld;
        private System.Windows.Forms.TextBox txtBllSuffix;
        private System.Windows.Forms.TextBox txtDalSuffix;
        private System.Windows.Forms.TextBox txtModelSuffix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RadioButton rbMvc;
        private System.Windows.Forms.GroupBox gbCodeForMvc;
        private System.Windows.Forms.RadioButton rbDal2;
        private System.Windows.Forms.RadioButton rbIDal2;
        private System.Windows.Forms.RadioButton rbModels2;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton rbContext2;
        private System.Windows.Forms.RadioButton rbBll2;
        private System.Windows.Forms.RadioButton rbIbll2;
        private System.Windows.Forms.ToolStripButton tsbtnAddServer;
        private System.Windows.Forms.RadioButton rbModels12;
    }
}