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
                        Article article = new()
                        {
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

                        foreach (Article article in articles)
                        {
                            if (article.ArticleID == Id)
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

        public void Update(int id, Article updatedArticle)
        {
            for (int i = 0; i < articles.Count; i++)
            {
                if (articles[i].ArticleID == id)
                {
                    articles[i] = updatedArticle;
                    break;
                }

            }

            // sql

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "UPDATE dbo.Artikel " +
                    "SET Title = @title, " +
                    "Content = @text, " +
                    "Link = @link " +
                    "WHERE ArtikelID = @id";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@title"].Value = updatedArticle.Name;
                cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@text"].Value = updatedArticle.Text;
                cmd.Parameters.Add("@link", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@link"].Value = updatedArticle.Link;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = updatedArticle.ArticleID;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Add(string name, string text, string link)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "INSERT INTO dbo.Artikel(Title, Content, Link) " +
                    "VALUES(@title, @text, @link)";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@title"].Value = name;
                cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@text"].Value = text;
                cmd.Parameters.Add("@link", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@link"].Value = link;
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT TOP 1 * FROM dbo.Artikel ORDER BY ArtikelID DESC";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int Id = (int)reader["ArtikelID"];
                    Article article = new()
                    {
                        ArticleID = Id,
                        Name = name,
                        Text = text,
                        Link = link
                    };
                    articles.Add(article);

                }
            }
        }

        public void Remove(int id)
        {
            for(int i = articles.Count - 1; i != 0; i--)
            {
                if (articles[i].ArticleID == id)
                {
                    articles.Remove(articles[i]);
                    break;
                }
            }

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "DELETE FROM dbo.Artikel " +
                    "WHERE ArtikelID = @id";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}


