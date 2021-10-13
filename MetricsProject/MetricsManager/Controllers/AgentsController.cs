using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Entity.DB;
using Entity.DB.MetricsManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rest;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {

        private readonly ILogger<AgentsController> _logger;
        private readonly IDbRepository<Agents> _agentsrepo;
        private readonly IMapper mapper;

        public AgentsController(ILogger<AgentsController> logger, IDbRepository<Agents> agentsrepo, IDbRepository<CpuMetricsManager> cpurepo, IMapper mapper)
        {
            _logger = logger;
            _agentsrepo = agentsrepo;
            this.mapper = mapper;

        }

        [HttpPut("enable/{agentId}")]
        public async Task<List<Agents>> EnableAgent([FromRoute] int agentId)
        {
            int id = agentId;
            var agents = _agentsrepo.GetAll().Where(x => x.Id == id).ToListAsync();
            var response = new List<Agents>();

            foreach (var agent in await agents)
            {
                agent.IsEnabled = true;
                response.Add(agent);
                await _agentsrepo.UpdateAsync(agent);
            }

            return response;
        }

        [HttpPut("disable/{agentId}")]
        public async Task<List<Agents>> DisableAgent([FromRoute] int agentId)
        {
            int id = agentId;
            var agents = _agentsrepo.GetAll().Where(x => x.Id == id).ToListAsync();
            var response = new List<Agents>();

            foreach (var agent in await agents)
            {
                agent.IsEnabled = false;
                response.Add(agent);
                await _agentsrepo.UpdateAsync(agent);
            }

            return response;
        }

        [HttpPost("register")]
        public IActionResult Register([FromQuery] string AgentURL)
        {
            var MachineName = Environment.MachineName;
            var newAgent = new Agents();

            newAgent.MachineName = MachineName;
            newAgent.AgentURL = AgentURL;
            newAgent.IsEnabled = false;
            _agentsrepo.AddAsync(newAgent);
            var agent = _agentsrepo.GetAll().FirstOrDefault(x => x.AgentURL == AgentURL);
            return Ok($"Your agent ID is:{agent.Id}");
        }

        [HttpGet("agentslist")]
        public async Task<List<AgentsDTO>> GetAll()
        {
            var agents = _agentsrepo.GetAll().ToListAsync();
            var response = new List<AgentsDTO>();

            foreach (var agent in await agents)
            {
                var m = mapper.Map<AgentsDTO>(agent);
                response.Add(m);
            }

            return response;
        }

        

    }
}
