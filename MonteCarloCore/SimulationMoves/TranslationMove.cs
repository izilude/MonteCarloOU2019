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
            double dx = (2 * JobEngine.Rng.NextDouble() - 1) * Amplitude;
            double dy = (2 * JobEngine.Rng.NextDouble() - 1) * Amplitude;

            ApplyMove(mcobject, dx, dy);
        }

        private void ApplyMove(SimulationObject mcObject, double dx, double dy)
        {
            Move(mcObject, dx, dy);

            var subObjects = mcObject.GetSubObjects();
            foreach (var sub in subObjects)
            {
                ApplyMove(sub, dx, dy);
            }
        }

        private void Move(SimulationObject mcobject, double dx, double dy)
        {
            mcobject.Translate(dx, dy);
        }
    }
}
