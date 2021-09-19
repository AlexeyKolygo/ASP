using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Entity.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkController : ControllerBase

    {
        private readonly IDbRepository<NetworkMetric> _networkMetricsRepo;
        private readonly ILogger<NetworkController> _logger;

        
        public NetworkController(IDbRepository<NetworkMetric> networkMetricsRepo, ILogger<NetworkController> logger)
        {
            _networkMetricsRepo = networkMetricsRepo;
            _logger = logger;
        }

        [HttpGet]
        public Task<List<NetworkMetric>> GetAll()
        {
            return _networkMetricsRepo.GetAll().ToListAsync();
        }

        [HttpPost]
        public Task Add(NetworkMetric metric)
        {
            return _networkMetricsRepo.AddAsync(metric);
        }

        [HttpPut]
        public Task Update(NetworkMetric metric)
        {
            return _networkMetricsRepo.UpdateAsync(metric);
        }

        [HttpDelete]
        public Task Delete(NetworkMetric metric)
        {
            return _networkMetricsRepo.DeleteAsync(metric);
        }

    }
}
