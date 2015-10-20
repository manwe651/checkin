using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckInWeb.Models
{
    using CheckInWeb.Data.Entities;

    public class MyCheckInViewModel
    {
        public List<Location> Locations { get; set; } 
    }
}