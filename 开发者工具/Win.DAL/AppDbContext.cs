using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Win.Models;

namespace Win.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(): base("AppContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual IDbSet<DataBaseConfig> DataBaseConfigs { get; set; }
        public virtual IDbSet<NamespaceConfig> NamespaceConfigs { get; set; }
    }
}