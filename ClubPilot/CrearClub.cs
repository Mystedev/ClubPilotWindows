using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClubPilot
{
    public partial class CrearClub : Form
    {
        private Connection db;
        public CrearClub()
        {
            InitializeComponent();
            db = new Connection();
        }

        private void CrearClub_Load(object sender, EventArgs e)
        {

            if (!(Usuari.usuari==null))
            {
                List<Dictionary<string, object>> club = db.ClubDusuari(Usuari.usuari.getIdClub().ToString());
                foreach (var registre in club)
                {
                    txtBoxNom.Text = (registre["nom"].ToString());
                    txtBoxData.Text = (registre["any_fundacio"].ToString());
                    txtBoxFundador.Text = (registre["fundador"].ToString());
                    txtBoxEmail.Text = (registre["emailfundador"].ToString());
                }
                txtBoxEmail.Enabled = false;
                txtBoxFundador.Enabled = false;

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxUsername1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png)|*.png";
            openFileDialog.Title = "Selecciona un archiu";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                MessageBox.Show("Archiu seleccionat: " + rutaArchivo);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if((!txtBoxData.Text.Equals(""))&& (!txtBoxNom.Text.Equals("")) && (!txtBoxFundador.Text.Equals("")))
            { 
                if ((Usuari.usuari == null))
                { 
                    String idlub=db.CrearClub(txtBoxNom.Text,txtBoxData.Text,txtBoxFundador.Text,txtBoxEmail.Text,"logo");
            String[] nomCognoms=txtBoxFundador.Text.Split(' ');

            String nom = nomCognoms[0];
            String cognoms="";
                for (int i = 1; i < nomCognoms.Length; i++) 
                {
                    cognoms += nomCognoms[i] + " ";
                }
                cognoms = cognoms.Trim();

                db.InsertCompte("",nom, cognoms, txtBoxEmail.Text,"administrador","",idlub);
                MessageBox.Show("club creat");
                }
                else
                {
                 
                    db.UpdateClub(Usuari.usuari.getIdClub().ToString(),txtBoxNom.Text, txtBoxData.Text, txtBoxFundador.Text, txtBoxEmail.Text);
                }
            }
            else
            {
             MessageBox.Show("camps sense emplenar");
            }
        }
    }   

}