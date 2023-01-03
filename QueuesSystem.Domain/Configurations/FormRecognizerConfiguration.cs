using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Domain.Configurations
{
    public class FormRecognizerConfiguration
    {
        public string Endpoint { get; set; }
        public string ApiKey { get; set; }
        public string ModelId { get; set; }
    }
}
