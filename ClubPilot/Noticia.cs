using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubPilot
{
    public class Noticia
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; }
        public string Imagen { get; set; }
        public Panel Panel { get; set; }

        public Noticia(string titulo, string texto, DateTime fecha, string autor, string imagen, Panel panel)
        {
            Titulo = titulo;
            Texto = texto;
            Fecha = fecha;
            Autor = autor;
            Imagen = imagen;
            Panel = new Panel();
        }

        
    }
}
