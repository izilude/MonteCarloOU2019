using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulationEngineCore
{
    public class TestJob : Job
    {
        public int Iterations = 10;

        public override void Run()
        {
            double sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                Thread.Sleep(100);
                sum += 1;

                OnProgress((int)(100.0*i/Iterations));
            }
            Console.WriteLine(sum);
        }
    }
}
