using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class Form1 : Form
    {

        private Connection db;

        int idUsuari;
        int idClub;
        int idEquip;
        String[] response;
        bool[] Rol;
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
            bool login = false;
            response = db.Login(username, password);






            if (response.Length < 1)
            {
                MessageBox.Show("Usuari o contrasenya incorrectes");
                return;
            }
            int numero = int.Parse(response[0]);
            Connection.OpenConnection();
            bool[] rol = db.ObtenerRol(numero);
            if (rol[0] == true || rol[2] == true || (rol[1] == false && rol[2] == false && rol[0] == false && rol[3] == false))
            {
                login = true;
            }
            Connection.CloseConnection();
            if (response.Length >= 1 && login == true)
            {

                if (rol[0] == false && rol[1] == false && rol[2]== false && rol[3]==false)
                {
                    clubs = db.SelectClubs();
                }
                else
                {
                    clubs = db.ClubsDeUsuari(response[0]);
                }

                MessageBox.Show("Login correcte");
                idUsuari = Convert.ToInt32(response[0]);


                // Cambiar la visibilidad de los controles
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                Connection.OpenConnection();
                Rol = db.ObtenerRol(numero);
                if (rol[0] == true || rol[2]==true)
                {
                    comboBox1.Visible = true;
                    label3.Visible = true;
                }
                Connection.CloseConnection();
                button2.Visible = true;
                label4.Visible = true;
                comboBox2.Visible = true;



                // Obtener los clubes del usuario

                if(rol[0] == false && rol[1] == false && rol[2] == false && rol[3] == false)
                {
                    foreach (var registre in clubs)
                    {
                        comboBox2.Items.Add(registre["nom"].ToString());
                    }
                }
                else
                {
                    foreach (var registre in clubs)
                    {
                        comboBox2.Items.Add(registre["nomClub"].ToString());
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Usuari o contrasenya incorrectes");
            }

        }




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();

            
            foreach (var registre in clubs)
            {
                if (!(Rol[0] == false && Rol[1] == false && Rol[2] == false && Rol[3] == false))
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
                else 
                {
                    if (registre["nom"].Equals(comboBox2.Text))
                    {



                        string clubId = registre["id"].ToString();
                        equips = db.EquipsDeClub(clubId);
                        foreach (var registreEquips in equips)
                        {
                            comboBox1.Items.Add(registreEquips["nom"].ToString());
                        }

                    }
                }
                    
            }

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            int idClub = 0;
            int idEquip = 0;
            
                foreach (var registre in clubs)
                {

                    if(Rol[0] == false && Rol[1] == false && Rol[2] == false && Rol[3] == false)
                    {
                        if (registre["nom"].Equals(comboBox2.Text))
                        {
                            idClub = int.Parse(registre["id"].ToString());
                            break;
                        }
                    }
                    else
                    {
                        if (registre["nomClub"].Equals(comboBox2.Text))
                        {
                            idClub = int.Parse(registre["idClub"].ToString());
                            break;
                        }
                    }
                  
                    
                }
                if ((Rol[2] == true ))
                {
                    foreach (var registreEquips in equips)
                    {
                        if (registreEquips["nom"].Equals(comboBox1.Text))
                        {
                            idEquip = int.Parse(registreEquips["id"].ToString());
                            break;
                        }
                    }
                }
                int idUsuari = int.Parse(response[0]);
            
            Connection.OpenConnection();
            Usuari.usuari = new infoUsuari(idUsuari, idClub, idEquip, db.ObtenerRol(idUsuari));
            Connection.CloseConnection();

            this.Hide();
            new MainForm().Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            CrearClub crearClub = new CrearClub();
            crearClub.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label_Pass_Click(object sender, EventArgs e)
        {
            PasswordReset pass = new PasswordReset();
            pass.Show();
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
        private bool[] rol;
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
        public bool[] getRol()
        {
            return rol;
        }
        public void setRol(bool[] rol)
        {
            this.rol = rol;
        }
        public infoUsuari(int idUsuari, int idClub, int idEquip, bool[] rol)
        {

            this.idUsuari = idUsuari;
            this.idClub = idClub;
            this.idEquip = idEquip;
            this.rol = rol;

        }
        public String toString()
        {
            return "Usuari: " + idUsuari + " Club: " + idClub + " Equip: " + idEquip;
        }
    }
}