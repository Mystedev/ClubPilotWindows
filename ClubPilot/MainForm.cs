using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class MainForm : Form
    {
        private Connection db;
        private Panel panelContainer;
        public MainForm()
        {
            InitializeComponent();
            db = new Connection();
            this.WindowState = FormWindowState.Maximized;
            /*panelContainer = new Panel
            {
                Dock = DockStyle.Fill

            };*/
            menuVertical.Dock = DockStyle.Left;
            panelContainer = new Panel
            {
                Dock = DockStyle.Fill

            };
            //panelContainer.Location = new Point(288, 0);
            //this.Controls.Add(panelContainer);
            // Form1 form1 = new Form1(panelContainer);
            // Cargar Form1 en el panel
            panelContainer1.Controls.Clear();

            // Configurar el formulario para que se comporte como un control secundario
            /*form1.TopLevel = false;
            form1.FormBorderStyle = FormBorderStyle.None;
            form1.Dock = DockStyle.Fill;

            // Agregar el formulario al panel
            panelContainer.Controls.Add(form1);

            // Mostrar el formulario
            form1.Show();*/
            LoadFormIntoPanel(new Players());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Si tanquem aquest formulari també tanquem l'aplicació
            //this.Controls.Remove(panelC);
            this.FormClosed += (s, args) => Application.Exit();
            
        }
        private void LoadFormIntoPanel(Form form)
        {
            // Limpiar cualquier control existente en el panel
            db.OpenConnection ();
            String  rol= db.ObtenerRol(Usuari.usuari.getIdUsuari());
            db.CloseConnection();
            
            // Aquí defines tu condición
            if (rol.Equals("a"))
            {
                //menuStrip1.Items.Insert(0, sollicitudsDeClubsToolStripMenuItem); // O Add() si prefieres al final
            }

            //menuStrip1.Visible = true;
            panelContainer1.Controls.Clear();

            // Configurar el formulari per a que es comporti com un control secundari
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Afegir el formulari al panel
            panelContainer1.Controls.Add(form);

            // Mostrar el formulari
            form.Show();

        }
        private void btnMenSolClubs_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Clubs());
        }
        // Botons del menú
        private void btnMenClub_Click(object sender, EventArgs e)
        {
            //LoadFormIntoPanel(new CrearClub());
            new CrearClub().Show();
        }

        private void btnMenComptes_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Accounts());
        }

        private void btnMenNoticies_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new News_Tab());
        }

        private void btnMenJugadors_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Players());
        }

        private void btnMenEsdeveniments_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Esdeveniments());
        }
        // Recalculo la mida del panel
        private void MainForm_Resize(object sender, EventArgs e)
        {
            panelContainer1.Width = this.ClientSize.Width - menuVertical.Width;
            panelContainer1.Height = this.ClientSize.Height - 20;
        }
    }
}
