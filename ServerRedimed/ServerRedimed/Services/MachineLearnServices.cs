using ServerRedimed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net;
using System.Web;

namespace ServerRedimed.Services
{
    public class MachineLearnServices : IMachineLearnServices
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "Gzh3L6XRWZ5buvdMbhFBqCYVqP8YrL961xvBaqei",
            BasePath = "https://redimed-9a201.firebaseio.com/"
        };
        IFirebaseClient client;

        private readonly Dictionary<string, testModel> _testModelItem;

        public MachineLearnServices()
        {
            _testModelItem = new Dictionary<string, testModel>();
        }

        public testModel testApi()
        {
            var n = new testModel();
            n.name = "nghia";
            return n;
        }

        public async Task<testModel> xuatTen(string idPatient, string sttRequest, string linkImage)
        {
          //  https % 3A % 5C % 5Cimages.unsplash.com % 5Cphoto - 1464982326199 - 86f32f81b211 % 3Fixlib % 3Drb - 1.2.1 % 26ixid % 3DeyJhcHBfaWQiOjEyMDd9 % 26w % 3D1000 % 26q % 3D80
            client = new FireSharp.FirebaseClient(config);
            testModel n;
            linkImage = linkImage.Replace("**n**", "\\");
            linkImage = linkImage.Replace("**nn**", "%2F");
            if (client != null)
            {
                //string mlFeedback = (new WebClient()).DownloadString("http://nghiagood.pythonanywhere.com/" + "https%3A%5C%5Cencrypted-tbn0.gstatic.com%5Cimages%3Fq%3Dtbn%3AANd9GcSlSjQxZe_tte_QOFNFfCIyn0jf6s3PIl2pzJuTedovz70SOz5S%26s");
                //string mlFeedback = (new WebClient()).DownloadString("http://nghiagood.pythonanywhere.com/" + HttpUtility.UrlEncode(linkImage));
                string mlFeedback = (new WebClient()).DownloadString("https://ungthudaserver-pchohu4vcq-as.a.run.app/" + HttpUtility.UrlEncode(linkImage));
               char resultML = mlFeedback[10];

                n = new testModel()
                {
                    name = "is connected"
                    //name = Char.ToString(resultML)
                    //name = HttpUtility.UrlEncode(linkImage)
                    

                };
                string lastResultML;
                if (Char.ToString(resultML).Equals('1') )
                {
                    lastResultML = "6";
                }
                else
                {
                    lastResultML = "5";
                }
                var item = new UserModel()
                {
                    State = lastResultML
                }; 
              SetResponse response = await client.SetTaskAsync("Patient/"+ idPatient+ "/Request/"+ sttRequest ,item);
              UserModel result = response.ResultAs<UserModel>();

            }
            else
            {
                n = new testModel()
                {
                    name = "not connected"
                };
            }
            return await Task.FromResult(n);
        }
    }
}
