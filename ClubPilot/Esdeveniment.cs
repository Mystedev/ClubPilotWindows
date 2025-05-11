using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClubPilot
{
    public class Esdeveniment
    {
        public string description { get; set; }
        public DateTime data { get; set; }
        public Panel Panel { get; set; }
        public int id_usuari { get; set; }
        public int id_equip { get; set; }
        public string tipus_esdeveniment { get; set; }
        public int id { get; set; }

        public Button borrar { get; set; }

        public Esdeveniment(string tipus_esdeveniment, string description, DateTime data)
        {
            this.description = description;
            this.data = data;
            this.tipus_esdeveniment = tipus_esdeveniment;
            this.id_usuari = Usuari.usuari.getIdUsuari();
            this.id_equip = Usuari.usuari.getIdEquip();

            Panel = new Panel
            {
                Size = new Size(610, 200),
                BackColor = Color.LightGray,
                AutoSize = false
            };

            InicializarControles();
        }

        private void InicializarControles()
        {
            // Título
            Label label_titulo = new Label
            {
                Text = tipus_esdeveniment,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Location = new Point(0, 20),
                AutoSize = true
            };
            Panel.Controls.Add(label_titulo);

            // Descripción
            Label label_texto = new Label
            {
                Text = description,
                Location = new Point(0, 50),
                Font = new Font("Arial", 9),
                AutoSize = true,
                MaximumSize = new Size(Panel.Width - 70, 0)
            };
            Panel.Controls.Add(label_texto);

            // Fecha
            Label label_fecha = new Label
            {
                Font = new Font("Arial", 10, FontStyle.Italic),
                Text = data.ToString("dd/MM/yyyy HH:mm"),
                AutoSize = true,
                Location = new Point(0, 150)
            };
            Panel.Controls.Add(label_fecha);

            // Botón BORRAR
            borrar = new Button
            {
                Width = 30,
                Height = 30,
                Location = new Point(560, 150),
                FlatStyle = FlatStyle.Flat,
                Image = Properties.Resources.icons8_eliminar_30,
                TabStop = false
            };
            borrar.FlatAppearance.BorderSize = 0;
            borrar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            borrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            borrar.Click += Borrar_Click;
            Panel.Controls.Add(borrar);
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            Connection.deleteEsdeveniment(this); // Este método debe estar implementado
            Connection con = new Connection();
            con.exportEsdeveniment(Usuari.usuari.getIdEquip()); // Opcional
            Esdeveniments.showEvents(); // Refresca el panel
        }

        public void Show()
        {
            // Ya todo se inicializa en el constructor
        }
    }
}
