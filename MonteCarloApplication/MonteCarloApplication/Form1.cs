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
            TestJob job1 = new TestJob() {Iterations = 100};
            job1.ProgressEvent += Job1OnProgressEvent;
            job1.ProgressEvent += Job2OnProgressEvent;

            TestJob job2 = new TestJob() { Iterations = 200 };
            job2.ProgressEvent += Job2OnProgressEvent;

            _engine.JobsToDo.Enqueue(job1);
            _engine.JobsToDo.Enqueue(job2);
        }

        private void Job2OnProgressEvent(int progressInPercent)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                progressBar2.Value = progressInPercent;
            }));
        }

        private void Job1OnProgressEvent(int progressInPercent)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                progressBar1.Value = progressInPercent;
            }));
        }
    }
}
