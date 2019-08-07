using System;

namespace MonteCarloCore
{
    public class CircleLennardJones : Circle

    {
        public double wellDepth = 1;
        
        public override double CalculateInteractionEnergy(SimulationObject Obj)
        {
            // lennard-jones potential
            if (Obj is Circle circle)
            {
                double potential;
                if (circle.Radius + Radius
                     < Math.Sqrt((circle.X - X) * (circle.X - X)
                     + (circle.Y - Y) * (circle.Y - Y)))
                {
                    double rm = circle.Radius + Radius;
                    double r = Math.Sqrt((circle.X - X) * (circle.X - X)
                        + (circle.Y - Y) * (circle.Y - Y));
                    potential = wellDepth * (Math.Pow((rm / r), 12.0) - 2.0 * Math.Pow((rm / r), 6.0));
                }
                else
                {
                    //kick it out
                    potential = 10000000;
                }
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
