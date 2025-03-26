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
            String a=db.CrearClub(txtBoxNom.Text,txtBoxData.Text,txtBoxFundador.Text,"logo");
            MessageBox.Show(a);
            }
            else
            {
             MessageBox.Show("camps sense emplenar");
            }
        }
    }   

}