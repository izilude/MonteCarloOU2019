using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public class MonteCarloSimulationJobAnnealed : MonteCarloSimulationJob

    {
        public double Temperature = 1;

        protected override bool IsMoveAcceptable(double currentEnergy, double newEnergy)
        {
            double rand = 0.8;
            if (newEnergy < currentEnergy) return true;
            double prob = Math.Exp(-(newEnergy - currentEnergy) / (Temperature));
            return rand < prob;
        }
    }
}
