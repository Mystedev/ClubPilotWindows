using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class PasswordReset : Form
    {
        public static string passwordOld;
        public static string password1;
        public static string password2;
        Connection db = new Connection();
        public List<string> UserInfo;

        public PasswordReset()
        {
            InitializeComponent();
            textBoxPass1.PasswordChar = '*';
            textBoxPass2.PasswordChar = '*';
            textBoxPass3.PasswordChar = '*';


        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            UserInfo = db.getUserByName(textBox1.Text);

            if (!textBoxPass2.Text.Equals(textBoxPass3.Text))
            {
                 label_incorrecto.Visible = true;

            }
            if (textBoxPass2.Text.Equals(textBoxPass3.Text) && Connection.CalcularSHA256(textBoxPass1.Text).Equals(UserInfo[2]))
            {
                label_incorrecto.Visible = false;
                db.updatePassword(int.Parse(UserInfo[0]), textBoxPass3.Text);
            }
            this.Close();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo = db.getUserByName(textBox1.Text);
                string pass = db.GenerarContrasenya();
                MessageBox.Show("S'ha enviat un correu amb la nova contrasenya.");
                Mail.EnviarCorreo(UserInfo[5].ToString(), "Nova contrasenya!", "Aquesta es la nova contrasenya: " + pass);
                db.updatePassword(int.Parse(UserInfo[0]), pass);
                this.Close();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("No s'ha pogut carregar l'informacion del usuari");
            }
            }
    }

}
