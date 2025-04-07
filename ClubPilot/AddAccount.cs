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
        public static String[][] password(String[][] arxiu, int i)
        {
            int longitud = 0, ordre = 0, numlletresSeparades = 0, numlletresMSeparades = 0, numCaracter = 0, numNumeros = 0;
            Random numCompletamentRandom = new Random();
            Random Ordre = new Random();
            Random Quantitat = new Random();
            String Lletres = "qwertyuiopasdfghjklzxcvbnm";
            String LletresM = Lletres.ToUpper();
            String Caracters = "!$%/()=?¿|@#~€ºª-_.:,;[]";
            String Contrasenya = "";
    
 
            char[] lletresSeparades = Lletres.ToCharArray();
            char[] LletresMSeparades = LletresM.ToCharArray();
            char[] CaractersSeparats = Caracters.ToCharArray();

  
            //Aqui he creat condicionals per a si es vol cada part
            int bLletres = 2, bNumeros = 2, bCaracters = 2, bLletresM = 2;




            //Aqui comença el bucle per a crear una contrasenya fent servir la longitud que a tocat aleatoria
            /*for (int x = 2; x < arxiu[0].length; x++)
            {
                for (int j = 0; j < longitud; j++)
                {
                    //Aqui hi ha un random que va del 0-3 per a saber si toca posar una lletra, un numero etc.
                    ordre = Ordre.nextInt(4);
                    //Aqui tots funcionen igual si els i toca el seu numero es fa servir un random el qual li dona una posicio del array depenent del array que toqui
                    if (ordre == 0 && bLletres == 1)
                    {
                        numlletresSeparades = numCompletamentRandom.nextInt(Lletres.length());
                        Contrasenya = Contrasenya + LletresSeparades[numlletresSeparades];
                    }
                    else if (ordre == 1 && bLletresM == 1)
                    {
                        numlletresMSeparades = numCompletamentRandom.nextInt(LletresM.length());
                        Contrasenya = Contrasenya + LletresMSeparades[numlletresMSeparades];
                    }
                    else if (ordre == 2 && bNumeros == 1)
                    {
                        numCaracter = numCompletamentRandom.nextInt(Caracters.length());
                        Contrasenya = Contrasenya + CaractersSeparats[numCaracter];
                    }
                    else if (ordre == 3 && bCaracters == 1)
                    {
                        numNumeros = numCompletamentRandom.nextInt(10);
                        Contrasenya = Contrasenya + numNumeros;

                    }

                }
                arxiu[i][x] = String.valueOf(Contrasenya);
                Contrasenya = "";
            }*/
            return arxiu;
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
