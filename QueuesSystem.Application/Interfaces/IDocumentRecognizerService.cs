using Microsoft.AspNetCore.Http;
using QueuesSystem.Application.Person.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Interfaces
{
    public interface IDocumentRecognizerService
    {
        Task<PersonDocumentModel> GetRecognizedDocument(IFormFile documentFile);
    }
}
