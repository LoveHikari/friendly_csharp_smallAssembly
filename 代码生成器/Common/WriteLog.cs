﻿using System;
using System.Configuration;

/******************************************************************************************************************
 * 
 * 
 * 说　明： 错误日志输出类(版本：Version1.0.0)
 * 作　者：YuXiaoWei
 * 日　期：2016/08/19
 * 修　改：
 * 参　考：
 * 备　注：config文件配置：<appSettings>
 *                         <add key="LogFilePath" value="E:\111"/>
 *                       </appSettings>
 * 
 * 
 * ***************************************************************************************************************/
namespace Common
{
    /// <summary>
    /// 输出log
    /// </summary>
    public class WriteLog
    {
        private static object locker = new object();
        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        public static void WriteError(Exception ex)
        {
            lock (locker)
            {
                System.IO.StreamWriter sw = null;
                try
                {
                    string directPath = ConfigurationManager.AppSettings["LogFilePath"]?.Trim();    //获得文件夹路径
                    if (string.IsNullOrEmpty(directPath))
                    {
                        directPath = System.IO.Path.Combine(Environment.CurrentDirectory, "log");  //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
                    }
                    if (!System.IO.Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                    {
                        System.IO.Directory.CreateDirectory(directPath);
                    }
                    directPath = System.IO.Path.Combine(directPath, $"{DateTime.Now:yyyy-MM-dd}_Log.log");

                    sw = !System.IO.File.Exists(directPath) ? System.IO.File.CreateText(directPath) : System.IO.File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。

                    //把异常信息输出到文件
                    sw.WriteLine("当前时间：" + DateTime.Now);
                    sw.WriteLine("异常信息：" + ex.Message);
                    sw.WriteLine("异常对象：" + ex.Source);
                    sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
                    sw.WriteLine("触发方法：" + ex.TargetSite);
                    sw.WriteLine("***********************************************************************");
                    sw.WriteLine();
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Dispose();
                    }
                }
            }

        }
        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="tag">传入标签（这里用于标识函数由哪个线程调用）</param>
        public static void WriteError(Exception ex, string tag)
        {
            lock (locker)
            {
                System.IO.StreamWriter sw = null;
                try
                {

                    string directPath = ConfigurationManager.AppSettings["LogFilePath"]?.Trim(); //获得文件夹路径
                    if (string.IsNullOrEmpty(directPath))
                    {
                        directPath = System.IO.Path.Combine(Environment.CurrentDirectory, "log"); //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
                    }
                    if (!System.IO.Directory.Exists(directPath)) //判断文件夹是否存在，如果不存在则创建
                    {
                        System.IO.Directory.CreateDirectory(directPath);
                    }
                    directPath = System.IO.Path.Combine(directPath, $"{DateTime.Now:yyyy-MM-dd}_Log.log");

                    sw = !System.IO.File.Exists(directPath) ? System.IO.File.CreateText(directPath) : System.IO.File.AppendText(directPath);//判断文件是否存在如果不存在则创建，如果存在则添加。

                    //把异常信息输出到文件
                    sw.WriteLine(string.Concat('[', DateTime.Now.ToString(), "] Tag:" + tag));
                    sw.WriteLine("异常信息：" + ex.Message);
                    sw.WriteLine("异常对象：" + ex.Source);
                    sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
                    sw.WriteLine("触发方法：" + ex.TargetSite);
                    sw.WriteLine("***********************************************************************");
                    sw.WriteLine();
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Dispose();
                    }
                }
            }
        }
    }
}