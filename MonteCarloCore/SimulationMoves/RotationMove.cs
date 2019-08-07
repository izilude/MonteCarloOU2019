using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationEngineCore;

namespace MonteCarloCore.SimulationMoves
{
    public class RotationMove : SimulationMove
    {
        public double MaxAngleInDegrees = 45;

        public override void ApplyMove(SimulationBox box, SimulationObject mcobject)
        {
            double theta = (2 * JobEngine.Rng.NextDouble() - 1) * MaxAngleInDegrees;
            int rotationIndex = JobEngine.Rng.Next(mcobject.GetSubObjects().Count);

            ApplyMove(mcobject, theta, rotationIndex);
        }

        private void ApplyMove(SimulationObject mcObject, double theta, int rotationIndex)
        {
            Move(mcObject, theta, rotationIndex);

            //var subObjects = mcObject.GetSubObjects();
            //foreach (var sub in subObjects)
            //{
            //    ApplyMove(sub, theta, rotationIndex);
            //}
        }

        private void Move(SimulationObject mcobject, double theta, int rotationIndex)
        {
            var subObjects = mcobject.GetSubObjects();
            SimulationObject pivotObject = subObjects[rotationIndex];

            double x0 = pivotObject.X;
            double y0 = pivotObject.Y;

            int startIndex = 0;
            int stopIndex = 0;

            if (JobEngine.Rng.NextDouble() < 0.5)
            {
                startIndex = 0;
                stopIndex = rotationIndex;
            }
            else
            {
                startIndex = rotationIndex + 1;
                stopIndex = subObjects.Count;
            }

            for (int i = startIndex; i < stopIndex; i++)
            {
                double cos1 = Math.Cos(theta * Math.PI / 180);
                double sin1 = Math.Sin(theta * Math.PI / 180);

                double x = subObjects[i].X;
                double y = subObjects[i].Y;

                double xp = x0 + (x - x0) * cos1 - (y - y0) * sin1;
                double yp = y0 + (x - x0) * sin1 + (y - y0) * cos1;

                subObjects[i].Translate(xp - x, yp - y);
            }
        }
    }
}
