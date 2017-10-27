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

        public ActionResult Detail(string parkCode, string choiceTemp)
        {
            if (!String.IsNullOrEmpty(choiceTemp))
            {

                Session["temperature"] = choiceTemp;
            }
            Park onePark = new Park();
            WeatherChoice weathers = new WeatherChoice();

            weathers.ChoiceTemp = Session["temperature"] as string;
            onePark = dal.GetSinglePark(parkCode);
            onePark.Weather = dal.GetAllWeather(parkCode);

            if (onePark == null)
            {
                return HttpNotFound();
            }

            var tuple = new Tuple<Park, WeatherChoice>(onePark, weathers);

            return View("Detail", tuple);
        }

        [HttpGet]
        public ActionResult TakeSurvey()
        {
            Survey model = new Survey();
            return View("TakeSurvey", model);
        }

        [HttpPost]
        public ActionResult TakeSurvey(Survey completedSurvey)
        {
            dal.SaveSurvey(completedSurvey);
            return RedirectToAction("SurveyResult");
        }

        [HttpGet]
        public ActionResult SurveyResult()
        {
            var something = dal.GetAllSurveys();
            return View("SurveyResult", something);
        }
  
    }
}