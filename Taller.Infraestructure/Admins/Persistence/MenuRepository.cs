﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;
using Taller.Infraestructure.Cores.Context;
using Taller.Infraestructure.Cores.Persistences;

namespace Taller.Infraestructure.Admins.Persistence
{
    public class MenuRepository : CrudRepository<Menu, int>, IMenuRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Menu>> FindAllAsync()
        {
            return await _dbContext.Set<Menu>().Include(t => t.Languages).Include(t => t.Permissions).AsNoTracking().ToListAsync();
        }

        public override async Task<Menu?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Menu>()
                .Include(t => t.Languages)
                .Include(t => t.Permissions)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

    }
}
