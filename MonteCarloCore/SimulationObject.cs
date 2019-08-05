using System.Collections.Generic;
using SimulationEngineCore;

namespace MonteCarloCore
{
    public abstract class SimulationObject
    {
        public List<SimulationMove> Moves = new List<SimulationMove>();
        public double X, Y;
        public SimulationMove GetRandomMove()
        {
            int index = JobEngine.Rng.Next(Moves.Count);
            return Moves[index];
        }

        public abstract double CalculateInteractionEnergy(SimulationObject Obj);

        public double PreviousX;
        public double PreviousY;

    }


}
