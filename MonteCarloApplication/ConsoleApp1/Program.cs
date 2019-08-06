using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MonteCarloCore;
using MonteCarloCore.Jobs;
using SimulationEngineCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            JobEngine engine = new JobEngine();
            engine.StartEngine();

            MonteCarloSimulationJob job2 = new MonteCarloSimulationJob();
            job2.Box = new SimulationBox();
            job2.Box.Objects.Add(new Circle());
            job2.Box.Objects.Add(new Circle() { Radius = 6});
            job2.Box.Objects.Add(new Circle());
            job2.Box.Objects.Add(new Circle());
            job2.Box.Objects.Add(new Circle());
            job2.Box.Objects.Add(new Circle());
            job2.Box.Objects.Add(new Circle());
            job2.Box.Objects.Add(new Circle());

            job2.Box.Boundaries.Add(new PeriodicBoundary(Position.Left));
            job2.Box.Boundaries.Add(new PeriodicBoundary(Position.Right));
            job2.Box.Boundaries.Add(new HardWall(Position.Top));
            job2.Box.Boundaries.Add(new HardWall(Position.Bottom));

            job2.ProgressEvent += Job1_ProgressEvent;

          
            engine.JobsToDo.Enqueue(job2);

            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        private static void Job1_ProgressEvent(int progressInPercent)
        {
            Console.WriteLine("---" + progressInPercent + "%---");
        }
    }
}
