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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 开发者工具.Tools
{
    /// <summary>
    /// PageEncrypt.xaml 的交互逻辑
    /// </summary>
    public partial class PageEncrypt : Page
    {
        public PageEncrypt()
        {
            InitializeComponent();
        }

        #region MD5
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMd5_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)this.cbMD5Encoding.SelectedItem;
            this.txtDestMd5.Text = rb16.IsChecked == true ? Win.Common.DEncryptHelper.MD5Encrypt16(this.txtSourceMd5.Text, tb.Text) : Win.Common.DEncryptHelper.MD5Encrypt32(this.txtSourceMd5.Text, tb.Text);
        }

        #endregion

        #region Base64

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBase64Encode_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)this.cbBase64Encoding.SelectedItem;
            this.txtDestBase64.Text = Convert.ToBase64String(Encoding.GetEncoding(tb.Text).GetBytes(this.txtSourceBase64.Text));
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBase64Decode_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)this.cbBase64Encoding.SelectedItem;
            this.txtSourceBase64.Text = Encoding.GetEncoding(tb.Text).GetString(Convert.FromBase64String(this.txtDestBase64.Text));
        }

        #endregion

    }
}
