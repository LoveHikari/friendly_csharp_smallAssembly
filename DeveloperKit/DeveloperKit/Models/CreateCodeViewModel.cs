using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using DeveloperKit.Command;

namespace DeveloperKit.Models
{
    public class CreateCodeViewModel : ViewModelBase
    {
        private readonly Win.Models.DataBaseConfig _dataBaseConfig;
        private readonly Win.Models.NamespaceConfig _namespaceConfig;

        #region 字段

        private string _connstr;
        private string _modelPath;
        private string _dalPath;
        private string _bllPath;
        private string _modelSuffix;
        private string _dalSuffix;
        private string _bllSuffix;

        #endregion

        #region 属性
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connstr { get => _connstr; set { _connstr = value; NotifyPropertyChanged("Connstr"); } }
        /// <summary>
        /// 实体类命名空间
        /// </summary>
        public string ModelPath { get => _modelPath; set { _modelPath = value; NotifyPropertyChanged("ModelPath"); } }
        /// <summary>
        /// 数据层命名空间
        /// </summary>
        public string DalPath { get => _dalPath; set { _dalPath = value; NotifyPropertyChanged("DalPath"); } }
        /// <summary>
        /// 业务层命名空间
        /// </summary>
        public string BllPath { get => _bllPath; set { _bllPath = value; NotifyPropertyChanged("BllPath"); } }
        /// <summary>
        /// 实体类名后缀
        /// </summary>
        public string ModelSuffix { get => _modelSuffix; set { _modelSuffix = value; NotifyPropertyChanged("ModelSuffix"); } }
        /// <summary>
        /// 数据层类名后缀
        /// </summary>
        public string DalSuffix { get => _dalSuffix; set { _dalSuffix = value; NotifyPropertyChanged("DalSuffix"); } }
        /// <summary>
        /// 业务层类名后缀
        /// </summary>
        public string BllSuffix { get => _bllSuffix; set { _bllSuffix = value; NotifyPropertyChanged("BllSuffix"); } }

        #endregion

        public CreateCodeViewModel()
        {
            _dataBaseConfig = Win.Models.Config.DataConfig.Instance.GetDataBaseConfig();
            _namespaceConfig = Win.Models.Config.DataConfig.Instance.GetNamespaceConfig();

            if (_dataBaseConfig != null)
            {

                _connstr = _dataBaseConfig.ConnStr;

                _modelPath = _namespaceConfig.ModelPath;
                _dalPath = _namespaceConfig.DalPath;
                _bllPath = _namespaceConfig.BllPath;

                _modelSuffix = _namespaceConfig.ModelSuffix;
                _dalSuffix = _namespaceConfig.DalSuffix;
                _bllSuffix = _namespaceConfig.BllSuffix;
            }
        }
        /// <summary>
        /// 刷新按钮单击
        /// </summary>
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand<object>((obj) =>
                {
                    TreeView treeView1 = (TreeView)obj;
                    InitTreeView(treeView1);
                });
            }
        }


        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitTreeView(TreeView treeView1)
        {
            treeView1.Items.Clear();
            treeView1.BeginInit();
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
            TreeViewItem item = new TreeViewItem()
            {
                Header = databaseName,
                Name = "parentNode"
            };
            item.IsExpanded = true;
            treeView1.Items.Add(item);
            foreach (DataRow row in dt.Rows)
            {
                TreeViewItem tn1 = new TreeViewItem
                {
                    Header = row["TABLE_NAME"].ToString(),
                    Name = row["TABLE_NAME"].ToString()
                };
                item.Items.Add(tn1);
            }
            treeView1.EndInit();
        }
    }
}