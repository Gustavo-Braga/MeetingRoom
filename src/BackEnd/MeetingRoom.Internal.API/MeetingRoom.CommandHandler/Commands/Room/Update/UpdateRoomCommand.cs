using MediatR;
using System;
using System.Text.Json.Serialization;

namespace MeetingRoom.CommandHandler.Commands.Room.Update
{
    public class UpdateRoomCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
