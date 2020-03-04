using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using HDCoreApi.ApplicationCore.Services;
using HDCoreApi.ApplicationCore.Entities;

namespace HDCoreApi.Controllers
{
    [ApiController]
    public class SecondarySalesController:ControllerBase
    {
        private ISecondarySalesServices _ssServices;
        public SecondarySalesController(ISecondarySalesServices ssServices)
        {
            _ssServices = ssServices;
        }
        // Example Method. 
        [Route("api/GetData/{Company_Code}")]
        [HttpGet]
        public OutPutJson GetData(string Company_Code)
        {
            return _ssServices.GetData(Company_Code);
        }
    }
}