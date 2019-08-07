namespace MonteCarloCore
{
    public class HardWall : Boundary
    {
        public override bool CheckBoundaryCondition(SimulationBox box, SimulationObject mcObject)
        {
            if ( BoxPosition == Position.Top && mcObject.Hit(box, Position.Top))
            {
                mcObject.ResetPosition(false, true);
            }
            if (BoxPosition == Position.Bottom && mcObject.Hit(box, Position.Bottom))
            {
                mcObject.ResetPosition(false, true);
            }
            if (BoxPosition == Position.Left && mcObject.Hit(box, Position.Left))
            {
                mcObject.ResetPosition(true, false);
            }
            if (BoxPosition == Position.Right && mcObject.Hit(box, Position.Right))
            {
                mcObject.ResetPosition(true, false);
            }
            return true;
        }

        public HardWall(Position myPosition) : base(myPosition)
        {
        }
    }
}