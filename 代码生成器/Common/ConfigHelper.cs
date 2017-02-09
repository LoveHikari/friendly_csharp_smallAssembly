using System;
using System.Collections.Generic;

namespace Common
{
    public class ConfigHelper
    {

        private readonly string _configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "config.ini");
        private IniHelper _ini;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connstr
        {
            get
            {
                if (_ini.ContainsKey("dataBaseConfig") && _ini["dataBaseConfig"].ContainsKey("connStr"))
                    return _ini["dataBaseConfig"]["connStr"].ToString();
                return null;
            }
            set
            {

                if (_ini["dataBaseConfig"].ContainsKey("connStr"))
                {
                    _ini["dataBaseConfig"]["connStr"] = value;
                }
                else
                {
                    _ini["dataBaseConfig"].Add("connStr", value);
                }

            }
        }
        /// <summary>
        /// 数据提供者
        /// </summary>
        public string ProviderName
        {
            get
            {
                if (_ini.ContainsKey("dataBaseConfig") && _ini["dataBaseConfig"].ContainsKey("providerName"))
                    return _ini["dataBaseConfig"]["providerName"].ToString();
                return null;
            }
            set
            {
                if (_ini["dataBaseConfig"].ContainsKey("providerName"))
                {
                    _ini["dataBaseConfig"]["providerName"] = value;
                }
                else
                {
                    _ini["dataBaseConfig"].Add("providerName", value);
                }
            }
        }
        /// <summary>
        /// 当前操作数据库名
        /// </summary>
        public string DatabaseName
        {
            get
            {
                if (_ini.ContainsKey("dataBaseConfig") && _ini["dataBaseConfig"].ContainsKey("databaseName"))
                    return _ini["dataBaseConfig"]["databaseName"].ToString();
                return null;
            }
            set
            {
                if (_ini["dataBaseConfig"].ContainsKey("databaseName"))
                {
                    _ini["dataBaseConfig"]["databaseName"] = value;
                }
                else
                {
                    _ini["dataBaseConfig"].Add("databaseName", value);
                }
            }
        }
        /// <summary>
        /// 服务器名
        /// </summary>
        public string ServerName
        {
            get
            {
                if (_ini.ContainsKey("dataBaseConfig") && _ini["dataBaseConfig"].ContainsKey("serverName"))
                    return _ini["dataBaseConfig"]["serverName"].ToString();
                return null;
            }
            set
            {
                if (_ini["dataBaseConfig"].ContainsKey("serverName"))
                {
                    _ini["dataBaseConfig"]["serverName"] = value;
                }
                else
                {
                    _ini["dataBaseConfig"].Add("serverName", value);
                }
            }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string Uid
        {
            get
            {
                if (_ini.ContainsKey("dataBaseConfig") && _ini["dataBaseConfig"].ContainsKey("uid"))
                    return _ini["dataBaseConfig"]["uid"].ToString();
                return null;
            }
            set
            {
                if (_ini["dataBaseConfig"].ContainsKey("uid"))
                {
                    _ini["dataBaseConfig"]["uid"] = value;
                }
                else
                {
                    _ini["dataBaseConfig"].Add("uid", value);
                }
            }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Pwd
        {
            get
            {
                if (_ini.ContainsKey("dataBaseConfig") && _ini["dataBaseConfig"].ContainsKey("pwd"))
                    return _ini["dataBaseConfig"]["pwd"].ToString();
                return null;
            }
            set
            {
                if (_ini["dataBaseConfig"].ContainsKey("pwd"))
                {
                    _ini["dataBaseConfig"]["pwd"] = value;
                }
                else
                {
                    _ini["dataBaseConfig"].Add("pwd", value);
                }
            }
        }

        /// <summary>
        /// 实体命名空间
        /// </summary>
        public string ModelPath
        {
            get
            {
                if (_ini.ContainsKey("namespaceConfig") && _ini["namespaceConfig"].ContainsKey("modelPath"))
                    return _ini["namespaceConfig"]["modelPath"].ToString();
                return null;
            }
            set
            {
                if (_ini["namespaceConfig"].ContainsKey("modelPath"))
                {
                    _ini["namespaceConfig"]["modelPath"] = value;
                }
                else
                {
                    _ini["namespaceConfig"].Add("modelPath", value);
                }
            }
        }
        /// <summary>
        /// 数据层命名空间
        /// </summary>
        public string DalPath
        {
            get
            {
                if (_ini.ContainsKey("namespaceConfig") && _ini["namespaceConfig"].ContainsKey("dalPath"))
                    return _ini["namespaceConfig"]["dalPath"].ToString();
                return null;
            }
            set
            {
                if (_ini["namespaceConfig"].ContainsKey("dalPath"))
                {
                    _ini["namespaceConfig"]["dalPath"] = value;
                }
                else
                {
                    _ini["namespaceConfig"].Add("dalPath", value);
                }
            }
        }
        /// <summary>
        /// 逻辑层命名空间
        /// </summary>
        public string BllPath
        {
            get
            {
                if (_ini.ContainsKey("namespaceConfig") && _ini["namespaceConfig"].ContainsKey("bllPath"))
                    return _ini["namespaceConfig"]["bllPath"].ToString();
                return null;
            }
            set
            {
                if (_ini["namespaceConfig"].ContainsKey("bllPath"))
                {
                    _ini["namespaceConfig"]["bllPath"] = value;
                }
                else
                {
                    _ini["namespaceConfig"].Add("bllPath", value);
                }
            }
        }
        /// <summary>
        /// 实体类名后缀
        /// </summary>
        public string ModelSuffix
        {
            get
            {
                if (_ini.ContainsKey("namespaceConfig") && _ini["namespaceConfig"].ContainsKey("modelSuffix"))
                    return _ini["namespaceConfig"]["modelSuffix"].ToString();
                return null;
            }
            set
            {
                if (_ini["namespaceConfig"].ContainsKey("modelSuffix"))
                {
                    _ini["namespaceConfig"]["modelSuffix"] = value;
                }
                else
                {
                    _ini["namespaceConfig"].Add("modelSuffix", value);
                }
            }
        }
        /// <summary>
        /// 数据层类名后缀
        /// </summary>
        public string DalSuffix
        {
            get
            {
                if (_ini.ContainsKey("namespaceConfig") && _ini["namespaceConfig"].ContainsKey("dalSuffix"))
                    return _ini["namespaceConfig"]["dalSuffix"].ToString();
                return null;
            }
            set
            {
                if (_ini["namespaceConfig"].ContainsKey("dalSuffix"))
                {
                    _ini["namespaceConfig"]["dalSuffix"] = value;
                }
                else
                {
                    _ini["namespaceConfig"].Add("dalSuffix", value);
                }
            }
        }
        /// <summary>
        /// 逻辑层类名后缀
        /// </summary>
        public string BllSuffix
        {
            get
            {
                if (_ini.ContainsKey("namespaceConfig") && _ini["namespaceConfig"].ContainsKey("bllSuffix"))
                    return _ini["namespaceConfig"]["bllSuffix"].ToString();
                return null;
            }
            set
            {
                if (_ini["namespaceConfig"].ContainsKey("bllSuffix"))
                {
                    _ini["namespaceConfig"]["bllSuffix"] = value;
                }
                else
                {
                    _ini["namespaceConfig"].Add("bllSuffix", value);
                }
            }
        }


        public ConfigHelper()
        {

            _ini = new IniHelper(_configPath);
            if (!_ini.ContainsKey("dataBaseConfig"))
            {
                _ini.Add("dataBaseConfig",new Dictionary<object, object>());
            }

            if (!_ini.ContainsKey("namespaceConfig"))
            {
                _ini.Add("namespaceConfig", new Dictionary<object, object>());
            }
        }

        /// <summary>
        /// 写配置
        /// </summary>
        public void WriteConfig()
        {
            _ini.Save();
        }
    }
}