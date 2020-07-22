using MediatR;
using MeetingRoom.CrossCutting.Notification;
using MeetingRoom.Domain.DTO;
using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Services
{
    public class SchedulerService : ISchedulerService
    {
        public readonly ISchedulerRepository _schedulerRepository;
        public readonly IRoomRepository _roomRepository;
        public readonly IMediator _mediator;
        public readonly IRoomSchedulerRepository _roomSchedulerRepository;

        public SchedulerService(ISchedulerRepository schedulerRepository, IRoomRepository roomRepository, IMediator mediator, IRoomSchedulerRepository roomSchedulerRepository)
        {
            _schedulerRepository = schedulerRepository;
            _roomRepository = roomRepository;
            _mediator = mediator;
            _roomSchedulerRepository = roomSchedulerRepository;
        }

        public async Task<Guid> AddSchedulerAsync(Scheduler request)
        {
            try
            {
                var entity = await _schedulerRepository.AddAsync(request);
                await _schedulerRepository.CommitAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao tentar criar o agendamento."));
            }
            return new Guid();
        }

        public async Task<bool> UpdateSchedulerAsync(Scheduler request)
        {
            try
            {
                var schedulerResponse = await _schedulerRepository.SingleOrDefault(x => x.Id == request.Id);
                if (schedulerResponse != null)
                {
                    var toInsert = request.RoomSchedulers.Where(x => !schedulerResponse.RoomSchedulers.Any(y => y.IdRoom == x.IdRoom));
                    var toRemove = schedulerResponse.RoomSchedulers.Where(x => !request.RoomSchedulers.Any(y => y.IdRoom == x.IdRoom))
                        .Select(x => new RoomScheduler { IdRoom = x.IdRoom, IdScheduler = x.IdScheduler });

                    await _schedulerRepository.DetachLocal(x => x.Id == request.Id);
                    await _schedulerRepository.UpdateAsync(request);

                    await _roomSchedulerRepository.AddRangeAsync(toInsert);
                    await _roomSchedulerRepository.RemoveRange(toRemove);

                    return await _schedulerRepository.CommitAsync();
                }
                else
                    await _mediator.Publish(new Notification("SchedulerService", $"Não foi possível localizar a agenda informada."));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao tentar alterar o agendamento."));
            }
            return false;
        }

        public async Task<bool> DeleteSchedulerAsync(Guid id)
        {
            try
            {
                var scheduler = await _schedulerRepository.SingleOrDefault(x => x.Id == id);
                if (scheduler != null && scheduler.RoomSchedulers.Any())
                {
                    await _mediator.Publish(new Notification("DeleteSchedulerAsync", $"Antes de remover esta agenda, é necessário remover todas as salas"));
                    return false;
                }
                await _schedulerRepository.DeleteAsync(id);
                return await _schedulerRepository.CommitAsync();
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("DeleteSchedulerAsync_Exception", $"Ocorreu um erro ao tentar excluir a sala solicitada."));
            }
            return false;
        }

        public async Task<List<ConflictsRoom>> GetConflictsRoom(Scheduler request)
        {
            var response = new List<ConflictsRoom>();
            try
            {
                var rooms = await _roomRepository.GetAsync(x => request.RoomSchedulers.Any(y => y.IdRoom == x.Id));
                foreach (var room in rooms)
                {
                    var schedulerConflicts = new List<SchedulerConflict>();
                    foreach (var scheduler in room.RoomSchedulers.Where(x => x.IdScheduler != request.Id).Select(x => x.Scheduler))
                    {
                        if (!(request.StartDate > scheduler.StartDate && request.StartDate > scheduler.EndDate)
                            || request.StartDate < scheduler.StartDate && request.EndDate < scheduler.StartDate)
                        {
                            schedulerConflicts.Add(new SchedulerConflict(
                                scheduler.Id,
                                scheduler.Title,
                                request.StartDate > scheduler.StartDate ? request.StartDate : scheduler.StartDate,
                                request.EndDate < scheduler.EndDate ? request.EndDate : scheduler.EndDate
                                ));
                        }
                    }
                    if (schedulerConflicts.Any())
                        response.Add(new ConflictsRoom(room.Id, room.Name, schedulerConflicts));
                }
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao consultar informações para o agendamento."));
                return response;
            }

            return response;
        }
    }
}
