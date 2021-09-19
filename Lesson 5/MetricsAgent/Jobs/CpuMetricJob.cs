
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
    public class CpuMetricJob : IJob
    {
        //private readonly IDbRepository<CpuMetric> _repository;

        private PerformanceCounter _cpuCounter;
        private IServiceProvider _scopeFactory;//иначе никак))пришлось передать в синглотн конструктор этот объект с вызовом CreateScope и уже туда сунуть репу.


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
                metric.Time = time;
                metric.Value = cpuUsageInPercents;
                _repository.AddAsync(metric);
            }
            
            return Task.CompletedTask;

        }
    }

}
