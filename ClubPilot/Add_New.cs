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
    public partial class Add_New : Form
    {
        String titulo;
        String autor;
        String texto;
        String imagen;
        DateTime fecha;
        private object dateTimePicker1;

        public Add_New()
        {
            InitializeComponent();
        }
        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fecha = DateTime.Parse(dateTimePicker1.ToString());
        }



        private void textBox_titulo_TextChanged(object sender, EventArgs e)
        {
            titulo = textBox_titulo.Text;
        }

        private void textBox_descripcion_TextChanged(object sender, EventArgs e)
        {
            texto = textBox_descripcion.Text;   
        }

        private void textBox_autor_TextChanged(object sender, EventArgs e)
        {
            autor = textBox_autor.Text;
        }

        private void textBox_imagen_TextChanged(object sender, EventArgs e)
        {
            imagen = textBox_imagen.Text;
        }
        private void boton_CrearNoticia_Click_1(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            Noticia noticia = new Noticia(titulo, texto, fecha, autor, imagen, panel);
            Forum forum = new Forum();
            forum.noticia = noticia;
            forum.Show();

        }
    }
}
