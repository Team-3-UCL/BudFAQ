using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    class VideoRepository
    {
        private List<Video> videos;
        readonly string connectionString = "Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;";
        public VideoRepository()
        {
            videos = new List<Video>();

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "SELECT * FROM dbo.Video";
                SqlCommand cmd = new(sCmd, connection);
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

                        videos.Add(Video);

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

                        foreach (Video Video in videos)
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
            return videos;
        }

        public void Update(int id, Video updatedVideo)
        {
            for (int i = 0; i < videos.Count; i++)
            {
                if (videos[i].VideoID == id)
                {
                    videos[i] = updatedVideo;
                    break;
                }

            }

            // sql

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "UPDATE dbo.Video " +
                    "SET Title = @title, " +
                    "Length = @length, " +
                    "Link = @link " +
                    "WHERE VideoID = @id";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@title"].Value = updatedVideo.Title;
                cmd.Parameters.Add("@length", System.Data.SqlDbType.Int);
                cmd.Parameters["@length"].Value = updatedVideo.Length;
                cmd.Parameters.Add("@link", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@link"].Value = updatedVideo.Link;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = updatedVideo.VideoID;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Add(string title, int length, string link)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "INSERT INTO dbo.Video(Title, Length, Link) " +
                    "VALUES(@title, @length, @link)";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@title"].Value = title;
                cmd.Parameters.Add("@length", System.Data.SqlDbType.Int);
                cmd.Parameters["@length"].Value = length;
                cmd.Parameters.Add("@link", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@link"].Value = link;
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT TOP 1 * FROM dbo.Video ORDER BY VideoID DESC";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    Video video = new()
                    {
                        VideoID = (int)reader["VideoID"],
                        Title = reader["Title"].ToString(),
                        Length = (int)reader["Length"],
                        Link = reader["Link"].ToString()
                    };
                    videos.Add(video);

                }
            }
        }

        public void Remove(int id)
        {
            for (int i = videos.Count - 1; i != 0; i--)
            {
                if (videos[i].VideoID == id)
                {
                    videos.Remove(videos[i]);
                    break;
                }
            }

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "DELETE FROM dbo.Video " +
                    "WHERE VideoID = @id";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
