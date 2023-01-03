using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdentificationNumber { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public char Gender { get; set; }
        public bool Pregnant { get; set; }
        public bool HealthIssues { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
    }
}
