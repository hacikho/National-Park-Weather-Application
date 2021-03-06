﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkDAL
    {
        List<Park> GetAllParks();
        Park GetSinglePark(string parkcode);
        List<Weather> GetAllWeather(string parkcode);
        bool SaveSurvey(Survey newSurvey);
        List<Survey> GetAllSurveys();

    }
}
