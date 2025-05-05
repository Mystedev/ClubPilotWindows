using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClubPilot
{
    public partial class Add_Esdeveniment : Form
    {
        DateTime fecha;
        DateTimePicker dtpTime;
        public Add_Esdeveniment()
        {
            InitializeComponent(); // Asegurar que los componentes del formulario están inicializados primero

            // Crear e inicializar el DateTimePicker para la fecha
            //dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(20, 250);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            this.Controls.Add(dateTimePicker1);

            // Crear e inicializar el DateTimePicker para la hora
            dtpTime = new DateTimePicker();
            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.CustomFormat = "HH:mm:ss"; // Formato de 24 horas con segundos
            dtpTime.ShowUpDown = true;
            dtpTime.Location = new Point(20, 230);
            dtpTime.Width = 100;
            dtpTime.ValueChanged += dtpTime_ValueChanged; // Evento para actualizar fecha
            this.Controls.Add(dtpTime);

            // Botón para crear evento
            Button boton_CrearEvento = new Button();
            boton_CrearEvento.Image = Properties.Resources.icons8_guardar_30;
            boton_CrearEvento.Width = 40;
            boton_CrearEvento.Height = 40;
            boton_CrearEvento.Show();
           // boton_CrearEvento.Location = new Point(750, 400);
            boton_CrearEvento.FlatStyle = FlatStyle.Flat;
            boton_CrearEvento.FlatAppearance.BorderSize = 0;
            boton_CrearEvento.FlatAppearance.MouseOverBackColor = Color.Transparent;
            boton_CrearEvento.FlatAppearance.MouseDownBackColor = Color.Transparent;
            boton_CrearEvento.BackColor = Color.Transparent;
            boton_CrearEvento.TabStop = false;
            boton_CrearEvento.Location = new Point(this.ClientSize.Width - boton_CrearEvento.Width - 10, this.ClientSize.Height - boton_CrearEvento.Height - 10);
            boton_CrearEvento.Anchor = AnchorStyles.Bottom | AnchorStyles.Right; //El ancla
            this.Controls.Add(boton_CrearEvento);
            boton_CrearEvento.Click += boton_CrearEvento_Click;

            // Inicializar la fecha con la selección actual
            fecha = ObtenerFechaHora();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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
                dateTimePicker1.Value.Year,
                dateTimePicker1.Value.Month,
                dateTimePicker1.Value.Day,
                dtpTime.Value.Hour,
                dtpTime.Value.Minute,
                dtpTime.Value.Second);
        }

        private void boton_CrearEvento_Click(object sender, EventArgs e)
        {
            Esdeveniment eventoActual = new Esdeveniment(textBox_nom.Text, textBox_descripcio.Text, fecha);
            Connection connection = new Connection();
            Connection.addEvent(eventoActual);
            Esdeveniments.showEvents();
            this.Close();
        }
    }
}
