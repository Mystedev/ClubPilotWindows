namespace ClubPilot
{
    partial class Add_New
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_titulo = new System.Windows.Forms.Label();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.label_fecha = new System.Windows.Forms.Label();
            this.label_autor = new System.Windows.Forms.Label();
            this.label_imagen = new System.Windows.Forms.Label();
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.textBox_autor = new System.Windows.Forms.TextBox();
            this.textBox_imagen = new System.Windows.Forms.TextBox();
            this.boton_CrearNoticia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Location = new System.Drawing.Point(45, 37);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(40, 16);
            this.label_titulo.TabIndex = 0;
            this.label_titulo.Text = "Titulo";
            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Location = new System.Drawing.Point(45, 103);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(79, 16);
            this.label_descripcion.TabIndex = 1;
            this.label_descripcion.Text = "Descripcion";
            // 
            // label_fecha
            // 
            this.label_fecha.AutoSize = true;
            this.label_fecha.Location = new System.Drawing.Point(45, 171);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(45, 16);
            this.label_fecha.TabIndex = 2;
            this.label_fecha.Text = "Fecha";
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(45, 235);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(38, 16);
            this.label_autor.TabIndex = 3;
            this.label_autor.Text = "Autor";
            // 
            // label_imagen
            // 
            this.label_imagen.AutoSize = true;
            this.label_imagen.Location = new System.Drawing.Point(45, 305);
            this.label_imagen.Name = "label_imagen";
            this.label_imagen.Size = new System.Drawing.Size(52, 16);
            this.label_imagen.TabIndex = 4;
            this.label_imagen.Text = "Imagen";
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Location = new System.Drawing.Point(48, 69);
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.Size = new System.Drawing.Size(100, 22);
            this.textBox_titulo.TabIndex = 5;
            this.textBox_titulo.TextChanged += new System.EventHandler(this.textBox_titulo_TextChanged);
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(48, 136);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(100, 22);
            this.textBox_descripcion.TabIndex = 6;
            this.textBox_descripcion.TextChanged += new System.EventHandler(this.textBox_descripcion_TextChanged);
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Location = new System.Drawing.Point(48, 210);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.Size = new System.Drawing.Size(100, 22);
            this.textBox_fecha.TabIndex = 7;
            // 
            // textBox_autor
            // 
            this.textBox_autor.Location = new System.Drawing.Point(48, 263);
            this.textBox_autor.Name = "textBox_autor";
            this.textBox_autor.Size = new System.Drawing.Size(100, 22);
            this.textBox_autor.TabIndex = 8;
            this.textBox_autor.TextChanged += new System.EventHandler(this.textBox_autor_TextChanged);
            // 
            // textBox_imagen
            // 
            this.textBox_imagen.Location = new System.Drawing.Point(48, 346);
            this.textBox_imagen.Name = "textBox_imagen";
            this.textBox_imagen.Size = new System.Drawing.Size(100, 22);
            this.textBox_imagen.TabIndex = 9;
            this.textBox_imagen.TextChanged += new System.EventHandler(this.textBox_imagen_TextChanged);
            // 
            // boton_CrearNoticia
            // 
            this.boton_CrearNoticia.Location = new System.Drawing.Point(698, 415);
            this.boton_CrearNoticia.Name = "boton_CrearNoticia";
            this.boton_CrearNoticia.Size = new System.Drawing.Size(75, 23);
            this.boton_CrearNoticia.TabIndex = 10;
            this.boton_CrearNoticia.Text = "crear";
            this.boton_CrearNoticia.UseVisualStyleBackColor = true;
            this.boton_CrearNoticia.Click += new System.EventHandler(this.boton_CrearNoticia_Click_1);
            // 
            // Add_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.boton_CrearNoticia);
            this.Controls.Add(this.textBox_imagen);
            this.Controls.Add(this.textBox_autor);
            this.Controls.Add(this.textBox_fecha);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.textBox_titulo);
            this.Controls.Add(this.label_imagen);
            this.Controls.Add(this.label_autor);
            this.Controls.Add(this.label_fecha);
            this.Controls.Add(this.label_descripcion);
            this.Controls.Add(this.label_titulo);
            this.Name = "Add_New";
            this.Text = "Add_New";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.Label label_imagen;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.TextBox textBox_autor;
        private System.Windows.Forms.TextBox textBox_imagen;
        private System.Windows.Forms.Button boton_CrearNoticia;
    }
}