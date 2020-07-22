using AutoMapper;
using MediatR;
using MeetingRoom.Infra.Data.Query.Interfaces;
using MeetingRoom.Infra.Data.Query.Queries.DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Queries.Room
{
    public class RoomQueryHandler : IRequestHandler<GetRoomQuery, IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;

        public RoomQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            return await _roomRepository.GetAsync(!string.IsNullOrEmpty(request.Name) ? request.Name : null);
        }
    }
}
