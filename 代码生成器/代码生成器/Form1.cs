using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private string _providerName;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _providerName = ConfigHelper.Instance.ProviderName;
            if (System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "config.ini")))
            {
                InitTreeView();
            }
            

            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;

            txtConnstr.Text = ConfigHelper.Instance.Connstr;
            txtModelPath.Text = ConfigHelper.Instance.ModelPath;
            txtDalPath.Text = ConfigHelper.Instance.DalPath;
            txtBllPath.Text = ConfigHelper.Instance.BllPath;

            txtModelSuffix.Text = ConfigHelper.Instance.ModelSuffix;
            txtDalSuffix.Text = ConfigHelper.Instance.DalSuffix;
            txtBllSuffix.Text = ConfigHelper.Instance.BllSuffix;
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
                ConfigHelper configHelper = new ConfigHelper();
            }
            
        }

        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            string databaseName = ConfigHelper.Instance.DatabaseName;
            DataTable dt;
            switch (_providerName)
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
            switch (ConfigHelper.Instance.ProviderName)
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

            string modelSuffix = this.txtBllSuffix.Text;
            string dalSuffix = this.txtBllSuffix.Text;
            string bllSuffix = this.txtBllSuffix.Text;

            string tableName = treeView1.SelectedNode.Name;


            List<ColumnModel> columns = new List<ColumnModel>();
            switch (ConfigHelper.Instance.ProviderName)
            {
                case "System.Data.SqlClient":
                    columns = DBUtility.SqlServerBll.GetTableColumnInfo(tableName);
                    break;
                case "System.Data.SQLite":
                    columns = DBUtility.SQLiteBll.GetTableColumnInfo(tableName);
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
                BuilderDAL builderDal = new BuilderDAL(columns, "SqlHelper.Instance", modelpath, dalpath, modelSuffix, dalSuffix);
                txtCode.Text = builderDal.CreatDal(true, true, true, true, true, true, true);
            }
            if (rbBll.Checked)
            {
                //生成业务逻辑层代码
                BuilderBLL builderBll = new BuilderBLL(columns, modelpath, dalpath, bllpath, modelSuffix, dalSuffix, bllSuffix);
                txtCode.Text = builderBll.CreatBll(true, true, true, true, true, true, true);
            }
            tabControl1.SelectedIndex = 1;
            ConfigHelper.Instance.WriteConfig("namespaceConfig", "modelpath", txtModelPath.Text);
            ConfigHelper.Instance.WriteConfig("namespaceConfig", "dalpath", txtDalPath.Text);
            ConfigHelper.Instance.WriteConfig("namespaceConfig", "bllpath", txtBllPath.Text);

            ConfigHelper.Instance.WriteConfig("namespaceConfig", "modelSuffix", txtModelSuffix.Text);
            ConfigHelper.Instance.WriteConfig("namespaceConfig", "dalSuffix", txtDalSuffix.Text);
            ConfigHelper.Instance.WriteConfig("namespaceConfig", "bllSuffix", txtBllSuffix.Text);
        }

        #endregion
    }
}
