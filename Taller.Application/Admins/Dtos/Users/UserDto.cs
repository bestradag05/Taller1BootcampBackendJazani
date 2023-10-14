using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Cores.Models;

namespace Taller.Application.Admins.Dtos.Users
{
    public class UserDto 
    {

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? LastName { get; set; }
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int RoleId { get; set; }

    }
}
