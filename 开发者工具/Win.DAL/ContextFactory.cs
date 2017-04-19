using System.Runtime.Remoting.Messaging;

namespace Win.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// <remarks>
    /// 创建：2014.02.05
    /// </remarks>
    /// </summary>
    public class ContextFactory
    {

        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static AppDbContext GetCurrentContext()
        {
            AppDbContext nContext = CallContext.GetData("AppContext") as AppDbContext;
            if (nContext == null)
            {
                nContext = new AppDbContext();
                CallContext.SetData("AppContext", nContext);
            }
            return nContext;
        }
    }
}