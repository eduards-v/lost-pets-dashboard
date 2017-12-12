using lost_pets_dashboard.CloudServices.Utils;
using lost_pets_dashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace lost_pets_dashboard.CloudServices
{
    class CloudService : CloudRequests<DashPost> 
    {
        private Json2ListParser json2List = new Json2ListParser();


        public async Task<List<DashPost>> requestList(DashboardType type)
        {
            var temp = new List<DashPost>();
            var objClient = new HttpClient();
            Uri uri = null;
            string strResponse; 


            if (type == DashboardType.LOST)
            {
                uri = new Uri("http://localhost:8080/dashboards/lost/");
                //temp.Add(new DashPost("Post 1", "Lost pet"));
                //temp.Add(new DashPost("Post 2", "Lost pet"));
            }
            else if (type == DashboardType.FOUND)
            {
                uri = new Uri("http://localhost:8080/dashboards/found/");

                //temp.Add(new DashPost("Post 3", "Found pet"));
                //temp.Add(new DashPost("Post 4", "Found pet"));
            }

            try
            {
                HttpResponseMessage response = await objClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                strResponse = await response.Content.ReadAsStringAsync();
                
                temp = json2List.parseJArray2List(JsonArray.Parse(strResponse));
            }
            catch (HttpRequestException exception)
            {
                Debug.WriteLine("DESCRIPTION: " + exception.Message + " STATUS CODE: " + exception.HResult);
            }

            return temp;
        }
    }
}
