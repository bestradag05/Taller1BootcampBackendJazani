﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.Users
{
    public class UserAuthDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
