using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.CloudServices
{
    class CloudProxy : CloudRequests<Dashpost>
    {

        private CloudRequests<Dashpost> cs;

        public CloudProxy()
        {
            cs = new CloudService();
        }

        public async Task<List<Dashpost>> RequestList(DashboardType type)
        {
            return await cs.RequestList(type);
        }

        public void AddFeed(DashboardType type, Dashpost post)
        {
            cs.AddFeed(type, post);
        }
    }
}
