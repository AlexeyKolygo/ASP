using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly IDbRepository<CpuMetricManager> _cpuMetricsRepo;


        public CpuMetricsController(IDbRepository<CpuMetricManager> cpuMetricsRepo)
        {
            _cpuMetricsRepo = cpuMetricsRepo;
        }

        [HttpGet]
        public Task<List<CpuMetricManager>> GetAll()
        {
            return _cpuMetricsRepo.GetAll().ToListAsync();
        }
    }
}
