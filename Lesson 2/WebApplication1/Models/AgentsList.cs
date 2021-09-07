using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Models;

namespace WebApplication1.Models
{
    public class AgentsList
    {

        private List<AgentInfo> _agents = new();

        public void AddNewAgent(AgentInfo agentInfo)
        {
            _agents.Add(agentInfo);
        }

        public List<AgentInfo> GetAgents()
        {
            return _agents;
        }
    }
}
