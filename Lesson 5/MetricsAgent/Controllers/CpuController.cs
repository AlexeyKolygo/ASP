using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;




namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase

    {
        private readonly IDbRepository<CpuMetric> _cpuMetricsRepo;
        private readonly ILogger<CpuController> _logger;

        
        public CpuController(IDbRepository<CpuMetric> cpuMetricsRepo, ILogger<CpuController> logger)
        {
            _cpuMetricsRepo = cpuMetricsRepo;
            _logger = logger;
        }

        [HttpGet("from/{from}/to/{to}")]
        public IActionResult GetMetrics([FromRoute] DateTime from,DateTime to)
        {
            var result = _cpuMetricsRepo.GetAll().Where(metric => metric.Time >= from && metric.Time <= to);
            return Ok(result);
        }

        [HttpGet]
        public Task<List<CpuMetric>> GetAll()
        {
            return _cpuMetricsRepo.GetAll().ToListAsync();
        }

        [HttpPost]
        public Task Add(CpuMetric cpumetric)
        {
            return _cpuMetricsRepo.AddAsync(cpumetric);
        }

        [HttpPut]
        public Task Update(CpuMetric cpumetric)
        {
            return _cpuMetricsRepo.UpdateAsync(cpumetric);
        }

        [HttpDelete]
        public Task Delete(CpuMetric cpumetric)
        {
            return _cpuMetricsRepo.DeleteAsync(cpumetric);
        }

    }
}
