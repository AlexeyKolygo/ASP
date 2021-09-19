using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DB
{
    public class HDDMetric:BaseEntity
    {
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
