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
    public partial class Players: Form
    {
        public Players()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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
    }
}
