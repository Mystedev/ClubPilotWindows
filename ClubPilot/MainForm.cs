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
            panelContainer = new Panel
            {
                Dock = DockStyle.Fill
            };

            panelContainer = new Panel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(panelContainer);
           // Form1 form1 = new Form1(panelContainer);
            // Cargar Form1 en el panel
            panelContainer.Controls.Clear();

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
                menuStrip1.Items.Insert(0, sollicitudsDeClubsToolStripMenuItem); // O Add() si prefieres al final
            }

            menuStrip1.Visible = true;
            panelContainer.Controls.Clear();

            // Configurar el formulario para que se comporte como un control secundario
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Agregar el formulario al panel
            panelContainer.Controls.Add(form);

            // Mostrar el formulario
            form.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sollicitudsDeClubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Clubs());
        }

        private void clubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new CrearClub());
        }

        private void comptesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Accounts());
        }

        private void noticiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new News_Tab());
        }

        private void jugadorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Players());
        }

        private void esdevenimentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Esdeveniments());
        }
    }
}
