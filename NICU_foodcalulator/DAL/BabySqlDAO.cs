using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using NICU_foodcalculator.Models;

namespace NICU_foodcalculator.DAL
{
    public class BabySqlDAO : IBabyDAO
    {
        private string connectionString;

        public BabySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Baby> ViewListofInfants()
        {
            List<Baby> babyList = new List<Baby>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Baby;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Baby bby= ConvertReaderToBaby(reader);
                        babyList.Add(bby);
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error occured when reading database. Please try again");
            }


            return babyList;
        }

        private Baby ConvertReaderToBaby(SqlDataReader reader)
        {
            Baby baby = new Baby();

            baby.BabyId = Convert.ToInt32(reader["id"]);
            baby.FirstName = Convert.ToString(reader["firstname"]);
            baby.LastName = Convert.ToString(reader["lastname"]);
            baby.BirthWeight = Convert.ToDecimal(reader["birthweight"]);
            baby.BirthDate = Convert.ToDateTime(reader["birthdate"]);
            baby.CurrentWeight = Convert.ToDecimal(reader["todayweight"]);
            baby.CurrentDate = Convert.ToDateTime(reader["todaydate"]);
            baby.FoodMouth = Convert.ToDecimal(reader["foodMouth"]);
            baby.MouthCalorie = Convert.ToDecimal(reader["foodMouthCal"]);
            baby.FoodTube = Convert.ToDecimal(reader["foodTube"]);
            baby.FoodIV = Convert.ToDecimal(reader["foodIV"]);

            return baby;
        }
    }
}
