using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Person.DTOs
{
    public class PersonAddDto
    {
        public IFormFile DocumentFile { get; set; } = null!;
        public bool Pregnant { get; set; }
        public bool HealthIssues { get; set; }

        public float Height { get; set; }
        public float Weight { get; set; }
    }
}
