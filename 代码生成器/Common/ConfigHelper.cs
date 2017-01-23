using System;
using System.Collections.Generic;

namespace Common
{
    public class ConfigHelper
    {
        private static ConfigHelper _instance;
        public static ConfigHelper Instance
        {
            get
            {
                _instance = new ConfigHelper();

                return _instance;
            }
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connstr { get; set; }
        /// <summary>
        /// 数据提供者
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// 当前操作数据库名
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// 服务器名
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 实体命名空间
        /// </summary>
        public string ModelPath { get; set; }
        /// <summary>
        /// 数据层命名空间
        /// </summary>
        public string DalPath { get; set; }
        /// <summary>
        /// 逻辑层命名空间
        /// </summary>
        public string BllPath { get; set; }
        /// <summary>
        /// 实体类名后缀
        /// </summary>
        public string ModelSuffix { get; set; }
        /// <summary>
        /// 数据层类名后缀
        /// </summary>
        public string DalSuffix { get; set; }
        /// <summary>
        /// 逻辑层类名后缀
        /// </summary>
        public string BllSuffix { get; set; }

        private readonly string _configPath;

        public ConfigHelper()
        {
            _configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "config.ini");
            IniHelper ini = new IniHelper(_configPath);
            if (ini.ContainsKey("dataBaseConfig"))
            {
                if (ini["dataBaseConfig"].ContainsKey("connStr"))
                    this.Connstr = ini["dataBaseConfig"]["connStr"]?.ToString();
                if (ini["dataBaseConfig"].ContainsKey("providerName"))
                    this.ProviderName = ini["dataBaseConfig"]["providerName"]?.ToString();
                if (ini["dataBaseConfig"].ContainsKey("databaseName"))
                    this.DatabaseName = ini["dataBaseConfig"]["databaseName"]?.ToString();
                if (ini["dataBaseConfig"].ContainsKey("serverName"))
                    this.ServerName = ini["dataBaseConfig"]["serverName"]?.ToString();
                if (ini["dataBaseConfig"].ContainsKey("uid"))
                    this.Uid = ini["dataBaseConfig"]["uid"]?.ToString();
                if (ini["dataBaseConfig"].ContainsKey("pwd"))
                    this.Pwd = ini["dataBaseConfig"]["pwd"]?.ToString();
            }

            if (ini.ContainsKey("namespaceConfig"))
            {
                if (ini["namespaceConfig"].ContainsKey("modelpath"))
                    this.ModelPath = ini["namespaceConfig"]["modelpath"]?.ToString();
                if (ini["namespaceConfig"].ContainsKey("dalpath"))
                    this.DalPath = ini["namespaceConfig"]["dalpath"]?.ToString();
                if (ini["namespaceConfig"].ContainsKey("bllpath"))
                    this.BllPath = ini["namespaceConfig"]["bllpath"]?.ToString();
                if (ini["namespaceConfig"].ContainsKey("modelSuffix"))
                    this.ModelSuffix = ini["namespaceConfig"]["modelSuffix"]?.ToString();
                if (ini["namespaceConfig"].ContainsKey("dalSuffix"))
                    this.DalSuffix = ini["namespaceConfig"]["dalSuffix"]?.ToString();
                if (ini["namespaceConfig"].ContainsKey("bllSuffix"))
                    this.BllSuffix = ini["namespaceConfig"]["bllSuffix"]?.ToString();
            }

        }
        /// <summary>
        /// 写配置
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WriteConfig(string section, string key, string value)
        {
            IniHelper ini = new IniHelper(_configPath);
            if (ini.ContainsKey(section))
            {
                Dictionary<object, object> dic = ini[section];
                if (dic.ContainsKey(key))
                {
                    dic[key] = value;
                }
                else
                {
                    dic.Add(key, value);
                }
            }
            else
            {
                ini.Add(section, key, value);
            }

            ini.Save();
        }

    }
}