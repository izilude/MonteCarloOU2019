using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public class PeriodicBoundary : Boundary
    {
        public PeriodicBoundary(Position myPosition) : base(myPosition)
        {
        }

        public override bool CheckBoundaryCondition(SimulationBox box, SimulationObject mcObject)
        {
            if (BoxPosition == Position.Bottom && mcObject.Y > box.Height)
            {
                mcObject.Translate(0, -box.Height);
            }

            if (BoxPosition == Position.Top && mcObject.Y < 0)
            {
                mcObject.Translate(0, box.Height);
            }

            if (BoxPosition == Position.Right && mcObject.X > box.Width)
            {
                mcObject.Translate(-box.Width, 0);
            }

            if (BoxPosition == Position.Left && mcObject.X < 0)
            {
                mcObject.Translate(box.Width, 0);
            }

            return true;
        }
    }
}
