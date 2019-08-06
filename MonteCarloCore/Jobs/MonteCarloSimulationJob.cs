using System;
using SimulationEngineCore;

namespace MonteCarloCore.Jobs
{
    public class MonteCarloSimulationJob : Job
    {
        public int Cycles = 100000;
        public int MovesPerCycle = 5;
        public SimulationBox Box;

        public override void Run()
        {
            double currentEnergy = Box.CalculateEnergy();
            for (int i = 0; i < Cycles; i++)
            {
                for (int j = 0; j < MovesPerCycle; j++)
                {
                    SimulationObject mcObject = Box.GetRandomObject();
                    SimulationMove move = mcObject.GetRandomMove();
                    move.ApplyMove(Box, mcObject);
                    Box.CheckBoundaryConditions(mcObject);
                }

                double newEnergy = Box.CalculateEnergy();
                if (IsMoveAcceptable(currentEnergy, newEnergy))
                {
                    Box.AcceptAllMoves();
                    currentEnergy = newEnergy;
                }
                else
                {
                    Box.RejectAllMoves();
                }

                OnProgress(100*i/Cycles);
            }
            
        }

        protected virtual bool IsMoveAcceptable(double currentEnergy, double newEnergy)
        {
            return newEnergy <= currentEnergy;
        }
    }

}
