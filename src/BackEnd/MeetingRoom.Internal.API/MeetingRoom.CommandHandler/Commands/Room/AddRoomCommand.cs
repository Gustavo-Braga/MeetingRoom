using MediatR;

namespace MeetingRoom.CommandHandler.Commands.Room
{
    public class AddRoomCommand : IRequest<AddRoomResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
