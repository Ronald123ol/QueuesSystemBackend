using FluentValidation;
using QueuesSystem.Application.Person.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Person.Validators
{
    public class PersonAddDtoValidator : AbstractValidator<PersonAddDto>
    {
        public PersonAddDtoValidator()
        {
            RuleFor(x => x.Pregnant)
                .NotEmpty();

            RuleFor(x => x.HealthIssues)
                .NotEmpty();

            RuleFor(x => x.Height)
                .NotEmpty()
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Weight)
                .NotEmpty()
                .GreaterThanOrEqualTo(1);
        }
    }
}
