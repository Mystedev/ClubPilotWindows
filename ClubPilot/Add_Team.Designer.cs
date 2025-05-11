namespace ClubPilot
{
    partial class Add_Team
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
            this.textBox_nom = new System.Windows.Forms.TextBox();
            this.textBox_categoria = new System.Windows.Forms.TextBox();
            this.textBox_divisio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_crear = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_nom
            // 
            this.textBox_nom.Location = new System.Drawing.Point(223, 108);
            this.textBox_nom.Name = "textBox_nom";
            this.textBox_nom.Size = new System.Drawing.Size(100, 20);
            this.textBox_nom.TabIndex = 0;
            // 
            // textBox_categoria
            // 
            this.textBox_categoria.Location = new System.Drawing.Point(223, 172);
            this.textBox_categoria.Name = "textBox_categoria";
            this.textBox_categoria.Size = new System.Drawing.Size(100, 20);
            this.textBox_categoria.TabIndex = 1;
            // 
            // textBox_divisio
            // 
            this.textBox_divisio.Location = new System.Drawing.Point(223, 241);
            this.textBox_divisio.Name = "textBox_divisio";
            this.textBox_divisio.Size = new System.Drawing.Size(100, 20);
            this.textBox_divisio.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Divisio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Crear Equip";
            // 
            // button_crear
            // 
            this.button_crear.Image = global::ClubPilot.Properties.Resources.icons8_aceptar_30;
            this.button_crear.Location = new System.Drawing.Point(476, 311);
            this.button_crear.Margin = new System.Windows.Forms.Padding(2);
            this.button_crear.Name = "button_crear";
            this.button_crear.Size = new System.Drawing.Size(38, 41);
            this.button_crear.TabIndex = 18;
            this.button_crear.UseVisualStyleBackColor = true;
            this.button_crear.Click += new System.EventHandler(this.button_crear_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::ClubPilot.Properties.Resources.icons8_cancelar_30;
            this.btn_cancel.Location = new System.Drawing.Point(530, 311);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(38, 41);
            this.btn_cancel.TabIndex = 19;
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // Add_Team
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(579, 363);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.button_crear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_divisio);
            this.Controls.Add(this.textBox_categoria);
            this.Controls.Add(this.textBox_nom);
            this.Name = "Add_Team";
            this.Text = "Add_Team";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nom;
        private System.Windows.Forms.TextBox textBox_categoria;
        private System.Windows.Forms.TextBox textBox_divisio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_crear;
        private System.Windows.Forms.Button btn_cancel;
    }
}