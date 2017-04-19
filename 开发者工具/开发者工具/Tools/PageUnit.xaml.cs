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
using Win.Common;

namespace 开发者工具.Tools
{
    /// <summary>
    /// PageUnit.xaml 的交互逻辑
    /// </summary>
    public partial class PageUnit : Page
    {
        public PageUnit()
        {
            InitializeComponent();
        }

        #region 进制换算

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            Button btnCal = (Button)sender;
            switch (btnCal.Tag.ToString())
            {
                case "10":
                    this.txt2.Text = ConvertHelper.ConvertBase(this.txt10.Text, 10, 2);
                    this.txt8.Text = ConvertHelper.ConvertBase(this.txt2.Text, 10, 8);
                    this.txt16.Text = ConvertHelper.ConvertBase(this.txt8.Text, 10, 16);
                    break;
                case "2":
                    this.txt10.Text = ConvertHelper.ConvertBase(this.txt2.Text, 2, 10);
                    this.txt8.Text = ConvertHelper.ConvertBase(this.txt2.Text, 10, 8);
                    this.txt16.Text = ConvertHelper.ConvertBase(this.txt8.Text, 10, 16);
                    break;
                case "8":
                    this.txt10.Text = ConvertHelper.ConvertBase(this.txt8.Text, 8, 10);
                    this.txt2.Text = ConvertHelper.ConvertBase(this.txt10.Text, 10, 2);
                    this.txt16.Text = ConvertHelper.ConvertBase(this.txt8.Text, 10, 16);
                    break;
                case "16":
                    this.txt10.Text = ConvertHelper.ConvertBase(this.txt16.Text, 16, 10);
                    this.txt2.Text = ConvertHelper.ConvertBase(this.txt10.Text, 10, 2);
                    this.txt8.Text = ConvertHelper.ConvertBase(this.txt2.Text, 10, 8);
                    break;
            }
        }

        #endregion

        #region 时间换算

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalTime_Click(object sender, RoutedEventArgs e)
        {
            Button btnCal = (Button)sender;
            switch (btnCal.Tag.ToString())
            {
                case "day":
                    this.txtHour.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24, 4).ToString();
                    this.txtMinute.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60, 4).ToString();
                    this.txtSecond.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60 * 60, 4).ToString();
                    this.txtMillisecond.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60 * 60 * 1000, 4).ToString();
                    break;
                case "hour":
                    this.txtDay.Text = Math.Round(Decimal.Parse(this.txtHour.Text) / 24, 4).ToString();
                    this.txtMinute.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60, 4).ToString();
                    this.txtSecond.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60 * 60, 4).ToString();
                    this.txtMillisecond.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60 * 60 * 1000, 4).ToString();
                    break;
                case "minute":
                    this.txtDay.Text = Math.Round(Decimal.Parse(this.txtMinute.Text) / 60 / 24, 4).ToString();
                    this.txtHour.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24, 4).ToString();
                    this.txtSecond.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60 * 60, 4).ToString();
                    this.txtMillisecond.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60 * 60 * 1000, 4).ToString();
                    break;
                case "second":
                    this.txtDay.Text = Math.Round(Decimal.Parse(this.txtSecond.Text) / 60 / 60 / 24, 4).ToString();
                    this.txtHour.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24, 4).ToString();
                    this.txtMinute.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60, 4).ToString();
                    this.txtMillisecond.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60 * 60 * 1000, 4).ToString();
                    break;
                case "millisecond":
                    this.txtDay.Text = Math.Round(Decimal.Parse(this.txtMillisecond.Text) / 1000 / 60 / 60 / 24, 4).ToString();
                    this.txtHour.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24, 4).ToString();
                    this.txtMinute.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60, 4).ToString();
                    this.txtSecond.Text = Math.Round(Decimal.Parse(this.txtDay.Text) * 24 * 60 * 60, 4).ToString();
                    break;
            }
        }

        #endregion

    }
}
