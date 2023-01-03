using AutoMapper;
using QueuesSystem.Application.Interfaces;
using QueuesSystem.Domain.Entities;
using QueuesSystem.Infrastructure.Context;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Infrastructure.Services
{
    public class QueueService : BaseCrudService<Queue>, IQueueService
    {
        public QueueService(IQueuesDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
