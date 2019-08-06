using System;
using SimulationEngineCore;

namespace MonteCarloCore.Jobs
{
    public class MonteCarloSimulationJob : Job
    {
   
        public int Cycles = 1000;
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
                    Console.WriteLine(currentEnergy);
                }
                else
                {
                    Box.RejectAllMoves();
                }
            }
            
        }

        protected virtual bool IsMoveAcceptable(double currentEnergy, double newEnergy)
        {
            return newEnergy <= currentEnergy;
        }
    }

}
