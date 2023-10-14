using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Taller.Application.Admins.Dtos.Users;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    //[ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }





        // POST api/<UserController>
        [HttpPost]
        public async Task<Results<BadRequest, CreatedAtRoute<UserDto>>> Post([FromBody] UserSaveDto userSaveDto)
        {
            UserDto user = await _userService.CreateAsync(userSaveDto);

            return TypedResults.CreatedAtRoute(user);
        }


    }
}
