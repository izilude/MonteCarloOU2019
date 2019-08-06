using System;

namespace MonteCarloCore
{
    public class Circle : SimulationObject

    {
        public double Radius = 1;
        public Circle()
        {
            Moves.Add(new TranslationMove());
            Moves.Add(new TranslationMove() { Amplitude = 10 } );
            Moves.Add(new TranslationMove() { Amplitude = 0.1 } );
        }

        public override bool Hit(SimulationBox box, Position boxPosition)
        {
            if (boxPosition == Position.Top)
            {
                return Y < Radius;
            }
            else if (boxPosition == Position.Bottom)
            {
                return Y > box.Height - Radius;
            }
            else if (boxPosition == Position.Left)
            {
                return X < Radius;
            }
            else
            {
                return X > box.Height - Radius;
            }
        }

        public override double CalculateInteractionEnergy(SimulationObject Obj)
        {
            if(Obj is Circle circle ) 
            {
                if (circle.Radius + Radius
                     < Math.Sqrt((circle.X - X) * (circle.X - X)
                     + (circle.Y - Y) * (circle.Y - Y)))
                {
                    return 0;
                }
                else return 10000;
            }

            throw new Exception("I don't know how to deal with this!!!");
        }

    }
}
