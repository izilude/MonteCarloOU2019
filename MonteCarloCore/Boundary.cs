using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public abstract class Boundary
    {
        protected Boundary(Position myPosition)
        {
            BoxPosition = myPosition;
        }

        public Position BoxPosition;

        public abstract bool CheckBoundaryCondition(SimulationBox box, SimulationObject mcObject);
    }
}
