using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Api.Exceptions;
using Taller.Application.Admins.Dtos.Documents;
using Taller.Application.Admins.Dtos.Investments;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;
using Taller.Core.Paginations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {

        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }



        // GET: api/<InvestmentController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
            return await _investmentService.findAllAsync();
        }

        // GET api/<InvestmentController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]//Formato cuando todo esta correcto
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))] //Formato cuando hay un error
        public async Task<Results<NotFound, Ok<InvestmentDto>>> Get(int id)
        {
            var response = await _investmentService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        //// POST api/<InvestmentController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<InvestmentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<InvestmentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<InvestmentDto>> PaginatedSearch([FromQuery] RequestPagination<InvestmentFilterDto> request)
        {
            return await _investmentService.PaginatedSearch(request);
        }
    }
}
