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
        Button button1 = new Button();
        Label addNew = new Label();




        public News_Tab()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            // Bloque de código de configuración del layout para organizar noticias
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = System.Drawing.Color.SeaShell;
            flowLayoutPanel.WrapContents = true;
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            // Config del label del titulo
            Label tituloNew = new Label();
            tituloNew.Text = "Noticies";
            tituloNew.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            tituloNew.Dock = DockStyle.Top; // Esto anclará el Label a la parte superior del formulario
            tituloNew.AutoSize = false;
            tituloNew.TextAlign = ContentAlignment.MiddleCenter; // Centra el texto
            tituloNew.Padding = new Padding(10);
            tituloNew.Height = 50; // Ajusta la altura según sea necesario
            tituloNew.BackColor = Color.Transparent;

            this.Controls.Add(button1); 
            this.Controls.Add(flowLayoutPanel);
            this.Controls.Add(tituloNew); 



            // Crear un nuevo objeto Connection y obtener la lista de noticias
            Connection connection = new Connection();
            noticias = connection.exportNoticia();
            showNews();
            // Crear y configurar el botón
            button1.Image = Properties.Resources.icons8_añadir_30;
            button1.Width = 40;
            button1.Height = 40;
            button1.Text = null;
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
            ////LABEL BOTON
            //addNew.Text = "Afegir Noticia";
            //addNew.Font = new System.Drawing.Font("Arial", 9);
            //addNew.BackColor = Color.Transparent;
            //addNew.Location = new Point(this.ClientSize.Width - button1.Width - 50, this.ClientSize.Height - button1.Height - 50);
            //addNew.AutoSize = true;
            //addNew.Visible = true;
            //addNew.BringToFront();
            //this.Controls.Add(addNew);



            //Mostrar noticias si existen
            if (noticias.Count > 0)
            {
                showNews();
            }
            else
            {
                MessageBox.Show("No hi ha noticies.");
            }
        }

        //Mostrar la pantalla de añadir noticia
        private void button1_Click_1(object sender, EventArgs e)
        {
            new Add_News().Show();
        }

        // Meter todas las noticias en una lista y añadir los paneles de estas al FlowLayoutPanel
        static public void showNews()
        {
            Connection connection = new Connection();

            //connection.exportNews();
            connection.passarDadesPsp();
            flowLayoutPanel.Controls.Clear();
            for (int i = 0; i < noticias.Count; i++)
            {
                noticias[i].Show(); 
                flowLayoutPanel.Controls.Add(noticias[i]);
            }

            noticias = connection.exportNoticia(); // ← Rellenamos la lista correctamente


            flowLayoutPanel.Controls.Clear();

            foreach (News noticia in noticias)
            {
                flowLayoutPanel.Controls.Add(noticia);
            }
        }


        private void News_Tab_ClientSizeChanged(object sender, EventArgs e)
        {
            button1.Location = new Point(this.ClientSize.Width - button1.Width - 20, this.ClientSize.Height - button1.Height - 20);
            //addNew.Location = new Point(this.ClientSize.Width - button1.Width - 50, this.ClientSize.Height - button1.Height - 50);

        }

        private void News_Tab_Load(object sender, EventArgs e)
        {
       
        }

        private void News_Tab_Load_1(object sender, EventArgs e)
        {

        }
    }
}
