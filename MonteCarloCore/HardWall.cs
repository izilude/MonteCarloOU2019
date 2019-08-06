namespace MonteCarloCore
{
    public class HardWall : Boundary
    {
        public override bool CheckBoundaryCondition(SimulationBox box, SimulationObject mcObject)
        {
            if ( BoxPosition == Position.Top && mcObject.Hit(box, Position.Top))
            {
                mcObject.Y = mcObject.PreviousY;
            }
            if (BoxPosition == Position.Bottom && mcObject.Hit(box, Position.Bottom))
            {
                mcObject.Y = mcObject.PreviousY;
            }
            if (BoxPosition == Position.Left && mcObject.Hit(box, Position.Left))
            {
                mcObject.X = mcObject.PreviousX;
            }
            if (BoxPosition == Position.Right && mcObject.Hit(box, Position.Right))
            {
                mcObject.X = mcObject.PreviousX;
            }
            return true;
        }

        public HardWall(Position myPosition) : base(myPosition)
        {
        }
    }
}