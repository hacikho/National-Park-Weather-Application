using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL dal;
        
        public HomeController(IParkDAL dal)
        {
            this.dal = dal;
        }
        // GET: Home
        public ActionResult Index()
        {
            var allParks = dal.GetAllParks();
            return View("Index", allParks);
        }

        public ActionResult Detail(string parkCode = "")
        {
            Park onePark = new Park();

            onePark = dal.GetSinglePark(parkCode);
            onePark.Weather = dal.GetAllWeather(parkCode);

            if (onePark == null)
            {
                return HttpNotFound();
            }

            return View("Detail", onePark);
        }
        
        public ActionResult TakeSurvey()
        {
            return View("TakeSurvey");
        }
  
    }
}