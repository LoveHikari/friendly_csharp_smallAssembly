using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class StringHelper
    {
        #region 全角半角转换
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToSbc(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }


        /// <summary> 转半角的函数(DBC case) </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDbc(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion
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