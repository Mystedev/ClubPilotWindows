using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ClubPilot
{
    public partial class Add_News : Form
    {
        DateTimePicker dtpTime;
        DateTime fecha;
        //DateTime hora;
        public Add_News()
        {
            InitializeComponent();
            //Cacho de codigo para dar formato al boton
            Button boton_CrearNoticia = new Button();
            boton_CrearNoticia.Image = Properties.Resources.icons8_guardar_30;
            boton_CrearNoticia.Width = 40;
            boton_CrearNoticia.Height = 40;
            boton_CrearNoticia.Location = new Point(this.ClientSize.Width - boton_CrearNoticia.Width , this.ClientSize.Height - boton_CrearNoticia.Height );

            boton_CrearNoticia.Show();
            boton_CrearNoticia.FlatStyle = FlatStyle.Flat;
            boton_CrearNoticia.FlatAppearance.BorderSize = 0;
            boton_CrearNoticia.FlatAppearance.MouseOverBackColor = Color.Transparent; 
            boton_CrearNoticia.FlatAppearance.MouseDownBackColor = Color.Transparent; 
            boton_CrearNoticia.BackColor = Color.Transparent;
            boton_CrearNoticia.TabStop = false; 
            this.Controls.Add(boton_CrearNoticia);
            boton_CrearNoticia.Click += boton_CrearNoticia_Click;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;


            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy"; // o el formato que prefieras
     

            // Crear el DateTimePicker
            dtpTime = new DateTimePicker();
            dtpTime.Format = DateTimePickerFormat.Time; // Mostrar solo la hora
            dtpTime.ShowUpDown = true; // Evita que se muestre el calendario
            dtpTime.Location = new System.Drawing.Point(20, 330);
            dtpTime.Width = 100;

            // Agregar al formulario
            this.Controls.Add(dtpTime);
            this.BackColor = System.Drawing.Color.SeaShell;


            
        }
        public void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            fecha = new DateTime(
                dateTimePicker2.Value.Year,
                dateTimePicker2.Value.Month,
                dateTimePicker2.Value.Day,
                dtpTime.Value.Hour,
                dtpTime.Value.Minute,
                dtpTime.Value.Second);

        }

        //Boton que crea una noticia y llama a la funcion para mostrarla en News_Tab (tambien cierra el formulario)
        private void boton_CrearNoticia_Click(object sender, EventArgs e)
        {
            News noticia = new News(textBox_titulo.Text, textBox_descripcion.Text, fecha, textBox_autor.Text, textBox_imagen.Text);
            News_Tab.Noticia = noticia;
            News_Tab.showNews();
            this.Close();

        }


    }
}