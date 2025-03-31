namespace ClubPilot
{
    partial class CrearClub
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxFundador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxNom = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12.25F);
            this.label3.Location = new System.Drawing.Point(344, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 12, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nom club";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtBoxFundador
            // 
            this.txtBoxFundador.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFundador.Location = new System.Drawing.Point(314, 221);
            this.txtBoxFundador.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxFundador.Name = "txtBoxFundador";
            this.txtBoxFundador.Size = new System.Drawing.Size(142, 20);
            this.txtBoxFundador.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Code", 12.25F);
            this.label6.Location = new System.Drawing.Point(344, 192);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 12, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fundador";
            // 
            // txtBoxData
            // 
            this.txtBoxData.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxData.Location = new System.Drawing.Point(314, 158);
            this.txtBoxData.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxData.Name = "txtBoxData";
            this.txtBoxData.Size = new System.Drawing.Size(142, 20);
            this.txtBoxData.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 12.25F);
            this.label4.Location = new System.Drawing.Point(310, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 12, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Any de creació";
            // 
            // txtBoxNom
            // 
            this.txtBoxNom.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNom.Location = new System.Drawing.Point(314, 98);
            this.txtBoxNom.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxNom.Name = "txtBoxNom";
            this.txtBoxNom.Size = new System.Drawing.Size(142, 20);
            this.txtBoxNom.TabIndex = 6;
            this.txtBoxNom.TextChanged += new System.EventHandler(this.txtBoxUsername1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cascadia Code", 12.25F);
            this.button1.Location = new System.Drawing.Point(292, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 35);
            this.button1.TabIndex = 13;
            this.button1.Text = "Escollir imatge";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Cascadia Code", 12.25F);
            this.button2.Location = new System.Drawing.Point(314, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 33);
            this.button2.TabIndex = 14;
            this.button2.Text = "Guardar club";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CrearClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxNom);
            this.Controls.Add(this.txtBoxFundador);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxData);
            this.Controls.Add(this.label6);
            this.Name = "CrearClub";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.CrearClub_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxFundador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxNom;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}