using AutoMapper;
using QueuesSystem.Application.Queue.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Queue.Mappings
{
    public class QueueProfile : Profile
    {
        public QueueProfile()
        {
            CreateMap<QueueAddDto, Domain.Entities.Queue>().ReverseMap();
            CreateMap<QueueUpdateDto, Domain.Entities.Queue>().ReverseMap();
            CreateMap<QueueDetailDto, Domain.Entities.Queue>().ReverseMap();
        }
    }
}
