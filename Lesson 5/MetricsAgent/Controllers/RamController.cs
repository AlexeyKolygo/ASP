using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Entity.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase

    {
        private readonly IDbRepository<RamMetric> _ramMetricsRepo;
        private readonly ILogger<RamController> _logger;

        
        public RamController(IDbRepository<RamMetric> ramMetricsRepo, ILogger<RamController> logger)
        {
            _ramMetricsRepo = ramMetricsRepo;
            _logger = logger;
        }

        [HttpGet]
        public Task<List<RamMetric>> GetAll()
        {
            return _ramMetricsRepo.GetAll().ToListAsync();
        }

        [HttpGet("from/{from}/to/{to}")]
        public IActionResult GetMetrics([FromRoute] DateTime from, DateTime to)
        {
            //var result = _cpuMetricsRepo.GetAll().Select(metric => metric.Time >= from && metric.Time <= to);//(e=>e.Time>= from&&e.Time=to));
            var result = _ramMetricsRepo.GetAll().Where(metric => metric.Time >= from && metric.Time <= to);

            return Ok(result);
        }

        [HttpPost]
        public Task Add(RamMetric metric)
        {
            return _ramMetricsRepo.AddAsync(metric);
        }

        [HttpPut]
        public Task Update(RamMetric metric)
        {
            return _ramMetricsRepo.UpdateAsync(metric);
        }

        [HttpDelete]
        public Task Delete(RamMetric metric)
        {
            return _ramMetricsRepo.DeleteAsync(metric);
        }

    }
}
