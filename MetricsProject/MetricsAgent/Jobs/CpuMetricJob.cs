
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Entity.DB;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection.PortableExecutable;
using static System.Uri;


namespace MetricsAgent.Jobs
{
    public class CpuMetricJob : IJob
    {
       

        private PerformanceCounter _cpuCounter;
        private IServiceProvider _scopeFactory;


        public CpuMetricJob(IServiceProvider scopeFactory)
        {
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            this._scopeFactory = scopeFactory;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<IDbRepository<CpuMetric>>();
                var cpuUsageInPercents = Convert.ToInt32(_cpuCounter.NextValue());
                var time =DateTime.Now; //TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

                var metric = new CpuMetric();
                metric.MachineName = Environment.MachineName;
                metric.Time = time;
                metric.Value = cpuUsageInPercents;
                _repository.AddAsync(metric);
            }
            
            return Task.CompletedTask;

        }
    }

}
