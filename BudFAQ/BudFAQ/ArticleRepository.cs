using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BudFAQ
{
    class ArticleRepository
    {
        private string connectionString = "Server = 10.56.8.36; Database=DB24;User Id = STUDENT24; Password=OPENDB_24;";

        public System.Data.SqlClient.SqlDataReader ExecuteReader { get; }

        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                }
            }
        }


       
   





    }
}
