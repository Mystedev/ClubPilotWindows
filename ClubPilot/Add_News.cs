using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class Add_News : Form
    {
        DateTimePicker dtpTime;
        DateTime fecha;

        //CAMBIAR EL TEXTBOX DE TEXTO POR UN RICHTEXTBOX

        public Add_News()
        {
            InitializeComponent();

            // Configuración del botón para crear noticia
            Button boton_CrearNoticia = new Button();
            boton_CrearNoticia.Image = Properties.Resources.icons8_guardar_30;
            boton_CrearNoticia.Width = 40;
            boton_CrearNoticia.Height = 40;
            boton_CrearNoticia.Location = new Point(this.ClientSize.Width - boton_CrearNoticia.Width, this.ClientSize.Height - boton_CrearNoticia.Height);
            boton_CrearNoticia.FlatStyle = FlatStyle.Flat;
            boton_CrearNoticia.FlatAppearance.BorderSize = 0;
            boton_CrearNoticia.FlatAppearance.MouseOverBackColor = Color.Transparent;
            boton_CrearNoticia.FlatAppearance.MouseDownBackColor = Color.Transparent;
            boton_CrearNoticia.BackColor = Color.Transparent;
            boton_CrearNoticia.TabStop = false;
            this.Controls.Add(boton_CrearNoticia);
            boton_CrearNoticia.Click += boton_CrearNoticia_Click;

            // Configuración del DateTimePicker para la fecha
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;

            // Configuración del DateTimePicker para la hora
            dtpTime = new DateTimePicker();
            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.CustomFormat = "HH:mm:ss";
            dtpTime.ShowUpDown = true;
            dtpTime.Location = new Point(20, 330);
            dtpTime.Width = 100;
            dtpTime.ValueChanged += dtpTime_ValueChanged;
            this.Controls.Add(dtpTime);

            this.BackColor = Color.SeaShell;
            fecha = ObtenerFechaHora();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            fecha = ObtenerFechaHora();
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            fecha = ObtenerFechaHora();
        }

        private DateTime ObtenerFechaHora()
        {
            return new DateTime(
                dateTimePicker2.Value.Year,
                dateTimePicker2.Value.Month,
                dateTimePicker2.Value.Day,
                dtpTime.Value.Hour,
                dtpTime.Value.Minute,
                dtpTime.Value.Second);
        }

        private void boton_CrearNoticia_Click(object sender, EventArgs e)
        {
            News noticia = new News(textBox_titulo.Text, textBox_descripcion.Text, textBox_autor.Text, textBox_imagen.Text, fecha);
            Connection.addNew(noticia);
            News_Tab.showNews();
            this.Close();
        }
    }
}
