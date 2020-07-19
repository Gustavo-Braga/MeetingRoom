using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Services
{
    public class RoomService : IRoomService
    {
        public readonly IRepository<Room> _roomRepository;
        public readonly IUnitOfWork _unitOfWork;

        public RoomService(IRepository<Room> roomRepository, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> AddRoomAsync(Room request)
        {
            try
            {
                if (!await IsDuplicated(request.Name))
                {
                    var entity = await _roomRepository.AddAsync(request);
                    await _unitOfWork.CommitAsync();

                    return entity.Id;
                }
                else
                {
                    //notification
                }

                return new Guid();

            }
            catch (Exception ex)
            {
                var testeEX = ex;
                //notification
                throw;
            }

        }

        public async Task<Room> UpdateRoomAsync(Room request)
        {
            try
            {
                var room = await _roomRepository.SingleOrDefault(x => x.Id == request.Id);
                if (room != null)
                {
                    if (await IsDuplicated(room.Name))
                    {
                        // notification
                    }
                    else
                    {
                        var entity = await _roomRepository.UpdateAsync(room);
                        await _unitOfWork.CommitAsync();

                        return entity;
                    }

                }
                else
                {
                    //notification
                }

                return new Room();

            }
            catch (Exception ex)
            {
                var testeEX = ex;
                //notification
                throw;
            }

        }

        public async Task<bool> DeleteRoomAsync(Guid id)
        {
            try
            {
                var room = await _roomRepository.SingleOrDefault(x => x.Id == id);
                if (room != null)
                {
                    await _roomRepository.DeleteAsync(room);
                    var response = await _unitOfWork.CommitAsync();

                    return response > 0;
                }
                else
                {
                    //notification nao localizado
                    return false;
                }
            }
            catch (Exception ex)
            {
                var testeEX = ex;
                //notification
                throw;
            }
        }

        private async Task<bool> IsDuplicated(string name)
        {
            var duplicated = await _roomRepository.SingleOrDefault(x => x.Name == name);
            return duplicated != null;

        }
    }
}
