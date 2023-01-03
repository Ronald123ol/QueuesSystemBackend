using AutoMapper;
using QueuesSystem.Application.Person.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Person.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDetailDto, Domain.Entities.Person>().ReverseMap();
            CreateMap<PersonAddDto, Domain.Entities.Person>().ReverseMap();
        }
    }
}
