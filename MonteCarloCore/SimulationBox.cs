using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
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

        public List<Boundary> Boundaries = new List<Boundary>();

        public List<SimulationObject> Objects = new List<SimulationObject>();

        public bool CheckBoundaryConditions(SimulationObject mcObject)
        {
            foreach (var boundary in Boundaries)
            {
                boundary.CheckBoundaryCondition(this, mcObject);
            }

            return true;
        }

        private List<SimulationObject> GetAllObjects()
        {
            var allObjects = new List<SimulationObject>();
            allObjects.AddRange(Objects);

            foreach (var obj in Objects)
            {
                GetAllObjects(obj, allObjects);
            }

            return allObjects;
        }

        private void GetAllObjects(SimulationObject obj, List<SimulationObject> allObjects)
        {
            allObjects.AddRange(obj.GetSubObjects());

            foreach (var sub in obj.GetSubObjects())
            {
                GetAllObjects(sub, allObjects);
            }
        }

        public double CalculateEnergy()
        {
            List<SimulationObject> allObjects = GetAllObjects();

            double totalEnergy=0;
            for (int i = 0; i < allObjects.Count; i++)
            {
                for (int j = i + 1; j < allObjects.Count; j++)
                {
                   double ene = allObjects[i].CalculateInteractionEnergy(allObjects[j]);
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
                Objects[i].SavePosition(true, true);
            }
        }

        public void RejectAllMoves()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].ResetPosition(true, true);
            }
        }
    }
    
}
