using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Models;
using WebApplication1.Models;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private AgentsList _agentsList;

        public AgentsController(AgentsList agentsList)
        {
            _agentsList = agentsList;
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgent([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgent([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _agentsList.AddNewAgent(agentInfo);
            return Ok();
        }
        
        [HttpGet("agentslist")]
        public IActionResult GetAgentsList()
        {
            return Ok(_agentsList.GetAgents());
        }

    }
}
