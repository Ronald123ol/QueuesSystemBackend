using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QueuesSystem.Application.Person.Handlers;
using QueuesSystem.Application.PersonQueue.Handlers;
using QueuesSystem.Application.Queue.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IQueueHandler, QueueHandler>();
            services.AddTransient<IPersonQueueHandler, PersonQueueHandler>();
            services.AddTransient<IPersonHandler, PersonHandler>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
