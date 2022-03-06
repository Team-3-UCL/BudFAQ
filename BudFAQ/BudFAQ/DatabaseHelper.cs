using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BudFAQ
{
    public class DatabaseHelper
    {
        private readonly string connectionString = "Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;";

        public List<string> getAllUsedKeywords()
        {
            List<string> UsedKeywords = new();

            using(SqlConnection connection = new(connectionString))
            {
                string sCmd = "SELECT Word " +
                    "FROM dbo.Keywords_Artikel " +
                    "UNION " +
                    "SELECT Word " +
                    "FROM DBO.Keywords_Video;";

                connection.Open();
                SqlCommand command = new(sCmd, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UsedKeywords.Add(reader["Word"].ToString());
                    }
                }
            }

            return UsedKeywords;
        }
    }
}
