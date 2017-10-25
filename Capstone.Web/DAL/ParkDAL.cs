using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkDAL : IParkDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["npgeek"].ConnectionString;
        const string SQL_GetAllParks = "Select * from park";
        const string SQL_GetSinglePark = "select * from park where park.parkCode = @parkCode";
        const string SQL_GetAllWeather = "select park.*, weather.* from park Join weather on weather.parkCode = park.parkCode where weather.parkCode = @parkCode";



        public List<Park> GetAllParks()
        {
            List<Park> output = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Park p = new Park();
                        p.Name = Convert.ToString(reader["parkName"]);
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Description = Convert.ToString(reader["parkDescription"]);
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        
                        output.Add(p);
                    }
                }
                return output;
            }
            catch(SqlException ex)
            {
                throw;
            }

        }

        public Park GetSinglePark(string parkcode)
        {
            Park np = null;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkcode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park p = new Park();
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.Name = Convert.ToString(reader["parkName"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.Description = Convert.ToString(reader["parkDescription"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        np = p;
                    }
                }

                return np;
            }catch(SqlException ex)
            {
                throw;
            }
        }

        public List<Weather> GetAllWeather(string parkcode)
        {
           List<Weather> weath = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllWeather, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkcode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather p = new Weather();
                        p.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        p.Low = Convert.ToInt32(reader["low"]);
                        p.High = Convert.ToInt32(reader["high"]);
                        p.Forecast = Convert.ToString(reader["forecast"]);

                        weath.Add(p);
                    }
                }

                return weath;
            }
            catch (SqlException ex)
            {
                throw;
            }

        }


    }
}