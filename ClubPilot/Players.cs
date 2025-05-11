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
            // Titol del formulari
            Label lblTitulo = new Label
            {
                Text = "Jugadors",
                Font = fontCascadiaCode,
                Size = new Size(200, 30),
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = true


            };
            fontCascadiaCode = new Font("Cascadia Code", 15);
            Label lblAfegir = new Label
            {
                Text = "Afegir Jugador",
                Font = fontCascadiaCode,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight
            };
            // Boto que al clicar-lo obra el formulari de crear un nou compte i un nou jugador
            Button botoAfegir = new Button { Image = Properties.Resources.icons8_añadir_30, Width = 40, Height = 40 };

            botoAfegir.Click += (sender, e) =>
            {
                new AddPlayer(this).Show();
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
            scrollPanel.Controls.Add(lblAfegir);
            scrollPanel.Controls.Add(botoAfegir);
            // Crido a la funció que obté els jugadors i els guardo a una llista
            jugadors = obtenirJugadors();
            // Carrego els jugadors al layout
            carregarJugadors();
            this.Resize += new EventHandler(Form_Resize);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            // Crido a la funció que em centra els controls quan la mida del formulari canvii
            colocarControls();

        }
        // Funció que centra els controls al formulari
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
                    else if (label.Text == "Afegir Jugador")
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
        // Funció que un cop afegit un compte torna a cridar a la funció d'obtenir els jugadors per actualitzar la llista i carrego els jugadores al layout
        /*public void addPlayertolist(Jugador jugador)
        {

            jugadors = obtenirJugadors();
            
            carregarJugadors();
        }*/

        // Funció que obté els jugadors de la base de dades i els afegeix a una llista
        private List<Jugador> obtenirJugadors()
        {
            List<Jugador> jugadorss = new List<Jugador>();

            List<Dictionary<string, object>> resultats = db.SelectJugadors(Usuari.usuari.getIdEquip());

            foreach (var registre in resultats)
            {
                jugadorss.Add(new Jugador(
                    registre["id"].ToString(),
                    registre["nom"].ToString(),
                    registre["cognoms"].ToString(),
                    registre["posicio"].ToString(),
                    int.Parse(registre["dorsal"].ToString()),
                    bool.Parse(registre["disponibilitat"].ToString())





                ));
            }

            return jugadorss;
        }
        // Funció que carregar els jugadors al layout 
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
            
            
            // Afegeixo els jugadores a la taula
            for (int i = 0; i < jugadors.Count; i++)
            {
                afegirJugadorATaula(layout, jugadors[i], i);
            }
            // Afegeixo el layout
            scrollPanel.Controls.Add(layout);
        }
        // Funció que un cop afegit un compte torna a cridar a la funció d'obtenir els jugadors per actualitzar la llista i carrego els jugadors al layout
        public void addPlayerToList(Jugador jugador)
        {

            jugadors = obtenirJugadors();
            carregarJugadors();
        }
        // Funció que dona el format de com es veuen els jugadores al layout
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
            string disponibleText = jugador.disponible ? "Disponible: Sí" : "Disponible: No";
            Label lblDisponible = new Label { Text = disponibleText, Font = fontCascadiaCode, Location = new Point(140, 123), ForeColor = Color.White, Width = 120 };
            

            int desplazamentY = 5;
            Button btnModificar = new Button { Image = Properties.Resources.icons8_modificar_30, Width = 40, Height = 40, Location = new Point(272,158), BackColor = Color.SeaShell };
            Button btnGuardar = new Button { Image = Properties.Resources.icons8_guardar_30, Width = 40, Height = 40, Enabled = false, Location = new Point(318, 158), BackColor = Color.SeaShell };
            Button btnEsborrar = new Button { Image = Properties.Resources.icons8_eliminar_30, Width = 40, Height = 40, Location = new Point(318, 14) , BackColor = Color.SeaShell };
            // El boto de modificar els jugadors
            btnModificar.Click += (sender, e) =>
            {
                txtPosicio.Enabled = true;
                txtDorsal.Enabled = true;
                
                btnModificar.Enabled = false;
                btnGuardar.Enabled = true;
            };
            // El boto de guardar els jugadors amb les respectives condicions per a poder guardar
            btnGuardar.Click += (sender, e) =>
            {
                txtPosicio.Enabled = false;
                txtDorsal.Enabled = false;
                btnModificar.Enabled = true;
                btnGuardar.Enabled = false;
                btnCamiseta.Text = txtDorsal.Text;
                if (txtDorsal.Text == "" || txtPosicio.Text == "")
                {
                    MessageBox.Show("Omple la informacio");
                    return;
                } else
                {
                    if (int.TryParse(txtDorsal.Text, out int dorsal))
                    {
                        if (dorsal < 0)
                        {
                            MessageBox.Show("El dorsal ha de ser un número superior o igual a 0");
                            return;
                        }
                        db.updateJugador(txtId.Text, dorsal, txtPosicio.Text);
                    }
                    else
                    {
                        MessageBox.Show("El dorsal ha de ser un número superior o igual a 0");
                        return;
                    }
                }
                   
            };
            // Esborrar de la base de dades i el layout el compte i el jugador
            btnEsborrar.Click += (sender, e) =>
            {
                
                    DialogResult result = MessageBox.Show(
                    "Segur que vol esborrar aquest Jugador? Usuari: " + jugadors[indexJugador].nom + " " + jugadors[indexJugador].cognoms,
                    "Confirmar eliminació",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                    if (result == DialogResult.Yes)
                    {
                        
                        jugadors.RemoveAt(indexJugador);
                        // Eliminar el compte de la base de dades que a la vegada esborra el jugador
                        db.deleteJugador(txtId.Text);
                        if (layout != null)
                        {
                            scrollPanel.Controls.Remove(layout);
                            layout.Dispose();
                        }
                        // Torno a carregar els jugadors
                        carregarJugadors();
                    }

                
            };



            // Afegeixo els controls al panel intern
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



            // Afegeixo el panel intern al panel
            panell.Controls.Add(panellIntern);
            
        }


        private void Players_Load(object sender, EventArgs e)
        {

        }

        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
        // Classe compte amb els seus atributs
        public class Jugador
        {
            public string id { get; set; }
            public string nom { get; set; }
            public string cognoms { get; set; }
            public string posicio { get; set; }
            public int dorsal { get; set; }
            
            public bool disponible { get; set; }


            public Jugador(string id, string nom, string cognoms, string posicio, int dorsal, bool disponible)
            {
                this.id = id;
                this.nom = nom;
                this.cognoms = cognoms;
                this.disponible = disponible;
                this.dorsal = dorsal;
                this.posicio = posicio;
                
            }
            public string toString()
            {
                return nom + " " + cognoms + " " + posicio + " " + dorsal + disponible;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
