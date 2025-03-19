using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ClubPilot
{
    internal class DatabaseConnection
    {
        private string connectionString = "server=localhost;database=clubpilot;user=root;password=12345;";
        private MySqlConnection connection;

        public DatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool Login(string username, string password)
        {
            bool isValidUser = false;
            bool isAdmin = false;

            try
            {
                OpenConnection();
                string query = @"
                   use clubpilot;
		           SELECT u.id, a.id_usuari AS id_usuari 
		           FROM usuari u 
		           LEFT JOIN administrador a ON u.id = a.id_usuari
                   WHERE u.username = @username AND u.password = @password;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isValidUser = true;
                            isAdmin = !reader.IsDBNull(reader.GetOrdinal("admin_id")); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en el login: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return isValidUser;
        }
    }
}
