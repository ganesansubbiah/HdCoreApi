using HDCoreApi.ApplicationCore.Repository;
using HDCoreApi.ApplicationCore.Entities;

namespace HDCoreApi.ApplicationCore.Services
{
    public interface ISecondarySalesServices
    {
        OutPutJson GetData(string Company_Code);
    }
}