using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Win.Models;

/******************************************************************************************************************
 * 
 * 
 * 说　明： 类型转换(版本：Version1.0.0)
 * 作　者：YuXiaoWei
 * 日　期：2016/08/29
 * 修　改：
 * 参　考：http://www.csframework.com/archive/2/arc-2-20110317-1144.htm
 * 备　注：暂无...
 * 
 * 
 * ***************************************************************************************************************/
namespace Win.Common
{
    public class CodeCommon:System.CodeCommon
    {
        /// <summary>
        /// 获得主键列表
        /// </summary>
        /// <param name="fieldlist"></param>
        public static List<ColumnModel> GetPrimaryKeyList(List<ColumnModel> fieldlist)
        {
            List<ColumnModel> keyList = new List<ColumnModel>();
            foreach (ColumnModel field in fieldlist)
            {
                if (field.IsPrimaryKey)
                {
                    keyList.Add(field);
                }
            }
            return keyList;
        }

        /// <summary>
        /// 主键列表中是否有标识列
        /// </summary>
        /// <param name="Keys"></param>
        /// <returns></returns>
        public static bool IsHasIdentity(List<ColumnModel> Keys)
        {
            bool flag = false;
            if (Keys.Count > 0)
            {
                foreach (ColumnModel key in Keys)
                {
                    if (key.IsIdentity)
                        flag = true;
                }
            }
            return flag;
        }
    }
}