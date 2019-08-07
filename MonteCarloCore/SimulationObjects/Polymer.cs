using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonteCarloCore.SimulationMoves;

namespace MonteCarloCore.SimulationObjects
{
    public class Polymer : SimulationObject
    {
        public List<Circle> Chains = new List<Circle>();

        public Polymer(List<Circle> chainLinks)
        {
            // Needs to be implemented
            Chains = chainLinks;
        }

        public Polymer(int numChains, double radius)
        {
            for (int i=0; i < numChains; i++)
            {
                Chains.Add(new Circle() {Radius = radius});
                Chains[i].X = i *2* Chains[i].Radius;
                
            }
            X = Chains[0].X;
            Y = Chains[0].Y;

            Moves.Add(new TranslationMove());
            Moves.Add(new RotationMove());
        }

        public override List<SimulationObject> GetSubObjects()
        {
            var objList = new List<SimulationObject>();
            objList.AddRange(Chains);
            return objList;
        }
        public override double CalculateInteractionEnergy(SimulationObject Obj)
        {
            double totalEng = 0;

            foreach(var circI in Chains)
            {
                foreach(var circJ in Chains)
                {
                    totalEng += circI.CalculateInteractionEnergy(circJ);
                }
                
            }
            return totalEng;
        }

        //Borrow the Hit function from the circle class
        public override bool Hit(SimulationBox box, Position boxPosition)
        {
            foreach (var circ in Chains)
            {
                if (circ.Hit(box, boxPosition))
                {
                    return true;
                }
            }
            return false;
        }






    }
}
