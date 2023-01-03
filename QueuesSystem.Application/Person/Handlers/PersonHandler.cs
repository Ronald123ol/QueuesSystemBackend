using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QueuesSystem.Application.Generic.Handlers;
using QueuesSystem.Application.Generic.Interfaces;
using QueuesSystem.Application.Interfaces;
using QueuesSystem.Application.Person.DTOs;
using QueuesSystem.Application.Person.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Person.Handlers
{
    public interface IPersonHandler : IBaseCrudHandler<Domain.Entities.Person>
    {
        Task<PersonDetailDto> GetById(int id);
        Task<List<PersonDetailDto>> GetAll();
        Task<PersonDetailDto> Create(PersonDocumentModel personDocument, PersonAddDto dto);

        Task<bool> PersonIdentificationNumberExists(string identificationNumber);
    }

    public class PersonHandler : BaseCrudHandler<Domain.Entities.Person>, IPersonHandler
    {
        private readonly IPersonService _crudService;
        private readonly IMapper _mapper;


        public PersonHandler(IPersonService crudService, IMapper mapper) : base(crudService, mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<PersonDetailDto> Create(PersonDocumentModel personDocument, PersonAddDto dto)
        {
            var identificationNumberExists = await PersonIdentificationNumberExists(personDocument.IdentificationNumber);

            if (identificationNumberExists)
                throw new InvalidOperationException("La cedula ya existe.");

            var person = _mapper.Map<Domain.Entities.Person>(dto);

            person.Name = personDocument.Name;
            person.LastName = personDocument.LastName;
            person.IdentificationNumber = personDocument.IdentificationNumber;
            person.Gender = personDocument.Gender;

            var createdPerson = await _crudService.Create(person);

            var personDetail = _mapper.Map<PersonDetailDto>(createdPerson);

            return personDetail;
        }

        public async Task<PersonDetailDto> GetById(int id)
        {
            return await base.GetById<PersonDetailDto>(id);
        }
        public async Task<List<PersonDetailDto>> GetAll()
        {
            return await base.GetAll<PersonDetailDto>();
        }
        public async Task<bool> PersonIdentificationNumberExists(string identificationNumber)
        {
            if (string.IsNullOrWhiteSpace(identificationNumber))
                return default;

            var queryResult = _crudService.Query();

            var identificationNumberExists =
                await queryResult.AnyAsync(p => p.IdentificationNumber == identificationNumber);

            return identificationNumberExists;
        }
    }
}
