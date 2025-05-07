using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClubPilot
{
    class Connection
    {
        private string server = "192.168.1.150";
        private string database = "clubPilot";
        private string port = "25230";
        private string user_id = "clubPilot";
        private string password = "ABCD!!25230";

        private static MySqlConnection connection;

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
        //Funcion que uso en News_Tab.cs cargar las noticias de la db a la lista de noticias
        public List<News> exportNews()
        {
            List<News> noticias = new List<News>();
            string selectNoticia = "SELECT * FROM noticia";
            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(selectNoticia, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        News news = null;
                        while (reader.Read())
                        {
                            string line = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                DateTime fecha = reader.GetDateTime(5);
                                news = new News(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), fecha);
                                news.id = (int)reader[0];
                                news.idUsuari = (int)reader[7];
                                news.idClub = (int)reader[6];
                                line += reader[i].ToString() + "#"; // Separa por tabulaciones
                                


                            }
                            noticias.Add(news);
                        }
                    }
                }

                MessageBox.Show("Exportación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
            return noticias;
        }
        //Export de esdeveniments
        public List<Esdeveniment> exportEsdeveniments()
        {
            List<Esdeveniment> esdeveniments = new List<Esdeveniment>();
            string selectEsdeveniment = "SELECT * FROM esdeveniment";
            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(selectEsdeveniment, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Esdeveniment esd= null;
                        while (reader.Read())
                        {
                            string line = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                DateTime fecha = reader.GetDateTime(5);
                                esd = new Esdeveniment(reader[3].ToString(), reader[4].ToString(), fecha );
                                esd.id = (int)reader[0];
                                esd.id_usuari = (int)reader[1];
                                esd.id_equip = (int)reader[2];
                                esd.description = reader[4].ToString();

                                line += reader[i].ToString() + "#"; // Separa por tabulaciones


                            }
                            esdeveniments.Add(esd);


                        }
                    }
                }

                MessageBox.Show("Exportación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
            return esdeveniments;
        }
        //AÑADIR NOTICIAS
        public static void addNew(News noticia)
        {
            try
            {
                OpenConnection();
                string query = @"


                INSERT INTO noticia(titol, descripcio, imatge_noticia, data, id_usuari, id_club)
                VALUES(@titulo, @descripcio, @imatge_noticia, @data, @id_usuari, @id_club); ";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@titulo", noticia.Titulo);
                    cmd.Parameters.AddWithValue("@descripcio", noticia.Texto);
                    cmd.Parameters.AddWithValue("@data", noticia.Fecha);
                    cmd.Parameters.AddWithValue("@imatge_noticia", noticia.Imagen);
                    cmd.Parameters.AddWithValue("@id_usuari", noticia.idUsuari);
                    cmd.Parameters.AddWithValue("@id_club", noticia.idClub);


                    int filasAfectadas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar noticia: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //ACTUALIZAR NOTICIAS
        public static void updateNews(News noticia)
        {
            try
            {
                OpenConnection();
                string query = @"
                UPDATE noticia
                SET 
                titol = @titulo,
                descripcio = @descripcio,
                imatge_noticia = @imatge_noticia,
                data = @data,
                id_Club = @id_club,
                id_usuari = @id_usuari

                WHERE id = @id;";
                //INSERT INTO noticia (titol, descripcio, autor, imatge_noticia, data) 
                //VALUES (@titulo, @descripcio, @autor,  @imatge_noticia, @data);";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@titulo", noticia.Titulo);
                    cmd.Parameters.AddWithValue("@descripcio", noticia.Texto);
                    cmd.Parameters.AddWithValue("@data", noticia.Fecha);
                    cmd.Parameters.AddWithValue("@imatge_noticia", noticia.Imagen);
                    cmd.Parameters.AddWithValue("@id_usuari", noticia.idUsuari);
                    cmd.Parameters.AddWithValue("@id_club", noticia.idClub);
                    cmd.Parameters.AddWithValue("@id", noticia.id);


                    int filasAfectadas = cmd.ExecuteNonQuery();
                    //if (filasAfectadas > 0)
                    //{
                    //    MessageBox.Show("Noticia desada");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Error");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar noticia: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //BORRAR NOTICIAS
        public static void deleteNew(News noticia)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM noticia WHERE id = @id";


                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", noticia.id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar noticia: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //MODIFICAR EVENTOS
        public static void updateEsdeveniment(Esdeveniment esd)
        {
            try
            {
                OpenConnection();
                string query = @"
                UPDATE noticia
                SET 
                id_usuari = @id_usuari,
                id_equip = @id_equip,
                tipus_esdeveniment = @tipus_esdeveniment,
                descripcio = @descripcio,
                data = @data,

                WHERE id = @id;";

                //INSERT INTO noticia (titol, descripcio, autor, imatge_noticia, data) 
                //VALUES (@titulo, @descripcio, @autor,  @imatge_noticia, @data);";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_usuari", esd.id_usuari);
                    cmd.Parameters.AddWithValue("@id_equip", esd.id_equip);
                    cmd.Parameters.AddWithValue("@tipus_esdeveniment", esd.tipus_esdeveniment);
                    cmd.Parameters.AddWithValue("@descripcio", esd.description);
                    cmd.Parameters.AddWithValue("@data", esd.data);


                    int filasAfectadas = cmd.ExecuteNonQuery();
                    //if (filasAfectadas > 0)
                    //{
                    //    MessageBox.Show("Noticia desada");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Error");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar noticia: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //AÑADIR ESDEVENIMENT
        public static void addEvent(Esdeveniment esd)
        {
            try
            {
                OpenConnection();
                string query = @"


                INSERT INTO esdeveniment(id_usuari, id_equip, tipus_esdeveniment, descripcio, data)
                VALUES(@id_usuari, @id_equip, @tipus_esdeveniment, @descripcio, @data); ";
                //INSERT INTO noticia (titol, descripcio, autor, imatge_noticia, data) 
                //VALUES (@titulo, @descripcio, @autor,  @imatge_noticia, @data);";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_usuari", esd.id_usuari);
                    cmd.Parameters.AddWithValue("@id_equip", esd.id_equip);
                    cmd.Parameters.AddWithValue("@tipus_esdeveniment", esd.tipus_esdeveniment);
                    cmd.Parameters.AddWithValue("@descripcio", esd.description);
                    cmd.Parameters.AddWithValue("@data", esd.data);


                    int filasAfectadas = cmd.ExecuteNonQuery();
                    //if (filasAfectadas > 0)
                    //{
                    //    MessageBox.Show("Noticia desada");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Error");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar evento: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //BORRAR ESDEVENIMENT
        public static void deleteEsdeveniment(Esdeveniment  esd)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM esdeveniment WHERE id = @id";



                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", esd.id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar noticia: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Método para inicializar la conexión
        private void InitializeConnection()
        {
        
            string connectionString = $"Server={server};Database={database};Port={port};User Id={user_id};Password={password};";
            connection = new MySqlConnection(connectionString);
        }

        // Metodo para abrir la conexión
        public static void OpenConnection()
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
        public static void CloseConnection()
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
        public String[] Login(string username, string passwordU)
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
                    passwordU = CalcularSHA256(passwordU);
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", passwordU);

                        // Ejecutar la consulta y obtener el valor directamente
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {

                            result = reader.GetInt32(0) + "";
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

        public List<Dictionary<string, object>> ClubsDeUsuari(string idUsuari)
        {
            string line = "";
            int id=int.Parse(idUsuari);
            OpenConnection();
            bool [] rol=ObtenerRol(id);
            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();
            if (rol[0] == true)
            {
            try
            {
              
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

                        Dictionary<string, object> registro = new Dictionary<string, object>
                        {
                        { "idClub", reader["id"] },
                        { "nomClub", reader["nom"] }
                        };
                            resultados.Add(registro);
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
            }
            else
            { 
            try
            {
                string query = @"
		           SELECT eq.nom, eq.id, c.nom as nom_club, c.id as id_club
                   FROM equip eq 
                   LEFT JOIN entrenador e ON e.id_equip = eq.id
                   LEFT JOIN club c ON c.id = eq.id_club 
                   WHERE e.id_usuari = @username;";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", idUsuari);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> registro = new Dictionary<string, object>
                            {
                                { "nomequip", reader["nom"] },
                                { "idEquip", reader["id"] },
                                { "idClub", reader["id_club"]},
                                { "nomClub", reader["nom_club"]}
                            };
                            resultados.Add(registro);
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
            }

            return resultados;
        }
        public string CrearClub(string nom, string anyDeFundacio, string fundador, string email, string logo)
        {
            string resultado = "Club creado correctamente";
            int idClub=0;
            try
            {
                OpenConnection();
                string query = @"
                INSERT INTO club (nom, any_fundacio, fundador, emailfundador, logo, registre)
                VALUES (@nom, @anyDeFundacio, @fundador,@email, @logo, 0);
                SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@anyDeFundacio", anyDeFundacio);
                    cmd.Parameters.AddWithValue("@fundador", fundador);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@logo", logo);


                    idClub = Convert.ToInt32(cmd.ExecuteScalar());

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
            return idClub+"";
        }
        public string UpdateClub(string id)
        {
            string resultado = "Club creado correctamente";
            try
            {
                OpenConnection();
                string query = @"
                UPDATE club 
                SET 
                registre = 1
                WHERE id = @id;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        resultado = "No se pudo crear el club.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = $"Error al actualizar el club: {ex.Message}";
            }
            finally
            {
                CloseConnection();
            }
            return resultado;
        }

        public void DeleteClub(string id)
        {
            {
                try
                {
                    OpenConnection();  
                    string query = @"
                    DELETE FROM club
                    WHERE id = @id;";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@id", id);

                        // Ejecutar la consulta
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Verificar si se actualizó algún registro
                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("El registro ha sido borrado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún registro para borrar");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el registro: {ex.Message}");
                }
                finally
                {
                    CloseConnection();  
                }
            }
        }
        public List<Dictionary<string, object>> SelectClubs()
        {
            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();

            try
            {
                OpenConnection();
                string query = @"
                  SELECT c.id, c.nom, c.any_fundacio, c.fundador, c.logo, c.emailfundador,c.registre
                  FROM club c
                  ";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> registro = new Dictionary<string, object>
                    {
                        { "id", reader["id"] },
                        { "nom", reader["nom"] },
                        { "any_fundacio", reader["any_fundacio"] },
                        { "fundador", reader["fundador"] },
                        { "logo", reader["logo"] },
                        { "emailfundador", reader["emailfundador"] },
                        {"registre", reader["registre"] }
                    };
                        resultados.Add(registro);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los registros: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }

            return resultados;
        }

        public List<Dictionary<string, object>> SelectComptes()
        {
            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();

            try
            {
                OpenConnection();

                // Obtener todos los usuarios
                string query = @"
            SELECT u.id, u.username, u.password, u.nom, u.cognoms, u.email
            FROM usuari u";

                List<Dictionary<string, object>> usuarios = new List<Dictionary<string, object>>();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var registro = new Dictionary<string, object>
                {
                    { "id", reader["id"] },
                    { "username", reader["username"] },
                    { "password", reader["password"] },
                    { "nom", reader["nom"] },
                    { "cognoms", reader["cognoms"] },
                    { "email", reader["email"] }
                };

                        usuarios.Add(registro);
                    }
                }

                CloseConnection();

                // Por cada usuario, obtener su rol y su id_club o id_Equip
                foreach (var usuario in usuarios)
                {
                    int id = Convert.ToInt32(usuario["id"]);
                    OpenConnection();
                    bool [] rol = ObtenerRol(id);
                    CloseConnection();
                    string tablaRol = "";
                    string columnaId = "";
                    bool clubOEquip=false;
                    if (rol[0] == true)
                    {
                        tablaRol = "administrador";
                        columnaId = "id_club";
                  

                    }
                    else if (rol[2] == true)
                    {
                        tablaRol = "entrenador";
                        columnaId = "id_equip";
                        clubOEquip = true;
                    }
                    else if (rol[3] == true)
                    {
                        tablaRol = "jugador";
                        columnaId = "id_equip";
                        clubOEquip = true;
                    }
                    else if (rol[1]==true)
                    {
                        tablaRol = "aficionat";
                        columnaId = "id_club";
                    }

                    int idClubUsuario = Usuari.usuari.getIdClub();
                 
                    List<Dictionary<string, object>> equips = EquipsDeClub(idClubUsuario.ToString());
               
                    OpenConnection();

                    string subquery = $"SELECT {columnaId} FROM {tablaRol} WHERE id_usuari = @id_usuari";
                    using (MySqlCommand cmd = new MySqlCommand(subquery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id_usuari", id);
                        object idClubOEquipo = cmd.ExecuteScalar(); // obtiene el valor directamente
                      

                        
                        int idClubOEquipoInt = Convert.ToInt32(idClubOEquipo);
                        if (rol[0] == true)
                        {
                           usuario.Add("rol", "administrador");
                        }
                        else if (rol[1] == true)
                        {
                            usuario.Add("rol", "aficionat");
                        }
                        else if (rol[2] == true)
                        {
                            usuario.Add("rol", "entrenador");
                        }
                        else if (rol[3] == true)
                        {
                            usuario.Add("rol", "jugador");
                        }
                        else
                        {
                            usuario.Add("rol", "");
                        }
                       
                        if (!clubOEquip)
                        {
                            if (idClubUsuario != idClubOEquipoInt)
                            {
                                CloseConnection();
                                continue;
                            }
                        } 
                        else
                        {
                            bool trobat=false;
                            foreach (var registreEquips in equips)
                            {
                               if( (registreEquips["id"].ToString().Equals(idClubOEquipoInt.ToString())))
                               {
                                    trobat=true;
                                   
                               }
                            }
                            if (!trobat)
                            {
                                CloseConnection();
                                continue;
                            }
                        }


                    }

                    CloseConnection();

                    resultados.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los registros: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }

            return resultados;
        }

        public void updateCompte(string id, string username, string nom, string cognoms, string email)
        {


            try
            {
                OpenConnection();  // Abre la conexión a la base de datos

                string query = @"
                UPDATE usuari
                SET 
                username = @username,
                nom = @nom,
                cognoms = @cognoms,
                email = @email
                WHERE id = @id;";

                // Crear el comando con la consulta SQL
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                 
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@cognoms", cognoms);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Ejecutar la consulta
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Verificar si se actualizó algún registro
                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine("El registro ha sido actualizado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningún registro para actualizar.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el registro: {ex.Message}");
            }
            finally
            {
                CloseConnection();  // Cierra la conexión a la base de datos
            }
        }
        public void deleteCompte(string id)
        {
            try
            {
                OpenConnection();  // Abre la conexión a la base de datos

                string query = @"
                DELETE FROM usuari
                WHERE id = @id;";

                // Crear el comando con la consulta SQL
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@id", id);

                    // Ejecutar la consulta
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Verificar si se actualizó algún registro
                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine("El registro ha sido borrado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningún registro para borrar");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el registro: {ex.Message}");
            }
            finally
            {
                CloseConnection();  // Cierra la conexión a la base de datos
            }
        }
        public string GenerarContrasenya()
        {
            Random random = new Random();
            string lletres = "qwertyuiopasdfghjklzxcvbnm";
            string lletresM = lletres.ToUpper();
            string caracters = "!$%/()=?¿|#~€ºª-_.[]";
            string numeros = "0123456789";

            string totsElsCaracters = lletres + lletresM + caracters + numeros;
            int longitud = 12;

            StringBuilder contrasenya = new StringBuilder();

            for (int i = 0; i < longitud; i++)
            {
                int index = random.Next(totsElsCaracters.Length);
                contrasenya.Append(totsElsCaracters[index]);
            }

            return contrasenya.ToString();
        }
        public string GenerarUsuari()
        {
            Random random = new Random();
            string lletres = "qwertyuiopasdfghjklzxcvbnm";
            string lletresM = lletres.ToUpper();
            string caracters = "!$%/()=?¿|#~€ºª-_.[]";
            string numeros = "0123456789";

            string totsElsCaracters = lletres + lletresM + caracters + numeros;
            int longitud = 12;

            StringBuilder contrasenya = new StringBuilder();

            for (int i = 0; i < longitud; i++)
            {
                int index = random.Next(totsElsCaracters.Length);
                contrasenya.Append(totsElsCaracters[index]);
            }

            return contrasenya.ToString();
        }
        public static string CalcularSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesTexto = Encoding.UTF8.GetBytes(texto);
                byte[] hashBytes = sha256.ComputeHash(bytesTexto);

                // Convertimos el hash a Base64
                return Convert.ToBase64String(hashBytes);
            }
        }

        public void InsertCompte(string username, string nom, string cognoms, string email, string rol, string idEquip, string idclub)
        {
            try
            {
                OpenConnection();  // Abre la conexión a la base de datos

                // 1. INSERTAR EN `usuari`
                string query = @"
                INSERT INTO usuari(username, password, nom, cognoms, email)
                VALUES(@username, @password, @nom, @cognoms, @email);
                SELECT LAST_INSERT_ID();";  // Obtener el último ID insertado

                int idUsuari;
                String usernameG = GenerarContrasenya();
                Thread.Sleep(100);
                String password =  GenerarUsuari();
                MessageBox.Show(password);
                String passwordHash = CalcularSHA256(password);
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                   
                    if (username.Equals(""))
                    {
                    cmd.Parameters.AddWithValue("@username", usernameG);
                    }
                    else
                    { 
                    cmd.Parameters.AddWithValue("@username", username);
                    }
                    cmd.Parameters.AddWithValue("@password", passwordHash);  
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@cognoms", cognoms);
                    cmd.Parameters.AddWithValue("@email", email);

                    // Ejecutar la consulta y obtener el ID del nuevo usuario
                    idUsuari = Convert.ToInt32(cmd.ExecuteScalar());
                }

                Console.WriteLine("Usuario insertado con ID: " + idUsuari);

              
                string tablaRol;
                string columnaId;

                if (rol == "administrador")
                {
                    tablaRol = "administrador"; 
                    columnaId = "id_club";
                }
                else if (rol== "entrenador")
                {
                    tablaRol = "entrenador";
                    columnaId = "id_Equip";
                }
                else 
                {
                    tablaRol = "jugador";
                    columnaId = "id_Equip";
                }

                query = $"INSERT INTO {tablaRol} (id_usuari, {columnaId}) VALUES (@id_usuari, @id);";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_usuari", idUsuari);
                    if (rol == "administrador" || rol == "aficionat")
                    {
                    if(idclub.Equals(""))
                    {
                     cmd.Parameters.AddWithValue("@id", Usuari.usuari.getIdClub());
                    }
                    else
                    {
                     cmd.Parameters.AddWithValue("@id", idclub);
                    }
                   
                    }
                    else
                    {
                    cmd.Parameters.AddWithValue("@id", idEquip);
                    }
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine("El rol ha sido asignado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Error al asignar el rol.");
                    }
                }
                String cuerpo = "";
                if (username.Equals(""))
                {
                    cuerpo = CrearAsunto(password,usernameG);
                }
                else 
                {
                    cuerpo = CrearAsunto(password, username);
                }
                Mail.EnviarCorreo(email,"Informació inici de sesió ClubPilot",cuerpo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar el registro: {ex.Message}");
                CloseConnection();
                if(username.Equals(""))
                { 
                InsertCompte(username, nom, cognoms, email, rol, idEquip, idclub);
                }
            }
            finally
            {

                CloseConnection(); 
            }
        }
        public  String CrearAsunto(String contrasena, String usuario)
        {
            
            return "Benvolgut/da fundador!,\r\n" +
                "\r\n" +
                "Espero que aquest missatge et trobi bé.\r\n" +
                "\r\n" +
                "A continuació, et proporcionem el nom d'usuari i la contrasenya que necessites per accedir al teu compte:\r\n" +
                "\r\n" +
                "Nom d'usuari: "+ usuario +"\r\n" +
                "\r\nContrasenya: "+contrasena +"\r\n" +
                "\r\n" +
                "Et recomano que, per raons de seguretat, canviïs la contrasenya tan bon punt accedeixis al compte. Si tens qualsevol dubte o necessites ajuda addicional, no dubtis a contactar-me.\r\n" +
                "\r\nEstic a la teva disposició per a qualsevol consulta.\r\n" +
                "\r\nSalutacions cordials,\r\n" +
                "Next Sphere S.L.\r\n" +
                "[La teva informació de contacte]";
        }



        public bool [] ObtenerRol(int id)
        {
           
            bool[] rols = new bool[4];


            if (EsRol(id, "administrador", connection))
            {
                rols[0] = true;
            }
            if (EsRol(id, "aficionat", connection))
            {
                rols[1] = true;
            }
            if (EsRol(id, "entrenador", connection))
            {
                rols[2] = true;
            }
            if (EsRol(id, "jugador", connection))
            {
                rols[3] = true;
            }

            return rols;
          
        }

        public bool EsRol(int id, string rol, MySqlConnection conn)
        {
            bool tieneRol = false;

            try
            {
                string query = $@"
                SELECT 1 FROM {rol} r 
                WHERE r.id_usuari = @id ;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())  
                        {
                            tieneRol = true;
                        }
                      
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la verificación del rol {rol}: {ex.Message}");
            }

            return tieneRol;
        }

        public List<Dictionary<string, object>> EquipsDeClub(string idClub)
        {
            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();
            try
            {
                OpenConnection();
                string query = @"
		           SELECT e.nom, e.id
		           FROM equip e 
                   WHERE e.id_club = @id;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", idClub);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          var registro = new Dictionary<string, object>
                          {
                            { "id", reader["id"] },
                            { "nom", reader["nom"] }
                          };
                            resultados.Add(registro);
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
            return resultados;
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
