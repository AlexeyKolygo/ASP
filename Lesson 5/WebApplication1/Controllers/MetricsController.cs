using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase

    {
        private readonly ILogger<MetricsController> _logger;

        public MetricsController(ILogger<MetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsController");
        }


        [HttpGet("cpu/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentCPU([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation(agentId.ToString() + fromTime.ToString() + toTime.ToString());

            return Ok($"CPU response: "); 
        }

        [HttpGet("cpu/cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation( fromTime.ToString() + toTime.ToString());
            return Ok();
        }


        [HttpGet("dotnet/errors-count/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentDotnet([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation(agentId.ToString() + fromTime.ToString() + toTime.ToString());
            return Ok($"Dotnet response: ");
        }


        [HttpGet("network/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentNetwork([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation(fromTime.ToString() + toTime.ToString());
            return Ok($"Network response: ");
        }


        [HttpGet("hdd/{agentId}/left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentHDD([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation(fromTime.ToString() + toTime.ToString());
            return Ok($"HDD response: ");
        }

        [HttpGet("ram/{agentId}/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentRAM([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation(agentId.ToString() + fromTime.ToString() + toTime.ToString());
            return Ok($"Ram response: ");
        }


    }
}
