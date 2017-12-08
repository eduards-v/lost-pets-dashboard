using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.ViewModels
{
    // This class represents View representation of actual dashboard (container with dashposts)
    // Also a singleton
    class DashboardVM : NotificationBase
    {
        private static DashboardVM instance;
        // Actual dashposts container
        private Dashboard dashboard;
        // Observable collection to source up the xaml view
        private ObservableCollection<DashPostVM> _dashboard;
         
        // Observable collection selected index. Keeping track of selections from UI
        private int selectedIndex;

        // Constructor
        private DashboardVM() {
            Debug.WriteLine("Constructing EXTERNAL container....");
            dashboard = Dashboard.Instance; // get instance of a container

            // set selectoedIndex to be negative, avoiding pointing to an empty index in case collection is empty
            SelectedIndex = -1;

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

        public static DashboardVM GetInstance([CallerMemberName] string callerName = null)
        {
            Debug.WriteLine("GETTING EXTERNAL container instance...." + " Called by " + callerName);

            /* 
               if callerName is LostPetsPage then set _dashboard content to be lost pets items 
               if callerName is FoundPetsPage then set _dashboard content to be found pets items

                boolean isLost is used to identify which item belong to lost/found view
                use it searching criteria for back-end API 

               
               display by locations requires to get current location and send request to API to specify location
               to return list of lost/found pets inside location, then populate _dashboard with new list

                this way you also no need to get full list of items from API, but only a slice of it
            */
            if (instance == null)
            {
                instance = new DashboardVM();
            }

            // calling non-static method from static via class reference. This will work with singleton calling it's own private methods.
            DashboardVM.Instance.initDashboard(callerName);
            return instance;
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

        private void initDashboard(string dashboardType)
        {
            if (_dashboard == null)
            {
                _dashboard = new ObservableCollection<DashPostVM>();
            }

            // clear existing items on _dashboard
            

            /*
                Call inner dashboard container to get list of Lost/Found items
                Use dashboardType to decide what method to call from dashboard container
            */

            if (dashboardType == "TestPage1")
            {
                // initialize observable list with values from a container
                foreach (var item in dashboard.GetContainer("lost-pets"))
                {

                    _dashboard.Add(new DashPostVM(item));
                }
                // call GetLostPets
                // iterate over returned items list and add each item into _dashboard
            }
            else if (dashboardType == "TestPage2") {

                // initialize observable list with values from a container
                foreach (var item in dashboard.GetContainer("found-pets"))
                {

                    _dashboard.Add(new DashPostVM(item));
                }
                // call GetFoundPets
                // iterate over returned items list and add each item into _dashboard
            }
        }
    }
}
