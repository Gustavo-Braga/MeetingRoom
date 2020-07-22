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
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public RoomQueryHandler(IMapper mapper, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<RoomDto>>(await _roomRepository.GetAsync(x => !string.IsNullOrEmpty(request.Name) ? x.Name == request.Name : true));
        }
    }
}
