using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Interface;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase

    {
        private readonly ILogger<CpuController> _logger;
        private ICpuMetricsRepository repository;
        
        public CpuController(ICpuMetricsRepository repository, ILogger<CpuController> logger)
        {
            this.repository = repository;
            _logger = logger;
        }


        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentCPU([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"CPU response: ");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            repository.Create(new IMetric
            {
                Time = request.Time.ToString("hh:mm tt"),
                Value = request.Value
            });

            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto { Time = metric.Time.ToString(), Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }











    }
}
