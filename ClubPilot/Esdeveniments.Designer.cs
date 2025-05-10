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
            this.boton_addevent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boton_addevent
            // 
            this.boton_addevent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boton_addevent.BackColor = System.Drawing.Color.Transparent;
            this.boton_addevent.FlatAppearance.BorderSize = 0;
            this.boton_addevent.Image = global::ClubPilot.Properties.Resources.icons8_añadir_30;
            this.boton_addevent.Location = new System.Drawing.Point(1254, 951);
            this.boton_addevent.Margin = new System.Windows.Forms.Padding(4);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Esdeveniments";
            this.Text = "Esdeveniments";
            this.Load += new System.EventHandler(this.Esdeveniments_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button boton_addevent;
    }
}