using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using System.Security.Cryptography;

namespace ClubPilot
{
    class Connection
    {
        private string server = "192.168.1.150";
        private string database = "clubPilot";
        private string port = "25230";
        private string user_id = "clubPilot";
        private string password = "ABCD!!25230";

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
                    password = CalcularSHA256(password);
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

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
            String rol=ObtenerRol(id);
            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();
            if(rol =="administrador")
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
                UPDATE Club 
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

                // Obtener todos los usuarios primero
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

               
                foreach (var usuario in usuarios)
                {
                    int id = Convert.ToInt32(usuario["id"]);
                    string rol = ObtenerRol(id); 
                    usuario.Add("rol", rol); 
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
                password = CalcularSHA256(password);
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
                    cmd.Parameters.AddWithValue("@password", password);  
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@cognoms", cognoms);
                    cmd.Parameters.AddWithValue("@email", email);

                    // Ejecutar la consulta y obtener el ID del nuevo usuario
                    idUsuari = Convert.ToInt32(cmd.ExecuteScalar());
                }

                Console.WriteLine("Usuario insertado con ID: " + idUsuari);

              
                string tablaRol;
                string columnaId;

                if (rol == "administrador" || rol == "aficionat")
                {
                    tablaRol = "administrador"; 
                    columnaId = "id_club";
                }
                else
                {
                    tablaRol = "entrenador";
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



        public string ObtenerRol(int id)
        {
            string rol = "a"; 

            if (EsRol(id, "administrador", connection))
            {
                rol = "administrador";
            }
            else if (EsRol(id, "aficionat", connection))
            {
                rol = "aficionat";
            }
            else if (EsRol(id, "entrenador", connection))
            {
                rol = "entrenador";
            }
            else if (EsRol(id, "jugador", connection))
            {
                rol = "jugador";
            }

            return rol;
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
		           FROM Equip e 
                   WHERE e.id = @id;";

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
        public List<Dictionary<string, object>> SelectJugadors()
        {
            List<Dictionary<string, object>> resultados = new List<Dictionary<string, object>>();
        
            try
            {
                OpenConnection();
                string query = @"
                  SELECT c.id, c.nom, c.any_fundacio, c.fundador, c.logo, c.emailfundador,c.registre
                  FROM club c
                  SELECT u.nom, u.cognoms, j.posicio, j.dorsal, j.disponibilitat 
                  FROM jugador j
                  JOIN usuari u ON j.id_usuari = u.id 
                  WHERE J.id_equip = @id;
                  ";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                //cmd.Parameters.AddWithValue("@id", idEquipEnQuestio);
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
    }
}
