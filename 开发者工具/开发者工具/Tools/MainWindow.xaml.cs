using System;
using System.Windows;
using System.Windows.Controls;

namespace 开发者工具.Tools
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region 事件

        private void Window_Closed(object sender, EventArgs e)
        {
            //Environment.Exit(Environment.ExitCode);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = (MenuItem) sender;
            string name = mi.Name;
            switch (name.Replace("MenuItem", ""))
            {
                case "实体生成":
                    frame1.Navigate(new Uri("PageEntityGeneration.xaml", UriKind.Relative));
                    break;
                case "编码解码":
                    frame1.Navigate(new Uri("Tools/PageEncode.xaml", UriKind.Relative));
                    break;
                case "加密解密":
                    frame1.Navigate(new Uri("Tools/PageEncrypt.xaml", UriKind.Relative));
                    break;
                case "字符转换":
                    frame1.Navigate(new Uri("Tools/PageTransfer.xaml", UriKind.Relative));
                    break;
                case "单位换算":
                    frame1.Navigate(new Uri("Tools/PageUnit.xaml", UriKind.Relative));
                    break;
                default:
                    frame1.Source = new Uri("PageCommonTool.xaml", UriKind.Relative);
                    break;
            }

            
        }

        

        #endregion


    }
}
