using System.Runtime.Remoting.Messaging;

namespace DBUtility
{
    /// <summary>
    /// 上下文简单工厂
    /// </summary>
    public class ContextFactory
    {

        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static AppDataContext GetCurrentContext()
        {
            AppDataContext nContext = CallContext.GetData("AppContext") as AppDataContext;
            if (nContext == null)
            {
                nContext = new AppDataContext();
                CallContext.SetData("AppContext", nContext);
            }
            return nContext;
        }
    }
}