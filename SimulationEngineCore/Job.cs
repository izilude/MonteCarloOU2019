using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationEngineCore
{
    public delegate void ProgressDelegate(int progressInPercent);

    public abstract class Job
    {
        public event ProgressDelegate ProgressEvent;

        public void OnProgress(int progressInPercent)
        {
            ProgressEvent?.Invoke(progressInPercent);
        }

        public abstract void Run();
    }
}
