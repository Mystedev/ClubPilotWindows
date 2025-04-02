using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubPilot
//Clase que representa una noticia
//El panel es para poder mostrar una noticia en el formulario de forma ordenada
{
    public class News : Panel
    {
        public int id { get; set; }
        public int idClub { get; set; }
        public int idUsuari { get; set; }
        private string Titulo { get; set; }
        private string Texto { get; set; }
        private DateTime Fecha { get; set; }
        private DateTime Hora { get; set; }
        private string Autor { get; set; }
        private string Imagen { get; set; }
        public Panel Panel { get; set; }

        public News(string titulo, string texto, string autor, string imagen ,DateTime fecha/*, DateTime hora*/)
        {
            Titulo = titulo;
            Texto = texto;
            Fecha = fecha;
            //Hora = hora;
            Autor = autor;
            Imagen = imagen;
            Panel = new Panel();
            Panel.Size = new System.Drawing.Size(700, 300);
        }

        //Le da formato a cada parte de la noticia y la añade al panel
        public void Show()
        {
            Panel.BackColor = System.Drawing.Color.FromArgb(82, 137, 179);
            Panel.AutoSize = false;

            Label label_titulo = new Label();
            label_titulo.Text = Titulo;
            label_titulo.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold); // Cambiar la fuente
            label_titulo.Location = new System.Drawing.Point(10, 10); // Ajusta la ubicación según sea necesario
            label_titulo.Size = new System.Drawing.Size(480, 30); // Ajusta el tamaño según sea necesario
            label_titulo.ForeColor = System.Drawing.Color.White; // Cambiar el color del texto a blanco
            Panel.Controls.Add(label_titulo);

            Label label_texto = new Label();
            label_texto.Text = Texto;
            label_texto.Location = new System.Drawing.Point(10, 50); // Ajusta la ubicación según sea necesario
            label_texto.AutoSize = true;
            label_texto.MaximumSize = new System.Drawing.Size(480, 0); // Ajusta el ancho máximo según sea necesario
            label_texto.ForeColor = System.Drawing.Color.White; // Cambiar el color del texto a blanco
            Panel.Controls.Add(label_texto);

            PictureBox pictureBox = new PictureBox();
            pictureBox.ImageLocation = Imagen;
            pictureBox.Location = new System.Drawing.Point(500, 10); // Ajusta la ubicación para que esté en la parte derecha
            pictureBox.Size = new System.Drawing.Size(180, 180); // Ajusta el tamaño según sea necesario
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Ajusta el modo de tamaño según sea necesario
            Panel.Controls.Add(pictureBox);

            Label label_fecha = new Label();
            label_fecha.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
            label_fecha.Text = Fecha.ToString("dd/MM/yyyy HH:mm"); // Formato de fecha y hora
            label_fecha.Location = new System.Drawing.Point(10, 280); // Ajusta la ubicación según sea necesario
            label_fecha.Size = new System.Drawing.Size(200, 20); // Ajusta el tamaño según sea necesario
            label_fecha.ForeColor = System.Drawing.Color.White; // Cambiar el color del texto a blanco
            Panel.Controls.Add(label_fecha);

            Label label_autor = new Label();
            label_autor.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
            label_autor.Text = "Autor: " + Autor;
            label_autor.AutoSize = true;
            label_autor.MaximumSize = new System.Drawing.Size(200, 0);
            label_autor.Location = new System.Drawing.Point(220, 280); // Ajusta la ubicación según sea necesario
            label_autor.Size = new System.Drawing.Size(200, 20); // Ajusta el tamaño según sea necesario
            label_autor.ForeColor = System.Drawing.Color.White; // Cambiar el color del texto a blanco
            Panel.Controls.Add(label_autor);
        }




    }
}
