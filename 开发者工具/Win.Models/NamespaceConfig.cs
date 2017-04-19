using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Win.Models
{
    [Serializable,Table("namespaceConfig")]
    public partial class NamespaceConfig
    {
        public int Id { get; set; }
        public string ModelPath { get; set; }
        public string DalPath { get; set; }
        public string BllPath { get; set; }
        public string ModelSuffix { get; set; }
        public string DalSuffix { get; set; }
        public string BllSuffix { get; set; }
    }
}