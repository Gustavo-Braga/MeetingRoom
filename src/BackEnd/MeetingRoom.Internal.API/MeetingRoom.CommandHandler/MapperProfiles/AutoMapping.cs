using AutoMapper;
using MeetingRoom.CommandHandler.Commands.Room.Add;
using MeetingRoom.Domain.Models;

namespace MeetingRoom.CommandHandler.MapperProfiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AddRoomCommand, Room>().ReverseMap();
        }
    }
}
