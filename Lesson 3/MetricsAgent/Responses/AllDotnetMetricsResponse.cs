using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Responses
{
    public class AllDotNetMetricsResponse
    {
        public List<DotnetMetricDto> Metrics { get; set; }
    }

    public class DotnetMetricDto
    {
        public string Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }

}
