using ClubPilot.Properties;
using MySql.Data.MySqlClient;
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

namespace ClubPilot
{
    public partial class Accounts : Form
    {
        private List<Compte> comptes;
        private TableLayoutPanel layout;
        private Panel scrollPanel;
        public Accounts()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            Connection myConnection = new Connection();
            myConnection.exportNoticia();
            myConnection.exportUsuari();
            myConnection.exportClub();
            myConnection.exportTipusEsdeveniment();
            myConnection.exportEsdeveniment();


            // Realiza operaciones con la base de datos...

            //myConnection.CloseConnection();
            Font fontCascadiaCode = new Font("Cascadia Code", 10);


            Label lblTitulo = new Label
            {
                Text = "Gestionar Comptes",
                Font = fontCascadiaCode,
                Size = new Size(200, 30), // Ajusta la mida segons sigui necessari
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblTitulo.Location = new Point(
                (this.ClientSize.Width - lblTitulo.Width) / 2,
                10 // Ajusta la distància des de la part superior segons sigui necessari
            );

            // Crear i configurar l'etiqueta de l'esquerra
            Label lblInformacio = new Label
            {
                Text = "Informació comptes",
                Font = fontCascadiaCode,
                AutoSize = true
            };
            lblInformacio.Location = new Point(10, 50);

            Label lblAfegir = new Label
            {
                Text = "Afegir compte",
                Font = fontCascadiaCode,
                AutoSize = true
            };

            lblAfegir.Location = new Point(this.ClientSize.Width - 200, 50); // Ajusta la posició segons sigui necessari

            Button botoAfegir = new Button { Image = Properties.Resources.icons8_añadir_30, Width = 40, Height = 40 };
            botoAfegir.Location = new Point(this.ClientSize.Width - 10, 50);
            botoAfegir.Click += (sender, e) =>
            {
                new AddAccount().Show();


            };


            scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(scrollPanel);
            scrollPanel.Controls.Add(lblTitulo);
            scrollPanel.Controls.Add(lblInformacio);
            scrollPanel.Controls.Add(lblAfegir);
            scrollPanel.Controls.Add(botoAfegir);
            comptes = ObtenirComptes();
            CarregarComptes();
        }
        private List<Compte> ObtenirComptes()
        {
            // Aquí has d'implementar la lògica per obtenir els comptes
            // Per exemple, des d'una base de dades o una llista predefinida
            return new List<Compte>
            {
                // Comptes de prova
                new Compte("usuari1", "Nom1", "Cognoms1", "email1@example.com", "Rol1"),
                new Compte("usuari2", "Nom2", "Cognoms2", "email2@example.com", "Rol2"),
                new Compte("usuari1", "Nom1", "Cognoms1", "email1@example.com", "Rol1"),
                new Compte("usuari2", "Nom2", "Cognoms2", "email2@example.com", "Rol2"),
                new Compte("usuari1", "Nom1", "Cognoms1", "email1@example.com", "Rol1"),
                new Compte("usuari2", "Nom2", "Cognoms2", "email2@example.com", "Rol2"),
                new Compte("usuari1", "Nom1", "Cognoms1", "email1@example.com", "Rol1"),
                new Compte("usuari2", "Nom2", "Cognoms2", "email2@example.com", "Rol2"),
                new Compte("usuari1", "Nom1", "Cognoms1", "email1@example.com", "Rol1"),
                new Compte("usuari1", "Nom1", "Cognoms1", "email1@example.com", "Rol1"),
                new Compte("usuari2", "Nom2", "Cognoms2", "email2@example.com", "Rol2"),
                new Compte("usuari1", "Nom1", "Cognoms1", "email1@example.com", "Rol1"),
                new Compte("usuari2", "Nom2", "Cognoms2", "email2@example.com", "Rol2"),
                new Compte("usuari2", "Nom2", "Cognoms2", "email2@example.com", "Rol2"),
                new Compte("usuari2", "Nom2", "Cognoms2", "email2@example.com", "Rol2"),
                // Afegir més comptes segons sigui necessari
            };
        }
        private void Accounts_Load(object sender, EventArgs e)
        {

        }
        private void CarregarComptes()
        {
            // Eliminar el TableLayoutPanel antic si existeix
            if (layout != null)
            {
                scrollPanel.Controls.Remove(layout);
                layout.Dispose();
            }

            // Crear un nou TableLayoutPanel
            layout = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                AutoSize = true,
                BackColor = Color.SeaShell,
                Padding = new Padding(100),
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F)); // Primera columna 85%
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));  // Segona columna 5%
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));  // Tercera columna 5%
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));

            // Ajustar el nombre de files segons el nombre de comptes
            layout.RowCount = comptes.Count;
            foreach (var _ in comptes)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F)); // Alçada fixa de 70 píxels per fila
            }

            // Afegir comptes al TableLayoutPanel
            for (int i = 0; i < comptes.Count; i++)
            {
                AfegirCompteATaula(layout, comptes[i], i);
            }

            // Afegir el TableLayoutPanel al formulari
            scrollPanel.Controls.Add(layout);


        }
        private void AfegirCompteATaula(TableLayoutPanel panell, Compte compte, int indexFila)
        {
            Panel panellIntern = new Panel { Dock = DockStyle.Fill, AutoSize = true };
            panellIntern.SuspendLayout();
            Font fontCascadiaCode = new Font("Cascadia Code", 10);

            // Crear etiquetes i camps de text
            Label lblUsuari = new Label { Text = "Usuari:", Font = fontCascadiaCode };
            TextBox txtUsuari = new TextBox { Text = compte.usuari, Width = 150, Left = 75, Font = fontCascadiaCode, Enabled = false };

            Label lblNom = new Label { Text = "Nom:", Left = 300, Font = fontCascadiaCode };
            TextBox txtNom = new TextBox { Text = compte.nom, Width = 150, Left = 375, Font = fontCascadiaCode, Enabled = false };

            Label lblCognoms = new Label { Text = "Cognoms:", Left = 600, Font = fontCascadiaCode };
            TextBox txtCognoms = new TextBox { Text = compte.cognoms, Width = 200, Left = 675, Font = fontCascadiaCode, Enabled = false };

            Label lblCorreu = new Label { Text = "Correu:", Left = 900, Font = fontCascadiaCode };
            TextBox txtCorreu = new TextBox { Text = compte.correu, Width = 200, Left = 975, Font = fontCascadiaCode, Enabled = false };

            Label lblRol = new Label { Text = "Rol:", Left = 1200, Font = fontCascadiaCode };
            TextBox txtRol = new TextBox { Text = compte.rol, Width = 100, Left = 1275, Font = fontCascadiaCode, Enabled = false };

            // Configurar la posició de les etiquetes i camps de text
            int desplazamentY = 5;

            lblUsuari.Location = new Point(5, desplazamentY);
            txtUsuari.Location = new Point(lblUsuari.Right + 5, desplazamentY);

            lblNom.Location = new Point(txtUsuari.Right + 20, desplazamentY);
            txtNom.Location = new Point(lblNom.Right + 5, desplazamentY);

            lblCognoms.Location = new Point(txtNom.Right + 20, desplazamentY);
            txtCognoms.Location = new Point(lblCognoms.Right + 5, desplazamentY);

            lblCorreu.Location = new Point(txtCognoms.Right + 20, desplazamentY);
            txtCorreu.Location = new Point(lblCorreu.Right + 5, desplazamentY);

            lblRol.Location = new Point(txtCorreu.Right + 20, desplazamentY);
            txtRol.Location = new Point(lblRol.Right + 5, desplazamentY);

            // Afegir controls al panell
            panellIntern.Controls.Add(lblUsuari);
            panellIntern.Controls.Add(txtUsuari);
            panellIntern.Controls.Add(lblNom);
            panellIntern.Controls.Add(txtNom);
            panellIntern.Controls.Add(lblCognoms);
            panellIntern.Controls.Add(txtCognoms);
            panellIntern.Controls.Add(lblCorreu);
            panellIntern.Controls.Add(txtCorreu);
            panellIntern.Controls.Add(lblRol);
            panellIntern.Controls.Add(txtRol);

            panellIntern.ResumeLayout();



            // Crear botons
            Button btnModificar = new Button { Image = Properties.Resources.icons8_modificar_30, Width = 40, Height = 40 };
            Button btnGuardar = new Button { Image = Properties.Resources.icons8_guardar_30, Width = 40, Height = 40, Enabled = false };
            Button btnEsborrar = new Button { Image = Properties.Resources.icons8_eliminar_30, Width = 40, Height = 40 };

            btnModificar.Click += (sender, e) =>
            {
                // Habilitar l'edició dels camps
                txtUsuari.Enabled = true;
                txtNom.Enabled = true;
                txtCognoms.Enabled = true;
                txtCorreu.Enabled = true;
                btnModificar.Enabled = false;
                btnGuardar.Enabled = true;
            };

            btnGuardar.Click += (sender, e) =>
            {
                // Guardar els canvis
                txtUsuari.Enabled = false;
                txtNom.Enabled = false;
                txtCognoms.Enabled = false;
                txtCorreu.Enabled = false;
                btnModificar.Enabled = true;
                btnGuardar.Enabled = false;
            };

            btnEsborrar.Click += (sender, e) =>
            {
                if (indexFila >= 0 && indexFila < comptes.Count)
                {
                    // Eliminar el compte de la llista
                    comptes.RemoveAt(indexFila);
                    // Recarregar els comptes
                    CarregarComptes();
                }
            };

            // Afegir controls al TableLayoutPanel
            panell.Controls.Add(panellIntern, 0, indexFila);
            panell.Controls.Add(btnModificar, 1, indexFila);
            panell.Controls.Add(btnGuardar, 2, indexFila);
            panell.Controls.Add(btnEsborrar, 3, indexFila);
        }
    }



    public class Compte
    {
        public string usuari { get; set; }
        public string nom { get; set; }
        public string cognoms { get; set; }
        public string correu { get; set; }
        public string rol { get; set; }

        public Compte(string usuari, string nom, string cognoms, string correu, string rol)
        {
            this.usuari = usuari;
            this.nom = nom;
            this.cognoms = cognoms;
            this.correu = correu;
            this.rol = rol;
        }
    }
}
