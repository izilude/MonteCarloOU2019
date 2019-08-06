using System;

namespace MonteCarloCore
{
    public class CircleLennardJones : Circle

    {
     
        public override double CalculateInteractionEnergy(SimulationObject Obj)
        {
            // lennard-jones potential
            if (Obj is Circle circle)
            {
                double rm = circle.Radius + Radius;
                double r = Math.Sqrt((circle.X - X) * (circle.X - X)
                    + (circle.Y - Y) * (circle.Y - Y));
                double eps = 1;
                double potential = eps * (Math.Pow((rm / r), 12.0) - 2.0 * Math.Pow((rm / r), 6.0));
                return potential;
            }
            else
            {
                return 10000;
            }
            throw new Exception("I don't know how to deal with this!!!");
        }

    }
}
