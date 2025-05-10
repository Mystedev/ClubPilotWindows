using ClubPilot;
using System.Windows.Forms;
using System;
using ClubPilot.Properties;
using System.Drawing;

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

    public News(string titulo, string texto, string autor, string imagen, DateTime fecha)
    {
        Titulo = titulo;
        Texto = texto;
        Fecha = fecha;
        Autor = autor;
        Imagen = imagen;
        //CONFIG BOTON
        borrar = new Button();
        borrar.Width = 40;
        borrar.Height = 40;
        borrar.Location = new Point(650, 250);
        borrar.FlatStyle = FlatStyle.Flat;
        borrar.FlatAppearance.BorderSize = 0;
        borrar.FlatAppearance.MouseOverBackColor = Color.Transparent;
        borrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
        borrar.Image = Resources.icons8_eliminar_30;
        borrar.TabStop = false;
        this.Controls.Add(borrar);
        borrar.Click += Delete_Click;

        //Config "Panel"
        this.Size = new System.Drawing.Size(700, 300);
        this.BackColor = System.Drawing.Color.FromArgb(82, 137, 179);
        this.AutoSize = false;

        //Asociar el evento Click al panel
        this.Click += News_Click;
        this.Cursor = Cursors.Hand;

        idClub = 1;
        idUsuari = 1;

        // Llamar a Show para agregar los controles a este panel
        Show();

    }

    public void Show()
    {
        // Etiqueta para el título
        Label label_titulo = new Label
        {
            Text = Titulo,
            Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
            Location = new System.Drawing.Point(10, 10),
            Size = new System.Drawing.Size(480, 30),
            ForeColor = System.Drawing.Color.White
        };
        this.Controls.Add(label_titulo);

        // Etiqueta para el texto
        Label label_texto = new Label
        {
            Text = Texto,
            Location = new System.Drawing.Point(10, 50),
            AutoSize = true,
            MaximumSize = new System.Drawing.Size(480, 0),
            ForeColor = System.Drawing.Color.White
        };
        this.Controls.Add(label_texto);

        // PictureBox para la imagen
        PictureBox pictureBox = new PictureBox
        {
            Location = new System.Drawing.Point(500, 10),
            Size = new System.Drawing.Size(180, 180),
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        // Cargar la imagen con manejo de errores
        try
        {
            pictureBox.ImageLocation = Imagen;
        }
        catch
        {
            pictureBox.Image = Resources.icons8_aceptar_30; // HAY QUE CAMBIAR ESTO
        }

        this.Controls.Add(pictureBox);

        // Etiqueta para la fecha
        Label label_fecha = new Label
        {
            Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic),
            Text = Fecha.ToString("dd/MM/yyyy HH:mm"),
            Location = new System.Drawing.Point(10, 280),
            Size = new System.Drawing.Size(200, 20),
            ForeColor = System.Drawing.Color.White
        };
        this.Controls.Add(label_fecha);

        // Etiqueta para el autor
        Label label_autor = new Label
        {
            Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic),
            Location = new System.Drawing.Point(220, 280),
            Size = new System.Drawing.Size(200, 20),
            ForeColor = System.Drawing.Color.White
        };

    }

    private void News_Click(object sender, EventArgs e)
    {
        EditNews editForm = new EditNews(this);  // Pasar la instancia actual de News
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
