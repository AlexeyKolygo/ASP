using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        [HttpGet("cpu/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentCPU([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"CPU response: "); 
        }

        [HttpGet("dotnet/errors-count/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentDotnet([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"Dotnet response: ");
        }

        [HttpGet("network/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentNetwork([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"Network response: ");
        }

        [HttpGet("hdd/{agentId}/left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentHDD([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"HDD response: ");
        }

        [HttpGet("ram/{agentId}/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentRAM([FromRoute] int agentId, [FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"Ram response: ");
        }


    }
}
