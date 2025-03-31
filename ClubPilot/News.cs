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
        private string Titulo { get; set; }
        private string Texto { get; set; }
        private DateTime Fecha { get; set; }
        private DateTime Hora { get; set; }
        private string Autor { get; set; }
        private string Imagen { get; set; }
        public Panel Panel { get; set; }

        public News(string titulo, string texto, DateTime fecha/*, DateTime hora*/, string autor, string imagen)
        {
            Titulo = titulo;
            Texto = texto;
            Fecha = fecha;
            //Hora = hora;
            Autor = autor;
            Imagen = imagen;
            Panel = new Panel();
            Panel.Size = new System.Drawing.Size(300, 75);
        }

        //Le da formato a cada parte de la noticia y la añade al panel
        public void Show()
        {
            Panel.BackColor = System.Drawing.Color.Blue;
            Panel.AutoSize = true;

            Label label_titulo = new Label();
            label_titulo.Text = Titulo;
            label_titulo.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold); // Cambiar la fuente
            label_titulo.Location = new System.Drawing.Point(0, 0);
            Panel.Controls.Add(label_titulo);

            Label label_texto = new Label();
            label_texto.Text = Texto;
            label_texto.Location = new System.Drawing.Point(0, 25);
            label_texto.AutoSize = true;
            label_texto.MaximumSize = new System.Drawing.Size(100, 0); // Ajusta el ancho máximo según sea necesario
            Panel.Controls.Add(label_texto);

            PictureBox pictureBox = new PictureBox();
            pictureBox.ImageLocation = Imagen;
            pictureBox.Location = new System.Drawing.Point(140, 5); // Ajusta la ubicación según sea necesario
            pictureBox.Size = new System.Drawing.Size(150, 150); // Ajusta el tamaño según sea necesario
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Ajusta el modo de tamaño según sea necesario
            Panel.Controls.Add(pictureBox);

            Label label_fecha = new Label();
            label_fecha.Font = new System.Drawing.Font("Arial", 7, System.Drawing.FontStyle.Italic);
            label_fecha.Text = Fecha.ToString();
            label_fecha.Location = new System.Drawing.Point(0, 140);
            Panel.Controls.Add(label_fecha);

            Label label_autor = new Label();
            label_autor.Font = new System.Drawing.Font("Arial", 7, System.Drawing.FontStyle.Italic);
            label_autor.Text = Autor;
            label_autor.AutoSize = true;
            label_autor.MaximumSize = new System.Drawing.Size(75, 0);
            label_autor.Location = new System.Drawing.Point(0, 120);
            Panel.Controls.Add(label_autor);
        }
    }
}
