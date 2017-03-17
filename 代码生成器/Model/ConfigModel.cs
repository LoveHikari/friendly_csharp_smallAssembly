namespace Model
{
    public class ConfigModel
    {
        /// <summary>
        /// 实体类命名空间
        /// </summary>
        public string ModelPath { get; set; }
        /// <summary>
        /// 数据层命名空间
        /// </summary>
        public string DalPath { get; set; }
        /// <summary>
        /// 业务层命名空间
        /// </summary>
        public string BllPath { get; set; }
        /// <summary>
        /// 模型类后缀
        /// </summary>
        public string ModelSuffix { get; set; }
        /// <summary>
        /// 数据层后缀
        /// </summary>
        public string DalSuffix { get; set; }
        /// <summary>
        /// 业务层后缀
        /// </summary>
        public string BllSuffix { get; set; }
    }
}