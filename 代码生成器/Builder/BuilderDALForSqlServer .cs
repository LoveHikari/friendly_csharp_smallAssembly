using System.Collections.Generic;
using Model;

namespace Builder
{
    public class BuilderDALForSqlServer : BuilderDAL
    {
        public BuilderDALForSqlServer(List<ColumnModel> fieldlist, string dbherlpername, string modelpath, string dalpath, string modelSuffix, string dalSuffix) : base(fieldlist, dbherlpername, modelpath, dalpath, modelSuffix, dalSuffix)
        {

        }
    }
}