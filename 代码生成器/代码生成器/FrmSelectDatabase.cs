﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 代码生成器
{
    public partial class FrmSelectDatabase : Form
    {
        public FrmSelectDatabase()
        {
            InitializeComponent();
        }
        private void FrmSelectDatabase_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 下一步按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (rbSqlServer.Checked)
            {
                FrmConnServer fcs = new FrmConnServer();
                fcs.ShowDialog(this.Owner);
                fcs.Dispose();
            }
            if (rbSqlite.Checked)
            {
                FrmConnSqlite fcs = new FrmConnSqlite();
                fcs.ShowDialog(this.Owner);
                fcs.Dispose();
            }
            
            this.Dispose();
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
