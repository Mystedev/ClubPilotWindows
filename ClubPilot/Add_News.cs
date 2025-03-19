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
            this.BackColor = System.Drawing.Color.SeaShell;
        }
        public void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            fecha = dateTimePicker2.Value;
        }
        //Boton que crea una noticia y llama a la funcion para mostrarla en News_Tab (tambien cierra el formulario)
        private void boton_CrearNoticia_Click_1(object sender, EventArgs e)
        {
            News noticia = new News(textBox_titulo.Text, textBox_descripcion.Text, dateTimePicker2.Value, textBox_autor.Text, textBox_imagen.Text);
            News_Tab.Noticia = noticia;
            News_Tab.showNews();
            this.Close();

        }


    }
}