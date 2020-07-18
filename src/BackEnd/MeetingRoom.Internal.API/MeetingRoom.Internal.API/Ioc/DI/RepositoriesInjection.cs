using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using MeetingRoom.Infra.Data.Command.Repositories;
using MeetingRoom.Infra.Data.Command.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public static class RepositoriesInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Room>, Repository<Room>>();
        }
    }
}
