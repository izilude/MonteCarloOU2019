using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public abstract class SimulationMove
    {
        public abstract void ApplyMove(SimulationBox box, SimulationObject mcobject); 
    
    }
}
