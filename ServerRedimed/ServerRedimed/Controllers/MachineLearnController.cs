using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerRedimed.Models;
using ServerRedimed.Services;

namespace ServerRedimed.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class MachineLearnController : ControllerBase
    {
        private readonly IMachineLearnServices _services;

        public MachineLearnController(IMachineLearnServices services)
        {
            _services = services;
        }


        [HttpGet]
        [Route("test")]
        public Task<testModel> testApi()
        {

            var testItem = _services.testApi();
            
            return Task.FromResult(testItem);
        }


        [HttpGet("test2/{idPatient}/{sttRequest}/{linkImage}")]
        public Task<testModel> xuatTen(string idPatient, string sttRequest, string linkImage) =>  _services.xuatTen(idPatient, sttRequest, linkImage);


    }
}