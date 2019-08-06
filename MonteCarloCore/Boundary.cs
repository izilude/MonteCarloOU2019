using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public abstract class Boundary
    {
        public abstract bool CheckBoundaryCondition(SimulationBox box, SimulationObject mcObject);
    }
}
