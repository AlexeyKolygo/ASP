using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DB.MetricsManager;
using Microsoft.EntityFrameworkCore;

namespace Entity.DB
{
    public class AppDbContextMng : DbContext
    {
        /// <summary>
        /// AppDbContext
        /// </summary>
        /// <param name="options">options</param>

        public DbSet<Agents> Agents { get; set; }
        public DbSet<CpuMetricsManager> CpuMetrics { get; set; }
        public DbSet<RamMetricsManager> RamMetrics { get; set; }
        public AppDbContextMng(DbContextOptions<AppDbContextMng> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
       


    }
}
