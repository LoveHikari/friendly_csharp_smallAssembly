using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common.DBHelper;
using Models;

namespace DBUtility
{
    public class SqlServerBll
    {
        #region instance
        private static volatile SqlServerBll _instance = null;
        private static readonly object lockHelper = new object();
        public static SqlServerBll Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SqlServerBll();
                    }
                }
                return _instance;
            }
        }
        #endregion
        private static string _connectionString;
        private static string _providerName;
        public SqlServerBll()
        {
             DataBaseConfigRepository dataBaseConfigRepository = new DataBaseConfigRepository();
            var dataBaseConfig = dataBaseConfigRepository.Find(dc => dc.Id == 1);
            _connectionString = dataBaseConfig.ConnStr;
            _providerName = dataBaseConfig.ProviderName;
        }
        /// <summary>
        /// 获得所有数据库
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllDatabase()
        {
            try
            {
                CrDB db = new CrDB(_connectionString, _providerName);
                string sql = "Select name from master..sysdatabases  ORDER BY name";
                return db.ExecuteDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// 获得所有数据表
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTable()
        {
            CrDB db = new CrDB(_connectionString, _providerName);
            string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME";
            return db.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获得字段表
        /// </summary>
        /// <param name="tablename">数据表名</param>
        /// <returns></returns>
        public DataTable GetColumnTable(string tablename)
        {
            CrDB db = new CrDB(_connectionString, _providerName);
            DataTable datatable = db.ExecuteDataTable($@"SELECT 
                                                表名   = CASE a.colorder WHEN 1 THEN c.name ELSE '' END, 
                                                表说明 = CASE a.colorder WHEN 1 THEN isnull(g.value,'') ELSE '' END,
                                                序号     = a.colorder, 
                                                字段名 = a.name, 
                                                标识   = CASE COLUMNPROPERTY(a.id,a.name,'IsIdentity') WHEN 1 THEN '√' ELSE '' END, 
                                                主键   = CASE 
                                                WHEN EXISTS ( 
                                                SELECT * 
                                                FROM sysobjects 
                                                WHERE xtype='PK' AND name IN ( 
                                                SELECT name 
                                                FROM sysindexes 
                                                WHERE id=a.id AND indid IN ( 
                                                SELECT indid 
                                                FROM sysindexkeys 
                                                WHERE id=a.id AND colid IN ( 
                                                SELECT colid 
                                                FROM syscolumns 
                                                WHERE id=a.id AND name=a.name 
                                                ) 
                                                ) 
                                                ) 
                                                ) 
                                                THEN '√' 
                                                ELSE '' 
                                                END, 
                                                类型   = b.name, 
                                                字节数 = a.length, 
                                                长度   = COLUMNPROPERTY(a.id,a.name,'Precision'), 
                                                小数   = CASE ISNULL(COLUMNPROPERTY(a.id,a.name,'Scale'),0) 
                                                WHEN 0 THEN '' 
                                                ELSE CAST(COLUMNPROPERTY(a.id,a.name,'Scale') AS VARCHAR) 
                                                END, 
                                                允许空 = CASE a.isnullable WHEN 1 THEN '√' ELSE '' END, 
                                                默认值 = ISNULL(d.[text],''), 
                                                说明   = ISNULL(e.[value],'') 
                                                FROM syscolumns a 
                                                LEFT  JOIN systypes      b ON a.xtype=b.xusertype 
                                                INNER JOIN sysobjects    c ON a.id=c.id AND c.xtype='U' AND c.name<>'dtproperties' 
                                                LEFT  JOIN syscomments   d ON a.cdefault=d.id 
                                                LEFT  JOIN sys.extended_properties e ON a.id=e.major_id AND a.colid=e.minor_id 
                                                LEFT JOIN sys.extended_properties g ON (a.id=g.major_id AND  g.minor_id = 0 )
                                                WHERE c.name = '{tablename}'
                                                ORDER BY c.name, a.colorder");
            return datatable;
        }

        /// <summary>
        /// 获得字段集合
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public List<ColumnModel> GetTableColumnInfo(string tablename)
        {
            DataTable dataTable = GetColumnTable(tablename);
            List<ColumnModel> fieldlist = new List<ColumnModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ColumnModel field = new ColumnModel();
                field.TableName = dataTable.Rows[0]["表名"].ToString();
                field.TableDescription = dataTable.Rows[0]["表说明"].ToString();
                field.ColumnOrder = dataRow["序号"].ToString();
                field.ColumnName = dataRow["字段名"].ToString();
                field.TypeName = dataRow["类型"].ToString();
                field.Length = int.Parse(dataRow["长度"].ToString());
                field.Precision = int.Parse(dataRow["字节数"].ToString());
                field.Scale = dataRow["小数"].ToString();
                field.IsIdentity = dataRow["标识"].ToString() == "√";
                field.IsPrimaryKey = dataRow["主键"].ToString() == "√";
                field.IsCanNull = dataRow["允许空"].ToString() == "√";
                field.DefaultVal = dataRow["默认值"].ToString();
                field.Description = dataRow["说明"].ToString();
                fieldlist.Add(field);
            }
            return fieldlist;
        }

        /// <summary>
        /// 返回数据表列名
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public DataColumnCollection Returncolumns(string tablename)
        {
            CrDB db = new CrDB(_connectionString, _providerName);
            DataTable datatable = db.ExecuteDataTable("select top 0 * from " + tablename);
            DataColumnCollection columns = datatable.Columns;
            return columns;
        }
    }
}