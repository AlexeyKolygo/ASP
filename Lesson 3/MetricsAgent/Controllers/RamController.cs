using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentRAM([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"Ram response: ");
        }
    }
}
