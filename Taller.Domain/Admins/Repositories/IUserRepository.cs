﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;
using Taller.Domain.Cores.Repositories;

namespace Taller.Domain.Admins.Repositories
{
    public interface IUserRepository : ICrudRepository<User, int>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
