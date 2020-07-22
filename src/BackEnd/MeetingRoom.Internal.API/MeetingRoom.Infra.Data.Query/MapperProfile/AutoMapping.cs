using AutoMapper;
using MeetingRoom.Infra.Data.Query.Entities;
using MeetingRoom.Infra.Data.Query.Queries.DTO;
using MeetingRoom.Infra.Data.Query.Queries.Scheduler;

namespace MeetingRoom.Infra.Data.Query.MapperProfile
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<RoomDto, Room>().ReverseMap();
        }
    }
}
