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
    public partial class AddPlayer : Form
    {
        private Players playersFormulari;
        private Connection db;
        public AddPlayer(Players playersFormulari)
        {
            db = new Connection();
            InitializeComponent();
            this.playersFormulari = playersFormulari;

        }
        // Quan es clica al boto de afegir jugador, es fa la validacio de que els camps estiguin omplerts i es fa la insercio a la base de dades
        private void btn_add_account_Click(object sender, EventArgs e)
        {
            if (txtBoxUsername1.Text == "" || txtBoxEmail1.Text == "" || txtBoxNom1.Text == "" || txtBoxCognoms1.Text == "" || txtBoxPosicio.Text == "" || pickNum.Value.ToString() == "")
            {
                MessageBox.Show("Omple tota la informació.");
                return;
            }
            else
            {
                String usuari = txtBoxUsername1.Text;
                String correu = txtBoxEmail1.Text;
                String nom = txtBoxNom1.Text;
                String cognoms = txtBoxCognoms1.Text;
                String posicio = txtBoxPosicio.Text;
                int num = Convert.ToInt32(pickNum.Value);
                String idEquip = Usuari.usuari.getIdEquip().ToString();

                // Afegeixo el jugador a la base de dades i a la llista de jugadors
                Players.Jugador jugador = new Players.Jugador("", nom, cognoms, posicio, num, true);
                db.InsertJugador(usuari, nom, cognoms, correu, posicio, num, true, idEquip);
                playersFormulari.addPlayerToList(jugador);
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPlayer_Load(object sender, EventArgs e)
        {

        }
    }
}
