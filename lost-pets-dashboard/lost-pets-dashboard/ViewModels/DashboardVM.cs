using lost_pets_dashboard.CloudServices;
using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace lost_pets_dashboard.ViewModels
{
    // This class represents View representation of actual dashboard (container with dashposts)
    // Also a singleton
    class DashboardVM : NotificationBase
    {
        private static DashboardVM instance;

        // Observable collection to source up the xaml view
        private ObservableCollection<DashPostVM> _dashboard;
        private CloudRequests<DashPost> cloud_service;

        // Observable collection selected index. Keeping track of selections from UI
        private int selectedIndex;

        // Constructor
        private DashboardVM() {
            Debug.WriteLine("Constructing EXTERNAL container....");

            cloud_service = new CloudProxy();

            _dashboard = new ObservableCollection<DashPostVM>();

            // set selectoedIndex to be negative, avoiding pointing to an empty index in case collection is empty
            SelectedIndex = -1;

        }
        // Class instance getter. Used for accessing public methods to cooperate with ListView.
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

        // Called from a xaml.cs Page to initialize ListView. Name of the caller class is passed as a 
        // parameter to determine what data to return.
        public static DashboardVM GetInstance([CallerMemberName] string callerName = null)
        {
            Debug.WriteLine("GETTING EXTERNAL container instance...." + " Called by " + callerName);

            // Calling private method inside static method via class reference. 
            Instance.initDashboard(callerName);

            Debug.WriteLine("AFTER INIT DASHBOARD ....");
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

        public ObservableCollection<DashPostVM> VMDashboard
        {
            get
            {
                Debug.WriteLine("GETTING Dashboard ....");
                return _dashboard;
            }
        }

        // Method to initialize dashboard for current page
        // Everytime an application navigates to a Page with ListView,
        // a new request sent to the service to obtain items. Consistency 
        // with database on cloud also kept in synch.
        private async void initDashboard(string dashboardType)
        {
            // clear existing items on _dashboard
            _dashboard.Clear();

            switch (dashboardType)
            {
                case "TestPage1":
                    Debug.WriteLine("Loading for TestPage1");

                    var tempLost = await Task.Run(() => cloud_service.requestList(DashboardType.LOST).Result);
                    // initialize observable list with values from a request
                    foreach (var item in tempLost)
                    {
                        var newPost = new DashPostVM(item);
                        _dashboard.Add(newPost);
                    }
                    break; // end of case TestPage1

                case "TestPage2":
                    Debug.WriteLine("Loading for TestPage2");

                    var tempFound = await Task.Run(() => cloud_service.requestList(DashboardType.FOUND).Result);
                    // initialize observable list with values from a container
                    foreach (var item in tempFound)
                    {
                        var newPost = new DashPostVM(item);
                        _dashboard.Add(new DashPostVM(newPost));
                    }
                    break; // end of case TestPage2
            } // end of cases
        } // end of initDashboard()


        public void AddItem()
        {
            _dashboard.Add(new DashPostVM(new DashPost("ADD ITEM", "Testing add item")));
        }

    }
}
