﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model;

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
namespace Common
{
    public class CodeCommon
    {
        /// <summary> 
        /// 将.NET数据类型（如：System.Int32）转换为C#类型（如：int） 
        /// </summary> 
        /// <param name="dotNetString">.NET数据类型</param> 
        /// <returns></returns> 
        public static string DotNetTypeToCSType(string dotNetString)
        {
            string[] dotNetTypes = { "system.boolean", "system.char","system.byte" ,"system.sbyte",
   "system.uint16","system.uint32","system.uint64","system.int16","system.int32","system.int64","system.single","system.double", "system.string"};

            string[] csTypes = {"bool", "char","byte" ,"sbyte","ushort","uint","ulong","short",
   "int","long","float","double", "string"};

            int i = Array.IndexOf(dotNetTypes, dotNetString.ToLower());
            if (i > -1)
            {
                return csTypes[i];
            }
            else
            {
                return dotNetString.ToLower();
            }

        }
        /// <summary> 
        /// 将SQLServer数据类型（如：varchar）转换为.Net类型（如：String） 
        /// </summary> 
        /// <param name="sqlTypeString">SQLServer数据类型</param> 
        /// <returns></returns> 
        public static string DbTypeToCS(string sqlTypeString)
        {
            string[] sqlTypeNames = { "int", "varchar","bit" ,"datetime","decimal","float","image","money",
   "ntext","nvarchar","smalldatetime","smallint","text","bigint","binary","char","nchar","numeric",
   "real","smallmoney", "sql_variant","timestamp","tinyint","uniqueidentifier","varbinary"};

            string[] dotNetTypes = {"int", "string","bool" ,"DateTime","Decimal","Double","Byte[]","Single",
   "string","string","DateTime","Int16","string","Int64","Byte[]","string","string","Decimal",
   "Single","Single", "Object","Byte[]","Byte","Guid","Byte[]"};
            int i = Array.IndexOf(sqlTypeNames, sqlTypeString.ToLower());
            if (i > -1)
            {
                return dotNetTypes[i];
            }
            else
            {
                return sqlTypeString.ToLower();
            }

        }
        /// <summary>
        /// 空格数量
        /// </summary>
        /// <param name="num">空格数量</param>
        /// <returns></returns>
        public static string Space(int num)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < num; ++index)
                stringBuilder.Append(" ");
            return stringBuilder.ToString();
        }
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
        /// <summary>
        /// sql server数据类型（如：varchar）转换为SqlDbType类型
        /// </summary>
        /// <param name="sqlTypeString"></param>
        /// <returns></returns>
        public static SqlDbType SqlTypeString2SqlType(string sqlTypeString)
        {
            SqlDbType dbType = SqlDbType.Variant;//默认为Object

            switch (sqlTypeString)
            {
                case "int":
                    dbType = SqlDbType.Int;
                    break;
                case "varchar":
                    dbType = SqlDbType.VarChar;
                    break;
                case "bit":
                    dbType = SqlDbType.Bit;
                    break;
                case "datetime":
                    dbType = SqlDbType.DateTime;
                    break;
                case "decimal":
                    dbType = SqlDbType.Decimal;
                    break;
                case "float":
                    dbType = SqlDbType.Float;
                    break;
                case "image":
                    dbType = SqlDbType.Image;
                    break;
                case "money":
                    dbType = SqlDbType.Money;
                    break;
                case "ntext":
                    dbType = SqlDbType.NText;
                    break;
                case "nvarchar":
                    dbType = SqlDbType.NVarChar;
                    break;
                case "smalldatetime":
                    dbType = SqlDbType.SmallDateTime;
                    break;
                case "smallint":
                    dbType = SqlDbType.SmallInt;
                    break;
                case "text":
                    dbType = SqlDbType.Text;
                    break;
                case "bigint":
                    dbType = SqlDbType.BigInt;
                    break;
                case "binary":
                    dbType = SqlDbType.Binary;
                    break;
                case "char":
                    dbType = SqlDbType.Char;
                    break;
                case "nchar":
                    dbType = SqlDbType.NChar;
                    break;
                case "numeric":
                    dbType = SqlDbType.Decimal;
                    break;
                case "real":
                    dbType = SqlDbType.Real;
                    break;
                case "smallmoney":
                    dbType = SqlDbType.SmallMoney;
                    break;
                case "sql_variant":
                    dbType = SqlDbType.Variant;
                    break;
                case "timestamp":
                    dbType = SqlDbType.Timestamp;
                    break;
                case "tinyint":
                    dbType = SqlDbType.TinyInt;
                    break;
                case "uniqueidentifier":
                    dbType = SqlDbType.UniqueIdentifier;
                    break;
                case "varbinary":
                    dbType = SqlDbType.VarBinary;
                    break;
                case "xml":
                    dbType = SqlDbType.Xml;
                    break;
            }
            return dbType;
        }
    }
}