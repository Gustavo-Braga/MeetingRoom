using AutoMapper;
using MeetingRoom.CommandHandler.Commands.Room.Add;
using MeetingRoom.CommandHandler.Commands.Room.Update;
using MeetingRoom.CommandHandler.Commands.Scheduler.Add;
using MeetingRoom.CommandHandler.Commands.Scheduler.Update;
using MeetingRoom.Domain.Models;

namespace MeetingRoom.CommandHandler.MapperProfiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AddRoomCommand, Room>().ReverseMap();
            CreateMap<UpdateRoomCommand, Room>().ReverseMap();

            CreateMap<AddSchedulerCommand, Scheduler>().ReverseMap();
            CreateMap<UpdateSchedulerCommand, Scheduler>().ReverseMap();
        }
    }
}
