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
using System.Web;

namespace MetricsManager.Controllers
{
    [Route("api/Agents/[controller]")]
    [ApiController]
    public class AgentsCpuMetricsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;
        private readonly IDbRepository<Agents> _agentsrepo;
        private readonly IDbRepository<CpuMetricsManager> _cpurepo;
        private readonly IMapper mapper;


        public AgentsCpuMetricsController(ILogger<AgentsController> logger, IDbRepository<Agents> agentsrepo, IDbRepository<CpuMetricsManager> cpurepo, IMapper mapper)
        {
            _logger = logger;
            _agentsrepo = agentsrepo;
            _cpurepo = cpurepo;
            this.mapper = mapper;
        }

        [HttpGet("GetAllCpuMetrics")]
        public async Task<IActionResult> GetAllCpuMetricsByAgentId([FromQuery] int id)
        {
            var url = _agentsrepo.GetAll().FirstOrDefault(x => x.Id == id).AgentURL;
            var machinename = _agentsrepo.GetAll().FirstOrDefault(x => x.Id == id).MachineName;
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url + "/cpu")
            };
            var response = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
            var jsonString = JsonSerializer.Deserialize<CpuMetricsDTO[]>(response);

            foreach (var metric in jsonString)
            {
                var entry = new CpuMetricsManager();
                entry.Time = metric.Time;
                entry.Value = metric.Value;
                entry.AgentId = id;
                entry.MachineName = machinename;
                await _cpurepo.AddAsync(entry);
            }

            return Ok(jsonString);
        }

        [HttpGet("GetCpuMetricsByTime")]
        public async Task<IActionResult> GetCPUmetricsbytime([FromQuery] int id, DateTime from, DateTime to)
        {
            var result =  _cpurepo.GetAll().Where(metric =>metric.AgentId==id).Where(metric => metric.Time >= from && metric.Time <= to);
            
            return Ok(result);
        }

        [HttpGet("GetCpuMetricsByTime_ValuesOnly")]
        public async Task<IActionResult> GetCPUmetricsValuesOnly([FromHeader]  int id)
        {
             DateTime from = DateTime.Now.AddMinutes(-30);
             DateTime to = DateTime.Now;

            var result = _cpurepo.GetAll()
                .Where(metric => metric.AgentId == id)
                .Where(metric => metric.Time >= from && metric.Time <= to)
                .Select(metric=>metric.Value);
            
            return Ok(result);
        }
    }
}
