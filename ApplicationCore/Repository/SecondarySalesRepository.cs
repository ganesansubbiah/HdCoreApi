using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Dapper;
using HDCoreApi.ApplicationCore.Repository;
using HDCoreApi.Infrastucture.Helper;
using HDCoreApi.ApplicationCore.Entities;

namespace HDCoreApi.ApplicationCore.Repository
{
    public class SecondarySalesRepository : ISecondarySalesRepository
    {
        private ISqlConnectivity _sqlconnectivity;
        public SecondarySalesRepository(ISqlConnectivity sqlconnectivity)
        {
            _sqlconnectivity = sqlconnectivity;
        }
        // Example Method.
        public List<SecondarySalesModel> GetData(string Company_Code)
        {
            List<SecondarySalesModel> lst = new List<SecondarySalesModel>();
            try
            {
                using (IDbConnection conn = _sqlconnectivity.IdbOpenConnection(Company_Code))
                {
                    lst = conn.Query<SecondarySalesModel>("Select * From Tbl_Sfa_SecondarySales_Header", null, commandType: CommandType.Text).ToList();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }         
    }
}