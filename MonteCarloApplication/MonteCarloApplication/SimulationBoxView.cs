using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonteCarloCore;

namespace MonteCarloApplication
{
    public partial class SimulationBoxView : UserControl
    {
        public SimulationBox DisplayedBox = null;

        public SimulationBoxView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(Brushes.Black, 0,0,Width, Height);

            if (DisplayedBox == null) return;

            foreach (var mcObject in DisplayedBox.Objects)
            {
                if (mcObject is Circle circle)
                {
                    double xConversion = Width / DisplayedBox.Width;
                    double yConversion = Height / DisplayedBox.Height;

                    double x1 = (circle.X - circle.Radius)*xConversion;
                    double x2 = (circle.X + circle.Radius)*xConversion;
                    double y1 = (circle.Y - circle.Radius)*yConversion;
                    double y2 = (circle.Y + circle.Radius)*yConversion;

                    e.Graphics.FillEllipse(Brushes.Aqua, (int)x1,(int)y1, (int)(x2-x1),(int)(y2-y1));
                }
            }
        }
    }
}
