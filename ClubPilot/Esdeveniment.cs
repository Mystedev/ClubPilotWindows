using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubPilot
{
    public class Esdeveniment
    {
        public String description { get; set; }
        public DateTime data { get; set; }
        public Panel Panel { get; set; }
        public int id_usuari { get; set; }
        public int id_equip { get; set; }
        public String tipus_esdeveniment { get; set; }
        public int id { get; set; }


        public Esdeveniment(String tipus_esdeveniment, String description, DateTime data)
        {
            this.description = description;
            this.data = data;
            this.tipus_esdeveniment = tipus_esdeveniment;
            Panel = new Panel();
            Panel.Size = new System.Drawing.Size(610,200);
            id_usuari = 1;
            id_equip = 1;


        } 

        public void Show()
        {
            Panel.BackColor = System.Drawing.Color.LightGray;
            Panel.AutoSize = false;

            Label label_titulo = new Label();
            label_titulo.Text = tipus_esdeveniment;
            label_titulo.Font = new System.Drawing.Font("Arial", 15, FontStyle.Bold); // Cambiar la fuente
            label_titulo.Location = new System.Drawing.Point(0, 20);
            label_titulo.AutoSize = true;
            //label_titulo.MaximumSize = new System.Drawing.Size(Panel.Width - 20, 0);
            Panel.Controls.Add(label_titulo);

            Label label_texto = new Label();
            label_texto.Text = description;
            label_texto.Location = new System.Drawing.Point(0, 50);
            label_texto.Font = new System.Drawing.Font("Arial", 9);
            label_texto.AutoSize = true;
            label_texto.MaximumSize = new System.Drawing.Size(Panel.Width - 20, 0); // Ajusta el ancho máximo según sea necesario
            Panel.Controls.Add(label_texto);

            Label label_fecha = new Label();
            label_fecha.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
            label_fecha.Text = data.ToString();
            label_fecha.AutoSize = true;
            label_fecha.Location = new System.Drawing.Point(0, 150);
            Panel.Controls.Add(label_fecha);
        }
    }

}
