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
    public partial class Esdeveniments: Form
    {
        static List<Esdeveniment> esdeveniments = new List<Esdeveniment>();
        private static FlowLayoutPanel flowLayoutPanel;
        static public Esdeveniment Esdeveniment { get; set; }
        public Esdeveniments()
        {
            InitializeComponent();
            //Organització del layout per mostrar els esdeveniments
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.AutoScroll = true;
                //flowLayoutPanel.AutoSize = true;
                //flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(flowLayoutPanel);
            flowLayoutPanel.Controls.Add(menuStrip1);
            //Config boton
            boton_addevent.Image = Properties.Resources.icons8_añadir_30;
            boton_addevent.Width = 40;
            boton_addevent.Height = 40;
            boton_addevent.Show();
            boton_addevent.Anchor = AnchorStyles.Bottom | AnchorStyles.Right; //El ancla
                //boton_addevent.Location = new Point(450, 300);
            boton_addevent.FlatStyle = FlatStyle.Flat;
            boton_addevent.FlatAppearance.BorderSize = 0;
            boton_addevent.FlatAppearance.MouseOverBackColor = Color.Transparent;
            boton_addevent.FlatAppearance.MouseDownBackColor = Color.Transparent;
            boton_addevent.BackColor = Color.Transparent;
            boton_addevent.Location = new Point(this.ClientSize.Width - boton_addevent.Width - 10, this.ClientSize.Height - boton_addevent.Height - 10);
            boton_addevent.TabStop = false;
            //Label Esdeveniments
            Label titulo = new Label();
            titulo.Text = "Esdeveniments";
            titulo.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            titulo.Location = new Point(this.ClientSize.Width , this.ClientSize.Height );
            titulo.AutoSize = true;
            flowLayoutPanel.Controls.Add( titulo );
            titulo.Show();
        }
        static public void showEvents()
        {
            esdeveniments.Add(Esdeveniment);
            for (int i = 0; i < esdeveniments.Count; i++)
            {
                esdeveniments[i].Show();
                esdeveniments[i].Panel.Show();
                flowLayoutPanel.Controls.Add(esdeveniments[i].Panel);
                //esdeveniments[i].Panel.Location = new Point(, 0);
            }
        }

        private void boton_addevent_Click(object sender, EventArgs e)
        {
            new Add_Esdeveniment().Show();
        }
    }
}
