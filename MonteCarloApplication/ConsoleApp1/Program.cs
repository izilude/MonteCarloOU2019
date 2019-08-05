using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimulationEngineCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            JobEngine engine = new JobEngine();
            engine.StartEngine();

            TestJob job1 = new TestJob() { Iterations = 100 };
            job1.ProgressEvent += Job1_ProgressEvent;

            TestJob job2 = new TestJob() { Iterations = 200 };
            job2.ProgressEvent += Job1_ProgressEvent;

            engine.JobsToDo.Enqueue(job1);
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
