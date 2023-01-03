using QueuesSystem.Application.Generic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Queue.DTOs
{
    public class QueueUpdateDto : BaseDto
    {
        public string Name { get; set; } = null!;
    }
}
