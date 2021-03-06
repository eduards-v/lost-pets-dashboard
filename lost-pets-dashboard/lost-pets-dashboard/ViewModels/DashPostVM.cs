﻿using lost_pets_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lost_pets_dashboard.ViewModels
{
    class DashPostVM : NotificationBase<Dashpost>
    {
        public DashPostVM(Dashpost dashPost = null) : base(dashPost) { }

        public String Title
        {
            get { return This.Title; }
            set { SetProperty(This.Title, value, () => This.Title = value); }
        }
        public String Description
        {
            get { return This.Description; }
            set { SetProperty(This.Description, value, () => This.Description = value); }
        }

    }
}
