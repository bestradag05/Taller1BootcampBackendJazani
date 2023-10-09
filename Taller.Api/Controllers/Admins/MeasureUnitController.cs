using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Api.Exceptions;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.MeasureUnits;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;
using Taller.Domain.Admins.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
   // [ApiController]
    public class MeasureUnitController : ControllerBase
    {

        private readonly IMeasureUnitService _measureUnitService;

        public MeasureUnitController(IMeasureUnitService measureUnitService)
        {
            _measureUnitService = measureUnitService;
        }



        // GET: api/<MeasureUnitController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<IEnumerable<MeasureUnitDto>> Get()
        {
            return await _measureUnitService.FindAllAsync();
        }

        // GET api/<MeasureUnitController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Get(int id)
        {
            var response =  await _measureUnitService.FindByIdAsync(id);
            return TypedResults.Ok(response);

        }

        // POST api/<MeasureUnitController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeasureUnitDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]//Formato cuando hay un error
        public async Task<Results<BadRequest, CreatedAtRoute<MeasureUnitDto>>> Post([FromBody] MeasureUnitSaveDto measureSaveDto)
        {
            var response =  await _measureUnitService.CreateAsync(measureSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<MeasureUnitController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Put(int id, [FromBody] MeasureUnitSaveDto measureSaveDto)
        {

            var response = await _measureUnitService.EditAsync(id, measureSaveDto);
            return TypedResults.Ok(response);
        }

        // DELETE api/<MeasureUnitController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Delete(int id)
        {
            var response =  await _measureUnitService.DiasabledAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
