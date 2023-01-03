using QueuesSystem.Application.Generic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Interfaces
{
    public interface IPersonService : IBaseCrudService<Domain.Entities.Person>
    {
    }
}
