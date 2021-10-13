using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entity.DB;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        //private readonly IDbRepository<CpuMetric> _repository;

        private PerformanceCounter _RamCounter;
        private IServiceProvider _scopeFactory;


        public RamMetricJob(IServiceProvider scopeFactory)
        {
            _RamCounter = new PerformanceCounter("Memory", "Available MBytes", null);
            this._scopeFactory = scopeFactory;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<IDbRepository<RAMMetric>>();


                var HDD = Convert.ToInt32(_RamCounter.NextValue());
                var time = DateTime.Now;//TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

                var metric = new RAMMetric();
                metric.MachineName = Environment.MachineName;
                metric.Time = time;
                metric.Value = HDD;
                _repository.AddAsync(metric);
            }

            return Task.CompletedTask;

        }
    }

}
