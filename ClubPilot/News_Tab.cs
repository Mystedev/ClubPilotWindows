using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class News_Tab : Form
    {
        // Objeto News para agregar noticias en esta lista
        static public News Noticia { get; set; }
        static List<News> noticias = new List<News>();
        private static FlowLayoutPanel flowLayoutPanel;

        public News_Tab()
        {

            InitializeComponent();
            Form news_tab = new Add_News();
            // Bloque de codigo de configuracion del layout para organizar noticias
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.WrapContents = true;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(flowLayoutPanel);

            noticiesToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            
            //if (Noticia != null)
            //{
            //    for (int i = 0; i < noticias.Count; i++)
            //    {
            //        Noticia.Show();
            //        noticias.Add(Noticia);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No hi ha noticies.");
            //    new Add_News().Show();
            //}
        }

        // Mostrar la pantalla de añadir noticia
        private void button1_Click_1(object sender, EventArgs e)
        {
            new Add_News().Show();
        }
        //Meto todas las noticias en unas lista y añado los paneles de estas
        //al flowlayoutpanel
        static public void showNews()
        {
            noticias.Add(Noticia);
            for (int i = 0; i < noticias.Count; i++)
            {
               noticias[i].Show();
               noticias[i].Panel.Show();
               flowLayoutPanel.Controls.Add(noticias[i].Panel);
            }
        }

    }
}
