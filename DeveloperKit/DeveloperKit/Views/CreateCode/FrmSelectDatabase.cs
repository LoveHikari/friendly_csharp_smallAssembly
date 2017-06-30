﻿using System;
using System.Windows.Forms;

namespace DeveloperKit.Views.CreateCode
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.rbSqlClient.Checked)
            {
                FrmSqlClient f = new FrmSqlClient();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
                f.Dispose();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
