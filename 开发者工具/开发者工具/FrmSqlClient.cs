using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 开发者工具
{
    public partial class FrmSqlClient : Form
    {

        private readonly Win.Models.DataBaseConfig _dataBaseConfig;
        public FrmSqlClient()
        {
            InitializeComponent();

            _dataBaseConfig = Win.Models.Config.DataConfig.Instance.GetDataBaseConfig();
        }

        private void FrmSqlClient_Load(object sender, EventArgs e)
        {
            this.btnConfirm.DialogResult = DialogResult.OK;

            BindData();
        }
        /// <summary>
        /// 连接/测试按钮单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConn_Click(object sender, EventArgs e)
        {
            string connectionString = $"server={this.cbServerName.Text};Database=master;uid={this.txtUid.Text};pwd={this.txtPwd.Text};";
            var sqlServer = new Win.DAL.BLL.SqlServerBll(connectionString);
            DataTable dt = sqlServer.GetAllDatabase();
            this.cbDatabase.DataSource = dt;
            this.cbDatabase.ValueMember = "name";
            this.cbDatabase.DisplayMember = "name";
            this.cbDatabase.Enabled = true;

            this.btnConfirm.Enabled = true;
        }
        /// <summary>
        /// 确定按钮单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _dataBaseConfig.ConnStr = $"server={this.cbServerName.Text};Database={this.cbDatabase.Text};uid={this.txtUid.Text};pwd={this.txtPwd.Text}";
            _dataBaseConfig.DatabaseName = this.cbDatabase.Text;
            _dataBaseConfig.ProviderName = "System.Data.SqlClient";
            _dataBaseConfig.ServerName = this.cbServerName.Text;
            _dataBaseConfig.Uid = this.txtUid.Text;
            _dataBaseConfig.Pwd = this.txtPwd.Text;
            Win.Models.Config.DataConfig.Instance.SetDataBaseConfig(_dataBaseConfig);

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindData()
        {
            if (_dataBaseConfig == null)
            {
                this.cbServerName.SelectedText = "(local)";

                this.txtUid.Text = "sa";
            }
            else
            {
                this.cbServerName.SelectedText = _dataBaseConfig.ServerName;

                this.txtUid.Text = _dataBaseConfig.Uid;
                this.txtPwd.Text = _dataBaseConfig.Pwd;
            }
            string[] serverTypes = new[] { "SQL Server2012", "SQL Server2008", "SQL Server2005", "SQL Server2000" };
            this.cbServerType.DataSource = serverTypes;

            string[] authentication = new[] { "SQL Server 身份认证", "Windows 身份认证" };
            this.cbAuthentication.DataSource = authentication;

            string[] loadTable = new[] { "加载全部表：", "只加载表名中含有：", "不加载表名中含有：" };
            this.cbLoadTable.DataSource = loadTable;

            this.cbDatabase.Enabled = false;

            this.txtTableName.Visible = false;

            this.btnConfirm.Enabled = false;
        }

        

        

        
    }
}
