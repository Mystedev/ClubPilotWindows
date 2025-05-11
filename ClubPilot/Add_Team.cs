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
    public partial class Add_Team : Form
    {
        public Add_Team()
        {
            InitializeComponent();
        }

        private void button_crear_Click(object sender, EventArgs e)
        {
            Equip equipo = new Equip(textBox_nom.Text, textBox_categoria.Text, textBox_divisio.Text);
            Connection db = new Connection();
            db.InsertEquip(equipo);
            MessageBox.Show("Equip creat correctament");
            this.Close();
        }
    }
}
