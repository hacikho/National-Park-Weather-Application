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
    }
}