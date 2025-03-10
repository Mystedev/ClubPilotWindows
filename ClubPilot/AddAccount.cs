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
        public AddAccount()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxEmail1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_account_Click(object sender, EventArgs e)
        {
            new Accounts().Show();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            new Accounts().Show();
        }
    }
}
