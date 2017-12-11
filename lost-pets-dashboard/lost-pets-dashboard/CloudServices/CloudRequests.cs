using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.CloudServices
{
    interface CloudRequests<T>
    {
        List<T> requestList(DashboardType type);
    }
} 
