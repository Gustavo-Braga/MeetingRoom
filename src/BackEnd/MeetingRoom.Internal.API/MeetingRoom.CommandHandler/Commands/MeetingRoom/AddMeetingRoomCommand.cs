using MediatR;

namespace MeetingRoom.CommandHandler.Commands.MeetingRoom
{
    public class AddMeetingRoomCommand : IRequest<AddMeetingRoomResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
