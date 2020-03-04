using System;
using System.Web;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using HDCoreApi.ApplicationCore.Repository;
using HDCoreApi.ApplicationCore.Entities;


namespace HDCoreApi.ApplicationCore.Services
{
    public class SecondarySalesService : OutputJsonRepositry, ISecondarySalesServices
    {
        private ISecondarySalesRepository _SecondarySalesRepository;
        public SecondarySalesService(ISecondarySalesRepository SSRepository)
        {
            _SecondarySalesRepository = SSRepository;
        }
        // Example Method.
        public OutPutJson GetData(string Company_Code)
        {
            List<SecondarySalesModel> lst = new List<SecondarySalesModel>();
            try
            {
                lst = _SecondarySalesRepository.GetData(Company_Code);
                return GenerateOutputJson(SUCCESS,lst,lst.Count,SUCCESS_STATUS,0);
            }
            catch (Exception ex)
            {
                return GenerateErrorOutputJson(ex.Message,lst);
            }
        }

    }
}