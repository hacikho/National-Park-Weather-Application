﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string ParkCode { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public int MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }

        public List<Weather> Weather { get; set; } = new List<Weather>();

    }
}