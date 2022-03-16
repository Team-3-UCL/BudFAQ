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
                string sCmd = "SELECT * FROM dbo.Article";
                SqlCommand cmd = new(sCmd, connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Article article = new()
                        {
                            ArticleID = (int)reader["ArticleID"],
                            Title = reader["Title"].ToString(),
                            Text = reader["Text"].ToString(),
                        };

                        articles.Add(article);

                    }
                }

                sCmd = "Select ArticleID, BrakeCaliper_Article.BrakeCaliperID, Name, BudwegNumber FROM dbo.BrakeCaliper_Article " +
                       "JOIN BrakeCaliper " +
                       "ON BrakeCaliper.BrakeCaliperID = BrakeCaliper_Article.BrakeCaliperID";
                cmd = new(sCmd, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = (int)reader["ArticleID"];

                        foreach (Article article in articles)
                        {
                            if (article.ArticleID == Id)
                            {
                                BrakeCaliper brakeCaliper = new()
                                {
                                    BrakeCaliperID = (int)reader["BrakeCaliperID"],
                                    Name = reader["Name"].ToString(),
                                    BudwegNumber = (int)reader["BudwegNumber"]
                                };
                                article.BrakeCalipers.Add(brakeCaliper);
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
                string sCmd = "UPDATE dbo.Article " +
                    "SET Title = @title, " +
                    "Text = @text " +
                    "WHERE ArticleID = @id";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@title"].Value = updatedArticle.Title;
                cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@text"].Value = updatedArticle.Text;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = updatedArticle.ArticleID;
                connection.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM dbo.BrakeCaliper_Article " +
                    "WHERE ArticleID = @id";
                cmd.ExecuteNonQuery();

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                foreach (BrakeCaliper brakeCaliper in updatedArticle.BrakeCalipers)
                {
                    cmd.Parameters["@caliperId"].Value = brakeCaliper.BrakeCaliperID;
                    cmd.CommandText = "INSERT INTO dbo.BrakeCaliper_Article(ArticleID, BrakeCaliperID) " +
                    "(@id, @caliperId)";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Add(string name, string text)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "INSERT INTO dbo.Article(Title, Text) " +
                    "VALUES(@title, @text)";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@title"].Value = name;
                cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@text"].Value = text;
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT TOP 1 * FROM dbo.Article ORDER BY ArticleID DESC";

                // inds;t brake calipers

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int Id = (int)reader["ArticleID"];
                    Article article = new()
                    {
                        ArticleID = Id,
                        Title = name,
                        Text = text
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
                string sCmd = "DELETE FROM dbo.BrakeCaliper_Article " +
                    "WHERE ArticleID = @id";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                connection.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM dbo.Article " +
                    "WHERE ArticleID = @id";
                cmd.ExecuteNonQuery();
            }
        }
    }
}


