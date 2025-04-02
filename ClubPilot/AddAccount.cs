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
    public partial class AddAccount : Form
    {
        private Accounts accountsFormulari;
        private Connection db;
      
        public AddAccount(Accounts accountsFormulari)
        {
            db = new Connection();
            InitializeComponent();
            this.accountsFormulari = accountsFormulari;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void ComboBoxRol1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            string selectedRole = ComboBoxRol1.SelectedItem.ToString();

            if (selectedRole == "administrador")
            {
                txtBoxEquips.Visible = false;
                labelEquips.Visible = false;
            }
            else if (selectedRole == "aficionat")
            {
                txtBoxEquips.Visible = true;
                labelEquips.Visible = true;
            }
            else if (selectedRole == "entrenador")
            {
                txtBoxEquips.Visible = true;
                labelEquips.Visible = true;
            }
            else if (selectedRole == "jugador")
            {
                txtBoxEquips.Visible = true;
                txtBoxEquips.Visible = true;
            }
        }


        private void txtBoxEmail1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_account_Click(object sender, EventArgs e)
        {
            if (txtBoxUsername1.Text == "" || txtBoxEmail1.Text == "" || txtBoxNom1.Text == "" || txtBoxCognoms1.Text == "" || ComboBoxRol1.Text == "")
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
                String rol = ComboBoxRol1.Text;
               
                String password = ""; // TODO: Generate random password

                /*string query = "INSERT INTO usuaris (username, email, nom, cognoms, rol, password) VALUES ('" + username + "', '" + email + "', '" + nom + "', '" + cognoms + "', '" + rol + "', '" + password + "')";
                if (db.ExecuteQuery(query) == 1)
                {
                    MessageBox.Show("Usuari afegit correctament.");
                }
                else
                {
                    MessageBox.Show("Error al afegir l'usuari.");
                }*/
                Accounts.Compte compte = new Accounts.Compte("", usuari,  nom, cognoms, correu, rol);
                db.InsertCompte(usuari,nom,cognoms,correu,rol);
                accountsFormulari.addAccountToList(compte);
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
