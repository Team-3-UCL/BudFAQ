using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ViewModel
{
    class ManualManager
    {
        private Manual _manual;

        public Manual Manual
        {
            get { return _manual; }
            set
            {
                using (SqlConnection connection =
                    new("Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;"))
                {
                    connection.Open();
                    string sCmd = "UPDATE dbo.Manual " +
                                  "SET Title = @title, " +
                                  "Link = @link" +
                                  "WHERE ManualID = @id;";
                    SqlCommand cmd = new(sCmd, connection);
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar);
                    cmd.Parameters["@title"].Value = value.Title;
                    cmd.Parameters.Add("@link", SqlDbType.NVarChar);
                    cmd.Parameters["@link"].Value = value.Link;
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = _manual.ManualID;
                    cmd.ExecuteNonQuery();
                }

                _manual = value;
            }
        }

        public ManualManager()
        {
            using (SqlConnection connection = new("Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;"))
            {
                connection.Open();
                SqlCommand cmd = new("SELECT * FROM dbo.Manual", connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _manual = new()
                    {
                        Link = reader["Link"].ToString(),
                        Title = reader["Title"].ToString(),
                        ManualID = (int) reader["ManualID"]
                    };
                }
            }
        }
    }
}
