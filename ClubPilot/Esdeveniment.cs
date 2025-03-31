using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubPilot
{
    public class Esdeveniment
    {
        private String nom { get; set; }
        private String description { get; set; }
        private DateTime data { get; set; }
        public Panel Panel { get; set; }


        public Esdeveniment(String nom, String description, DateTime data)
        {
            this.nom = nom;
            this.description = description;
            this.data = data;
            Panel = new Panel();
            Panel.Size = new System.Drawing.Size(910,200);

        } 

        public void Show()
        {
            Panel.BackColor = System.Drawing.Color.LightGray;
            Panel.AutoSize = false;

            Label label_titulo = new Label();
            label_titulo.Text = nom;
            label_titulo.Font = new System.Drawing.Font("Arial", 13, System.Drawing.FontStyle.Bold); // Cambiar la fuente
            label_titulo.Location = new System.Drawing.Point(0, 20);
            //label_titulo.MaximumSize = new System.Drawing.Size(Panel.Width - 20, 0);
            Panel.Controls.Add(label_titulo);

            Label label_texto = new Label();
            label_texto.Text = description;
            label_texto.Location = new System.Drawing.Point(0, 50);
            label_titulo.Font = new System.Drawing.Font("Arial", 9);
            label_texto.AutoSize = true;
            label_texto.MaximumSize = new System.Drawing.Size(Panel.Width - 20, 0); // Ajusta el ancho máximo según sea necesario
            Panel.Controls.Add(label_texto);

            Label label_fecha = new Label();
            label_fecha.Font = new System.Drawing.Font("Arial", 7, System.Drawing.FontStyle.Italic);
            label_fecha.Text = data.ToString();
            label_fecha.Location = new System.Drawing.Point(0, 170);
            Panel.Controls.Add(label_fecha);
        }
    }

}
