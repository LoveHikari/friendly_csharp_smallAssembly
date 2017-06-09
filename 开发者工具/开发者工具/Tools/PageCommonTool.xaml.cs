using System;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace 开发者工具.Tools
{
    /// <summary>
    /// PageCommonTool.xaml 的交互逻辑
    /// </summary>
    public partial class PageCommonTool : Page
    {
        public PageCommonTool()
        {
            InitializeComponent();
        }

        //#region 事件

        //#region json格式化
        /// <summary>
        /// 格式化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJsonFormat_Click(object sender, RoutedEventArgs e)
        {
            this.txtJsonNew.Text = NewtonsoftJsonHelper.ConvertJsonString(this.txtJsonOld.Text);
        }
        /// <summary>
        /// 复制结果按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJsonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(this.txtJsonNew.Text);
        }

        //#endregion

        //#region UrlEncode
        ///// <summary>
        ///// 编码按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnUrlEncode_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtUrlEncode.Text = Uri.EscapeDataString(this.txtUrlDecode.Text);
        //}
        ///// <summary>
        ///// 解码按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnUrlDecode_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtUrlDecode.Text = Uri.UnescapeDataString(this.txtUrlEncode.Text);
        //}


        //#endregion

        //#region HtmlEncode

        ///// <summary>
        ///// 编码按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnHtmlEncode_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtHtmlEncode.Text = HttpUtility.HtmlEncode(this.txtHtmlDecode.Text);
        //}

        ///// <summary>
        ///// 解码按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnHtmlDecode_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtHtmlDecode.Text = HttpUtility.HtmlDecode(this.txtHtmlEncode.Text);
        //}



        //#endregion

        //#region MD5
        ///// <summary>
        ///// MD5按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnMd5Encode_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtMd5New.Text = rb16bit.IsChecked == true ? Common.DEncryptHelper.MD5Encrypt16(this.txtJsonOld.Text, cbMD5Encoding.SelectedItem.ToString()) : Common.DEncryptHelper.MD5Encrypt32(this.txtJsonOld.Text, cbMD5Encoding.SelectedItem.ToString());
        //}


        //#endregion

        //#region Base64

        ///// <summary>
        ///// 加密按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnBase64Encode_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtBase64Encode.Text = Convert.ToBase64String(Encoding.GetEncoding(cbBase64Encoding.SelectedItem.ToString()).GetBytes(this.txtBase64Decode.Text));
        //}
        ///// <summary>
        ///// 解密按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnBase64Decode_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtBase64Decode.Text = Encoding.GetEncoding(cbBase64Encoding.SelectedItem.ToString()).GetString(Convert.FromBase64String(this.txtBase64Encode.Text));
        //}

        //#endregion

        //#region GUID

        //private void btnGenerateGuid_Click(object sender, RoutedEventArgs e)
        //{
        //    txtGuid.Text = System.Guid.NewGuid().ToString();
        //}



        //#endregion

        //#region 全角半角

        ///// <summary>
        ///// 半转全按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnToSbc_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtSbc.Text = Common.StringHelper.ToSbc(this.txtDbc.Text);
        //}
        ///// <summary>
        ///// 全转半
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnToDbc_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtDbc.Text = Common.StringHelper.ToDbc(this.txtSbc.Text);
        //}

        //#endregion

        //#region 大小写转换

        ///// <summary>
        ///// 转大写按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnToUpper_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtUpper.Text = this.txtLower.Text.ToUpper();
        //}
        ///// <summary>
        ///// 转小写
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnToLower_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtLower.Text = this.txtUpper.Text.ToLower();
        //}

        //#endregion

        //#region Unix时间戳

        ///// <summary>
        ///// 日期转时间戳
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnToTimestamp_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtUnixTimestamp.Text = Common.DateTimeHelper.ConvertDateTimeInt(DateTime.Parse(this.txtTime.Text)).ToString();
        //}
        ///// <summary>
        ///// 时间戳转日期
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnToTime_Click(object sender, RoutedEventArgs e)
        //{
        //    this.txtTime.Text = Common.DateTimeHelper.ConvertDateTime(this.txtUnixTimestamp.Text).ToString("yyyy-MM-dd HH:mm:ss");
        //}

        //#endregion

        //#region 字符长度

        //private void btnCompute_Click(object sender, RoutedEventArgs e)
        //{
        //    txtStr2.Text = $"字符长度：{txtStr1.Text.Length}";
        //}

        //#endregion

        //#endregion
    }
}
