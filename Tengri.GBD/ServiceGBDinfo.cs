using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Tengri.GBD
{
    public class ServiceGBDinfo
    {
        RestClient client = new RestClient("https://meteor.almaty.e-orda.kz/");
        RestRequest request = new RestRequest();
        public personal_data GetInfo(string Iin)
        {
            personal_data personal_Data = null;

            request.Resource =
                string.Format("ru/api-form/load-info-by-iin/?iin={0}&params[city_check]=true", Iin);
            IRestResponse response = client.Get(request);
            //if (response.IsSuccessful)
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               string result = response.Content;
                personal_Data = JsonConvert.DeserializeObject<personal_data>(result);
            }
            return personal_Data;
        }
    }
}
