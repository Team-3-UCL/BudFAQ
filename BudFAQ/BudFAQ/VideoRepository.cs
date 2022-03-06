using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudFAQ
{
    class VideoRepository
    {
        private List<Video> Videos;
        string connectionString = "Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;";
        public VideoRepository()
        {
            Videos = new List<Video>();

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "SELECT * FROM dbo.Video";
                SqlCommand cmd = new SqlCommand(sCmd, connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Video Video = new()
                        {
                            VideoID = (int)reader["VideoID"],
                            Title = reader["Title"].ToString(),
                            Length = int.Parse(reader["Length"].ToString()),
                            Link = reader["Link"].ToString()
                        };

                        Videos.Add(Video);

                    }
                }

                sCmd = "Select * FROM dbo.Keywords_Video";
                cmd = new(sCmd, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = (int)reader["VideoID"];
                        string word = reader["Word"].ToString();

                        foreach (Video Video in Videos)
                        {
                            if (Video.VideoID == Id)
                            {
                                Video.Keywords.Add(word);
                                break;
                            }

                        }

                    }
                }


            }
        }

        public List<Video> GetAll()
        {
            return Videos;
        }


    }
}
