using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Api.Exceptions;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.InvestmentConcepts;
using Taller.Application.Admins.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    //[ApiController]
    public class InvestmentConceptController : ControllerBase
    {

        private readonly IInvestmentConceptService _investmentConceptService;

        public InvestmentConceptController(IInvestmentConceptService investmentConceptService)
        {
            _investmentConceptService = investmentConceptService;
        }



        // GET: api/<InvestmentConceptController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentConceptDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<IEnumerable<InvestmentConceptDto>> Get()
        {
            return await _investmentConceptService.findAllAsync();
        }

        // GET api/<InvestmentConceptController>/5
        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Get(int id)
        {
            var response =  await _investmentConceptService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/<InvestmentConceptController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentConceptDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]//Formato cuando hay un error
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentConceptDto>>> Post([FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            var response =  await _investmentConceptService.CreateAsync(investmentConceptSaveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<InvestmentConceptController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentConceptDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Put(int id, [FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {

            var response = await _investmentConceptService.EditAsync(id, investmentConceptSaveDto);

            return TypedResults.Ok(response);
        }

        // DELETE api/<InvestmentConceptController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentConceptDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Delete(int id)
        {
            var response =  await _investmentConceptService.DisabledAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
