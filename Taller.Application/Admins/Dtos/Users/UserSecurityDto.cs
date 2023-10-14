using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Core.Securities.Entities;

namespace Taller.Application.Admins.Dtos.Users
{
    public class UserSecurityDto : UserDto
    {
        public SecurityEntity Security { get; set; }
    }
}
