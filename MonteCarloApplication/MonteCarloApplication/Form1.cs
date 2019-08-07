using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonteCarloCore;
using MonteCarloCore.Jobs;
using MonteCarloCore.SimulationObjects;
using SimulationEngineCore;

namespace MonteCarloApplication
{
    public partial class Form1 : Form
    {
        public JobEngine _engine;

        public Form1()
        {
            InitializeComponent();

            _engine = new JobEngine();
            _engine.StartEngine();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MonteCarloSimulationJob job1 = new MonteCarloSimulationJobAnnealed();

            job1.Box = new SimulationBox();
            job1.MovesPerCycle = 10;

            var chain = new Polymer(15, 3);
            chain.Translate(10,10);
            job1.Box.Objects.Add(chain);

            chain = new Polymer(10, 3);
            chain.Translate(30, 30);
            job1.Box.Objects.Add(chain);

            for (int i = 0; i < 10; i++)
            {
                job1.Box.Objects.Add(new CircleLennardJones());
            }

            job1.Box.Boundaries.Add(new PeriodicBoundary(Position.Left));
            job1.Box.Boundaries.Add(new PeriodicBoundary(Position.Right));
            job1.Box.Boundaries.Add(new PeriodicBoundary(Position.Top));
            job1.Box.Boundaries.Add(new PeriodicBoundary(Position.Bottom));

            job1.ProgressEvent += Job1OnProgressEvent;

            simulationBoxView1.DisplayedBox = job1.Box;
            simulationBoxView1.Refresh();

            _engine.JobsToDo.Enqueue(job1);
        }

        private void Job2OnProgressEvent(int progressInPercent)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                progressBar2.Value = progressInPercent;
            }));
        }

        private void UpdateMonteCarloPlot()
        {
            simulationBoxView1.Refresh();
        }

        public delegate void SimulationBoxHandler();

        private void Job1OnProgressEvent(int progressInPercent)
        {
            var deleg = new SimulationBoxHandler(UpdateMonteCarloPlot);
            this.Invoke(deleg);

            this.BeginInvoke(new MethodInvoker(delegate
            {
                progressBar1.Value = progressInPercent;
            }));
        }
    }
}
