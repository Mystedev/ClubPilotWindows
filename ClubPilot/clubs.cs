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
    public partial class Clubs : Form
    {
        private List<Club> clubs;
        private TableLayoutPanel layout;
        private Panel scrollPanel;

        public Clubs()
        {
            InitializeComponent();
            // Maximizar la ventana
            this.WindowState = FormWindowState.Maximized;
            // Configurar la fuente de la letra
            Font fontCascadiaCode = new Font("Cascadia Code", 10);
            // Titulo de la ventana

            Label lblAfegir = new Label
            {
                Text = "Gestionar Clubs",
                Font = fontCascadiaCode,
                AutoSize = true,
                Dock = DockStyle.None,
            };

            scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };

            this.Controls.Add(scrollPanel);
            scrollPanel.Controls.Add(lblAfegir);

            clubs = ObtenirClubs();
            CarregarClubs();

            this.Resize += new EventHandler(Form_Resize);
            PositionAddButton(lblAfegir);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            CenterControls();
            PositionAddButton();
        }

        private void CenterControls()
        {
            foreach (Control control in scrollPanel.Controls)
            {
                if (control is Label label && label.Name != "lblAfegir")
                {
                    label.Location = new Point(
                        (scrollPanel.ClientSize.Width - label.Width) / 2,
                        label.Location.Y
                    );
                }
                else if (control is Button button && button.Name != "botoAfegir")
                {
                    button.Location = new Point(
                        (scrollPanel.ClientSize.Width - button.Width) / 2,
                        button.Location.Y
                    );
                }
            }
        }

        private void PositionAddButton(Label lblAfegir = null)
        {
            if (lblAfegir == null)
            {
                lblAfegir = scrollPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text == "Gestionar Clubs");
            }

            if (lblAfegir != null)
            {
                int padding = 10;
                lblAfegir.Location = new Point(
                    (scrollPanel.ClientSize.Width - lblAfegir.Width) / 2,
                    padding
                );
            }
        }

        private List<Club> ObtenirClubs()
        {
            return new List<Club>
            {
                new Club("Nom1", "Fundador1", 2001),
                new Club("Nom2", "Fundador2", 2002),
                new Club("Nom3", "Fundador3", 2003),
                new Club("Nom4", "Fundador4", 2004),
                new Club("Nom5", "Fundador5", 2005),
                new Club("Nom6", "Fundador6", 2006),
                new Club("Nom7", "Fundador7", 2007),
                new Club("Nom8", "Fundador8", 2008),
                new Club("Nom9", "Fundador9", 2009),
                new Club("Nom10", "Fundador10", 2010),
            };
        }

        private void CarregarClubs()
        {
            if (layout != null)
            {
                scrollPanel.Controls.Remove(layout);
                layout.Dispose();
            }

            layout = new TableLayoutPanel
            {
                ColumnCount = 5,
                Dock = DockStyle.Top,
                AutoSize = true,
                BackColor = Color.SeaShell,
                Padding = new Padding(100),
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            layout.RowCount = clubs.Count;
            foreach (var _ in clubs)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            }

            for (int i = 0; i < clubs.Count; i++)
            {
                AfegirClubATaula(layout, clubs[i], i);
            }

            scrollPanel.Controls.Add(layout);
        }

        private void AfegirClubATaula(TableLayoutPanel panell, Club club, int indexFila)
        {
            Panel panellIntern = new Panel { Dock = DockStyle.Fill, AutoSize = true };
            panellIntern.SuspendLayout();
            Font fontCascadiaCode = new Font("Cascadia Code", 10);

            Label lblNom = new Label { Text = "Nom:", Font = fontCascadiaCode };
            TextBox txtNom = new TextBox { Text = club.Nom, Width = 150, Left = 75, Font = fontCascadiaCode, Enabled = false };

            Label lblFundador = new Label { Text = "Fundador:", Left = 250, Font = fontCascadiaCode };
            TextBox txtFundador = new TextBox { Text = club.Fundador, Width = 150, Left = 350, Font = fontCascadiaCode, Enabled = false };

            Label lblAnyFundacio = new Label { Text = "Any Fundació:", Left = 500, Font = fontCascadiaCode };
            TextBox txtAnyFundacio = new TextBox { Text = club.AnyFundacio.ToString(), Width = 150, Left = 600, Font = fontCascadiaCode, Enabled = false };

            int desplazamentY = 5;

            lblNom.Location = new Point(5, desplazamentY);
            txtNom.Location = new Point(lblNom.Right + 5, desplazamentY);

            lblFundador.Location = new Point(txtNom.Right + 20, desplazamentY);
            txtFundador.Location = new Point(lblFundador.Right + 5, desplazamentY);

            lblAnyFundacio.Location = new Point(txtFundador.Right + 20, desplazamentY);
            txtAnyFundacio.Location = new Point(lblAnyFundacio.Right + 5, desplazamentY);

 
            panellIntern.Controls.Add(lblNom);
            panellIntern.Controls.Add(txtNom);
            panellIntern.Controls.Add(lblFundador);
            panellIntern.Controls.Add(txtFundador);
            panellIntern.Controls.Add(lblAnyFundacio);
            panellIntern.Controls.Add(txtAnyFundacio);
 

            panellIntern.ResumeLayout();

            Button btnAcceptar = new Button { Image = Properties.Resources.icons8_aceptar_30, Width = 40, Height = 40 };
            Button btnEsborrar = new Button { Image = Properties.Resources.icons8_eliminar_30, Width = 40, Height = 40 };

            btnAcceptar.Click += (sender, e) =>
            {
                txtNom.Enabled = true;
                txtFundador.Enabled = true;
                txtAnyFundacio.Enabled = true;
                btnAcceptar.Enabled = false;
            };

            btnEsborrar.Click += (sender, e) =>
            {
                if (indexFila >= 0 && indexFila < clubs.Count)
                {
                    // Confirmar que realmente se desea eliminar el club
                    DialogResult result = MessageBox.Show(
                        "Segur que vol esborrar aquest club? " + clubs[indexFila].Nom,
                        "Confirmar eliminació",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Comprobar la respuesta del usuario
                    if (result == DialogResult.Yes)
                    {
                        // Eliminar el club si asi lo desea el usuario
                        clubs.RemoveAt(indexFila);

                        // Remove only the TableLayoutPanel and recreate it
                        if (layout != null)
                        {
                            scrollPanel.Controls.Remove(layout);
                            layout.Dispose();
                        }

                        CarregarClubs();
                    }
                }
            };



            panell.Controls.Add(panellIntern, 0, indexFila);
            panell.Controls.Add(btnAcceptar, 1, indexFila);
            panell.Controls.Add(btnEsborrar, 2, indexFila);
        }
    }
}

public class Club
{
    public string Nom { get; set; }
    public string Fundador { get; set; }
    public int AnyFundacio { get; set; }
    public Image Logo { get; set; }

    public Club(string nom, string fundador, int anyFundacio)
    {
        this.Nom = nom;
        this.Fundador = fundador;
        this.AnyFundacio = anyFundacio;
    }
}
