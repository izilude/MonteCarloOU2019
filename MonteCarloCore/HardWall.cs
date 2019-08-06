using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public class HardWall : Boundary
    {
        public override bool CheckBoundaryCondition(SimulationBox box, SimulationObject mcObject)
        {
            if ( BoxPosition == Position.Top || BoxPosition == Position.Bottom)
            {
                mcObject.Y = mcObject.PreviousY;
            }
            if (BoxPosition == Position.Left || BoxPosition == Position.Right)
            {
                mcObject.X = mcObject.PreviousX;
            }
            return true;
        }

        protected HardWall(Position myPosition) : base(myPosition)
        {
        }
    }
}