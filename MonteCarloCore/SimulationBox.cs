using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationEngineCore;

namespace MonteCarloCore
{
    public class SimulationBox
    {
        public List<SimulationObject> Objects = new List<SimulationObject>();

        public double CalculateEnergy()
        {
            return 0;
        }

        public SimulationObject GetRandomObject()
        {
           int index = JobEngine.Rng.Next(Objects.Count);
            return Objects[index];
        }

        public void AcceptAllMoves()
        {
            
        }

        public void RejectAllMoves()
        {
            
        }
    }
    
}
