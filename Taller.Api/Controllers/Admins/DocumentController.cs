using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Api.Exceptions;
using Taller.Application.Admins.Dtos.Documents;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.InvestmentConcepts;
using Taller.Application.Admins.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    //[ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }



        // GET: api/<DocumentController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<IEnumerable<DocumentDto>> Get()
        {
            return await _documentService.findAllAsync();
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<DocumentDto>>> Get(int id)
        {
            var response =  await _documentService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<DocumentController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DocumentDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]//Formato cuando hay un error
        public async Task<Results<BadRequest, CreatedAtRoute<DocumentDto>>> Post([FromBody] DocumentSaveDto documentSaveDto)
        {
           var response =  await _documentService.CreateAsync(documentSaveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<DocumentDto>>> Put(int id, [FromBody] DocumentSaveDto documentSaveDto)
        {

            var response =  await _documentService.EditAsync(id, documentSaveDto);

            return TypedResults.Ok(response);
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<DocumentDto>>> Delete(int id)
        {
            var response =  await _documentService.DisabledAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
