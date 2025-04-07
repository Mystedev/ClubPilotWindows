using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClubPilot
{
    public partial class Form1 : Form
    {
     
        private Connection db;
       
        int idUsuari;
        int idClub;
        int idEquip;
        String[] response;
        List<Dictionary<string, object>> clubs;
        List<Dictionary<string, object>> equips;

        public Form1()
        {
            
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            db = new Connection();
   
            textBox2.PasswordChar = '*';
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            bool login=false;
            response = db.Login(username, password);

            
            

           

            int numero = int.Parse(response[0]);
            db.OpenConnection();
            if (db.ObtenerRol(numero).Equals("administrador") || db.ObtenerRol(numero).Equals("entrenador"))

            {
                login = true;
            }
            db.CloseConnection();

            if (response.Length >=1 && login==true)
            {

                clubs = db.ClubsDeUsuari(response[0]);
                MessageBox.Show("Login correcto");
                idUsuari = Convert.ToInt32(response[0]);

   
                // Cambiar la visibilidad de los controles
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                db.OpenConnection();
                if (db.ObtenerRol(numero).Equals("administrador"))
                {
                comboBox1.Visible = true;
                label3.Visible = true;
                }
                db.CloseConnection();
                button2.Visible = true;
                label4.Visible = true;
                comboBox2.Visible = true;



                // Obtener los clubes del usuario


                foreach (var registre in clubs)
                {
                    comboBox2.Items.Add(registre["nomClub"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }

        }

            

      
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();

            foreach (var registre in clubs)
            {
                if (registre["nomClub"].Equals(comboBox2.Text))  
                {


                   
                    string clubId = registre["idClub"].ToString();
                    equips = db.EquipsDeClub(clubId);
                    foreach (var registreEquips in equips)
                    {
                        comboBox1.Items.Add(registreEquips["nom"].ToString());
                    }

            }
            }

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            CrearClub crearClub = new CrearClub();
            crearClub.Show();
        }
    }
    public static class Usuari
    {
        public static infoUsuari usuari;
        
    }
    public class infoUsuari
    {
        private int idUsuari;
        private int idClub;
        private int idEquip;
        private String rol;
        public int getIdUsuari()
        {
            return idUsuari;
        }
        public void setIdUsuari(int id)
        {
            idUsuari = id;
        }
        public int getIdClub()
        {
            return idClub;
        }
        public void setIdClub(int id)
        {
            idClub = id;
        }
        public int getIdEquip()
        {
            return idEquip;
        }
        public void setIdEquip(int id)
        {
            idEquip = id;
        }
        public String getRol()
        {
            return rol;
        }
        public void setRol(String rol)
        {
            this.rol = rol;
        }
        public infoUsuari(int idUsuari, int idClub, int idEquip)
        {
            this.idUsuari = idUsuari;
            this.idClub = idClub;
            this.idEquip = idEquip;
        }
        public String toString()
        {
            return "Usuari: " + idUsuari + " Club: " + idClub + " Equip: " + idEquip;
        }
    }
}