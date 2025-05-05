using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class Accounts : Form
    {
        private List<Compte> comptes;
        private TableLayoutPanel layout;
        private Panel scrollPanel;
        private Connection db;

        public Accounts()
        {
            db = new Connection();
            InitializeComponent();
          
            this.WindowState = FormWindowState.Maximized;


            Connection myConnection = new Connection();
            //myConnection.exportNoticia();
            //myConnection.exportUsuari();
            //myConnection.exportClub();
            //myConnection.exportTipusEsdeveniment();
            //myConnection.exportEsdeveniment();

            // Realiza operaciones con la base de datos...

            //myConnection.CloseConnection();


           
            Font fontCascadiaCode = new Font("Cascadia Code", 30);

            Label lblTitulo = new Label
            {
                Text = "Gestionar Comptes",
                Font = fontCascadiaCode,
                Size = new Size(200, 30),
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = true


            };
            fontCascadiaCode = new Font("Cascadia Code", 15);
            Label lblInformacio = new Label
            {
                Text = "Informació Comptes",
                Font = fontCascadiaCode,
                AutoSize = true,



            };

            Label lblAfegir = new Label
            {
                Text = "Afegir compte",
                Font = fontCascadiaCode,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight
            };


            lblAfegir.Location = new Point(this.ClientSize.Width - 200, 50); 

            // Boto que al clicar-lo obra el formulari de crear un nou compte
            Button botoAfegir = new Button { Image = Properties.Resources.icons8_añadir_30, Width = 40, Height = 40 };

            botoAfegir.Click += (sender, e) =>
            {
                new AddAccount(this).Show();
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
            scrollPanel.Controls.Add(lblInformacio);
            scrollPanel.Controls.Add(lblAfegir);
            scrollPanel.Controls.Add(botoAfegir);


            // Crido a la funció que obté els comptes i els guardo a una llista
            comptes = obtenirComptes();
            carregarComptes();
            this.Resize += new EventHandler(Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            // Crido a la funció que em centra els controls quan la mida del formulari canvii
            colocarControls();

        }
        // Funcio que ficar els controls a la seva posició
        private void colocarControls()
        {
            foreach (Control control in scrollPanel.Controls)
            {
                if (control is Label label)
                {

                    if (label.Text == "Gestionar Comptes")
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
        public void addAccountToList(Compte compte)
        {

            comptes = obtenirComptes();
            carregarComptes();
        }
        // Funció que obté els comptes del club de la base de dades i els retorna en llista
        private List<Compte> obtenirComptes()
        {
            List<Compte> comptes = new List<Compte>();

            List<Dictionary<string, object>> resultats = db.SelectComptes();

            foreach (var registre in resultats)
            {
                comptes.Add(new Compte(
                    registre["id"].ToString(),
                    registre["username"].ToString(),
                    registre["nom"].ToString(),
                    registre["cognoms"].ToString(),
                    registre["email"].ToString(),
                    registre["rol"].ToString()
                  
                ));
            }

            return comptes;
        }

        // Funció que carregar els comptes al layout 
        private void carregarComptes()
        {
            if (layout != null)
            {
                scrollPanel.Controls.Remove(layout);
                layout.Dispose();
            }

            layout = new TableLayoutPanel
            {
                ColumnCount = 4,
                AutoSize = true,
                BackColor = Color.SeaShell,
                Padding = new Padding(10),
                Dock = DockStyle.Top,
                Width = scrollPanel.ClientSize.Width - 20,
            };
            // Defineixo les mides de les columnes del table layout
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            layout.RowCount = comptes.Count;
            // Afegeixo un estil de fila per cada compte
            foreach (var _ in comptes)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            }
            // Afegeixo els comptes a la taula
            for (int i = 0; i < comptes.Count; i++)
            {
                afegirCompteATaula(layout, comptes[i], i);
            }
            // Afegeixo el layout
            scrollPanel.Controls.Add(layout);
        }
        // Funció que dona el format de com es veuen els comptes al layout
        private void afegirCompteATaula(TableLayoutPanel panell, Compte compte, int indexFila)
        {
            Panel panellIntern = new Panel { Dock = DockStyle.Fill, AutoSize = true };
            panellIntern.SuspendLayout();
            Font fontCascadiaCode = new Font("Cascadia Code", 10);
            TextBox txtId = new TextBox { Text = compte.id, Width = 140, Font = fontCascadiaCode, Visible = false };


            Label lblUsuari = new Label { Text = "Usuari:", Font = fontCascadiaCode, TextAlign = ContentAlignment.TopRight };
            TextBox txtUsuari = new TextBox { Text = compte.usuari, Width = 80, Font = fontCascadiaCode, Enabled = false };

            Label lblNom = new Label { Text = "Nom:", Font = fontCascadiaCode, TextAlign = ContentAlignment.TopRight, Width = 60 };
            TextBox txtNom = new TextBox { Text = compte.nom, Width = 80, Font = fontCascadiaCode, Enabled = false };

            Label lblCognoms = new Label { Text = "Cognoms:", Font = fontCascadiaCode, TextAlign = ContentAlignment.TopRight };
            TextBox txtCognoms = new TextBox { Text = compte.cognoms, Width = 80, Font = fontCascadiaCode, Enabled = false };

            Label lblCorreu = new Label { Text = "Correu:", Font = fontCascadiaCode, TextAlign = ContentAlignment.TopRight };
            TextBox txtCorreu = new TextBox { Text = compte.correu, Width = 150, Font = fontCascadiaCode, Enabled = false };

            Label lblRol = new Label { Text = "Rol:", Font = fontCascadiaCode, TextAlign = ContentAlignment.TopRight, Width = 60 };
            TextBox txtRol = new TextBox { Text = compte.rol, Width = 130, Font = fontCascadiaCode, Enabled = false };

            int desplazamentY = 5;
            // Definir posicionament
            lblUsuari.Location = new Point(5, desplazamentY);
            txtUsuari.Location = new Point(lblUsuari.Right, desplazamentY);

            lblNom.Location = new Point(txtUsuari.Right, desplazamentY);
            txtNom.Location = new Point(lblNom.Right, desplazamentY);

            lblCognoms.Location = new Point(txtNom.Right, desplazamentY);
            txtCognoms.Location = new Point(lblCognoms.Right, desplazamentY);

            lblCorreu.Location = new Point(txtCognoms.Right, desplazamentY);
            txtCorreu.Location = new Point(lblCorreu.Right, desplazamentY);

            lblRol.Location = new Point(txtCorreu.Right, desplazamentY);
            txtRol.Location = new Point(lblRol.Right, desplazamentY);
            // Afegeixo els controls al panel
            panellIntern.Controls.Add(txtId);
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


            Button btnModificar = new Button { Image = Properties.Resources.icons8_modificar_30, Width = 40, Height = 40 };
            Button btnGuardar = new Button { Image = Properties.Resources.icons8_guardar_30, Width = 40, Height = 40, Enabled = false };
            Button btnEsborrar = new Button { Image = Properties.Resources.icons8_eliminar_30, Width = 40, Height = 40 };
            // Obre els textBox
            btnModificar.Click += (sender, e) =>
            {
                txtUsuari.Enabled = true;
                txtNom.Enabled = true;
                txtCognoms.Enabled = true;
                txtCorreu.Enabled = true;
                btnModificar.Enabled = false;
                btnGuardar.Enabled = true;
            };
            // Tancar els textbox i ho guarda a la base de dades
            btnGuardar.Click += (sender, e) =>
            {
                txtUsuari.Enabled = false;
                txtNom.Enabled = false;
                txtCognoms.Enabled = false;
                txtCorreu.Enabled = false;
                btnModificar.Enabled = true;
                btnGuardar.Enabled = false;
                db.updateCompte(txtId.Text, txtUsuari.Text, txtNom.Text, txtCognoms.Text, txtCorreu.Text);
            };
            // Esborrar de la base de dades i el layout el compte
            btnEsborrar.Click += (sender, e) =>
            {
                if (indexFila >= 0 && indexFila < comptes.Count)
                {
                    DialogResult result = MessageBox.Show(
                    "Segur que vol esborrar aquest compte? Usuari:" + comptes[indexFila].usuari,
                    "Confirmar eliminació",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                    if (result == DialogResult.Yes)
                    {
                        // Eliminar el club si asi lo desea el usuario
                        comptes.RemoveAt(indexFila);
                        db.deleteCompte(txtId.Text);

                        
                        if (layout != null)
                        {
                            scrollPanel.Controls.Remove(layout);
                            layout.Dispose();
                        }
                        // Torno a carregar els comptes
                        carregarComptes();
                    }

                }
            };
            // Afegeixo els botons
            panell.Controls.Add(panellIntern, 0, indexFila);
            panell.Controls.Add(btnModificar, 1, indexFila);
            panell.Controls.Add(btnGuardar, 2, indexFila);
            panell.Controls.Add(btnEsborrar, 3, indexFila);
        }


        private void Accounts_Load(object sender, EventArgs e)
        {
          
        }


        // Classe compte amb els seus atributs
        public class Compte
        {
            public string id { get; set; }
            public string usuari { get; set; }
            public string nom { get; set; }
            public string cognoms { get; set; }
            public string correu { get; set; }
            public string rol { get; set; }

            public Compte(string id, string usuari, string nom, string cognoms, string correu, string rol)
            {
                this.id = id;
                this.usuari = usuari;
                this.nom = nom;
                this.cognoms = cognoms;
                this.correu = correu;
                this.rol = rol;
            }
        }
    }
}

