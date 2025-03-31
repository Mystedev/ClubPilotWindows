namespace ClubPilot
{
    partial class AddAccount
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
            this.txtBoxUsername1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxNom1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxCognoms1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxEmail1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxRol1 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add_account = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxUsername1
            // 
            this.txtBoxUsername1.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.txtBoxUsername1.Location = new System.Drawing.Point(120, 83);
            this.txtBoxUsername1.Name = "txtBoxUsername1";
            this.txtBoxUsername1.Size = new System.Drawing.Size(200, 27);
            this.txtBoxUsername1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.label3.Location = new System.Drawing.Point(15, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username:";
            // 
            // txtBoxNom1
            // 
            this.txtBoxNom1.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.txtBoxNom1.Location = new System.Drawing.Point(121, 132);
            this.txtBoxNom1.Name = "txtBoxNom1";
            this.txtBoxNom1.Size = new System.Drawing.Size(200, 27);
            this.txtBoxNom1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.label4.Location = new System.Drawing.Point(65, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nom:";
            // 
            // txtBoxCognoms1
            // 
            this.txtBoxCognoms1.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.txtBoxCognoms1.Location = new System.Drawing.Point(438, 130);
            this.txtBoxCognoms1.Name = "txtBoxCognoms1";
            this.txtBoxCognoms1.Size = new System.Drawing.Size(300, 27);
            this.txtBoxCognoms1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.label5.Location = new System.Drawing.Point(343, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cognoms:";
            // 
            // txtBoxEmail1
            // 
            this.txtBoxEmail1.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.txtBoxEmail1.Location = new System.Drawing.Point(437, 85);
            this.txtBoxEmail1.Name = "txtBoxEmail1";
            this.txtBoxEmail1.Size = new System.Drawing.Size(300, 27);
            this.txtBoxEmail1.TabIndex = 14;
            this.txtBoxEmail1.TextChanged += new System.EventHandler(this.txtBoxEmail1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.label6.Location = new System.Drawing.Point(361, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "Email:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtBoxRol1
            // 
            this.txtBoxRol1.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.txtBoxRol1.Location = new System.Drawing.Point(120, 180);
            this.txtBoxRol1.Name = "txtBoxRol1";
            this.txtBoxRol1.Size = new System.Drawing.Size(200, 27);
            this.txtBoxRol1.TabIndex = 16;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Cascadia Code", 10F);
            this.label28.Location = new System.Drawing.Point(65, 180);
            this.label28.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 22);
            this.label28.TabIndex = 15;
            this.label28.Text = "Rol:";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::ClubPilot.Properties.Resources.icons8_cancelar_30;
            this.btn_cancel.Location = new System.Drawing.Point(687, 171);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(50, 50);
            this.btn_cancel.TabIndex = 18;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add_account
            // 
            this.btn_add_account.Image = global::ClubPilot.Properties.Resources.icons8_aceptar_30;
            this.btn_add_account.Location = new System.Drawing.Point(616, 171);
            this.btn_add_account.Name = "btn_add_account";
            this.btn_add_account.Size = new System.Drawing.Size(50, 50);
            this.btn_add_account.TabIndex = 17;
            this.btn_add_account.UseVisualStyleBackColor = true;
            this.btn_add_account.Click += new System.EventHandler(this.btn_add_account_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(288, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 35);
            this.label1.TabIndex = 19;
            this.label1.Text = "Compte nou";
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(752, 233);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add_account);
            this.Controls.Add(this.txtBoxRol1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.txtBoxEmail1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxCognoms1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxNom1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxUsername1);
            this.Controls.Add(this.label3);
            this.Name = "AddAccount";
            this.Text = "AddAccount";
            this.Load += new System.EventHandler(this.AddAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxUsername1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxNom1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxCognoms1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxEmail1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxRol1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btn_add_account;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label1;
    }
}