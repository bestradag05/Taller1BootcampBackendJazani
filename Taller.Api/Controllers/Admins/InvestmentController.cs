using Microsoft.AspNetCore.Mvc;
using Taller.Application.Admins.Dtos.Investments;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;

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
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
            return await _investmentService.findAllAsync();
        }

        // GET api/<InvestmentController>/5
        [HttpGet("{id}")]
        public async Task<InvestmentDto> Get(int id)
        {
            return await _investmentService.FindByIdAsync(id);
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
    }
}
