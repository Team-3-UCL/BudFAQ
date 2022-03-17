using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    class BrakeCaliperRepository
    {
        private List<BrakeCaliper> BrakeCalipers;
        readonly string connectionString = "Server = 10.56.8.36; Database=P1DB03;User Id = P1-03; Password=OPENDB_03;";
        public BrakeCaliperRepository()
        {
            BrakeCalipers = new List<BrakeCaliper>();

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "SELECT * FROM dbo.BrakeCaliper";
                SqlCommand cmd = new(sCmd, connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BrakeCaliper BrakeCaliper = new()
                        {
                            BrakeCaliperID = (int)reader["BrakeCaliperID"],
                            Name = reader["Name"].ToString(),
                            BudwegNumber = int.Parse(reader["BudwegNumber"].ToString()),
                        };
                        BrakeCalipers.Add(BrakeCaliper);
                    }
                }
            }
        }

        public List<BrakeCaliper> GetAll()
        {
            return BrakeCalipers;
        }

        public void Update(int id, BrakeCaliper updatedBrakeCaliper)
        {
            for (int i = 0; i < BrakeCalipers.Count; i++)
            {
                if (BrakeCalipers[i].BrakeCaliperID == id)
                {
                    BrakeCalipers[i] = updatedBrakeCaliper;
                    break;
                }

            }

            // sql

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "UPDATE dbo.BrakeCaliper " +
                    "SET Name = @name, " +
                    "BudwegNumber = @number " +
                    "WHERE BrakeCaliperID = @id";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@name"].Value = updatedBrakeCaliper.Name;
                cmd.Parameters.Add("@number", System.Data.SqlDbType.Int);
                cmd.Parameters["@number"].Value = updatedBrakeCaliper.BudwegNumber;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = updatedBrakeCaliper.BrakeCaliperID;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Add(string name, int budwegNumber)
        {
            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "INSERT INTO dbo.BrakeCaliper(Name, BudwegNumber) " +
                    "VALUES(@name, @number)";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@name"].Value = name;
                cmd.Parameters.Add("@number", System.Data.SqlDbType.Int);
                cmd.Parameters["@number"].Value = budwegNumber;
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT TOP 1 * FROM dbo.BrakeCaliper ORDER BY BrakeCaliperID DESC";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    BrakeCaliper BrakeCaliper = new()
                    {
                        BrakeCaliperID = (int)reader["BrakeCaliperID"],
                        Name = reader["Name"].ToString(),
                        BudwegNumber = (int)reader["BudwegNumber"]
                    };
                    BrakeCalipers.Add(BrakeCaliper);
                }
            }
        }

        public void Remove(int id)
        {
            for (int i = BrakeCalipers.Count - 1; i != 0; i--)
            {
                if (BrakeCalipers[i].BrakeCaliperID == id)
                {
                    BrakeCalipers.Remove(BrakeCalipers[i]);
                    break;
                }
            }

            using (SqlConnection connection = new(connectionString))
            {
                string sCmd = "DELETE FROM dbo.BrakeCaliper_Article " +
                    "WHERE BrakeCaliperID = @id";
                SqlCommand cmd = new(sCmd, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                connection.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM dbo.BrakeCaliper_Video " +
                    "WHERE BrakeCaliperID = @id";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM dbo.BrakeCaliper " +
                    "WHERE BrakeCaliperID = @id";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
