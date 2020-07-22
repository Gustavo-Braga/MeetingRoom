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
        public readonly IRoomRepository _roomRepository;
        public readonly IMediator _mediator;

        public RoomService(IRoomRepository roomRepository, IMediator mediator)
        {
            _roomRepository = roomRepository;
            _mediator = mediator;
        }

        public async Task<Guid> AddRoomAsync(Room request)
        {
            try
            {
                if (!await IsDuplicated(request.Name))
                {
                    var entity = await _roomRepository.AddAsync(request);
                    await _roomRepository.CommitAsync();

                    return entity.Id;
                }
                else
                    await _mediator.Publish(new Notification("DuplicatedRoom", $"Já existe uma sala com o nome de {request.Name}."));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("AddRoomAsync_Exception", $"Ocorreu um erro ao tentar adicionar a sala {request.Name}. Erro: {ex.Message}"));
            }

            return new Guid();

        }

        public async Task<bool> UpdateRoomAsync(Room request)
        {
            try
            {
                if (await IsDuplicated(request.Name))
                    await _mediator.Publish(new Notification("DuplicatedRoom", $"Já existe uma sala com o nome de {request.Name}."));
                else
                {
                    await _roomRepository.UpdateAsync(request);
                    return await _roomRepository.CommitAsync();
                }
            }
            catch (Exception)
            {
                await _mediator.Publish(new Notification("UpdateRoomAsync_Exception", $"Ocorreu um erro ao tentar alterar a sala solicitada."));
            }
            return false;
        }

        public async Task<bool> DeleteRoomAsync(Guid id)
        {
            try
            {
                await _roomRepository.DeleteAsync(id);
                return await _roomRepository.CommitAsync();
            }
            catch (Exception)
            {
                await _mediator.Publish(new Notification("DeleteRoomAsync_Exception", $"Ocorreu um erro ao tentar excluir a sala solicitada."));
            }

            return false;
        }

        private async Task<bool> IsDuplicated(string name)
        {
            var duplicated = await _roomRepository.SingleOrDefault(x => x.Name == name);
            return duplicated != null;
        }
    }
}
