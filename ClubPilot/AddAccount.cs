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
        public AddAccount(Accounts accountsFormulari)
        {
            InitializeComponent();
            this.accountsFormulari = accountsFormulari;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxEmail1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_account_Click(object sender, EventArgs e)
        {
            if (txtBoxUsername1.Text == "" || txtBoxEmail1.Text == "" || txtBoxNom1.Text == "" || txtBoxCognoms1.Text == "" || txtBoxRol1.Text == "")
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
                String rol = txtBoxRol1.Text;
               
                String password = ""; // TODO: Generate random password

                /*string query = "INSERT INTO usuaris (username, email, nom, cognoms, rol, password) VALUES ('" + username + "', '" + email + "', '" + nom + "', '" + cognoms + "', '" + rol + "', '" + password + "')";
                if (DBConnection.ExecuteQuery(query) == 1)
                {
                    MessageBox.Show("Usuari afegit correctament.");
                }
                else
                {
                    MessageBox.Show("Error al afegir l'usuari.");
                }*/
                Compte compte = new Compte(usuari,  nom, cognoms, correu, rol);
               
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
