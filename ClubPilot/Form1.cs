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
     
        private DatabaseConnection db;
        public Form1()
        {
            InitializeComponent();
       
            db = new DatabaseConnection();
   
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

            if (db.Login(username, password))
            {
                MessageBox.Show("Login exitoso");

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

                comboBox1.Items.AddRange(new string[] { "equip1", "equip2", "equip3", "equip4" });
                comboBox2.Items.AddRange(new string[] { "club1", "club2", "club3", "club4" });
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //entrar a la aplicació
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CrearClub crearClub = new CrearClub();
            crearClub.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
    }
}