using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.DB;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricsDTO>();
            CreateMap<CpuMetricsDTO, CpuMetric>();

            CreateMap<RAMMetric, RamMetricsDTO>();
            CreateMap<RamMetricsDTO, RAMMetric>();
        }
    }
}

