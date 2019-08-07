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

        public virtual List<SimulationObject> GetSubObjects()
        {
            return new List<SimulationObject>();
        }

        public abstract bool Hit(SimulationBox box, Position boxPosition);

        public abstract double CalculateInteractionEnergy(SimulationObject Obj);

        public void Translate(double dx, double dy)
        {
            X += dx;
            Y += dy;

            var subObjects = GetSubObjects();
            foreach (var sub in subObjects)
            {
                sub.Translate(dx, dy);
            }
        }

        public void SavePosition(bool saveX, bool saveY)
        {
            if (saveX) PreviousX = X;
            if (saveY) PreviousY = Y;

            var subObjects = GetSubObjects();
            foreach (var sub in subObjects)
            {
                sub.SavePosition(saveX, saveY);
            }
        }

        public void ResetPosition(bool resetX, bool resetY)
        {
            if (resetX) X = PreviousX;
            if (resetY) Y = PreviousY;

            var subObjects = GetSubObjects();
            foreach (var sub in subObjects)
            {
                sub.ResetPosition(resetX, resetY);
            }
        }

        public double PreviousX;
        public double PreviousY;

    }


}
