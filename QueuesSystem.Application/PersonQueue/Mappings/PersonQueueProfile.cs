using AutoMapper;
using QueuesSystem.Application.PersonQueue.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.PersonQueue.Mappings
{
    public class PersonQueueProfile : Profile
    {
        public PersonQueueProfile()
        {
            CreateMap<PersonQueueAddDto, Domain.Entities.PersonQueue>().ReverseMap();
            CreateMap<PersonQueueDetailDto, Domain.Entities.PersonQueue>().ReverseMap();
        }
    }
}
