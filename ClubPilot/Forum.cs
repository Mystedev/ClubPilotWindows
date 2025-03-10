using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class Forum : Form
    {
        public Noticia noticia { get; set; }

        public Forum()
        {
            InitializeComponent();

            List<Noticia> noticias = new List<Noticia>();



            if (noticia != null)
            {
                noticias.Add(noticia);
                //flowLayoutPanel1.Controls.Add(noticia.Panel);
                noticia.Panel.Show();
                //Controls.Add(noticia.Panel);
            }
            else
            {
                MessageBox.Show("No hay panel para mostrar.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Add_New().Show();
        }
    }

}