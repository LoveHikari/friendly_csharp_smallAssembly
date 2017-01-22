using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class StringHelper
    {
        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <param name="culture">一个对象，用于提供区域性特定的大小写规则</param>
        /// <returns></returns>
        public static string ToFirstUpper(this string str, CultureInfo culture = null)
        {
            if (culture == null)
            {
                str = str.Substring(0, 1).ToUpper() + str.Substring(1);
            }
            else
            {
                str = str.Substring(0, 1).ToUpper(culture) + str.Substring(1);
            }
            return str;
            //s = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s)
        }

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="str"></param>
        /// <param name="culture">一个对象，用于提供区域性特定的大小写规则</param>
        /// <returns></returns>
        public static string ToFirstLower(this string str, CultureInfo culture = null)
        {
            if (culture == null)
            {
                str = str.Substring(0, 1).ToLower() + str.Substring(1);
            }
            else
            {
                str = str.Substring(0, 1).ToLower(culture) + str.Substring(1);
            }
            return str;
        }
        /// <summary>
        /// Pascal 规则,每个单词开头的字母大写(如 TestCounter)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToPascal(this string str)
        {
            if (str.IndexOf("_") > -1)
            {
                StringBuilder sb = new StringBuilder();
                string[] s = str.Split('_');
                foreach (string s1 in s)
                {
                    sb.Append(s1.ToFirstUpper());
                }
                str = sb.ToString();
            }
            else
            {
                str = str.ToFirstUpper();
            }
            
            return str;
        }
    }
}