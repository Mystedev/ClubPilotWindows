namespace ClubPilot
{
    partial class Esdeveniments
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jugadorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esdevenimentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comptesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noticiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton_addevent = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MidnightBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jugadorsToolStripMenuItem,
            this.esdevenimentsToolStripMenuItem,
            this.comptesToolStripMenuItem,
            this.noticiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1462, 49);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jugadorsToolStripMenuItem
            // 
            this.jugadorsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jugadorsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.jugadorsToolStripMenuItem.Name = "jugadorsToolStripMenuItem";
            this.jugadorsToolStripMenuItem.Size = new System.Drawing.Size(156, 45);
            this.jugadorsToolStripMenuItem.Text = "Jugadors";
            // 
            // esdevenimentsToolStripMenuItem
            // 
            this.esdevenimentsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.esdevenimentsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.esdevenimentsToolStripMenuItem.Name = "esdevenimentsToolStripMenuItem";
            this.esdevenimentsToolStripMenuItem.Size = new System.Drawing.Size(237, 45);
            this.esdevenimentsToolStripMenuItem.Text = "Esdeveniments";
            // 
            // comptesToolStripMenuItem
            // 
            this.comptesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comptesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.comptesToolStripMenuItem.Name = "comptesToolStripMenuItem";
            this.comptesToolStripMenuItem.Size = new System.Drawing.Size(154, 45);
            this.comptesToolStripMenuItem.Text = "Comptes";
            // 
            // noticiesToolStripMenuItem
            // 
            this.noticiesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noticiesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.noticiesToolStripMenuItem.Name = "noticiesToolStripMenuItem";
            this.noticiesToolStripMenuItem.Size = new System.Drawing.Size(143, 45);
            this.noticiesToolStripMenuItem.Text = "Noticies";
            // 
            // boton_addevent
            // 
            this.boton_addevent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boton_addevent.BackColor = System.Drawing.Color.Transparent;
            this.boton_addevent.FlatAppearance.BorderSize = 0;
            this.boton_addevent.Image = global::ClubPilot.Properties.Resources.icons8_añadir_30;
            this.boton_addevent.Location = new System.Drawing.Point(1254, 951);
            this.boton_addevent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.boton_addevent.Name = "boton_addevent";
            this.boton_addevent.Size = new System.Drawing.Size(195, 38);
            this.boton_addevent.TabIndex = 2;
            this.boton_addevent.UseVisualStyleBackColor = false;
            this.boton_addevent.Click += new System.EventHandler(this.boton_addevent_Click);
            // 
            // Esdeveniments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1462, 1002);
            this.Controls.Add(this.boton_addevent);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Esdeveniments";
            this.Text = "Esdeveniments";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jugadorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esdevenimentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comptesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noticiesToolStripMenuItem;
        private System.Windows.Forms.Button boton_addevent;
    }
}