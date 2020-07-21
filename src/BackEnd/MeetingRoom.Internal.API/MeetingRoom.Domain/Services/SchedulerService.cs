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

        public SchedulerService(ISchedulerRepository schedulerRepository, IRoomRepository roomRepository, IMediator mediator)
        {
            _schedulerRepository = schedulerRepository;
            _roomRepository = roomRepository;
            _mediator = mediator;
        }

        public async Task<Guid> AddSchedulerAsync(Scheduler request)
        {
            try
            {
                if (await AllowedScheduler(request))
                {
                    var entity = await _schedulerRepository.AddAsync(request);
                    await _schedulerRepository.CommitAsync();
                    return entity.Id;
                }
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao tentar criar o agendamento. Erro: {ex.Message}"));
            }
            return new Guid();
        }

        public async Task<bool> UpdateSchedulerAsync(Scheduler request)
        {
            try
            {
                if (await AllowedScheduler(request))
                {
                    var exists = await _schedulerRepository.SingleOrDefault(x => x.Id == request.Id);
                    if (exists != null)
                    {
                        await _schedulerRepository.UpdateAsync(exists);
                        return await _schedulerRepository.CommitAsync();
                    }
                    else
                        await _mediator.Publish(new Notification("SchedulerNotFoun", $"Não foi possível localizar o agendamento solicitado."));
                }
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao tentar alterar o agendamento. Erro: {ex.Message}"));
            }
            return false;
        }

        public async Task<bool> DeleteSchedulerAsync(Guid id)
        {
            try
            {
                await _schedulerRepository.DeleteAsync(id);
                return await _schedulerRepository.CommitAsync();
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
                var room = await _roomRepository.GetAsync();



                    if (request.DateIsValid)
                        return true;
                    else
                        await _mediator.Publish(new Notification("InvalidDate", "Data de inicio da reunião deve ser maior que a data de termino."));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao consultar informações para o agendamento. Erro: {ex.Message}"));
            }
            return false;
        }


        private async Task<bool> GetConflictsRoom(Scheduler request)
        {
            try
            {
                var response = new List<ConflictsRoom>();
                DateTime startConflict;
                DateTime endConflict;
                foreach (var roomScheduler in request.RoomSchedulers)
                {
                    var room = await _roomRepository.GetAsync(x=> x.Id == roomScheduler.IdRoom);

                    var teste = room.First();
                    var schedulerConflicts = new List<SchedulerConflict>();
                    foreach (var scheduler in teste.RoomSchedulers.Select(x=> x.Scheduler))
                    {
                        //if (!(request.StartDate > scheduler.StartDate && request.StartDate > scheduler.EndDate))
                        //{
                        //    response.Add()
                        //    startConflict = request.StartDate > scheduler.StartDate ? request.StartDate : scheduler.StartDate;
                        //    endConflict
                        //}
                        
    


                    }
                    var schedulers = teste.RoomSchedulers.Where(x=> x.Scheduler.StartDate >= request.StartDate)




                }
                //var room = await _roomRepository.GetAsync();



                if (request.DateIsValid)
                    return true;
                else
                    await _mediator.Publish(new Notification("InvalidDate", "Data de inicio da reunião deve ser maior que a data de termino."));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new Notification("SchedulerService_Exception", $"Ocorreu um erro ao consultar informações para o agendamento. Erro: {ex.Message}"));
            }
            return false;
        }

        //public async Task<Scheduler> GetSchedulerWithRooms(Guid id)
        //{
        //    var teste =
        //}
    }
}
