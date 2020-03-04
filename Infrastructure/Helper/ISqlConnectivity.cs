using System.Data;
using System.Data.SqlClient;
namespace HDCoreApi.Infrastucture.Helper
{
    public interface ISqlConnectivity
    {
        IDbConnection IdbOpenConnection (string Company_Code);
    }
}