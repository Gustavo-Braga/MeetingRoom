using MediatR;
using System;

namespace MeetingRoom.CommandHandler.Commands.Room.Delete
{

    public class DeleteRoomCommand : IRequest<Unit>
    {
        public DeleteRoomCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
