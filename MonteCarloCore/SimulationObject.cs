using System.Collections.Generic;
using SimulationEngineCore;

namespace MonteCarloCore
{
    public class SimulationObject
    {
        public List<SimulationMove> Moves = new List<SimulationMove>();

        public SimulationMove GetRandomMove()
        {
            int index = JobEngine.Rng.Next(Moves.Count);
            return Moves[index];
        }
    }
}
