using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubPilot
{
    class Connection
    {
        private string server = "localhost";
        private string database = "clubpilot";
        private string port = "3306";
        private string user_id = "root";
        private string password = "1234";
        //private MySqlConnection connection;

        // Constructor por defecto
        public Connection()
        {
            InitializeConnection();
        }

        // Constructor con parámetro de base de datos
        public Connection(string database)
        {
            this.database = database;
            InitializeConnection();
        }

        // Constructor con todos los parámetros
        public Connection(string server, string database, string port, string user_id, string password)
        {
            this.server = server;
            this.database = database;
            this.port = port;
            this.user_id = user_id;
            this.password = password;
            InitializeConnection();
        }

        // Método para inicializar la conexión
        private void InitializeConnection()
        {
            //string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";
            //connection = new MySqlConnection(connectionString);
        }

        // Método para abrir la conexión
        public void OpenConnection()
        {
            try
            {
                //connection.Open();
                MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó: " + ex.Message);
            }
        }

        // Método para cerrar la conexión
        public void CloseConnection()
        {
            try
            {
                //connection.Close();
                MessageBox.Show("Conexión cerrada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}
