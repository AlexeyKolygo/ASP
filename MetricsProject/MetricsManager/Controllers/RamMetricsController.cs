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

namespace MetricsManager.Controllers
{
    [Route("api/Agents/[controller]")]
    [ApiController]
    public class AgentsRamMetricsController : ControllerBase
    {
        private readonly IDbRepository<Agents> _agentsrepo;
        private readonly IDbRepository<RamMetricsManager> _ramrepo;
        private readonly IMapper mapper;


        public AgentsRamMetricsController(IDbRepository<Agents> agentsrepo, IDbRepository<RamMetricsManager> ramrepo, IMapper mapper)
        {
            _agentsrepo = agentsrepo;
            _ramrepo = ramrepo;
            this.mapper = mapper;
        }

        [HttpGet("GetAllRamMetrics")]
        public async Task<IActionResult> GetAllRamMetricsByAgentId([FromQuery] int id)
        {
            var url = _agentsrepo.GetAll().FirstOrDefault(x => x.Id == id).AgentURL;
            var machinename = _agentsrepo.GetAll().FirstOrDefault(x => x.Id == id).MachineName;
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url + "/RAM")
            };
            var response = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
            var jsonString = JsonSerializer.Deserialize<RamMetricsDTO[]>(response);

            foreach (var metric in jsonString)
            {
                var entry = new RamMetricsManager();
                entry.Time = metric.Time;
                entry.Value = metric.Value;
                entry.AgentId = id;
                entry.MachineName = machinename;
                await _ramrepo.AddAsync(entry);
            }

            return Ok(jsonString);
        }

        [HttpGet("GetCpuMetricsByTime")]
        public async Task<IActionResult> GetRamByTime([FromQuery] int id, string from, string to)
        {
            var url = _agentsrepo.GetAll().FirstOrDefault(x => x.Id == id).AgentURL;
            var machinename = _agentsrepo.GetAll().FirstOrDefault(x => x.Id == id).MachineName;
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url + $"/RAM/from/{from}/to/{to}")
            };
            var response = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
            var jsonString = JsonSerializer.Deserialize<RamMetricsDTO[]>(response);

            return Ok(jsonString);
        }
    }
}
