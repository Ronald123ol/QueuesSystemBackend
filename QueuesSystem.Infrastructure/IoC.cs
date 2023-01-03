using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueuesSystem.Application.Interfaces;
using QueuesSystem.Infrastructure.Context;
using QueuesSystem.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IQueueService, QueueService>();
            services.AddTransient<IPersonQueueService, PersonQueueService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IDocumentRecognizerService, DocumentRecognizerService>();

            services.AddTransient<IQueuesDbContext, QueuesDbContext>();

            services.AddDbContext<QueuesDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
