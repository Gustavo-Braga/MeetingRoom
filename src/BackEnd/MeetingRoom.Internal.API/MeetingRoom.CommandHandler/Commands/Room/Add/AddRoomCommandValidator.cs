using FluentValidation;

namespace MeetingRoom.CommandHandler.Commands.Room.Add
{
    public class AddRoomCommandValidator : AbstractValidator<AddRoomCommand>
    {
        public AddRoomCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome da sala não pode ser vazio");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Nome da sala deve conter no máximo 50 caracteres");

            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Descrição da sala deve conter no máximo 100 caracteres");
        }
    }
}
