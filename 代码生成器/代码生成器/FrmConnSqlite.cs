using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace 代码生成器
{
    public partial class FrmConnSqlite : Form
    {
        public FrmConnSqlite()
        {
            InitializeComponent();
            rbDatabaseFile.Click += radioButton_Click;
            rbConnStr.Click += radioButton_Click;

            txtDatabaseFile.TextChanged += textBox_TextChanged;
            txtPwd.TextChanged += textBox_TextChanged;
        }

        private void FrmConnSqlite_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 确定按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append($"Data Source={txtDatabaseFile.Text};");
            //if (txtPwd.Text != "")
            //{
            //    sb.Append($"Password={txtPwd.Text};");
            //}
            //sb.Append("Pooling=true;FailIfMissing=false;");

            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "connStr", this.txtConnStr.Text);
            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "databaseName", txtDatabaseFile.Text);
            ConfigHelper.Instance.WriteConfig("dataBaseConfig", "providerName", "System.Data.SQLite");
            this.Close();
        }
        /// <summary>
        /// 取消按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 单选框点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_Click(object sender, EventArgs e)
        {
            string rbName = ((RadioButton)sender).Name;
            if (rbName == rbDatabaseFile.Name)
            {
                rbDatabaseFile.Checked = true;
                txtDatabaseFile.Enabled = true;
                txtPwd.Enabled = true;

                rbConnStr.Checked = false;
                txtConnStr.Enabled = false;
            }
            if (rbName == rbConnStr.Name)
            {
                rbConnStr.Checked = true;
                txtConnStr.Enabled = true;

                rbDatabaseFile.Checked = false;
                txtDatabaseFile.Enabled = false;
                txtPwd.Enabled = false;
            }
        }
        /// <summary>
        /// 选择按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files (*.*)|*.*";

            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtDatabaseFile.Text = openFileDialog1.FileName;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (txtDatabaseFile.Text != "")
            {
                sb.Append($"Data Source={txtDatabaseFile.Text};");
            }
            if (txtPwd.Text != "")
            {
                sb.Append($"Password={txtPwd.Text};");
            }
            sb.Append("Pooling=true;FailIfMissing=false;");
            txtConnStr.Text = sb.ToString();
        }

        private void txtDatabaseFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                txtDatabaseFile.Text = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            }
        }
    }
}

