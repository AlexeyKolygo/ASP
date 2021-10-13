
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Entity.DB;
using System.Collections;
using System.Collections.Specialized;



namespace MetricsManager.Jobs
{
    public class testJob : IJob
    {
  

        public Task Execute(IJobExecutionContext context)
        {

            Debug.WriteLine("Test");
            
            return Task.CompletedTask;

        }
    }

}
