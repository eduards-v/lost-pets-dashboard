using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace lost_pets_dashboard.CloudServices.Utils
{
    class Json2ListParser
    {
        // REF.: https://github.com/arkiq/AppDataBind/blob/master/App9databind2/MainPage.xaml.cs
        public List<DashPost> parseJArray2List(JsonArray tempJson)
        {
            List<DashPost> tempList = new List<DashPost>();
            foreach (var item in tempJson)
            {
                var obj = item.GetObject();

                DashPost dashPost = new DashPost();

                foreach (var key in obj.Keys)
                {
                    IJsonValue value;
                    if (!obj.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "title":
                            dashPost.Title = value.GetString();
                            break;
                        case "desc":
                            dashPost.Description = value.GetString();
                            break;

                    }
                } // inner foreach

                tempList.Add(dashPost);
            } // outter foreach
            return tempList;
        } // end of json to collection converter
    }
}
