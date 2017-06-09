using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Win.Common;

namespace 开发者工具.Tools
{
    /// <summary>
    /// PageEncode.xaml 的交互逻辑
    /// </summary>
    public partial class PageEncode : Page
    {
        public PageEncode()
        {
            InitializeComponent();
        }

        #region UrlEncode
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrlEncode_Click(object sender, RoutedEventArgs e)
        {
            this.txtDestUrl.Text = Uri.EscapeDataString(this.txtSourceUrl.Text);
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrlDecode_Click(object sender, RoutedEventArgs e)
        {
            this.txtSourceUrl.Text = Uri.UnescapeDataString(this.txtDestUrl.Text);
        }
        #endregion

        #region HtmlEncode

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHtmlEncode_Click(object sender, RoutedEventArgs e)
        {
            this.txtDestHtml.Text = HttpUtility.HtmlEncode(this.txtSourceHtml.Text);
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHtmlDecode_Click(object sender, RoutedEventArgs e)
        {
            this.txtSourceHtml.Text = HttpUtility.HtmlDecode(this.txtDestHtml.Text);
        }

        #endregion

        #region Unicode

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnicodeEncode_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)cbUnicode.SelectedItem;
            switch (tb.Text)
            {
                case "ASCII":
                    byte[] asciiArray = System.Text.Encoding.ASCII.GetBytes(this.txtSourceUnicode.Text);  //数组array为对应的ASCII数组     
                    string asciiStr = null;
                    for (int i = 0; i < asciiArray.Length; i++)
                    {
                        int code = (int)(asciiArray[i]);
                        asciiStr += "&#" + code + ";"; //字符串ASCIIstr2 为对应的ASCII字符串
                    }
                    this.txtDestUnicode.Text = asciiStr;
                    break;
                case "UTF-8":
                    byte[] utf8Array = System.Text.Encoding.UTF8.GetBytes(this.txtSourceUnicode.Text);
                    string utf8Str = null;
                    for (int i = 0; i < utf8Array.Length; i++)
                    {
                        int code = (int)(utf8Array[i]);
                        string str = ConvertHelper.ConvertBase(code.ToString(), 10, 16).PadLeft(4, '0');
                        utf8Str += "\\u" + str;
                    }
                    this.txtDestUnicode.Text = utf8Str;
                    break;
                case "Unicode":
                    byte[] unicodeArray = System.Text.Encoding.Unicode.GetBytes(this.txtSourceUnicode.Text);
                    string unicodeStr = null;
                    for (int i = 0; i < unicodeArray.Length; i++)
                    {
                        int code = (int)(unicodeArray[i]);
                        string str = ConvertHelper.ConvertBase(code.ToString(), 10, 16).PadLeft(4, '0');
                        unicodeStr += "\\u" + str;
                    }
                    this.txtDestUnicode.Text = unicodeStr;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnicodeDecode_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)cbUnicode.SelectedItem;
            switch (tb.Text)
            {
                case "ASCII":
                    string[] s = this.txtDestUnicode.Text.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    byte[] bytes = new byte[s.Length];
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i].IndexOf("&#", StringComparison.CurrentCultureIgnoreCase) != 0)
                        {
                            System.Windows.MessageBox.Show("格式错误!");
                            return;
                        }
                        bytes[i] = byte.Parse(s[i].TrimStart("&#".ToCharArray()));
                    }
                    this.txtSourceUnicode.Text = System.Text.Encoding.ASCII.GetString(bytes);
                    break;
                case "UTF-8":
                    string[] us = this.txtDestUnicode.Text.Split("\\u".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    byte[] ubytes = new byte[us.Length];
                    for (int i = 0; i < us.Length; i++)
                    {
                        ubytes[i] = byte.Parse(ConvertHelper.ConvertBase(us[i], 16, 10));
                    }
                    this.txtSourceUnicode.Text = System.Text.Encoding.UTF8.GetString(ubytes);
                    break;
                case "Unicode":
                    string[] ues = this.txtDestUnicode.Text.Split("\\u".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    byte[] uebytes = new byte[ues.Length];
                    for (int i = 0; i < ues.Length; i++)
                    {
                        uebytes[i] = byte.Parse(ConvertHelper.ConvertBase(ues[i], 16, 10));
                    }
                    this.txtSourceUnicode.Text = System.Text.Encoding.Unicode.GetString(uebytes);
                    break;
            }
        }

        #endregion

    }
}
