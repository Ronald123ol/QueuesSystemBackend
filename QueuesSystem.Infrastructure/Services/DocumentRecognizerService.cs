using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using QueuesSystem.Application.Interfaces;
using QueuesSystem.Application.Person.Models;
using QueuesSystem.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Infrastructure.Services
{
    public class DocumentRecognizerService : IDocumentRecognizerService
    {
        private readonly FormRecognizerConfiguration _formRecognizerConfiguration;
        private readonly AzureKeyCredential _azureKeyCredential;
        public DocumentRecognizerService(
            IOptions<FormRecognizerConfiguration> formRecognizerConfiguration)
        {
            _formRecognizerConfiguration = formRecognizerConfiguration.Value;
            _azureKeyCredential = new AzureKeyCredential(_formRecognizerConfiguration.ApiKey);
        }

        public async Task<PersonDocumentModel> GetRecognizedDocument(IFormFile documentFile)
        {
            using var stream = documentFile.OpenReadStream();

            var client = new DocumentAnalysisClient(new Uri(_formRecognizerConfiguration.Endpoint), _azureKeyCredential);

            var operation = await client.AnalyzeDocumentAsync(
                WaitUntil.Completed,
                _formRecognizerConfiguration.ModelId,
                stream);

            var operationResult = operation.Value;
            var fields = operationResult?.Documents?.FirstOrDefault()?.Fields;

            var personDocument = new PersonDocumentModel();

            if (fields == default)
                return personDocument;

            personDocument.Name = fields.GetValueOrDefault("Name")?.Value?.AsString();
            personDocument.LastName = fields.GetValueOrDefault("LastName")?.Value?.AsString();
            personDocument.IdentificationNumber = fields.GetValueOrDefault("IdentificationNumber")?.Value?.AsString().Replace("-", string.Empty);
            personDocument.Gender = char.Parse(fields.GetValueOrDefault("Gender")?.Value.AsString());
            personDocument.Birthdate = ConvertStringToDatetime(fields.GetValueOrDefault("Birthdate")?.Value.AsString());


            return personDocument;
        }

        private DateTime ConvertStringToDatetime(string DateString)
        {
            var date = DateTime.ParseExact(DateString, "dd MMMM yyyy", new CultureInfo("es-ES"));
            return date;
        }
    }
}
