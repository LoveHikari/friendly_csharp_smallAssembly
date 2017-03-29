using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DBUtility;
using Models;

namespace 开发者工具.CreateCode
{
    /// <summary>
    /// 连接到服务器窗口
    /// </summary>
    public partial class FrmConnServer : Form
    {
        private DataBaseConfigRepository _dataBaseConfigRepository;

        public DataBaseConfig DataBaseConfig
        {
            get { return _dataBaseConfigRepository.Find(dc => dc.Id == 1); }

        }
        public FrmConnServer()
        {
            InitializeComponent();

            _dataBaseConfigRepository = new DataBaseConfigRepository();
        }

        private void FrmConnServer_Load(object sender, EventArgs e)
        {
            this.cbDatabase.Enabled = false;
            this.btnDetermine.Enabled = false;

            this.txtServerName.Text = DataBaseConfig?.ServerName;
            this.txtUid.Text = DataBaseConfig?.Uid;
            this.txtPwd.Text = DataBaseConfig?.Pwd;
        }
        /// <summary>
        /// 连接/测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {

            string cooStr = $"server={this.txtServerName.Text};Database=master;uid={this.txtUid.Text};pwd={this.txtPwd.Text};";
            DataBaseConfig.ConnStr = cooStr;
            DataBaseConfig.ProviderName = "System.Data.SqlClient";
            DataBaseConfig.ServerName = this.txtServerName.Text;
            DataBaseConfig.Uid = this.txtUid.Text;
            DataBaseConfig.Pwd = this.txtPwd.Text;
            _dataBaseConfigRepository.Update(DataBaseConfig);

            DataTable dt;
            try
            {
                dt = DBUtility.SqlServerBll.Instance.GetAllDatabase();
            }
            catch (SqlException se)
            {
                MessageBox.Show("数据库连接错误！" + se.Message);
                return;
            }
            
            this.cbDatabase.DataSource = (from p in dt.AsEnumerable() select p.Field<string>("name")).ToArray();

            this.cbDatabase.SelectedIndex = 0;
            this.cbDatabase.Enabled = true;
            this.btnTest.Enabled = false;
            this.btnDetermine.Enabled = true;

        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            string cooStr = $"server={txtServerName.Text};Database={cbDatabase.SelectedItem};uid={txtUid.Text};pwd={txtPwd.Text};";
            DataBaseConfig.ConnStr = cooStr;
            DataBaseConfig.DatabaseName = this.cbDatabase.SelectedItem.ToString();
            _dataBaseConfigRepository.Update(DataBaseConfig);
            this.Close();
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
