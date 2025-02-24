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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            if((textBox1.Text.Equals("usuario1"))&&(textBox2.Text.Equals("contraseña1")))
            { 
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                comboBox1.Visible = true;
                label3.Visible= true;
                button2.Visible= true;
                label4.Visible= true;
                comboBox2.Visible= true;

                comboBox1.Items.Add("equip1");
                comboBox1.Items.Add("equip2");
                comboBox1.Items.Add("equip3");
                comboBox1.Items.Add("equip4");


                comboBox2.Items.Add("club1");
                comboBox2.Items.Add("club2");
                comboBox2.Items.Add("club3");
                comboBox2.Items.Add("club4");


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
    }
}
