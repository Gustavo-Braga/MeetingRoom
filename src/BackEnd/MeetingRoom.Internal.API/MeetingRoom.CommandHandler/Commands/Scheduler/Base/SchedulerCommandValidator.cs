using FluentValidation;
using System;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Base
{
    public class SchedulerCommandValidator : AbstractValidator<SchedulerCommand>
    {
        public SchedulerCommandValidator()
        {
            RuleFor(x => x.Observation).MaximumLength(100).WithMessage("Observação do agendamento deve conter no máximo 100 caracteres");
            RuleFor(x => x.Responsible).MaximumLength(100).WithMessage("Responsável do agendamento deve conter no máximo 50 caracteres");

            RuleFor(x => x.StartDate).LessThan(DateTime.Now).WithMessage("Data de início deve ser maior que a data de agora");
            RuleFor(x => x.EndDate).LessThan(DateTime.Now).WithMessage("Data de termino deve ser maior que a data agora");

            RuleFor(x => x.IdRoom).NotEmpty().WithMessage("Id da sala é obrigatório");
        }
    }
}
