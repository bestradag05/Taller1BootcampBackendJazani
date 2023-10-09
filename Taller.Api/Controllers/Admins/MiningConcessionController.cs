using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Api.Exceptions;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Dtos.MiningConsessions;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
   // [ApiController]
    public class MiningConcessionController : ControllerBase
    {
        private readonly IMiningConcessionService _miningConcessionService;

        public MiningConcessionController(IMiningConcessionService miningConcessionService)
        {
            _miningConcessionService = miningConcessionService;
        }



        // GET: api/<MenuController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConsessionDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<IEnumerable<MiningConsessionDto>> Get()
        {
            return await _miningConcessionService.FindAllAsync();
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConsessionDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<MiningConsessionDto>>> Get(int id)
        {
            var response = await _miningConcessionService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/<MenuController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConsessionDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]//Formato cuando hay un error
        public async Task<Results<BadRequest, CreatedAtRoute<MiningConsessionDto>>> Post([FromBody] MiningConsessionSaveDto miningConcessionSaveDto)
        {
            var response = await _miningConcessionService.CreateAsync(miningConcessionSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConsessionDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<MiningConsessionDto>>> Put(int id, [FromBody] MiningConsessionSaveDto miningConcessionSaveDto)
        {
            var response = await _miningConcessionService.EditAsync(id, miningConcessionSaveDto);
            return TypedResults.Ok(response);

        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConsessionDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<MiningConsessionDto>>> Delete(int id)
        {
            var response = await _miningConcessionService.DiasabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
