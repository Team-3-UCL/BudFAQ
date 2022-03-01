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
        private List<Article> articles;
        string connectionString = "Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;";
        public ArticelRepository()
        {
            articles = new List<Article>();

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

                        articles.Add(article);

                    }
                }
            }
        }
    
        public List<Article> GetAll()
        {
            return articles;
        }
    }
}




