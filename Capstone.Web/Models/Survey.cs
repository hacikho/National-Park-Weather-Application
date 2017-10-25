using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveryId { get; set; }
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }


        public List<SelectListItem> NationalParks
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "Cuyahoga Valley National Park", Value = "CVNP"},
                    new SelectListItem {Text = "Everglades National Park", Value = "ENP"},
                    new SelectListItem {Text = "Grand Canyon National Park", Value = "GCNP"},
                    new SelectListItem {Text = "Glacier National Park", Value = "GNP"},
                    new SelectListItem {Text = "Great Smoky Mountains National Park", Value = "GSMNP"},
                    new SelectListItem {Text = "Grand Teton National Park", Value = "GTNP"},
                    new SelectListItem {Text = "Mount Rainier National Park", Value = "MRNP"},
                    new SelectListItem {Text = "Rocky Mountain National Park", Value = "RMNP"},
                    new SelectListItem {Text = "Yellowstone National Park", Value = "YNP"},
                    new SelectListItem {Text = "Yosemite National Park", Value = "YNP2"},
                };
            }
        }

        public List<SelectListItem> PhysicalActivityList
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "Inactive", Value = "Inactive"},
                    new SelectListItem { Text = "Sedentary", Value = "Sedentary"},
                    new SelectListItem { Text = "Active", Value = "Active"},
                    new SelectListItem { Text = "Extremely Active", Value = "Extremely Active"}
                };
            }
        }
    }
}