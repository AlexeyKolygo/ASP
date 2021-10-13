
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Entity.DB;
using System.Collections;
using System.Collections.Specialized;



namespace MetricsAgent.Jobs
{
    public class testJob : IJob
    {

        private PerformanceCounter _cpuCounter;


        public testJob()
        {
           
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        }

        public Task Execute(IJobExecutionContext context)
        {

            Debug.WriteLine("Test");
            return Task.CompletedTask;

        }
    }

}
