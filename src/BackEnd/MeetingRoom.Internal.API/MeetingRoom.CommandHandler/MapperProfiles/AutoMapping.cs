using AutoMapper;
using MeetingRoom.CommandHandler.Commands.Room.Add;
using MeetingRoom.CommandHandler.Commands.Room.Update;
using MeetingRoom.CommandHandler.Commands.Scheduler.Add;
using MeetingRoom.CommandHandler.Commands.Scheduler.Update;
using MeetingRoom.Domain.Models;
using System.Linq;

namespace MeetingRoom.CommandHandler.MapperProfiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AddRoomCommand, Room>();
            CreateMap<UpdateRoomCommand, Room>();

            CreateMap<AddSchedulerCommand, Scheduler>()
                 .ForMember(src => src.RoomSchedulers, map => map.MapFrom(src => src.Rooms.Select(room => new RoomScheduler { IdRoom = room })));

            CreateMap<UpdateSchedulerCommand, Scheduler>()
                .ForMember(src => src.RoomSchedulers, map => map.MapFrom(src => src.Rooms.Select(room => new RoomScheduler { IdRoom = room, IdScheduler = src.Id})));
        }
    }
}
