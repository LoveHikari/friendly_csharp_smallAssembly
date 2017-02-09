using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Builder;
using Common;
using Model;

namespace 代码生成器
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "config.ini")))
            {
                InitTreeView();
            }


            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            ConfigHelper configHelper = new ConfigHelper();
            txtConnstr.Text = configHelper.Connstr;
            txtModelPath.Text = configHelper.ModelPath;
            txtDalPath.Text = configHelper.DalPath;
            txtBllPath.Text = configHelper.BllPath;

            txtModelSuffix.Text = configHelper.ModelSuffix;
            txtDalSuffix.Text = configHelper.DalSuffix;
            txtBllSuffix.Text = configHelper.BllSuffix;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        #region 事件

        /// <summary>
        /// 新增服务器注册 点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnAddServer_Click(object sender, EventArgs e)
        {
            FrmSelectDatabase fsd = new FrmSelectDatabase();
            fsd.ShowDialog(this);
            fsd.Dispose();
            if (System.IO.File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "config.ini")))
            {
                InitTreeView();
            }

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

            ConfigHelper configHelper = new ConfigHelper();
            switch (configHelper.ProviderName)
            {
                case "System.Data.SqlClient":
                    dt = DBUtility.SqlServerBll.GetColumnTable(tableName);
                    break;
                case "System.Data.SQLite":
                    dt = DBUtility.SQLiteBll.GetColumnTable(tableName);
                    break;
            }

            dataGridView1.DataSource = dt;

            List<string> identityKeyList = (from p in dt.AsEnumerable()
                                            where p.Field<string>("主键") == "√"
                                            select p.Field<string>("字段名")).ToList();
            cbIdentityKey.DataSource = identityKeyList;



        }
        /// <summary>
        /// 生成按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCode_Click(object sender, EventArgs e)
        {
            string modelpath = this.txtModelPath.Text;
            string dalpath = this.txtDalPath.Text;
            string bllpath = this.txtBllPath.Text;

            string modelSuffix = this.txtModelSuffix.Text;
            string dalSuffix = this.txtDalSuffix.Text;
            string bllSuffix = this.txtBllSuffix.Text;

            string tableName = treeView1.SelectedNode.Name;

            ConfigHelper configHelper = new ConfigHelper();
            List<ColumnModel> columns;
            string className = "Builder.";
            switch (configHelper.ProviderName)
            {
                case "System.Data.SqlClient":
                    columns = DBUtility.SqlServerBll.GetTableColumnInfo(tableName);
                    className += "BuilderDALForSqlServer";
                    break;
                case "System.Data.SQLite":
                    columns = DBUtility.SQLiteBll.GetTableColumnInfo(tableName);
                    className += "BuilderDALForSqlite";
                    break;
                default:
                    columns = DBUtility.SqlServerBll.GetTableColumnInfo(tableName);
                    className += "BuilderDALForSqlServer";
                    break;
            }

            if (rbModel.Checked)
            {
                //生成实体类
                BuilderModel builderModel = new BuilderModel(columns, modelpath, modelSuffix);
                txtCode.Text = builderModel.CreatModel();
            }
            if (rbDal.Checked)
            {
                //生成数据访问代码
                this.txtCode.Text = GenerateDal(className, columns, modelpath, dalpath, modelSuffix, dalSuffix);
            }
            if (rbBll.Checked)
            {
                //生成业务逻辑层代码
                BuilderBLL builderBll = new BuilderBLL(columns, modelpath, dalpath, bllpath, modelSuffix, dalSuffix, bllSuffix);
                txtCode.Text = builderBll.CreatBll(true, true, true, true, true, true, true);
            }

            tabControl1.SelectedIndex = 1;

            configHelper.ModelPath = this.txtModelPath.Text;
            configHelper.DalPath = this.txtDalPath.Text;
            configHelper.BllPath = this.txtBllPath.Text;

            configHelper.ModelSuffix = this.txtModelSuffix.Text;
            configHelper.DalSuffix = this.txtDalSuffix.Text;
            configHelper.BllSuffix = this.txtBllSuffix.Text;
            configHelper.WriteConfig();
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
        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            ConfigHelper configHelper = new ConfigHelper();
            string databaseName = configHelper.DatabaseName;
            string providerName = configHelper.ProviderName;
            DataTable dt;
            switch (providerName)
            {
                case "System.Data.SQLite":
                    dt = DBUtility.SQLiteBll.GetAllTable();
                    break;
                default:
                    dt = DBUtility.SqlServerBll.GetAllTable();
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
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "Builder.dll");

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
        #endregion
        
    }
}
