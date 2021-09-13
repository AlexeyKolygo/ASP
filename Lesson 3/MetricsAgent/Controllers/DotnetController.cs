using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    public class DotnetController : ControllerBase
    {
        private readonly ILogger<DotnetController> _logger;
        private ICpuMetricsRepository repository;

        public DotnetController(ICpuMetricsRepository repository, ILogger<DotnetController> logger)
        {
            this.repository = repository;
            _logger = logger;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotnetMetricCreateRequest request)
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

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotnetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new DotnetMetricDto { Time = metric.Time.ToString(), Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }

        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentDotnet([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"Dotnet response: ");
        }

       
    }
}
