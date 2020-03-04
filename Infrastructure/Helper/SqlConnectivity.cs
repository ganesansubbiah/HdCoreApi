using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using HDCoreApi.Infrastucture.Helper;

namespace HDCoreApi.Infrastucture.Helper
{
    public class SqlConnectivity : ISqlConnectivity
    {
        private readonly IConfiguration _config;

        public SqlConnectivity(IConfiguration config)
        {
            _config = config;
        }
        // Get GlobaConnection string .
        private string GetGlobalConnectionString()
        {
            return _config.GetConnectionString("SqlConnectionString");
        }
        // Open Company Wise sql connection.
        public IDbConnection IdbOpenConnection(string Company_Code)
        {
            string connectionString  = GetCompanyConnectionString(Company_Code);
            IDbConnection obj = new SqlConnection(connectionString);
            return obj;
        }
        // Open Gobal Sql Connection.
        private IDbConnection IdbOpenGlobalConnection
        {
            get
            {
                return new SqlConnection(GetGlobalConnectionString());
            }
        }
        // Get Company Wise Connection string.
        private string GetCompanyConnectionString(string Company_Code)
        {
            try
            {
                string connectionString = string.Empty;
                List<ConnectionModel> lstConnection = new List<ConnectionModel>();
                using (IDbConnection conn = IdbOpenGlobalConnection)
                {
                    var p = new DynamicParameters();
                    p.Add("@CompanyCode", Company_Code);
                    lstConnection = conn.Query<ConnectionModel>("sp_hdOfflineGetCompanyConnection", p, commandType: CommandType.StoredProcedure).ToList();
                    connectionString = SetConnectionString(lstConnection);
                    conn.Close();
                }
                return connectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Converting list to string format.
        private string SetConnectionString(List<ConnectionModel> lstConnection)
        {
            StringBuilder str = new StringBuilder();
            foreach (ConnectionModel item in lstConnection)
            {
                str.Append("data source=" + item.SqlIPAddress);
                str.Append(";Initial Catalog=" + item.DatabaseName.ToString());
                str.Append(";User Id=" + item.SqlLoginId.ToString());
                str.Append(";Password=" + item.SqlPassword.ToString());
            }
            return str.ToString();
        }
    }
}