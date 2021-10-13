using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DB
{
    public class AgentsDTO
    {
        public int id { get; set; }
        public bool IsEnabled { get; set; }
        public string MachineName { get; set; }
        public string AgentURL { get; set; }
    }
}
