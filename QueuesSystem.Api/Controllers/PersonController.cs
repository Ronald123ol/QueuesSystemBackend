using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueuesSystem.Application.Generic.Models;
using QueuesSystem.Application.Interfaces;
using QueuesSystem.Application.Person.DTOs;
using QueuesSystem.Application.Person.Handlers;

namespace QueuesSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonHandler _personHandler;
        private readonly IDocumentRecognizerService _documentRecognizerService;

        public PersonController(
            IPersonHandler personHandler,
            IDocumentRecognizerService documentRecognizerService)
        {
            _personHandler = personHandler;
            _documentRecognizerService = documentRecognizerService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            var response = new ResponseModel<PersonDetailDto>();

            try
            {
                var person = await _personHandler.GetById(id);
                response.SetData(person);

                if (!response.HasData())
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.SetErrorMessage(ex);
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            var response = new ResponseModel<List<PersonDetailDto>>();

            try
            {
                var person = await _personHandler.GetAll();
                response.SetData(person);

                if (!response.HasData())
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.SetErrorMessage(ex);
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromForm] PersonAddDto personAddDto)
        {
            var response = new ResponseModel<PersonDetailDto>();

            try
            {
                var personDocument = await _documentRecognizerService.GetRecognizedDocument(personAddDto.DocumentFile);
                var person = await _personHandler.Create(personDocument, personAddDto);
                response.SetData(person);

                if (!response.HasData())
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.SetErrorMessage(ex);
                return BadRequest(response);
            }
        }
    }
}
