using System;
using System.Collections.Generic;
using System.Drawing;
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

            // Configurar el MenuStrip para que ocupe toda la parte superior
            menuStrip1.Dock = DockStyle.Top;
            this.Controls.Add(menuStrip1);

            // Bloque de código de configuración del layout para organizar noticias
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = System.Drawing.Color.SeaShell;
            flowLayoutPanel.WrapContents = true;
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            this.Controls.Add(flowLayoutPanel);

            // Asegurarse de que el FlowLayoutPanel esté debajo del MenuStrip
            flowLayoutPanel.BringToFront();

            Connection connection = new Connection();
            noticias = connection.exportNews();

            // Crear y configurar el botón
            button1 = new Button();
            button1.Image = Properties.Resources.icons8_añadir_30;
            button1.Width = 40;
            button1.Height = 40;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.Location = new Point(this.ClientSize.Width - button1.Width - 10, this.ClientSize.Height - button1.Height - 10);
            button1.BackColor = Color.Transparent;
            button1.TabStop = false;
            button1.Click += new EventHandler(button1_Click_1);
            this.Controls.Add(button1); 
            button1.BringToFront();


            noticiesToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            // Mostrar noticias si existen
            if (noticias.Count > 0)
            {
                showNews();
            }
            else
            {
                MessageBox.Show("No hi ha noticies.");
                new Add_News().Show();
            }
        }

        // Mostrar la pantalla de añadir noticia
        private void button1_Click_1(object sender, EventArgs e)
        {
            new Add_News().Show();
        }

        // Meter todas las noticias en una lista y añadir los paneles de estas al FlowLayoutPanel
        static public void showNews()
        {
            for (int i = 0; i < noticias.Count; i++)
            {
                noticias[i].Show();
                noticias[i].Panel.Show();
                flowLayoutPanel.Controls.Add(noticias[i].Panel);
            }


        }
    }
}
