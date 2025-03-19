using ClubPilot.Properties;
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

namespace ClubPilot
{
    


    public partial class Accounts : Form
    {
       
        public Accounts()
        {
         
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_mod_conta1_Click(object sender, EventArgs e)
        {
            btn_mod_conta1.Enabled = false;
            txtBoxUsername1.Enabled = true;
            txtBoxNom1.Enabled = true;
            txtBoxCognoms1.Enabled = true;
            txtBoxEmail1.Enabled = true;
            btn_gua_conta1.Enabled = true;

        }

        private void btn_gua_conta1_Click(object sender, EventArgs e)
        {
            btn_gua_conta1.Enabled = false;
            btn_mod_conta1.Enabled = true;
        }

        private void btn_add_conta_Click(object sender, EventArgs e)
        {
            new AddAccount().Show();
        }
    }
    public class Usuari : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel;
        private Button button1;
        private Button button2;

        /*public Usuari()
        {
            // Inicializar componentes
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel = new Panel();
            button1 = new Button();
            button2 = new Button();

            // Configurar etiquetas
            label1.Text = "Username";
            label1.Location = new System.Drawing.Point(10, 10);
            label2.Text = "Nom";
            label2.Location = new System.Drawing.Point(10, 40);
            label3.Text = "Cognoms";
            label3.Location = new System.Drawing.Point(10, 70);
            label4.Text = "Email";
            label4.Location = new System.Drawing.Point(10, 100);

            // Configurar panel
            panel.Location = new System.Drawing.Point(10, 130);
            panel.Size = new System.Drawing.Size(260, 100);
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Configurar botones
            button1.Image = Resources.icons8_añadir_30.png;
            button1.Location = new System.Drawing.Point(10, 240);
            button2.Text = "Botón 2";
            button2.Location = new System.Drawing.Point(100, 240);

            // Agregar eventos a los botones
            button1.Click += new EventHandler(Button1_Click);
            button2.Click += new EventHandler(Button2_Click);

            // Agregar componentes al formulario
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(label4);
            this.Controls.Add(panel);
            this.Controls.Add(button1);
            this.Controls.Add(button2);

            // Configurar formulario
            this.Text = "Formulario Usuari";
            this.Size = new System.Drawing.Size(300, 300);
        }

        // Métodos de eventos
        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botón 1 presionado");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botón 2 presionado");
        }
    }*/


    }
}
