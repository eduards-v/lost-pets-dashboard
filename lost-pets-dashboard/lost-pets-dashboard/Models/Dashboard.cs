using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.Models
{
    /*
        Class that acts as a container for storing dashboard in memory
        This class is a Singleton class as we want to use only one instance of it within application 
    */
    class Dashboard
    {
        private static Dashboard instance;

        private IList<DashPost> container;

        private Dashboard()
        {
            Debug.WriteLine("Constructing INTERNAL container...");
            container = new List<DashPost>();
        }

        public static Dashboard Instance
        {
            get
            {
                Debug.WriteLine("GETTING INTERNAL container instance....");
                if (instance == null)
                {
                    instance = new Dashboard();
                    return instance;
                }
                return instance;
            }
        }

        public IList<DashPost> Container
        {
            get
            {
                return container;
            }
        }

        public IList<DashPost> GetContainer(string data_type)
        {
            if (data_type == "lost-pets")
            {
                // ask service to request lost pets payload
                var lostPets = container.Where( p => p.IsLost == true);
                return lostPets.ToList();
            }else if (data_type == "found-pets")
            {
                // ask service to request found pets payload
                var lostPets = container.Where(p => p.IsLost == false);
                return lostPets.ToList();
            }

            return new List<DashPost>();
        }

        public void initializeContainer()
        {
            // make a request to get list items
            // call this method at app start along with an 
            Debug.WriteLine("Initializing INTERNAL container instance...");
            // doomy data for now
            container.Add(new DashPost ("Post 1", "About post", false ));
            container.Add(new DashPost("Post 2", "About post", true));
            container.Add(new DashPost("Post 3", "About post", true));
            container.Add(new DashPost("Post 4", "About post", false));
            container.Add(new DashPost("Post 5", "About post", true));
            container.Add(new DashPost("Post 6", "About post", false));

        }

        public Boolean Add()
        {
            // make a request to add new item
            return false;
        }

        public Boolean Delete()
        {
            // make a request to delete item
            return false;
        }

        public void Update()
        {
            // make a request to update item
        }

        
    }
}
