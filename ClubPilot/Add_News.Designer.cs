namespace ClubPilot
{
    partial class Add_News
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
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.label_autor = new System.Windows.Forms.Label();
            this.textBox_autor = new System.Windows.Forms.TextBox();
            this.label_imagen = new System.Windows.Forms.Label();
            this.textBox_imagen = new System.Windows.Forms.TextBox();
            this.label_fecha = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Location = new System.Drawing.Point(25, 27);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(33, 16);
            this.label_titulo.TabIndex = 0;
            this.label_titulo.Text = "Titol";
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Location = new System.Drawing.Point(28, 56);
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.Size = new System.Drawing.Size(100, 22);
            this.textBox_titulo.TabIndex = 1;

            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Location = new System.Drawing.Point(28, 102);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(72, 16);
            this.label_descripcion.TabIndex = 2;
            this.label_descripcion.Text = "Descripcio";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(28, 141);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(100, 22);
            this.textBox_descripcion.TabIndex = 3;
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(28, 186);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(38, 16);
            this.label_autor.TabIndex = 4;
            this.label_autor.Text = "Autor";
            // 
            // textBox_autor
            // 
            this.textBox_autor.Location = new System.Drawing.Point(28, 215);
            this.textBox_autor.Name = "textBox_autor";
            this.textBox_autor.Size = new System.Drawing.Size(100, 22);
            this.textBox_autor.TabIndex = 5;
            // 
            // label_imagen
            // 
            this.label_imagen.AutoSize = true;
            this.label_imagen.Location = new System.Drawing.Point(28, 263);
            this.label_imagen.Name = "label_imagen";
            this.label_imagen.Size = new System.Drawing.Size(48, 16);
            this.label_imagen.TabIndex = 6;
            this.label_imagen.Text = "Imatge";
            // 
            // textBox_imagen
            // 
            this.textBox_imagen.Location = new System.Drawing.Point(28, 292);
            this.textBox_imagen.Name = "textBox_imagen";
            this.textBox_imagen.Size = new System.Drawing.Size(100, 22);
            this.textBox_imagen.TabIndex = 7;
            // 
            // label_fecha
            // 
            this.label_fecha.AutoSize = true;
            this.label_fecha.Location = new System.Drawing.Point(28, 341);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(36, 16);
            this.label_fecha.TabIndex = 8;
            this.label_fecha.Text = "Data";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(28, 373);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(275, 22);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // Add_News
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label_fecha);
            this.Controls.Add(this.textBox_imagen);
            this.Controls.Add(this.label_imagen);
            this.Controls.Add(this.textBox_autor);
            this.Controls.Add(this.label_autor);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.label_descripcion);
            this.Controls.Add(this.textBox_titulo);
            this.Controls.Add(this.label_titulo);
            this.Name = "Add_News";
            this.Text = "Add_News";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.TextBox textBox_autor;
        private System.Windows.Forms.Label label_imagen;
        private System.Windows.Forms.TextBox textBox_imagen;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}