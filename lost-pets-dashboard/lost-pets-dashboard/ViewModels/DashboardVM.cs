using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        // Observable collection selected index. Keeping track of selections from UI
        private int selectedIndex;

        // Constructor
        private DashboardVM() {
            Debug.WriteLine("Constructing EXTERNAL container....");
            dashboard = Dashboard.Instance; // get instance of a container

            _dashboard = new ObservableCollection<DashPostVM>();

            SelectedIndex = -1;

            // initialize observable list with values from a container
            foreach (var item in dashboard.Container)
            {
                _dashboard.Add(new DashPostVM(item));
            }
        }
        // Class instance getter
        public static DashboardVM Instance
        {
            get {
                Debug.WriteLine("GETTING EXTERNAL container instance....");
                if (instance == null)
                {
                    instance = new DashboardVM();
                    return instance;
                }
                return instance;
            }
        }

        public int SelectedIndex
        {
            get { Debug.WriteLine("SELECTED INDEX CHANGED - TodoCollectionVM :: " + selectedIndex); return selectedIndex; }
            set
            {
                if (SetProperty(ref selectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedDashPost)); }
            }
        }

        public DashPostVM SelectedDashPost
        {
            get { return (selectedIndex >= 0) ? _dashboard[selectedIndex] : null; }
        }

        public ObservableCollection<DashPostVM> GetDashboard
        {
            get
            {
                Debug.WriteLine("GETTING Dashboard ....");
                return _dashboard;
            }
        }
    }
}
