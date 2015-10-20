using CheckInWeb.Data.Entities;
using CheckInWeb.Data.Repositories;
using CheckInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckInWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var locationRepository = new LocationRepository();
            var locations = locationRepository.GetLocations()
                                              .OrderByDescending(x => x.CheckIns.Count)
                                              .Take(10);

            List<TopLocationModel> topLocationModels = new List<TopLocationModel>();
            foreach (Location location in locations)
            {
                var result = (from c in location.CheckIns
                              group c by c.User
                              into checkInsByUser
                              orderby checkInsByUser.Count() descending
                              select checkInsByUser.Key.UserName).FirstOrDefault();
                result = result != null ? result : "No users have checked in";
                topLocationModels.Add(new TopLocationModel(location.Name, result));
            }

            return View(new HomeViewModel(topLocationModels));
        }
    }
}