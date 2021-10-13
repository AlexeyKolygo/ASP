using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entity.DB
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// AppDbContext
        /// </summary>
        /// <param name="options">options</param>

        public DbSet<CpuMetric> CpuMetrics { get; set; }
        public DbSet<RAMMetric> RamMetrics { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
       


    }
}
