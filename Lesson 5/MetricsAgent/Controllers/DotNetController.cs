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
    public class DotNetController : ControllerBase

    {
        private readonly IDbRepository<DotNetMetric> _dotnetMetricsRepo;
        private readonly ILogger<DotNetController> _logger;

        
        public DotNetController(IDbRepository<DotNetMetric> dotnetMetricsRepo, ILogger<DotNetController> logger)
        {
            _dotnetMetricsRepo = dotnetMetricsRepo;
            _logger = logger;
        }

        [HttpGet]
        public Task<List<DotNetMetric>> GetAll()
        {
            return _dotnetMetricsRepo.GetAll().ToListAsync();
        }

        [HttpPost]
        public Task Add(DotNetMetric metric)
        {
            return _dotnetMetricsRepo.AddAsync(metric);
        }

        [HttpPut]
        public Task Update(DotNetMetric metric)
        {
            return _dotnetMetricsRepo.UpdateAsync(metric);
        }

        [HttpDelete]
        public Task Delete(DotNetMetric metric)
        {
            return _dotnetMetricsRepo.DeleteAsync(metric);
        }

    }
}
