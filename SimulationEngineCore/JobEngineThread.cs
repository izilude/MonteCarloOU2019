using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulationEngineCore
{
    public class JobEngineThread
    {
        public bool Running = true;
        private Queue<Job> _jobQueue;

        private Thread _thread;

        public void Start(Queue<Job> jobQueue, string nameOfThread)
        {
            _jobQueue = jobQueue;
            _thread = new Thread(WorkJob);
            _thread.Name = nameOfThread;
            _thread.Start();
        }

        public void Stop()
        {
            
        }

        public void WorkJob()
        {
            while (Running)
            {
                Thread.Sleep(100);

                if (_jobQueue.Count > 0)
                {
                    Job job = null;
                    lock (_jobQueue)
                    {
                        job = _jobQueue.Dequeue();
                    }

                    if (job != null) job.Run();
                }
            }
        }
    }
}
