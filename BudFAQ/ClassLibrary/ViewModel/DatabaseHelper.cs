using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ViewModel
{
    public class DatabaseHelper
    {
        private readonly string connectionString = "Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;";

        public List<string> GetAllUsedBrakeCalipers()
        {
            List<string> UsedCalipers = new();

            using(SqlConnection connection = new(connectionString))
            {
                string sCmd = "SELECT Name " +
                    "FROM dbo.BrakeCaliper_Article " +
                    "JOIN dbo.BrakeCaliper " +
                    "ON BrakeCaliper_Article.BrakeCaliperID = BrakeCaliper.BrakeCaliperID " +
                    "UNION " + // union giver bare distinct v;rdier
                    "SELECT Name " +
                    "FROM dbo.BrakeCaliper_Video " +
                    "JOIN dbo.BrakeCaliper " +
                    "ON BrakeCaliper_Video.BrakeCaliperID = BrakeCaliper.BrakeCaliperID;";

                connection.Open();
                SqlCommand command = new(sCmd, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UsedCalipers.Add(reader["Word"].ToString());
                    }
                }
            }

            return UsedCalipers;
        }
    }
}
