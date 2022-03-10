using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;

namespace ViewModel
{
    class ArticleRepository
    {
        private List<Article> articles;
        readonly string connectionString = "Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;";
        public ArticleRepository()
        {
            articles = new List<Article>();

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "SELECT * FROM dbo.Artikel";
                SqlCommand cmd = new(sCmd, connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {              
                        Article article = new() {
                            ArticleID = (int)reader["ArtikelID"],
                            Name = reader["Title"].ToString(),
                            Text = reader["Content"].ToString(),
                            Link = reader["Link"].ToString()
                        };

                        articles.Add(article);

                    }
                }

                sCmd = "Select * FROM dbo.Keywords_Artikel";
                cmd = new(sCmd, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = (int)reader["ArtikelID"];
                        string word = reader["Word"].ToString();

                        foreach(Article article in articles)
                        {
                            if(article.ArticleID == Id)
                            {
                                article.Keywords.Add(word);
                                break;
                            }

                        }

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




