using System.Collections;
using System.Collections.Generic;
using HDCoreApi.ApplicationCore.Entities;

namespace HDCoreApi.ApplicationCore.Repository
{
    public interface ISecondarySalesRepository
    {
        List<SecondarySalesModel> GetData(string Company_Code);
    }
}