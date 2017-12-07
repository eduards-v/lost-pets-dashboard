using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.ViewModels
{
    // This class represents View representation of actual dashboard (container with dashposts)
    // Also a singleton
    class DashboardVM : NotificationBase
    {
        private static DashboardVM instance;
        // Actual dashpost container
        private Dashboard dashboard;
        private ObservableCollection<DashPostVM> _dashboard;

        private DashboardVM() {
            dashboard = Dashboard.Instance; // get instance of a container
            _dashboard = new ObservableCollection<DashPostVM>();

            // initialize observable list with values from a container
            foreach (var item in dashboard.Container)
            {
                _dashboard.Add(new DashPostVM(item));
            }
        }

        public static DashboardVM Instance
        {
            get {
                if (instance == null)
                {
                    instance = new DashboardVM();
                    return instance;
                }
                return instance;
            }
        }
    }
}
