using ServerRedimed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerRedimed.Services
{
    public interface IMachineLearnServices
    {
        testModel testApi();
        
        Task<testModel> xuatTen(string idPatient, string sttRequest, string linkImage);
    }
}
