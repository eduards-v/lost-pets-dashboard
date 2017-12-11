using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.CloudServices
{
    class CloudService : CloudRequests<DashPost> 
    {
        public List<DashPost> requestList(DashboardType type)
        {
            var temp = new List<DashPost>();

            if (type == DashboardType.LOST)
            {
                temp.Add(new DashPost("Post 1", "Lost pet"));
                temp.Add(new DashPost("Post 2", "Lost pet"));
            }else if (type == DashboardType.FOUND)
            {
                temp.Add(new DashPost("Post 3", "Found pet"));
                temp.Add(new DashPost("Post 4", "Found pet"));
            }
            return temp;
        }
    }
}
