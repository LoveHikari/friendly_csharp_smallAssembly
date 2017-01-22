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
using Common;

namespace 代码生成器
{
    /// <summary>
    /// 连接到服务器窗口
    /// </summary>
    public partial class FrmConnServer : Form
    {
        public FrmConnServer()
        {
            InitializeComponent();
        }

        private void FrmConnServer_Load(object sender, EventArgs e)
        {
            cbDatabase.Enabled = false;
            txtServerName.Text = ConfigHelper.Instance.ServerName;
            txtUid.Text = ConfigHelper.Instance.Uid;
            txtPwd.Text = ConfigHelper.Instance.Pwd;
        }
        /// <summary>
        /// 连接/测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            string cooStr = $"server={txtServerName.Text};Database=master;uid={txtUid.Text};pwd={txtPwd.Text};";

            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "connStr", cooStr);
            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "providerName", "System.Data.SqlClient");
            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "serverName", txtServerName.Text);
            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "uid", txtUid.Text);
            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "pwd", txtPwd.Text);
            DataTable dt;
            try
            {
                dt = DBUtility.SqlServerBll.GetAllDatabase();
            }
            catch (SqlException se)
            {
                MessageBox.Show("数据库连接错误！" + se.Message);
                return;
            }
            cbDatabase.Enabled = true;
            cbDatabase.DataSource = (from p in dt.AsEnumerable() select p.Field<string>("name")).ToArray();

            cbDatabase.SelectedIndex = 0;
            btnTest.Enabled = false;
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            string cooStr = $"server={txtServerName.Text};Database={cbDatabase.SelectedItem};uid={txtUid.Text};pwd={txtPwd.Text};";
            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "connStr", cooStr);
            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "databaseName", cbDatabase.SelectedItem.ToString());
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
