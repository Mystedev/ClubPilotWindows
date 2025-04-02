using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace ClubPilot
{
    class Connection
    {
        private string server = "localhost";
        private string database = "clubpilot";
        private string port = "3306";
        private string user_id = "root";
        private string password = "root";
        private MySqlConnection connection;

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
            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";
            connection = new MySqlConnection(connectionString);
        }

        // Metodo para abrir la conexión
        public void OpenConnection()
        {
            try
            {
               connection.Open();
               // MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó: " + ex.Message);
            }
        }

        // Metodo para cerrar la conexión
        public void CloseConnection()
        {
            try
            {
               connection.Close();
               // MessageBox.Show("Conexión cerrada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
            }
        }

        // Metodo para exportar la base de datos a un .txt
        public void exportNoticia()
        {
            string selectClub = "SELECT * FROM club";
            string selectEquip = "SELECT * FROM equip";
            string selecteEsdeveniment = "SELECT * FROM esdeveniment";
            string selectNoticia = "SELECT * FROM noticia";
            string selectTipusEsdeveniment = "SELECT * FROM tipus_esdeveniment";
            string selectUsuari = "SELECT * FROM usuari";

            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";

            string filePath = "C:\\Intel\\exportedNoticia.txt";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(selectNoticia, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        while (reader.Read())
                        {
                            string line = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                line += reader[i].ToString() + "#"; // Separa por tabulaciones
                            }
                            writer.WriteLine(line.Trim());
                        }
                    }
                }

                MessageBox.Show("Exportación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }
        public void exportClub()
        {
            string selectClub = "SELECT * FROM club";
            string selectEquip = "SELECT * FROM equip";
            string selecteEsdeveniment = "SELECT * FROM esdeveniment";
            string selectNoticia = "SELECT * FROM noticia";
            string selectTipusEsdeveniment = "SELECT * FROM tipus_esdeveniment";
            string selectUsuari = "SELECT * FROM usuari";

            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";
           
            string filePath = "C:\\Intel\\exportedClub.txt";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(selectClub, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        while (reader.Read())
                        {
                            string line = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                line += reader[i].ToString() + "#"; // Separa por tabulaciones
                            }
                            writer.WriteLine(line.Trim());
                        }
                    }
                }

                MessageBox.Show("Exportación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }
        public void exportedEquip()
        {
            string selectClub = "SELECT * FROM club";
            string selectEquip = "SELECT * FROM equip";
            string selecteEsdeveniment = "SELECT * FROM esdeveniment";
            string selectNoticia = "SELECT * FROM noticia";
            string selectTipusEsdeveniment = "SELECT * FROM tipus_esdeveniment";
            string selectUsuari = "SELECT * FROM usuari";

            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";

            string filePath = "C:\\Intel\\exportedEquip.txt";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(selectNoticia, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        while (reader.Read())
                        {
                            string line = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                line += reader[i].ToString() + "#"; // Separa por tabulaciones
                            }
                            writer.WriteLine(line.Trim());
                        }
                    }
                }

                MessageBox.Show("Exportación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }
        public void exportEsdeveniment()
        {
            string selectClub = "SELECT * FROM club";
            string selectEquip = "SELECT * FROM equip";
            string selecteEsdeveniment = "SELECT * FROM esdeveniment";
            string selectNoticia = "SELECT * FROM noticia";
            string selectTipusEsdeveniment = "SELECT * FROM tipus_esdeveniment";
            string selectUsuari = "SELECT * FROM usuari";

            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";

            string filePath = "C:\\Intel\\exportedEsdeveniments.txt";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(selectNoticia, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        while (reader.Read())
                        {
                            string line = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                line += reader[i].ToString() + "#"; // Separa por tabulaciones
                            }
                            writer.WriteLine(line.Trim());
                        }
                    }
                }

                MessageBox.Show("Exportación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }
        public void exportTipusEsdeveniment()
        {
            string selectClub = "SELECT * FROM club";
            string selectEquip = "SELECT * FROM equip";
            string selecteEsdeveniment = "SELECT * FROM esdeveniment";
            string selectNoticia = "SELECT * FROM noticia";
            string selectTipusEsdeveniment = "SELECT * FROM tipus_esdeveniment";
            string selectUsuari = "SELECT * FROM usuari";

            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";

            string filePath = "C:\\Intel\\exportedTipusEsdeveniment.txt";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(selectNoticia, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        while (reader.Read())
                        {
                            string line = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                line += reader[i].ToString() + "#"; // Separa por tabulaciones
                            }
                            writer.WriteLine(line.Trim());
                        }
                    }
                }

                MessageBox.Show("Exportación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }
        public String[] Login(string username, string password)
        {
            OpenConnection();
            String result = "";
            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";
            List<string> results = new List<string>();
            try
            {


                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                     
                    
                 
                string query = @"
                  SELECT u.id
                  FROM usuari u 
                  LEFT JOIN administrador a ON u.id = a.id_usuari
                  WHERE u.username = @username AND u.password = @password;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                        // Ejecutar la consulta y obtener el valor directamente
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        
                            result = reader.GetInt32(0)+""; 
                            results.Add(result);
                    }
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de error, capturamos y mostramos el error
                Console.WriteLine($"Error en el login: {ex.Message}");
                result = "Error";
            }
            finally
            {
                CloseConnection();
            }
            return results.ToArray();
        }
        public String ClubsDeUsuari(string idUsuari)
        {
            string line = "";
            try
            {
                OpenConnection();
                string query = @"
		           SELECT c.nom, c.id
                   FROM club c 
                   LEFT JOIN administrador a ON a.id_club = c.id
                   WHERE a.id_usuari = @username;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", idUsuari);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                         
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                line += reader[i].ToString() + "$"; // Separa por tabulaciones
                            }
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
            return line;
        }
        public string CrearClub(string nom, string anyDeFundacio, string fundador, string logo)
        {
            string resultado = "Club creado correctamente";
            try
            {
                OpenConnection();
                string query = @"
            INSERT INTO club (nom, any_fundacio, fundador, logo, registre)
            VALUES (@nom, @anyDeFundacio, @fundador, @logo, 0);";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@anyDeFundacio", anyDeFundacio);
                    cmd.Parameters.AddWithValue("@fundador", fundador);
                    cmd.Parameters.AddWithValue("@logo", logo);

                    int filasAfectadas = cmd.ExecuteNonQuery(); 

                    if (filasAfectadas == 0)
                    {
                        resultado = "No se pudo crear el club.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = $"Error al crear el club: {ex.Message}";
            }
            finally
            {
                CloseConnection();
            }
            return resultado;
        }
        public String EquipsDeClub(string idClub)
        {
            String line = "";
            try
            {
                OpenConnection();
                string query = @"
		           SELECT e.nom 
		           FROM Equip e 
                   WHERE e.id = @username;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", idClub);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                line += reader[i].ToString() + "$"; 
                            }
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
            return line;
        }
        public void exportUsuari()
        {
            string selectClub = "SELECT * FROM club";
            string selectEquip = "SELECT * FROM equip";
            string selecteEsdeveniment = "SELECT * FROM esdeveniment";
            string selectNoticia = "SELECT * FROM noticia";
            string selectTipusEsdeveniment = "SELECT * FROM tipus_esdeveniment";
            string selectUsuari = "SELECT * FROM usuari";

            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";

            string filePath = "C:\\Intel\\exportedUsuari.txt";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(selectNoticia, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        while (reader.Read())
                        {
                            string line = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                line += reader[i].ToString() + "#"; // Separa por tabulaciones
                            }
                            writer.WriteLine(line.Trim());
                        }
                    }
                }

                MessageBox.Show("Exportación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }
    }
}
