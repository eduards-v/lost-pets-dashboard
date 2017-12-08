using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.Models
{
    class DashPost
    {
        private string title;
        private string description;
        private bool isLost;

        public DashPost() { }
        public DashPost(string title, string description, bool isLost)
        {
            this.title = title;
            this.description = description;
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        
        public bool IsLost
        {
            get
            {
                return isLost;
            }

            set
            {
                isLost = value;
            }
        }
    }
}
