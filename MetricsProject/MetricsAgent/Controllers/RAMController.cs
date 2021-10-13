using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RAMController : ControllerBase
    {
        private readonly IDbRepository<RAMMetric> _RamMetricsRepo;
        private readonly ILogger<RAMController> _logger;
        private readonly IMapper mapper;


        public RAMController(IDbRepository<RAMMetric> hddMetricsRepo, ILogger<RAMController> logger, IMapper mapper)
        {
            _RamMetricsRepo = hddMetricsRepo;
            _logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<RamMetricsDTO>> GetAll()
        {
            var metrics = _RamMetricsRepo.GetAll().ToListAsync();
            var response = new List<RamMetricsDTO>();

            foreach (var metric in await metrics)
            {
                var m = mapper.Map<RamMetricsDTO>(metric);
                response.Add(m);

            }
            return response;
        }

        [HttpGet("from/{from}/to/{to}")]
        public IActionResult GetMetrics([FromRoute] DateTime from, DateTime to)
        {
            var result = _RamMetricsRepo.GetAll().Where(metric => metric.Time >= from && metric.Time <= to);
            return Ok(result);
        }

    }
}
