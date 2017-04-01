using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBUtility;
using Models;

namespace 开发者工具.CreateCode
{
    public partial class FrmConnMySQL : Form
    {
        private DataBaseConfigRepository _dataBaseConfigRepository;

        public DataBaseConfig DataBaseConfig
        {
            get { return _dataBaseConfigRepository.Find(dc => dc.Id == 1); }

        }

        public FrmConnMySQL()
        {
            InitializeComponent();

            _dataBaseConfigRepository = new DataBaseConfigRepository();
        }

        private void FrmConnMySQL_Load(object sender, EventArgs e)
        {
            this.btnDetermine.Enabled = false;

            this.txtServerName.Text = DataBaseConfig?.ServerName;
            this.txtUid.Text = DataBaseConfig?.Uid;
            this.txtPwd.Text = DataBaseConfig?.Pwd;
            this.txtPort.Text = "3306";
        }
        /// <summary>
        /// 测试连接按钮单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            string cooStr = $"Data Source='{this.txtServerName.Text}';Port={this.txtPort.Text};User Id='{this.txtUid.Text}';Password='{this.txtPwd.Text}';charset='utf8';pooling=true";
            DataBaseConfig.ConnStr = cooStr;
            DataBaseConfig.ProviderName = "MySql.Data.MySqlClient";
            DataBaseConfig.ServerName = this.txtServerName.Text;
            DataBaseConfig.Uid = this.txtUid.Text;
            DataBaseConfig.Pwd = this.txtPwd.Text;
            _dataBaseConfigRepository.Update(DataBaseConfig);

            DataTable dt;
            try
            {
                dt = DBUtility.BLL.MySqlBll.Instance.GetAllDatabase();
            }
            catch (SqlException se)
            {
                MessageBox.Show("数据库连接错误！" + se.Message);
                return;
            }

            this.cbDatabase.DataSource = (from p in dt.AsEnumerable() select p.Field<string>("Database")).ToArray();

            this.cbDatabase.SelectedIndex = 0;
            this.cbDatabase.Enabled = true;
            this.btnTest.Enabled = false;
            this.btnDetermine.Enabled = true;
        }
        /// <summary>
        /// 确定按钮单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            string cooStr = $"Database='{cbDatabase.SelectedItem}';Data Source='{this.txtServerName.Text}';Port={this.txtPort.Text};User Id='{this.txtUid.Text}';Password='{this.txtPwd.Text}';charset='utf8';pooling=true";
            DataBaseConfig.ConnStr = cooStr;
            DataBaseConfig.DatabaseName = this.cbDatabase.SelectedItem.ToString();
            _dataBaseConfigRepository.Update(DataBaseConfig);
            this.Close();
        }
        /// <summary>
        /// 取消按钮单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
