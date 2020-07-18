using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Services
{
    public class RoomService: IRoomService
    {
        public readonly IRepository<Room> _roomRepository;
        public readonly IUnitOfWork _unitOfWork;

        public RoomService(IRepository<Room> roomRepository, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> AddRoom(Room room)
        {
            return await Task.Run(async () =>
            {
                var entity = (Room)await _roomRepository.AddAsync(room);
                await _unitOfWork.CommitAsync();

                return entity.Id;
            });
        }
    }
}
