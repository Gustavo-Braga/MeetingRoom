using MediatR;
using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Factories
{
    public class RoomSchedulerFactory : IRoomSchedulerFactory
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ISchedulerRepository _schedulerRepository;
        public readonly IMediator _mediator;

        public RoomSchedulerFactory(IRoomRepository roomRepository, ISchedulerRepository schedulerRepository, IMediator mediator)
        {
            _roomRepository = roomRepository;
            _schedulerRepository = schedulerRepository;
            _mediator = mediator;
        }


        public async Task AddOrUpdateRoomScheduler(Scheduler schedulerRequest, IList<Guid> idRooms)
        {
            try
            {
                //var roomsToAdd = _roomRepository.GetRoomsById(idRooms);
                //var scheduler = _schedulerService.GetSchedulerWithRooms(schedulerRequest.Id);



            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
