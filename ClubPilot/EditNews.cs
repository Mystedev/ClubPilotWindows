using Mysqlx.Cursor;
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
    public partial class EditNews : Form
    {
        private News noticiaOriginal;
        private News noticiaNew;
        public EditNews(News noticia)
        {
            InitializeComponent();
            noticiaOriginal = noticia;
            textBox_titulo.Text = noticia.Titulo;
            TextBox_texto.Text = noticia.Texto;
            textBox_imagen.Text = noticia.Imagen;
            dateTimePicker1.Value = noticia.Fecha;

            //textBox_titulo.TextChanged += textchanged;
            //TextBox_texto.TextChanged += textchanged;
            //textBox_imagen.TextChanged += textchanged;

            //CONFIG BOTON
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
        }
        //public void textchanged(object sender, EventArgs e)
        //{
        //    noticiaNew.Titulo = textBox_titulo.Text;
        //    noticiaNew.Texto = TextBox_texto.Text;
        //    noticiaNew.Imagen = textBox_imagen.Text;
        //    noticiaNew.Fecha = dateTimePicker1.Value;
        //}
        private void boton_CrearNoticia_Click(object sender, EventArgs e)
        {
            // Actualiza la noticia original, manteniendo su ID y demás datos
            noticiaOriginal.Titulo = textBox_titulo.Text;
            noticiaOriginal.Texto = TextBox_texto.Text;
            noticiaOriginal.Imagen = textBox_imagen.Text;
            noticiaOriginal.Fecha = dateTimePicker1.Value;

            Connection.updateNews(noticiaOriginal);
            News_Tab.showNews();
            this.Close();
        }
    }
}
