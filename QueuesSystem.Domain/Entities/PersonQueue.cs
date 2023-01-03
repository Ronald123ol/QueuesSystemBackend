using QueuesSystem.Domain.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Domain.Entities
{
    public class PersonQueue : BaseEntity
    {
        public int PersonId { get; set; }
        public int QueueId { get; set; }
        public State State { get; set; } = State.InQueue;
        public PreferenceLevel PreferenceLevel { get; set; } = PreferenceLevel.Third;
        public DateTime ArrivedTime { get; set; } = DateTime.Now;
        public Person Person { get; set; } = null!;
        public Queue Queue { get; set; } = null!;
    }
}
