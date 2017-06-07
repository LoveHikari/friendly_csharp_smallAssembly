using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using Win.Common;

namespace 开发者工具.JAVAConfig
{
    /// <summary>
    /// java环境变量配置
    /// </summary>
    /// <remarks>http://www.52pojie.cn/thread-537812-1-1.html</remarks>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool b = RegistryHelper.IsRegistryExist(RegistryHive.LocalMachine, @"SOFTWARE\JavaSoft\Java Development Kit",RegistryView.Registry64);
            if (b)  // 安装jdk
            {
                string[] subKeys = RegistryHelper.GetSubKeyNames(RegistryHive.LocalMachine, @"SOFTWARE\JavaSoft\Java Development Kit", RegistryView.Registry64);
                if (subKeys != null)
                {
                    this.label4.Text = subKeys[0];
                    this.label5.Text = RegistryHelper.GetRegistryData(RegistryHive.LocalMachine, @"SOFTWARE\JavaSoft\Java Development Kit\" + subKeys[0], "JavaHome", RegistryView.Registry64);
                    return;
                }
            }
            this.label4.Text = "没有查找到JDK";
            this.label5.Text = "没有查找到JDK路径！";
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            if (FileHelper.FindDirectories(this.label5.Text).Contains("bin"))
            {
                MessageBox.Show("选择的文件夹不是JDK目录（如：C:\\Program Files\\Java\\jdk1.8.0_101）");
                return;
            }
            if (Environment.GetEnvironmentVariable("JAVA_HOME", EnvironmentVariableTarget.Machine) != null)
            {
                SetVariable("JAVA_HOME", this.label5.Text);
                SetVariable("Path", @"%JAVA_HOME%\bin;%JAVA_HOME%\jre\bin");
                SetVariable("CLASSPATH", @".;%JAVA_HOME%\lib;%JAVA_HOME%\lib\tools.jar");
            }
            MessageBox.Show("配置成功！注销或者重启生效！");
        }

        /// <summary>
        /// 设置环境变量
        /// </summary>
        /// <param name="variable">环境变量名</param>
        /// <param name="value">值</param>
        /// <remarks>http://blog.chinaunix.net/uid-25498312-id-4085179.html</remarks>
        public void SetVariable(string variable, string value)
        {
            string pathlist = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
            if (pathlist != null)
            {
                pathlist = pathlist.TrimEnd(';');
                string[] list = pathlist.Split(';');
                bool isPathExist = false;

                foreach (string item in list)
                {
                    if (item == value)
                        isPathExist = true;
                }
                if (!isPathExist)
                {
                    Environment.SetEnvironmentVariable(variable, pathlist + ";" + value,
                        EnvironmentVariableTarget.Machine);
                }
            }
            else
            {
                Environment.SetEnvironmentVariable(variable, value, EnvironmentVariableTarget.Machine);
            }

        }

        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="cmd">cmd命令</param>
        /// <returns>执行结果</returns>
        /// <remarks>http://blog.csdn.net/qq_26597393/article/details/69945030</remarks>
        public string RunCmd(string cmd)
        {
            string output = "";
            //cmd = cmd.Trim().TrimEnd('&') + "&exit"; //说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态  
            using (Process p = new Process())
            {
                p.StartInfo.FileName = @"cmd.exe"; 
                p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动  
                p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息  
                p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息  
                p.StartInfo.RedirectStandardError = true; //重定向标准错误输出  
                p.StartInfo.CreateNoWindow = false; //不显示程序窗口  

                p.Start(); //启动程序

                //向cmd窗口写入命令
                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息  
                output = p.StandardOutput.ReadToEnd();
                
                p.WaitForExit(); //等待程序执行完退出进程  
                p.Close();
            }
            return output;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            this.label5.Text = dialog.SelectedPath.Trim();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
