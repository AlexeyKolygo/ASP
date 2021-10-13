using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity.DB
{
    public class RamMetricsDTO
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
    }
}
