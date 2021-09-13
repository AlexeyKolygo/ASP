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
    public class HddController : ControllerBase
    {
        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgentHDD([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok($"HDD response: ");
        }
    }
}
