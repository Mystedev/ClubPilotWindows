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
            try
            {
                OpenConnection();
                string query = "SELECT * FROM `usuari` WHERE `username` = @username AND `password` = @password;";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        isValidUser = reader.HasRows;
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

        public DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ejecutando consulta: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
    }
}
