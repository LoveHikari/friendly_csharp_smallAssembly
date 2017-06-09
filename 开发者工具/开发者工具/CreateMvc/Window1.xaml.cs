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
using Win.Common;

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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtIdalPath.Text = "IDAL";  //数据接口命名空间
            this.txtDalPath.Text = "DAL";  //数据层命名空间
            this.txtIbllPath.Text = "IBLL";  //业务层接口命名空间
            this.txtBllPath.Text = "BLL";  //业务层命名空间
            this.txtModelsPath.Text = "Models";  //模型命名空间
            this.txtContext.Text = "AppContext";  //数据库连接字符串配置节名称
            this.txtSaveDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\MVC框架";  //保存路径
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
                dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\MVC框架";
            }
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            string dir2 = this.rbEf.IsChecked==true ? "EF" : "Linq";


            //生成IDAL
            CreateIDAL(dir,dir2);
            //生成DAL
            CreateDAL(dir, dir2);
            //生成IBLL
            CreateIBLL(dir, dir2);
            //生成BLL
            CreateBLL(dir, dir2);
            System.Windows.MessageBox.Show("完成");
        }

        public void CreateIDAL(string dir,string dir2)
        {
            string iDalPath = this.txtIdalPath.Text;
            
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template",dir2,"IBaseRepository.te");
            string s = FileHelper.ReadFile(filePath);
            s = s.Replace("${IdalPath}", iDalPath);
            filePath = System.IO.Path.Combine(dir, "IDAL\\IBaseRepository.cs");
            FileHelper.WriteFile(filePath, s);
        }

        public void CreateDAL(string dir, string dir2)
        {
            string iDalPath = this.txtIdalPath.Text;
            string dalPath = this.txtDalPath.Text;
            string modelsPath = this.txtModelsPath.Text;
            string context = this.txtContext.Text;

            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template", dir2, "BaseRepository.te");
            string s = FileHelper.ReadFile(filePath);
            s = s.Replace("${IdalPath}", iDalPath).Replace("${DalPath}", dalPath);
            filePath = System.IO.Path.Combine(dir, "DAL\\BaseRepository.cs");
            FileHelper.WriteFile(filePath, s);

            filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template", dir2, "AppDbContext.te");
            s = FileHelper.ReadFile(filePath);
            s = s.Replace("${ModelsPath}", modelsPath).Replace("${DalPath}", dalPath).Replace("${Context}", context);
            filePath = System.IO.Path.Combine(dir, "DAL\\AppDbContext.cs");
            FileHelper.WriteFile(filePath, s);

            filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template", dir2, "ContextFactory.te");
            s = FileHelper.ReadFile(filePath);
            s = s.Replace("${DalPath}", dalPath).Replace("${Context}", context);
            filePath = System.IO.Path.Combine(dir, "DAL\\ContextFactory.cs");
            FileHelper.WriteFile(filePath, s);

            filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template", dir2, "RepositoryFactory.te");
            s = FileHelper.ReadFile(filePath);
            s = s.Replace("${DalPath}", dalPath).Replace("${Context}", context).Replace("${IdalPath}", iDalPath);
            filePath = System.IO.Path.Combine(dir, "DAL\\RepositoryFactory.cs");
            FileHelper.WriteFile(filePath, s);
        }

        public void CreateIBLL(string dir, string dir2)
        {
            string iBllPath = this.txtIbllPath.Text;
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template", dir2, "IBaseService.te");
            string s = FileHelper.ReadFile(filePath);
            s = s.Replace("${IbllPath}", iBllPath);
            filePath = System.IO.Path.Combine(dir, "IBLL\\IBaseService.cs");
            FileHelper.WriteFile(filePath, s);
        }
        public void CreateBLL(string dir, string dir2)
        {
            string iBllPath = this.txtIbllPath.Text;
            string iDalPath = this.txtIdalPath.Text;
            string bllPath = this.txtBllPath.Text;
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "App_Data\\Template", dir2, "BaseService.te");
            string s = FileHelper.ReadFile(filePath);
            s = s.Replace("${IbllPath}", iBllPath).Replace("${IdalPath}", iDalPath).Replace("${BllPath}", bllPath);
            filePath = System.IO.Path.Combine(dir, "BLL\\BaseService.cs");
            FileHelper.WriteFile(filePath, s);
        }


    }
}
