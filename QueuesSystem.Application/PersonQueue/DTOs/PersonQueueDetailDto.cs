using QueuesSystem.Application.Generic.DTOs;
using QueuesSystem.Application.Person.DTOs;
using QueuesSystem.Application.Queue.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.PersonQueue.DTOs
{
    public class PersonQueueDetailDto : BaseDto
    {
        public int PersonId { get; set; }
        public int QueueId { get; set; }
        public int State { get; set; }
        public int PreferenceLevel { get; set; }
        public DateTime ArrivedTime { get; set; }
        public PersonDetailDto? Person { get; set; } = null!;
        public QueueDetailDto? Queue { get; set; } = null!;
    }
}
