using MediatR;
using MeetingRoom.CrossCutting.Notification;
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
        public readonly IMediator _mediator;

        public RoomService(IRepository<Room> roomRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<Guid> AddRoomAsync(Room request)
        {
            try
            {
                throw new Exception("Erro personalusado");
                if (!await IsDuplicated(request.Name))
                {
                    var entity = await _roomRepository.AddAsync(request);
                    await _unitOfWork.CommitAsync();

                    return entity.Id;
                }
                else
                {
                    await _mediator.Publish(new Notification("DuplicatedRoom", $"Já existe uma sala com o nome de {request.Name}"));
                }

                return new Guid();

            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("AddRoomAsync", $"Ocorreu um erro ao tentar adicionar a sala {request.Name}. Erro: \"{ex.Message}\""));
                return new Guid();
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
