using Application.Command;
using Application.Interfaces;
using Application.Services;
using Entities.Events;
using FluentValidation.Results;
using Infraestructure.EventSourcing;
using Infraestructure.Interfaces;
using Infraestructure.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class ClienteInjection
    {

        public static void AddInjectionRepository(this IServiceCollection services)
        {


            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
        }

        public static void AddInjectionEvents(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<ClienteRegisterEvent>, ClienteEventHandler>();
            services.AddScoped<IRequestHandler<RegisterClienteCommand, ValidationResult>, ClienteCommandHandler>();

        }

        public static void AddInjectionService(this IServiceCollection services)
        {

            services.AddScoped<IClienteAppService, ClienteAppService>();
        }
    }
}