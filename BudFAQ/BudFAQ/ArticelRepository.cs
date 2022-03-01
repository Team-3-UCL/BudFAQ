using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BudFAQ
{
    class ArticelRepository
    {
        public ArticelRepository()
        {
            // l;ser alle artikler som er i databasen
            // tilf'jer den til articles i repoen
        }


        public static void ReadOrderData(string connectionStringm)
        {
            

            string queryString =
                "SELECT City FROM dbo.CINEMA WHERE CinemaID = 3;";

            using (SqlConnection connection =
                       new SqlConnection(connectionStringm))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                    
                }

                // Call Close when done reading.
                reader.Close();
            }
        }

        private List<Article> _articles;
        string connectionString = "Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;";
        public ArticelRepository()
        {
            _articles = new List<Article>();


            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "SELECT * FROM dbo.Artikel";
                SqlCommand cmd = new SqlCommand(sCmd, connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {              
                        Article article = new();
                        article.Name = reader["ArticleName"].ToString();
                        article.Text = reader["ArticleText"].ToString();
                        article.Link = reader["ArticleLink"].ToString();

                        _articles.Add(article);

                    }
                }


            }
        }




    }
}




