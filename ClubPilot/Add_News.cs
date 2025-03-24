using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ClubPilot
{
    public partial class Add_News : Form
    {
        DateTime fecha;
        public Add_News()
        {
            InitializeComponent();
            //Cacho de codigo para dar formato al boton
            Button boton_CrearNoticia = new Button();
            boton_CrearNoticia.Image = Properties.Resources.icons8_guardar_30;
            boton_CrearNoticia.Width = 40;
            boton_CrearNoticia.Height = 40;
            boton_CrearNoticia.Show();
            boton_CrearNoticia.Location = new Point(450, 300);
            boton_CrearNoticia.FlatStyle = FlatStyle.Flat;
            boton_CrearNoticia.FlatAppearance.BorderSize = 0;
            boton_CrearNoticia.FlatAppearance.MouseOverBackColor = Color.Transparent; 
            boton_CrearNoticia.FlatAppearance.MouseDownBackColor = Color.Transparent; 
            boton_CrearNoticia.BackColor = Color.Transparent;
            boton_CrearNoticia.TabStop = false; 
            this.Controls.Add(boton_CrearNoticia);
            boton_CrearNoticia.Click += boton_CrearNoticia_Click;

            this.BackColor = System.Drawing.Color.SeaShell;


            
        }
        public void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            fecha = dateTimePicker2.Value;
        }
        //Boton que crea una noticia y llama a la funcion para mostrarla en News_Tab (tambien cierra el formulario)
        private void boton_CrearNoticia_Click(object sender, EventArgs e)
        {
            News noticia = new News(textBox_titulo.Text, textBox_descripcion.Text, dateTimePicker2.Value, textBox_autor.Text, textBox_imagen.Text);
            News_Tab.Noticia = noticia;
            News_Tab.showNews();
            this.Close();

        }


    }
}