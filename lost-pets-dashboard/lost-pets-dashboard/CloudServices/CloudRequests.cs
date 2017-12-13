using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.CloudServices
{
    interface CloudRequests<T>
    {
        Task<List<T>> RequestList(DashboardType type);
        void AddFeed(DashboardType type, Dashpost post);
    }
} 
