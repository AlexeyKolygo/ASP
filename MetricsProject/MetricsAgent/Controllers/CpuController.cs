using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Entity.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;


namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase

    {
        private readonly IDbRepository<CpuMetric> _cpuMetricsRepo;
        private readonly ILogger<CpuController> _logger;
        private readonly IMapper mapper;

        public CpuController(IDbRepository<CpuMetric> cpuMetricsRepo, ILogger<CpuController> logger, IMapper mapper)
        {
            _cpuMetricsRepo = cpuMetricsRepo;
            _logger = logger;
            this.mapper = mapper;
        }


        [HttpGet("from/{from}/to/{to}")]
        public IActionResult GetMetrics([FromRoute] DateTime from,DateTime to)
        {
            var result = _cpuMetricsRepo.GetAll().Where(metric => metric.Time >= from && metric.Time <= to);
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<CpuMetricsDTO>> GetAll()
        {

            var metrics = _cpuMetricsRepo.GetAll().ToListAsync();
            var response = new List<CpuMetricsDTO>();

            foreach (var metric in await metrics)
            {
                var m = mapper.Map<CpuMetricsDTO>(metric);
                response.Add(m);
                _logger.LogInformation(
                    $"Добавлена метрика от {metric.MachineName}. Время:{metric.Time}. Значение: {metric.Value}");

            }
            return response;
        }

      

    }
}
