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
        public CrearClub()
        {
            InitializeComponent();
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
            openFileDialog.Filter = "Archius d'imatge (*.png)"; // Filtros opcionales
            openFileDialog.Title = "Selecciona un archiu";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                MessageBox.Show("Archivu seleccionat: " + rutaArchivo);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}