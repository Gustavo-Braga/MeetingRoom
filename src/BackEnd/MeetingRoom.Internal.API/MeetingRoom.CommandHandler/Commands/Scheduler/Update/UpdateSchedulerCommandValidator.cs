using FluentValidation;
using System;
using System.Linq;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Update
{
    public class UpdateSchedulerCommandValidator : AbstractValidator<UpdateSchedulerCommand>
    {
        public UpdateSchedulerCommandValidator()
        {
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Título do agendamento deve conter no máximo 100 caracteres");
            RuleFor(x => x.StartDate).GreaterThan(DateTime.Now).WithMessage("Data de início deve ser maior que a data de agora");
            RuleFor(x => x.EndDate).GreaterThan(DateTime.Now).WithMessage("Data de termino deve ser maior que a data agora");
            RuleFor(x => x).Must(x => x.StartDate < x.EndDate).WithMessage("Data final do agendamento deve ser maior que a data inicial.");
        }
    }
}
