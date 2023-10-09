using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Api.Exceptions;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.InvestmentTypes;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    //[ApiController]
    public class InvestmentTypeController : ControllerBase
    {
        private readonly IInvestmentTypeService _investmentTypeService;

        public InvestmentTypeController(IInvestmentTypeService investmentTypeService)
        {
            _investmentTypeService = investmentTypeService;
        }


        // GET: api/<InvestmentTypeController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<IEnumerable<InvestmentTypeDto>> Get()
        {
            return await _investmentTypeService.findAllAsync();
        }

        // GET api/<InvestmentTypeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<InvestmentTypeDto>>> Get(int id)
        {
            var response = await _investmentTypeService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/<InvestmentTypeController>
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]//Formato cuando hay un error
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentTypeDto>>> Post([FromBody] InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            var response =  await _investmentTypeService.CreateAsync(investmentTypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<InvestmentTypeController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<InvestmentTypeDto>>> Put(int id, [FromBody] InvestmentTypeSaveDto investmentTypeSaveDto)
        {

            var response =  await _investmentTypeService.EditAsync(id, investmentTypeSaveDto);

            return TypedResults.Ok(response);
        }

        // DELETE api/<InvestmentTypeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<InvestmentTypeDto>>> Delete(int id)
        {
            var response = await _investmentTypeService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }

    }
}
