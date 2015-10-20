using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckInWeb.Models
{
    public class TopLocationModel
    {
        #region Properties...

        public string LocationName { get; set; }
        public string UserName { get; set; }

        #endregion

        #region Constructors...

        public TopLocationModel() { }

        public TopLocationModel(string location, string user)
        {
            LocationName = location;
            UserName = user;
        }

        #endregion
    }
}