using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DB
{
    public class HDDMetricManager:BaseEntity
    {
        public int Value { get; set; }
        public string Time { get; set; }
        public Uri MachineID { get; set; }
    }
}
