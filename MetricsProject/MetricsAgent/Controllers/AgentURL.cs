using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    public class AgentURL : ControllerBase
    {
        [Route("api/")]
        [HttpGet()]
        public IActionResult GetAgentURL()
        {
            var url = HttpContext.Request.GetDisplayUrl();

            return Ok(url);
        }
    }
}
