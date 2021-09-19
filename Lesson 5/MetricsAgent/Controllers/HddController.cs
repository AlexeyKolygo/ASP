using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HddController : ControllerBase
    {
        private readonly IDbRepository<HDDMetric> _hddMetricsRepo;
        private readonly ILogger<HddController> _logger;


        public HddController(IDbRepository<HDDMetric> hddMetricsRepo, ILogger<HddController> logger)
        {
            _hddMetricsRepo = hddMetricsRepo;
            _logger = logger;
        }

        [HttpGet]
        public Task<List<HDDMetric>> GetAll()
        {
            return _hddMetricsRepo.GetAll().ToListAsync();
        }

        [HttpPost]
        public Task Add(HDDMetric metric)
        {
            return _hddMetricsRepo.AddAsync(metric);
        }

        [HttpPut]
        public Task Update(HDDMetric metric)
        {
            return _hddMetricsRepo.UpdateAsync(metric);
        }

        [HttpDelete]
        public Task Delete(HDDMetric metric)
        {
            return _hddMetricsRepo.DeleteAsync(metric);
        }

    }
}
