using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DeveloperKit.Views.CreateCode.Models;
using Win.Common;
using Win.Common.Builder;
using Win.Common.Builder.MVC;
using Win.Models;
using BuilderBLL = Win.Common.Builder.BuilderBLL;
using BuilderDAL = Win.Common.Builder.MVC.BuilderDAL;
using BuilderModel = Win.Common.Builder.BuilderModel;

namespace DeveloperKit.Views.CreateCode
{
    public partial class Form1 : Form
    {
        public DataBaseConfig DataBaseConfig => Win.Models.Config.DataConfig.Instance.GetDataBaseConfig();
        private NamespaceConfig _namespaceConfig;
        public NamespaceConfig NamespaceConfig
        {
            get
            {
                if (_namespaceConfig == null)
                {
                    _namespaceConfig = Win.Models.Config.DataConfig.Instance.GetNamespaceConfig();
                }
                else
                {
                    _namespaceConfig.ModelPath = this.txtModelPath.Text;
                    _namespaceConfig.DalPath = this.txtDalPath.Text;
                    _namespaceConfig.BllPath = this.txtBllPath.Text;

                    _namespaceConfig.ModelSuffix = this.txtModelSuffix.Text;
                    _namespaceConfig.DalSuffix = this.txtDalSuffix.Text;
                    _namespaceConfig.BllSuffix = this.txtBllSuffix.Text;
                }
               
                return _namespaceConfig;
            }
        }
        private Hashtable _databaseInfo;
        public Hashtable DatabaseInfo
        {
            get
            {
                if (_databaseInfo == null)
                {
                    _databaseInfo = new Hashtable();
                    DataTable dt = Win.DAL.BLL.SqlServerBll.Instance.GetAllTable();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string tableName = dr["TABLE_NAME"].ToString();
                        List<ColumnModel> list = Win.DAL.BLL.SqlServerBll.Instance.GetTableColumnInfo(tableName);
                        _databaseInfo.Add(tableName, list);
                    }
                    return _databaseInfo;
                }
                return _databaseInfo;
            }
        }

        private Models.Config Config => new Models.Config()
        {
            Operating = this.rbOld.Checked ? "old" : "new",
            Parameter = new Models.Parameter()
            {
                ModelPath = this.txtModelPath.Text,
                DalPath = this.txtDalPath.Text,
                BllPath = this.txtBllPath.Text,
                ModelSuffix = this.txtModelSuffix.Text,
                DalSuffix = this.txtDalSuffix.Text,
                BllSuffix = this.txtBllSuffix.Text
            },
            Classification = "",
            Architecture = this.rbMvc.Checked ? "mvc" : (this.rbDbu.Checked ? "3ceng" : ""),
            CodeType = "",
        };

        public Form1()
        {
            InitializeComponent();
        }

        #region 事件

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1155, 604);
            this.tabControl1.Size = new Size(891, 478);

            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.btnCreateCode.Enabled = false;
            this.gbCodeForMvc.Visible = false;

            foreach (Control control in this.gbArchitecture.Controls)
            {
                control.Click += gbArchitectureRadioButton_Click;
            }

            BindData();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// treeView上使用鼠标单击treeNode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)  //右键
            {
                TreeNode tn = e.Node;
                string tableName = tn.Name;
                treeView1.SelectedNode = tn;
            }
        }
        private void 单表代码生成器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            string tableName = tn.Name;
            DataTable dt = new DataTable();

            switch (DataBaseConfig.ProviderName)
            {
                case "System.Data.SqlClient":
                    dt = Win.DAL.BLL.SqlServerBll.Instance.GetColumnTable(tableName);
                    break;
                case "System.Data.SQLite":
                    dt = Win.DAL.BLL.SQLiteBll.GetColumnTable(tableName);
                    break;
                case "MySql.Data.MySqlClient":
                    dt = Win.DAL.BLL.MySqlBll.Instance.GetColumnTable(DataBaseConfig.DatabaseName, tableName);
                    break;
            }

            this.dataGridView1.DataSource = dt;

            List<string> identityKeyList = (from p in dt.AsEnumerable()
                                            where p.Field<string>("主键") == "√"
                                            select p.Field<string>("字段名")).ToList();
            this.cbIdentityKey.DataSource = identityKeyList;

            this.btnCreateCode.Enabled = true;
        }
        /// <summary>
        /// 新增服务器注册单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnAddServer_Click(object sender, EventArgs e)
        {
            FrmSelectDatabase fsd = new FrmSelectDatabase();
            if (fsd.ShowDialog(this) == DialogResult.OK)
            {
                InitTreeView();
            }
            fsd.Dispose();
        }
        /// <summary>
        /// 刷新按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetDatabaseInfo();
            InitTreeView();
        }

        /// <summary>
        /// 生成按钮单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCode_Click(object sender, EventArgs e)
        {
            string tableName = treeView1.SelectedNode.Name;  //当前选中的数据表
            List<ColumnModel> columns = (List<ColumnModel>)DatabaseInfo[tableName];  //所有字段
            

            if (this.rbMvc.Checked)  //架构选择mvc模式
            {
                CreateMvcCode(columns, Config);
            }
            else if (this.rbDbu.Checked)  //简单三层模式
            {
                CreateDbuCode(columns, Config);
            }

            tabControl1.SelectedIndex = 1;

            Win.Models.Config.DataConfig.Instance.SetNamespaceConfig(NamespaceConfig);

        }
        /// <summary>
        /// 架构选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gbArchitectureRadioButton_Click(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string controlName = "";
            switch (radioButton.Name)
            {
                case "rbDbu":
                    controlName = "gbCodeForlayers";
                    break;
                case "":
                    controlName = "gbCodeForMvc";
                    break;
                default:
                    controlName = "gbCodeForMvc";
                    break;
            }
            new Action(delegate
            {
                foreach (Control control in this.tabPage1.Controls)
                {
                    if (control.Text == "代码类型" && control.Name != controlName)
                    {
                        control.Visible = false;
                    }
                    if (control.Name == controlName)
                    {
                        control.Visible = true;
                        control.Location = new Point(6, 381);
                    }
                }
            }).Invoke();
        }
        /// <summary>
        /// 按下某键后发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')  //按下ctrl+A
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
        /// <summary>
        /// 全部生成按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllGenerate_Click(object sender, EventArgs e)
        {
            var v = FormHelper.GetAllControls(this.gbArchitecture, typeof(RadioButton)).Where(p=> ((RadioButton)p).Checked).ToList()[0];
            switch (v.Text)
            {
                case "单类结构":
                    break;
                case "简单三层":
                    break;
                case "工厂模式三层":
                    break;
                case "MVC模式":
                    break;
            }
            
        }
        #endregion

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void BindData()
        {
            if (DataBaseConfig != null)
            {

                this.txtConnstr.Text = DataBaseConfig.ConnStr;

                this.txtModelPath.Text =NamespaceConfig.ModelPath;
                this.txtDalPath.Text = NamespaceConfig.DalPath;
                this.txtBllPath.Text = NamespaceConfig.BllPath;

                this.txtModelSuffix.Text = NamespaceConfig.ModelSuffix;
                this.txtDalSuffix.Text = NamespaceConfig.DalSuffix;
                this.txtBllSuffix.Text = NamespaceConfig.BllSuffix;
            }
        }
        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            string databaseName = DataBaseConfig.DatabaseName;
            var tableNames = DatabaseInfo.Keys;

            TreeNode tn = new TreeNode
            {
                Text = databaseName,
                Name = "0"
            };
            treeView1.Nodes.Add(tn);
            foreach (var tableName in tableNames)
            {
                TreeNode tn1 = new TreeNode
                {
                    Text = tableName.ToString(),
                    Name = tableName.ToString()
                };
                tn.Nodes.Add(tn1);
            }
            treeView1.EndUpdate();
            treeView1.ExpandAll();
        }

        /// <summary>
        /// 创建三层代码
        /// </summary>
        /// <param name="columns">列信息</param>
        /// <param name="config">配置</param>
        /// <param name="className">生成数据访问代码的类名</param>
        private void CreateDbuCode(List<ColumnModel> columns, Config config)
        {
            if (rbModels.Checked)
            {
                //生成实体类
                BuilderModel builderModel = new BuilderModel(columns, config.Parameter.ModelPath, config.Parameter.ModelSuffix);
                txtCode.Text = builderModel.CreatModel();
            }
            if (rbModels12.Checked)
            {
                //生成实体类
                BuilderModel2 builderModel = new BuilderModel2(columns, config.Parameter.ModelPath, config.Parameter.ModelSuffix);
                txtCode.Text = builderModel.CreatModel();
            }
            if (rbDal.Checked)
            {
                //生成数据访问代码
                this.txtCode.Text = GenerateDal(columns, config.Parameter.ModelPath, config.Parameter.DalPath, config.Parameter.ModelSuffix, config.Parameter.DalSuffix);
            }
            if (rbBll.Checked)
            {
                //生成业务逻辑层代码
                BuilderBLL builderBll = new BuilderBLL(columns, config.Parameter.ModelPath, config.Parameter.DalPath, config.Parameter.BllPath, config.Parameter.ModelSuffix, config.Parameter.DalSuffix, config.Parameter.BllSuffix);
                txtCode.Text = builderBll.CreatBll(true, true, true, true, true, true, true);
            }
        }
        /// <summary>
        /// 生成DAL代码
        /// </summary>
        /// <param name="className">需要在反射中调用的类</param>
        /// <param name="columns">所要生成表的字段集合</param>
        /// <param name="modelpath">实体类命名空间</param>
        /// <param name="dalpath">数据类命名空间</param>
        /// <param name="modelSuffix">实体类名后缀</param>
        /// <param name="dalSuffix">数据类名后缀</param>
        /// <returns></returns>
        private string GenerateDal(List<ColumnModel> columns, string modelpath, string dalpath, string modelSuffix, string dalSuffix)
        {
            string className = "Win.Common.Builder.";
            switch (DataBaseConfig.ProviderName)
            {
                case "System.Data.SqlClient":
                    className += "BuilderDALForSqlServer";
                    break;
                case "System.Data.SQLite":
                    className += "BuilderDALForSqlite";
                    break;
                case "MySql.Data.MySqlClient":
                    className += "BuilderDALForSqlServer";
                    break;
                default:
                    className += "BuilderDALForSqlServer";
                    break;
            }
            //加载程序集(dll文件地址)，使用Assembly类   
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "Win.Common.dll");

            //获取类型，参数（名称空间+类）   
            Type type = assembly.GetType(className);

            object[] objArray = { columns, "db", modelpath, dalpath, modelSuffix, dalSuffix }; //构造函数参数

            //创建该对象的实例，object类型，参数（名称空间+类）
            object instance = assembly.CreateInstance(className, false, BindingFlags.Default, null, objArray, null, null);
            //设置Show_Str方法中的参数类型，Type[]类型；如有多个参数可以追加多个   
            Type[] paramsType = { Type.GetType("System.Boolean"), Type.GetType("System.Boolean"), Type.GetType("System.Boolean"), Type.GetType("System.Boolean"), Type.GetType("System.Boolean"), Type.GetType("System.Boolean"), Type.GetType("System.Boolean") };

            //设置方法中的参数值；如有多个参数可以追加多个
            Object[] paramsObj = { true, true, true, true, true, true, true };
            //执行方法
            object value = type.GetMethod("CreatDal", paramsType).Invoke(instance, paramsObj);
            return value.ToString();
        }
        /// <summary>
        /// 创建mvc代码
        /// </summary>
        /// <param name="columns">列信息</param>
        /// <param name="config">配置</param>
        private void CreateMvcCode(List<ColumnModel> columns, Config config)
        {
            if (this.rbModels2.Checked)
            {
                //生成实体类
                Win.Common.Builder.MVC.BuilderModel builderModel = new Win.Common.Builder.MVC.BuilderModel(columns, config.Parameter.ModelPath, config.Parameter.ModelSuffix);
                txtCode.Text = builderModel.CreatModel();
            }
            if (this.rbIDal2.Checked)
            {
                //生成数据层接口
                BuilderIDAL builderIdal = new BuilderIDAL(config.Parameter.DalPath, config.Parameter.ModelPath, columns);
                txtCode.Text = builderIdal.CreatIDAL();
            }
            if (this.rbDal2.Checked)
            {
                //生成数据层
                BuilderDAL builderDal = new BuilderDAL(config.Parameter.DalPath, config.Parameter.ModelPath, columns);
                txtCode.Text = builderDal.CreatIDAL();
            }
            if (this.rbIbll2.Checked)
            {
                //生成业务层接口
                BuilderIBLL builderIbll = new BuilderIBLL(config.Parameter.DalPath, config.Parameter.ModelPath, columns);
                txtCode.Text = builderIbll.CreatIBLL();
            }
            if (this.rbBll2.Checked)
            {
                //生成业务层
                Win.Common.Builder.MVC.BuilderBLL builderBll = new Win.Common.Builder.MVC.BuilderBLL(config.Parameter.DalPath, config.Parameter.ModelPath, config.Parameter.DalPath, columns);
                txtCode.Text = builderBll.CreatBLL();
            }
            if (this.rbContext2.Checked)
            {
                //生成数据上下文
            }
        }




        private void SetDatabaseInfo()
        {

            System.Serialization.BinaryFormatterHelper.SerilizeToFile(DatabaseInfo,System.IO.Path.Combine(System.Environment.CurrentDirectory,"App_Data\\TempData","database.dat"));
        }

        private Hashtable GetDatabaseInfo()
        {
            return System.Serialization.BinaryFormatterHelper.DeserializeForFile<Hashtable>(System.IO.Path.Combine(System.Environment.CurrentDirectory, "App_Data\\TempData", "database.dat"));
        }

        private void Write()
        {
            Hashtable hashtable = GetDatabaseInfo();
            foreach (string key in hashtable.Keys)
            {
                //生成实体类
                Win.Common.Builder.MVC.BuilderModel builderModel = new Win.Common.Builder.MVC.BuilderModel((List<ColumnModel>)hashtable[key], Config.Parameter.ModelPath, Config.Parameter.ModelSuffix);
                string codeText = builderModel.CreatModel();
                System.FileHelper.WriteFile("D\\11\\" + key + ".cs", codeText);
            }
            
        }
    }
}
