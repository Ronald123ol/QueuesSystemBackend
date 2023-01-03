using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Domain.Enumerables
{
    public enum State : int
    {
        InQueue = 1,
        Active = 2,
        Attended = 3
    }
}
