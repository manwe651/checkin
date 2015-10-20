using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckInWeb.Models
{
    public class HomeViewModel
    {
        #region Properties...

        public List<TopLocationModel> TopLocations { get; set; }

        #endregion

        #region Constructors...

        public HomeViewModel()
        {
            TopLocations = new List<TopLocationModel>();
        }

        public HomeViewModel(List<TopLocationModel> locations)
        {
            TopLocations = locations;
        }

        #endregion
    }
}