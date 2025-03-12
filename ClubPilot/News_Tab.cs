using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class News_Tab : Form
    {
        public News Noticia { get; set; }

        public News_Tab()
        {
            List<News> noticias = new List<News>();



            if (Noticia != null)
            {
                noticias.Add(Noticia);
                //flowLayoutPanel1.Controls.Add(noticia.Panel);
                Noticia.Panel.Show();
                //Controls.Add(noticia.Panel);
            }
            else
            {
                MessageBox.Show("No hay panel para mostrar.");
                new Add_New().Show();
            }

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            new Add_New().Show();
        }
    }

}