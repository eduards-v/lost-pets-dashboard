using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.CloudServices
{
    class CloudProxy : CloudRequests<DashPost>
    {

        private CloudRequests<DashPost> cs;

        public CloudProxy()
        {
            cs = new CloudService();
        }
        public List<DashPost> requestList(DashboardType type)
        {
            return cs.requestList(type);
        }
    }
}
