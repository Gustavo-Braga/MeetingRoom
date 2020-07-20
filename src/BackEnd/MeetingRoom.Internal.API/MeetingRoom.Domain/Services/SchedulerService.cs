using MediatR;
using MeetingRoom.CrossCutting.Notification;
using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Services
{
    public class SchedulerService : ISchedulerService
    {
        public readonly IRepository<Scheduler> _schedulerRepository;
        public readonly IRepository<Room> _roomRepository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMediator _mediator;

        public SchedulerService(IRepository<Scheduler> schedulerRepository, IRepository<Room> roomRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _schedulerRepository = schedulerRepository;
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<Guid> AddSchedulerAsync(Scheduler request)
        {
            try
            {
                if (await AllowedScheduler(request))
                {
                    var entity = await _schedulerRepository.AddAsync(request);
                    await _unitOfWork.CommitAsync();
                    return entity.Id;
                }
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao tentar criar o agendamento. Erro: {ex.Message}"));
            }
            return new Guid();
        }

        public async Task UpdateSchedulerAsync(Scheduler request)
        {
            try
            {
                if (await AllowedScheduler(request))
                {
                    var exists = await _schedulerRepository.SingleOrDefault(x => x.Id == request.Id);
                    if (exists != null)
                    {
                        await _schedulerRepository.UpdateAsync(exists, request);
                        await _unitOfWork.CommitAsync();
                    }
                    else
                        await _mediator.Publish(new Notification("SchedulerNotFoun", $"Não foi possível localizar o agendamento solicitado."));
                }
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao tentar alterar o agendamento. Erro: {ex.Message}"));
            }
        }

        public async Task<bool> DeleteSchedulerAsync(Guid id)
        {
            try
            {
                var scheduler = await _schedulerRepository.SingleOrDefault(x => x.Id == id);
                if (scheduler != null)
                {
                    await _schedulerRepository.DeleteAsync(scheduler);
                    var response = await _unitOfWork.CommitAsync();

                    return response > 0;
                }
                else
                    await _mediator.Publish(new Notification("RoomNotFoun", $"Não foi possível localizar a sala solicitada."));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("DeleteRoomAsync_Exception", $"Ocorreu um erro ao tentar excluir a sala solicitada. Erro: {ex.Message}"));
            }

            return false;
        }

        private async Task<Room> GetRoom(Guid id)
        {
            var room = await _roomRepository.SingleOrDefault(x => x.Id == id);
            return room;
        }

        private async Task<bool> AllowedScheduler(Scheduler request)
        {
            try
            {
                var room = await GetRoom(request.IdRoom);
                if (room != null)
                {
                    if (request.DateIsValid)
                        return true;
                    else
                        await _mediator.Publish(new Notification("InvalidDate", "Data de inicio da reunião deve ser maior que a data de termino."));
                }
                else
                    await _mediator.Publish(new Notification("InvalidRoom", "Não foi possível localizar a sala."));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao consultar informações para o agendamento. Erro: {ex.Message}"));
            }
            return false;
        }
    }
}
