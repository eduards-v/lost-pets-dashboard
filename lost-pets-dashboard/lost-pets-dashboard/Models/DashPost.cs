﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.Models
{
    class Dashpost
    {
        private string title;
        private string description;


        public Dashpost() { }
        public Dashpost(string title, string description)
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

    }
}
