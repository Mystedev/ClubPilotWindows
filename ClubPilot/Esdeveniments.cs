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
        static public List<Esdeveniment> esdeveniments = new List<Esdeveniment>();
        private static FlowLayoutPanel flowLayoutPanel;
        static public Esdeveniment Esdeveniment { get; set; }
        Label tituloEvent = new Label();


        public Esdeveniments()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //Organització del layout per mostrar els esdeveniments
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            //flowLayoutPanel.AutoSize = true;
            //flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = System.Drawing.Color.SeaShell;
            flowLayoutPanel.WrapContents = true;
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            this.Controls.Add(flowLayoutPanel);
            //flowLayoutPanel.Padding = new Padding(20);
            this.Padding = new Padding(120, 10, 60, 10);  // márgenes horizontales iniciales
            //this.Resize += Esdeveniments_Resize;            //Config boton
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
            //Label titulo Esdeveniments
            Label tituloEvent = new Label();
            tituloEvent.Text = "Esdeveniments";
            tituloEvent.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            tituloEvent.Dock = DockStyle.Top; // Esto anclará el Label a la parte superior del formulario
            tituloEvent.AutoSize = false;
            tituloEvent.TextAlign = ContentAlignment.MiddleCenter; // Centra el texto
            tituloEvent.Padding = new Padding(10);
            tituloEvent.Location = new Point(
                (this.ClientSize.Width - tituloEvent.Width) / 2, 0); tituloEvent.Height = 50; 
            tituloEvent.BackColor = Color.Transparent;
            this.Controls.Add(tituloEvent);

           showEvents();

        }
         public static void showEvents()
        {
            esdeveniments.Clear();
            flowLayoutPanel.Controls.Clear();

            Connection connection = new Connection();
            esdeveniments = connection.exportEsdeveniment();
            if(Esdeveniment != null)
            {
                esdeveniments.Add(Esdeveniment);
            }
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
        //private void Esdeveniments_Resize(object sender, EventArgs e)
        //{
        //    int desiredWidth = 200;
        //    // Calculamos cuánto sobra a cada lado
        //    int sideMargin = (this.ClientSize.Width - desiredWidth) / 2;
        //    if (sideMargin < 0) sideMargin = 0;
        //    // Márgenes: left/right = sideMargin, top/bottom igual que antes
        //    flowLayoutPanel.Margin = new Padding(sideMargin,
        //                                         flowLayoutPanel.Margin.Top,
        //                                         sideMargin,
        //                                         flowLayoutPanel.Margin.Bottom);
        //}



    }
}
