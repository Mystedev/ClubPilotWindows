namespace ClubPilot
{
    partial class Add_Esdeveniment
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
            this.label_titol = new System.Windows.Forms.Label();
            this.label_descripcio = new System.Windows.Forms.Label();
            this.label_data = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox_descripcio = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox_nom
            // 
            this.textBox_nom.Location = new System.Drawing.Point(12, 92);
            this.textBox_nom.Name = "textBox_nom";
            this.textBox_nom.Size = new System.Drawing.Size(131, 22);
            this.textBox_nom.TabIndex = 0;
            // 
            // label_titol
            // 
            this.label_titol.AutoSize = true;
            this.label_titol.Location = new System.Drawing.Point(13, 62);
            this.label_titol.Name = "label_titol";
            this.label_titol.Size = new System.Drawing.Size(130, 16);
            this.label_titol.TabIndex = 3;
            this.label_titol.Text = "Tipus Esdeveniment";
            // 
            // label_descripcio
            // 
            this.label_descripcio.AutoSize = true;
            this.label_descripcio.Location = new System.Drawing.Point(13, 130);
            this.label_descripcio.Name = "label_descripcio";
            this.label_descripcio.Size = new System.Drawing.Size(72, 16);
            this.label_descripcio.TabIndex = 4;
            this.label_descripcio.Text = "Descripcio";
            // 
            // label_data
            // 
            this.label_data.AutoSize = true;
            this.label_data.Location = new System.Drawing.Point(10, 261);
            this.label_data.Name = "label_data";
            this.label_data.Size = new System.Drawing.Size(36, 16);
            this.label_data.TabIndex = 5;
            this.label_data.Text = "Data";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 289);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // textBox_descripcio
            // 
            this.textBox_descripcio.Location = new System.Drawing.Point(16, 149);
            this.textBox_descripcio.Name = "textBox_descripcio";
            this.textBox_descripcio.Size = new System.Drawing.Size(359, 96);
            this.textBox_descripcio.TabIndex = 7;
            this.textBox_descripcio.Text = "";
            // 
            // Add_Esdeveniment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_descripcio);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label_data);
            this.Controls.Add(this.label_descripcio);
            this.Controls.Add(this.label_titol);
            this.Controls.Add(this.textBox_nom);
            this.Name = "Add_Esdeveniment";
            this.Text = "Add_Esdeveniment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nom;
        private System.Windows.Forms.Label label_titol;
        private System.Windows.Forms.Label label_descripcio;
        private System.Windows.Forms.Label label_data;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RichTextBox textBox_descripcio;
    }
}