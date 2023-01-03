using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Domain.Entities
{
    public class Queue : BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
