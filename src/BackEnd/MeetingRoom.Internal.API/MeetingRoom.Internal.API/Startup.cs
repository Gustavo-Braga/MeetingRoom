using MeetingRoom.CrossCutting.Notification;
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

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
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                 {
                     options.InvalidModelStateResponseFactory = context =>
                     {
                         if (!context.ModelState.IsValid)
                         {
                             if (context.ModelState.Values.Any())
                             {
                                 var notifications = new List<Notification>();
                                 foreach (var item in context.ModelState)
                                     if (item.Value.Errors.Any(x => !string.IsNullOrEmpty(x.ErrorMessage)))
                                         notifications.Add(new Notification(item.Key, string.Join(", ", item.Value.Errors.Select(x => x.ErrorMessage))));

                                 return new BadRequestObjectResult(new { data = default(Nullable), success = false, notifications });
                             }
                         }
                         return new BadRequestObjectResult(context.ModelState);
                     };
                 });

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

            var connectionString = Configuration.GetConnectionString("MeetingRoom");

            services.AddDbContext<MeetingRoomDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IDbConnection, DbConnection>(x => new SqlConnection(connectionString));
            services.AddScoped<MeetingRoomDBContext, MeetingRoomDBContext>();
            Bootstrapper.Initialize(services);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<MeetingRoomDBContext>();
                    context.Database.EnsureCreated();
                }
            }
            catch (System.Exception)
            {
                //log
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
