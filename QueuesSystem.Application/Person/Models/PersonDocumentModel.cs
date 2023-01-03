using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Person.Models
{
    public class PersonDocumentModel
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdentificationNumber { get; set; } = null!;
        public char Gender { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
