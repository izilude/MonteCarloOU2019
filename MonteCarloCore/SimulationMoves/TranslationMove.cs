using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationEngineCore;

namespace MonteCarloCore
{
    public class TranslationMove : SimulationMove
    {
        public double Amplitude = 1;
        public override void ApplyMove(SimulationBox box, SimulationObject mcobject)
        {
            double dx = (2*JobEngine.Rng.NextDouble() - 1)*Amplitude;
            double dy = (2 * JobEngine.Rng.NextDouble() - 1)*Amplitude;
            mcobject.X += dx;
            mcobject.Y += dy;
        }
    }
}
