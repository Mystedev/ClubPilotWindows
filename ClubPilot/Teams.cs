using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class Teams : Form
    {
        private static List<Equip> equips;
        private static TableLayoutPanel layout;
        private static Panel scrollPanel;
        private static Connection db;
        private Button btnAfegir;

        public Teams()
        {
            db = new Connection();
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            Font fontCascadiaCode = new Font("Cascadia Code", 10);

            Label lblAfegir = new Label
            {
                Text = "Gestionar Equips",
                Font = fontCascadiaCode,
                AutoSize = true
            };

            scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            this.Controls.Add(scrollPanel);
            scrollPanel.Controls.Add(lblAfegir);

            btnAfegir = new Button
            {
                Image = Properties.Resources.icons8_añadir_30,
                Width = 36,
                Height = 36
            };
            btnAfegir.Click += (s, e) =>
            {
                new Add_Team().Show();

            };
            this.Controls.Add(btnAfegir); // Fuera del scrollPanel

            equips = db.SelectTeam();
            CarregarEquips();

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
                if (control is Label label && label.Text == "Gestionar Equips")
                {
                    label.Location = new Point(
                        (scrollPanel.ClientSize.Width - label.Width) / 2,
                        10
                    );
                }
            }
        }

        private void PositionAddButton(Label lblAfegir = null)
        {
            int padding = 20;
            btnAfegir.Location = new Point(
                this.ClientSize.Width - btnAfegir.Width - padding,
                this.ClientSize.Height - btnAfegir.Height - padding
            );
            btnAfegir.BringToFront();
        }

        public static void CarregarEquips()
        {
            if (layout != null)
            {
                scrollPanel.Controls.Remove(layout);
                layout.Dispose();
            }

            layout = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Top,
                AutoSize = true,
                BackColor = Color.SeaShell,
                Padding = new Padding(100)
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));

            layout.RowCount = equips.Count;
            foreach (var _ in equips)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            }

            for (int i = 0; i < equips.Count; i++)
            {
                AfegirEquipATaula(layout, equips[i], i);
            }

            scrollPanel.Controls.Add(layout);
        }

        private static void AfegirEquipATaula(TableLayoutPanel panell, Equip equip, int indexFila)
        {
            Panel panellIntern = new Panel { Dock = DockStyle.Fill, AutoSize = true };
            panellIntern.SuspendLayout();
            Font font = new Font("Cascadia Code", 10);

            Label lblNom = new Label { Text = "Nom:", Font = font };
            TextBox txtNom = new TextBox { Text = equip.nom, Width = 120, Font = font, Enabled = false };

            Label lblCat = new Label { Text = "Categoria:", Font = font };
            TextBox txtCat = new TextBox { Text = equip.categoria, Width = 100, Font = font, Enabled = false };

            Label lblDiv = new Label { Text = "Divisió:", Font = font };
            TextBox txtDiv = new TextBox { Text = equip.divisio, Width = 100, Font = font, Enabled = false };

            int x = 5, y = 5, padding = 10;
            lblNom.Location = new Point(x, y);
            txtNom.Location = new Point(lblNom.Right + padding, y);
            lblCat.Location = new Point(txtNom.Right + padding, y);
            txtCat.Location = new Point(lblCat.Right + padding, y);
            lblDiv.Location = new Point(txtCat.Right + padding, y);
            txtDiv.Location = new Point(lblDiv.Right + padding, y);


            panellIntern.Controls.AddRange(new Control[] {
                lblNom, txtNom,
                lblCat, txtCat,
                lblDiv, txtDiv,
            });
            panellIntern.ResumeLayout();

            Button btnAcceptar = new Button { Image = Properties.Resources.icons8_aceptar_30, Width = 36, Height = 36, Enabled = false };
            Button btnEditar = new Button { Image = Properties.Resources.icons8_modificar_30, Width = 36, Height = 36 };
            Button btnEsborrar = new Button { Image = Properties.Resources.icons8_eliminar_30, Width = 36, Height = 36 };

            btnEditar.Click += (s, e) =>
            {
                txtNom.Enabled = true;
                txtCat.Enabled = true;
                txtDiv.Enabled = true;
                btnAcceptar.Enabled = true;
            };

            btnAcceptar.Click += (s, e) =>
            {
                try
                {
                    equip.nom = txtNom.Text;
                    equip.categoria = txtCat.Text;
                    equip.divisio = txtDiv.Text;

                    db.UpdateEquip(equip);

                    txtNom.Enabled = false;
                    txtCat.Enabled = false;
                    txtDiv.Enabled = false;
                    btnAcceptar.Enabled = false;

                    MessageBox.Show("Equip actualitzat correctament.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualitzar l'equip: " + ex.Message);
                }
            };

            btnEsborrar.Click += (s, e) =>
            {
                var resp = MessageBox.Show(
                    $"Segur que vol esborrar l'equip «{equip.nom}»?",
                    "Confirmar eliminació",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (resp == DialogResult.Yes)
                {
                    equips.RemoveAt(indexFila);
                    db.DeleteEquip(equip.id.ToString());
                    CarregarEquips();
                }
            };

            panell.Controls.Add(panellIntern, 0, indexFila);
            panell.Controls.Add(btnAcceptar, 1, indexFila);
            panell.Controls.Add(btnEditar, 2, indexFila);
            panell.Controls.Add(btnEsborrar, 3, indexFila);
        }

        private void Teams_Load(object sender, EventArgs e)
        {
        }
    }

    public class Equip
    {
        public int id;
        public string nom;
        public string categoria;
        public string divisio;
        public int id_club;

        public Equip(string nom, string categoria, string divisio)
        {
            this.nom = nom;
            this.categoria = categoria;
            this.divisio = divisio;
            this.id_club = Usuari.usuari.getIdClub();
        }
    }
}
