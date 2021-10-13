using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity.DB;

namespace MetricsManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Agents, AgentsDTO>();
            CreateMap<AgentsDTO, Agents>();
        }
    }
}
