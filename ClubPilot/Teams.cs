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
    public partial class Teams : Form
    {
        private static List<Equip> equips;
        private static TableLayoutPanel layout;
        private static Panel scrollPanel;
        private static Connection db;
        public Teams()
        {
            db = new Connection();
            InitializeComponent();
            Font fontCascadiaCode = new Font("Cascadia Code", 10);
            this.WindowState = FormWindowState.Maximized;


            Label lblAfegir = new Label
            {
                Text = "Gestionar Equips",
                Font = fontCascadiaCode,
                AutoSize = true,
                Dock = DockStyle.None,


            };
                                                                                                                                            //BOTON ANYADIR 
            Button btnAfegir = new Button { Image = Properties.Resources.icons8_añadir_30, Width = 36, Height = 36 };
            btnAfegir.BringToFront();
            //btnAfegir.Location = new Point(this.ClientSize.Width - btnAfegir.Width - 20, this.ClientSize.Height - btnAfegir.Height - 20);
            btnAfegir.Click += (s, e) =>
            {
                new Add_Team().Show();
            };
            scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };

            this.Controls.Add(scrollPanel);
            scrollPanel.Controls.Add(lblAfegir);

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
                lblAfegir = scrollPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text == "Gestionar Equips");
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

        //private List<Equip> ObtenirEquips()
        //{
        //    List<Equip> equips = db.SelectTeam();
        //    Console.WriteLine("Registros obtenidos: " + resultats.Count);
        //    //foreach (var registre in equips)
        //    //{
        //    //    Console.WriteLine($"ID: {equips["id"]}, Nom: {equips["nom"]}, Categoria: {equips["categoria"]}, diviso: {registre["divisio"]}");
        //    //}
        //    //foreach (var registre in equips)
        //    //{

        //    //    equips.Add(new Equip(
        //    //            int.Parse(registre["id"].ToString()),
        //    //            registre["nom"].ToString(),
        //    //            registre["categoria"].ToString(),
        //    //            registre["divisio"].ToString(),
        //    //            int.Parse(registre["id_club"].ToString())
        //    //        ));
        //    //}
        //    //return equips;
        //}
        public static void CarregarEquips()
        {
            if (layout != null)
            {
                scrollPanel.Controls.Remove(layout);
                layout.Dispose();
            }

            layout = new TableLayoutPanel
            {
                ColumnCount = 3,
                Dock = DockStyle.Top,
                AutoSize = true,
                BackColor = Color.SeaShell,
                Padding = new Padding(100),
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
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
            // 1. Panel contenedor
            Panel panellIntern = new Panel { Dock = DockStyle.Fill, AutoSize = true };
            panellIntern.SuspendLayout();
            Font font = new Font("Cascadia Code", 10);

            // 2. Etiquetas y TextBox (editable solo tras pulsar Editar)
            Label lblNom = new Label { Text = "Nom:", Font = font };
            TextBox txtNom = new TextBox { Text = equip.nom, Width = 120, Font = font, Enabled = false };

            Label lblCat = new Label { Text = "Categoria:", Font = font };
            TextBox txtCat = new TextBox { Text = equip.categoria, Width = 100, Font = font, Enabled = false };

            Label lblDiv = new Label { Text = "Divisió:", Font = font };
            TextBox txtDiv = new TextBox { Text = equip.divisio, Width = 100, Font = font, Enabled = false };

            Label lblClub = new Label { Text = "Club ID:", Font = font };
            TextBox txtClub = new TextBox { Text = equip.id_club.ToString(), Width = 60, Font = font, Enabled = false };

            // 3. Posicionamiento horizontal
            int x = 5, y = 5, padding = 10;
            lblNom.Location = new Point(x, y);
            txtNom.Location = new Point(lblNom.Right + padding, y);

            lblCat.Location = new Point(txtNom.Right + padding, y);
            txtCat.Location = new Point(lblCat.Right + padding, y);

            lblDiv.Location = new Point(txtCat.Right + padding, y);
            txtDiv.Location = new Point(lblDiv.Right + padding, y);

            lblClub.Location = new Point(txtDiv.Right + padding, y);
            txtClub.Location = new Point(lblClub.Right + padding, y);

            // 4. Añadir controles al panel interno
            panellIntern.Controls.AddRange(new Control[] {
        lblNom, txtNom,
        lblCat, txtCat,
        lblDiv, txtDiv,
        lblClub, txtClub
    });
            panellIntern.ResumeLayout();

            // 5. Botones ✔️, ✏️ y ❌
            Button btnAcceptar = new Button { Image = Properties.Resources.icons8_aceptar_30, Width = 36, Height = 36, Enabled = false };
            Button btnEditar = new Button { Image = Properties.Resources.icons8_modificar_30, Width = 36, Height = 36 };
            Button btnEsborrar = new Button { Image = Properties.Resources.icons8_eliminar_30, Width = 36, Height = 36 };

            // Evento del botón Editar
            btnEditar.Click += (s, e) =>
            {
                txtNom.Enabled = true;
                txtCat.Enabled = true;
                txtDiv.Enabled = true;
                txtClub.Enabled = true;
                btnAcceptar.Enabled = true;
            };

            // Evento del botón Aceptar
            btnAcceptar.Click += (s, e) =>
            {
                try
                {
                    equip.nom = txtNom.Text;
                    equip.categoria = txtCat.Text;
                    equip.divisio = txtDiv.Text;
                    equip.id_club = int.Parse(txtClub.Text);

                    db.UpdateEquip(equip);

                    txtNom.Enabled = false;
                    txtCat.Enabled = false;
                    txtDiv.Enabled = false;
                    txtClub.Enabled = false;
                    btnAcceptar.Enabled = false;

                    MessageBox.Show("Equip actualitzat correctament.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualitzar l'equip: " + ex.Message);
                }
            };

            // Evento del botón Eliminar
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

                    if (layout != null)
                    {
                        scrollPanel.Controls.Remove(layout);
                        layout.Dispose();
                    }
                    CarregarEquips();
                }
            };

            // 6. Añadir al panel principal (ajustar columnas si es necesario)
            if (panell.ColumnCount < 4)
            {
                panell.ColumnCount = 4;
                panell.ColumnStyles.Clear();
                panell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F)); // Panel info
                panell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));  // Aceptar
                panell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));  // Editar
                panell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));  // Eliminar
            }

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
            //this.id_club = Usuari.usuari.getIdClub();
            this.id_club = 1;
        }
    }
}
