using System.Collections.Generic;

namespace SimulationEngineCore
{
    public class JobEngine
    {
        public int NumberOfThreads = 1;

        public Queue<Job> JobsToDo = new Queue<Job>();
        private List<JobEngineThread> _workerThreads = new List<JobEngineThread>();

        public JobEngine()
        {
            for (int i = 0; i < NumberOfThreads; i++)
            {
                JobEngineThread newThread = new JobEngineThread();
                _workerThreads.Add(newThread);
            }
        }

        public void StartEngine()
        {
            foreach (JobEngineThread thread in _workerThreads)
            {
                thread.Start(JobsToDo, "Our Thread");
            }
        }

        public void StopEngine()
        {
            foreach (JobEngineThread thread in _workerThreads)
            {
                thread.Stop();
            }
        }
    }
}
