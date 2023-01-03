using FluentValidation;
using QueuesSystem.Application.Queue.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Queue.Validators
{
    public class QueueAddDtoValidator : AbstractValidator<QueueAddDto>
    {
        public QueueAddDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(150)
                .WithName("Invalid-Name")
                .WithMessage("Nombre inválido");
        }
    }

    public class QueueUpdateDtoValidator : AbstractValidator<QueueUpdateDto>
    {
        public QueueUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .WithName("Invalid-Id")
                .WithMessage("Id inválido");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(150)
                .WithName("Invalid-Name")
                .WithMessage("Nombre inválido");
        }
    }
}
