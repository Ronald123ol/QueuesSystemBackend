using FluentValidation;
using QueuesSystem.Application.PersonQueue.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.PersonQueue.Validators
{
    public class PersonQueueAddDtoValidator : AbstractValidator<PersonQueueAddDto>
    {
        public PersonQueueAddDtoValidator()
        {
            RuleFor(x => x.PersonId)
                .NotEmpty()
                .GreaterThan(1)
                .WithName("Invalid-PersonId")
                .WithMessage("Id de persona inválido");
        }
    }
}
