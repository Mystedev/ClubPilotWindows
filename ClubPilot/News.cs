using ClubPilot;
using System.Windows.Forms;
using System;
using ClubPilot.Properties;
using System.Drawing;
using System.IO;

public class News : Panel
{
    Connection connection = new Connection();
    public int id { get; set; }
    public int idClub { get; set; }
    public int idUsuari { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Texto { get; set; }
    public DateTime Fecha { get; set; }
    public string Imagen { get; set; }
    public Button borrar { get; set; }

    public News(string titulo, string texto, string imagen, DateTime fecha)
    {
        Connection db = new Connection();
        Titulo = titulo;
        Texto = texto;
        Fecha = fecha;
        Autor = db.getUsernameByID(Usuari.usuari.getIdUsuari());
        Imagen = imagen;

        idClub = Usuari.usuari.getIdClub();
        idUsuari = Usuari.usuari.getIdUsuari();

        // Configurar botón de borrado
        borrar = new Button
        {
            Width = 40,
            Height = 40,
            Location = new Point(650, 250),
            FlatStyle = FlatStyle.Flat,
            Image = Resources.icons8_eliminar_30,
            TabStop = false
        };
        borrar.FlatAppearance.BorderSize = 0;
        borrar.FlatAppearance.MouseOverBackColor = Color.Transparent;
        borrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
        borrar.Click += Delete_Click;
        this.Controls.Add(borrar);

        // Configurar panel contenedor
        this.Size = new Size(700, 300);
        this.BackColor = Color.FromArgb(82, 137, 179);
        this.AutoSize = false;
        this.Cursor = Cursors.Hand;

        // Asociar evento de clic al panel
        this.Click += News_Click;

        // Inicializar controles visuales
        InicializarControles();
    }

    private void InicializarControles()
    {
        // Título
        Label label_titulo = new Label
        {
            Text = Titulo,
            Font = new Font("Arial", 14, FontStyle.Bold),
            Location = new Point(10, 10),
            Size = new Size(480, 30),
            ForeColor = Color.White
        };
        this.Controls.Add(label_titulo);

        // Texto
        Label label_texto = new Label
        {
            Text = Texto,
            Location = new Point(10, 50),
            AutoSize = true,
            MaximumSize = new Size(480, 0),
            ForeColor = Color.White
        };
        this.Controls.Add(label_texto);

        // Imagen
        PictureBox pictureBox = new PictureBox
        {
            Location = new Point(500, 10),
            Size = new Size(180, 180),
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        if (File.Exists(Imagen))
            pictureBox.ImageLocation = Imagen;
        else
            pictureBox.Image = Resources.icons8_aceptar_30;

        this.Controls.Add(pictureBox);

        // Fecha
        Label label_fecha = new Label
        {
            Font = new Font("Arial", 10, FontStyle.Italic),
            Text = Fecha.ToString("dd/MM/yyyy HH:mm"),
            Location = new Point(10, 280),
            Size = new Size(200, 20),
            ForeColor = Color.White
        };
        this.Controls.Add(label_fecha);

        // Autor
        Label label_autor = new Label
        {
            Font = new Font("Arial", 10, FontStyle.Italic),
            Text = $"Por: {Autor}",
            Location = new Point(220, 280),
            Size = new Size(200, 20),
            ForeColor = Color.White
        };
        this.Controls.Add(label_autor);
    }

    private void News_Click(object sender, EventArgs e)
    {
        EditNews editForm = new EditNews(this);  // Pasa esta instancia
        editForm.Show();
    }

    private void Delete_Click(object sender, EventArgs e)
    {
        Connection.deleteNew(this);
        connection.exportNews();
        connection.passarDadesPsp();
        News_Tab.showNews();
    }
}
