using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Api.Exceptions;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    //[ApiController]
    public class HolderController : ControllerBase
    {
        private readonly IHolderService _holderService;

        public HolderController(IHolderService holderService)
        {
            _holderService = holderService;
        }



        // GET: api/<HolderController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<IEnumerable<HolderDto>> Get()
        {
            return await _holderService.findAllAsync();
        }

        // GET api/<HolderController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<HolderDto>>> Get(int id)
        {
            var response = await _holderService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<HolderController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HolderDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]//Formato cuando hay un error
        public async Task<Results<BadRequest, CreatedAtRoute<HolderDto>>> Post([FromBody] HolderSaveDto holderSaveDto) 
        {
            var response = await _holderService.CreateAsync(holderSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<HolderController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<HolderDto>>> Put(int id, [FromBody] HolderSaveDto holderSaveDto)
        {
            var response = await _holderService.EditAsync(id, holderSaveDto);
            return TypedResults.Ok(response);
            
        }

        // DELETE api/<HolderController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<HolderDto>>> Delete(int id)
        {
            var response =  await _holderService.DisabledAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
