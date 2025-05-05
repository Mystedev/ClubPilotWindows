using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class MainForm : Form
    {
        private Connection db;
        private Dictionary<Button, Type> menuFormsMap;
        private List<Panel> indicatorPanels;

        public MainForm()
        {
            db = new Connection();
         
            InitializeComponent();
            ConfigureInitialState();
            InitializeApplication();
            SetupMenuMappings();
           
        }


        private void InitializeApplication()
        {
           
            WindowState = FormWindowState.Maximized;
            menuVertical.Dock = DockStyle.Left;
            MainForm_Resize(null, null);
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            panelContainer1.Location = new Point(menuVertical.Width, 0); 
            panelContainer1.Size = new Size(
                ClientSize.Width - menuVertical.Width,
                ClientSize.Height - 20
            );
        }   
        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }
        private void SetupMenuMappings()
        {

          
             menuFormsMap = new Dictionary<Button, Type>
            {
                { btnMenSolClubs, typeof(Clubs) },
                { btnMenClub, typeof(CrearClub) },
                { btnMenComptes, typeof(Accounts) },
                { btnMenNoticies, typeof(News_Tab) },
                { btnMenJugadors, typeof(Players) },
                { btnMenEsdeveniments, typeof(Esdeveniments) }
                //{ button6, typeof(EquipsForm) } // Reemplazar con formulario real
            };

           
        }

        private void ConfigureInitialState()
        {
            LoadFormIntoPanel(typeof(Players));
            ConfigureMenuVisibility();
        }

        private void ConfigureMenuVisibility()
        {
           
            



            Connection.OpenConnection();
            String  rol= db.ObtenerRol(Usuari.usuari.getIdUsuari());
            Connection.CloseConnection();

       
            if (rol.Equals("a"))
            {
            

 
                this.btnMenSolClubs.Location = new System.Drawing.Point(12, 185);
                this.btnMenClub.Location = new System.Drawing.Point(12, 250);
                this.button6.Location = new System.Drawing.Point(12, 317);
                this.btnMenComptes.Location = new System.Drawing.Point(12, 382);
                this.btnMenNoticies.Location = new System.Drawing.Point(12, 447);
                this.btnMenJugadors.Location = new System.Drawing.Point(12, 512);
                this.btnMenEsdeveniments.Location = new System.Drawing.Point(12, 577);
                this.menuVertical.BackColor = System.Drawing.Color.MidnightBlue;
                this.menuVertical.Controls.Add(this.panelC);
                this.menuVertical.Controls.Add(this.pictureBox1);
                this.menuVertical.Location = new System.Drawing.Point(0, 0);
                this.menuVertical.Name = "menuVertical";
                this.menuVertical.Size = new System.Drawing.Size(285, 709);
                this.menuVertical.TabIndex = 2;
 
                btnMenEsdeveniments.Visible = false;
                btnMenEsdeveniments.Enabled = false;
                btnMenJugadors.Visible = false;
                btnMenJugadors.Enabled = false;
                this.btnMenClub.Location = new System.Drawing.Point(12, 185);
                this.button6.Location = new System.Drawing.Point(12, 250);
                this.btnMenComptes.Location = new System.Drawing.Point(12, 317);
                this.btnMenNoticies.Location = new System.Drawing.Point(12, 382);
                this.btnMenJugadors.Location = new System.Drawing.Point(12, 447);
                this.btnMenEsdeveniments.Location = new System.Drawing.Point(12, 512);


                this.menuVertical.Controls.Add(this.btnMenSolClubs);
                this.menuVertical.Controls.Add(this.btnMenEsdeveniments);
                this.menuVertical.Controls.Add(this.button6);
                this.menuVertical.Controls.Add(this.btnMenJugadors);
                this.menuVertical.Controls.Add(this.panel4);
                this.menuVertical.Controls.Add(this.btnMenNoticies);
                this.menuVertical.Controls.Add(this.panel2);
                this.menuVertical.Controls.Add(this.btnMenComptes);
                this.menuVertical.Controls.Add(this.btnMenClub);
                this.menuVertical.Controls.Add(this.panel3);
                this.menuVertical.Controls.Add(this.panel1);
                this.menuVertical.Controls.Add(this.pictureBox1);
                this.menuVertical.Location = new System.Drawing.Point(0, 0);
                this.menuVertical.Name = "menuVertical";
                this.menuVertical.Size = new System.Drawing.Size(285, 709);
                this.menuVertical.TabIndex = 2;
            }
            else if(rol.Equals("administrador"))
            {
                this.menuVertical.BackColor = System.Drawing.Color.MidnightBlue;
                this.menuVertical.Controls.Add(this.panelC);
                this.menuVertical.Controls.Add(this.pictureBox1);
                this.menuVertical.Location = new System.Drawing.Point(0, 0);
                this.menuVertical.Name = "menuVertical";
                this.menuVertical.Size = new System.Drawing.Size(285, 709);
                this.menuVertical.TabIndex = 2;
                btnMenSolClubs.Visible = false;
                btnMenSolClubs.Enabled = false;
                btnMenEsdeveniments.Visible = false;
                btnMenEsdeveniments.Enabled = false;
                btnMenJugadors.Visible = false;
                btnMenJugadors.Enabled = false;
                this.btnMenClub.Location = new System.Drawing.Point(12, 185);
                this.button6.Location = new System.Drawing.Point(12, 250);
                this.btnMenComptes.Location = new System.Drawing.Point(12, 317);
                this.btnMenNoticies.Location = new System.Drawing.Point(12, 382);
                this.btnMenJugadors.Location = new System.Drawing.Point(12, 447);
                this.btnMenEsdeveniments.Location = new System.Drawing.Point(12, 512);
           
                this.menuVertical.Controls.Add(this.btnMenEsdeveniments);
                this.menuVertical.Controls.Add(this.button6);
                this.menuVertical.Controls.Add(this.btnMenJugadors);
                this.menuVertical.Controls.Add(this.panel4);
                this.menuVertical.Controls.Add(this.btnMenNoticies);
                this.menuVertical.Controls.Add(this.panel2);
                this.menuVertical.Controls.Add(this.btnMenComptes);
                this.menuVertical.Controls.Add(this.btnMenClub);
                this.menuVertical.Controls.Add(this.panel3);
                this.menuVertical.Controls.Add(this.panel1);
                this.menuVertical.Controls.Add(this.pictureBox1);
                this.menuVertical.Location = new System.Drawing.Point(0, 0);
                this.menuVertical.Name = "menuVertical";
                this.menuVertical.Size = new System.Drawing.Size(285, 709);
                this.menuVertical.TabIndex = 2;

            }
            else if(rol.Equals("entrenador"))
            {
                this.menuVertical.BackColor = System.Drawing.Color.MidnightBlue;
                this.menuVertical.Controls.Add(this.panelC);
                btnMenSolClubs.Visible = false;
                btnMenSolClubs.Enabled = false;
                this.btnMenClub.Location = new System.Drawing.Point(12, 185);
                this.button6.Location = new System.Drawing.Point(12, 250);
                this.btnMenComptes.Location = new System.Drawing.Point(12, 317);
                this.btnMenNoticies.Location = new System.Drawing.Point(12, 382);
                this.btnMenJugadors.Location = new System.Drawing.Point(12, 317);
                this.btnMenEsdeveniments.Location = new System.Drawing.Point(12, 382);
              

                this.menuVertical.Controls.Add(this.btnMenEsdeveniments);
                this.menuVertical.Controls.Add(this.button6);
                this.menuVertical.Controls.Add(this.panel4);
                this.menuVertical.Controls.Add(this.btnMenJugadors);
                this.menuVertical.Controls.Add(this.panel2);
                this.menuVertical.Controls.Add(this.btnMenClub);
                this.menuVertical.Controls.Add(this.panel3);
                this.menuVertical.Controls.Add(this.panel1);
                this.menuVertical.Controls.Add(this.pictureBox1);
                this.menuVertical.Location = new System.Drawing.Point(0, 0);
                this.menuVertical.Name = "menuVertical";
                this.menuVertical.Size = new System.Drawing.Size(285, 709);
                this.menuVertical.TabIndex = 2;
            }
            
           
        }

        private void LoadFormIntoPanel(Type formType)
        {
            try
            {
                panelContainer1.Controls.Clear();
                var form = (Form)Activator.CreateInstance(formType);

                // No lo acoples para poder moverlo manualmente
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(100, 0); // Desplazado hacia la derecha

                panelContainer1.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}");
            }
        }


        private void ConfigureChildForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
        }
    




        private void MenuButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && menuFormsMap.TryGetValue(button, out Type formType))
            {
                LoadFormIntoPanel(formType);
            
            }
        }

        

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuVertical_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}