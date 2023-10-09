using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taller.Application.Admins.Dtos.Permissions;
using Taller.Application.Admins.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    //Comentado, ya que no pertecene al taller 3 del bootcamp

    //    [Route("api/[controller]")]
    //    [ApiController]
    //    public class PermissionController : ControllerBase
    //    {
    //        private readonly IPermissionServices _permissionServices;
    //        private readonly IMapper _mapper;

    //        public PermissionController(IPermissionServices permissionServices, IMapper mapper)
    //        {
    //            _permissionServices = permissionServices;
    //            _mapper = mapper;
    //        }





    //        // GET: api/<PermissionController>
    //        [HttpGet]
    //        public async Task<IEnumerable<PermissionDto>> Get()
    //        {
    //            return await _permissionServices.findAllAsync();
    //        }

    //        // GET api/<PermissionController>/5
    //        [HttpGet("{id}")]
    //        public async Task<PermissionDto> Get(int id)
    //        {
    //            return await _permissionServices.FindByIdAsync(id);
    //        }

    //        // POST api/<PermissionController>
    //        [HttpPost]
    //        public async Task<PermissionDto> Post([FromBody] PermissionSaveDto saveDto)
    //        {
    //            return await _permissionServices.CreateAsync(saveDto);
    //        }

    //        // PUT api/<PermissionController>/5
    //        [HttpPut("{id}")]
    //        public async Task<PermissionDto> Put(int id, [FromBody] PermissionSaveDto saveDto)
    //        {
    //            return await _permissionServices.EditAsync(id, saveDto);
    //        }

    //        // DELETE api/<PermissionController>/5
    //        [HttpDelete("{id}")]
    //        public async Task<PermissionDto> Delete(int id)
    //        {
    //            return await _permissionServices.DisabledAsync(id);
    //        }
    //    }
}
