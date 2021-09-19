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

        private PerformanceCounter _ramCounter;
        private IServiceProvider _scopeFactory;


        public RamMetricJob(IServiceProvider scopeFactory)
        {
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            this._scopeFactory = scopeFactory;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetRequiredService<IDbRepository<RamMetric>>();


                var RamAvailable = Convert.ToInt32(_ramCounter.NextValue());
                var time = DateTime.Now;//TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

                var metric = new RamMetric();
                metric.Time = time;
                metric.Value = RamAvailable;
                _repository.AddAsync(metric);
            }

            return Task.CompletedTask;

        }
    }

}
