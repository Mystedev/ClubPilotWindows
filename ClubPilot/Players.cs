using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClubPilot.Accounts;

namespace ClubPilot
{
    public partial class Players: Form
    {
        List<Jugador> jugadors;
        private FlowLayoutPanel layout;
        private Panel scrollPanel;
        private Connection db;
        public Players()
        {
            db = new Connection();
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Font fontCascadiaCode = new Font("Cascadia Code", 30);
            this.Controls.Clear();
            Label lblTitulo = new Label
            {
                Text = "Jugadors",
                Font = fontCascadiaCode,
                Size = new Size(200, 30),
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = true


            };
            // Panel que mostrarà la informació
            scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10, 200, 10, 10)
            };
            this.Controls.Add(scrollPanel);
            scrollPanel.Controls.Add(lblTitulo);
            // Crido a la funció que obté els comptes i els guardo a una llista
            jugadors = obtenirJugadors();
            carregarJugadors();
            this.Resize += new EventHandler(Form_Resize);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            // Crido a la funció que em centra els controls quan la mida del formulari canvii
            colocarControls();

        }
        private void colocarControls()
        {
            foreach (Control control in scrollPanel.Controls)
            {
                if (control is Label label)
                {

                    if (label.Text == "Jugadors")
                    {
                        label.Location = new Point(
                            (scrollPanel.ClientSize.Width - label.Width) / 2,
                            40
                        );
                    }
                    else if (label.Text == "Informació Comptes")
                    {
                        label.Location = new Point(60, 150);
                    }
                    else if (label.Text == "Afegir compte")
                    {
                        label.Location = new Point(this.ClientSize.Width - 300, 150);
                    }
                }
                else if (control is Button button)
                {
                    button.Location = new Point(this.ClientSize.Width - 110, 150);
                }
            }
        }
        // Funció que un cop afegit un compte torna a cridar a la funció d'obtenir els comptes per actualitzar la llista i carrego els comptes al layout
        public void addPlayertolist(Jugador jugador)
        {

            jugadors = obtenirJugadors();
            carregarJugadors();
        }

        // Funció que obté els jugadors de la base de dades i els afegeix a una llista
        private List<Jugador> obtenirJugadors()
        {
            List<Jugador> jugadors = new List<Jugador>();

            List<Dictionary<string, object>> resultats = db.SelectJugadors(Usuari.usuari.getIdEquip());

            foreach (var registre in resultats)
            {
                jugadors.Add(new Jugador(
                    registre["id"].ToString(),
                    registre["nom"].ToString(),
                    registre["cognoms"].ToString(),
                    bool.Parse(registre["disponibilitat"].ToString()),
                     int.Parse(registre["dorsal"].ToString()),
                    registre["posicio"].ToString()
                    
                    

                ));
            }
            //jugadors.Add(new Jugador("1", "Javier", "García", true, 10, "Delantero"));

            return jugadors;
        }
        // Funció que carregar els comptes al layout 
        private void carregarJugadors()
        {
            if (layout != null)
            {
                scrollPanel.Controls.Remove(layout);
                layout.Dispose();
            }

            layout = new FlowLayoutPanel
            {
                AutoSize = true,
                BackColor = Color.SeaShell,
                Padding = new Padding(10),
                Dock = DockStyle.Top,
                Width = scrollPanel.ClientSize.Width - 20,
            };
            
            
            // Afegeixo els comptes a la taula
            for (int i = 0; i < jugadors.Count; i++)
            {
                afegirJugadorATaula(layout, jugadors[i], i);
            }
            // Afegeixo el layout
            scrollPanel.Controls.Add(layout);
        }
        // Funció que dona el format de com es veuen els comptes al layout
        private void afegirJugadorATaula(FlowLayoutPanel panell, Jugador jugador, int indexJugador)
        {
            Panel panellIntern = new Panel { Width= 363, Height= 209, AutoSize = true, BackColor = Color.MidnightBlue };
            panellIntern.SuspendLayout();
            Font fontCascadiaCode = new Font("Cascadia Code", 10);
            TextBox txtId = new TextBox { Text = jugador.id, Width = 140, Font = fontCascadiaCode, Visible = false };
            fontCascadiaCode = new Font("Cascadia Code", 16);
            TextBox txtNomCognoms = new TextBox { Text = jugador.nom + " " + jugador.cognoms, Width = 295, Font = fontCascadiaCode, Enabled = false, Location = new Point(17,18), BackColor = Color.SeaShell };
            Button btnCamiseta = new Button { Image = Properties.Resources.camisetaJugador, Width = 117, Height = 147, Location = new Point(17, 51), Text = jugador.dorsal.ToString(), Font =  fontCascadiaCode};
            fontCascadiaCode = new Font("Cascadia Code", 10);
            TextBox txtPosicio = new TextBox { Text = jugador.posicio, Width = 168, Font = fontCascadiaCode, Enabled = false, Location = new Point(144, 60), BackColor = Color.SeaShell };
            TextBox txtDorsal = new TextBox { Text = jugador.dorsal.ToString(), Width = 54, Font = fontCascadiaCode, Enabled = false, Location = new Point(144, 93), BackColor = Color.SeaShell };
            Label lblDisponible = new Label { Text = "Disponible:" + " " + (jugador.disponible ? "Sí" : "No"), Font = fontCascadiaCode, Location = new Point(140, 123), ForeColor = Color.White };
            

            int desplazamentY = 5;
            Button btnModificar = new Button { Image = Properties.Resources.icons8_modificar_30, Width = 40, Height = 40, Location = new Point(272,158), BackColor = Color.SeaShell };
            Button btnGuardar = new Button { Image = Properties.Resources.icons8_guardar_30, Width = 40, Height = 40, Enabled = false, Location = new Point(318, 158), BackColor = Color.SeaShell };
            Button btnEsborrar = new Button { Image = Properties.Resources.icons8_eliminar_30, Width = 40, Height = 40, Location = new Point(318, 14) , BackColor = Color.SeaShell };
            // Obre els textBox
            btnModificar.Click += (sender, e) =>
            {
                txtPosicio.Enabled = true;
                txtDorsal.Enabled = true;
                
                btnModificar.Enabled = false;
                btnGuardar.Enabled = true;
            };
            // Tancar els textbox i ho guarda a la base de dades
            btnGuardar.Click += (sender, e) =>
            {
                txtPosicio.Enabled = false;
                txtDorsal.Enabled = false;
                btnModificar.Enabled = true;
                btnGuardar.Enabled = false;
                //db.updateJugador(txtId.Text, txtPosicio.Text, txtDorsal.Text);
            };
            // Esborrar de la base de dades i el layout el compte
            btnEsborrar.Click += (sender, e) =>
            {
                
                    DialogResult result = MessageBox.Show(
                    "Segur que vol esborrar aquest compte? Usuari:" + jugadors[indexJugador].nom + jugadors[indexJugador].cognoms,
                    "Confirmar eliminació",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                    if (result == DialogResult.Yes)
                    {
                        // Eliminar el club si asi lo desea el usuario
                        jugadors.RemoveAt(indexJugador);
                        //db.deleteJugador(txtId.Text);
                        //db.deleteCompte(txtId.Text);


                        if (layout != null)
                        {
                            scrollPanel.Controls.Remove(layout);
                            layout.Dispose();
                        }
                        // Torno a carregar els comptes
                        carregarJugadors();
                    }

                
            };



            // Afegeixo els controls al panel
            panellIntern.Controls.Add(txtId);
            panellIntern.Controls.Add(txtNomCognoms);
            panellIntern.Controls.Add(btnCamiseta);
            panellIntern.Controls.Add(txtPosicio);
            panellIntern.Controls.Add(txtDorsal);
            panellIntern.Controls.Add(lblDisponible);
            panellIntern.Controls.Add(btnModificar);
            panellIntern.Controls.Add(btnGuardar);
            panellIntern.Controls.Add(btnEsborrar);

            panellIntern.ResumeLayout();



            // Afegeixo els botons
           layout.Controls.Add(panellIntern);
            
        }


        private void Players_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Boto de equip de futbol
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Boto de equip de basketball
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void jugadorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CrearClub().Show();
        }

        private void comptesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Accounts().Show();
        }

        private void noticiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new News().Show();
        }

        private void esdevenimentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Esdeveniments().Show();
        }

        private void sollicitudsDeClubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Clubs().Show();
        }
        // Classe compte amb els seus atributs
        public class Jugador
        {
            public string id { get; set; }
            public string nom { get; set; }
            public string cognoms { get; set; }
            public bool disponible { get; set; }
            public int dorsal { get; set; }
            public string posicio { get; set; }
           

            public Jugador(string id, string nom, string cognoms, bool disponible, int dorsal, string posicio)
            {
                this.id = id;
                this.nom = nom;
                this.cognoms = cognoms;
                this.disponible = disponible;
                this.dorsal = dorsal;
                this.posicio = posicio;
                
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
