using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace pvrocnikovka
{
    public class DatabaseConnect
    {
        private string _connectionString;

        public string ConnectionString { get; internal set; }

        public DatabaseConnect(string server, string database, string username, string password)
        {
            _connectionString = $"server={server};user id={username};password={password};database={database}";
        }

        public void TestConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        public void ExecuteQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + "\t");
                        }
                        Console.WriteLine();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
