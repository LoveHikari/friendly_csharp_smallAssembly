using System.Collections.Generic;
using Win.Models;

namespace DeveloperKit.Views.CreateCode.Builder
{
    public class BuilderDALForSqlServer : BuilderDAL
    {
        public BuilderDALForSqlServer(List<ColumnModel> fieldlist, string dbherlpername, string modelpath, string dalpath, string modelSuffix, string dalSuffix) : base(fieldlist, dbherlpername, modelpath, dalpath, modelSuffix, dalSuffix)
        {

        }
    }
}