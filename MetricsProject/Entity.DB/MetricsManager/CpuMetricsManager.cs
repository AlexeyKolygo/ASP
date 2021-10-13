using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DB.MetricsManager
{
    public class CpuMetricsManager : BaseEntity
    {
      
            public int Value { get; set; }
            public DateTime Time { get; set; }
            public int AgentId { get; set; }
    }
}
