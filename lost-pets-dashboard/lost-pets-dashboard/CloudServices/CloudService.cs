using lost_pets_dashboard.CloudServices.Utils;
using lost_pets_dashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace lost_pets_dashboard.CloudServices
{
    class CloudService : CloudRequests<Dashpost> 
    {
        private Json2ListParser json2List = new Json2ListParser();

        public async Task<List<Dashpost>> RequestList(DashboardType type)
        {
            var temp = new List<Dashpost>();
            var objClient = new HttpClient();
            Uri uri = null;
            string strResponse; 

            if (type == DashboardType.LOST)
            {
                uri = new Uri("http://localhost:8080/dashboards/lost/");
            }
            else if (type == DashboardType.FOUND)
            {
                uri = new Uri("http://localhost:8080/dashboards/found/");
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


        public async Task<bool> AddFeed(DashboardType type, Dashpost post)
        {
            bool statusFlag = false;
            Uri requestUri =  new Uri("http://localhost:8080/dashboards/add/lost/");
            if (type.Equals(DashboardType.FOUND)) requestUri = new Uri("http://localhost:8080/dashboards/add/found/");

            dynamic dynamicJson = new ExpandoObject();
            dynamicJson.title = post.Title;
            dynamicJson.desc = post.Description;
            string json = "";
            json = JsonConvert.SerializeObject(dynamicJson); // serialize json object and store it in string 
            var objClient = new HttpClient(); // create Http Client to access http methods

            try
            {
                HttpResponseMessage respon = await objClient.PostAsync(requestUri,
                new StringContent(json, Encoding.UTF8, "application/json"));
                string responJsonText = await respon.Content.ReadAsStringAsync();

                Debug.WriteLine("Adding new item respone: " + responJsonText);
                statusFlag = true;

            }
            catch (HttpRequestException exception)
            {
                // catch Http Exception
                Debug.WriteLine("DESCRIPTION: " + exception.Message + " STATUS CODE: " + exception.HResult);
            }

            return statusFlag;
        }
    }
}
