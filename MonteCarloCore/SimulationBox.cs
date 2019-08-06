using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationEngineCore;

namespace MonteCarloCore
{
    public enum Position { Top, Bottom, Left, Right}

    public class SimulationBox
    {
        public double Width = 100;
        public double Height = 100;

        public Boundary Left;
        public Boundary Right;
        public Boundary Top;
        public Boundary Bottom;

        public List<SimulationObject> Objects = new List<SimulationObject>();

        public bool CheckBoundaryConditions(SimulationObject mcObject)
        {
            if (mcObject.Y > Height)
            {
                Bottom.CheckBoundaryCondition(this, mcObject);
            }
            else if (mcObject.Y < 0)
            {
                Top.CheckBoundaryCondition(this, mcObject);
            }

            if (mcObject.X > Width)
            {
                Right.CheckBoundaryCondition(this, mcObject);
            }
            else if (mcObject.X < 0)
            {
                Left.CheckBoundaryCondition(this, mcObject);
            }
            return true;
        }

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
