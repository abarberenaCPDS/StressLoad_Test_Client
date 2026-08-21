using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace StressLoad_Test_Client
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtThreads.Text = Environment.ProcessorCount.ToString();
            this.txtProcessorCount.Text = Environment.ProcessorCount.ToString();
        }

        private void btnStressTest_Click(object sender, EventArgs e)
        {
            int iterations = Convert.ToInt32(this.txtIterations.Text);
            int threads = Convert.ToInt32(this.txtThreads.Text);

            for (int i = 0; i < threads; i++)
            {
                Thread thread = new Thread(delegate ()
                {

                    // Instantiate here...
                    //http

                    Stopwatch watch = new Stopwatch();

                    watch.Start();
                    //DateTime time = DateTime.Now;

                    for (int j = 0; j < iterations; j++)
                    {
                        // invoke here...
                        //ClientRectangle.getasync

                        // use this to print out
                        //var result = stringresponse;
                        Trace.WriteLine($" - Iteration {j + 1}");
                        //Trace.WriteLine(result);
                    }
                    watch.Stop();

                    int transactionsPerSecond = (int)((Convert.ToDecimal(iterations) / Convert.ToDecimal(watch.ElapsedMilliseconds)) * 1000);
                    double transactionDuration = 1.0 / (double)transactionsPerSecond;

                    Trace.WriteLine($"\n----------");
                    Trace.WriteLine($"Transactions Per Second = {transactionsPerSecond * threads} Transaction Duration = {transactionDuration}", "Stress Test Results");
                    Trace.WriteLine($"----------\n");
                });

                thread.Name = $"My Thread_{i + 1}";
                Trace.WriteLine($"- Thread {thread.Name}");

                thread.Start();
            }
        }
    }
}