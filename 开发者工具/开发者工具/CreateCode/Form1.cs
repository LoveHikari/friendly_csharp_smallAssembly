using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win.Models;
using 开发者工具.CreateCode.Models;

namespace 开发者工具.CreateCode
{
    public partial class Form1 : Form
    {
        private readonly Win.DAL.DataBaseConfigRepository _dataBaseConfigRepository;
        private readonly Win.DAL.NamespaceConfigRepository _namespaceConfigRepository;

        private readonly Win.Models.DataBaseConfig _dataBaseConfig;
        private readonly Win.Models.NamespaceConfig _namespaceConfig;

        public Form1()
        {
            InitializeComponent();

            _dataBaseConfigRepository = new Win.DAL.DataBaseConfigRepository();
            _namespaceConfigRepository = new Win.DAL.NamespaceConfigRepository();

            _dataBaseConfig = _dataBaseConfigRepository.Find(dc => dc.Id == 1);
            _namespaceConfig = _namespaceConfigRepository.Find(nc => nc.Id == 1);
        }

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

            switch (_dataBaseConfig.ProviderName)
            {
                case "System.Data.SqlClient":
                    dt = Win.DAL.BLL.SqlServerBll.Instance.GetColumnTable(tableName);
                    break;
                case "System.Data.SQLite":
                    dt = Win.DAL.BLL.SQLiteBll.GetColumnTable(tableName);
                    break;
                case "MySql.Data.MySqlClient":
                    dt = Win.DAL.BLL.MySqlBll.Instance.GetColumnTable(_dataBaseConfig.DatabaseName, tableName);
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
                BindData();
                InitTreeView();
            }
            fsd.Dispose();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void BindData()
        {
            if (_dataBaseConfig != null)
            {

                this.txtConnstr.Text = _dataBaseConfig.ConnStr;

                this.txtModelPath.Text = _namespaceConfig.ModelPath;
                this.txtDalPath.Text = _namespaceConfig.DalPath;
                this.txtBllPath.Text = _namespaceConfig.BllPath;

                this.txtModelSuffix.Text = _namespaceConfig.ModelSuffix;
                this.txtDalSuffix.Text = _namespaceConfig.DalSuffix;
                this.txtBllSuffix.Text = _namespaceConfig.BllSuffix;
            }
        }
        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            string databaseName = _dataBaseConfig.DatabaseName;
            string providerName = _dataBaseConfig.ProviderName;
            DataTable dt;
            switch (providerName)
            {
                case "System.Data.SQLite":
                    dt = Win.DAL.BLL.SQLiteBll.GetAllTable();
                    break;
                case "MySql.Data.MySqlClient":
                    dt = Win.DAL.BLL.MySqlBll.Instance.GetAllTable();
                    break;
                default:
                    dt = Win.DAL.BLL.SqlServerBll.Instance.GetAllTable();
                    break;
            }
            TreeNode tn = new TreeNode
            {
                Text = databaseName,
                Name = "0"
            };
            treeView1.Nodes.Add(tn);
            foreach (DataRow row in dt.Rows)
            {
                TreeNode tn1 = new TreeNode
                {
                    Text = row["TABLE_NAME"].ToString(),
                    Name = row["TABLE_NAME"].ToString()
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
        private void CreateDbuCode(List<ColumnModel> columns, Config config,string className)
        {
            if (rbModels.Checked)
            {
                //生成实体类
                Builder.BuilderModel builderModel = new Builder.BuilderModel(columns, config.Parameter.ModelPath, config.Parameter.ModelSuffix);
                txtCode.Text = builderModel.CreatModel();
            }
            if (rbModels12.Checked)
            {
                //生成实体类
                Builder.BuilderModel2 builderModel = new Builder.BuilderModel2(columns, config.Parameter.ModelPath, config.Parameter.ModelSuffix);
                txtCode.Text = builderModel.CreatModel();
            }
            if (rbDal.Checked)
            {
                //生成数据访问代码
                this.txtCode.Text = GenerateDal(className, columns, config.Parameter.ModelPath, config.Parameter.DalPath, config.Parameter.ModelSuffix, config.Parameter.DalSuffix);
            }
            if (rbBll.Checked)
            {
                //生成业务逻辑层代码
                Builder.BuilderBLL builderBll = new Builder.BuilderBLL(columns, config.Parameter.ModelPath, config.Parameter.DalPath, config.Parameter.BllPath, config.Parameter.ModelSuffix, config.Parameter.DalSuffix, config.Parameter.BllSuffix);
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
        private string GenerateDal(string className, List<ColumnModel> columns, string modelpath, string dalpath, string modelSuffix, string dalSuffix)
        {

            //加载程序集(dll文件地址)，使用Assembly类   
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "开发者工具.exe");

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
                Builder.MVC.BuilderModel builderModel = new Builder.MVC.BuilderModel(columns, config.Parameter.ModelPath, config.Parameter.ModelSuffix);
                txtCode.Text = builderModel.CreatModel();
            }
            if (this.rbIDal2.Checked)
            {
                //生成数据层接口
                Builder.MVC.BuilderIDAL builderIdal = new Builder.MVC.BuilderIDAL(config.Parameter.DalPath, config.Parameter.ModelPath, columns);
                txtCode.Text = builderIdal.CreatIDAL();
            }
            if (this.rbDal2.Checked)
            {
                //生成数据层
                Builder.MVC.BuilderDAL builderDal = new Builder.MVC.BuilderDAL(config.Parameter.DalPath, config.Parameter.ModelPath, columns);
                txtCode.Text = builderDal.CreatIDAL();
            }
            if (this.rbIbll2.Checked)
            {
                //生成业务层接口
                Builder.MVC.BuilderIBLL builderIbll = new Builder.MVC.BuilderIBLL(config.Parameter.DalPath, config.Parameter.ModelPath, columns);
                txtCode.Text = builderIbll.CreatIBLL();
            }
            if (this.rbBll2.Checked)
            {
                //生成业务层
                Builder.MVC.BuilderBLL builderBll = new Builder.MVC.BuilderBLL(config.Parameter.DalPath, config.Parameter.ModelPath, config.Parameter.DalPath, columns);
                txtCode.Text = builderBll.CreatBLL();
            }
            if (this.rbContext2.Checked)
            {
                //生成数据上下文
            }
        }
        /// <summary>
        /// 刷新按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitTreeView();
        }
        /// <summary>
        /// 代码显示框按键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A) //按下Ctrl+A
            {
                ((TextBox)sender).SelectAll();
            }
        }
        /// <summary>
        /// 生成按钮单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCode_Click(object sender, EventArgs e)
        {
            Models.Config config = new Models.Config()
            {
                Operating = this.rbOld.Checked?"old":"new",
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
                Architecture = this.rbMvc.Checked?"mvc":(this.rbDbu.Checked?"3ceng":""),
                CodeType = "",
            };
            string tableName = treeView1.SelectedNode.Name;  //当前选中的数据表


            List<ColumnModel> columns;  //所有字段
            string className = "开发者工具.CreateCode.Builder.";
            switch (_dataBaseConfig.ProviderName)
            {
                case "System.Data.SqlClient":
                    columns = Win.DAL.BLL.SqlServerBll.Instance.GetTableColumnInfo(tableName);
                    className += "BuilderDALForSqlServer";
                    break;
                case "System.Data.SQLite":
                    columns = Win.DAL.BLL.SQLiteBll.GetTableColumnInfo(tableName);
                    className += "BuilderDALForSqlite";
                    break;
                case "MySql.Data.MySqlClient":
                    columns = Win.DAL.BLL.MySqlBll.Instance.GetTableColumnInfo(_dataBaseConfig.DatabaseName, tableName);
                    className += "BuilderDALForSqlServer";
                    break;
                default:
                    columns = Win.DAL.BLL.SqlServerBll.Instance.GetTableColumnInfo(tableName);
                    className += "BuilderDALForSqlServer";
                    break;
            }

            if (this.rbMvc.Checked)  //架构选择mvc模式
            {
                CreateMvcCode(columns, config);
            }
            else if(this.rbDbu.Checked)  //简单三层模式
            {
                CreateDbuCode(columns,config, className);
            }



            tabControl1.SelectedIndex = 1;

            _namespaceConfig.ModelPath = this.txtModelPath.Text;
            _namespaceConfig.DalPath = this.txtDalPath.Text;
            _namespaceConfig.BllPath = this.txtBllPath.Text;

            _namespaceConfig.ModelSuffix = this.txtModelSuffix.Text;
            _namespaceConfig.DalSuffix = this.txtDalSuffix.Text;
            _namespaceConfig.BllSuffix = this.txtBllSuffix.Text;
            _namespaceConfigRepository.Update(_namespaceConfig);
        }

        private void gbArchitectureRadioButton_Click(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton) sender;
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
    }
}
