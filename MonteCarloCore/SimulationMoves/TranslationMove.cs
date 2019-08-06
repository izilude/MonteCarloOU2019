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
        double dx = (2 * JobEngine.Rng.NextDouble() - 1) * Amplitude;
        double dy = (2 * JobEngine.Rng.NextDouble() - 1) * Amplitude;
        public override void ApplyMove(SimulationBox box, SimulationObject mcobject)
        {
            
            Move(mcobject,dx,dy);

            var subObjects = mcobject.GetSubObjects();
            foreach (var sub in subObjects)
            {
                ApplyMove(box, sub);
            }
        }

        private void Move(SimulationObject mcobject, double dx, double dy)
        {
            mcobject.X += dx;
            mcobject.Y += dy;
        }
    }
}
