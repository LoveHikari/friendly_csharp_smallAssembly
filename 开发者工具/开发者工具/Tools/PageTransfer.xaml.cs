using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 开发者工具.Tools
{
    /// <summary>
    /// PageTransfer.xaml 的交互逻辑
    /// </summary>
    public partial class PageTransfer : Page
    {
        public PageTransfer()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtSourceUnix.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #region 全角半角

        /// <summary>
        /// 半转全
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetDbc_Click(object sender, RoutedEventArgs e)
        {
            this.txtDestDbc.Text = Common.StringHelper.ToSbc(this.txtSourceDbc.Text);
        }
        /// <summary>
        /// 全转半
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetDbcBack_Click(object sender, RoutedEventArgs e)
        {
            this.txtSourceDbc.Text = Common.StringHelper.ToDbc(this.txtDestDbc.Text);
        }


        #endregion

        #region 大小写转换

        /// <summary>
        /// 转大写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUpper_Click(object sender, RoutedEventArgs e)
        {
            this.txtDestUpper.Text = this.txtSourceUpper.Text.ToUpper();
        }
        /// <summary>
        /// 转小写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetLower_Click(object sender, RoutedEventArgs e)
        {
            this.txtDestUpper.Text = this.txtSourceUpper.Text.ToLower();
        }

        #endregion

        #region Unix时间戳

        /// <summary>
        /// 转时间戳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransUnix_Click(object sender, RoutedEventArgs e)
        {
            this.txtDestUnix.Text = Common.DateTimeHelper.ConvertDateTimeInt(DateTime.Parse(this.txtSourceUnix.Text)).ToString();
        }
        /// <summary>
        /// 转原日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransDate_Click(object sender, RoutedEventArgs e)
        {
            this.txtSourceUnix.Text = Common.DateTimeHelper.ConvertDateTime(this.txtDestUnix.Text).ToString("yyyy-MM-dd HH:mm:ss");
        }



        #endregion

        #region 字符长度

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetLen_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"[\u4E00-\u9FA5]");
            this.textBlock1.Text = $"字符长度：{this.txtSourceLen.Text.Length}，字节长度：{Encoding.Default.GetByteCount(this.txtSourceLen.Text)}，汉字数量：{regex.Matches(this.txtSourceLen.Text).Count}";
        }

        #endregion

        #region GUID

        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetGuid_Click(object sender, RoutedEventArgs e)
        {
            txtSourceGuid.Text = System.Guid.NewGuid().ToString();
        }

        #endregion

    }
}
