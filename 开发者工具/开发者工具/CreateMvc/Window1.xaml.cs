using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 开发者工具.CreateMvc
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择保存路径单击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            this.txtSaveDir.Text = dialog.SelectedPath.Trim();
        }

        /// <summary>
        /// 生成全部按钮单击发生时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            string dir = this.txtSaveDir.Text;
            if (dir.Trim() == "")
            {
                dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }
            //生成IDAL
            CreateIDAL(dir);
            //生成DAL
            CreateDAL(dir);
            //生成IBLL
            CreateIBLL(dir);
            //生成BLL
            CreateBLL(dir);
            System.Windows.MessageBox.Show("完成");
        }

        public void CreateIDAL(string dir)
        {
            string iDalPath = this.txtIdalPath.Text;
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template\\IBaseRepository.te");
            string s = DotNet.Utilities.FileHelper.ReadFile(filePath);
            s = s.Replace("${IdalPath}", iDalPath);
            filePath = System.IO.Path.Combine(dir, "IDAL\\IBaseRepository.cs");
            DotNet.Utilities.FileHelper.WriteFile(filePath, s);
        }

        public void CreateDAL(string dir)
        {
            string iDalPath = this.txtIdalPath.Text;
            string dalPath = this.txtDalPath.Text;
            string modelsPath = this.txtModelsPath.Text;
            string context = this.txtContext.Text;

            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template\\BaseRepository.te");
            string s = DotNet.Utilities.FileHelper.ReadFile(filePath);
            s = s.Replace("${IdalPath}", iDalPath).Replace("${DalPath}", dalPath);
            filePath = System.IO.Path.Combine(dir, "DAL\\BaseRepository.cs");
            DotNet.Utilities.FileHelper.WriteFile(filePath, s);

            filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template\\AppDbContext.te");
            s = DotNet.Utilities.FileHelper.ReadFile(filePath);
            s = s.Replace("${ModelsPath}", modelsPath).Replace("${DalPath}", dalPath).Replace("${Context}", context);
            filePath = System.IO.Path.Combine(dir, "DAL\\AppDbContext.cs");
            DotNet.Utilities.FileHelper.WriteFile(filePath, s);

            filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template\\ContextFactory.te");
            s = DotNet.Utilities.FileHelper.ReadFile(filePath);
            s = s.Replace("${DalPath}", dalPath).Replace("${Context}", context);
            filePath = System.IO.Path.Combine(dir, "DAL\\ContextFactory.cs");
            DotNet.Utilities.FileHelper.WriteFile(filePath, s);

            filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template\\RepositoryFactory.te");
            s = DotNet.Utilities.FileHelper.ReadFile(filePath);
            s = s.Replace("${DalPath}", dalPath).Replace("${Context}", context).Replace("${IdalPath}", iDalPath);
            filePath = System.IO.Path.Combine(dir, "DAL\\RepositoryFactory.cs");
            DotNet.Utilities.FileHelper.WriteFile(filePath, s);
        }

        public void CreateIBLL(string dir)
        {
            string iBllPath = this.txtIbllPath.Text;
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template\\IBaseService.te");
            string s = DotNet.Utilities.FileHelper.ReadFile(filePath);
            s = s.Replace("${IbllPath}", iBllPath);
            filePath = System.IO.Path.Combine(dir, "IBLL\\IBaseService.cs");
            DotNet.Utilities.FileHelper.WriteFile(filePath, s);
        }
        public void CreateBLL(string dir)
        {
            string iBllPath = this.txtIbllPath.Text;
            string iDalPath = this.txtIdalPath.Text;
            string bllPath = this.txtBllPath.Text;
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template\\BaseService.te");
            string s = DotNet.Utilities.FileHelper.ReadFile(filePath);
            s = s.Replace("${IbllPath}", iBllPath).Replace("${IdalPath}", iDalPath).Replace("${BllPath}", bllPath);
            filePath = System.IO.Path.Combine(dir, "BLL\\BaseService.cs");
            DotNet.Utilities.FileHelper.WriteFile(filePath, s);
        }
    }
}
