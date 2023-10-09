using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Api.Exceptions;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Dtos.PeriodTypes;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    //[ApiController]
    public class PeriodTypeController : ControllerBase
    {

        private readonly IPeriodTypeService _periodTypeService;

        public PeriodTypeController(IPeriodTypeService periodTypeService)
        {
            _periodTypeService = periodTypeService;
        }



        // GET: api/<MenuController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<IEnumerable<PeriodTypeDto>> Get()
        {
            return await _periodTypeService.FindAllAsync();
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<PeriodTypeDto>>> Get(int id)
        {
            var response = await _periodTypeService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<MenuController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]//Formato cuando hay un error
        public async Task<Results<BadRequest, CreatedAtRoute<PeriodTypeDto>>> Post([FromBody] PeriodTypeSaveDto periodTypeSaveDto)
        {
            var response = await _periodTypeService.CreateAsync(periodTypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<PeriodTypeDto>>> Put(int id, [FromBody] PeriodTypeSaveDto periodTypeSaveDto)
        {
            var response = await _periodTypeService.EditAsync(id, periodTypeSaveDto);
            return TypedResults.Ok(response);
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<PeriodTypeDto>>> Delete(int id)
        {
            var response =  await _periodTypeService.DiasabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
