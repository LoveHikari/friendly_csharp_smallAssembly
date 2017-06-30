namespace DeveloperKit.Views.CreateCode.Models
{
    public class Config
    {
        /// <summary>
        /// 操作
        /// </summary>
        public string Operating { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public Parameter Parameter { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Classification { get; set; }
        /// <summary>
        /// 架构选择
        /// </summary>
        public string Architecture { get; set; }
        /// <summary>
        /// 代码类型
        /// </summary>
        public string CodeType { get; set; }
    }
}