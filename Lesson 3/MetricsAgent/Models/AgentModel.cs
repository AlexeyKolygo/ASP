using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models
{
    public class AgentModel
    {
        public int Value { get; }
        public DateTime Time { get; }
        public AgentModel()
        {
        }
        public AgentModel(int value, DateTime dateTime)
        {
            Value = value;
            Time = dateTime;
        }
    }
}
