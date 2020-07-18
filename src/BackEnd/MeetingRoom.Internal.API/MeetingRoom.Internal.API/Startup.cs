using MeetingRoom.Infra.Data.Command.Context;
using MeetingRoom.Internal.API.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MeetingRoom.Internal.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Meeting Room",
                    Description = "Api criada para gerenciar salas de reuniões",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Gustavo Braga",
                        Email = "gustavo.braga10@outlook.com"
                    }
                });
                c.EnableAnnotations();
            });

            services.AddDbContext<MeetingRoomDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MeetingRoom"));
            });



            services.AddScoped<MeetingRoomDBContext, MeetingRoomDBContext>();

            Bootstrapper.Initialize(services);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MeetingRoomDBContext>();
                context.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
