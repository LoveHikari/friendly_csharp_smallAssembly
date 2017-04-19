using System;
using System.Text;

namespace Win.Common
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// 向此实例追加指定字符串的副本。
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="spaceNum">空格数</param>
        /// <param name="text">要追加的字符串</param>
        /// <returns></returns>
        public static StringBuilder AppendSpace(this StringBuilder sb,int spaceNum, string text)
        {
            sb.Append(Space(spaceNum));
            sb.Append(text);
            return sb;
        }
        /// <summary>
        /// 将后面跟有默认行终止符的指定字符串的副本追加到当前 StringBuilder 对象的末尾
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="spaceNum">空格数</param>
        /// <param name="text">要追加的字符串</param>
        /// <returns></returns>
        public static StringBuilder AppendSpaceLine(this StringBuilder sb, int spaceNum, string text)
        {
            sb.Append(Space(spaceNum));
            sb.AppendLine(text);
            return sb;
        }
        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="strchar">要删除的字符</param>
        /// <param name="sc">大小写排序规则</param>
        /// <returns></returns>
        public static StringBuilder DelLastChar(this StringBuilder sb, string strchar, StringComparison sc = StringComparison.CurrentCulture)
        {
            string str = sb.ToString();
            int length = str.LastIndexOf(strchar,sc);
            if (length <= 0)
                return sb;
            sb.Clear().Append(str.Substring(0, length));
            return sb;
        }

        private static string Space(int spaceNum)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < spaceNum; i++)
                stringBuilder.Append(" ");
            return stringBuilder.ToString();
        }
    }
}