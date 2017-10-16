using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Cat
    {
        private String breed;
        private String name;
        private String details;

        public Cat(string breed, string name, string details)
        {
            this.breed = breed;
            this.name = name;
            this.details = details;
        }

        public string Breed
        {
            get
            {
                return breed;
            }

            set
            {
                breed = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }




    }
}
