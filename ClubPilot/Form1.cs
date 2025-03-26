using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            String []response = db.Login(username, password);
         
       

            if (response.Length >=1)
            {
                String a=db.ClubsDeUsuari(response[0]);
                String []clubs = a.Split(' ');
                MessageBox.Show("Login correcto");

                // Cambiar la visibilidad de los controles
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                comboBox1.Visible = true;
                label3.Visible = true;
                button2.Visible = true;
                label4.Visible = true;
                comboBox2.Visible = true;

                // Obtener los clubes del usuario
               
                for (int i = 0; i < clubs.Length-1; i++)
                {
                    comboBox2.Items.Add(clubs[i]);
                }
               

          
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }

        }

            

        private void button2_Click(object sender, EventArgs e)
        {
            //entrar a la aplicació
            new Players().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CrearClub crearClub = new CrearClub();
            crearClub.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            String b = db.ClubsDeUsuari(comboBox2.Text);
            String[] equips = b.Split(' ');
            for (int i = 0; i < equips.Length - 1; i++)
            {
                comboBox1.Items.Add(equips[i]);
            }

        }
    }
}