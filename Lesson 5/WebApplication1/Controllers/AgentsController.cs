using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Models;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private AgentsList _agentsList;
        private readonly ILogger<AgentsController> _logger;

        public AgentsController(AgentsList agentsList, ILogger<AgentsController> logger)
        {
            _agentsList = agentsList;
            _logger = logger;
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
            _logger.LogInformation($"Новая регистрация: {agentInfo.AgentId.ToString()} {agentInfo.AgentUri}");
            return Ok();
        }
        
        [HttpGet("agentslist")]
        public IActionResult GetAgentsList()
        {
            return Ok(_agentsList.GetAgents());
        }

    }
}
