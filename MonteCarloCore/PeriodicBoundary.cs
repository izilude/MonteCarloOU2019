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
            if (BoxPosition == Position.Bottom && mcObject.Hit(box, Position.Bottom))
            {
                mcObject.Translate(0, -box.Height);
            }

            if (BoxPosition == Position.Top && mcObject.Hit(box, Position.Top))
            {
                mcObject.Translate(0, box.Height);
            }

            if (BoxPosition == Position.Right && mcObject.Hit(box, Position.Right))
            {
                mcObject.Translate(-box.Width, 0);
            }

            if (BoxPosition == Position.Left && mcObject.Hit(box, Position.Left))
            {
                mcObject.Translate(box.Width, 0);
            }

            return true;
        }
    }
}
