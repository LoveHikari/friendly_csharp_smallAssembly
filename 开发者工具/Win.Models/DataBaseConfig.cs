using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Win.Models
{
    [Serializable, Table("dataBaseConfig")]
    public partial class DataBaseConfig
    {
        public int Id { get; set; }
        public string ConnStr { get; set; }
        public string DatabaseName { get; set; }
        public string ProviderName { get; set; }
        public string ServerName { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
    }
}