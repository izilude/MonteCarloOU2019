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
            double totalEnergy=0;
            for (int i = 0; i < Objects.Count; i++)
            {
                for (int j = i + 1; j < Objects.Count; j++)
                {
                   double ene = Objects[i].CalculateInteractionEnergy(Objects[j]);
                    totalEnergy += ene;
                    
                }
            }
            return totalEnergy;
        }
        
        public SimulationObject GetRandomObject()
        {
           int index = JobEngine.Rng.Next(Objects.Count);
            return Objects[index];
        }

        public void AcceptAllMoves()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].PreviousX = Objects[i].X;
                Objects[i].PreviousY = Objects[i].Y;
            }
        }

        public void RejectAllMoves()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].X = Objects[i].PreviousX;
                Objects[i].Y = Objects[i].PreviousY;
            }
        }
    }
    
}
